namespace BaiduyunCrack
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.tbxBaiduyunAddr = new System.Windows.Forms.TextBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxUltimatelyPwd = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblStartTime = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblStopTime = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblCurTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "百度云地址：";
			// 
			// tbxBaiduyunAddr
			// 
			this.tbxBaiduyunAddr.Location = new System.Drawing.Point(113, 27);
			this.tbxBaiduyunAddr.Name = "tbxBaiduyunAddr";
			this.tbxBaiduyunAddr.Size = new System.Drawing.Size(334, 21);
			this.tbxBaiduyunAddr.TabIndex = 1;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(30, 85);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 2;
			this.btnStart.Text = "开始";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 204);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "最终密码为：";
			// 
			// tbxUltimatelyPwd
			// 
			this.tbxUltimatelyPwd.Location = new System.Drawing.Point(111, 201);
			this.tbxUltimatelyPwd.Name = "tbxUltimatelyPwd";
			this.tbxUltimatelyPwd.ReadOnly = true;
			this.tbxUltimatelyPwd.Size = new System.Drawing.Size(100, 21);
			this.tbxUltimatelyPwd.TabIndex = 4;
			this.tbxUltimatelyPwd.Text = "5665";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 140);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "开始时间：";
			// 
			// lblStartTime
			// 
			this.lblStartTime.AutoSize = true;
			this.lblStartTime.Location = new System.Drawing.Point(109, 140);
			this.lblStartTime.Name = "lblStartTime";
			this.lblStartTime.Size = new System.Drawing.Size(41, 12);
			this.lblStartTime.TabIndex = 6;
			this.lblStartTime.Text = "label4";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(230, 140);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 12);
			this.label5.TabIndex = 5;
			this.label5.Text = "结束时间：";
			// 
			// lblStopTime
			// 
			this.lblStopTime.AutoSize = true;
			this.lblStopTime.Location = new System.Drawing.Point(314, 140);
			this.lblStopTime.Name = "lblStopTime";
			this.lblStopTime.Size = new System.Drawing.Size(41, 12);
			this.lblStopTime.TabIndex = 6;
			this.lblStopTime.Text = "label4";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(30, 170);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 12);
			this.label4.TabIndex = 7;
			this.label4.Text = "当前时间：";
			// 
			// lblCurTime
			// 
			this.lblCurTime.AutoSize = true;
			this.lblCurTime.Location = new System.Drawing.Point(111, 170);
			this.lblCurTime.Name = "lblCurTime";
			this.lblCurTime.Size = new System.Drawing.Size(41, 12);
			this.lblCurTime.TabIndex = 6;
			this.lblCurTime.Text = "label4";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 290);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblStopTime);
			this.Controls.Add(this.lblCurTime);
			this.Controls.Add(this.lblStartTime);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbxUltimatelyPwd);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.tbxBaiduyunAddr);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "百度云资源暴力破解";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbxBaiduyunAddr;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxUltimatelyPwd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblStartTime;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblStopTime;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblCurTime;
	}
}

