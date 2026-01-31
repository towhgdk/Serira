namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxRandom = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.radioButtonRead = new System.Windows.Forms.RadioButton();
            this.radioButtonWrite = new System.Windows.Forms.RadioButton();
            this.radioall = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioManual = new System.Windows.Forms.RadioButton();
            this.buttonSaveGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "테스트 시작";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(32, 124);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "현재 속도: 0 MB/s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "테스트할 드라이브 :";
            // 
            // formsPlot1
            // 
            this.formsPlot1.DisplayScale = 0F;
            this.formsPlot1.Location = new System.Drawing.Point(274, 31);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(500, 386);
            this.formsPlot1.TabIndex = 6;
            this.formsPlot1.Load += new System.EventHandler(this.formsPlot1_Load);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(32, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 45);
            this.button2.TabIndex = 7;
            this.button2.Text = "테스트 중지!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // checkBoxRandom
            // 
            this.checkBoxRandom.AutoSize = true;
            this.checkBoxRandom.Location = new System.Drawing.Point(32, 264);
            this.checkBoxRandom.Name = "checkBoxRandom";
            this.checkBoxRandom.Size = new System.Drawing.Size(178, 16);
            this.checkBoxRandom.TabIndex = 9;
            this.checkBoxRandom.Text = "랜덤쓰기 (읽기는 영향 없음)";
            this.checkBoxRandom.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(5, 48);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Items.AddRange(new object[] {
            "GB",
            "MB"});
            this.comboBoxUnit.Location = new System.Drawing.Point(130, 48);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(71, 20);
            this.comboBoxUnit.TabIndex = 11;
            this.comboBoxUnit.SelectedIndexChanged += new System.EventHandler(this.comboBoxUnit_SelectedIndexChanged);
            // 
            // radioButtonRead
            // 
            this.radioButtonRead.AutoSize = true;
            this.radioButtonRead.Location = new System.Drawing.Point(9, 20);
            this.radioButtonRead.Name = "radioButtonRead";
            this.radioButtonRead.Size = new System.Drawing.Size(153, 16);
            this.radioButtonRead.TabIndex = 12;
            this.radioButtonRead.TabStop = true;
            this.radioButtonRead.Text = "읽기 (관리자 권한 필요)";
            this.radioButtonRead.UseVisualStyleBackColor = true;
            // 
            // radioButtonWrite
            // 
            this.radioButtonWrite.AutoSize = true;
            this.radioButtonWrite.Location = new System.Drawing.Point(9, 45);
            this.radioButtonWrite.Name = "radioButtonWrite";
            this.radioButtonWrite.Size = new System.Drawing.Size(47, 16);
            this.radioButtonWrite.TabIndex = 13;
            this.radioButtonWrite.TabStop = true;
            this.radioButtonWrite.Text = "쓰기";
            this.radioButtonWrite.UseVisualStyleBackColor = true;
            this.radioButtonWrite.CheckedChanged += new System.EventHandler(this.radioButtonWrite_CheckedChanged);
            // 
            // radioall
            // 
            this.radioall.AutoSize = true;
            this.radioall.Location = new System.Drawing.Point(126, 23);
            this.radioall.Name = "radioall";
            this.radioall.Size = new System.Drawing.Size(75, 16);
            this.radioall.TabIndex = 14;
            this.radioall.TabStop = true;
            this.radioall.Text = "전체 용량";
            this.radioall.UseVisualStyleBackColor = true;
            this.radioall.CheckedChanged += new System.EventHandler(this.radioall_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonRead);
            this.groupBox1.Controls.Add(this.radioButtonWrite);
            this.groupBox1.Location = new System.Drawing.Point(32, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 67);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "테스트 선택";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioManual);
            this.groupBox2.Controls.Add(this.radioall);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.comboBoxUnit);
            this.groupBox2.Location = new System.Drawing.Point(32, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 78);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "용량 선택";
            // 
            // radioManual
            // 
            this.radioManual.AutoSize = true;
            this.radioManual.Location = new System.Drawing.Point(6, 23);
            this.radioManual.Name = "radioManual";
            this.radioManual.Size = new System.Drawing.Size(75, 16);
            this.radioManual.TabIndex = 15;
            this.radioManual.TabStop = true;
            this.radioManual.Text = "수동 입력";
            this.radioManual.UseVisualStyleBackColor = true;
            // 
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Location = new System.Drawing.Point(274, 4);
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(142, 23);
            this.buttonSaveGraph.TabIndex = 17;
            this.buttonSaveGraph.Text = "그래프 저장 (PNG)";
            this.buttonSaveGraph.UseVisualStyleBackColor = true;
            this.buttonSaveGraph.Click += new System.EventHandler(this.buttonSaveGraph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSaveGraph);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxRandom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxRandom;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.RadioButton radioButtonRead;
        private System.Windows.Forms.RadioButton radioButtonWrite;
        private System.Windows.Forms.RadioButton radioall;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioManual;
        private System.Windows.Forms.Button buttonSaveGraph;
    }
}