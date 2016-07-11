namespace Mofi
{
    partial class frmMain
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctlS = new System.Windows.Forms.CheckBox();
            this.ctlA = new System.Windows.Forms.CheckBox();
            this.ctlB = new System.Windows.Forms.CheckBox();
            this.button_ResetProcess = new System.Windows.Forms.Button();
            this.comboBox_Process = new System.Windows.Forms.ComboBox();
            this.button_SelectProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctlS
            // 
            this.ctlS.AutoSize = true;
            this.ctlS.Location = new System.Drawing.Point(12, 12);
            this.ctlS.Name = "ctlS";
            this.ctlS.Size = new System.Drawing.Size(49, 19);
            this.ctlS.TabIndex = 1;
            this.ctlS.Text = "S 급";
            this.ctlS.UseVisualStyleBackColor = true;
            this.ctlS.CheckedChanged += new System.EventHandler(this.ctlS_CheckedChanged);
            // 
            // ctlA
            // 
            this.ctlA.AutoSize = true;
            this.ctlA.Location = new System.Drawing.Point(67, 12);
            this.ctlA.Name = "ctlA";
            this.ctlA.Size = new System.Drawing.Size(50, 19);
            this.ctlA.TabIndex = 2;
            this.ctlA.Text = "A 급";
            this.ctlA.UseVisualStyleBackColor = true;
            this.ctlA.CheckedChanged += new System.EventHandler(this.ctlA_CheckedChanged);
            // 
            // ctlB
            // 
            this.ctlB.AutoSize = true;
            this.ctlB.Location = new System.Drawing.Point(123, 12);
            this.ctlB.Name = "ctlB";
            this.ctlB.Size = new System.Drawing.Size(49, 19);
            this.ctlB.TabIndex = 3;
            this.ctlB.Text = "B 급";
            this.ctlB.UseVisualStyleBackColor = true;
            this.ctlB.CheckedChanged += new System.EventHandler(this.ctlB_CheckedChanged);
            // 
            // button_ResetProcess
            // 
            this.button_ResetProcess.Location = new System.Drawing.Point(93, 66);
            this.button_ResetProcess.Name = "button_ResetProcess";
            this.button_ResetProcess.Size = new System.Drawing.Size(79, 23);
            this.button_ResetProcess.TabIndex = 7;
            this.button_ResetProcess.Text = "재설정";
            this.button_ResetProcess.UseVisualStyleBackColor = true;
            // 
            // comboBox_Process
            // 
            this.comboBox_Process.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Process.FormattingEnabled = true;
            this.comboBox_Process.Location = new System.Drawing.Point(12, 37);
            this.comboBox_Process.Name = "comboBox_Process";
            this.comboBox_Process.Size = new System.Drawing.Size(160, 23);
            this.comboBox_Process.Sorted = true;
            this.comboBox_Process.TabIndex = 8;
            // 
            // button_SelectProcess
            // 
            this.button_SelectProcess.Location = new System.Drawing.Point(12, 66);
            this.button_SelectProcess.Name = "button_SelectProcess";
            this.button_SelectProcess.Size = new System.Drawing.Size(75, 23);
            this.button_SelectProcess.TabIndex = 9;
            this.button_SelectProcess.Text = "수동 설정";
            this.button_SelectProcess.UseVisualStyleBackColor = true;
            this.button_SelectProcess.Click += new System.EventHandler(this.button_SelectProcess_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 101);
            this.Controls.Add(this.button_ResetProcess);
            this.Controls.Add(this.comboBox_Process);
            this.Controls.Add(this.button_SelectProcess);
            this.Controls.Add(this.ctlB);
            this.Controls.Add(this.ctlA);
            this.Controls.Add(this.ctlS);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mofi";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ctlS;
        private System.Windows.Forms.CheckBox ctlA;
        private System.Windows.Forms.CheckBox ctlB;
        private System.Windows.Forms.Button button_ResetProcess;
        private System.Windows.Forms.ComboBox comboBox_Process;
        private System.Windows.Forms.Button button_SelectProcess;

    }
}

