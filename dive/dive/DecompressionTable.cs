using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dive
{
    public enum GasMix { NONE, AIR, AIRO2 };


    public class DCompTable
    {
        public Dictionary<int, DCompMatrix> m_AirTable;
        public Dictionary<int, DCompMatrix> m_AirO2Table;

        public DCompTable()
        {
            m_AirTable = new Dictionary<int, DCompMatrix>();
            m_AirO2Table = new Dictionary<int, DCompMatrix>();
        }

        //update DCompMatrix by index
        public void add(int depth, DCompRow row, GasMix gasMix)
        {
            if (!m_AirTable.ContainsKey(depth))
            {
                m_AirTable.Add(depth, new DCompMatrix());
            }
            if (!m_AirO2Table.ContainsKey(depth))
            {
                m_AirO2Table.Add(depth, new DCompMatrix());
            }
            switch (gasMix)
            {
                case GasMix.AIR:
                    m_AirTable[depth].addDComp(row);
                    break;
                case GasMix.AIRO2:
                    m_AirO2Table[depth].addDComp(row);
                    break;
                case GasMix.NONE:
                default:
                    Console.Write("failed to add element on DCompTable");
                    break;
            }


            //implemented in updateBTLUT
            //g_depthList.Add(depth);
        }
        public Dictionary<int, DCompMatrix> getTable(GasMix gasMix)
        {
            Dictionary<int, DCompMatrix> table = new Dictionary<int, DCompMatrix>();
            switch (gasMix)
            {
                case GasMix.AIR:
                    table = m_AirTable;
                    break;
                case GasMix.AIRO2:
                    table = m_AirO2Table;
                    break;
            }
            return table;
        }
    }

    public class DCompMatrix
    {
        int bottomDepth = -1;
        public Dictionary<int, DCompRow> m_DComps;
        public List<int> m_bottomTimesLUT;
        public DCompMatrix()
        {
            m_bottomTimesLUT = new List<int>();
            m_DComps = new Dictionary<int, DCompRow>();
        }
        public DCompMatrix(int bottomDepth)
        {
            this.bottomDepth = bottomDepth;
            m_DComps = new Dictionary<int, DCompRow>();
        }
        public void addDComp(DCompRow newDComp)
        {
            this.m_DComps[newDComp.m_BottomTime] = newDComp;
            this.m_bottomTimesLUT.Add(newDComp.m_BottomTime);
        }

        public override string ToString()
        {
            return m_DComps[0].printDCompStops();
        }
    }

    public class DCompRow
    {
        public int m_BottomTime = 1;
        public int m_TimeToFirstStop = -1;
        public GasMix m_GasMix = GasMix.NONE;
        public int m_AscentMinute = -1;
        public int m_AscentSecond = -1;
        public double m_ChamberO2Periods = -1;
        public char m_RepeatGroup = '0';
        //Total Decompression Time
        public int m_TDT = 0;
        public int m_TDT_w_pause = 0;
        public int m_TotalPauseTime = 0;
        //ex) map[20] = 46, map [30] = 7, ...
        public SortedDictionary<int, int> m_DCompStops;
        //ex) if DCompStops[20] = 46, DCompStops[30] = 7, ... :
        //      map[30] = { 7 }, map[20] = { 23, 5, 23}
        //      under condition of MaxDCompTime = 30, pauseInterval = 5
        public SortedDictionary<int, List<int>> m_DComp_pauses_data;
        public SortedDictionary<int, int> m_DCompStops_including_pause_time;
        public bool isInitialized = false;
        public string printDCompStops()
        {
            if (!isInitialized)
            {
                return "No Data";
            }
            string result = "";
            result = "Time to first stop : " + m_TimeToFirstStop.ToString() + "Total Ascent Time : " + m_AscentMinute.ToString() + "m " + (m_AscentSecond <= 0 ? "" : (m_AscentSecond.ToString() + "s")) + ", Repeat Group : " + m_RepeatGroup.ToString() + ", Chamber O2 Periods : " + m_ChamberO2Periods.ToString() + "\n";
            foreach (var pair in m_DCompStops)
            {
                result += "Ft : " + pair.Key.ToString() + ", DCompTime(min) : " + pair.Value.ToString() + "\n";
            }
            return result;
        }

        public DCompRow()
        {
            m_DCompStops = new SortedDictionary<int, int>();
            m_DComp_pauses_data = new SortedDictionary<int, List<int>>();
            m_DCompStops_including_pause_time = new SortedDictionary<int, int>();
        }
        public DCompRow(int bottomTime, int timeToFirstStop, GasMix gasMix, double chamberO2Periods, char repeatGroup, params int[] DCompTimeFromFile)
        {
            m_DCompStops = new SortedDictionary<int, int>();
            m_DComp_pauses_data = new SortedDictionary<int, List<int>>();
            m_DCompStops_including_pause_time = new SortedDictionary<int, int>();

            var keys = m_DCompStops.Keys.ToList();

            for (int idx = 0; idx < DCompTimeFromFile.Length; idx++)
            {
                m_DCompStops.Add((20 + idx * 10), DCompTimeFromFile[idx]);
                m_TDT += DCompTimeFromFile[idx];
                //m_DCompStops[keys.ElementAt(idx)] = mapList[idx];
            }

            m_BottomTime = bottomTime;
            m_TimeToFirstStop = timeToFirstStop;
            m_GasMix = gasMix;
            m_ChamberO2Periods = chamberO2Periods;
            m_RepeatGroup = repeatGroup;

            this.UpdatePauseData();
            this.UpdateTimeIncludingPauses();

            isInitialized = true;


        }
        private void UpdateTimeIncludingPauses()
        {

            foreach (var pair in m_DComp_pauses_data)
            {
                int depth = pair.Key;
                var data = pair.Value;

                int totalMinutes = 0;
                foreach (var min in data)
                {
                    totalMinutes += min;
                }

                m_TDT_w_pause += totalMinutes;

                m_DCompStops_including_pause_time[depth] = totalMinutes;
            }
        }

        private void UpdatePauseData()
        {
            int maxDcompTime = 30;
            int pauseInterval = 5;
            int intervalFromLastPause = 0;
            bool changeGas = true;
            int gasChangingTime = 2;

            var reversed = m_DCompStops.OrderByDescending(i => i.Key);

            foreach (var pair in reversed)
            {
                int depth = pair.Key;
                int min = pair.Value;

                //init
                m_DComp_pauses_data.Add(depth, new List<int>());

                /*
                 *  while ( int + min > maxD ) :
                 *      done = max - int
                 *      dcomp (done)
                 *      min -= done
                 *      i = 0
                 *  endWhile
                 *  
                 *  dcomp (min)
                 *  int = min
                 *  
                 *  dcomp() { add_to_list(); add_pause(); }
                 */

                switch (this.m_GasMix)
                {
                    case GasMix.AIR:
                        {
                            m_DComp_pauses_data[depth].Add(min);
                        }
                        break;
                    case GasMix.AIRO2:
                        {
                            if (depth == 30 || depth == 20)
                            {
                                if (changeGas && min != 0)
                                {
                                    m_DComp_pauses_data[depth].Add(gasChangingTime);
                                    changeGas = false;
                                }
                                while (intervalFromLastPause + min >= maxDcompTime)
                                {
                                    int done = maxDcompTime - intervalFromLastPause;
                                    //dcomp (done)
                                    if(done != 0)
                                    {
                                        m_DComp_pauses_data[depth].Add(done);
                                        m_DComp_pauses_data[depth].Add(pauseInterval);
                                        m_TotalPauseTime += pauseInterval;
                                        min -= done;
                                    }
                                    intervalFromLastPause = 0;
                                }

                                //dcomp (min)
                                if (min != 0)
                                {
                                    m_DComp_pauses_data[depth].Add(min);
                                }
                                intervalFromLastPause += min;
                            }
                            else
                            {
                                m_DComp_pauses_data[depth].Add(min);
                            }
                        }
                        break;
                    case GasMix.NONE:
                    default:
                        break;
                }





                //m_DCompStops_pauses[depth] = 

            }
        }
    }

}
