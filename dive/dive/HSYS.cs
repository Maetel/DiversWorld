using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dive
{
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
            int seconds = MMSS % 100 + min * 60;

            this.addSeconds(seconds);

        }



        public void addSeconds(int seconds)
        {
            if (seconds <= 0)
                return;
            int min = (seconds - 1) / 60;
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
            if (_4digit.Length != 4)
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

            while (this.minute < 0)
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

}
