namespace dive
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hTimes = new HSYSTimes();

            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.TestimateDepth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LcurTime = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LRecAscTime = new System.Windows.Forms.Label();
            this.LmaxDepth = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RB_plan = new System.Windows.Forms.RadioButton();
            this.RB_site = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.L_TBT_site = new System.Windows.Forms.Label();
            this.L_TBT_site_ = new System.Windows.Forms.Label();
            this.L_EstRB = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.L_LB = new System.Windows.Forms.Label();
            this.TB_LB = new System.Windows.Forms.TextBox();
            this.L_RB = new System.Windows.Forms.Label();
            this.TB_RB = new System.Windows.Forms.TextBox();
            this.L_LS = new System.Windows.Forms.Label();
            this.TB_LS = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.L_TBT = new System.Windows.Forms.Label();
            this.TB_TBT = new System.Windows.Forms.TextBox();
            this.L_DcompTitle = new System.Windows.Forms.Label();
            this.L_DCompResult = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(14, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "감압 종류";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(105, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "공기/산소 감압";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "공기감압";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // TestimateDepth
            // 
            this.TestimateDepth.Location = new System.Drawing.Point(299, 239);
            this.TestimateDepth.Name = "TestimateDepth";
            this.TestimateDepth.Size = new System.Drawing.Size(100, 21);
            this.TestimateDepth.TabIndex = 2;
            this.TestimateDepth.TextChanged += new System.EventHandler(this.estimatedDepthTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "현재 시각 :";
            // 
            // LcurTime
            // 
            this.LcurTime.AutoSize = true;
            this.LcurTime.Location = new System.Drawing.Point(81, 9);
            this.LcurTime.Name = "LcurTime";
            this.LcurTime.Size = new System.Drawing.Size(34, 12);
            this.LcurTime.TabIndex = 4;
            this.LcurTime.Text = "Time";
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Interval = 1000;
            this.clockTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "입력";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "예상 깊이(ft)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Time to 1st :";
            // 
            // LRecAscTime
            // 
            this.LRecAscTime.AutoSize = true;
            this.LRecAscTime.Location = new System.Drawing.Point(300, 287);
            this.LRecAscTime.Name = "LRecAscTime";
            this.LRecAscTime.Size = new System.Drawing.Size(11, 12);
            this.LRecAscTime.TabIndex = 8;
            this.LRecAscTime.Text = "0";
            // 
            // LmaxDepth
            // 
            this.LmaxDepth.AutoSize = true;
            this.LmaxDepth.Location = new System.Drawing.Point(300, 266);
            this.LmaxDepth.Name = "LmaxDepth";
            this.LmaxDepth.Size = new System.Drawing.Size(11, 12);
            this.LmaxDepth.TabIndex = 10;
            this.LmaxDepth.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "Maximum Depth :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RB_plan);
            this.groupBox2.Controls.Add(this.RB_site);
            this.groupBox2.Location = new System.Drawing.Point(14, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 65);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "입력 종류";
            // 
            // RB_plan
            // 
            this.RB_plan.AutoSize = true;
            this.RB_plan.Location = new System.Drawing.Point(7, 44);
            this.RB_plan.Name = "RB_plan";
            this.RB_plan.Size = new System.Drawing.Size(47, 16);
            this.RB_plan.TabIndex = 1;
            this.RB_plan.Text = "계획";
            this.RB_plan.UseVisualStyleBackColor = true;
            this.RB_plan.CheckedChanged += new System.EventHandler(this.RB_plan_CheckedChanged);
            // 
            // RB_site
            // 
            this.RB_site.AutoSize = true;
            this.RB_site.Location = new System.Drawing.Point(7, 21);
            this.RB_site.Name = "RB_site";
            this.RB_site.Size = new System.Drawing.Size(47, 16);
            this.RB_site.TabIndex = 0;
            this.RB_site.Text = "현장";
            this.RB_site.UseVisualStyleBackColor = true;
            this.RB_site.CheckedChanged += new System.EventHandler(this.RB_site_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.L_TBT_site);
            this.groupBox3.Controls.Add(this.L_TBT_site_);
            this.groupBox3.Controls.Add(this.L_EstRB);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.L_LB);
            this.groupBox3.Controls.Add(this.TB_LB);
            this.groupBox3.Controls.Add(this.L_RB);
            this.groupBox3.Controls.Add(this.TB_RB);
            this.groupBox3.Controls.Add(this.L_LS);
            this.groupBox3.Controls.Add(this.TB_LS);
            this.groupBox3.Location = new System.Drawing.Point(179, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 149);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "현장";
            // 
            // L_TBT_site
            // 
            this.L_TBT_site.AutoSize = true;
            this.L_TBT_site.Location = new System.Drawing.Point(58, 128);
            this.L_TBT_site.Name = "L_TBT_site";
            this.L_TBT_site.Size = new System.Drawing.Size(29, 12);
            this.L_TBT_site.TabIndex = 20;
            this.L_TBT_site.Text = "TBT";
            // 
            // L_TBT_site_
            // 
            this.L_TBT_site_.AutoSize = true;
            this.L_TBT_site_.Location = new System.Drawing.Point(11, 128);
            this.L_TBT_site_.Name = "L_TBT_site_";
            this.L_TBT_site_.Size = new System.Drawing.Size(29, 12);
            this.L_TBT_site_.TabIndex = 19;
            this.L_TBT_site_.Text = "TBT";
            // 
            // L_EstRB
            // 
            this.L_EstRB.AutoSize = true;
            this.L_EstRB.Location = new System.Drawing.Point(61, 77);
            this.L_EstRB.Name = "L_EstRB";
            this.L_EstRB.Size = new System.Drawing.Size(0, 12);
            this.L_EstRB.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "RB예상";
            // 
            // L_LB
            // 
            this.L_LB.AutoSize = true;
            this.L_LB.Location = new System.Drawing.Point(11, 101);
            this.L_LB.Name = "L_LB";
            this.L_LB.Size = new System.Drawing.Size(20, 12);
            this.L_LB.TabIndex = 15;
            this.L_LB.Text = "LB";
            // 
            // TB_LB
            // 
            this.TB_LB.Enabled = false;
            this.TB_LB.Location = new System.Drawing.Point(59, 98);
            this.TB_LB.Name = "TB_LB";
            this.TB_LB.Size = new System.Drawing.Size(100, 21);
            this.TB_LB.TabIndex = 16;
            this.TB_LB.TextChanged += new System.EventHandler(this.TB_LB_TextChanged);
            // 
            // L_RB
            // 
            this.L_RB.AutoSize = true;
            this.L_RB.Location = new System.Drawing.Point(11, 50);
            this.L_RB.Name = "L_RB";
            this.L_RB.Size = new System.Drawing.Size(21, 12);
            this.L_RB.TabIndex = 13;
            this.L_RB.Text = "RB";
            // 
            // TB_RB
            // 
            this.TB_RB.Enabled = false;
            this.TB_RB.Location = new System.Drawing.Point(59, 47);
            this.TB_RB.Name = "TB_RB";
            this.TB_RB.Size = new System.Drawing.Size(100, 21);
            this.TB_RB.TabIndex = 14;
            this.TB_RB.TextChanged += new System.EventHandler(this.TB_RB_TextChanged);
            // 
            // L_LS
            // 
            this.L_LS.AutoSize = true;
            this.L_LS.Location = new System.Drawing.Point(11, 23);
            this.L_LS.Name = "L_LS";
            this.L_LS.Size = new System.Drawing.Size(20, 12);
            this.L_LS.TabIndex = 12;
            this.L_LS.Text = "LS";
            // 
            // TB_LS
            // 
            this.TB_LS.Enabled = false;
            this.TB_LS.Location = new System.Drawing.Point(59, 20);
            this.TB_LS.Name = "TB_LS";
            this.TB_LS.Size = new System.Drawing.Size(100, 21);
            this.TB_LS.TabIndex = 12;
            this.TB_LS.TextChanged += new System.EventHandler(this.TB_LS_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.L_TBT);
            this.groupBox4.Controls.Add(this.TB_TBT);
            this.groupBox4.Location = new System.Drawing.Point(357, 70);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(172, 136);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "계획";
            // 
            // L_TBT
            // 
            this.L_TBT.AutoSize = true;
            this.L_TBT.Location = new System.Drawing.Point(11, 23);
            this.L_TBT.Name = "L_TBT";
            this.L_TBT.Size = new System.Drawing.Size(29, 12);
            this.L_TBT.TabIndex = 12;
            this.L_TBT.Text = "TBT";
            // 
            // TB_TBT
            // 
            this.TB_TBT.Enabled = false;
            this.TB_TBT.Location = new System.Drawing.Point(59, 20);
            this.TB_TBT.Name = "TB_TBT";
            this.TB_TBT.Size = new System.Drawing.Size(100, 21);
            this.TB_TBT.TabIndex = 12;
            this.TB_TBT.TextChanged += new System.EventHandler(this.TB_TBT_TextChanged);
            // 
            // L_DcompTitle
            // 
            this.L_DcompTitle.AutoSize = true;
            this.L_DcompTitle.Location = new System.Drawing.Point(190, 307);
            this.L_DcompTitle.Name = "L_DcompTitle";
            this.L_DcompTitle.Size = new System.Drawing.Size(45, 12);
            this.L_DcompTitle.TabIndex = 18;
            this.L_DcompTitle.Text = "Dcomp";
            // 
            // L_DCompResult
            // 
            this.L_DCompResult.AutoSize = true;
            this.L_DCompResult.Location = new System.Drawing.Point(266, 307);
            this.L_DCompResult.Name = "L_DCompResult";
            this.L_DCompResult.Size = new System.Drawing.Size(40, 12);
            this.L_DCompResult.TabIndex = 19;
            this.L_DCompResult.Text = "Result";
            this.L_DCompResult.Click += new System.EventHandler(this.L_DCompResult_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.L_DCompResult);
            this.Controls.Add(this.L_DcompTitle);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LmaxDepth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LRecAscTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LcurTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TestimateDepth);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Diver\'s World";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox TestimateDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LcurTime;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LRecAscTime;
        private System.Windows.Forms.Label LmaxDepth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RB_plan;
        private System.Windows.Forms.RadioButton RB_site;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TB_LS;
        private System.Windows.Forms.Label L_LS;
        private System.Windows.Forms.Label L_LB;
        private System.Windows.Forms.TextBox TB_LB;
        private System.Windows.Forms.Label L_RB;
        private System.Windows.Forms.TextBox TB_RB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label L_TBT;
        private System.Windows.Forms.TextBox TB_TBT;
        private System.Windows.Forms.Label L_EstRB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label L_TBT_site;
        private System.Windows.Forms.Label L_TBT_site_;
        private System.Windows.Forms.Label L_DcompTitle;
        private System.Windows.Forms.Label L_DCompResult;
    }
}

