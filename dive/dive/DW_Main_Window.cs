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
            //system made
            InitializeComponent();

            initVars();
            initTBDesignators();
            initMemberProperties();
            initTableData();
            setLanguageDependentValues();
            initLanguageDependentValues();
            initFieldValues();
        }

        void colorInputField(bool decolor = false)
        {
            if (decolor)
            {
                foreach (var tb in g_TB_WRITE_field)
                {
                    tb.BackColor = Color.White;
                    if(tb == TB_Author || tb==TB_Diver || tb == TB_Write_Time)
                    {
                        tb.BackColor = Color.FromArgb(192, 192, 255);
                    }
                    //tb.Invalidate();
                    //tb.Update();
                    //tb.Refresh();
                    //Application.DoEvents();
                }

                PN_Additional_Record.BackColor = Color.White;

                GB_DComp_Proc_Air.BackColor = Color.White;
                GB_DComp_Proc_AirHe.BackColor = Color.White;

                //update UI
                GB_DComp_Proc_AirHe.Invalidate();
                GB_DComp_Proc_AirHe.Update();
                GB_DComp_Proc_AirHe.Refresh();
                Application.DoEvents();
            }
            else
            {
                PN_Additional_Record.BackColor = Color.FromArgb(255, 255, 192);

                GB_DComp_Proc_Air.BackColor = Color.FromArgb(255, 255, 192);
                GB_DComp_Proc_AirHe.BackColor = Color.FromArgb(255, 255, 192);

                foreach (var tb in g_TB_WRITE_field)
                {
                    tb.BackColor = Color.FromArgb(255,255,192);
                }
                
            }
            
        }

        private void setLanguageDependentValues()
        {
            //Label
            scr.labels.Add(nameof(LB_input), LB_input);
            scr.labels.Add(nameof(LB_output), LB_output);
            scr.labels.Add(nameof(LB_D_CurTime), LB_D_CurTime);


            //Button
            scr.buttons.Add(nameof(BT_LANGUAGE), BT_LANGUAGE);
            scr.buttons.Add(nameof(BT_Initialize), BT_Initialize);
            scr.buttons.Add(nameof(BT_Reload_Data_File), BT_Reload_Data_File);
            scr.buttons.Add(nameof(BT_Save_Capture), BT_Save_Capture);
            scr.buttons.Add(nameof(BT_Info), BT_Info);
            scr.buttons.Add(nameof(BT_License), BT_License);


            //RadioButton
            scr.radioButtons.Add(nameof(RB_GAS_AIR), RB_GAS_AIR);
            scr.radioButtons.Add(nameof(RB_GAS_AIRO2), RB_GAS_AIRO2);
            scr.radioButtons.Add(nameof(RB_GAS_SurD), RB_GAS_SurD);
            scr.radioButtons.Add(nameof(RB_HeO2_HeO2), RB_HeO2_HeO2);
            scr.radioButtons.Add(nameof(RB_HeO2_SurD), RB_HeO2_SurD);

            //TextBox
            scr.textBoxes.Add(nameof(TB_Title), TB_Title);
            scr.textBoxes.Add(nameof(TB_D_Author), TB_D_Author);
            scr.textBoxes.Add(nameof(TB_D_Diver), TB_D_Diver);
            scr.textBoxes.Add(nameof(TB_D_Write_Time), TB_D_Write_Time);
            scr.textBoxes.Add(nameof(TB_D_Depth), TB_D_Depth);
            scr.textBoxes.Add(nameof(TB_D_Dcomp_Time), TB_D_Dcomp_Time);
            scr.textBoxes.Add(nameof(TB_D_Clocktime), TB_D_Clocktime);
            scr.textBoxes.Add(nameof(TB_D_Circums), TB_D_Circums);
            scr.textBoxes.Add(nameof(TB_D_Depth_Time), TB_D_Depth_Time);
            scr.textBoxes.Add(nameof(TB_D_LS), TB_D_LS);
            scr.textBoxes.Add(nameof(TB_D_RB), TB_D_RB);
            scr.textBoxes.Add(nameof(TB_D_LB), TB_D_LB);
            scr.textBoxes.Add(nameof(TB_D_R1st), TB_D_R1st);
            scr.textBoxes.Add(nameof(TB_D_RS), TB_D_RS);
            scr.textBoxes.Add(nameof(TB_D_Desc_Time), TB_D_Desc_Time);
            scr.textBoxes.Add(nameof(TB_D_StageDepth), TB_D_StageDepth);
            scr.textBoxes.Add(nameof(TB_D_MaxDepth), TB_D_MaxDepth);
            scr.textBoxes.Add(nameof(TB_D_TBT), TB_D_TBT);
            scr.textBoxes.Add(nameof(TB_D_DCompTable), TB_D_DCompTable);
            scr.textBoxes.Add(nameof(TB_D_TB_Time_To_R1st_Actual), TB_D_TB_Time_To_R1st_Actual);
            scr.textBoxes.Add(nameof(TB_D_Time_To_R1st_Planned), TB_D_Time_To_R1st_Planned);
            scr.textBoxes.Add(nameof(TB_D_Time_To_R1st_Delayed), TB_D_Time_To_R1st_Delayed);
            scr.textBoxes.Add(nameof(TB_D_Travel_Shift_Vent_Time), TB_D_Travel_Shift_Vent_Time);
            scr.textBoxes.Add(nameof(TB_D_Ascent_Time_Water), TB_D_Ascent_Time_Water);
            scr.textBoxes.Add(nameof(TB_D_Undress_Time), TB_D_Undress_Time);
            scr.textBoxes.Add(nameof(TB_D_Desc_Chamber_SurD), TB_D_Desc_Chamber_SurD);
            scr.textBoxes.Add(nameof(TB_D_Total_SurD_Interval), TB_D_Total_SurD_Interval);
            scr.textBoxes.Add(nameof(TB_D_Ascent_Time_Chamber), TB_D_Ascent_Time_Chamber);
            scr.textBoxes.Add(nameof(TB_D_HoldsOnDesc), TB_D_HoldsOnDesc);
            scr.textBoxes.Add(nameof(TB_D_Delay_Depth), TB_D_Delay_Depth);
            scr.textBoxes.Add(nameof(TB_D_Delay_Problem), TB_D_Delay_Problem);
            scr.textBoxes.Add(nameof(TB_D_DelayOnAsc), TB_D_DelayOnAsc);
            scr.textBoxes.Add(nameof(TB_D_Delay_Depth2), TB_D_Delay_Depth2);
            scr.textBoxes.Add(nameof(TB_D_Delay_Problem2), TB_D_Delay_Problem2);
            scr.textBoxes.Add(nameof(TB_D_Decomp_proc_used), TB_D_Decomp_proc_used);
            scr.textBoxes.Add(nameof(TB_D_Repeat_Group), TB_D_Repeat_Group);
            scr.textBoxes.Add(nameof(TB_D_TDT), TB_D_TDT);
            scr.textBoxes.Add(nameof(TB_D_TTD), TB_D_TTD);
            scr.textBoxes.Add(nameof(TB_D_Additional_Record), TB_D_Additional_Record);
            //scr.textBoxes.Add(nameof(), );

            //GroupBoxes
            scr.groupBoxes.Add(nameof(GB_DComp_Proc_Air), GB_DComp_Proc_Air);
            scr.groupBoxes.Add(nameof(GB_DComp_Proc_AirHe), GB_DComp_Proc_AirHe);

        }

        private void initLanguageDependentValues()
        {
            //Label
            foreach (var label in scr.labels)
            {
                label.Value.Text = scr.alias[label.Key];
            }

            //RadioButton
            foreach (var rb in scr.radioButtons)
            {
                rb.Value.Text = scr.alias[rb.Key];
            }

            //Button
            foreach (var button in scr.buttons)
            {
                button.Value.Text = scr.alias[button.Key];
            }

            //TextBox
            foreach (var box in scr.textBoxes)
            {
                box.Value.Text = scr.alias[box.Key];
            }

            //GroupBox
            foreach (var gb in scr.groupBoxes)
            {
                gb.Value.Text = scr.alias[gb.Key];
            }
        }

        private void DW_Main_Window_Load(object sender, EventArgs e)
        {
            this.LB_CurTime.Text = getTime();
        }

        private void switchLanguage()
        {
            scr.switchLanguage();
            initLanguageDependentValues();
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
            return DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss (tt)", System.Globalization.CultureInfo.InvariantCulture);
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

            //all input fields
            {
                g_TB_WRITE_field.Add(TB_Author);
                g_TB_WRITE_field.Add(TB_Diver);

                g_TB_WRITE_field.Add(TB_LS);
                g_TB_WRITE_field.Add(TB_StageDepth);
                g_TB_WRITE_field.Add(TB_TBT);
                g_TB_WRITE_field.Add(TB_Time_To_R1st_Delayed);

                g_TB_WRITE_field.Add(TB_DELAY_Desc_Depth1);
                g_TB_WRITE_field.Add(TB_DELAY_Desc_Depth2);
                g_TB_WRITE_field.Add(TB_DELAY_Desc_Depth3);
                g_TB_WRITE_field.Add(TB_DELAY_Asc_Depth1);
                g_TB_WRITE_field.Add(TB_DELAY_Asc_Depth2);
                g_TB_WRITE_field.Add(TB_DELAY_Asc_Depth3);
                g_TB_WRITE_field.Add(TB_DELAY_Desc_Reason1);
                g_TB_WRITE_field.Add(TB_DELAY_Desc_Reason2);
                g_TB_WRITE_field.Add(TB_DELAY_Desc_Reason3);
                g_TB_WRITE_field.Add(TB_DELAY_Asc_Reason1);
                g_TB_WRITE_field.Add(TB_DELAY_Asc_Reason2);
                g_TB_WRITE_field.Add(TB_DELAY_Asc_Reason3);

                g_TB_WRITE_field.Add(TB_Additional_Record);
            }
        }

        public void initFieldValues() {
            
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
            this.LB_CurTime.Text = getTime();
        }

        //memory allocation
        public void initVars()
        {
            scr = new Scripts(Language.KOR);

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
                    
                    setStatus(Status.ST_Data_Nested, Color.LightGreen, Color.Black);
                }
                else
                {
                    g_LoadFromFile = false;
                }
                
            }

            if (g_LoadFromFile == false)
            //make nested table
            {
                setStatus(Status.ST_Data_Nested, Color.LightGreen, Color.Black);

                lines = DataTable.makeNestedDataTable();
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

        static Scripts scr;

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

        #region Utils
        enum Status { ST_Lang_Changed, ST_Image_Saved, ST_Data_Nested, ST_Initialized}
        private void setStatus(Status stat, Color bg, Color textColor)
        {
            string statStr = "";
            switch (stat)
            {
                case Status.ST_Data_Nested:
                    statStr = "ST_Data_Nested";
                    break;
                case Status.ST_Image_Saved:
                    statStr = "ST_Image_Saved";
                    break;
                case Status.ST_Initialized:
                    statStr = "ST_Initialized";
                    break;
                case Status.ST_Lang_Changed:
                    statStr = "ST_Lang_Changed";
                    break;
            }
            LB_Status.Text = scr.alias[statStr];
            LB_Status.BackColor = bg;
            LB_Status.ForeColor = textColor;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.LB_CurTime.Text = getTime();
            this.TB_Write_Time.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm (tt)", System.Globalization.CultureInfo.InvariantCulture);
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
                string isError = scr.alias["WORD_Put_Number"];
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
            map.Add(300, 7);
            map.Add(200, 4);
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
                TB_DCompTable.Text = "[ FSW: " + tableDepth.ToString() + ", BT: " + tableBT.ToString() + " ]";

                TB_Time_To_R1st_Planned.Text = colonizeTime(row.m_TimeToFirstStop, ColonType.SEC4DIGITS);
                UpdateTimeTo1stStop();

                TB_Repeat_Group.Text = ((row.m_RepeatGroup.ToString()) == "0") ? scr.alias["WORD_No_Repeat_Group"] : row.m_RepeatGroup.ToString();

                foreach (var elem in g_TB_FSW_Results) { elem.Text = "-"; }

                foreach (var stop in row.m_DCompStops)
                {
                    //specialize for No decompression
                    if (stop.Key == 20 && stop.Value == 0)
                    {
                        TB_DCompTable.Text = "[ "+ scr.alias["WORD_No_Decomp"] + " ]";
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
                string noData = scr.alias["WORD_No_Data"];
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
            initFieldValues();
            setStatus(Status.ST_Initialized, Color.LightGreen, Color.Black);
        }

        
        private void BT_Reload_Data_File_MouseDown(object sender, MouseEventArgs e)
        {
            g_LoadFromFile = true;
            initTableData();
        }

        private void BT_Save_Capture_MouseDown(object sender, MouseEventArgs e)
        {
            colorInputField(true);
            setInputFieldFontSize(9f);

            //get window and save image
            Rectangle bounds = this.Bounds;
            int padTop = 31;
            int padLeft = 8;
            int padBottom = 1;
            int padRight = 1;
            int left = bounds.Left + padLeft;
            int top = bounds.Top + padTop;
            Point LT = new Point(left + this.PN_Title.Location.X, top + this.PN_Title.Location.Y);
            Point RB = new Point(left + this.PN_Title.Location.X + this.PN_Title.Size.Width, top + this.PN_Tale.Location.Y + this.PN_Tale.Size.Height);

            //string defaultImgName = "감압테이블 " + DateTime.Now.ToString()+".png";
            string defaultImgName = scr.alias["WORD_DComp_Table"]+" " +
                DateTime.Now.ToString("yyyy-MM-dd tt HHmm", System.Globalization.CultureInfo.InvariantCulture);

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
                DialogResult res = imgSaveDialog.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                //if (imgSaveDialog.FileName != "")
                if (res == DialogResult.OK)
                {
                    System.IO.FileStream fs = (System.IO.FileStream)imgSaveDialog.OpenFile();
                    switch (imgSaveDialog.FilterIndex)
                    {
                        case 1:
                            var encoderJ = ImageCodecInfo.GetImageEncoders()
                            .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encParamsJ = new EncoderParameters(1);
                            encParamsJ.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 120L);
                            bitmap.Save(fs, encoderJ, encParamsJ);
                            //bitmap.Save(fs,
                            //   System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            var encoderP = ImageCodecInfo.GetImageEncoders()
                            .First(c => c.FormatID == ImageFormat.Png.Guid);
                            var encParamsP = new EncoderParameters(1);
                            encParamsP.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 120L);
                            bitmap.Save(fs, encoderP, encParamsP);
                            break;
                    }

                    fs.Close();

                    setStatus(Status.ST_Image_Saved, Color.LightGreen, Color.Black);

                }

            }

            colorInputField();
            setInputFieldFontSize(11.25f);
        }

        void setInputFieldFontSize(float size)
        {
            TB_LS.Font = new Font(TB_LS.Font.FontFamily, size);
            TB_StageDepth.Font = new Font(TB_LS.Font.FontFamily, size);
            TB_TBT.Font = new Font(TB_LS.Font.FontFamily, size);
            TB_Time_To_R1st_Delayed.Font = new Font(TB_LS.Font.FontFamily, size);

            TB_Time_To_R1st_Delayed.Invalidate();
            TB_Time_To_R1st_Delayed.Update();
            TB_Time_To_R1st_Delayed.Refresh();
            Application.DoEvents();
        }

        #endregion

        //get script
        private string getScr(string alias)
        {
            if (scr.alias.ContainsKey(alias.ToLower()))
            {
                return scr.alias[alias.ToLower()];
            }

            return "no data";
        }

        #region Make_Nested_Data_Table

        
        #endregion

        private void BT_Info_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(scr.getInfo(), scr.alias["WORD_INFO"]);
        }

        private void BT_License_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(scr.getLicense(), scr.alias["WORD_LICENSE"]);
        }

        private void BT_LANGUAGE_Click(object sender, EventArgs e)
        {
            switchLanguage();
            UpdateInput();

            setStatus(Status.ST_Lang_Changed, Color.LightGreen, Color.Black);
        }
    }
}
