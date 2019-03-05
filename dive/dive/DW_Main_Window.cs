using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace dive
{
    
    public partial class DW_Main_Window : Form
    {
        #region Init
        public DW_Main_Window()
        {
            InitializeComponent();
            initVars();
            initTBDesignators();
            initMemberProperties();
            initTableData();
            initAllFieldValues();
        }

        private void DW_Main_Window_Load(object sender, EventArgs e)
        {
            this.LcurTime.Text = getTime();
        }

        private void initMemberProperties()
        {
            foreach(var lists in g_TB_All_Fields)
            {
                foreach(var tb in lists)
                {
                    //tb.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    
                }
            }
            
        }

        private string getTime()
        {
            return DateTime.Now.ToString();
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
                g_TB_Totals.Add(CORNER_LB);
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
            
            //clear inputfield first
            foreach(var tb in g_TB_WRITE_field)
            {
                tb.Text = "";
            }

            foreach(var list in g_TB_All_Fields)
            {
                foreach(var tb in list)
                {
                    tb.Text = "";
                }
            }
            this.LcurTime.Text = getTime();
        }

        //memory allocation
        public void initVars()
        {
            this.hTimes = new HSYSTimes();
            g_depthList = new List<int>();
            g_BTLUT = new Dictionary<int, List<int>>();
            g_DCompTable = new DCompTable();

            g_TB_All_Fields = new List<List<TextBox>>();
            g_TB_WRITE_field = new List<TextBox>();
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
            string dataFile = @"Decompression Table.txt";
            string[] lines = new string []{ };
            if (g_LoadFromFile)
            {
                if (File.Exists(dataFile))
                {
                    lines = System.IO.File.ReadAllLines(dataFile);
                    var loading = "데이터 파일을 불러옵니다... ";
                    setNotification(loading, Color.LightGreen, Color.Black);
                }
                else
                {
                    g_LoadFromFile = false;
                }
                
            }

            if (g_LoadFromFile == false)
            //make nested table
            {
                var noData = "내장된 데이터 파일을 이용합니다... ";
                setNotification(noData, Color.Red, Color.White);

                lines = makeNestedDataTable();
            }

            //load data from string[] lines
            {
                char[] delimiterChars = { ' ', ',', ':', '\t' };

                int lineNumber = 0;
                foreach (string line in lines)
                {
                    lineNumber++;

                    //skip empty lines
                    if (line.Length <= 0)
                        continue;

                    //skip comments
                    if (line[0].ToString() == "#" || line[0] == '\n')
                        continue;

                    Console.WriteLine(line);

                    string[] words = line.Split(delimiterChars);

                    int paramStartIdx = 6;
                    int paramSize = words.Length - paramStartIdx;

                    ////data validity check
                    bool paramsContainChar = false;
                    for (int idx = paramStartIdx; idx < words.Length; idx++)
                    {
                        if (containsChar(words[idx]))
                        {
                            paramsContainChar = true;
                            break;
                        }
                    }
                    if (paramSize <= 0
                        ||
                        containsChar(words[0]) ||
                        containsChar(words[1]) ||
                        containsChar(words[2]) ||
                        words[5].Length != 1 ||
                        paramsContainChar
                        )
                    {
                        Console.WriteLine("Wrong input at line number : " + lineNumber.ToString());
                        Console.WriteLine("wrong input. input words are : ");
                        string wrongWords = "";
                        foreach (var word in words) { wrongWords += word+", "; }
                        Console.WriteLine(wrongWords);
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
                    { mix = GasMix.NONE; }
                    //int totalAsc = Convert.ToInt32(words[4]);
                    double chamberPeriod = Convert.ToDouble(words[4]);
                    char repeatGroup = Convert.ToChar(words[5]);

                    int[] paramList = new int[paramSize];
                    for (int idx = paramStartIdx; idx < words.Length; idx++)
                    {
                        paramList[idx - paramStartIdx] = Convert.ToInt32(words[idx]);
                    }
                    g_DCompTable.add(depth, new DCompRow(BT, to1st, mix, chamberPeriod, repeatGroup, paramList), mix);

                    
                }

                var dataLoadResult = L_Data_Loaded.Text + "성공!";
                setNotification(dataLoadResult, Color.LightGreen, Color.Black);
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
        // if ( true )  try{ Read_from_file(); }
        // if ( false || (true && file==null) ) { Load_nested_data(); }
        static bool g_LoadFromFile = false;
        
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

        static List<TextBox> g_TB_WRITE_field;

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
        private void setNotification(string text, Color bg, Color textColor)
        {
            L_Data_Loaded.Text = text;
            L_Data_Loaded.BackColor = bg;
            L_Data_Loaded.ForeColor = textColor;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.LcurTime.Text = getTime();
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

                CORNER_RB.Text = ((row.m_RepeatGroup.ToString()) == "0") ? "분류 그룹 없음" : row.m_RepeatGroup.ToString();

                foreach (var elem in g_TB_FSW_Results) { elem.Text = "-"; }

                foreach (var stop in row.m_DCompStops)
                {
                    //specialize for No decompression
                    if (stop.Key == 20 && stop.Value == 0)
                    {
                        TB_DCompTable.Text = "[ 무감압 ]";
                        CORNER_LB.Text = "-";
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
                CORNER_LB.Text = colonizeTime(hTimes.g_TDT);
                
            }
            else
            {
                string noData = "데이터 없음";
                TB_DCompTable.Text = noData;
                TB_Time_To_R1st_Planned.Text = noData;
                CORNER_RB.Text = noData;
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
                this.TB_StageDepth.Text = "";
                this.TB_MaxDepth.Text = "";
                g_MaxDepth = -1;
                g_stageDepth = -1;
                return;
            }
            int depth = Convert.ToInt32(t);
            g_stageDepth = depth;
            g_MaxDepth = getMaximumDepth(depth);

            this.TB_MaxDepth.Text = getMaximumDepth(depth).ToString();

            int DescTimeMin = g_stageDepth == 0 ? 0 : (g_stageDepth - 1) / 75 + 1;

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
            g_LoadFromFile = true;
            initTableData();
        }

        private void BT_Save_Capture_MouseDown(object sender, MouseEventArgs e)
        {
            //get window and save image
            Rectangle bounds = this.Bounds;
            int padTop = 31;
            int padLeft = 8;
            int padBottom = 1;
            int padRight = 1;
            int left = bounds.Left + padLeft;
            int top = bounds.Top + padTop;
            Point LT = new Point(left + this.CORNER_LT.Location.X, top + this.CORNER_LT.Location.Y);
            Point RB = new Point(left + this.CORNER_RB.Location.X + this.CORNER_RB.Size.Width, top + this.CORNER_RB.Location.Y + this.CORNER_RB.Size.Height);

            //string defaultImgName = "감압테이블 " + DateTime.Now.ToString()+".png";
            string defaultImgName = "감압테이블 " +
                DateTime.Now.ToString("yyyy년MM월dd일HH시mm분");

            Size captureSize = new Size(RB.X - LT.X + padRight, RB.Y - LT.Y + padBottom);

            using (Bitmap bitmap = new Bitmap(captureSize.Width, captureSize.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(LT, Point.Empty, captureSize);
                }

                //get save path
                SaveFileDialog imgSaveDialog = new SaveFileDialog();
                imgSaveDialog.FileName = defaultImgName;
                imgSaveDialog.Filter = "Jpeg Image|*.jpg|PNG Image|*.png";
                imgSaveDialog.Title = "Save an Image File";
                imgSaveDialog.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (imgSaveDialog.FileName != "")
                {
                    var encoder = ImageCodecInfo.GetImageEncoders()
                            .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                    var encParams = new EncoderParameters(1);
                    encParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                    //image.Save(path, encoder, encParams);

                    System.IO.FileStream fs = (System.IO.FileStream)imgSaveDialog.OpenFile();
                    switch (imgSaveDialog.FilterIndex)
                    {
                        case 1:
                            bitmap.Save(fs, encoder, encParams);
                            //bitmap.Save(fs,
                            //   System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            bitmap.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }

                    fs.Close();

                    var imageSave = "테이블을 사진으로 저장했습니다";
                    setNotification(imageSave, Color.LightGreen, Color.Black);
                }

            }


        }


        #endregion


        #region Make_Nested_Data_Table

        string[] makeNestedDataTable()
        {
            string data;
            {
                data =
@"################AUTHOR INFO################
#Made by Wonjun Hwang
#E-mail : iamjam4944@gmail.com
#Find full source code @ https://github.com/Maetel/DiversWorld
#License : This work is licensed under a Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License.

################USAGE################
#File format :
#[Depth] [Bottom Time] [Time to First stop (MMSS)] [Gas mix] [Chamber O2 Periods] [Repeat group] [Decompression stops {20}, {30}, {40}, ... ]
#Delimitters can be either one of {' '} {','} {', '}
#For Gas mix, ""O2"" == ""AIRO2"" == ""AIR / O2"". Works either for upper/lower cases or mixed.

#Data of 30FSW

30 371 100 A 0 Z 0
30 371 100 O 0 Z 0
30 380 020 A 0.5 Z 5
30 380 020 O 0.5 Z 1
30 420 020 A 0.5 Z 22
30 420 020 O 0.5 Z 5
30 480 020 A 0.5 0 42
30 480 020 O 0.5 0 9
30 540 020 A 1 0 71
30 540 020 O 1 0 14
30 600 020 A 1 0 92
30 600 020 O 1 0 19
30 660 020 A 1 0 120
30 660 020 O 1 0 22
30 720 020 A 1 0 158
30 720 020 O 1 0 27

#Data of 35FSW

35 232 110 A 0 Z 0
35 232 110 O 0 Z 0
35 240 030 A 0.5 Z 4
35 240 030 O 0.5 Z 2
35 270 030 A 0.5 Z 28
35 270 030 O 0.5 Z 7
35 300 030 A 0.5 Z 53
35 300 030 O 0.5 Z 13
35 330 030 A 1 Z 71
35 330 030 O 1 Z 18
35 360 030 A 1 0 88
35 360 030 O 1 0 22
35 420 030 A 1.5 0 134
35 420 030 O 1.5 0 29
35 480 030 A 1.5 0 173
35 480 030 O 1.5 0 38
35 540 030 A 2 0 228
35 540 030 O 2 0 45
35 600 030 A 2 0 277
35 600 030 O 2 0 53
35 660 030 A 2.5 0 314
35 660 030 O 2.5 0 63
35 720 030 A 3 0 342
35 720 030 O 3 0 71

#Data of 40FSW

40 163 120 A 0 O 0
40 163 120 O 0 O 0
40 170 040 A 0.5 O 6
40 170 040 O 0.5 O 2
40 180 040 A 0.5 Z 14
40 180 040 O 0.5 Z 5
40 190 040 A 0.5 Z 21
40 190 040 O 0.5 Z 7
40 200 040 A 0.5 Z 27
40 200 040 O 0.5 Z 9
40 210 040 A 0.5 Z 39
40 210 040 O 0.5 Z 11
40 220 040 A 0.5 Z 52
40 220 040 O 0.5 Z 12
40 230 040 A 1 Z 64
40 230 040 O 1 Z 16
40 240 040 A 1 Z 75
40 240 040 O 1 Z 19
40 270 040 A 1 Z 101
40 270 040 O 1 Z 26
40 300 040 A 1.5 0 128
40 300 040 O 1.5 0 33
40 330 040 A 1.5 0 160
40 330 040 O 1.5 0 38
40 360 040 A 2 0 184
40 360 040 O 2 0 44
40 420 040 A 2.5 0 248
40 420 040 O 2.5 0 56
40 480 040 A 2.5 0 321
40 480 040 O 2.5 0 68
40 540 040 A 3 0 372
40 540 040 O 3 0 80
40 600 040 A 3.5 0 410
40 600 040 O 3.5 0 93
40 660 040 A 4 0 439
40 660 040 O 4 0 103
40 720 040 A 4.5 0 461
40 720 040 O 4.5 0 112

#Data of 45FSW

45 125 130 A 0 N 0
45 125 130 O 0 N 0
45 130 050 A 0.5 O 2
45 130 050 O 0.5 O 1
45 140 050 A 0.5 O 14
45 140 050 O 0.5 O 5
45 150 050 A 0.5 Z 25
45 150 050 O 0.5 Z 8
45 160 050 A 0.5 Z 34
45 160 050 O 0.5 Z 11
45 170 050 A 1 Z 41
45 170 050 O 1 Z 14
45 180 050 A 1 Z 59
45 180 050 O 1 Z 17
45 190 050 A 1 Z 75
45 190 050 O 1 Z 19
45 200 050 A 1 Z 89
45 200 050 O 1 Z 23
45 210 050 A 1 Z 101
45 210 050 O 1 Z 27
45 220 050 A 1.5 Z 112
45 220 050 O 1.5 Z 30
45 230 050 A 1.5 Z 121
45 230 050 O 1.5 Z 33
45 240 050 A 1.5 Z 130
45 240 050 O 1.5 Z 37
45 270 050 A 2 0 173
45 270 050 O 2 0 45
45 300 050 A 2 0 206
45 300 050 O 2 0 51
45 330 050 A 2.5 0 243
45 330 050 O 2.5 0 61
45 360 050 A 3 0 288
45 360 050 O 3 0 69
45 420 050 A 3.5 0 373
45 420 050 O 3.5 0 84
45 480 050 A 4 0 431
45 480 050 O 4 0 101
45 540 050 A 4.5 0 473
45 540 050 O 4.5 0 117

#Data of 50FSW

50 92 140 A 0 M 0
50 92 140 O 0 M 0
50 95 100 A 0.5 M 2
50 95 100 O 0.5 M 1
50 100 100 A 0.5 N 4
50 100 100 O 0.5 N 2
50 110 100 A 0.5 O 8
50 110 100 O 0.5 O 4
50 120 100 A 0.5 O 21
50 120 100 O 0.5 O 7
50 130 100 A 0.5 Z 34
50 130 100 O 0.5 Z 12
50 140 100 A 1 Z 45
50 140 100 O 1 Z 16
50 150 100 A 1 Z 56
50 150 100 O 1 Z 19
50 160 100 A 1 Z 78
50 160 100 O 1 Z 23
50 170 100 A 1 Z 96
50 170 100 O 1 Z 26
50 180 100 A 1.5 Z 111
50 180 100 O 1.5 Z 30
50 190 100 A 1.5 Z 125
50 190 100 O 1.5 Z 35
50 200 100 A 1.5 Z 136
50 200 100 O 1.5 Z 39
50 210 100 A 2 0 147
50 210 100 O 2 0 43
50 220 100 A 2 0 166
50 220 100 O 2 0 47
50 230 100 A 2 0 183
50 230 100 O 2 0 50
50 240 100 A 2 0 198
50 240 100 O 2 0 53
50 270 100 A 2.5 0 236
50 270 100 O 2.5 0 62
50 300 100 A 3 0 285
50 300 100 O 3 0 74
50 330 100 A 3.5 0 345
50 330 100 O 3.5 0 83
50 360 100 A 3.5 0 393
50 360 100 O 3.5 0 92
50 420 100 A 4.5 0 464
50 420 100 O 4.5 0 113

#Data of 55FSW

55 74 150 A 0 L 0
55 75 110 A 0.5 L 1
55 80 110 A 0.5 M 4
55 90 110 A 0.5 N 10
55 100 110 A 0.5 O 17
55 110 110 A 0.5 O 34
55 120 110 A 1 Z 48
55 130 110 A 1 Z 59
55 140 110 A 1 Z 84
55 150 110 A 1.5 Z 105
55 160 110 A 1.5 Z 123
55 170 110 A 1.5 Z 138
55 180 110 A 2 Z 151
55 190 110 A 2 0 169
55 200 110 A 2 0 190
55 210 110 A 2.5 0 208
55 220 110 A 2.5 0 224
55 230 110 A 2.5 0 239
55 240 110 A 3 0 254
55 270 110 A 3.5 0 313
55 300 110 A 3.5 0 380
55 330 110 A 4 0 432
55 360 110 A 4.5 0 474
55 74 150 O 0 L 0
55 75 110 O 0.5 L 1
55 80 110 O 0.5 M 2
55 90 110 O 0.5 N 5
55 100 110 O 0.5 O 8
55 110 110 O 0.5 O 12
55 120 110 O 1 Z 17
55 130 110 O 1 Z 22
55 140 110 O 1 Z 26
55 150 110 O 1.5 Z 30
55 160 110 O 1.5 Z 34
55 170 110 O 1.5 Z 40
55 180 110 O 2 Z 45
55 190 110 O 2 0 50
55 200 110 O 2 0 54
55 210 110 O 2.5 0 58
55 220 110 O 2.5 0 62
55 230 110 O 2.5 0 66
55 240 110 O 3 0 69
55 270 110 O 3.5 0 83
55 300 110 O 3.5 0 94
55 330 110 O 4 0 106
55 360 110 O 4.5 0 118

#Data of 60FSW

60 63 200 A 0 K 0
60 63 200 O 0 K 0
60 65 120 AIR 0.5 L 2
60 65 120 O2 0.5 L 1
60 70 120 AIR 0.5 L 7
60 70 120 O2 0.5 L 4
60 80 120 AIR 0.5 N 14
60 80 120 O2 0.5 N 7
60 90 120 AIR 0.5 O 23
60 90 120 O2 0.5 O 10
60 100 120 AIR 1 Z 42
60 100 120 O2 1 Z 15
60 110 120 AIR 1 Z 57
60 110 120 O2 1 Z 21
60 120 120 AIR 1 Z 75
60 120 120 O2 1 Z 26
60 130 120 A 1.5 Z 102
60 140 120 A 1.5 Z 124
60 150 120 A 2 Z 143
60 160 120 A 2 Z 158
60 170 120 A 2 0 178
60 180 120 A 2.5 0 201
60 190 120 A 2.5 0 222
60 200 120 A 2.5 0 240
60 210 120 A 3 0 256
60 220 120 A 3 0 278
60 230 120 A 3.5 0 300
60 240 120 A 3.5 0 321
60 270 120 A 4 0 398
60 300 120 A 4.5 0 456
60 130 120 O 1.5 Z 31
60 140 120 O 1.5 Z 35
60 150 120 O 2 Z 41
60 160 120 O 2 Z 48
60 170 120 O 2 0 53
60 180 120 O 2.5 0 59
60 190 120 O 2.5 0 64
60 200 120 O 2.5 0 68
60 210 120 O 3 0 73
60 220 120 O 3 0 77
60 230 120 O 3.5 0 82
60 240 120 O 3.5 0 88
60 270 120 O 4 0 102
60 300 120 O 4.5 0 115

#Data of 70FSW

70 48 220 A 0 K 0
70 48 220 O 0 K 0
70 50 140 AIR 0.5 K 2
70 50 140 O2 0.5 K 1
70 55 140 AIR 0.5 L 9
70 55 140 O2 0.5 L 5
70 60 140 AIR 0.5 M 14
70 60 140 O2 0.5 M 8
70 70 140 AIR 0.5 N 24
70 70 140 O2 0.5 N 13
70 80 140 AIR 1 O 44
70 80 140 O2 1 O 17
70 90 140 AIR 1 Z 64
70 90 140 O2 1 Z 24
70 100 140 AIR 1.5 Z 88
70 100 140 O2 1.5 Z 31
70 110 140 AIR 1.5 Z 120
70 110 140 O2 1.5 Z 38
70 120 140 AIR 2 Z 145
70 120 140 O2 2 Z 44
70 130 140 A 2 Z 167
70 140 140 A 2.5 0 189
70 150 140 A 2.5 0 219
70 160 120 A 3 0 244 1
70 170 120 A 3 0 265 2
70 180 120 A 3.5 0 289 4
70 190 120 A 3.5 0 316 5
70 200 120 A 4 0 345 9
70 210 120 A 4 0 378 13
70 240 120 A 4.5 0 454 25
70 130 140 O 2 Z 51
70 140 140 O 2.5 0 59
70 150 140 O 2.5 0 66
70 160 120 O 3 0 72 1
70 170 120 O 3 0 78 1
70 180 120 O 3.5 0 83 2
70 190 120 O 3.5 0 88 3
70 200 120 O 4 0 93 5
70 210 120 O 4 0 98 7
70 240 120 O 4.5 0 110 13

#Data of 80FSW

80 39 240 A 0 J 0
80 39 240 O 0 J 0
80 40 200 A 0.5 J 1
80 40 200 O 0.5 J 1
80 45 200 A 0.5 K 10
80 45 200 O 0.5 K 5
80 50 200 A 0.5 M 17
80 50 200 O 0.5 M 9
80 55 200 A 0.5 M 24
80 55 200 O 0.5 M 13
80 60 200 A 1 N 30
80 60 200 O 1 N 16
80 70 200 A 1 O 54
80 70 200 O 1 O 22
80 80 200 A 1.5 Z 77
80 80 200 O 1.5 Z 30
80 90 200 A 1.5 Z 114
80 90 200 O 1.5 Z 39
80 100 140 A 2 Z 147
80 100 140 O 2 Z 46
80 110 140 A 2 Z 171
80 110 140 O 2 Z 51
80 120 140 A 2.5 0 200
80 120 140 O 2.5 0 59
80 130 140 A 3 0 232 14
80 140 140 A 3.5 0 258 17
80 150 140 A 3.5 0 285 19
80 160 140 A 4 0 318 21
80 170 140 A 4 0 354 27
80 180 140 A 4.5 0 391 33
80 210 140 A 5 0 473 51
80 130 140 O 3 0 67 7
80 140 140 O 3.5 0 73 9
80 150 140 O 3.5 0 80 10
80 160 140 O 4 0 86 11
80 170 140 O 4 0 90 14
80 180 140 O 4.5 0 96 17
80 210 140 O 5 0 110 26

#Data of 90FSW

90 33 300 A 0 J 0
90 33 300 O 0 J 0
90 35 220 A 0.5 J 4
90 35 220 O 0.5 J 2
90 40 220 A 0.5 L 14
90 40 220 O 0.5 L 7
90 45 220 A 0.5 M 23
90 45 220 O 0.5 M 12
90 50 220 A 1 N 31
90 50 220 O 1 N 17
90 55 220 A 1 O 39
90 55 220 O 1 O 21
90 60 220 A 1 Z 56
90 60 220 O 1 Z 24
90 70 220 A 1.5 Z 83
90 70 220 O 1.5 Z 32
90 80 200 A 2 Z 125 5
90 80 200 O 2 Z 40 3
90 90 200 A 2 Z 158 13
90 90 200 O 2 Z 7 46
90 100 200 A 2.5 0 185 19
90 100 200 O 2.5 0 53 10
90 110 200 A 3 0 224 25
90 110 200 O 3 0 61 13
90 120 140 A 3.5 0 256 28 2
90 120 140 O 3.5 0 70 14 2
90 130 140 A 3.5 0 291 28 5
90 140 140 A 4 0 330 28 8
90 150 140 A 4.5 0 378 34 11
90 160 140 A 4.5 0 418 40 13
90 170 140 A 5 0 451 45 15
90 180 140 A 5.5 0 479 51 16
90 240 140 A 7.5 0 592 68 42
90 130 140 O 3.5 0 79 14 5
90 140 140 O 4 0 87 14 8
90 150 140 O 4.5 0 94 17 11
90 160 140 O 4.5 0 101 20 13
90 170 140 O 5 0 106 23 15
90 180 140 O 5.5 0 112 26 16
90 240 140 O 7.5 0 159 34 42

#Data of 100FSW

100 25 320 A 0 H 0
100 25 320 O 0 H 0
100 30 240 A 0.5 J 3
100 30 240 O 0.5 J 2
100 35 240 A 0.5 L 15
100 35 240 O 0.5 L 8
100 40 240 A 1 M 26
100 40 240 O 1 M 14
100 45 240 A 1 N 36
100 45 240 O 1 N 19
100 50 240 A 1 O 47
100 50 240 O 1 O 24
100 55 240 AIR 1.5 Z 65
100 55 240 O2 1.5 Z 28
100 60 240 AIR 1.5 Z 81
100 60 240 O2 1.5 Z 33
100 70 220 AIR 2 Z 124 11
100 70 220 O2 2 Z 39 6
100 80 220 AIR 2.5 Z 160 21
100 80 220 O2 2.5 Z 45 11
100 90 220 AIR 2.5 0 196 28 2
100 90 220 O2 2.5 0 53 14 2
100 100 200 A 3 0 241 28 9
100 100 200 O 3 0 66 14 9
100 110 200 A 3.5 0 278 28 14
100 110 200 O 3.5 0 76 14 14
100 120 200 A 4 0 324 28 19
100 120 200 O 4 0 85 14 19
100 150 140 A 5 0 461 46 26 3
100 150 140 O 5 0 109 23 26 3
100 180 120 A 7.5 0 593 68 47 23 3
100 180 120 O 7.5 0 159 34 47 23 3

#Data of 110FSW

110 20 340 A 0 H 0
110 20 340 O 0 H 0
110 25 300 A 0.5 I 5
110 25 300 O 0.5 I 3
110 30 300 A 0.5 K 14
110 30 300 O 0.5 K 7
110 35 300 A 1 M 27
110 35 300 O 1 M 14
110 40 300 A 1 N 39
110 40 300 O 1 N 20
110 45 300 A 1 O 50
110 45 300 O 1 O 26
110 50 300 A 1.5 Z 71
110 50 300 O 1.5 Z 32
110 55 240 A 1.5 Z 85 5
110 55 240 O 1.5 Z 33 3
110 60 240 A 2 Z 111 13
110 60 240 O 2 Z 36 7
110 70 240 A 2.5 Z 155 26
110 70 240 O 2.5 Z 42 14
110 80 220 A 2.5 0 200 28 9
110 80 220 O 2.5 0 54 14 9
110 90 220 A 3.5 0 249 28 18
110 90 220 O 3.5 0 68 14 18
110 100 220 A 3.5 0 295 28 25
110 100 220 O 3.5 0 79 14 25
110 110 200 A 4 0 353 28 26 5
110 110 200 O 4 0 91 14 26 5
110 120 200 A 4.5 0 413 35 26 10
110 120 200 O 4.5 0 101 18 26 10
110 180 140 A 7.5 0 593 68 47 23 3
110 180 140 O 7.5 0 159 34 47 23 3

#Data of 120FSW

120 15 400 A 0 F 0
120 15 400 O 0 F 0
120 20 320 A 0.5 H 4
120 20 320 O 0.5 H 2
120 25 320 A 0.5 J 9
120 25 320 O 0.5 J 5
120 30 320 A 0.5 L 24
120 30 320 O 0.5 L 13
120 35 320 A 1 N 38
120 35 320 O 1 N 20
120 40 300 A 1 O 49 2
120 40 300 O 1 O 26 1
120 45 300 A 1.5 Z 71 3
120 45 300 O 1.5 Z 31 2
120 50 300 A 1.5 Z 85 10
120 50 300 O 1.5 Z 33 5
120 55 300 A 2 Z 116 19
120 55 300 O 2 Z 35 10
120 60 300 A 2 Z 142 27
120 60 300 O 2 Z 39 14
120 70 240 A 2.5 0 190 28 13
120 70 240 O 2.5 0 51 14 13
120 80 240 A 3 0 246 28 24
120 80 240 O 3 0 67 14 24
120 90 220 A 3.5 0 303 28 26 7
120 90 220 O 3.5 0 80 14 26 7
120 100 220 A 4 0 372 28 25 15
120 100 220 O 4 0 95 14 25 15
120 110 220 A 5 0 433 38 25 21
120 110 220 O 5 0 105 19 25 21
120 120 200 A 5.5 0 480 47 25 23 3
120 120 200 O 5.5 0 113 24 25 23 3
120 180 140 A 9 0 658 94 57 45 21 13
120 180 140 O 9 0 198 46 57 45 21 13

#Data of 130FSW

130 12 420 A 0 F 0
130 12 420 O 0 F 0
130 15 340 A 0.5 G 3
130 15 340 O 0.5 G 2
130 20 340 A 0.5 I 8
130 20 340 O 0.5 I 5
130 25 340 A 0.5 K 17
130 25 340 O 0.5 K 9
130 30 320 A 1 M 32 2
130 30 320 O 1 M 17 1
130 35 320 A 1 O 44 5
130 35 320 O 1 O 23 3
130 40 320 A 1.5 Z 66 6
130 40 320 O 1.5 Z 30 3
130 45 300 A 1.5 Z 84 11 1
130 45 300 O 1.5 Z 33 6 1
130 50 300 A 2 Z 118 20 2
130 50 300 O 2 Z 36 10 2
130 55 300 A 2 Z 146 28 4
130 55 300 O 2 Z 40 14 4
130 60 300 A 2.5 Z 170 28 12
130 60 300 O 2.5 Z 46 14 12
130 70 240 A 3 0 235 28 26 1
130 70 240 O 3 0 63 14 26 1
130 80 240 A 3.5 0 297 28 26 12
130 80 240 O 3.5 0 79 14 26 12
130 90 240 A 4 0 375 28 25 22
130 90 240 O 4 0 95 14 25 22
130 100 220 A 5 0 444 38 26 23 6
130 100 220 O 5 0 106 20 26 23 6
130 120 220 A 6 0 534 57 27 24 17
130 120 220 O 6 0 130 29 27 24 17
130 180 200 A 9 0 658 94 57 45 21 13
130 180 200 O 9 0 198 46 57 45 21 13

#Data of 140FSW

140 10 440 A 0 E 0
140 10 440 O 0 E 0
140 15 400 A 0.5 H 5
140 15 400 O 0.5 H 3
140 20 340 A 0.5 J 13
140 20 340 O 0.5 J 7
140 25 340 A 1 L 24 3
140 25 340 O 1 L 12 2
140 30 320 A 1 N 37 7
140 30 320 O 1 N 19 4
140 35 320 A 1.5 O 58 7 2
140 35 320 O 1.5 O 26 4 2
140 40 320 A 1.5 Z 82 7 4
140 40 320 O 1.5 Z 33 4 4
140 45 320 A 2 Z 114 18 5
140 45 320 O 2 Z 36 9 5
140 50 320 A 2 Z 145 27 8
140 50 320 O 2 Z 39 14 8
140 55 300 A 2.5 Z 171 29 15 1
140 55 300 O 2.5 Z 45 15 15 1
140 60 300 A 3 0 209 28 23 2
140 60 300 O 3 0 56 14 23 2
140 70 300 A 3.5 0 276 29 25 14
140 70 300 O 3.5 0 74 15 25 14
140 80 240 A 4 0 362 29 25 24 2
140 80 240 O 4 0 91 15 25 24 2
140 90 240 A 5 0 443 38 26 23 12
140 90 240 O 5 0 107 19 26 23 12
140 120 220 A 8 0 608 75 50 23 22 20 3
140 120 220 O 8 0 168 37 50 23 22 20 3
140 180 140 A 10.5 0 694 121 79 48 42 20 19 2
140 180 140 O 10.5 0 222 58 79 48 42 20 19 2

#Data of 150FSW

150 8 500 A 0 E 0
150 8 500 O 0 E 0
150 10 420 A 0.5 F 2
150 10 420 O 0.5 F 1
150 15 420 A 0.5 H 8
150 15 420 O 0.5 H 5
150 20 400 A 0.5 K 15 2
150 20 400 O 0.5 K 8 1
150 25 400 A 1 M 29 7
150 25 400 O 1 M 14 4
150 30 340 A 1.5 O 45 7 4
150 30 340 O 1.5 O 22 4 4
150 35 340 A 1.5 Z 74 7 6
150 35 340 O 1.5 Z 30 4 6
150 40 320 A 2 Z 106 14 6 2
150 40 320 O 2 Z 35 7 6 2
150 45 320 A 2 Z 142 24 8 3
150 45 320 O 2 Z 40 12 8 3
150 50 320 A 2.5 Z 170 28 14 4
150 50 320 O 2.5 Z 46 14 14 4
150 55 320 A 3 0 212 28 21 7
150 55 320 O 3 0 57 14 21 7
150 60 320 A 3 0 248 28 26 11
150 60 320 O 3 0 67 14 26 11
150 70 300 A 4 0 330 28 25 24 3
150 70 300 O 4 0 85 14 25 24 3
150 80 300 A 4.5 0 430 35 26 23 15
150 80 300 O 4.5 0 104 18 26 23 15
150 90 240 A 5.5 0 496 47 26 23 22 3
150 90 240 O 5.5 0 118 24 26 23 22 3
150 120 220 A 8 0 608 75 50 23 22 20 3
150 120 220 O 8 0 168 37 50 23 22 20 3
150 180 200 A 10.5 0 694 121 79 48 42 20 19 2
150 180 200 O 10.5 0 222 58 79 48 42 20 19 2

#Data of 160FSW

160 7 520 A 0 C 0
160 10 440 A 0.5 F 4
160 15 440 A 0.5 I 10 2
160 20 400 A 0.5 L 22 4 1
160 25 400 A 1 N 35 7 4
160 30 340 A 1.5 O 62 7 6 2
160 35 340 A 1.5 Z 89 8 6 4
160 40 340 A 2 Z 134 21 6 6
160 45 320 A 2.5 Z 166 28 11 5 2
160 50 320 A 3 0 207 28 19 8 2
160 55 320 A 3 0 248 28 26 11 3
160 60 320 A 3.5 0 291 29 25 17 6
160 70 320 A 4.5 0 399 29 26 23 15
160 80 300 A 5.5 0 482 44 25 24 21 6
160 7 520 O 0 C 0
160 10 440 O 0.5 F 2
160 15 440 O 0.5 I 6 1
160 20 400 O 0.5 L 12 2 1
160 25 400 O 1 N 17 4 4
160 30 340 O 1.5 O 26 4 6 2
160 35 340 O 1.5 Z 34 4 6 4
160 40 340 O 2 Z 38 11 6 6
160 45 320 O 2.5 Z 45 14 11 5 2
160 50 320 O 3 0 55 15 19 8 2
160 55 320 O 3 0 67 14 26 11 3
160 60 320 O 3.5 0 77 15 25 17 6
160 70 320 O 4.5 0 99 15 26 23 15
160 80 300 O 5.5 0 114 23 25 24 21 6
160 120 220 A 9 0 659 94 60 42 22 20 19 9
160 180 200 A 11.5 0 703 156 97 70 43 40 19 18 10
160 120 220 O 9 0 198 46 60 42 22 20 19 9
160 180 200 O 11.5 0 229 74 97 70 43 40 19 18 10

#Data of 170FSW

170 6 540 A 0 D 0
170 10 500 A 0.5 G 6
170 15 440 A 0.5 J 13 3
170 20 420 A 1 M 24 6 3
170 25 400 A 1 O 41 7 7 1
170 30 400 A 1.5 Z 77 7 7 5
170 35 340 A 2 Z 120 15 6 6 2
170 40 340 A 2.5 Z 158 25 9 6 4
170 45 340 A 2.5 Z 197 28 16 7 5
170 50 320 A 3 0 244 28 23 11 5 1
170 55 320 A 3.5 0 289 28 26 16 7 2
170 60 320 A 4 0 344 28 26 21 11 2
170 70 320 A 5 0 454 39 25 24 19 7
170 80 320 A 6 0 525 53 26 23 22 17
170 90 300 A 7 0 574 66 37 23 22 19 8
170 120 240 A 9 0 659 94 60 42 22 20 19 9
170 180 220 A 11.5 0 703 156 97 70 43 40 19 18 10
170 6 540 O 0 D 0
170 10 500 O 0.5 G 3
170 15 440 O 0.5 J 4 2
170 20 420 O 1 M 12 3 3
170 25 400 O 1 O 20 4 7 1
170 30 400 O 1.5 Z 30 3 7 5
170 35 340 O 2 Z 37 8 6 6 2
170 40 340 O 2.5 Z 44 12 9 6 4
170 45 340 O 2.5 Z 53 14 16 7 5
170 50 320 O 3 0 66 14 23 11 5 1
170 55 320 O 3.5 0 77 14 26 16 7 2
170 60 320 O 4 0 88 14 26 21 11 2
170 70 320 O 5 0 109 20 25 24 19 7
170 80 320 O 6 0 128 27 26 23 22 17
170 90 300 O 7 0 148 33 37 23 22 19 8
170 120 240 O 9 0 198 46 60 42 22 20 19 9
170 180 220 O 11.5 0 229 74 97 70 43 40 19 18 10

#Data of 180FSW

180 6 600 A 0 E 0
180 10 520 A 0.5 G 8
180 15 440 A 0.5 K 14 3 2
180 20 420 A 1 M 26 7 5 1
180 25 420 A 1.5 O 54 7 6 5
180 30 400 A 1.5 Z 95 7 6 6 3
180 35 340 A 2 Z 144 22 6 6 5 1
180 40 340 A 2.5 0 178 28 13 5 6 2
180 45 340 A 3 0 235 28 20 10 5 4
180 50 340 A 3.5 0 277 28 25 13 8 4
180 55 340 A 4 0 336 28 26 19 11 5
180 60 320 A 4.5 0 406 31 25 23 13 8 1
180 70 320 A 5.5 0 499 48 25 24 21 12 4
180 6 600 O 0 E 0
180 10 520 O 0.5 G 4
180 15 440 O 0.5 K 7 2 2
180 20 420 O 1 M 15 3 5 1
180 25 420 O 1.5 O 26 4 6 5
180 30 400 O 1.5 Z 34 4 6 6 3
180 35 340 O 2 Z 41 11 6 6 5 1
180 40 340 O 2.5 0 48 14 13 5 6 2
180 45 340 O 3 0 63 14 20 10 5 4
180 50 340 O 3.5 0 75 15 25 13 8 4
180 55 340 O 4 0 87 14 26 19 11 5
180 60 320 O 4.5 0 100 16 25 23 13 8 1
180 70 320 O 5.5 0 119 24 25 24 21 12 4
180 90 300 A 8.5 0 626 83 51 28 21 20 19 11
180 120 240 A 10.5 0 691 113 79 46 37 20 19 17 15
180 90 300 O 8.5 0 178 41 51 28 21 20 19 11
180 120 240 O 10.5 0 219 55 79 46 37 20 19 17 15

#Data of 190FSW

190 5 620 A 0 D 0
190 10 520 A 0.5 H 8 2
190 15 440 A 0.5 K 16 3 3 1
190 20 420 A 1 N 34 7 6 2 1
190 25 420 A 1.5 Z 72 7 7 6 2
190 30 400 A 2 Z 122 13 7 5 6 1
190 35 400 A 2.5 Z 165 26 8 6 5 4
190 40 340 A 3 0 217 28 17 8 5 5 1
190 45 340 A 3.5 0 264 29 24 12 6 5 2
190 50 340 A 4 0 324 28 26 17 10 5 3
190 55 340 A 4.5 0 397 30 25 24 10 8 4
190 60 340 A 5 0 454 40 25 24 16 10 5
190 90 320 A 8.5 0 626 83 51 28 21 20 19 11
190 120 300 A 10.5 0 691 113 79 46 37 20 19 17 15
190 5 620 O 0 D 0
190 10 520 O 0.5 H 4 1
190 15 440 O 0.5 K 8 2 3 1
190 20 420 O 1 N 17 4 6 2 1
190 25 420 O 1.5 Z 28 3 7 6 2
190 30 400 O 2 Z 38 7 7 5 6 1
190 35 400 O 2.5 Z 45 13 8 6 5 4
190 40 340 O 3 0 58 15 17 8 5 5 1
190 45 340 O 3.5 0 71 15 24 12 6 5 2
190 50 340 O 4 0 85 14 26 17 10 5 3
190 55 340 O 4.5 0 99 15 25 24 10 8 4
190 60 340 O 5 0 109 20 25 24 16 10 5
190 90 320 O 8.5 0 178 41 51 28 21 20 19 11
190 120 300 O 10.5 0 219 55 79 46 37 20 19 17 15

#Data of 200FSW

200 5 640 A 0 E 0
200 10 540 A 0.5 H 8 3
200 15 500 A 0.5 L 19 5 3 2
200 20 440 A 1 O 43 7 6 4 2
200 25 420 A 1.5 Z 85 7 6 6 5 1
200 30 420 A 2 Z 145 19 7 5 6 4
200 35 400 A 2.5 0 188 28 13 6 5 5 2
200 40 400 A 3.5 0 249 28 21 11 5 5 4
200 45 340 A 3.5 0 306 28 25 14 10 5 4 1
200 50 340 A 4.5 0 382 28 26 21 10 8 4 2
200 5 640 O 0 E 0
200 10 540 O 0.5 H 4 2
200 15 500 O 0.5 L 9 3 3 2
200 20 440 O 1 O 20 4 6 4 2
200 25 420 O 1.5 Z 32 4 6 6 5 1
200 30 420 O 2 Z 42 10 7 5 6 4
200 35 400 O 2.5 0 51 14 13 6 5 5 2
200 40 400 O 3.5 0 68 14 21 11 5 5 4
200 45 340 O 3.5 0 81 14 25 14 10 5 4 1
200 50 340 O 4.5 0 97 14 26 21 10 8 4 2

#Data of 210FSW

210 4 700 A 0 D 0
210 5 620 A 0.5 E 2
210 10 540 A 0.5 I 24 3 2
210 15 500 A 1 M 24 6 3 3 1
210 20 440 A 1 O 57 7 6 5 3 1
210 25 440 A 2 Z 110 8 7 5 6 3
210 30 420 A 2.5 Z 163 26 6 6 6 5 2
210 35 400 A 3 0 223 28 18 7 6 5 4 1
210 40 400 A 3.5 0 278 28 26 11 7 5 5 2
210 45 400 A 4 0 355 28 26 18 11 6 4 4
210 50 340 A 5 0 432 36 26 23 12 10 5 4 1
210 4 700 O 0 D 0
210 5 620 O 0.5 E 1
210 10 540 O 0.5 I 4 2 2
210 15 500 O 1 M 12 3 3 3 1
210 20 440 O 1 O 23 4 6 5 3 1
210 25 440 O 2 Z 38 4 7 5 6 3
210 30 420 O 2.5 Z 45 13 6 6 6 5 2
210 35 400 O 3 0 60 14 18 7 6 5 4 1
210 40 400 O 3.5 0 76 14 26 11 7 5 5 2
210 45 400 O 4 0 91 14 26 18 11 6 4 4
210 50 340 O 5 0 105 18 26 23 12 10 5 4 1

#Data of 220FSW

220 4 720 A 0 E 0
220 5 640 A 0.5 E 8 3
220 10 600 A 0.5 J 19 5 3 2
220 15 520 A 1 N 43 7 6 4 2
220 20 500 A 1.5 Z 85 7 6 6 5 1
220 25 440 A 2 Z 145 19 7 5 6 4
220 30 420 A 2.5 0 188 28 13 6 5 5 2
220 35 420 A 3.5 0 249 28 21 11 5 5 4
220 40 400 A 4 0 306 28 25 14 10 5 4 1
220 4 720 O 0 E 0
220 5 640 O 0.5 E 4 2
220 10 600 O 0.5 J 9 3 3 2
220 15 520 O 1 N 20 4 6 4 2
220 20 500 O 1.5 Z 32 4 6 6 5 1
220 25 440 O 2 Z 42 10 7 5 6 4
220 30 420 O 2.5 0 51 14 13 6 5 5 2
220 35 420 O 3.5 0 68 14 21 11 5 5 4
220 40 400 O 4 0 81 14 25 14 10 5 4 1

#Data of 250FSW

250 4 740 A 0.5 F 0
250 5 740 A 0.5 G 2
250 10 620 A 0.5 L 24 3 2
250 15 540 A 1 O 24 6 3 3 1
250 20 520 A 2 Z 57 7 6 5 3 1
250 25 500 A 2.5 0 110 8 7 5 6 3
250 30 440 A 3.5 0 163 26 6 6 6 5 2
250 35 440 A 4 0 223 28 18 7 6 5 4 1
250 4 740 O 0.5 F 0
250 5 740 O 0.5 G 1
250 10 620 O 0.5 L 4 2 2
250 15 540 O 1 O 12 3 3 3 1
250 20 520 O 2 Z 23 4 6 5 3 1
250 25 500 O 2.5 0 38 4 7 5 6 3
250 30 440 O 3.5 0 45 13 6 6 6 5 2
250 35 440 O 4 0 60 14 18 7 6 5 4 1
";
            }
            string[] lines_w_r = data.Split('\n');
            List<string> linesL = new List<string>();
            foreach(var line in lines_w_r)
            {
                if (line == "")
                    continue;
                linesL.Add(line.Substring(0, line.Length - 1));
            }

            string[] lines = linesL.ToArray();

            return lines;
        }

        #endregion

        private void BT_Info_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(@"기획Plan : 최율겸, Yulgyeom Choe, choy0928@naver.com
개발Dev : 황원준, Wonjun Hwang, iamjam4944@gmail.com

Currently under development. Intended for helping divers to easily make Air decompression tables. Now can be used as a prototype.
Diver's World는 현재 개발 중이며 다이버/슈퍼바이저들의 감압 테이블 작성을 도와주는 프로그램입니다.

Diver's world has no additional dependency except for the fact that is manufactured, built & tested under .NET framework 4.6.1., and is an open source program and can be found on the link below;
본 프로그램은 별도의 Dependency가 없으며 .NET framwork 4.6.1버전에서 제작, 테스트, 빌드되었습니다. 본 프로그램은 오픈소스이며 소스코드는 하단의 주소에 공개되어 있습니다.
https://github.com/Maetel/DiversWorld

* Warning *
The data and the strategy used for making air decompression table we provide with are referred to U.S. Navy guide. The providers cannot accept responsibility for loss or damage and does not endorse the U.S. Navy, and is not liable for their policies nor guaranteed/verified from them.
본 프로그램은 美 Navy 교범을 참고하였으나 해당 기관으로부터의 보증과 해당 기관과의 이해관계가 없으며, 제작자 및 제공자는 본 프로그램의 사용에 따른 인명 및 재산 피해에 대한 어떤 법적 책임도 지지 않습니다.

Last update/마지막 업데이트 날짜 : 2019. 03. 05 (yyyy.mm.dd)
", "INFO");
        }

        private void BT_License_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(@"By downloading, copying, installing or using the software you agree to this license. If you do not agree to this license, do not download, install, copy or use the software.

This work is licensed under a Creative Commons Attribution-NonCommercial - ShareAlike 4.0 International License.
Please refer to INFO button above for more and contact.

본 프로그램은 Creative Commons 4.0 NC SA 라이센스로 제작되었습니다. 다음 행동들은 해당 라이센스에 동의하는 것으로 간주됩니다 : 다운로드, 설치, 복사. 자세한 내용 및 문의는 INFO를 참조해주세요.
", "LICENSE");
        }
    }
}
