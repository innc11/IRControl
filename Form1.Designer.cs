namespace IRControl
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = new System.ComponentModel.Container();

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
			this.state = new System.Windows.Forms.CheckBox();
			this.opencloseCom = new System.Windows.Forms.Button();
			this.console = new System.Windows.Forms.TextBox();
			this.comSelect = new System.Windows.Forms.ComboBox();
			this.rulesList = new System.Windows.Forms.ListBox();
			this.IRCode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.keyCode = new System.Windows.Forms.ComboBox();
			this.addRule = new System.Windows.Forms.Button();
			this.removeRule = new System.Windows.Forms.Button();
			this.editRule = new System.Windows.Forms.Button();
			this.baudrate = new System.Windows.Forms.ComboBox();
			this.startMinimun = new System.Windows.Forms.CheckBox();
			this.startOpen = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.catchIR = new System.Windows.Forms.CheckBox();
			this.lable = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.preview = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = new System.Drawing.Icon("tubiao.ico");
			this.notifyIcon1.Text = "IR Control";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// state
			// 
			this.state.AutoSize = true;
			this.state.Location = new System.Drawing.Point(6, 274);
			this.state.Name = "state";
			this.state.Size = new System.Drawing.Size(82, 20);
			this.state.TabIndex = 13;
			this.state.Text = "模拟按键";
			this.state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.state.UseVisualStyleBackColor = true;
			// 
			// opencloseCom
			// 
			this.opencloseCom.Location = new System.Drawing.Point(254, 8);
			this.opencloseCom.Name = "opencloseCom";
			this.opencloseCom.Size = new System.Drawing.Size(56, 23);
			this.opencloseCom.TabIndex = 1;
			this.opencloseCom.Text = "打开";
			this.opencloseCom.UseVisualStyleBackColor = true;
			this.opencloseCom.Click += new System.EventHandler(this.opencloseCom_Click);
			// 
			// console
			// 
			this.console.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.console.Location = new System.Drawing.Point(210, 56);
			this.console.Multiline = true;
			this.console.Name = "console";
			this.console.ReadOnly = true;
			this.console.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.console.Size = new System.Drawing.Size(160, 185);
			this.console.TabIndex = 2;
			this.console.WordWrap = false;
			// 
			// comSelect
			// 
			this.comSelect.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.comSelect.FormattingEnabled = true;
			this.comSelect.Location = new System.Drawing.Point(44, 8);
			this.comSelect.Name = "comSelect";
			this.comSelect.Size = new System.Drawing.Size(72, 22);
			this.comSelect.TabIndex = 3;
			this.comSelect.SelectedIndexChanged += new System.EventHandler(this.comSelect_SelectedIndexChanged);
			this.comSelect.GotFocus += ComSelect_GotFocus;
			// 
			// rulesList
			// 
			this.rulesList.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rulesList.FormattingEnabled = true;
			this.rulesList.HorizontalExtent = 50;
			this.rulesList.ItemHeight = 14;
			this.rulesList.Location = new System.Drawing.Point(6, 56);
			this.rulesList.Name = "rulesList";
			this.rulesList.Size = new System.Drawing.Size(198, 214);
			this.rulesList.TabIndex = 4;
			this.rulesList.SelectedIndexChanged += new System.EventHandler(this.rulesList_SelectedIndexChanged);
			// 
			// IRCode
			// 
			this.IRCode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.IRCode.Location = new System.Drawing.Point(290, 247);
			this.IRCode.Name = "IRCode";
			this.IRCode.Size = new System.Drawing.Size(80, 22);
			this.IRCode.TabIndex = 5;
			this.IRCode.TextChanged += new System.EventHandler(this.IRCode_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(6, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "串口";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(195, 310);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "键值*";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(254, 248);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "红外";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// keyCode
			// 
			this.keyCode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.keyCode.FormattingEnabled = true;
			this.keyCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.keyCode.Location = new System.Drawing.Point(243, 307);
			this.keyCode.Name = "keyCode";
			this.keyCode.Size = new System.Drawing.Size(127, 22);
			this.keyCode.TabIndex = 10;
			// 
			// addRule
			// 
			this.addRule.Location = new System.Drawing.Point(195, 276);
			this.addRule.Name = "addRule";
			this.addRule.Size = new System.Drawing.Size(51, 23);
			this.addRule.TabIndex = 11;
			this.addRule.Text = "添加";
			this.addRule.UseVisualStyleBackColor = true;
			this.addRule.Click += new System.EventHandler(this.addRule_Click);
			// 
			// removeRule
			// 
			this.removeRule.Location = new System.Drawing.Point(136, 276);
			this.removeRule.Name = "removeRule";
			this.removeRule.Size = new System.Drawing.Size(53, 23);
			this.removeRule.TabIndex = 12;
			this.removeRule.Text = "移除";
			this.removeRule.UseVisualStyleBackColor = true;
			this.removeRule.Click += new System.EventHandler(this.removeRule_Click);
			// 
			// editRule
			// 
			this.editRule.Location = new System.Drawing.Point(136, 306);
			this.editRule.Name = "editRule";
			this.editRule.Size = new System.Drawing.Size(53, 23);
			this.editRule.TabIndex = 14;
			this.editRule.Text = "编辑";
			this.editRule.UseVisualStyleBackColor = true;
			this.editRule.Click += new System.EventHandler(this.editRule_Click);
			// 
			// baudrate
			// 
			this.baudrate.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
			this.baudrate.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.baudrate.FormattingEnabled = true;
			this.baudrate.Items.AddRange(new object[] {
            "9600",
            "74880",
            "115200"});
			this.baudrate.Location = new System.Drawing.Point(172, 8);
			this.baudrate.Name = "baudrate";
			this.baudrate.Size = new System.Drawing.Size(74, 22);
			this.baudrate.TabIndex = 15;
			// 
			// startMinimun
			// 
			this.startMinimun.AutoSize = true;
			this.startMinimun.Location = new System.Drawing.Point(6, 310);
			this.startMinimun.Name = "startMinimun";
			this.startMinimun.Size = new System.Drawing.Size(110, 20);
			this.startMinimun.TabIndex = 16;
			this.startMinimun.Text = "启动后最小化";
			this.startMinimun.UseVisualStyleBackColor = true;
			// 
			// startOpen
			// 
			this.startOpen.AutoSize = true;
			this.startOpen.Location = new System.Drawing.Point(6, 292);
			this.startOpen.Name = "startOpen";
			this.startOpen.Size = new System.Drawing.Size(124, 20);
			this.startOpen.TabIndex = 17;
			this.startOpen.Text = "启动后打开串口";
			this.startOpen.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label4.Location = new System.Drawing.Point(122, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 18;
			this.label4.Text = "波特率";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 16);
			this.label5.TabIndex = 20;
			this.label5.Text = "规则列表";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(314, 36);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 21;
			this.label6.Text = "清空Log";
			this.label6.Click += new System.EventHandler(this.label6_Click);
			// 
			// catchIR
			// 
			this.catchIR.AutoSize = true;
			this.catchIR.Location = new System.Drawing.Point(316, 10);
			this.catchIR.Name = "catchIR";
			this.catchIR.Size = new System.Drawing.Size(54, 20);
			this.catchIR.TabIndex = 22;
			this.catchIR.Text = "捕捉";
			this.catchIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.catchIR.UseVisualStyleBackColor = true;
			// 
			// lable
			// 
			this.lable.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lable.Location = new System.Drawing.Point(290, 278);
			this.lable.Name = "lable";
			this.lable.Size = new System.Drawing.Size(80, 22);
			this.lable.TabIndex = 23;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label7.Location = new System.Drawing.Point(254, 279);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 17);
			this.label7.TabIndex = 24;
			this.label7.Text = "标签";
			// 
			// preview
			// 
			this.preview.AutoSize = true;
			this.preview.Location = new System.Drawing.Point(68, 36);
			this.preview.Name = "preview";
			this.preview.Size = new System.Drawing.Size(56, 16);
			this.preview.TabIndex = 25;
			this.preview.Text = "Preview";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(374, 333);
			this.Controls.Add(this.preview);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.lable);
			this.Controls.Add(this.catchIR);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.startOpen);
			this.Controls.Add(this.startMinimun);
			this.Controls.Add(this.baudrate);
			this.Controls.Add(this.editRule);
			this.Controls.Add(this.state);
			this.Controls.Add(this.removeRule);
			this.Controls.Add(this.addRule);
			this.Controls.Add(this.keyCode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.IRCode);
			this.Controls.Add(this.rulesList);
			this.Controls.Add(this.comSelect);
			this.Controls.Add(this.console);
			this.Controls.Add(this.opencloseCom);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Deactivate += Form1_Deactivate;
		}

		#endregion
		private System.Windows.Forms.Button opencloseCom;
		private System.Windows.Forms.TextBox console;
		private System.Windows.Forms.ComboBox comSelect;
		private System.Windows.Forms.ListBox rulesList;
		private System.Windows.Forms.TextBox IRCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox keyCode;
		private System.Windows.Forms.Button addRule;
		private System.Windows.Forms.Button removeRule;
		private System.Windows.Forms.Button editRule;
		private System.Windows.Forms.CheckBox state;
		private System.Windows.Forms.ComboBox baudrate;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.CheckBox startMinimun;
		private System.Windows.Forms.CheckBox startOpen;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox catchIR;
		private System.Windows.Forms.TextBox lable;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label preview;
	}
}