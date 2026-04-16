namespace FileCompare
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

            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lvwLeftDir = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnLeftDir = new System.Windows.Forms.Button();
            this.txtLeftDir = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCopyFromLeft = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvwRightDir = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRightDir = new System.Windows.Forms.Button();
            this.txtRightDir = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCopyFromRight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(30, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel6);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1352, 851);
            this.splitContainer1.SplitterDistance = 677;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lvwLeftDir);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 254);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(677, 597);
            this.panel6.TabIndex = 2;
            // 
            // lvwLeftDir
            // 
            this.lvwLeftDir.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwLeftDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwLeftDir.FullRowSelect = true;
            this.lvwLeftDir.GridLines = true;
            this.lvwLeftDir.HideSelection = false;
            this.lvwLeftDir.Location = new System.Drawing.Point(0, 0);
            this.lvwLeftDir.Name = "lvwLeftDir";
            this.lvwLeftDir.OwnerDraw = true;
            this.lvwLeftDir.Size = new System.Drawing.Size(677, 597);
            this.lvwLeftDir.TabIndex = 1;
            this.lvwLeftDir.UseCompatibleStateImageBehavior = false;
            this.lvwLeftDir.View = System.Windows.Forms.View.Details;
            this.lvwLeftDir.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvwLeftDir_DrawItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "이름";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "크기";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "수정일";
            this.columnHeader3.Width = 100;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnLeftDir);
            this.panel5.Controls.Add(this.txtLeftDir);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 126);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(677, 128);
            this.panel5.TabIndex = 1;
            // 
            // btnLeftDir
            // 
            this.btnLeftDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeftDir.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLeftDir.Location = new System.Drawing.Point(510, 75);
            this.btnLeftDir.Name = "btnLeftDir";
            this.btnLeftDir.Size = new System.Drawing.Size(164, 51);
            this.btnLeftDir.TabIndex = 3;
            this.btnLeftDir.Text = "폴더 선택";
            this.btnLeftDir.UseVisualStyleBackColor = true;
            this.btnLeftDir.Click += new System.EventHandler(this.btnLeftDir_Click);
            // 
            // txtLeftDir
            // 
            this.txtLeftDir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeftDir.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLeftDir.Location = new System.Drawing.Point(0, 84);
            this.txtLeftDir.Name = "txtLeftDir";
            this.txtLeftDir.Size = new System.Drawing.Size(504, 44);
            this.txtLeftDir.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCopyFromLeft);
            this.panel4.Controls.Add(this.lblAppName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(677, 126);
            this.panel4.TabIndex = 0;
            // 
            // btnCopyFromLeft
            // 
            this.btnCopyFromLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyFromLeft.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopyFromLeft.Location = new System.Drawing.Point(571, 42);
            this.btnCopyFromLeft.Name = "btnCopyFromLeft";
            this.btnCopyFromLeft.Padding = new System.Windows.Forms.Padding(5);
            this.btnCopyFromLeft.Size = new System.Drawing.Size(103, 49);
            this.btnCopyFromLeft.TabIndex = 4;
            this.btnCopyFromLeft.Text = ">>>";
            this.btnCopyFromLeft.UseVisualStyleBackColor = true;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("굴림", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAppName.Location = new System.Drawing.Point(16, 22);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Padding = new System.Windows.Forms.Padding(5);
            this.lblAppName.Size = new System.Drawing.Size(477, 79);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "File Compare";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvwRightDir);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 254);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(671, 597);
            this.panel3.TabIndex = 2;
            // 
            // lvwRightDir
            // 
            this.lvwRightDir.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvwRightDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwRightDir.FullRowSelect = true;
            this.lvwRightDir.GridLines = true;
            this.lvwRightDir.HideSelection = false;
            this.lvwRightDir.Location = new System.Drawing.Point(0, 0);
            this.lvwRightDir.Name = "lvwRightDir";
            this.lvwRightDir.Size = new System.Drawing.Size(671, 597);
            this.lvwRightDir.TabIndex = 0;
            this.lvwRightDir.UseCompatibleStateImageBehavior = false;
            this.lvwRightDir.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "이름";
            this.columnHeader4.Width = 300;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "크기";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "수정일";
            this.columnHeader6.Width = 100;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRightDir);
            this.panel2.Controls.Add(this.txtRightDir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 128);
            this.panel2.TabIndex = 1;
            // 
            // btnRightDir
            // 
            this.btnRightDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRightDir.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRightDir.Location = new System.Drawing.Point(506, 75);
            this.btnRightDir.Name = "btnRightDir";
            this.btnRightDir.Size = new System.Drawing.Size(162, 51);
            this.btnRightDir.TabIndex = 2;
            this.btnRightDir.Text = "폴더 선택";
            this.btnRightDir.UseVisualStyleBackColor = true;
            this.btnRightDir.Click += new System.EventHandler(this.btnRightDir_Click);
            // 
            // txtRightDir
            // 
            this.txtRightDir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRightDir.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRightDir.Location = new System.Drawing.Point(0, 84);
            this.txtRightDir.Name = "txtRightDir";
            this.txtRightDir.Size = new System.Drawing.Size(500, 44);
            this.txtRightDir.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCopyFromRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 126);
            this.panel1.TabIndex = 0;
            // 
            // btnCopyFromRight
            // 
            this.btnCopyFromRight.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopyFromRight.Location = new System.Drawing.Point(3, 42);
            this.btnCopyFromRight.Name = "btnCopyFromRight";
            this.btnCopyFromRight.Size = new System.Drawing.Size(103, 49);
            this.btnCopyFromRight.TabIndex = 3;
            this.btnCopyFromRight.Text = "<<<";
            this.btnCopyFromRight.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1412, 911);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnLeftDir;
        private System.Windows.Forms.TextBox txtLeftDir;
        private System.Windows.Forms.Button btnCopyFromLeft;
        private System.Windows.Forms.Button btnRightDir;
        private System.Windows.Forms.TextBox txtRightDir;
        private System.Windows.Forms.Button btnCopyFromRight;
        private System.Windows.Forms.ListView lvwRightDir;
        private System.Windows.Forms.ListView lvwLeftDir;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

