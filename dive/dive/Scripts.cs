using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dive
{
    public enum Language { KOR, ENG }

    public class Scripts
    {
        public Dictionary<string, Label> labels;
        public Dictionary<string, Button> buttons;
        public Dictionary<string, RadioButton> radioButtons;
        public Dictionary<string, TextBox> textBoxes;
        public Dictionary<string, GroupBox> groupBoxes;
        public Dictionary<string, string> alias;
        Dictionary<string, string> alias_KOR;
        Dictionary<string, string> alias_ENG;

        public Language GUI_language;

        public Scripts(Language lang) {
            labels = new Dictionary<string, Label>();
            buttons = new Dictionary<string, Button>();
            radioButtons = new Dictionary<string, RadioButton>();
            textBoxes = new Dictionary<string, TextBox>();
            groupBoxes = new Dictionary<string, GroupBox>();

            alias = new Dictionary<string, string>();
            alias_KOR = new Dictionary<string, string>();
            alias_ENG = new Dictionary<string, string>();

            this.GUI_language = lang;

            initScripts();

            setAlias();
        }

        
        public void setList(Dictionary<string, TextBox> inputBoxes)
        {
            textBoxes = inputBoxes;
        }
        private void setDictionary()
        {
            //parse raw string
            string data = this.totalScripts;
            string[] lines_w_r = data.Split('\n');
            List<string> linesL = new List<string>();
            foreach (var line in lines_w_r)
            {
                if (line == "" || line.Length <= 1)
                    continue;
                linesL.Add(line.Substring(0, line.Length - 1));
            }

            string[] lines = linesL.ToArray();

            //parse each line and put data
            foreach(var line in lines)
            {
                string[] words = line.Split('|');
                alias_KOR[words[0]] = words[1];
                alias_ENG[words[0]] = words[2];
            }
        }

        public void switchLanguage(/*Language lang*/)
        {
            switch (GUI_language)
            {
                case Language.ENG:
                    this.GUI_language = Language.KOR;
                    break;
                case Language.KOR:
                    this.GUI_language = Language.ENG;
                    break;
                default:
                    this.GUI_language = Language.KOR;
                    break;
            }

            setAlias();
        }

        private void setAlias()
        {
            switch (GUI_language)
            {
                case Language.ENG:
                    this.alias = this.alias_ENG;
                    break;
                case Language.KOR:
                    this.alias = this.alias_KOR;
                    break;
                default:
                    this.alias = this.alias_KOR;
                    break;
            }
        }

        private void initScripts() {

            setDictionary();

            alias_KOR["info"] = this.getInfo();
            alias_KOR["license"] = this.getLicense();

            //Textboxes
        }
        /*
         switch (this.language)
            {
                case Language.KOR:
                    break;
                case Language.ENG:
                    break;
                default:
                    info = "no data";
                    break;
            }
             */

        
        public string getInfo() {
            string info = "";
            switch (this.GUI_language)
            {
                case Language.KOR:
                    info =
                        @"기획 : 최율겸, Yulgyeom Choe, choy0928@naver.com
개발 : 황원준, Wonjun Hwang, iamjam4944@gmail.com

Diver's World는 현재 개발 중이며 다이버/슈퍼바이저들의 감압 테이블 작성을 도와주는 프로그램입니다.
본 프로그램은 별도의 Dependency가 없으며 .NET framwork 4.6.1버전에서 제작, 테스트, 빌드되었습니다. 본 프로그램은 오픈소스이며 소스코드는 하단의 주소에 공개되어 있습니다.
https://github.com/Maetel/DiversWorld

* 주의사항 *
본 프로그램은 美 Navy 교범을 참고하였으나 해당 기관으로부터의 보증과 해당 기관과의 이해관계가 없으며, 제작자 및 제공자는 본 프로그램의 사용에 따른 인명 및 재산 피해에 대한 어떤 법적 책임도 지지 않습니다.
마지막 업데이트 날짜 : 2019. 03. 10 (yyyy.mm.dd)";
                    break;
                case Language.ENG:
                    info =
                        @"Plan : 최율겸, Yulgyeom Choe, choy0928@naver.com
Developer : 황원준, Wonjun Hwang, iamjam4944@gmail.com

Diver's World is currently under development. Intended for helping divers to easily make Air decompression tables. Now can be used as a prototype.
Diver's world has no additional dependency except for the fact that is manufactured, built & tested under .NET framework 4.6.1., and is an open source program and can be found on the link below;
https://github.com/Maetel/DiversWorld

* Warning *
The data and the strategy used for making air decompression table we provide with are referred to U.S. Navy guide. The providers cannot accept responsibility for loss or damage and does not endorse the U.S. Navy, and is not liable for their policies nor guaranteed/verified from them.
Last update : 2019. 03. 10 (yyyy.mm.dd)";
                    break;
                default:
                    info = "no data";
                    break;
            }

            return info;
        }

        
        public string getLicense()
        {
            string license = "";
            switch (this.GUI_language)
            {
                case Language.KOR:
                    license =
                        @"본 프로그램은 Creative Commons 4.0 NC SA 라이센스로 제작되었습니다. 다음 행동들은 해당 라이센스에 동의하는 것으로 간주됩니다 : 다운로드, 설치, 복사.
자세한 내용 및 문의는 '제작 및 정보'를 참조해주세요.";
                    break;
                case Language.ENG:
                    license =
                    @"By downloading, copying, installing or using the software you agree to this license. If you do not agree to this license, do not download, install, copy or use the software.

This work is licensed under a Creative Commons Attribution-NonCommercial - ShareAlike 4.0 International License.
Please refer to INFO button above for more and contact.";
                    break;
                default:
                    license = "no data";
                    break;
            }

            return license;
        }

        //Order = KOR / ENG
        private string totalScripts =
            @"
TB_Title|감압표|Decompression Table
TB_D_Author|작성자 :|Author :
TB_D_Diver|잠수사 :|Diver :
TB_D_Write_Time|작성일시 :|Date :

LB_input|입력|Input
LB_output|출력|Output
LB_D_CurTime|현재 시각 :|Current Time:

BT_LANGUAGE|ENGLISH|한국어
BT_Initialize|초기화|Initialize
BT_Reload_Data_File|데이터 불러오기|Load Table DB
BT_Save_Capture|사진으로 저장하기|Save as Image
BT_Info|제작 및 정보|INFO
BT_License|라이센스|LICENSE

RB_GAS_AIR|수중 공기 감압|In-water Air
RB_GAS_AIRO2|수중 공기/산소 감압|In-water Air/O2
RB_GAS_SurD|표면 산소 감압|SurDO2
RB_HeO2_HeO2|수중 헬륨/산소 감압|In-water HeO2/O2
RB_HeO2_SurD|표면 감압|SurDO2

TB_D_Depth|수심|EVENT
TB_D_Dcomp_Time|감압시간|STOP TIME
TB_D_Clocktime|시각|CLOCK TIME
TB_D_Circums|상황|EVENT
TB_D_Depth_Time|수심/시간|TIME/DEPTH
TB_D_LS|해면 출발|LS or 20 fsw
TB_D_RB|해저 도착|RB
TB_D_LB|해저 출발|LB
TB_D_R1st|첫 정지점 도착|R 1st Stop
TB_D_RS|해면 도착|RS
TB_D_Desc_Time|하잠 시간 (수중)|Descent Time (Water)
TB_D_StageDepth|측정 수심 (ft)|Stage Depth (fsw)
TB_D_MaxDepth|보정 수심 (ft)|Maximum Depth (fsw)
TB_D_TBT|총 해저 체류 시간|Total Bottom Time
TB_D_DCompTable|사용 감압표 [수심, TBT]|Table/Schedule
TB_D_TB_Time_To_R1st_Actual|첫 정지점까지 상승시간 (실제)|Time to 1st Stop (Actual)
TB_D_Time_To_R1st_Planned|첫 정지점까지 상승시간 (계획)|Time to 1st Stop (Planned)
TB_D_Time_To_R1st_Delayed|첫 정지점까지 지연시간 (단위 : 초)|Delay to 1st Stop
TB_D_Travel_Shift_Vent_Time|상승/기체전환/환기 시간|Travel/Shift/Vent Time
TB_D_Ascent_Time_Water|상승시간|Ascent Time-Water/SurD (Actual)
TB_D_Undress_Time|장비 해체 시간|Undress Time-SurD (Actual)
TB_D_Desc_Chamber_SurD|챔버 정지점까지 하잠시간|Descent Chamber-SurD (Actual)
TB_D_Total_SurD_Interval|수중 40ft ~ 챔버 50ft까지의 시간|Total SurD Surface Interval
TB_D_Ascent_Time_Chamber|상승시간 (챔버 ~ 해면)|Ascent Time–Chamber (Actual)
TB_D_HoldsOnDesc|하잠 중 지연|HOLDS ON DESCENT
TB_D_Delay_Depth|수심|DEPTH
TB_D_Delay_Problem|원인|PROBLEM
TB_D_DelayOnAsc|상승 중 지연|DELAYS ON ASCENT
TB_D_Delay_Depth2|수심|DEPTH
TB_D_Delay_Problem2|원인|PROBLEM
TB_D_Decomp_proc_used|사용 감압 절차|DECOMPRESSION PROCEDURES USED
TB_D_Repeat_Group|반복그룹 기호  |REPETITIVE GROUP 
TB_D_TTD|총 감압시간|TTD
TB_D_TDT|총 잠수시간|TDT

GB_DComp_Proc_Air|공기|Air
GB_DComp_Proc_AirHe|헬륨/산소|HeO2

ST_Lang_Changed|한국어로 변경되었습니다|Changed to English
ST_Image_Saved|성공적으로 저장되었습니다|Saved as an image
ST_Data_Nested|내장데이터를 로드합니다|Using nested table data
ST_Initialized|감압표를 초기화합니다|Table initialized

WORD_No_Decomp|무감압|No decomp
WORD_No_Repeat_Group|분류 그룹 없음|No repeatitive group
WORD_No_Data|데이터 없음|No data
WORD_DComp_Table|감압표|Decomp Table
WORD_Put_Number|숫자만 입력해주세요|Put numbers only
WORD_INFO|제작 및 정보|INFO
WORD_LICENSE|라이센스|LICENSE
";
    }
    
}
