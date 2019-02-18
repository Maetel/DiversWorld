using System;
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
        int g_stageDepth = -1;
        int g_MaxDepth = -1;

        HSYSTimes hTimes;
        SortedDictionary<int, DCompTable> g_DCompTables; init

        public class HSYSTimes
        {
            public HSYS g_LS;
            public HSYS g_RB;
            public HSYS g_LB;
            public HSYS g_EstRB;
            public HSYS g_TBT;

            public HSYSTimes()
            {
                g_LS = new HSYS();
                g_RB = new HSYS();
                g_LB = new HSYS();
                g_EstRB = new HSYS();
                g_TBT = new HSYS();
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

            public bool isInitialized()
            {
                return hour != -1 && minute != 1;
            }

            public HSYS(int _4digit)
            {
                hour = _4digit / 100;
                minute = _4digit % 100;
            }

            public void set4digit(int _4digit)
            {
                int digit = Convert.ToInt32(_4digit);
                hour = digit / 100;
                minute = digit % 100;
            }

            public HSYS(string _4digit)
            {
                this.set4digit(Convert.ToInt32(_4digit));
            }
            public HSYS(int hour, int minute)
            {
                this.hour = hour;
                this.minute = minute;
            }

            public HSYS addMin(int min)
            {
                int totMin = this.minute + min;
                int totHour = this.hour;
                if (totMin >= 60)
                {
                    totHour++;
                    totMin -= 60;
                }
                this.minute = totMin;
                this.hour = totHour;
                return this;
            }

            public HSYS subMin(int min)
            {
                int totMin = this.minute - min;
                int totHour = this.hour;
                if (totMin < 0)
                {
                    totHour--;
                    totMin += 60;
                }
                this.minute = totMin;
                this.hour = totHour;
                return this;
            }

            public static HSYS operator +(HSYS lhs, HSYS rhs)
            {
                int totMin = lhs.minute + rhs.minute;
                int totHour = lhs.hour + rhs.hour;
                if (totMin >= 60)
                {
                    totHour++;
                    totMin -= 60;
                }
                HSYS result = new HSYS(totHour, totMin);
                return result;
            }

            public static HSYS operator -(HSYS lhs, HSYS rhs)
            {
                int totMin = lhs.minute - rhs.minute;
                int totHour = lhs.hour - rhs.hour;
                if (totMin < 0)
                {
                    totHour--;
                    totMin += 60;
                }
                HSYS result = new HSYS(totHour, totMin);
                return result;
            }

            public override string ToString()
            {
                return ToInt().ToString().PadLeft(4, '0');
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

        public class DCompRow
        {
            int m_BottomTime = 1;
            int m_TimeToFirstStop = -1;
            GasMix m_GasMix = GasMix.NONE;
            int m_TotalAscentTime = -1;
            double m_ChamberO2Periods = -1;
            char m_RepeatGroup = '0';
            SortedDictionary<int, int> m_DCompStops;
            bool isMapInitialized = false;
            public string printDCompStops()
            {
                string result = "";
                foreach ( var pair in m_DCompStops)
                {
                    result += "key : " + pair.Key.ToString() + ", value : " + pair.Value.ToString() + "\n";
                }
                return result;
            }
            private void initDecomp()
            {
                m_DCompStops = new SortedDictionary<int, int>();
                m_DCompStops[20] = 0;
                m_DCompStops[30] = 0;
                m_DCompStops[40] = 0;
                m_DCompStops[50] = 0;
                m_DCompStops[60] = 0;
                m_DCompStops[70] = 0;
                m_DCompStops[80] = 0;
                m_DCompStops[90] = 0;
                m_DCompStops[100] = 0;
            }
            private void initDecomp(params int[] mapList)
            {
                initDecomp();
                var keys = m_DCompStops.Keys.ToList();
                
                for ( int idx = 0; idx < mapList.Length; idx++)
                {
                    m_DCompStops[keys.ElementAt(idx)] = mapList[idx];
                }
                isMapInitialized = true;
            }

            public DCompRow() {
                m_DCompStops = new SortedDictionary<int, int>();
                m_DCompStops[20] = -1;
                m_DCompStops[30] = -1;
                m_DCompStops[40] = -1;
                m_DCompStops[50] = -1;
                m_DCompStops[60] = -1;
                m_DCompStops[70] = -1;
                m_DCompStops[80] = -1;
                m_DCompStops[90] = -1;
                m_DCompStops[100] = -1;
            }
            public DCompRow(int bottomTime, int timeToFirstStop, GasMix gasMix, int totalAscentTime, double chamberO2Periods, char repeatGroup, params int[] mapList)
            {
                m_DCompStops = new SortedDictionary<int, int>();
                m_DCompStops[20] = -1;
                m_DCompStops[30] = -1;
                m_DCompStops[40] = -1;
                m_DCompStops[50] = -1;
                m_DCompStops[60] = -1;
                m_DCompStops[70] = -1;
                m_DCompStops[80] = -1;
                m_DCompStops[90] = -1;
                m_DCompStops[100] = -1;
                var keys = m_DCompStops.Keys.ToList();

                for (int idx = 0; idx < mapList.Length; idx++)
                {
                    m_DCompStops[keys.ElementAt(idx)] = mapList[idx];
                }
                isMapInitialized = true;

                m_BottomTime = bottomTime;
                m_TimeToFirstStop = timeToFirstStop;
                m_GasMix = gasMix;
                m_TotalAscentTime = totalAscentTime;
                m_ChamberO2Periods = chamberO2Periods;
                m_RepeatGroup = repeatGroup;
            }
        }

        public class DCompTable
        {
            int bottomDepth = -1;
            List<DCompRow> m_DComps;
            public DCompTable() {
                m_DComps = new List<DCompRow>();
            }
            public DCompTable(int bottomDepth)
            {
                this.bottomDepth = bottomDepth;
                m_DComps = new List<DCompRow>();
                initTable();
            }
            private void initTable()
            {
                switch (bottomDepth)
                {
                    case 100:
                        {
                            m_DComps.Add(new DCompRow(55, 240, GasMix.AIR, 6820, 1.5, 'Z', 65));
                            m_DComps.Add(new DCompRow(60, 240, GasMix.AIR, 8420, 1.5, 'Z', 81));
                            m_DComps.Add(new DCompRow(70, 220, GasMix.AIR, 13800, 2, 'Z', 124, 11));
                            m_DComps.Add(new DCompRow(80, 220, GasMix.AIR, 18400, 2.5, 'Z', 160, 21));
                            m_DComps.Add(new DCompRow(90, 220, GasMix.AIR, 22840, 2.5, '0', 196, 28, 2));
                        }
                        break;
                    case 90:
                        {
                            m_DComps.Add(new DCompRow(70, 220, GasMix.AIR, 8600, 1.5, 'Z', 83));
                            m_DComps.Add(new DCompRow(80, 200, GasMix.AIR, 13240, 2, 'Z', 125,5));
                        }
                        break;
                    default:
                        //not existing
                        break;
                }
            }
            public override string ToString()
            {
                return m_DComps[0].printDCompStops();
            }
        }

        void UpdateTBT()
        {
            if(hTimes.g_LS.isInitialized() && hTimes.g_LB.isInitialized())
            {
                hTimes.g_TBT = hTimes.g_LB - hTimes.g_LS;
                this.L_TBT_site.Text = hTimes.g_TBT.ToHS();
                this.TB_TBT.Text = hTimes.g_TBT.TotalMinutes().ToString();
            }
        }

        void UpdateEstRB()
        {
            if (hTimes.g_LS.isInitialized() && g_stageDepth != -1)
            {
                int min = (int)Math.Ceiling(g_stageDepth / 75.0);

                HSYS hLS = new HSYS(TB_LS.Text);

                hLS.addMin(min);

                L_EstRB.Text = hLS.ToString();
            }
            else
            {
                L_EstRB.Text = "";
            }
        }

        
        int getMaximumDepth(int estDepth)
        {
            var map = new Dictionary<int, int>();
            map.Add(200, 3);
            map.Add(100, 2);
            map.Add(0, 1);

            List<int> limits = new List<int>();
            foreach ( var pair in map)
            {
                limits.Add(pair.Key);
            }

            foreach ( var lim in limits)
            {
                if(estDepth > lim)
                {
                    return estDepth + map[lim];
                }
            }

            return -1;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.LcurTime.Text = DateTime.Now.ToString();
        }

        private void estimatedDepthTextChanged(object sender, EventArgs e)
        {
            if(((TextBox)sender).Text == "")
            {
                this.LmaxDepth.Text = "";
                this.LRecAscTime.Text = "";
                this.L_EstRB.Text = "";
                return;
            }
            int depth = Convert.ToInt32(((TextBox)sender).Text);
            g_stageDepth = depth;
            g_MaxDepth = getMaximumDepth(depth);

            this.LmaxDepth.Text = getMaximumDepth(depth).ToString();

            int RecAscTimeSeconds = depth * 2;
            int RecAscTimeMin = RecAscTimeSeconds / 60;
            while(RecAscTimeSeconds >= 60)
            {
                RecAscTimeSeconds -= 60;
            }
            string asctime;
            if (RecAscTimeMin == 0) {
                asctime = RecAscTimeSeconds.ToString() + "초";
            }
            else
            {
                asctime = RecAscTimeMin.ToString() + "분" + RecAscTimeSeconds.ToString() + "초";
            }

            UpdateEstRB();

            this.LRecAscTime.Text = asctime;


        }

        //false means for planning
        void setSiteOrPlan(bool tf)
        {
            this.TB_TBT.Enabled = !tf;
            this.L_TBT.Enabled = !tf;
            this.L_LS.Enabled = tf;
            this.L_RB.Enabled = tf;
            this.L_LB.Enabled = tf;
            this.TB_LS.Enabled = tf;
            this.TB_RB.Enabled = tf;
            this.TB_LB.Enabled = tf;
        }

        private void RB_site_CheckedChanged(object sender, EventArgs e)
        {
            setSiteOrPlan(true);
        }

        private void RB_plan_CheckedChanged(object sender, EventArgs e)
        {
            setSiteOrPlan(false);
        }

        private void TB_LS_TextChanged(object sender, EventArgs e)
        {
            if(((TextBox)sender).Text == "")
            {
                return;
            }

            hTimes.g_LS.set4digit(Convert.ToInt32(((TextBox)sender).Text));

            UpdateEstRB();
            UpdateTBT();
        }

        private void TB_LB_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                return;
            }
            hTimes.g_LB.set4digit(Convert.ToInt32(((TextBox)sender).Text));

            UpdateEstRB();
            UpdateTBT();
        }

        private void TB_RB_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                return;
            }
            hTimes.g_RB.set4digit(Convert.ToInt32(((TextBox)sender).Text));
        }

        private void TB_TBT_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                return;
            }
            hTimes.g_TBT.set4digit(Convert.ToInt32(((TextBox)sender).Text));
        }

        private void L_DCompResult_Click(object sender, EventArgs e)
        {
            DCompTable table = new DCompTable(100);
            L_DCompResult.Text = table.ToString();
        }
    }
}
