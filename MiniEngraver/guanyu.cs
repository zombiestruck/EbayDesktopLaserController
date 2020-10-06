using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MiniEngraver
{
	public class offyu : Form
	{
		private IContainer components;

		private Panel panel1;

		private Label label1;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private LinkLabel linkLabel1;

		private LinkLabel linkLabel2;

		private Button button1;

		public offyu()
		{
			InitializeComponent();
		}

		private void offyu_Load(object sender, EventArgs e)
		{
			linkLabel1.Links.Add(0, 4, "http://blog.sina.com.cn/mcudiyck");
			linkLabel2.Links.Add(0, 4, "https://engraverkejidiy.taobao.com/");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
			Dispose();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()));
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()));
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniEngraver.offyu));
			panel1 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			linkLabel2 = new System.Windows.Forms.LinkLabel();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
			panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			panel1.Location = new System.Drawing.Point(12, 12);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(183, 182);
			panel1.TabIndex = 0;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.ForeColor = System.Drawing.Color.Blue;
			label1.Location = new System.Drawing.Point(212, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(120, 16);
			label1.TabIndex = 1;
			label1.Text = "智成电子工作室";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.ForeColor = System.Drawing.Color.Blue;
			label2.Location = new System.Drawing.Point(212, 40);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(144, 16);
			label2.TabIndex = 2;
			label2.Text = "旺旺：yanyaling55";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.ForeColor = System.Drawing.Color.Blue;
			label3.Location = new System.Drawing.Point(212, 66);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(144, 16);
			label3.TabIndex = 3;
			label3.Text = "手机：18317653617";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.ForeColor = System.Drawing.Color.Blue;
			label4.Location = new System.Drawing.Point(212, 92);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(120, 16);
			label4.TabIndex = 4;
			label4.Text = "QQ：2934332198";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label5.ForeColor = System.Drawing.Color.Blue;
			label5.Location = new System.Drawing.Point(212, 118);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(120, 16);
			label5.TabIndex = 5;
			label5.Text = "微信：jiakuo25";
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(227, 152);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(53, 12);
			linkLabel1.TabIndex = 7;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "我的博客";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			linkLabel2.AutoSize = true;
			linkLabel2.Location = new System.Drawing.Point(227, 182);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(53, 12);
			linkLabel2.TabIndex = 8;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "我的网店";
			linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			button1.Location = new System.Drawing.Point(296, 157);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(64, 36);
			button1.TabIndex = 9;
			button1.Text = "关闭";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(368, 206);
			base.Controls.Add(button1);
			base.Controls.Add(linkLabel2);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(panel1);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "offyu";
			Text = "关于";
			base.Load += new System.EventHandler(offyu_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
