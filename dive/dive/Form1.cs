﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dive
{
    
    public partial class Form1 : Form
    {
        #region Init
        public Form1()
        {
            InitializeComponent();
            initVars();
            initTBDesignators();
            initTableData();
            initAllFieldValues();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void initTBDesignators()
        {
            //Time field
            {
                g_TB_Times_READONLY.Add(TB_RB);
                g_TB_Times_READONLY.Add(TB_LB);
                g_TB_Times_READONLY.Add(TB_RS);
                g_TB_Times_READONLY.Add(TB_R1st);

                g_TB_Times_WRITE.Add(TB_LS);

                foreach(var tb in g_TB_Times_READONLY)
                {
                    g_TB_Times.Add(tb);
                }
                foreach (var tb in g_TB_Times_WRITE)
                {
                    g_TB_Times.Add(tb);
                }
            }

            //FSW field
            {
                foreach (var result in g_FSW2Interval)
                {
                    g_TB_FSW_Results.Add(result.Value);
                }
                foreach (var result in g_FSW2Time)
                {
                    g_TB_FSW_Results.Add(result.Value);
                }
            }

            //Circumstance field
            {
                g_TB_Circum_READONLY.Add(TB_Desc_Time);
                g_TB_Circum_READONLY.Add(TB_MaxDepth);
                g_TB_Circum_READONLY.Add(TB_DCompTable);
                g_TB_Circum_READONLY.Add(TB_Time_To_R1st_Actual);
                g_TB_Circum_READONLY.Add(TB_Time_To_R1st_Planned);
                g_TB_Circum_READONLY.Add(TB_Travel_Shift_Vent_Time);
                g_TB_Circum_READONLY.Add(TB_Ascent_Time_Water);
                g_TB_Circum_READONLY.Add(TB_Undress_Time);
                g_TB_Circum_READONLY.Add(TB_Desc_Chamber_SurD);
                g_TB_Circum_READONLY.Add(TB_Total_SurD_Interval);
                g_TB_Circum_READONLY.Add(TB_Ascent_Time_Chamber);

                g_TB_Circum_WRITE.Add(TB_StageDepth);
                g_TB_Circum_WRITE.Add(TB_TBT);
                g_TB_Circum_WRITE.Add(TB_Time_To_R1st_Delayed);

                foreach (var tb in g_TB_Circum_READONLY)
                {
                    g_TB_Times.Add(tb);
                }
                foreach (var tb in g_TB_Circum_WRITE)
                {
                    g_TB_Times.Add(tb);
                }
            }

            //Totals field
            {
                g_TB_Totals.Add(TB_TTD);
                g_TB_Totals.Add(TB_TDT);
            }

            //memo field
            {
                g_TB_Delays_Asc.Add(TB_DELAY_Asc_Depth1);
                g_TB_Delays_Asc.Add(TB_DELAY_Asc_Depth2);
                g_TB_Delays_Asc.Add(TB_DELAY_Asc_Depth3);
                g_TB_Delays_Asc.Add(TB_DELAY_Asc_Reason1);
                g_TB_Delays_Asc.Add(TB_DELAY_Asc_Reason2);
                g_TB_Delays_Asc.Add(TB_DELAY_Asc_Reason3);

                g_TB_Delays_Desc.Add(TB_DELAY_Desc_Depth1);
                g_TB_Delays_Desc.Add(TB_DELAY_Desc_Depth2);
                g_TB_Delays_Desc.Add(TB_DELAY_Desc_Depth3);
                g_TB_Delays_Desc.Add(TB_DELAY_Desc_Reason1);
                g_TB_Delays_Desc.Add(TB_DELAY_Desc_Reason2);
                g_TB_Delays_Desc.Add(TB_DELAY_Desc_Reason3);
            }

            //sum up everything
            {
                g_TB_All_Fields.Add(g_TB_FSW_Results);
                g_TB_All_Fields.Add(g_TB_Times);
                g_TB_All_Fields.Add(g_TB_Circum);
                g_TB_All_Fields.Add(g_TB_Totals);
                g_TB_All_Fields.Add(g_TB_Delays_Asc);
                g_TB_All_Fields.Add(g_TB_Delays_Desc);
            }
        }

        public void initAllFieldValues() {
            foreach(var list in g_TB_All_Fields)
            {
                foreach(var tb in list)
                {
                    tb.Text = "";
                }
            }
            this.LcurTime.Text = DateTime.Now.ToString();
        }

        //memory allocation
        public void initVars()
        {
            this.hTimes = new HSYSTimes();
            g_depthList = new List<int>();
            g_BTLUT = new Dictionary<int, List<int>>();
            g_DCompTable = new DCompTable();

            g_TB_All_Fields = new List<List<TextBox>>();
            g_TB_FSW_Results = new List<TextBox>();
            g_TB_Times = new List<TextBox>();
            g_TB_Circum = new List<TextBox>();
            g_TB_Totals = new List<TextBox>();
            g_TB_Delays_Asc = new List<TextBox>();
            g_TB_Delays_Desc = new List<TextBox>();

            g_TB_Times_READONLY = new List<TextBox>();
            g_TB_Times_WRITE = new List<TextBox>();
            g_TB_Circum_READONLY = new List<TextBox>();
            g_TB_Circum_WRITE = new List<TextBox>();

            g_FSW2Interval = new SortedDictionary<int, TextBox>();
            g_FSW2Time = new SortedDictionary<int, TextBox>();
            {
                g_FSW2Interval[20] = this.TB_R20_Interval;
                g_FSW2Interval[30] = this.TB_R30_Interval;
                g_FSW2Interval[40] = this.TB_R40_Interval;
                g_FSW2Interval[50] = this.TB_R50_Interval;
                g_FSW2Interval[60] = this.TB_R60_Interval;
                g_FSW2Interval[70] = this.TB_R70_Interval;
                g_FSW2Interval[80] = this.TB_R80_Interval;
                g_FSW2Interval[90] = this.TB_R90_Interval;
                g_FSW2Interval[100] = this.TB_R100_Interval;
                g_FSW2Interval[110] = this.TB_R110_Interval;
                g_FSW2Interval[120] = this.TB_R120_Interval;
                g_FSW2Interval[130] = this.TB_R130_Interval;
                g_FSW2Interval[140] = this.TB_R140_Interval;
                g_FSW2Interval[150] = this.TB_R150_Interval;
                g_FSW2Interval[160] = this.TB_R160_Interval;
                g_FSW2Interval[170] = this.TB_R170_Interval;
                g_FSW2Interval[180] = this.TB_R180_Interval;
                g_FSW2Interval[190] = this.TB_R190_Interval;

                g_FSW2Time[20] = this.TB_R20_CLOCKTIME;
                g_FSW2Time[30] = this.TB_R30_CLOCKTIME;
                g_FSW2Time[40] = this.TB_R40_CLOCKTIME;
                g_FSW2Time[50] = this.TB_R50_CLOCKTIME;
                g_FSW2Time[60] = this.TB_R60_CLOCKTIME;
                g_FSW2Time[70] = this.TB_R70_CLOCKTIME;
                g_FSW2Time[80] = this.TB_R80_CLOCKTIME;
                g_FSW2Time[90] = this.TB_R90_CLOCKTIME;
                g_FSW2Time[100] = this.TB_R100_CLOCKTIME;
                g_FSW2Time[110] = this.TB_R110_CLOCKTIME;
                g_FSW2Time[120] = this.TB_R120_CLOCKTIME;
                g_FSW2Time[130] = this.TB_R130_CLOCKTIME;
                g_FSW2Time[140] = this.TB_R140_CLOCKTIME;
                g_FSW2Time[150] = this.TB_R150_CLOCKTIME;
                g_FSW2Time[160] = this.TB_R160_CLOCKTIME;
                g_FSW2Time[170] = this.TB_R170_CLOCKTIME;
                g_FSW2Time[180] = this.TB_R180_CLOCKTIME;
                g_FSW2Time[190] = this.TB_R190_CLOCKTIME;
            }
        }

        public void initTableData()
        {
            //TODO : load from file?
            string dataFile = @"Decompression Table.txt";
            if (File.Exists(dataFile))
            {
                string[] lines = System.IO.File.ReadAllLines(dataFile);

                char[] delimiterChars = { ' ', ',', ':', '\t' };

                foreach (string line in lines)
                {
                    //skip empty lines
                    if (line.Length <= 0)
                        continue;

                    //skip comments
                    if (line[0].ToString() == "#")
                        continue;

                    Console.WriteLine(line);

                    string[] words = line.Split(delimiterChars);

                    int paramStartIdx = 6;
                    int paramSize = words.Length - paramStartIdx;
                    if(paramSize <= 0)
                    {
                        Console.Write("wrong input. input words are : ");
                        foreach ( var word in words) { Console.Write(word + " "); }
                        continue;
                    }

                    int depth = Convert.ToInt32(words[0]);
                    int BT = Convert.ToInt32(words[1]);
                    int to1st = Convert.ToInt32(words[2]);

                    GasMix mix;
                    words[3] = words[3].ToUpper();
                    if (words[3] == "AIR" || words[3] == "A")
                    { mix = GasMix.AIR; }
                    else if (words[3] == "AIRO2" || words[3] == "O2" || words[3] == "AIR/O2" || words[3] == "O")
                    { mix = GasMix.AIRO2; }
                    else
                    { mix = GasMix.NONE;  }
                    //int totalAsc = Convert.ToInt32(words[4]);
                    double chamberPeriod = Convert.ToDouble(words[4]);
                    char repeatGroup = Convert.ToChar(words[5]);

                    int[] paramList = new int[paramSize];
                    for ( int idx = paramStartIdx; idx < words.Length; idx++)
                    {
                        paramList[idx - paramStartIdx] = Convert.ToInt32(words[idx]);
                    }
                    g_DCompTable.add(depth, new DCompRow(BT, to1st, mix, chamberPeriod, repeatGroup, paramList), mix);
                }

                Console.Write("Succesfully loaded from file");
                L_Data_Loaded.Text = "데이터 불러오기 성공!";
                L_Data_Loaded.BackColor = Color.Green;
            }

            else
            //make table
            {
                L_Data_Loaded.Text = "데이터 파일이 없습니다. 실행파일과 같은 경로에 Decompression Table.Txt파일이 필요합니다.";
                L_Data_Loaded.BackColor = Color.Red;
                L_Data_Loaded.ForeColor = Color.White;
            }
            

            updateGlobalLUT();
        }


        public void updateGlobalLUT()
        {
            //Matrix.m_bottomTimesLUT
            foreach (var elem in g_DCompTable.m_AirTable)
            {
                g_depthList.Add(elem.Key);
                g_BTLUT[elem.Key] = elem.Value.m_bottomTimesLUT;
            }

        }
        
        #region GlobalVariables
        static int g_stageDepth = -1;
        static int g_MaxDepth = -1;
        static int g_BottomTime = -1;
        static SortedDictionary<int, TextBox> g_FSW2Interval;
        static SortedDictionary<int, TextBox> g_FSW2Time;

        static List<List<TextBox>> g_TB_All_Fields;
        static List<TextBox> g_TB_FSW_Results;
        static List<TextBox> g_TB_Times;
        static List<TextBox> g_TB_Circum;
        static List<TextBox> g_TB_Totals;
        static List<TextBox> g_TB_Delays_Desc;
        static List<TextBox> g_TB_Delays_Asc;

        static List<TextBox> g_TB_Times_READONLY;
        static List<TextBox> g_TB_Times_WRITE;
        static List<TextBox> g_TB_Circum_READONLY;
        static List<TextBox> g_TB_Circum_WRITE;
        
        static DCompRow g_curDCompRow;
        static GasMix g_GasMix = GasMix.NONE;

        HSYSTimes hTimes;
        static List<int> g_depthList;
        static Dictionary<int, List<int>> g_BTLUT;
        static DCompTable g_DCompTable;
        #endregion
        #endregion

        #region Classes
        
        public class HSYSTimes
        {
            public HSYS g_LS;
            public HSYS g_RB;
            public HSYS g_LB;
            public HSYS g_RS;
            public HSYS g_TDT;
            public HSYS g_TTD;
            public HSYS g_R1st_Stop;
            public HSYS g_EstRB;
            public HSYS g_TBT;
            public SortedDictionary<int, HSYS> g_DCompStop_Leave;
            public SortedDictionary<int, HSYS> g_DCompStop_Reach;

            public HSYSTimes()
            {
                g_LS = new HSYS();
                g_RB = new HSYS();
                g_LB = new HSYS();
                g_RS = new HSYS();
                g_TDT = new HSYS();
                g_TTD = new HSYS();
                g_EstRB = new HSYS();
                g_TBT = new HSYS();
                g_R1st_Stop = new HSYS();
                g_DCompStop_Leave = new SortedDictionary<int, HSYS>();
                g_DCompStop_Reach = new SortedDictionary<int, HSYS>();
            }
        }
        public class HSYS
        {

            public int hour = -1;
            public int minute = -1;
            public HSYS() { }

            public int TotalMinutes()
            {
                if (isInitialized())
                {
                    return hour * 60 + minute;
                }
                return 0;
            }

            public void addMMSS(int MMSS)
            {
                if (MMSS <= 0)
                {
                    return;
                }

                int min = MMSS / 100;
                int seconds = MMSS % 100 + min*60;

                this.addSeconds(seconds);
                
            }

            

            public void addSeconds(int seconds)
            {
                if (seconds <= 0)
                    return;
                int min = (seconds-1) / 60;
                min++;
                this.addMin(min);
            }

            public bool isInitialized()
            {
                return hour != -1 && minute != -1;
            }

            public HSYS(int _4digit)
            {
                hour = _4digit / 100;
                minute = _4digit % 100;
            }

            public void setByMinutes(string minutes)
            {
                int min = Convert.ToInt32(minutes);
                int hour = min / 60;
                min = min % 60;
                this.minute = min;
                this.hour = hour;
            }

            public void set4digit(string _4digit)
            {
                if(_4digit.Length != 4)
                {
                    return;
                }
                int digit = Convert.ToInt32(_4digit);
                hour = digit / 100;
                minute = digit % 100;
            }

            public HSYS(string _4digit)
            {
                this.set4digit(_4digit);
            }
            public HSYS(int hour, int minute)
            {
                this.hour = hour;
                this.minute = minute;
                UpdateMinHr();
            }

            private void UpdateMinHr()
            {
                while (this.minute >= 60)
                {
                    this.hour++;
                    minute -= 60;
                }

                while ( this.minute < 0)
                {
                    this.hour--;
                    minute += 60;
                }
            }

            public HSYS addMin(int min)
            {
                this.minute += min;
                UpdateMinHr();
                return this;
            }

            public HSYS subMin(int min)
            {
                this.minute -= min;
                UpdateMinHr();
                return this;
            }

            public static HSYS operator +(HSYS lhs, HSYS rhs)
            {
                int totMin = lhs.minute + rhs.minute;
                int totHour = lhs.hour + rhs.hour;

                HSYS result = new HSYS(totHour, totMin);
                return result;
            }

            public static HSYS operator -(HSYS lhs, HSYS rhs)
            {
                int totMin = lhs.minute - rhs.minute;
                int totHour = lhs.hour - rhs.hour;

                HSYS result = new HSYS(totHour, totMin);
                return result;
            }

            //public override string ToString()
            //{
            //    return ToInt().ToString().PadLeft(4, '0');
            //}

            public string ToString(string filler = "")
            {
                var hr = hour.ToString().PadLeft(2, '0');
                var m = minute.ToString().PadLeft(2, '0');
                return hr + filler + m;
            }

            public int ToInt()
            {
                return ((hour * 100) + minute);
            }

            public string ToHS(string filler = " ")
            {
                return hour.ToString() + "h" + filler + minute.ToString() + "m";
            }
        }

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
                result = "Time to first stop : " + m_TimeToFirstStop.ToString() + "Total Ascent Time : " + m_AscentMinute.ToString() + "m " + (m_AscentSecond <= 0 ?  "" : (m_AscentSecond.ToString() + "s")) + ", Repeat Group : " + m_RepeatGroup.ToString() + ", Chamber O2 Periods : " + m_ChamberO2Periods.ToString() + "\n";
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
                    foreach(var min in data)
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

                foreach (var pair in reversed){
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
                                if(depth == 30 || depth == 20)
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
                                        m_DComp_pauses_data[depth].Add(done);
                                        m_DComp_pauses_data[depth].Add(pauseInterval);
                                        m_TotalPauseTime += pauseInterval;
                                        min -= done;
                                        intervalFromLastPause = 0;
                                    }

                                    //dcomp (min)
                                    m_DComp_pauses_data[depth].Add(min);
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

        #endregion

        #region Utils

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.LcurTime.Text = DateTime.Now.ToString();
        }

        string limitTextNchars(string text, int limit = 4)
        {
            if (text.Length >= limit)
            {
                return text.Substring(0, limit);
            }
            return text;
        }

        //true == succeeded, false == failed
        bool numericConversion(string str)
        {
            if (containsChar(str))
            {
                string isError = "숫자만 입력해주세요";
                MessageBox.Show(isError);
                return false;
            }
            return true;
        }

        bool containsChar(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return true;
            }

            return false;
        }

        enum ConvertTimeType { MMSS2SEC_ONLY, SEC_ONLY2MMSS }
        int convertTimeType(int input, ConvertTimeType cType)
        {
            switch (cType)
            {
                case ConvertTimeType.MMSS2SEC_ONLY:
                    return (input / 100) * 60 + (input % 100);
                case ConvertTimeType.SEC_ONLY2MMSS:
                    return (input / 60) * 100 + (input % 60);
                default:
                    break;
            }
            return -1;
        }

        enum ColonType { MIN2HR, SEC4DIGITS, SEC_ONLY }
        string colonizeTime(HSYS time)
        {
            return colonizeTime(time.TotalMinutes());
        }
        string colonizeTime(int time, ColonType cType = ColonType.MIN2HR)
        {
            string result = "";
            int HR, min, sec;
            string strHR, strMin, strSec;
            bool isHr, isMin;

            switch (cType)
            {
                case ColonType.MIN2HR:
                    HR = time / 60;
                    strHR = (HR == 0) ? ":" : (HR.ToString()+":");
                    strMin = (time % 60).ToString().PadLeft(2, '0'); ;
                    result = strHR + strMin;
                    break;
                case ColonType.SEC4DIGITS:   // 13500 = 135min 0sec
                    min = time / 100;
                    sec = time % 100;
                    if (sec >= 60) { min+= sec/60; sec = sec% 60; }
                    HR = min / 60;
                    isHr = HR != 0;  isMin = min != 0;
                    strHR = !isHr ? (isMin ? ":" : "") : HR.ToString() + ":";
                    strMin = !isMin ? "::" : (min.ToString().PadLeft(2, '0') + "::");
                    strSec = sec.ToString().PadLeft(2, '0');
                    result = strHR + strMin + strSec;
                    break;
                case ColonType.SEC_ONLY:   // 123 = 2min 3sec
                    min = time / 60;
                    sec = time % 60;
                    if (sec >= 60) { min += sec / 60; sec = sec % 60; }
                    HR = min / 60;
                    min = min % 60;
                    isHr = HR != 0;  isMin = min != 0;
                    strHR = !isHr ? (isMin ? ":" : "") : HR.ToString() + ":";
                    strMin = !isMin ? "::" : (min.ToString().PadLeft(2, '0') + "::");
                    strSec = sec.ToString().PadLeft(2, '0');
                    result = strHR + strMin + strSec;
                    break;
                default:
                    return "";
            }
            
            return result;
        }

        public int intListLookup(int dest, List<int> LUlist)
        {
            int result = -1;

            //sort asc
            LUlist.Sort();

            foreach (var elem in LUlist)
            {
                if (dest <= elem)
                {
                    return elem;
                }
            }

            return result;
        }

        #endregion

        #region Crucial_Methods

        int getMaximumDepth(int estDepth)
        {
            var map = new Dictionary<int, int>();
            map.Add(200, 3);
            map.Add(100, 2);
            map.Add(0, 1);

            List<int> limits = new List<int>();
            foreach (var pair in map)
            {
                limits.Add(pair.Key);
            }

            foreach (var lim in limits)
            {
                if (estDepth > lim)
                {
                    return estDepth + map[lim];
                }
            }

            return -1;
        }

        public DCompRow searchDComp(int inDepth, int inMinutes, GasMix inGasType, ref int outTableDepth, ref int outTableBT)
        {
            DCompRow result;
            int depth = inDepth;
            int BT = inMinutes;
            int tableDepth = intListLookup(depth, g_depthList);
            if (tableDepth == -1) { return new DCompRow(); }
            var tableBT = intListLookup(BT, g_BTLUT[tableDepth]);
            if (tableBT == -1) { return new DCompRow(); }

            outTableDepth = tableDepth;
            outTableBT = tableBT;
            result = g_DCompTable.getTable(inGasType)[tableDepth].m_DComps[tableBT];

            return result;
        }

        public bool isResultReady()
        {
            return !((g_MaxDepth == -1) || (g_BottomTime == -1) || (g_GasMix == GasMix.NONE));
        }

        
        #endregion

        #region Update

        private void UpdateInput()
        {
            UpdateEstRB();
            UpdateLB();
            UpdateTBT();

            UpdateResult();
        }

        void UpdateTBT()
        {
            //for site
            if (hTimes.g_LS.isInitialized() && (hTimes.g_TBT.TotalMinutes() > 0))
            {
                //this.TB_TBT.Text = hTimes.g_TBT.ToHS() + "( "+ colonizeTime(hTimes.g_TBT.TotalMinutes()) + ")";
                g_BottomTime = hTimes.g_TBT.TotalMinutes();
            }

            else
            {
                g_BottomTime = -1;
            }

        }


        void UpdateLB()
        {
            if (hTimes.g_LS.isInitialized() && hTimes.g_TBT.isInitialized())
            {
                hTimes.g_LB = hTimes.g_LS + hTimes.g_TBT;

                TB_LB.Text = hTimes.g_LB.ToString();
            }
            else
            {
                TB_LB.Text = "";
            }
        }

        void UpdateEstRB()
        {
            if (hTimes.g_LS.isInitialized() && g_stageDepth != -1)
            {
                int min = (int)Math.Ceiling(g_stageDepth / 75.0);

                HSYS hLS = new HSYS(TB_LS.Text);

                hLS.addMin(min);

                TB_RB.Text = hLS.ToString();
            }
            else
            {
                TB_RB.Text = "";
            }
        }

        void UpdateGasMix()
        {
            if (this.RB_GAS_AIR.Checked)
            { g_GasMix = GasMix.AIR; }
            else if (this.RB_GAS_AIRO2.Checked)
            { g_GasMix = GasMix.AIRO2; }
            else
            { g_GasMix = GasMix.NONE; }

            switch (g_GasMix)
            {
                case GasMix.AIR:
                    TB_Travel_Shift_Vent_Time.Text = colonizeTime(40, ColonType.SEC_ONLY);
                    TB_Ascent_Time_Water.Text = "";
                    break;
                case GasMix.AIRO2:
                    TB_Travel_Shift_Vent_Time.Text = colonizeTime(2);
                    TB_Ascent_Time_Water.Text = colonizeTime(40, ColonType.SEC_ONLY);
                    break;
                case GasMix.NONE:
                default:
                    break;
            }
        }

        //Update result and calls UI
        //UpdateGasMix is called inside
        //if ( depth, BT, gasMix ) { search_DCompRow(); show();  } 
        void UpdateResult()
        {
            UpdateGasMix();
            //if not ready, return
            if (!isResultReady())
            {
                return;
            }

            //show result
            int tableDepth = 0, tableBT = 0;
            g_curDCompRow = searchDComp(g_MaxDepth, g_BottomTime, g_GasMix, ref tableDepth, ref tableBT);
            var row = g_curDCompRow;

            //update GUI
            if (row.isInitialized)
            {
                TB_DCompTable.Text = "[ " + tableDepth.ToString() + " FSW, " + tableBT.ToString() + " 분 ]";

                TB_Time_To_R1st_Planned.Text = colonizeTime(row.m_TimeToFirstStop, ColonType.SEC4DIGITS);
                UpdateTimeTo1stStop();

                TB_Repeat_Group.Text = ((row.m_RepeatGroup.ToString()) == "0") ? "분류 그룹 없음" : row.m_RepeatGroup.ToString();

                foreach (var elem in g_TB_FSW_Results) { elem.Text = "-"; }

                foreach (var stop in row.m_DCompStops)
                {
                    //specialize for No decompression
                    if (stop.Key == 20 && stop.Value == 0)
                    {
                        TB_DCompTable.Text = "[ 무감압 ]";
                        TB_TDT.Text = "-";
                        break;
                    }
                    g_FSW2Interval[stop.Key].Text = colonizeTime(stop.Value);
                }

                //update pause time first
                var reversed = row.m_DCompStops_including_pause_time.OrderByDescending(i => i.Key);
                HSYS lastLeave = hTimes.g_R1st_Stop;
                int R1stMinute = lastLeave.TotalMinutes();
                hTimes.g_DCompStop_Leave = new SortedDictionary<int, HSYS>();
                hTimes.g_DCompStop_Reach = new SortedDictionary<int, HSYS>();
                foreach (var stop in reversed)
                {
                    int depth = stop.Key;
                    int min = stop.Value;
                    //init
                    hTimes.g_DCompStop_Leave.Add(depth, new HSYS());
                    hTimes.g_DCompStop_Reach.Add(depth, new HSYS());

                    HSYS toStop = new HSYS(0, 0);
                    toStop.addMin(min);

                    // add 1 minute if not first stop
                    //if (lastLeave.TotalMinutes() != R1stMinute)
                    //{
                    //    lastLeave.addMin(1);
                    //}

                    hTimes.g_DCompStop_Reach[depth] = lastLeave;
                    
                    hTimes.g_DCompStop_Leave[depth] = lastLeave + toStop;

                    lastLeave = hTimes.g_DCompStop_Reach[depth] + toStop;

                }

                if((hTimes.g_DCompStop_Leave).Count > 0)
                {
                    //gets called by reference...
                    //hTimes.g_RS = hTimes.g_DCompStop_Leave[20];
                    hTimes.g_RS = lastLeave;
                    
                    //up to surface
                    hTimes.g_RS.addMin(1);

                    hTimes.g_TTD = hTimes.g_RS - hTimes.g_LS;
                }

                {
                    TB_RS.Text = hTimes.g_RS.ToString();

                    TB_TTD.Text = colonizeTime(hTimes.g_TTD);
                }
                

                //pauses related UI update

                // interval
                foreach ( var stop in row.m_DComp_pauses_data)
                {
                    int dataLength = stop.Value.Count;

                    //for AIR/O2 Decompression
                    if ( stop.Value.Count != 1 )
                    {
                        var t = g_FSW2Interval[stop.Key].Text;
                        g_FSW2Interval[stop.Key].Text = t + " { ";
                        //decltype(stop.Value) = List<int>
                        foreach (var min in stop.Value)
                        {
                            g_FSW2Interval[stop.Key].Text = g_FSW2Interval[stop.Key].Text + colonizeTime(min) + " ";
                        }
                        g_FSW2Interval[stop.Key].Text = g_FSW2Interval[stop.Key].Text + "}";
                    }
                }
                // Clocktime
                foreach (var stop in row.m_DCompStops_including_pause_time)
                {
                    int depth = stop.Key;
                    string filler = ":";
                    g_FSW2Time[depth].Text = hTimes.g_DCompStop_Reach[depth].ToString(filler) + " ~ " +hTimes.g_DCompStop_Leave[depth].ToString(filler);
                }

                //TDT
                hTimes.g_TDT = hTimes.g_RS - hTimes.g_LB;
                TB_TDT.Text = colonizeTime(hTimes.g_TDT);
                
            }
            else
            {
                string noData = "데이터 없음";
                TB_DCompTable.Text = noData;
                TB_Time_To_R1st_Planned.Text = noData;
                TB_Repeat_Group.Text = noData;
                TB_DCompTable.Text = noData;
                TB_Time_To_R1st_Actual.Text = noData;

            }
        }

        private void UpdateTimeTo1stStop()
        {
            if (g_curDCompRow == null)
            {
                return;
            }
            bool notDelayed = TB_Time_To_R1st_Delayed.Text == "";
            int delayTime;
            if (notDelayed)
            {
                delayTime = 0;
            }
            else
            {
                delayTime = Convert.ToInt32(TB_Time_To_R1st_Delayed.Text);
            }
            int actualAscTime = convertTimeType(g_curDCompRow.m_TimeToFirstStop, ConvertTimeType.MMSS2SEC_ONLY) + delayTime;

            hTimes.g_R1st_Stop = new HSYS(hTimes.g_LB.hour, hTimes.g_LB.minute);
            hTimes.g_R1st_Stop.addSeconds(actualAscTime);
            TB_R1st.Text = hTimes.g_R1st_Stop.ToString();

            TB_Time_To_R1st_Actual.Text = colonizeTime(actualAscTime, ColonType.SEC_ONLY);
        }

        #endregion

        #region Callbacks

        // LS, Stage depth, TBT, Delay to 1st stop
        #region Value_Input_Field
        private void TB_LS_TextChanged(object sender, EventArgs e)
        {
            TB_LS.Text = limitTextNchars(TB_LS.Text, 4);

            if (!numericConversion(TB_LS.Text) )
            {
                TB_LS.Text = "";
            }
            if (TB_LS.Text.Length < 4)
            {
                return;
            }

            hTimes.g_LS.set4digit(TB_LS.Text);

            UpdateInput();
        }

        private void TB_Stage_Depth_TextChanged(object sender, EventArgs e)
        {

            TB_StageDepth.Text = limitTextNchars(TB_StageDepth.Text, 4);

            var t = TB_StageDepth.Text;
            if (t == "" || !numericConversion(t))
            {
                this.TB_MaxDepth.Text = "";
                g_MaxDepth = -1;
                g_stageDepth = -1;
                return;
            }
            int depth = Convert.ToInt32(t);
            g_stageDepth = depth;
            g_MaxDepth = getMaximumDepth(depth);

            this.TB_MaxDepth.Text = getMaximumDepth(depth).ToString();

            int DescTimeMin = (g_stageDepth - 1) / 75 + 1;

            this.TB_Desc_Time.Text = colonizeTime(DescTimeMin);

            UpdateInput();
        }

        private void TB_TBT_TextChanged(object sender, EventArgs e)
        {
            TB_TBT.Text = limitTextNchars(TB_TBT.Text, 4);

            var t = TB_TBT.Text;
            if (t == "" || !numericConversion(t))
            {
                TB_TBT.Text = "";
                return;
            }

            hTimes.g_TBT.setByMinutes(((TextBox)sender).Text);
            UpdateInput();
        }

        private void TB_Time_To_R1st_Delayed_TextChanged(object sender, EventArgs e)
        {
            TB_Time_To_R1st_Delayed.Text = limitTextNchars(TB_Time_To_R1st_Delayed.Text, 5);

            var t = TB_Time_To_R1st_Delayed.Text;
            if (!numericConversion(t))
            {
                TB_Time_To_R1st_Delayed.Text = "";
                return;
            }

            UpdateInput();
        }
        #endregion

        // Values input field
        




        private void RB_GAS_AIR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInput();
        }

        private void RB_GAS_AIRO2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInput();
        }

        
        //clear field
        private void BT_Initialize_MouseDown(object sender, MouseEventArgs e)
        {
            hTimes = new HSYSTimes();
            initAllFieldValues();
        }

        
        private void BT_Reload_Data_File_MouseDown(object sender, MouseEventArgs e)
        {
            initTableData();
        }

        #endregion

    }
}
