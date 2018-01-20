namespace SMSBomber
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
			this.tbxPhoneNumber = new System.Windows.Forms.TextBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxCount = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblStateStr = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(33, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "手机号码：";
			// 
			// tbxPhoneNumber
			// 
			this.tbxPhoneNumber.Location = new System.Drawing.Point(104, 47);
			this.tbxPhoneNumber.Name = "tbxPhoneNumber";
			this.tbxPhoneNumber.Size = new System.Drawing.Size(153, 21);
			this.tbxPhoneNumber.TabIndex = 1;
			this.tbxPhoneNumber.Text = "15802745971";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(182, 120);
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
			this.label2.Location = new System.Drawing.Point(57, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "次数：";
			// 
			// tbxCount
			// 
			this.tbxCount.Location = new System.Drawing.Point(104, 74);
			this.tbxCount.Name = "tbxCount";
			this.tbxCount.Size = new System.Drawing.Size(153, 21);
			this.tbxCount.TabIndex = 1;
			this.tbxCount.Text = "1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(35, 188);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "状态：";
			// 
			// lblStateStr
			// 
			this.lblStateStr.AutoSize = true;
			this.lblStateStr.Location = new System.Drawing.Point(82, 188);
			this.lblStateStr.Name = "lblStateStr";
			this.lblStateStr.Size = new System.Drawing.Size(23, 12);
			this.lblStateStr.TabIndex = 4;
			this.lblStateStr.Text = "lbl";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(404, 258);
			this.Controls.Add(this.lblStateStr);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.tbxCount);
			this.Controls.Add(this.tbxPhoneNumber);
			this.Controls.Add(this.label1);
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "短信轰炸机";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbxPhoneNumber;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxCount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblStateStr;
	}
}

