namespace mbe
{
	partial class SetPTHForm
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.radioObround = new System.Windows.Forms.RadioButton();
            this.radioRectangle = new System.Windows.Forms.RadioButton();
            this.textWidth = new System.Windows.Forms.TextBox();
            this.textHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textDrill = new System.Windows.Forms.TextBox();
            this.IDOK = new System.Windows.Forms.Button();
            this.IDCANCEL = new System.Windows.Forms.Button();
            this.textSizeRange = new System.Windows.Forms.Label();
            this.textDrillRange = new System.Windows.Forms.Label();
            this.textNum = new System.Windows.Forms.TextBox();
            this.labelNum = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.listBoxMyStandard = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.checkInhibitThermalRelief = new System.Windows.Forms.CheckBox();
            this.checkNoResistMask = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioObround
            // 
            this.radioObround.AutoSize = true;
            this.radioObround.Location = new System.Drawing.Point(16, 80);
            this.radioObround.Name = "radioObround";
            this.radioObround.Size = new System.Drawing.Size(79, 16);
            this.radioObround.TabIndex = 11;
            this.radioObround.TabStop = true;
            this.radioObround.Text = "OBROUND";
            this.radioObround.UseVisualStyleBackColor = true;
            // 
            // radioRectangle
            // 
            this.radioRectangle.AutoSize = true;
            this.radioRectangle.Location = new System.Drawing.Point(16, 104);
            this.radioRectangle.Name = "radioRectangle";
            this.radioRectangle.Size = new System.Drawing.Size(90, 16);
            this.radioRectangle.TabIndex = 12;
            this.radioRectangle.TabStop = true;
            this.radioRectangle.Text = "RECTANGLE";
            this.radioRectangle.UseVisualStyleBackColor = true;
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(64, 8);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(52, 19);
            this.textWidth.TabIndex = 1;
            this.textWidth.TextChanged += new System.EventHandler(this.OnTextWidthChanged);
            // 
            // textHeight
            // 
            this.textHeight.Location = new System.Drawing.Point(64, 32);
            this.textHeight.Name = "textHeight";
            this.textHeight.Size = new System.Drawing.Size(52, 19);
            this.textHeight.TabIndex = 4;
            this.textHeight.TextChanged += new System.EventHandler(this.OnTextHeightChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "mm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "mm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Drill";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "mm";
            // 
            // textDrill
            // 
            this.textDrill.Location = new System.Drawing.Point(224, 8);
            this.textDrill.Name = "textDrill";
            this.textDrill.Size = new System.Drawing.Size(52, 19);
            this.textDrill.TabIndex = 8;
            this.textDrill.TextChanged += new System.EventHandler(this.OnTextDrillChanged);
            // 
            // IDOK
            // 
            this.IDOK.Location = new System.Drawing.Point(239, 56);
            this.IDOK.Name = "IDOK";
            this.IDOK.Size = new System.Drawing.Size(75, 23);
            this.IDOK.TabIndex = 18;
            this.IDOK.Text = "OK";
            this.IDOK.UseVisualStyleBackColor = true;
            this.IDOK.Click += new System.EventHandler(this.OnOK);
            // 
            // IDCANCEL
            // 
            this.IDCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.IDCANCEL.Location = new System.Drawing.Point(239, 88);
            this.IDCANCEL.Name = "IDCANCEL";
            this.IDCANCEL.Size = new System.Drawing.Size(75, 23);
            this.IDCANCEL.TabIndex = 19;
            this.IDCANCEL.Text = "Cancel";
            this.IDCANCEL.UseVisualStyleBackColor = true;
            // 
            // textSizeRange
            // 
            this.textSizeRange.AutoSize = true;
            this.textSizeRange.Location = new System.Drawing.Point(16, 56);
            this.textSizeRange.Name = "textSizeRange";
            this.textSizeRange.Size = new System.Drawing.Size(33, 12);
            this.textSizeRange.TabIndex = 6;
            this.textSizeRange.Text = "range";
            // 
            // textDrillRange
            // 
            this.textDrillRange.AutoSize = true;
            this.textDrillRange.Location = new System.Drawing.Point(176, 32);
            this.textDrillRange.Name = "textDrillRange";
            this.textDrillRange.Size = new System.Drawing.Size(33, 12);
            this.textDrillRange.TabIndex = 10;
            this.textDrillRange.Text = "range";
            // 
            // textNum
            // 
            this.textNum.Location = new System.Drawing.Point(128, 104);
            this.textNum.Name = "textNum";
            this.textNum.Size = new System.Drawing.Size(96, 19);
            this.textNum.TabIndex = 14;
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(120, 88);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(64, 12);
            this.labelNum.TabIndex = 13;
            this.labelNum.Text = "Pin Number";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.buttonDown);
            this.groupBox1.Controls.Add(this.buttonUp);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.listBoxMyStandard);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Location = new System.Drawing.Point(8, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 144);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "My Standard";
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDown.Location = new System.Drawing.Point(236, 112);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(70, 23);
            this.buttonDown.TabIndex = 4;
            this.buttonDown.Text = "Down";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUp.Location = new System.Drawing.Point(160, 112);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(70, 23);
            this.buttonUp.TabIndex = 3;
            this.buttonUp.Text = "Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.Location = new System.Drawing.Point(84, 112);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(70, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listBoxMyStandard
            // 
            this.listBoxMyStandard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxMyStandard.FormattingEnabled = true;
            this.listBoxMyStandard.ItemHeight = 12;
            this.listBoxMyStandard.Location = new System.Drawing.Point(8, 16);
            this.listBoxMyStandard.Name = "listBoxMyStandard";
            this.listBoxMyStandard.Size = new System.Drawing.Size(299, 88);
            this.listBoxMyStandard.TabIndex = 0;
            this.listBoxMyStandard.SelectedIndexChanged += new System.EventHandler(this.listBoxMyStandard_SelectedIndexChanged);
            this.listBoxMyStandard.DoubleClick += new System.EventHandler(this.listBoxMyStandard_DoubleClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(8, 112);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(70, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // checkInhibitThermalRelief
            // 
            this.checkInhibitThermalRelief.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkInhibitThermalRelief.AutoSize = true;
            this.checkInhibitThermalRelief.Location = new System.Drawing.Point(16, 288);
            this.checkInhibitThermalRelief.Name = "checkInhibitThermalRelief";
            this.checkInhibitThermalRelief.Size = new System.Drawing.Size(194, 16);
            this.checkInhibitThermalRelief.TabIndex = 16;
            this.checkInhibitThermalRelief.Text = "Inhibit generating a thermal relief";
            this.checkInhibitThermalRelief.UseVisualStyleBackColor = true;
            // 
            // checkNoResistMask
            // 
            this.checkNoResistMask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkNoResistMask.AutoSize = true;
            this.checkNoResistMask.Location = new System.Drawing.Point(16, 330);
            this.checkNoResistMask.Name = "checkNoResistMask";
            this.checkNoResistMask.Size = new System.Drawing.Size(106, 16);
            this.checkNoResistMask.TabIndex = 17;
            this.checkNoResistMask.Text = "No Resist mask";
            this.checkNoResistMask.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(282, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "(Termal relief is not generated on non componet PTH)";
            // 
            // SetPTHForm
            // 
            this.AcceptButton = this.IDOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.IDCANCEL;
            this.ClientSize = new System.Drawing.Size(336, 361);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkNoResistMask);
            this.Controls.Add(this.checkInhibitThermalRelief);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelNum);
            this.Controls.Add(this.textNum);
            this.Controls.Add(this.textDrillRange);
            this.Controls.Add(this.textSizeRange);
            this.Controls.Add(this.IDCANCEL);
            this.Controls.Add(this.IDOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textDrill);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textHeight);
            this.Controls.Add(this.textWidth);
            this.Controls.Add(this.radioRectangle);
            this.Controls.Add(this.radioObround);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(352, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(352, 400);
            this.Name = "SetPTHForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set PTH";
            this.Load += new System.EventHandler(this.FormLoad);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton radioObround;
		private System.Windows.Forms.RadioButton radioRectangle;
		private System.Windows.Forms.TextBox textWidth;
		private System.Windows.Forms.TextBox textHeight;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textDrill;
		private System.Windows.Forms.Button IDOK;
		private System.Windows.Forms.Button IDCANCEL;
		private System.Windows.Forms.Label textSizeRange;
		private System.Windows.Forms.Label textDrillRange;
		private System.Windows.Forms.TextBox textNum;
		private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListBox listBoxMyStandard;
        private System.Windows.Forms.CheckBox checkInhibitThermalRelief;
        private System.Windows.Forms.CheckBox checkNoResistMask;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Label label7;
    }
}