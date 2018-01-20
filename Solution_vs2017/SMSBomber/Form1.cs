using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSBomber
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			string phoneNumber = tbxPhoneNumber.Text;
			if (phoneNumber.IsNullOrWhiteSpace())
			{
				tbxPhoneNumber.Text = "";
				MessageBox.Show("请填写手机号！");
				tbxPhoneNumber.Focus();
				return;
			}
			string countStr = tbxCount.Text;
			if (countStr.IsNullOrWhiteSpace())
			{
				tbxCount.Text = "";
				MessageBox.Show("请填写次数！");
				tbxCount.Focus();
				return;
			}

		}
	}
}
