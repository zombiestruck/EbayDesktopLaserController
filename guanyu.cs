// Decompiled with JetBrains decompiler
// Type: 微型雕刻机2.guanyu
// Assembly: 微型雕刻机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3AF547DE-808E-4700-98FB-6D70B3F08398
// Assembly location: D:\Downloads\Laser engraving machine (3).exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace 微型雕刻机2
{
  public class guanyu : Form
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

    public guanyu()
    {
      this.InitializeComponent();
    }

    private void guanyu_Load(object sender, EventArgs e)
    {
      this.linkLabel1.Links.Add(0, 4, (object) "http://blog.sina.com.cn/mcudiyck");
      this.linkLabel2.Links.Add(0, 4, (object) "https://diaokejidiy.taobao.com/");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
      this.Dispose();
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
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (guanyu));
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.linkLabel1 = new LinkLabel();
      this.linkLabel2 = new LinkLabel();
      this.button1 = new Button();
      this.SuspendLayout();
      this.panel1.BackgroundImage = (Image) componentResourceManager.GetObject("panel1.BackgroundImage");
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.Location = new Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(183, 182);
      this.panel1.TabIndex = 0;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label1.ForeColor = Color.Blue;
      this.label1.Location = new Point(212, 12);
      this.label1.Name = "label1";
      this.label1.Size = new Size(120, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "智成电子工作室";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label2.ForeColor = Color.Blue;
      this.label2.Location = new Point(212, 40);
      this.label2.Name = "label2";
      this.label2.Size = new Size(144, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "旺旺：yanyaling55";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label3.ForeColor = Color.Blue;
      this.label3.Location = new Point(212, 66);
      this.label3.Name = "label3";
      this.label3.Size = new Size(144, 16);
      this.label3.TabIndex = 3;
      this.label3.Text = "手机：18317653617";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label4.ForeColor = Color.Blue;
      this.label4.Location = new Point(212, 92);
      this.label4.Name = "label4";
      this.label4.Size = new Size(120, 16);
      this.label4.TabIndex = 4;
      this.label4.Text = "QQ：2934332198";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label5.ForeColor = Color.Blue;
      this.label5.Location = new Point(212, 118);
      this.label5.Name = "label5";
      this.label5.Size = new Size(120, 16);
      this.label5.TabIndex = 5;
      this.label5.Text = "微信：jiakuo25";
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new Point(227, 152);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(53, 12);
      this.linkLabel1.TabIndex = 7;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "我的博客";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.Location = new Point(227, 182);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new Size(53, 12);
      this.linkLabel2.TabIndex = 8;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "我的网店";
      this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
      this.button1.Location = new Point(296, 157);
      this.button1.Name = "button1";
      this.button1.Size = new Size(64, 36);
      this.button1.TabIndex = 9;
      this.button1.Text = "关闭";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(368, 206);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.linkLabel2);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.panel1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (guanyu);
      this.Text = "关于";
      this.Load += new EventHandler(this.guanyu_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
