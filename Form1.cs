// Decompiled with JetBrains decompiler
// Type: 微型雕刻机2.Form1
// Assembly: 微型雕刻机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3AF547DE-808E-4700-98FB-6D70B3F08398
// Assembly location: D:\Downloads\Laser engraving machine (3).exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace 微型雕刻机2
{
  public class Form1 : Form
  {
    private int[] zysx = new int[4];
    private Point[] zhixian = new Point[0];
    private string wenben = "";
    private int[] hua_kg = new int[2];
    private string wen_jian_ming = "";
    private Point wz_weizhi = new Point(0, 0);
    private bool wzms = true;
    private bool diyi = true;
    private int[] bj = new int[4];
    private int[] bj2 = new int[4];
    private Bitmap biao_shi_k = new Bitmap(1, 1);
    private Bitmap biao_shi_g = new Bitmap(1, 1);
    private Bitmap tu_pian2 = new Bitmap(1, 1);
    private bool mm_in = true;
    private string str1 = "Scaling";
    private string str2 = "Attach device";
    private string str3 = "Disconnect device";
    private string str4 = "Import pictures";
    private string str5 = "Input text";
    private string str6 = "Enter key";
    private string str7 = "Start";
    private string str8 = "Pause";
    private string str9 = "Continue";
    private string str10 = "Stop";
    private string str11 = "Choose engraving model";
    private string str12 = "Black and white";
    private string str13 = "Discrete engraving";
    private string str14 = "Gray scale";
    private string str15 = "Picture adjustment";
    private string str16 = "Depth adjustment of engraving";
    private string str17 = "Depth of caving";
    private string str18 = "Laser positioning";
    private string str19 = "Back to center";
    private string str20 = "Frame positioning";
    private string str21 = "Back to starting point";
    private string str22 = "Device has been disconnected! ";
    private string str23 = "Please connect device first! ";
    private string str24 = "Please input picture or words first! ";
    private string str25 = "Being engraved! ";
    private string str26 = "Engraving completed!";
    private string str27 = "Failto connect device,please check if USB is attatched and driver is properly installed. ";
    private string str28 = "Laser engraving machine";
    private string str29 = "Please no longer input words. ";
    private string str30 = "Receive error! ";
    private string str31 = "Time cost:";
    private string str32 = "Minutes";
    private string str33 = "Seconds";
    private string str34 = "Pictures";
    private string str35 = "Please stop frame positoning!";
    private string str36 = "Enlarge";
    private string str37 = "Laser power adjustment";
    private string str38 = "Please input the correct number";
    private string str39 = "Save success";
    private string str40 = "Contrast ratio";
    private string str42 = "Left and right mirrors";
    private string str43 = "Upper and lower mirrors";
    private string str44 = "Rotate";
    private string str45 = "Flipping";
    private string str46 = "Delete";
    private string str47 = "Typeface";
    private string str48 = "Locate to image center";
    private string str49 = "Fan";
    private string str50 = "Save the picture";
    private string str51 = "Drag to change the size";
    private string str52 = "Drag to change location";
    private string str53 = "Save failed";
    private string str54 = "Width";
    private string str55 = "Height";
    private diao_ke_ji diao;
    public int dx;
    public int dy;
    private int zhuang_tai;
    public int x;
    public int y;
    private int wei_zhi;
    private bool hua2;
    private bool anxia;
    private bool anxia2;
    private bool ting_zhi;
    private bool ca;
    private bool g_daima;
    private int suofang;
    public Form guan;
    private Bitmap tu;
    private bool fan_se;
    private int wen_zi_x;
    private int wen_zi_y;
    private Font ziti;
    private bool anxia3;
    private bool kuang;
    private int shu_x;
    private int shu_y;
    public int hua_kuan;
    public int hua_gao;
    private bool fen;
    private bool kai_shi;
    private bool gai_bian;
    private bool feng_shang;
    private bool zan_ting;
    private bool zan_ting2;
    private bool an_xia;
    private Point yi_dian;
    private bool bjk_anxia;
    private int bjk_x;
    private int bjk_y;
    private Bitmap w_z;
    private int hei_dian_shu;
    private int miao60;
    private double kg_bi;
    private double bai_bian_k;
    private double bai_bian_g;
    private bool zhong_xin;
    private bool cuo_wu;
    private bool cuo_wu2;
    private int fanhui_shu;
    private int shi_jian;
    private int gong_lv;
    private bool jk;
    private int shubiao_x;
    private int shubiao_y;
    private int miao;
    private bool z_anxia;
    private int z_x;
    private int z_y;
    private IContainer components;
    private Panel panel1;
    private Button button1;
    private CheckBox checkBox1;
    private Button button2;
    private Button button3;
    private Button button6;
    private Button button7;
    private Button button8;
    private Button button4;
    private Button button5;
    private SerialPort com;
    private OpenFileDialog dakai;
    private OpenFileDialog da_kai_g;
    private FontDialog fontDialog1;
    private Panel panel2;
    private Button button17;
    private ProgressBar jdt;
    private Button button18;
    private Button button19;
    private Button button20;
    private Button button21;
    private Button button22;
    private Button button23;
    private TrackBar trackBar3;
    private Button button24;
    private Button button25;
    private Button button15;
    private Label label3;
    private Label label5;
    private Label label4;
    private Button button16;
    private Panel panel3;
    private Label label6;
    private Button button27;
    private Button button10;
    private Button button9;
    private TextBox textBox2;
    private TrackBar trackBar2;
    private Label label2;
    private RadioButton hei_bai;
    private RadioButton li_san;
    private RadioButton hui_du;
    private TextBox textBox3;
    private TrackBar trackBar1;
    private Label label1;
    private TextBox textBox1;
    private TrackBar trackBar4;
    private TextBox textBox5;
    private CheckBox checkBox2;
    private Button button11;
    private Button button12;
    private Button button13;
    private Button button14;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private TextBox textBox4;
    private Button button26;
    private System.Windows.Forms.Timer timer1;
    private Button button28;
    private Label label7;
    private Button button29;
    private Button button30;
    private Button button31;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Button button32;
    private System.Windows.Forms.Timer timer2;
    private Label label12;
    private System.Windows.Forms.Timer timer3;
    private Label label13;
    private GroupBox groupBox4;
    private Button button36;
    private Button button35;
    private Panel panel6;
    private Label label17;
    private Label label16;
    private RadioButton radioButton4;
    private RadioButton radioButton3;
    private RadioButton radioButton2;
    private RadioButton radioButton5;
    private ListBox listBox1;
    private TrackBar trackBar5;
    private TextBox textBox8;
    private TextBox textBox7;
    private Label label21;
    private Label label20;
    private Label label19;
    private Label label18;
    private GroupBox groupBox5;
    private ToolTip toolTip1;
    private Panel panel4;
    private Panel panel5;
    private Button button33;
    private Button button34;

    private void shu_xin()
    {
      if (this.an_xia)
        return;
      this.quan_bu_shua_xin();
    }

    private void shuxin()
    {
      this.BeginInvoke((Delegate) new Form1.MyInvoke(this.shu_xin));
    }

    public Form1()
    {
      this.InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.button1.Text == this.str2)
      {
        if (this.diao.lian_jie())
        {
          this.timer2.Enabled = true;
          this.panel3.Visible = true;
          this.button1.Text = this.str3;
          this.panel2.Refresh();
          this.diao.x = 0;
          this.diao.y = 0;
          this.dx = 0;
          this.dy = 0;
          this.x = 0;
          this.y = 0;
          this.diao.dao_yuandian();
          this.panel1.Location = new Point(25, 60);
          this.x = 0;
          this.y = 0;
        }
        else
        {
          int num = (int) MessageBox.Show(this.str27);
        }
      }
      else
      {
        if (this.checkBox2.Checked)
          this.diao.guan_kuang();
        if (this.kai_shi)
        {
          this.button29_MouseDown((object) null, (MouseEventArgs) null);
          Thread.Sleep(100);
          diao_ke_ji.处理事件();
          Thread.Sleep(100);
          diao_ke_ji.处理事件();
          this.button24_Click((object) null, (EventArgs) null);
          Thread.Sleep(100);
          diao_ke_ji.处理事件();
          Thread.Sleep(100);
          diao_ke_ji.处理事件();
          this.panel1.Location = new Point(525, 560);
          this.pan_yidong();
        }
        this.panel1.Location = new Point(525, 560);
        this.pan_yidong();
        this.timer2.Enabled = false;
        this.com.Close();
        this.diao.lianjie = false;
        this.panel3.Visible = false;
        this.button1.Text = this.str2;
        this.panel2.Refresh();
      }
    }

    private void suo_fang2(Bitmap bb2, int da)
    {
      if (bb2.Width > bb2.Height)
      {
        int newW = bb2.Width + (this.trackBar3.Value - 1600);
        if (newW < 10)
          newW = 10;
        if (newW > da)
          newW = da;
        double num = (double) bb2.Width * 1.0 / (double) newW;
        int newH = (int) ((double) bb2.Height / num);
        this.diao.tu = tu_xiang.suofang(bb2, newW, newH);
      }
      else
      {
        int newH = bb2.Height + (this.trackBar3.Value - 1600);
        if (newH < 10)
          newH = 10;
        if (newH > da)
          newH = da;
        double num = (double) bb2.Height * 1.0 / (double) newH;
        int newW = (int) ((double) bb2.Width / num);
        this.diao.tu = tu_xiang.suofang(bb2, newW, newH);
      }
    }

    private void suo_fang(Bitmap bb2)
    {
      if (bb2 == null)
        return;
      if (this.textBox7.Text != "" && this.textBox8.Text != "")
      {
        int num1;
        if (this.mm_in)
        {
          num1 = (int) (Convert.ToDouble(this.textBox7.Text) / 0.05);
          double num2 = Convert.ToDouble(this.textBox8.Text) / 0.05;
        }
        else
        {
          num1 = (int) (Convert.ToDouble(this.textBox7.Text) / 0.001968505);
          double num2 = Convert.ToDouble(this.textBox8.Text) / 0.001968505;
        }
        int num3 = this.bj2[1] - this.bj2[0];
        int num4 = this.bj2[3];
        int num5 = this.bj2[2];
        double num6 = (double) num1 / (double) num3;
        this.diao.tu = tu_xiang.suofang(bb2, (int) ((double) bb2.Width * num6), (int) ((double) bb2.Height * num6));
      }
      if (this.hei_bai.Checked)
      {
        this.diao.tu_pian = this.diao.hei_bai(this.trackBar2.Value);
        if (!this.fan_se)
          return;
        this.diao.tu_pian = tu_xiang.fanse(this.diao.tu_pian);
      }
      else if (this.li_san.Checked)
      {
        this.diao.tu_pian = this.diao.dou_dong(this.trackBar2.Value);
        if (!this.fan_se)
          return;
        this.diao.tu_pian = tu_xiang.fanse(this.diao.tu_pian);
      }
      else
      {
        this.diao.tu_pian = this.diao.hui_du(this.trackBar2.Value);
        if (!this.fan_se)
          return;
        this.diao.tu_pian = tu_xiang.fanse_huidu(this.diao.tu_pian);
      }
    }

    private void da_kai()
    {
      Bitmap bitmap = new Bitmap(this.wen_jian_ming);
      this.tu = new Bitmap((Image) bitmap);
      bitmap.Dispose();
      this.diao.tu = this.tu;
      this.trackBar2.Value = 128;
      this.trackBar3.Value = this.trackBar3.Maximum / 2 + 10;
      if (this.hei_bai.Checked)
      {
        this.diao.tu_pian = this.diao.hei_bai(this.trackBar2.Value);
        if (this.fan_se)
          this.diao.tu_pian = tu_xiang.fanse(this.diao.tu_pian);
      }
      else if (this.li_san.Checked)
      {
        this.diao.tu_pian = this.diao.dou_dong(this.trackBar2.Value);
        if (this.fan_se)
          this.diao.tu_pian = tu_xiang.fanse(this.diao.tu_pian);
      }
      else
        this.diao.tu_pian = this.diao.hui_du(this.trackBar2.Value);
      this.bj2 = tu_xiang.qu_bian_jie2(this.diao.tu_pian);
      this.bj[0] = this.bj2[0];
      this.bj[1] = this.bj2[1];
      this.bj[2] = this.bj2[2];
      this.bj[3] = this.bj2[3];
      this.bai_bian_k = (double) (this.bj[1] - this.bj[0]) / (double) this.diao.tu_pian.Width;
      this.bai_bian_g = (double) (this.bj[3] - this.bj[2]) / (double) this.diao.tu_pian.Height;
      if (this.tu.Width > 1600 || this.tu.Height > 1520)
        this.tu = this.tu.Width - 1600 <= this.tu.Height - 1520 ? tu_xiang.suofang(this.tu, (int) ((double) this.tu.Width / ((double) this.tu.Height / 1520.0)), 1520) : tu_xiang.suofang(this.tu, 1600, (int) ((double) this.tu.Height / ((double) this.tu.Width / 1600.0)));
      this.panel1.Location = new Point(25 + (int) (500.0 - (double) this.diao.tu_pian.Width * (5.0 / 16.0)) / 2, 60 + (int) (500.0 - (double) this.diao.tu_pian.Height * (5.0 / 16.0)) / 2);
      this.diyi = true;
      this.kg_bi = (double) (this.bj[1] - this.bj[0]) / (double) (this.bj[3] - this.bj[2]);
      if (this.mm_in)
      {
        this.textBox7.Text = ((int) ((double) (this.bj[1] - this.bj[0]) * 0.05)).ToString();
        this.textBox8.Text = ((int) ((double) (this.bj[3] - this.bj[2]) * 0.05)).ToString();
      }
      else
      {
        this.textBox7.Text = ((double) (this.bj[1] - this.bj[0]) * 0.05 * 0.0393701).ToString().Substring(0, 5);
        this.textBox8.Text = ((double) (this.bj[3] - this.bj[2]) * 0.05 * 0.0393701).ToString().Substring(0, 5);
      }
      this.diyi = false;
      this.hua_biao_shi();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      if (this.textBox2.Visible)
      {
        this.textBox2.Visible = false;
        this.button9.Visible = false;
      }
      if (this.dakai.ShowDialog() != DialogResult.OK)
        return;
      this.wzms = false;
      this.wen_jian_ming = this.dakai.FileName;
      this.da_kai();
      this.gai_bian = true;
      this.shu_xin();
      this.pan_yidong();
    }

    private void hua_wen_zi()
    {
      float num = (float) this.panel1.Width * 3.2f / (float) this.tu.Width;
      Bitmap bitmap = new Bitmap((int) ((double) this.w_z.Width / (double) num), (int) ((double) this.w_z.Height / (double) num));
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.DrawImage((Image) this.w_z, 0.0f, 0.0f, (float) this.w_z.Width / num, (float) this.w_z.Height / num);
      graphics.Dispose();
      for (int x = 0; x < bitmap.Width; ++x)
      {
        for (int y = 0; y < bitmap.Height; ++y)
        {
          if (bitmap.GetPixel(x, y).B < (byte) 1 && (int) ((double) this.wz_weizhi.X / (double) num + (double) x) < this.tu.Width && ((int) ((double) this.wz_weizhi.Y / (double) num + (double) y) < this.tu.Height && (int) ((double) this.wz_weizhi.X / (double) num + (double) x) > 0) && (int) ((double) this.wz_weizhi.Y / (double) num + (double) y) > 0)
            this.tu.SetPixel((int) ((double) this.wz_weizhi.X / (double) num + (double) x), (int) ((double) this.wz_weizhi.Y / (double) num + (double) y), Color.Black);
        }
      }
      this.w_z = (Bitmap) null;
    }

    private void quan_bu_shua_xin()
    {
      if (this.tu == null && !(this.textBox2.Text != ""))
        return;
      if (!this.kai_shi && this.gai_bian)
      {
        if (this.w_z != null)
        {
          if (this.wzms)
          {
            this.bj = tu_xiang.qu_bian_jie2(this.w_z);
            this.tu = new Bitmap(this.w_z.Width, this.w_z.Height);
            Graphics graphics = Graphics.FromImage((Image) this.tu);
            graphics.DrawImage((Image) this.w_z, 0, 0, this.w_z.Width, this.w_z.Height);
            graphics.Dispose();
            this.bj2 = tu_xiang.qu_bian_jie2(this.tu);
            this.bj[0] = this.bj2[0];
            this.bj[1] = this.bj2[1];
            this.bj[2] = this.bj2[2];
            this.bj[3] = this.bj2[3];
            this.bai_bian_k = (double) (this.bj[1] - this.bj[0]) / (double) this.tu.Width;
            this.bai_bian_g = (double) (this.bj[3] - this.bj[2]) / (double) this.tu.Height;
            this.diyi = true;
            this.kg_bi = (double) (this.bj[1] - this.bj[0]) / (double) (this.bj[3] - this.bj[2]);
            if (this.mm_in)
            {
              this.textBox7.Text = ((int) ((double) this.tu.Width * 0.05)).ToString();
              this.textBox8.Text = ((int) ((double) this.tu.Height * 0.05)).ToString();
            }
            else
            {
              this.textBox7.Text = ((int) ((double) this.tu.Width * 0.05 * 0.0393701)).ToString().Substring(0, 5);
              this.textBox8.Text = ((int) ((double) this.tu.Height * 0.05 * 0.0393701)).ToString().Substring(0, 5);
            }
            this.diyi = false;
            this.xianzhi();
            this.w_z = (Bitmap) null;
          }
          else
            this.hua_wen_zi();
        }
        if (this.tu != null)
        {
          this.suo_fang(this.tu);
          this.xianzhi();
        }
        this.gai_bian = false;
      }
      this.bj = tu_xiang.qu_bian_jie2(this.diao.tu_pian);
      if (this.diao.tu_pian == null)
        return;
      if (this.checkBox2.Checked)
      {
        Bitmap bb2 = new Bitmap((Image) this.diao.tu_pian);
        Graphics graphics = Graphics.FromImage((Image) bb2);
        graphics.DrawRectangle(new Pen(Color.Red, 3f), this.bj[0] - 2, this.bj[2] - 2, this.bj[1] - this.bj[0] + 4, this.bj[3] - this.bj[2] + 4);
        graphics.Dispose();
        tu_kuan_gao tuKuanGao = tu_xiang.shua_xin(this.panel1, bb2, 0, 0, bb2.Width, bb2.Height, this.hui_du.Checked);
        this.diao.tu_pian = tuKuanGao.bb;
        this.hua_kg = new int[2]{ tuKuanGao.k, tuKuanGao.g };
      }
      else
      {
        Graphics graphics = Graphics.FromImage((Image) new Bitmap((Image) this.diao.tu_pian));
        graphics.DrawRectangle(new Pen(Color.White, 3f), this.bj[0] - 2, this.bj[2] - 2, this.bj[1] - this.bj[0] + 4, this.bj[3] - this.bj[2] + 4);
        graphics.Dispose();
        tu_kuan_gao tuKuanGao = tu_xiang.shua_xin(this.panel1, this.diao.tu_pian, 0, 0, this.diao.tu_pian.Width, this.diao.tu_pian.Height, this.hui_du.Checked);
        this.diao.tu_pian = tuKuanGao.bb;
        this.hua_kg = new int[2]{ tuKuanGao.k, tuKuanGao.g };
      }
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
      this.quan_bu_shua_xin();
    }

    private void yu_yan()
    {
      this.button1.Text = this.str2;
      this.label3.Text = this.str1;
      this.Text = this.str28;
      this.button2.Text = this.str4;
      this.button5.Text = this.str5;
      this.button4.Text = this.str7;
      this.button29.Text = this.str8;
      this.button24.Text = this.str10;
      this.groupBox1.Text = this.str11;
      this.groupBox2.Text = this.str16;
      this.groupBox3.Text = this.str18;
      this.hei_bai.Text = this.str12;
      this.li_san.Text = this.str13;
      this.hui_du.Text = this.str14;
      this.label2.Text = this.str15;
      this.label1.Text = this.str17;
      this.label18.Text = this.str54;
      this.label19.Text = this.str55;
      this.button28.Text = this.str20;
      this.button30.Text = this.str19;
      this.button26.Text = this.str21;
      this.dakai.Filter = this.str34 + "|*.bmp;*.jpg;*.jpge;*.png";
      this.label13.Text = this.str36;
      this.groupBox4.Text = this.str37;
      this.groupBox5.Text = this.str40;
      TrackBar trackBar3_1 = this.trackBar3;
      Point location1 = this.label3.Location;
      int x1 = location1.X + this.label3.Width;
      location1 = this.trackBar3.Location;
      int y = location1.Y;
      Point point = new Point(x1, y);
      trackBar3_1.Location = point;
      TrackBar trackBar3_2 = this.trackBar3;
      Point location2 = this.label13.Location;
      int x2 = location2.X;
      location2 = this.label3.Location;
      int num1 = location2.X + this.label3.Width;
      int num2 = x2 - num1;
      trackBar3_2.Width = num2;
      this.toolTip1.SetToolTip((Control) this.button21, this.str42);
      this.toolTip1.SetToolTip((Control) this.button22, this.str43);
      this.toolTip1.SetToolTip((Control) this.button25, this.str44);
      this.toolTip1.SetToolTip((Control) this.button20, this.str45);
      this.toolTip1.SetToolTip((Control) this.button15, this.str46);
      this.toolTip1.SetToolTip((Control) this.button32, this.str47);
      this.toolTip1.SetToolTip((Control) this.button35, this.str48);
      this.toolTip1.SetToolTip((Control) this.button27, this.str49);
      this.toolTip1.SetToolTip((Control) this.button36, this.str50);
      this.toolTip1.SetToolTip((Control) this.button9, this.str51);
      this.toolTip1.SetToolTip((Control) this.panel1, this.str52);
      if (this.str1 == "Scaling")
      {
        this.hei_bai.Location = new Point(6, 24);
        this.hui_du.Location = new Point(129, 24);
        this.li_san.Location = new Point(6, 43);
      }
      else if (this.str1 == "縮小")
      {
        this.hei_bai.Location = new Point(6, 24);
        this.hui_du.Location = new Point(124, 24);
        this.li_san.Location = new Point(79, 24);
      }
      else
      {
        this.hei_bai.Location = new Point(6, 24);
        this.hui_du.Location = new Point(156, 24);
        this.li_san.Location = new Point(79, 24);
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.diao = new diao_ke_ji(this.com);
      this.panel1.Width = 20;
      this.panel1.Height = 20;
      this.diao.lian_jie();
      this.com.Close();
      this.diao.lianjie = false;
      this.panel3.Visible = false;
      this.button1.Text = this.str2;
      this.yu_yan();
      this.panel2.Refresh();
      FontFamily[] families = new InstalledFontCollection().Families;
      for (int length = families.Length; length > 0; --length)
        this.listBox1.Items.Add((object) families[length - 1].Name);
      this.listBox1.SelectedIndex = 0;
    }

    private void trackBar2_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.kai_shi)
        return;
      this.gai_bian = true;
      this.shu_xin();
      this.textBox3.Text = this.trackBar2.Value.ToString();
    }

    private void huaxian(Point[] zhixian)
    {
      Graphics graphics = Graphics.FromImage((Image) this.diao.tu_pian);
      Point point = new Point();
      bool flag = false;
      for (int index = 0; index < zhixian.Length; ++index)
      {
        if (zhixian[index].X == 600 || zhixian[index].X == 601)
        {
          if (zhixian[index].X == 600)
            flag = true;
          if (zhixian[index].X == 601)
            flag = false;
        }
        else
        {
          if (flag)
            graphics.DrawLine(Pens.Blue, new Point(point.X, 500 - point.Y), new Point(zhixian[index].X, 500 - zhixian[index].Y));
          point = zhixian[index];
        }
      }
    }

    private void diaokexian(Point[] zhixian)
    {
      Graphics graphics = Graphics.FromImage((Image) this.diao.tu_pian);
      Point point = new Point();
      this.diao.guan_ruo_guang();
      bool flag = this.hua2;
      if (flag)
      {
        point = new Point(zhixian[this.wei_zhi].X + this.dx, zhixian[this.wei_zhi].Y + this.dy);
        this.diao.gai_bian_F(0);
        this.diao.kai_deng();
        this.diao.gai_bian_F(this.trackBar1.Value);
      }
      else
        this.diao.gai_bian_F(0);
      for (int weiZhi = this.wei_zhi; weiZhi < zhixian.Length; ++weiZhi)
      {
        if (zhixian[weiZhi].X == 600 || zhixian[weiZhi].X == 601)
        {
          if (zhixian[weiZhi].X == 600)
          {
            flag = true;
            this.diao.kai_deng();
            this.diao.gai_bian_F(this.trackBar1.Value);
          }
          if (zhixian[weiZhi].X == 601)
          {
            flag = false;
            this.diao.guan_deng();
            this.diao.gai_bian_F(0);
          }
        }
        else
        {
          if (flag)
            graphics.DrawLine(Pens.Red, new Point(point.X, 500 - point.Y), new Point(zhixian[weiZhi].X, 500 - zhixian[weiZhi].Y));
          point = zhixian[weiZhi];
        }
      }
      this.button4.Refresh();
    }

    private void jie()
    {
      this.zhixian = g_dai_ma.jie_xi(this.wenben);
      this.huaxian(this.zhixian);
      this.shuxin();
    }

    private void button6_Click(object sender, EventArgs e)
    {
      if (this.textBox2.Visible || this.da_kai_g.ShowDialog() != DialogResult.OK)
        return;
      Graphics graphics = Graphics.FromImage((Image) this.diao.tu_pian);
      graphics.Clear(Color.White);
      graphics.Dispose();
      this.zhuang_tai = 2;
      this.textBox1.Text = "10";
      this.trackBar1.Maximum = 35;
      this.trackBar1.Value = 12;
      this.textBox1.Text = "12";
      this.dx = 0;
      this.dy = 0;
      this.wenben = File.ReadAllText(this.da_kai_g.FileName);
      new Thread(new ThreadStart(this.jie)).Start();
    }

    public bool diaoke2()
    {
      if (this.li_san.Checked)
        this.diao.li_san_mo_shi();
      else
        this.diao.fei_li_san_mo_shi();
      this.diao.fu_wei();
      this.diao.kai_feng();
      this.fen = true;
      this.diao.kai_shi((int) ((double) (this.panel1.Location.X - 25) * 3.2), (int) ((double) (this.panel1.Location.Y - 60) * 3.2));
      byte[] buffer1 = this.diao.tu_pian.Width % 8 <= 0 ? new byte[this.diao.tu_pian.Width / 8 + 9] : new byte[this.diao.tu_pian.Width / 8 + 10];
      byte[] numArray = new byte[8]
      {
        (byte) 128,
        (byte) 64,
        (byte) 32,
        (byte) 16,
        (byte) 8,
        (byte) 4,
        (byte) 2,
        (byte) 1
      };
      this.hei_dian_shu = this.diao.qu_hei_dian();
      this.timer3.Enabled = true;
      this.miao = 0;
      this.label12.Visible = true;
      for (int weiZhi = this.wei_zhi; weiZhi < this.diao.tu_pian.Height; ++weiZhi)
      {
        int num1 = 0;
        for (int index1 = 0; index1 < buffer1.Length - 9; ++index1)
        {
          byte num2 = 0;
          for (int index2 = 0; index2 < 8; ++index2)
          {
            if (index1 * 8 + index2 < this.diao.tu_pian.Width && this.diao.tu_pian.GetPixel(index1 * 8 + index2, weiZhi).R == (byte) 0)
            {
              num2 |= numArray[index2];
              this.diao.tu_pian.SetPixel(index1 * 8 + index2, weiZhi, Color.Red);
            }
          }
          buffer1[num1 + 9] = num2;
          ++num1;
        }
        buffer1[0] = (byte) 9;
        buffer1[1] = (byte) (buffer1.Length >> 8);
        buffer1[2] = (byte) buffer1.Length;
        buffer1[3] = (byte) (this.trackBar1.Value >> 8);
        buffer1[4] = (byte) this.trackBar1.Value;
        buffer1[5] = (byte) (this.trackBar4.Value * 10 >> 8);
        buffer1[6] = (byte) (this.trackBar4.Value * 10);
        buffer1[7] = (byte) (weiZhi >> 8);
        buffer1[8] = (byte) weiZhi;
        this.diao.fanhui = false;
        bool flag1 = false;
        for (int index = 9; index < buffer1.Length; ++index)
        {
          if (buffer1[index] != (byte) 0)
          {
            flag1 = true;
            break;
          }
        }
        if (flag1)
        {
label_18:
          do
          {
            try
            {
              if (!this.cuo_wu)
              {
                this.com.Write(buffer1, 0, buffer1.Length);
              }
              else
              {
                byte[] buffer2 = new byte[23];
                this.com.Write(buffer2, 0, buffer2.Length);
                this.cuo_wu = false;
              }
            }
            catch (Exception ex)
            {
              this.com.Close();
              Thread.Sleep(500);
              string portName1 = this.com.PortName;
              bool flag2 = false;
              do
              {
                foreach (string portName2 in SerialPort.GetPortNames())
                {
                  if (portName2 == portName1)
                  {
                    flag2 = true;
                    break;
                  }
                }
                Thread.Sleep(100);
                diao_ke_ji.处理事件();
              }
              while (!flag2);
              this.com.Open();
              continue;
            }
            int num2 = 0;
            while (!this.diao.fanhui)
            {
              if (this.com.IsOpen)
              {
                ++num2;
                if (this.ting_zhi)
                {
                  this.diao.ting_zhi();
                  this.kai_shi = false;
                  this.gai_bian = true;
                  this.timer3.Enabled = false;
                  this.label12.Visible = true;
                  this.shu_xin();
                  return false;
                }
                if (this.feng_shang)
                {
                  if (this.fen)
                    this.diao.kai_feng2();
                  else
                    this.diao.guan_feng2();
                  this.feng_shang = false;
                }
                else if (this.zan_ting)
                {
                  if (this.zan_ting2)
                  {
                    this.diao.zan_ting();
                    this.timer3.Enabled = false;
                  }
                  else
                  {
                    this.diao.ji_xu();
                    this.timer3.Enabled = true;
                  }
                  this.zan_ting = false;
                }
                diao_ke_ji.处理事件();
                Thread.Sleep(10);
              }
              else
                goto label_18;
            }
            this.gai_bian = true;
            this.shu_xin();
            diao_ke_ji.处理事件();
            Thread.Sleep(10);
          }
          while (this.fanhui_shu == 8);
        }
      }
      if (!this.ting_zhi)
      {
        this.wei_zhi = 0;
        this.kai_shi = false;
        this.timer3.Enabled = false;
        this.timer3.Enabled = false;
        this.label12.Visible = true;
        this.diao.ting_zhi();
        this.kai_shi = false;
        this.gai_bian = true;
        this.timer3.Enabled = false;
        this.label12.Visible = true;
        this.shu_xin();
        this.quan_bu_shua_xin();
        int num = (int) MessageBox.Show(this.str26);
        return true;
      }
      this.timer3.Enabled = false;
      this.label12.Visible = true;
      this.diao.ting_zhi();
      this.kai_shi = false;
      this.gai_bian = true;
      this.timer3.Enabled = false;
      this.label12.Visible = true;
      this.shu_xin();
      return true;
    }

    public bool diaoke_hui()
    {
      this.diao.fei_li_san_mo_shi();
      this.diao.fu_wei();
      this.diao.kai_feng();
      this.fen = true;
      diao_ke_ji diao = this.diao;
      Point location = this.panel1.Location;
      int xx = (int) ((double) (location.X - 25) * 3.2);
      location = this.panel1.Location;
      int yy = (int) ((double) (location.Y - 60) * 3.2);
      diao.kai_shi(xx, yy);
      byte[] buffer = new byte[this.diao.tu_pian.Width + 9];
      int width = this.diao.tu_pian.Width;
      int height = this.diao.tu_pian.Height;
      new byte[8]
      {
        (byte) 128,
        (byte) 64,
        (byte) 32,
        (byte) 16,
        (byte) 8,
        (byte) 4,
        (byte) 2,
        (byte) 1
      };
      this.timer3.Enabled = true;
      this.miao = 0;
      this.label12.Visible = true;
      for (int y1 = 0; y1 < height; ++y1)
      {
        for (int x1 = 0; x1 < width; ++x1)
        {
          byte[] numArray = buffer;
          int index = x1 + 9;
          Color pixel = this.diao.tu_pian.GetPixel(x1, y1);
          int num = (int) (byte) ((int) byte.MaxValue - (int) pixel.R);
          numArray[index] = (byte) num;
          Bitmap tuPian = this.diao.tu_pian;
          int x2 = x1;
          int y2 = y1;
          pixel = this.diao.tu_pian.GetPixel(x1, y1);
          Color color = Color.FromArgb((int) pixel.R, 0, 0);
          tuPian.SetPixel(x2, y2, color);
        }
        bool flag = false;
        for (int index = 9; index < width; ++index)
        {
          if (buffer[index + 9] > (byte) 20)
          {
            flag = true;
            ++this.hei_dian_shu;
            break;
          }
        }
        if (flag)
        {
          buffer[0] = (byte) 19;
          buffer[1] = (byte) (buffer.Length >> 8);
          buffer[2] = (byte) buffer.Length;
          buffer[3] = (byte) (this.trackBar1.Value >> 8);
          buffer[4] = (byte) this.trackBar1.Value;
          buffer[5] = (byte) (this.trackBar4.Value * 10 >> 8);
          buffer[6] = (byte) (this.trackBar4.Value * 10);
          buffer[7] = (byte) (y1 >> 8);
          buffer[8] = (byte) y1;
          this.diao.fanhui = false;
          try
          {
            if (!this.com.IsOpen)
              return false;
            this.com.Write(buffer, 0, buffer.Length);
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show(ex.ToString());
          }
          diao_ke_ji.处理事件();
          while (!this.diao.fanhui)
          {
            if (this.ting_zhi)
            {
              this.diao.ting_zhi();
              this.kai_shi = false;
              this.gai_bian = true;
              this.timer3.Enabled = false;
              this.label12.Visible = true;
              this.shu_xin();
              this.ting_zhi = false;
              return false;
            }
            if (this.feng_shang)
            {
              Thread.Sleep(500);
              if (this.fen)
                this.diao.kai_feng2();
              else
                this.diao.guan_feng2();
              this.feng_shang = false;
            }
            else if (this.zan_ting)
            {
              if (this.zan_ting2)
              {
                this.timer3.Enabled = false;
                this.diao.zan_ting();
              }
              else
              {
                this.timer3.Enabled = true;
                this.diao.ji_xu();
              }
              this.zan_ting = false;
            }
            diao_ke_ji.处理事件();
            Thread.Sleep(10);
          }
          this.gai_bian = true;
          this.shu_xin();
        }
      }
      if (!this.ting_zhi)
      {
        this.wei_zhi = 0;
        this.kai_shi = false;
        this.timer3.Enabled = false;
        this.timer3.Enabled = false;
        this.label12.Visible = true;
        this.diao.ting_zhi();
        this.kai_shi = false;
        this.gai_bian = true;
        this.timer3.Enabled = false;
        this.label12.Visible = true;
        this.shu_xin();
        this.quan_bu_shua_xin();
        int num = (int) MessageBox.Show(this.str26);
        return true;
      }
      this.timer3.Enabled = false;
      this.label12.Visible = true;
      this.diao.ting_zhi();
      this.kai_shi = false;
      this.gai_bian = true;
      this.timer3.Enabled = false;
      this.label12.Visible = true;
      this.shu_xin();
      return true;
    }

    private void button4_Click(object sender, EventArgs e)
    {
    }

    public Bitmap heibai(Bitmap bb)
    {
      Bitmap bitmap = new Bitmap((Image) bb);
      Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
      byte[] destination = new byte[length];
      byte[] source = new byte[length];
      Marshal.Copy(scan0, destination, 0, length);
      for (int index = 0; index < destination.Length; index += 4)
      {
        int num = ((int) destination[index] * 30 + (int) destination[index + 1] * 59 + (int) destination[index + 2] * 11) / 100 <= 150 ? 0 : (int) byte.MaxValue;
        source[index] = (byte) num;
        source[index + 1] = (byte) num;
        source[index + 2] = (byte) num;
        source[index + 3] = byte.MaxValue;
      }
      Marshal.Copy(source, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata);
      return bitmap;
    }

    private void button5_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      if (this.textBox2.Visible)
      {
        this.panel6.Visible = false;
        this.button9.Visible = false;
        this.button10.Visible = false;
        if (this.textBox2.Text == "")
        {
          this.textBox2.Visible = false;
          this.button9.Visible = false;
          this.button10.Visible = false;
          this.button5.Text = this.str5;
        }
        else
        {
          this.textBox2.BorderStyle = BorderStyle.None;
          --this.textBox2.Width;
          this.textBox2.Location = new Point(this.textBox2.Location.X + 1, this.textBox2.Location.Y + 1);
          Thread.Sleep(10);
          diao_ke_ji.处理事件();
          Thread.Sleep(10);
          this.w_z = tu_xiang.jieping_控件((Control) this.textBox2);
          this.w_z = tu_xiang.suofang(this.w_z, (int) ((double) this.w_z.Width * 3.2), (int) ((double) this.w_z.Height * 3.2));
          this.w_z = this.heibai(this.w_z);
          this.w_z = tu_xiang.qu_bian_jie(this.w_z);
          Point location = this.textBox2.Location;
          int x1 = location.X;
          location = this.panel1.Location;
          int x2 = location.X;
          int x3 = (int) ((double) (x1 - x2) * 3.2);
          location = this.textBox2.Location;
          int y1 = location.Y;
          location = this.panel1.Location;
          int y2 = location.Y;
          int y3 = (int) ((double) (y1 - y2) * 3.2);
          this.wz_weizhi = new Point(x3, y3);
          this.button5.Text = this.str5;
          this.textBox2.Visible = false;
          this.button9.Visible = false;
          this.button10.Visible = false;
          this.gai_bian = true;
          this.zhuang_tai = 3;
          this.dx = 0;
          this.dy = 0;
          this.wei_zhi = 0;
        }
      }
      else
      {
        this.zhuang_tai = 3;
        this.textBox2.Visible = true;
        this.button9.Visible = true;
        this.textBox2.Location = this.panel1.Location;
        this.textBox2.Focus();
        this.button10.Location = new Point(161, 126);
        this.textBox2.Size = new Size(70, 50);
        this.textBox2.BorderStyle = BorderStyle.FixedSingle;
        Button button9 = this.button9;
        Point location = this.textBox2.Location;
        int x = location.X + this.textBox2.Width;
        location = this.textBox2.Location;
        int y = location.Y + this.textBox2.Height;
        Point point = new Point(x, y);
        button9.Location = point;
        this.button5.Text = this.str6;
        this.gai_bian = true;
        this.shu_xin();
      }
    }

    private void button10_MouseDown(object sender, MouseEventArgs e)
    {
      this.anxia = true;
      this.shu_x = e.X;
      this.shu_y = e.Y;
    }

    private void button10_MouseUp(object sender, MouseEventArgs e)
    {
      this.anxia = false;
    }

    private void button10_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.anxia)
        return;
      Point point = new Point();
      Point location;
      if (e.X - this.shu_x > 0)
      {
        location = this.textBox2.Location;
        if (location.X + this.textBox2.Size.Width < this.panel1.Width)
        {
          ref Point local1 = ref point;
          location = this.textBox2.Location;
          int num1 = location.X + (e.X - this.shu_x);
          local1.X = num1;
          ref Point local2 = ref point;
          location = this.textBox2.Location;
          int y1 = location.Y;
          local2.Y = y1;
          this.textBox2.Location = point;
          ref Point local3 = ref point;
          location = this.button10.Location;
          int num2 = location.X + (e.X - this.shu_x);
          local3.X = num2;
          ref Point local4 = ref point;
          location = this.button10.Location;
          int y2 = location.Y;
          local4.Y = y2;
          this.button10.Location = point;
          ref Point local5 = ref point;
          location = this.button9.Location;
          int num3 = location.X + (e.X - this.shu_x);
          local5.X = num3;
          ref Point local6 = ref point;
          location = this.button9.Location;
          int y3 = location.Y;
          local6.Y = y3;
          this.button9.Location = point;
        }
      }
      else
      {
        location = this.textBox2.Location;
        if (location.X + (e.X - this.shu_x) > 0)
        {
          ref Point local1 = ref point;
          location = this.textBox2.Location;
          int num1 = location.X + (e.X - this.shu_x);
          local1.X = num1;
          ref Point local2 = ref point;
          location = this.textBox2.Location;
          int y1 = location.Y;
          local2.Y = y1;
          this.textBox2.Location = point;
          ref Point local3 = ref point;
          location = this.button10.Location;
          int num2 = location.X + (e.X - this.shu_x);
          local3.X = num2;
          ref Point local4 = ref point;
          location = this.button10.Location;
          int y2 = location.Y;
          local4.Y = y2;
          this.button10.Location = point;
          ref Point local5 = ref point;
          location = this.button9.Location;
          int num3 = location.X + (e.X - this.shu_x);
          local5.X = num3;
          ref Point local6 = ref point;
          location = this.button9.Location;
          int y3 = location.Y;
          local6.Y = y3;
          this.button9.Location = point;
        }
      }
      if (e.Y - this.shu_y > 0)
      {
        location = this.textBox2.Location;
        if (location.Y + this.textBox2.Size.Height >= this.panel1.Height)
          return;
        ref Point local1 = ref point;
        location = this.textBox2.Location;
        int x1 = location.X;
        local1.X = x1;
        ref Point local2 = ref point;
        location = this.textBox2.Location;
        int num1 = location.Y + (e.Y - this.shu_y);
        local2.Y = num1;
        this.textBox2.Location = point;
        ref Point local3 = ref point;
        location = this.button10.Location;
        int x2 = location.X;
        local3.X = x2;
        ref Point local4 = ref point;
        location = this.button10.Location;
        int num2 = location.Y + (e.Y - this.shu_y);
        local4.Y = num2;
        this.button10.Location = point;
        ref Point local5 = ref point;
        location = this.button9.Location;
        int x3 = location.X;
        local5.X = x3;
        ref Point local6 = ref point;
        location = this.button9.Location;
        int num3 = location.Y + (e.Y - this.shu_y);
        local6.Y = num3;
        this.button9.Location = point;
      }
      else
      {
        location = this.textBox2.Location;
        if (location.Y + (e.Y - this.shu_y) <= 0)
          return;
        ref Point local1 = ref point;
        location = this.textBox2.Location;
        int x1 = location.X;
        local1.X = x1;
        ref Point local2 = ref point;
        location = this.textBox2.Location;
        int num1 = location.Y + (e.Y - this.shu_y);
        local2.Y = num1;
        this.textBox2.Location = point;
        ref Point local3 = ref point;
        location = this.button10.Location;
        int x2 = location.X;
        local3.X = x2;
        ref Point local4 = ref point;
        location = this.button10.Location;
        int num2 = location.Y + (e.Y - this.shu_y);
        local4.Y = num2;
        this.button10.Location = point;
        ref Point local5 = ref point;
        location = this.button9.Location;
        int x3 = location.X;
        local5.X = x3;
        ref Point local6 = ref point;
        location = this.button9.Location;
        int num3 = location.Y + (e.Y - this.shu_y);
        local6.Y = num3;
        this.button9.Location = point;
      }
    }

    private void button9_MouseDown(object sender, MouseEventArgs e)
    {
      this.anxia = true;
      this.shu_x = e.X;
      this.shu_y = e.Y;
    }

    private void button9_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.anxia)
        return;
      this.textBox2.Width = this.button9.Location.X - this.textBox2.Location.X;
      this.textBox2.Height = this.button9.Location.Y - this.textBox2.Location.Y;
      this.button9.Location = new Point(this.button9.Location.X + (e.X - this.shu_x), this.button9.Location.Y + (e.Y - this.shu_y));
    }

    private void button9_MouseUp(object sender, MouseEventArgs e)
    {
      this.anxia = false;
      Point location;
      if (this.textBox2.Width > 500)
      {
        this.textBox2.Width = 500;
        Button button9 = this.button9;
        int x = this.textBox2.Location.X + 500;
        location = this.button9.Location;
        int y = location.Y;
        Point point = new Point(x, y);
        button9.Location = point;
      }
      if (this.textBox2.Height <= 500)
        return;
      this.textBox2.Height = 500;
      Button button9_1 = this.button9;
      location = this.button9.Location;
      int x1 = location.X;
      location = this.textBox2.Location;
      int y1 = location.Y + 500;
      Point point1 = new Point(x1, y1);
      button9_1.Location = point1;
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (this.diao.tu_pian == null)
        return;
      if (this.checkBox2.Checked)
      {
        this.diao.kai_kuang2(this.bj[1] - this.bj[0], this.bj[3] - this.bj[2], this.bj[0], this.bj[2]);
        this.gai_bian = true;
        this.shu_xin();
      }
      else
      {
        this.gai_bian = true;
        this.shu_xin();
        this.diao.guan_kuang2();
      }
    }

    private void button8_Click(object sender, EventArgs e)
    {
      int weiZhi = this.wei_zhi;
    }

    private void button7_Click(object sender, EventArgs e)
    {
      int weiZhi = this.wei_zhi;
      int kuanGao = this.diao.kuan_gao;
    }

    private void panel2_Paint(object sender, PaintEventArgs e)
    {
    }

    private void trackBar1_MouseUp(object sender, MouseEventArgs e)
    {
      this.textBox1.Text = this.trackBar1.Value.ToString();
      if (!this.g_daima)
        return;
      this.diao.gai_bian_F(this.trackBar1.Value);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (this.textBox1.Text == "")
        return;
      try
      {
        if (Convert.ToInt32(this.textBox1.Text) < 1000)
        {
          this.trackBar1.Value = Convert.ToInt32(this.textBox1.Text);
        }
        else
        {
          this.textBox1.Text = "1000";
          this.trackBar1.Value = 1000;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {
      this.trackBar2.Value = Convert.ToInt32(this.textBox3.Text);
    }

    private void button11_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.textBox2.Visible)
      {
        int num3 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        this.panel1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y - (int) ((double) Convert.ToInt16(this.textBox4.Text) * (5.0 / 16.0)));
        this.pan_yidong();
      }
    }

    private void button12_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.textBox2.Visible)
      {
        int num3 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        this.panel1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y + (int) ((double) Convert.ToInt16(this.textBox4.Text) * (5.0 / 16.0)));
        this.pan_yidong();
      }
    }

    private void button13_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.textBox2.Visible)
      {
        int num3 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        this.panel1.Location = new Point(this.panel1.Location.X - (int) ((double) Convert.ToInt16(this.textBox4.Text) * (5.0 / 16.0)), this.panel1.Location.Y);
        this.pan_yidong();
      }
    }

    private void button14_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.textBox2.Visible)
      {
        int num3 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        this.panel1.Location = new Point(this.panel1.Location.X + (int) ((double) Convert.ToInt16(this.textBox4.Text) * (5.0 / 16.0)), this.panel1.Location.Y);
        this.pan_yidong();
      }
    }

    private void button15_Click(object sender, EventArgs e)
    {
      this.diao.guan_ruo_guang();
      this.diao.dian_deng(this.trackBar1.Value);
    }

    private void button16_Click(object sender, EventArgs e)
    {
      this.diao.tuo_ji_da_yin();
    }

    private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void button17_Click(object sender, EventArgs e)
    {
      if (this.textBox2.Visible)
        return;
      if (this.zhuang_tai == 2)
        this.diao.duoji2(this.jdt, this.zhixian);
      else
        this.diao.duoji(this.jdt);
    }

    private void button20_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      this.fan_se = !this.fan_se;
      this.gai_bian = true;
      this.shu_xin();
      this.bj = tu_xiang.qu_bian_jie2(this.diao.tu_pian);
    }

    private void button18_Click(object sender, EventArgs e)
    {
      this.suofang += 5;
      Graphics.FromImage((Image) this.diao.tu).DrawImage((Image) new Bitmap((Image) tu_xiang.suofang(this.tu, this.diao.kuan_gao + this.suofang, this.diao.kuan_gao + this.suofang)), 0, 0);
      this.diao.tu_pian = this.diao.dou_dong(this.trackBar2.Value);
      this.shu_xin();
    }

    private void button19_Click(object sender, EventArgs e)
    {
      this.suofang -= 5;
      Bitmap bitmap = new Bitmap((Image) tu_xiang.suofang(this.tu, this.diao.kuan_gao + this.suofang, this.diao.kuan_gao + this.suofang));
      Graphics graphics = Graphics.FromImage((Image) this.diao.tu);
      graphics.Clear(Color.White);
      graphics.DrawImage((Image) bitmap, 0, 0);
      this.diao.tu_pian = this.diao.dou_dong(this.trackBar2.Value);
      this.shu_xin();
    }

    private void trackBar3_MouseUp(object sender, MouseEventArgs e)
    {
      this.gai_bian = true;
      this.quan_bu_shua_xin();
      if (this.checkBox2.Checked)
        this.diao.kai_kuang(this.diao.tu_pian.Width, this.diao.tu_pian.Height);
      this.pan_yidong();
    }

    private void button24_Click(object sender, EventArgs e)
    {
      if (this.button1.Text == this.str2)
        return;
      this.hei_dian_shu = 0;
      this.ting_zhi = true;
      this.kai_shi = false;
      this.wei_zhi = 0;
      this.hua2 = false;
      this.button29.Text = this.str8;
    }

    private void button21_Click(object sender, EventArgs e)
    {
      if (this.kai_shi || this.tu == null)
        return;
      this.tu.RotateFlip(RotateFlipType.RotateNoneFlipX);
      this.gai_bian = true;
      this.shu_xin();
    }

    private void button22_Click(object sender, EventArgs e)
    {
      if (this.kai_shi || this.tu == null)
        return;
      this.tu.RotateFlip(RotateFlipType.Rotate180FlipX);
      this.gai_bian = true;
      this.shu_xin();
    }

    private void button25_Click(object sender, EventArgs e)
    {
      if (this.kai_shi || this.tu == null)
        return;
      this.tu.RotateFlip(RotateFlipType.Rotate90FlipNone);
      this.gai_bian = true;
      this.panel1.Refresh();
      this.pan_yidong();
    }

    private void button23_Click(object sender, EventArgs e)
    {
      if (this.zhuang_tai == 2 || this.diao.tu_pian == null)
        return;
      this.gai_bian = true;
      if (this.ca)
      {
        this.ca = false;
        this.panel1.Cursor = Cursors.Cross;
      }
      else
      {
        this.ca = true;
        this.panel1.Cursor = Cursors.No;
      }
    }

    private void button15_Click_1(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      this.wenben = "";
      this.textBox2.Text = "";
      Graphics graphics = Graphics.FromImage((Image) new Bitmap(1, 1));
      graphics.Clear(Color.White);
      graphics.Dispose();
      this.tu = (Bitmap) null;
      this.diao.tu = (Bitmap) null;
      this.diao.tu_pian = (Bitmap) null;
      this.wen_jian_ming = "";
      this.w_z = (Bitmap) null;
      if (this.checkBox2.Checked)
      {
        this.diao.guan_kuang();
        this.checkBox2.Checked = false;
      }
      this.wzms = true;
      this.panel1.Width = 20;
      this.panel1.Height = 20;
      this.panel1.Location = new Point(25, 60);
      this.pan_yidong();
      this.panel1.Refresh();
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      this.shubiao_x = e.X;
      this.shubiao_y = e.Y;
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
      this.anxia3 = false;
      this.panel1.Refresh();
    }

    private void pictureBox1_LocationChanged(object sender, EventArgs e)
    {
    }

    private void button16_Click_1(object sender, EventArgs e)
    {
      this.diao.tuo_ji_da_yin();
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      if (this.kai_shi)
        return;
      if (this.textBox2.Visible)
      {
        this.textBox2.Visible = false;
        this.button9.Visible = false;
      }
      string str = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
      this.wzms = false;
      this.wen_jian_ming = str;
      this.da_kai();
      this.gai_bian = true;
      this.shu_xin();
      this.pan_yidong();
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (this.checkBox2.Checked)
        this.diao.guan_kuang();
      this.panel3.Visible = false;
      this.panel1.Width = 20;
      this.panel1.Height = 20;
      this.panel1.Location = new Point(525, 560);
      this.pan_yidong();
      this.timer2.Enabled = false;
      this.com.Close();
      this.diao.lianjie = false;
      this.panel2.Refresh();
      Process currentProcess = Process.GetCurrentProcess();
      foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
      {
        if (process.Id == currentProcess.Id)
          process.Kill();
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.cuo_wu = true;
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
    }

    private void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      if (!this.com.IsOpen)
        return;
      this.diao.fanhui = true;
      this.fanhui_shu = this.com.ReadByte();
      if (this.fanhui_shu == 8)
        this.fanhui_shu = 8;
      this.com.DiscardInBuffer();
    }

    private void com_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
    {
      try
      {
        this.com.Close();
        this.com.Open();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(this.str30, ex.ToString());
        throw;
      }
    }

    private void button26_Click(object sender, EventArgs e)
    {
      this.diao.kai_deng();
    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {
      this.textBox4.Text = Form1.ToDBC(this.textBox4.Text);
      this.textBox4.Select(this.textBox4.Text.Length, 0);
    }

    public static string ToDBC(string input)
    {
      char[] charArray = input.ToCharArray();
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] == '　')
          charArray[index] = ' ';
        else if (charArray[index] > '\xFF00' && charArray[index] < '｟')
          charArray[index] = (char) ((uint) charArray[index] - 65248U);
      }
      return new string(charArray);
    }

    private void button27_Click(object sender, EventArgs e)
    {
      if (this.button1.Text == this.str2)
        return;
      if (this.kai_shi)
      {
        this.feng_shang = true;
        if (this.fen)
          this.fen = false;
        else
          this.fen = true;
      }
      else if (this.fen)
      {
        this.fen = false;
        this.diao.guan_feng();
      }
      else
      {
        this.fen = true;
        this.diao.kai_feng();
      }
    }

    private void hua_biao_shi()
    {
      if (this.bj[1] - this.bj[0] == 0)
        return;
      double num1 = Convert.ToDouble(this.textBox7.Text);
      double num2 = Convert.ToDouble(this.textBox8.Text);
      this.panel4.Width = (int) ((double) (this.bj[1] - this.bj[0]) / 3.2);
      this.panel4.Location = new Point((int) ((double) this.panel1.Location.X + (double) this.bj[0] / 3.2), 43);
      if (this.panel4.Width == 0)
        return;
      this.biao_shi_k = new Bitmap(this.panel4.Width, 17);
      Bitmap bitmap1 = new Bitmap(55, 15);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap1);
      graphics1.Clear(this.BackColor);
      graphics1.DrawString(num1.ToString() + this.label20.Text, this.Font, Brushes.Blue, new PointF(0.0f, 0.0f));
      graphics1.Dispose();
      Graphics graphics2 = Graphics.FromImage((Image) this.biao_shi_k);
      graphics2.Clear(this.BackColor);
      graphics2.DrawRectangle(Pens.Blue, new Rectangle(0, -1, this.panel4.Width - 1, 19));
      graphics2.DrawLine(Pens.Blue, 0, 8, this.panel4.Width, 8);
      graphics2.DrawImage((Image) bitmap1, this.panel4.Width / 2 - 25, 2);
      graphics2.Dispose();
      this.panel4.Refresh();
      this.panel5.Height = (int) ((double) (this.bj[3] - this.bj[2]) / 3.2);
      this.panel5.Location = new Point(8, (int) ((double) this.panel1.Location.Y + (double) this.bj[2] / 3.2));
      if (this.panel4.Height == 0)
        return;
      this.biao_shi_g = new Bitmap(17, this.panel5.Height);
      Bitmap bitmap2 = new Bitmap(55, 15);
      Graphics graphics3 = Graphics.FromImage((Image) bitmap2);
      graphics3.Clear(this.BackColor);
      graphics3.DrawString(num2.ToString() + this.label20.Text, this.Font, Brushes.Blue, new PointF(0.0f, 0.0f));
      graphics3.Dispose();
      Graphics graphics4 = Graphics.FromImage((Image) this.biao_shi_g);
      graphics4.Clear(this.BackColor);
      graphics4.DrawRectangle(Pens.Blue, new Rectangle(-1, 1, this.panel5.Width + 2, this.panel5.Height - 2));
      graphics4.DrawLine(Pens.Blue, 8, 1, 8, this.panel5.Height);
      bitmap2.RotateFlip(RotateFlipType.Rotate90FlipNone);
      graphics4.DrawImage((Image) bitmap2, 1, this.panel5.Height / 2 - 25);
      graphics4.Dispose();
      this.panel5.Refresh();
    }

    private void hei_bai_CheckedChanged(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      this.gai_bian = true;
      this.trackBar2.Value = 128;
      this.textBox1.Text = "10";
      this.textBox3.Text = "128";
      if (this.wen_jian_ming == "")
        return;
      this.da_kai();
      this.gai_bian = true;
      this.panel1.Refresh();
    }

    private void li_san_CheckedChanged(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      this.gai_bian = true;
      this.trackBar2.Value = 128;
      this.textBox1.Text = "10";
      this.textBox3.Text = "128";
      if (this.textBox2.Visible || this.wen_jian_ming == "")
        return;
      this.da_kai();
      this.gai_bian = true;
      this.panel1.Refresh();
    }

    private void hui_du_CheckedChanged(object sender, EventArgs e)
    {
      if (this.kai_shi || this.textBox2.Visible)
        return;
      this.trackBar2.Value = 128;
      this.gai_bian = true;
      this.textBox1.Text = "10";
      this.textBox3.Text = "128";
      if (this.wen_jian_ming == "")
        return;
      this.da_kai();
      this.gai_bian = true;
      this.panel1.Refresh();
    }

    private void trackBar4_Scroll(object sender, EventArgs e)
    {
      this.textBox5.Text = this.trackBar4.Value.ToString();
    }

    private void textBox5_TextChanged(object sender, EventArgs e)
    {
      this.trackBar4.Value = Convert.ToInt32(this.textBox5.Text);
    }

    private void button4_MouseUp(object sender, MouseEventArgs e)
    {
    }

    private void button4_MouseDown(object sender, MouseEventArgs e)
    {
      if (this.button1.Text == this.str2)
      {
        int num1 = (int) MessageBox.Show(this.str23);
      }
      else if (this.tu == null && this.textBox2.Text == "")
      {
        int num2 = (int) MessageBox.Show(this.str24);
      }
      else if (this.kai_shi)
      {
        int num3 = (int) MessageBox.Show(this.str25);
      }
      else
      {
        if (this.textBox2.Visible)
          this.button5_Click((object) null, new EventArgs());
        if (this.checkBox2.Checked)
        {
          int num4 = (int) MessageBox.Show(this.str35);
        }
        else
        {
          if (this.zhong_xin)
            this.button35_Click((object) null, (EventArgs) null);
          this.kai_shi = true;
          this.ting_zhi = false;
          if (this.hui_du.Checked)
            this.diaoke_hui();
          else
            this.diaoke2();
        }
      }
    }

    private void button26_Click_1(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else
      {
        if (this.textBox2.Visible)
        {
          int num3 = (int) MessageBox.Show(this.str29);
        }
        this.diao.dao_yuandian();
        this.panel1.Location = new Point(25, 60);
        this.x = 0;
        this.y = 0;
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      int num = this.kai_shi ? 1 : 0;
    }

    private void button28_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.tu == null && this.textBox2.Text == "")
      {
        int num3 = (int) MessageBox.Show(this.str24);
      }
      else if (this.textBox2.Visible)
      {
        int num4 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        if (this.zhong_xin)
          this.button35_Click((object) null, (EventArgs) null);
        if (!this.checkBox2.Checked)
          this.checkBox2.Checked = true;
        else
          this.checkBox2.Checked = false;
      }
    }

    private void li_san_MouseDown(object sender, MouseEventArgs e)
    {
      int num = this.textBox2.Visible ? 1 : 0;
    }

    private void button29_MouseDown(object sender, MouseEventArgs e)
    {
      if (!this.kai_shi)
        return;
      this.zan_ting = true;
      if (this.button29.Text == this.str8)
      {
        this.zan_ting2 = true;
        this.button29.Text = this.str9;
      }
      else
      {
        this.zan_ting2 = false;
        this.button29.Text = this.str8;
      }
    }

    private void button29_Click(object sender, EventArgs e)
    {
    }

    private void button30_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.textBox2.Visible)
      {
        int num3 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        if (this.diao.tu_pian == null)
          this.panel1.Location = new Point(275, 310);
        else
          this.panel1.Location = new Point(25 + (int) (500.0 - (double) this.diao.tu_pian.Width * (5.0 / 16.0)) / 2, 60 + (int) (500.0 - (double) this.diao.tu_pian.Height * (5.0 / 16.0)) / 2);
        this.pan_yidong();
      }
    }

    private void button31_Paint(object sender, PaintEventArgs e)
    {
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      if (this.textBox2.Visible)
        return;
      this.quan_bu_shua_xin();
    }

    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
      this.an_xia = true;
      this.yi_dian = new Point(e.X, e.Y);
    }

    private void pan_yidong()
    {
      Point location;
      if (this.panel1.Location.X < 25)
      {
        Panel panel1 = this.panel1;
        location = this.panel1.Location;
        Point point = new Point(25, location.Y);
        panel1.Location = point;
      }
      location = this.panel1.Location;
      if (location.Y < 60)
      {
        Panel panel1 = this.panel1;
        location = this.panel1.Location;
        Point point = new Point(location.X, 60);
        panel1.Location = point;
      }
      location = this.panel1.Location;
      if (location.X + this.panel1.Width > 525)
      {
        Panel panel1 = this.panel1;
        int x = 525 - this.panel1.Width;
        location = this.panel1.Location;
        int y = location.Y;
        Point point = new Point(x, y);
        panel1.Location = point;
      }
      location = this.panel1.Location;
      if (location.Y + this.panel1.Height > 560)
      {
        Panel panel1 = this.panel1;
        location = this.panel1.Location;
        Point point = new Point(location.X, 560 - this.panel1.Height);
        panel1.Location = point;
      }
      if (!this.diao.lianjie)
        return;
      diao_ke_ji diao = this.diao;
      location = this.panel1.Location;
      int xx = (int) ((double) (location.X - 25 - this.x) * 3.2);
      location = this.panel1.Location;
      int yy = (int) ((double) (location.Y - 60 - this.y) * 3.2);
      PictureBox p = new PictureBox();
      diao.yidong(xx, yy, p, false);
      location = this.panel1.Location;
      this.x = location.X - 25;
      location = this.panel1.Location;
      this.y = location.Y - 60;
    }

    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
      if (!this.an_xia)
        return;
      this.an_xia = false;
      this.pan_yidong();
    }

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.an_xia)
        return;
      if (this.button1.Text == this.str2)
      {
        int num = (int) MessageBox.Show(this.str23);
        this.an_xia = false;
      }
      else if (this.kai_shi)
      {
        int num = (int) MessageBox.Show(this.str25);
        this.an_xia = false;
      }
      else
      {
        int x = this.panel1.Location.X + (e.X - this.yi_dian.X);
        int y = this.panel1.Location.Y + (e.Y - this.yi_dian.Y);
        if (x < 25)
          x = 25;
        if (x > 525 - this.panel1.Width)
          x = 525 - this.panel1.Width;
        if (y < 60)
          y = 60;
        if (y > 560 - this.panel1.Height)
          y = 560 - this.panel1.Height;
        this.panel1.Location = new Point(x, y);
      }
    }

    private void button31_Click(object sender, EventArgs e)
    {
      this.heibai(tu_xiang.jieping_控件((Control) this.button1));
    }

    private void button32_Click(object sender, EventArgs e)
    {
      if (this.panel6.Visible)
        this.panel6.Visible = false;
      else
        this.panel6.Visible = true;
    }

    private void textBox2_MouseDown(object sender, MouseEventArgs e)
    {
      this.bjk_anxia = true;
      this.bjk_x = e.X;
      this.bjk_y = e.Y;
    }

    private void textBox2_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.bjk_anxia)
        return;
      this.textBox2.Location = new Point(this.textBox2.Location.X + (e.X - this.bjk_x), this.textBox2.Location.Y + (e.Y - this.bjk_y));
    }

    private void textBox2_MouseUp(object sender, MouseEventArgs e)
    {
      this.bjk_anxia = false;
      if (this.textBox2.Location.X < 25)
        this.textBox2.Location = new Point(25, this.textBox2.Location.Y);
      Point location;
      if (this.textBox2.Location.X + this.textBox2.Width > 525)
      {
        TextBox textBox2 = this.textBox2;
        int x = 525 - this.textBox2.Width;
        location = this.textBox2.Location;
        int y = location.Y;
        Point point = new Point(x, y);
        textBox2.Location = point;
      }
      location = this.textBox2.Location;
      if (location.Y < 60)
      {
        TextBox textBox2 = this.textBox2;
        location = this.textBox2.Location;
        Point point = new Point(location.X, 60);
        textBox2.Location = point;
      }
      location = this.textBox2.Location;
      if (location.Y + this.textBox2.Height <= 560)
        return;
      TextBox textBox2_1 = this.textBox2;
      location = this.textBox2.Location;
      Point point1 = new Point(location.X, 560 - this.textBox2.Height);
      textBox2_1.Location = point1;
    }

    private void textBox2_LocationChanged(object sender, EventArgs e)
    {
      Button button9 = this.button9;
      Point location = this.textBox2.Location;
      int x = location.X + this.textBox2.Width;
      location = this.textBox2.Location;
      int y = location.Y + this.textBox2.Height;
      Point point = new Point(x, y);
      button9.Location = point;
    }

    [DllImport("kernel32.dll")]
    private static extern uint SetThreadExecutionState(Form1.ExecutionFlag flags);

    public static void PreventSleep(bool includeDisplay = false)
    {
      if (includeDisplay)
      {
        int num1 = (int) Form1.SetThreadExecutionState(Form1.ExecutionFlag.System | Form1.ExecutionFlag.Display | Form1.ExecutionFlag.Continus);
      }
      else
      {
        int num2 = (int) Form1.SetThreadExecutionState(Form1.ExecutionFlag.System | Form1.ExecutionFlag.Continus);
      }
    }

    public static void ResotreSleep()
    {
      int num = (int) Form1.SetThreadExecutionState(Form1.ExecutionFlag.Continus);
    }

    public static void ResetSleepTimer(bool includeDisplay = false)
    {
      if (includeDisplay)
      {
        int num1 = (int) Form1.SetThreadExecutionState(Form1.ExecutionFlag.System | Form1.ExecutionFlag.Display);
      }
      else
      {
        int num2 = (int) Form1.SetThreadExecutionState(Form1.ExecutionFlag.System);
      }
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        ++this.miao60;
        if (this.miao60 > 100)
        {
          this.miao60 = 0;
          Form1.ResetSleepTimer(true);
        }
      }
      if (!this.diao.lianjie)
        return;
      try
      {
        if (this.com.IsOpen || this.kai_shi)
          return;
        this.com.Close();
        this.diao.lianjie = false;
        this.panel3.Visible = false;
        this.button1.Text = this.str2;
        if (this.kai_shi)
        {
          this.hei_dian_shu = 0;
          this.ting_zhi = true;
          this.zan_ting = false;
          this.zan_ting2 = false;
          this.kai_shi = false;
          this.wei_zhi = 0;
          this.hua2 = false;
          this.button29.Text = this.str8;
        }
        this.panel2.Refresh();
        int num = (int) MessageBox.Show(this.str22);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void timer3_Tick(object sender, EventArgs e)
    {
      ++this.miao;
      this.label12.Text = this.str31 + (this.miao / 60).ToString() + this.str32 + (this.miao % 60).ToString() + this.str33;
      this.label12.Refresh();
    }

    private void label7_Click(object sender, EventArgs e)
    {
    }

    private void groupBox3_Enter(object sender, EventArgs e)
    {
    }

    private void label13_Click(object sender, EventArgs e)
    {
    }

    private void xianzhi()
    {
      if (this.mm_in)
      {
        if (Convert.ToDouble(this.textBox7.Text) > 1600.0 * this.bai_bian_k * 0.05)
          this.textBox7.Text = (1600.0 * this.bai_bian_k * 0.05).ToString();
        if (Convert.ToDouble(this.textBox8.Text) > 1520.0 * this.bai_bian_g * 0.05)
          this.textBox8.Text = (1520.0 * this.bai_bian_g * 0.05).ToString();
        if (Convert.ToDouble(this.textBox7.Text) < 1.0)
        {
          this.diyi = true;
          this.textBox7.Text = "1";
          this.textBox8.Text = ((int) ((double) Convert.ToInt32(this.textBox7.Text) / this.kg_bi)).ToString();
          this.diyi = false;
        }
        if (Convert.ToDouble(this.textBox8.Text) >= 1.0)
          return;
        this.diyi = true;
        this.textBox8.Text = "1";
        this.textBox7.Text = ((int) ((double) Convert.ToInt32(this.textBox8.Text) * this.kg_bi)).ToString();
        this.diyi = false;
      }
      else
      {
        if (Convert.ToDouble(this.textBox7.Text) > 1600.0 * this.bai_bian_k * 0.05 * 0.0393701)
          this.textBox7.Text = (1600.0 * this.bai_bian_k * 0.05 * 0.0393701).ToString().Substring(0, 5);
        if (Convert.ToDouble(this.textBox8.Text) <= 1520.0 * this.bai_bian_g * 0.05 * 0.0393701)
          return;
        this.textBox8.Text = (1520.0 * this.bai_bian_g * 0.05 * 0.0393701).ToString().Substring(0, 5);
      }
    }

    private void textBox7_TextChanged2(object sender, EventArgs e)
    {
      if (this.kai_shi || this.diyi)
        return;
      if (this.textBox7.Text == "")
        this.textBox7.Text = "1";
      this.diyi = true;
      this.textBox8.Text = ((int) (Convert.ToDouble(this.textBox7.Text) / this.kg_bi)).ToString();
      this.diyi = false;
      this.xianzhi();
      this.gai_bian = true;
      this.panel1.Refresh();
      this.pan_yidong();
      this.bj = tu_xiang.qu_bian_jie2(this.diao.tu_pian);
      this.hua_biao_shi();
    }

    private void textBox8_TextChanged2(object sender, EventArgs e)
    {
      if (this.kai_shi || this.diyi)
        return;
      if (this.textBox8.Text == "")
        this.textBox8.Text = "1";
      this.diyi = true;
      this.textBox7.Text = ((int) (Convert.ToDouble(this.textBox8.Text) * this.kg_bi)).ToString();
      this.diyi = false;
      this.xianzhi();
      this.gai_bian = true;
      this.panel1.Refresh();
      this.pan_yidong();
      this.bj = tu_xiang.qu_bian_jie2(this.diao.tu_pian);
      this.hua_biao_shi();
    }

    private void trackBar2_Scroll(object sender, EventArgs e)
    {
      this.textBox3.Text = this.trackBar2.Value.ToString();
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
      this.textBox1.Text = this.trackBar1.Value.ToString();
    }

    private void zi_ti()
    {
      FontStyle style = FontStyle.Regular;
      if (this.radioButton5.Checked)
        style = FontStyle.Regular;
      if (this.radioButton2.Checked)
        style = FontStyle.Bold;
      if (this.radioButton3.Checked)
        style = FontStyle.Italic;
      if (this.radioButton4.Checked)
        style = FontStyle.Bold | FontStyle.Italic;
      try
      {
        this.textBox2.Font = new Font(this.listBox1.Text, (float) (this.trackBar5.Value * 2), style, GraphicsUnit.Pixel);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void trackBar5_Scroll(object sender, EventArgs e)
    {
      this.label17.Text = this.trackBar5.Value.ToString();
      this.zi_ti();
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.zi_ti();
    }

    private void radioButton5_CheckedChanged(object sender, EventArgs e)
    {
      this.zi_ti();
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
      this.zi_ti();
    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
      this.zi_ti();
    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {
      this.zi_ti();
    }

    private void label16_MouseDown(object sender, MouseEventArgs e)
    {
      this.z_anxia = true;
      this.z_x = e.X;
      this.z_y = e.Y;
    }

    private void label16_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.z_anxia)
        return;
      this.panel6.Location = new Point(this.panel6.Location.X + (e.X - this.z_x), this.panel6.Location.Y + (e.Y - this.z_y));
    }

    private void button34_Click(object sender, EventArgs e)
    {
      this.cuo_wu2 = true;
    }

    private void button33_Click(object sender, EventArgs e)
    {
      if (this.mm_in)
      {
        this.mm_in = false;
        this.label20.Text = "in";
        this.label21.Text = "in";
        this.textBox7.Text = (Convert.ToDouble(this.textBox7.Text) * 0.0393701).ToString().Substring(0, 5);
        this.textBox8.Text = (Convert.ToDouble(this.textBox8.Text) * 0.0393701).ToString().Substring(0, 5);
      }
      else
      {
        this.mm_in = true;
        this.label20.Text = "mm";
        this.label21.Text = "mm";
        this.textBox7.Text = (Convert.ToDouble(this.textBox7.Text) / 0.0393701).ToString().Substring(0, 5);
        this.textBox8.Text = (Convert.ToDouble(this.textBox8.Text) / 0.0393701).ToString().Substring(0, 5);
      }
      this.hua_biao_shi();
    }

    private void label16_MouseUp(object sender, MouseEventArgs e)
    {
      this.z_anxia = false;
    }

    private void button35_Click(object sender, EventArgs e)
    {
      if (this.checkBox2.Checked)
      {
        this.checkBox2.Checked = false;
        Thread.Sleep(500);
      }
      if (this.bj == null)
        return;
      if (this.zhong_xin)
      {
        this.diao.yidong2(-(this.bj[0] + (this.bj[1] - this.bj[0]) / 2), -(this.bj[2] + (this.bj[3] - this.bj[2]) / 2), new PictureBox(), false);
        this.zhong_xin = false;
      }
      else
      {
        this.diao.yidong2(this.bj[0] + (this.bj[1] - this.bj[0]) / 2, this.bj[2] + (this.bj[3] - this.bj[2]) / 2, new PictureBox(), false);
        this.zhong_xin = true;
      }
    }

    private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (this.kai_shi)
        return;
      if (this.checkBox2.Checked)
      {
        int num1 = (int) MessageBox.Show(this.str35);
      }
      else if (e.KeyChar == '\r')
      {
        if (this.mm_in)
        {
          this.textBox7_TextChanged2((object) null, (EventArgs) null);
        }
        else
        {
          this.textBox8.Text = (Convert.ToDouble(this.textBox7.Text) / this.kg_bi).ToString().Substring(0, 5);
          this.xianzhi();
          this.gai_bian = true;
          this.panel1.Refresh();
          this.pan_yidong();
          this.bj = tu_xiang.qu_bian_jie2(this.diao.tu_pian);
          this.hua_biao_shi();
        }
      }
      else
      {
        if (e.KeyChar >= '0' && e.KeyChar <= '9' || (e.KeyChar == '\b' || e.KeyChar == '.') || e.KeyChar == '-')
          return;
        int num2 = (int) MessageBox.Show(this.str38);
        this.textBox1.Text = "";
        e.Handled = true;
      }
    }

    private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (this.kai_shi)
        return;
      if (this.checkBox2.Checked)
      {
        int num1 = (int) MessageBox.Show(this.str35);
      }
      else if (e.KeyChar == '\r')
      {
        if (this.mm_in)
        {
          this.textBox8_TextChanged2((object) null, (EventArgs) null);
        }
        else
        {
          this.textBox7.Text = (Convert.ToDouble(this.textBox8.Text) * this.kg_bi).ToString().Substring(0, 5);
          this.xianzhi();
          this.gai_bian = true;
          this.panel1.Refresh();
          this.pan_yidong();
          this.bj = tu_xiang.qu_bian_jie2(this.diao.tu_pian);
          this.hua_biao_shi();
        }
      }
      else
      {
        if (e.KeyChar >= '0' && e.KeyChar <= '9' || (e.KeyChar == '\b' || e.KeyChar == '.') || e.KeyChar == '-')
          return;
        int num2 = (int) MessageBox.Show(this.str38);
        this.textBox1.Text = "";
        e.Handled = true;
      }
    }

    private void button36_Click(object sender, EventArgs e)
    {
      if (this.diao.tu_pian == null)
        return;
      DateTime dateTime = new DateTime();
      DateTime now = DateTime.Now;
      string str1 = now.Month.ToString() + now.Day.ToString() + now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString();
      string str2 = Directory.GetCurrentDirectory() + "\\";
      try
      {
        this.diao.tu_pian.Save(str2 + str1 + ".bmp", ImageFormat.Bmp);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(this.str53 + "\r\n" + ex.ToString());
        return;
      }
      int num1 = (int) MessageBox.Show(this.str39 + str2 + str1 + ".bmp");
    }

    private void panel4_Paint(object sender, PaintEventArgs e)
    {
      Graphics graphics = this.panel4.CreateGraphics();
      graphics.DrawImage((Image) this.biao_shi_k, 0, 0);
      graphics.Dispose();
    }

    private void panel5_Paint(object sender, PaintEventArgs e)
    {
      Graphics graphics = this.panel5.CreateGraphics();
      graphics.DrawImage((Image) this.biao_shi_g, 0, 0);
      graphics.Dispose();
    }

    private void panel1_LocationChanged(object sender, EventArgs e)
    {
      this.hua_biao_shi();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.panel1 = new Panel();
      this.button10 = new Button();
      this.button9 = new Button();
      this.textBox2 = new TextBox();
      this.button18 = new Button();
      this.button19 = new Button();
      this.button1 = new Button();
      this.checkBox1 = new CheckBox();
      this.button2 = new Button();
      this.button3 = new Button();
      this.button6 = new Button();
      this.button7 = new Button();
      this.button8 = new Button();
      this.button4 = new Button();
      this.button5 = new Button();
      this.com = new SerialPort(this.components);
      this.dakai = new OpenFileDialog();
      this.da_kai_g = new OpenFileDialog();
      this.fontDialog1 = new FontDialog();
      this.panel2 = new Panel();
      this.panel3 = new Panel();
      this.button17 = new Button();
      this.jdt = new ProgressBar();
      this.button20 = new Button();
      this.button21 = new Button();
      this.button22 = new Button();
      this.button23 = new Button();
      this.trackBar3 = new TrackBar();
      this.button24 = new Button();
      this.button25 = new Button();
      this.button15 = new Button();
      this.label3 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.button16 = new Button();
      this.label6 = new Label();
      this.button27 = new Button();
      this.trackBar2 = new TrackBar();
      this.label2 = new Label();
      this.hei_bai = new RadioButton();
      this.li_san = new RadioButton();
      this.hui_du = new RadioButton();
      this.textBox3 = new TextBox();
      this.trackBar1 = new TrackBar();
      this.label1 = new Label();
      this.textBox1 = new TextBox();
      this.trackBar4 = new TrackBar();
      this.textBox5 = new TextBox();
      this.checkBox2 = new CheckBox();
      this.button11 = new Button();
      this.button12 = new Button();
      this.button13 = new Button();
      this.button14 = new Button();
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.groupBox3 = new GroupBox();
      this.textBox8 = new TextBox();
      this.textBox7 = new TextBox();
      this.label21 = new Label();
      this.label20 = new Label();
      this.label19 = new Label();
      this.label18 = new Label();
      this.button30 = new Button();
      this.button28 = new Button();
      this.button26 = new Button();
      this.label13 = new Label();
      this.textBox4 = new TextBox();
      this.label7 = new Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.button29 = new Button();
      this.button31 = new Button();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.button32 = new Button();
      this.timer2 = new System.Windows.Forms.Timer(this.components);
      this.label12 = new Label();
      this.timer3 = new System.Windows.Forms.Timer(this.components);
      this.groupBox4 = new GroupBox();
      this.button36 = new Button();
      this.button35 = new Button();
      this.panel6 = new Panel();
      this.label17 = new Label();
      this.label16 = new Label();
      this.radioButton4 = new RadioButton();
      this.radioButton3 = new RadioButton();
      this.radioButton2 = new RadioButton();
      this.radioButton5 = new RadioButton();
      this.listBox1 = new ListBox();
      this.trackBar5 = new TrackBar();
      this.groupBox5 = new GroupBox();
      this.toolTip1 = new ToolTip(this.components);
      this.panel4 = new Panel();
      this.panel5 = new Panel();
      this.button33 = new Button();
      this.button34 = new Button();
      this.panel2.SuspendLayout();
      this.trackBar3.BeginInit();
      this.trackBar2.BeginInit();
      this.trackBar1.BeginInit();
      this.trackBar4.BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.panel6.SuspendLayout();
      this.trackBar5.BeginInit();
      this.groupBox5.SuspendLayout();
      this.SuspendLayout();
      this.panel1.BackColor = Color.White;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Cursor = Cursors.SizeAll;
      this.panel1.Location = new Point(25, 60);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(247, 176);
      this.panel1.TabIndex = 1;
      this.panel1.TabStop = true;
      this.panel1.LocationChanged += new EventHandler(this.panel1_LocationChanged);
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
      this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
      this.panel1.MouseUp += new MouseEventHandler(this.panel1_MouseUp);
      this.button10.BackColor = Color.Transparent;
      this.button10.Cursor = Cursors.SizeAll;
      this.button10.DialogResult = DialogResult.Cancel;
      this.button10.Location = new Point(438, 187);
      this.button10.Name = "button10";
      this.button10.Size = new Size(17, 17);
      this.button10.TabIndex = 2;
      this.button10.UseVisualStyleBackColor = false;
      this.button10.Visible = false;
      this.button10.MouseDown += new MouseEventHandler(this.button10_MouseDown);
      this.button10.MouseMove += new MouseEventHandler(this.button10_MouseMove);
      this.button10.MouseUp += new MouseEventHandler(this.button10_MouseUp);
      this.button9.BackColor = Color.Transparent;
      this.button9.Cursor = Cursors.SizeNWSE;
      this.button9.Location = new Point(453, 203);
      this.button9.Name = "button9";
      this.button9.Size = new Size(17, 17);
      this.button9.TabIndex = 1;
      this.button9.UseVisualStyleBackColor = false;
      this.button9.Visible = false;
      this.button9.MouseDown += new MouseEventHandler(this.button9_MouseDown);
      this.button9.MouseMove += new MouseEventHandler(this.button9_MouseMove);
      this.button9.MouseUp += new MouseEventHandler(this.button9_MouseUp);
      this.textBox2.BorderStyle = BorderStyle.FixedSingle;
      this.textBox2.Cursor = Cursors.SizeAll;
      this.textBox2.Font = new Font("宋体", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox2.Location = new Point(278, 61);
      this.textBox2.Multiline = true;
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(177, 143);
      this.textBox2.TabIndex = 0;
      this.textBox2.Visible = false;
      this.textBox2.LocationChanged += new EventHandler(this.textBox2_LocationChanged);
      this.textBox2.MouseDown += new MouseEventHandler(this.textBox2_MouseDown);
      this.textBox2.MouseMove += new MouseEventHandler(this.textBox2_MouseMove);
      this.textBox2.MouseUp += new MouseEventHandler(this.textBox2_MouseUp);
      this.button18.Location = new Point(1001, 210);
      this.button18.Name = "button18";
      this.button18.Size = new Size(35, 35);
      this.button18.TabIndex = 30;
      this.button18.UseVisualStyleBackColor = true;
      this.button18.Visible = false;
      this.button18.Click += new EventHandler(this.button18_Click);
      this.button19.Location = new Point(984, 211);
      this.button19.Name = "button19";
      this.button19.Size = new Size(35, 35);
      this.button19.TabIndex = 31;
      this.button19.UseVisualStyleBackColor = true;
      this.button19.Visible = false;
      this.button19.Click += new EventHandler(this.button19_Click);
      this.button1.BackColor = Color.Transparent;
      this.button1.DialogResult = DialogResult.Cancel;
      this.button1.ForeColor = Color.Blue;
      this.button1.Location = new Point(532, 14);
      this.button1.Name = "button1";
      this.button1.Size = new Size(107, 32);
      this.button1.TabIndex = 1;
      this.button1.Text = "設備接続";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(949, 7);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(66, 16);
      this.checkBox1.TabIndex = 2;
      this.checkBox1.Text = "250*250";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.Visible = false;
      this.button2.BackColor = Color.Transparent;
      this.button2.Location = new Point(532, 52);
      this.button2.Name = "button2";
      this.button2.Size = new Size(107, 33);
      this.button2.TabIndex = 3;
      this.button2.Text = "絵図導入";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button3.BackColor = Color.Transparent;
      this.button3.ForeColor = Color.Red;
      this.button3.Location = new Point(825, 7);
      this.button3.Name = "button3";
      this.button3.Size = new Size(94, 30);
      this.button3.TabIndex = 4;
      this.button3.Text = "模拟发送错误";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button6.BackColor = Color.Transparent;
      this.button6.Location = new Point(917, 73);
      this.button6.Name = "button6";
      this.button6.Size = new Size(107, 30);
      this.button6.TabIndex = 6;
      this.button6.Text = "打开G代码";
      this.button6.UseVisualStyleBackColor = false;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.button7.BackColor = Color.Transparent;
      this.button7.Location = new Point(994, 105);
      this.button7.Name = "button7";
      this.button7.Size = new Size(107, 30);
      this.button7.TabIndex = 11;
      this.button7.Text = "快进>>";
      this.button7.UseVisualStyleBackColor = false;
      this.button7.Click += new EventHandler(this.button7_Click);
      this.button8.BackColor = Color.Transparent;
      this.button8.Location = new Point(917, 109);
      this.button8.Name = "button8";
      this.button8.Size = new Size(107, 30);
      this.button8.TabIndex = 10;
      this.button8.Text = "<<快退";
      this.button8.UseVisualStyleBackColor = false;
      this.button8.Click += new EventHandler(this.button8_Click);
      this.button4.BackColor = Color.Transparent;
      this.button4.ForeColor = Color.Red;
      this.button4.Location = new Point(532, 91);
      this.button4.Name = "button4";
      this.button4.Size = new Size(71, 36);
      this.button4.TabIndex = 12;
      this.button4.Text = "スタート";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.button4.MouseDown += new MouseEventHandler(this.button4_MouseDown);
      this.button4.MouseUp += new MouseEventHandler(this.button4_MouseUp);
      this.button5.BackColor = Color.Transparent;
      this.button5.Location = new Point(655, 52);
      this.button5.Name = "button5";
      this.button5.Size = new Size(107, 33);
      this.button5.TabIndex = 13;
      this.button5.Text = "文字編集";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.com.ErrorReceived += new SerialErrorReceivedEventHandler(this.com_ErrorReceived);
      this.com.DataReceived += new SerialDataReceivedEventHandler(this.com_DataReceived);
      this.dakai.FileName = "openFileDialog1";
      this.dakai.Filter = "ビットマップファイル|*.bmp;*.jpg;*.jpge;*.png;";
      this.da_kai_g.FileName = "openFileDialog1";
      this.da_kai_g.Filter = "刀路文件|*.NC|所有文件|*.*";
      this.fontDialog1.Font = new Font("宋体", 24f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImage = (Image) componentResourceManager.GetObject("panel2.BackgroundImage");
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.Controls.Add((Control) this.panel3);
      this.panel2.Location = new Point(692, 14);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(32, 32);
      this.panel2.TabIndex = 23;
      this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);
      this.panel3.BackColor = Color.Transparent;
      this.panel3.BackgroundImage = (Image) componentResourceManager.GetObject("panel3.BackgroundImage");
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.Location = new Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(32, 32);
      this.panel3.TabIndex = 44;
      this.panel3.Visible = false;
      this.button17.BackColor = Color.Transparent;
      this.button17.Location = new Point(962, 387);
      this.button17.Name = "button17";
      this.button17.Size = new Size(215, 38);
      this.button17.TabIndex = 28;
      this.button17.Text = "发送脱机数据";
      this.button17.UseVisualStyleBackColor = false;
      this.button17.Click += new EventHandler(this.button17_Click);
      this.jdt.Location = new Point(963, 427);
      this.jdt.Name = "jdt";
      this.jdt.Size = new Size(213, 10);
      this.jdt.TabIndex = 29;
      this.jdt.Visible = false;
      this.button20.BackColor = Color.Transparent;
      this.button20.Image = (Image) componentResourceManager.GetObject("button20.Image");
      this.button20.Location = new Point(178, 9);
      this.button20.Name = "button20";
      this.button20.Size = new Size(35, 35);
      this.button20.TabIndex = 32;
      this.button20.UseVisualStyleBackColor = false;
      this.button20.Click += new EventHandler(this.button20_Click);
      this.button21.BackColor = Color.Transparent;
      this.button21.Image = (Image) componentResourceManager.GetObject("button21.Image");
      this.button21.Location = new Point(25, 9);
      this.button21.Name = "button21";
      this.button21.Size = new Size(35, 35);
      this.button21.TabIndex = 33;
      this.button21.UseVisualStyleBackColor = false;
      this.button21.Click += new EventHandler(this.button21_Click);
      this.button22.BackColor = Color.Transparent;
      this.button22.Image = (Image) componentResourceManager.GetObject("button22.Image");
      this.button22.Location = new Point(76, 9);
      this.button22.Name = "button22";
      this.button22.Size = new Size(35, 35);
      this.button22.TabIndex = 34;
      this.button22.UseVisualStyleBackColor = false;
      this.button22.Click += new EventHandler(this.button22_Click);
      this.button23.BackColor = Color.Transparent;
      this.button23.Image = (Image) componentResourceManager.GetObject("button23.Image");
      this.button23.Location = new Point(928, 29);
      this.button23.Name = "button23";
      this.button23.Size = new Size(35, 35);
      this.button23.TabIndex = 35;
      this.button23.UseVisualStyleBackColor = false;
      this.button23.Click += new EventHandler(this.button23_Click);
      this.trackBar3.AutoSize = false;
      this.trackBar3.Location = new Point(924, 526);
      this.trackBar3.Maximum = 3200;
      this.trackBar3.Name = "trackBar3";
      this.trackBar3.Size = new Size(136, 31);
      this.trackBar3.TabIndex = 36;
      this.trackBar3.Value = 1650;
      this.trackBar3.MouseUp += new MouseEventHandler(this.trackBar3_MouseUp);
      this.button24.BackColor = Color.Transparent;
      this.button24.Location = new Point(690, 91);
      this.button24.Name = "button24";
      this.button24.Size = new Size(71, 36);
      this.button24.TabIndex = 37;
      this.button24.Text = "停止";
      this.button24.UseVisualStyleBackColor = false;
      this.button24.Click += new EventHandler(this.button24_Click);
      this.button25.BackColor = Color.Transparent;
      this.button25.Image = (Image) componentResourceManager.GetObject("button25.Image");
      this.button25.Location = new Point((int) sbyte.MaxValue, 9);
      this.button25.Name = "button25";
      this.button25.Size = new Size(35, 35);
      this.button25.TabIndex = 31;
      this.button25.UseVisualStyleBackColor = false;
      this.button25.Click += new EventHandler(this.button25_Click);
      this.button15.BackColor = Color.Transparent;
      this.button15.Image = (Image) componentResourceManager.GetObject("button15.Image");
      this.button15.Location = new Point(280, 9);
      this.button15.Name = "button15";
      this.button15.Size = new Size(35, 35);
      this.button15.TabIndex = 31;
      this.button15.UseVisualStyleBackColor = false;
      this.button15.Click += new EventHandler(this.button15_Click_1);
      this.label3.AutoSize = true;
      this.label3.FlatStyle = FlatStyle.Popup;
      this.label3.Font = new Font("宋体", 13f);
      this.label3.Location = new Point(875, 534);
      this.label3.Name = "label3";
      this.label3.Size = new Size(44, 18);
      this.label3.TabIndex = 32;
      this.label3.Text = "缩放";
      this.label5.BorderStyle = BorderStyle.FixedSingle;
      this.label5.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label5.ForeColor = Color.Blue;
      this.label5.Location = new Point(1013, 509);
      this.label5.Name = "label5";
      this.label5.Size = new Size(92, 31);
      this.label5.TabIndex = 41;
      this.label5.Text = "Y：";
      this.label4.BorderStyle = BorderStyle.FixedSingle;
      this.label4.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label4.ForeColor = Color.Blue;
      this.label4.Location = new Point(952, 479);
      this.label4.Name = "label4";
      this.label4.Size = new Size(92, 31);
      this.label4.TabIndex = 42;
      this.label4.Text = "X：";
      this.button16.BackColor = Color.Transparent;
      this.button16.ForeColor = Color.Red;
      this.button16.Location = new Point(928, 145);
      this.button16.Name = "button16";
      this.button16.Size = new Size(53, 30);
      this.button16.TabIndex = 43;
      this.button16.Text = "开始";
      this.button16.UseVisualStyleBackColor = false;
      this.button16.Visible = false;
      this.button16.Click += new EventHandler(this.button16_Click_1);
      this.label6.AutoSize = true;
      this.label6.Location = new Point(954, 289);
      this.label6.Name = "label6";
      this.label6.Size = new Size(65, 12);
      this.label6.TabIndex = 47;
      this.label6.Text = "激光功率：";
      this.button27.BackColor = Color.Transparent;
      this.button27.BackgroundImageLayout = ImageLayout.Stretch;
      this.button27.Image = (Image) componentResourceManager.GetObject("button27.Image");
      this.button27.Location = new Point(229, 9);
      this.button27.Name = "button27";
      this.button27.Size = new Size(35, 35);
      this.button27.TabIndex = 52;
      this.button27.UseVisualStyleBackColor = false;
      this.button27.Click += new EventHandler(this.button27_Click);
      this.trackBar2.Location = new Point(3, 20);
      this.trackBar2.Maximum = 253;
      this.trackBar2.Name = "trackBar2";
      this.trackBar2.Size = new Size(190, 45);
      this.trackBar2.TabIndex = 16;
      this.trackBar2.Value = 128;
      this.trackBar2.Scroll += new EventHandler(this.trackBar2_Scroll);
      this.trackBar2.MouseUp += new MouseEventHandler(this.trackBar2_MouseUp);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(869, 244);
      this.label2.Name = "label2";
      this.label2.Size = new Size(65, 12);
      this.label2.TabIndex = 17;
      this.label2.Text = "絵図調整：";
      this.label2.Visible = false;
      this.hei_bai.AutoSize = true;
      this.hei_bai.Checked = true;
      this.hei_bai.Location = new Point(6, 24);
      this.hei_bai.Name = "hei_bai";
      this.hei_bai.Size = new Size(47, 16);
      this.hei_bai.TabIndex = 49;
      this.hei_bai.TabStop = true;
      this.hei_bai.Text = "黒白";
      this.hei_bai.UseVisualStyleBackColor = true;
      this.hei_bai.CheckedChanged += new EventHandler(this.hei_bai_CheckedChanged);
      this.li_san.AutoSize = true;
      this.li_san.Location = new Point(6, 43);
      this.li_san.Name = "li_san";
      this.li_san.Size = new Size(47, 16);
      this.li_san.TabIndex = 50;
      this.li_san.Text = "离散";
      this.li_san.UseVisualStyleBackColor = true;
      this.li_san.CheckedChanged += new EventHandler(this.li_san_CheckedChanged);
      this.li_san.MouseDown += new MouseEventHandler(this.li_san_MouseDown);
      this.hui_du.AutoSize = true;
      this.hui_du.Location = new Point(129, 24);
      this.hui_du.Name = "hui_du";
      this.hui_du.Size = new Size(107, 16);
      this.hui_du.TabIndex = 51;
      this.hui_du.Text = "グレースケール";
      this.hui_du.UseVisualStyleBackColor = true;
      this.hui_du.CheckedChanged += new EventHandler(this.hui_du_CheckedChanged);
      this.textBox3.BackColor = Color.Gainsboro;
      this.textBox3.BorderStyle = BorderStyle.None;
      this.textBox3.Location = new Point(195, 23);
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      this.textBox3.Size = new Size(33, 14);
      this.textBox3.TabIndex = 18;
      this.textBox3.Text = "128";
      this.textBox3.TextAlign = HorizontalAlignment.Center;
      this.textBox3.TextChanged += new EventHandler(this.textBox3_TextChanged);
      this.trackBar1.Location = new Point(6, 20);
      this.trackBar1.Maximum = 100;
      this.trackBar1.Minimum = 1;
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new Size(191, 45);
      this.trackBar1.TabIndex = 8;
      this.trackBar1.Value = 10;
      this.trackBar1.Scroll += new EventHandler(this.trackBar1_Scroll);
      this.trackBar1.MouseUp += new MouseEventHandler(this.trackBar1_MouseUp);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(869, 371);
      this.label1.Name = "label1";
      this.label1.Size = new Size(101, 12);
      this.label1.TabIndex = 9;
      this.label1.Text = "彫刻の深さ調整：";
      this.label1.Visible = false;
      this.textBox1.BackColor = Color.Gainsboro;
      this.textBox1.BorderStyle = BorderStyle.None;
      this.textBox1.Location = new Point(195, 23);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(33, 14);
      this.textBox1.TabIndex = 14;
      this.textBox1.Text = "10";
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.trackBar4.Location = new Point(12, 15);
      this.trackBar4.Maximum = 100;
      this.trackBar4.Name = "trackBar4";
      this.trackBar4.Size = new Size(175, 45);
      this.trackBar4.TabIndex = 46;
      this.trackBar4.Value = 100;
      this.trackBar4.Scroll += new EventHandler(this.trackBar4_Scroll);
      this.textBox5.BackColor = Color.Gainsboro;
      this.textBox5.BorderStyle = BorderStyle.None;
      this.textBox5.Location = new Point(191, 15);
      this.textBox5.Name = "textBox5";
      this.textBox5.ReadOnly = true;
      this.textBox5.Size = new Size(35, 14);
      this.textBox5.TabIndex = 48;
      this.textBox5.Text = "100";
      this.textBox5.TextAlign = HorizontalAlignment.Center;
      this.textBox5.TextChanged += new EventHandler(this.textBox5_TextChanged);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(866, 404);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(60, 16);
      this.checkBox2.TabIndex = 15;
      this.checkBox2.Text = "框定位";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.Visible = false;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.button11.BackColor = Color.Transparent;
      this.button11.DialogResult = DialogResult.Cancel;
      this.button11.Location = new Point(82, 62);
      this.button11.Name = "button11";
      this.button11.Size = new Size(67, 35);
      this.button11.TabIndex = 19;
      this.button11.Text = "↑";
      this.button11.UseVisualStyleBackColor = false;
      this.button11.Click += new EventHandler(this.button11_Click);
      this.button12.BackColor = Color.Transparent;
      this.button12.Location = new Point(82, 141);
      this.button12.Name = "button12";
      this.button12.Size = new Size(67, 35);
      this.button12.TabIndex = 20;
      this.button12.Text = "↓";
      this.button12.UseVisualStyleBackColor = false;
      this.button12.Click += new EventHandler(this.button12_Click);
      this.button13.BackColor = Color.Transparent;
      this.button13.Location = new Point(9, 101);
      this.button13.Name = "button13";
      this.button13.Size = new Size(67, 35);
      this.button13.TabIndex = 21;
      this.button13.Text = "←";
      this.button13.UseVisualStyleBackColor = false;
      this.button13.Click += new EventHandler(this.button13_Click);
      this.button14.BackColor = Color.Transparent;
      this.button14.Location = new Point(155, 101);
      this.button14.Name = "button14";
      this.button14.Size = new Size(67, 35);
      this.button14.TabIndex = 22;
      this.button14.Text = "→";
      this.button14.UseVisualStyleBackColor = false;
      this.button14.Click += new EventHandler(this.button14_Click);
      this.groupBox1.Controls.Add((Control) this.hui_du);
      this.groupBox1.Controls.Add((Control) this.li_san);
      this.groupBox1.Controls.Add((Control) this.hei_bai);
      this.groupBox1.Location = new Point(532, 131);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(231, 65);
      this.groupBox1.TabIndex = 53;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "彫刻スタイル選択";
      this.groupBox2.Controls.Add((Control) this.textBox1);
      this.groupBox2.Controls.Add((Control) this.trackBar1);
      this.groupBox2.Location = new Point(532, 301);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(230, 50);
      this.groupBox2.TabIndex = 54;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "レーザー彫刻パラメータ調整";
      this.groupBox3.Controls.Add((Control) this.textBox8);
      this.groupBox3.Controls.Add((Control) this.textBox7);
      this.groupBox3.Controls.Add((Control) this.label21);
      this.groupBox3.Controls.Add((Control) this.label20);
      this.groupBox3.Controls.Add((Control) this.label19);
      this.groupBox3.Controls.Add((Control) this.label18);
      this.groupBox3.Controls.Add((Control) this.button30);
      this.groupBox3.Controls.Add((Control) this.button28);
      this.groupBox3.Controls.Add((Control) this.button26);
      this.groupBox3.Controls.Add((Control) this.button14);
      this.groupBox3.Controls.Add((Control) this.button13);
      this.groupBox3.Controls.Add((Control) this.button12);
      this.groupBox3.Controls.Add((Control) this.button11);
      this.groupBox3.Location = new Point(534, 357);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(229, 204);
      this.groupBox3.TabIndex = 55;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "レーザー位置調整";
      this.groupBox3.Enter += new EventHandler(this.groupBox3_Enter);
      this.textBox8.Location = new Point(156, 178);
      this.textBox8.Name = "textBox8";
      this.textBox8.Size = new Size(46, 21);
      this.textBox8.TabIndex = 30;
      this.textBox8.Text = "10";
      this.textBox8.KeyPress += new KeyPressEventHandler(this.textBox8_KeyPress);
      this.textBox7.Location = new Point(41, 178);
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new Size(46, 21);
      this.textBox7.TabIndex = 29;
      this.textBox7.Text = "10";
      this.textBox7.KeyPress += new KeyPressEventHandler(this.textBox7_KeyPress);
      this.label21.AutoSize = true;
      this.label21.Location = new Point(206, 183);
      this.label21.Name = "label21";
      this.label21.Size = new Size(17, 12);
      this.label21.TabIndex = 38;
      this.label21.Text = "MM";
      this.label20.AutoSize = true;
      this.label20.Location = new Point(91, 183);
      this.label20.Name = "label20";
      this.label20.Size = new Size(17, 12);
      this.label20.TabIndex = 37;
      this.label20.Text = "MM";
      this.label19.AutoSize = true;
      this.label19.Location = new Point(119, 181);
      this.label19.Name = "label19";
      this.label19.Size = new Size(41, 12);
      this.label19.TabIndex = 36;
      this.label19.Text = "高度：";
      this.label18.AutoSize = true;
      this.label18.Location = new Point(6, 181);
      this.label18.Name = "label18";
      this.label18.Size = new Size(41, 12);
      this.label18.TabIndex = 35;
      this.label18.Text = "宽度：";
      this.button30.BackColor = Color.Transparent;
      this.button30.Location = new Point(82, 101);
      this.button30.Name = "button30";
      this.button30.Size = new Size(67, 34);
      this.button30.TabIndex = 28;
      this.button30.Text = "中心に戻る";
      this.button30.UseVisualStyleBackColor = false;
      this.button30.Click += new EventHandler(this.button30_Click);
      this.button28.BackColor = Color.Transparent;
      this.button28.Location = new Point(37, 20);
      this.button28.Name = "button28";
      this.button28.Size = new Size(75, 36);
      this.button28.TabIndex = 26;
      this.button28.Text = "彫刻範囲プレビュー";
      this.button28.UseVisualStyleBackColor = false;
      this.button28.Click += new EventHandler(this.button28_Click);
      this.button26.BackColor = Color.Transparent;
      this.button26.Location = new Point(117, 20);
      this.button26.Name = "button26";
      this.button26.Size = new Size(75, 36);
      this.button26.TabIndex = 25;
      this.button26.Text = "原点に戻る";
      this.button26.UseVisualStyleBackColor = false;
      this.button26.Click += new EventHandler(this.button26_Click_1);
      this.label13.AutoSize = true;
      this.label13.FlatStyle = FlatStyle.Popup;
      this.label13.Font = new Font("宋体", 13f);
      this.label13.Location = new Point(1034, 538);
      this.label13.Name = "label13";
      this.label13.Size = new Size(44, 18);
      this.label13.TabIndex = 37;
      this.label13.Text = "缩放";
      this.label13.Click += new EventHandler(this.label13_Click);
      this.textBox4.CausesValidation = false;
      this.textBox4.Location = new Point(866, 318);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(53, 21);
      this.textBox4.TabIndex = 24;
      this.textBox4.Text = "20";
      this.textBox4.TextAlign = HorizontalAlignment.Center;
      this.textBox4.TextChanged += new EventHandler(this.textBox4_TextChanged);
      this.textBox4.KeyPress += new KeyPressEventHandler(this.textBox4_KeyPress);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(851, 420);
      this.label7.Name = "label7";
      this.label7.Size = new Size(53, 12);
      this.label7.TabIndex = 27;
      this.label7.Text = "步进值：";
      this.label7.Visible = false;
      this.label7.Click += new EventHandler(this.label7_Click);
      this.timer1.Enabled = true;
      this.timer1.Interval = 300;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.button29.BackColor = Color.Transparent;
      this.button29.ForeColor = Color.Blue;
      this.button29.Location = new Point(611, 91);
      this.button29.Name = "button29";
      this.button29.Size = new Size(71, 36);
      this.button29.TabIndex = 56;
      this.button29.Text = "一時停止";
      this.button29.UseVisualStyleBackColor = false;
      this.button29.Click += new EventHandler(this.button29_Click);
      this.button29.MouseDown += new MouseEventHandler(this.button29_MouseDown);
      this.button31.Location = new Point(871, 278);
      this.button31.Name = "button31";
      this.button31.Size = new Size(55, 19);
      this.button31.TabIndex = 57;
      this.button31.Text = "button31";
      this.button31.UseVisualStyleBackColor = true;
      this.button31.Visible = false;
      this.button31.Click += new EventHandler(this.button31_Click);
      this.label8.BackColor = Color.Black;
      this.label8.Location = new Point(25, 60);
      this.label8.Name = "label8";
      this.label8.Size = new Size(500, 1);
      this.label8.TabIndex = 58;
      this.label8.Text = "label8";
      this.label9.BackColor = Color.Black;
      this.label9.Location = new Point(25, 560);
      this.label9.Name = "label9";
      this.label9.Size = new Size(500, 1);
      this.label9.TabIndex = 59;
      this.label9.Text = "label9";
      this.label10.BackColor = Color.Black;
      this.label10.Location = new Point(25, 60);
      this.label10.Name = "label10";
      this.label10.Size = new Size(1, 500);
      this.label10.TabIndex = 60;
      this.label10.Text = "label10";
      this.label11.BackColor = Color.Black;
      this.label11.Location = new Point(525, 60);
      this.label11.Name = "label11";
      this.label11.Size = new Size(1, 500);
      this.label11.TabIndex = 61;
      this.label11.Text = "label11";
      this.button32.BackColor = Color.Transparent;
      this.button32.Font = new Font("宋体", 20f);
      this.button32.Image = (Image) componentResourceManager.GetObject("button32.Image");
      this.button32.Location = new Point(331, 9);
      this.button32.Name = "button32";
      this.button32.Size = new Size(35, 35);
      this.button32.TabIndex = 62;
      this.button32.UseVisualStyleBackColor = false;
      this.button32.Click += new EventHandler(this.button32_Click);
      this.timer2.Enabled = true;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Location = new Point(32, 543);
      this.label12.Name = "label12";
      this.label12.Size = new Size(0, 12);
      this.label12.TabIndex = 63;
      this.timer3.Interval = 1000;
      this.timer3.Tick += new EventHandler(this.timer3_Tick);
      this.groupBox4.Controls.Add((Control) this.trackBar4);
      this.groupBox4.Controls.Add((Control) this.textBox5);
      this.groupBox4.Location = new Point(532, 251);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(231, 50);
      this.groupBox4.TabIndex = 64;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "レーザー彫刻パラメータ調整";
      this.button36.BackColor = Color.Transparent;
      this.button36.Font = new Font("宋体", 20f);
      this.button36.Image = (Image) componentResourceManager.GetObject("button36.Image");
      this.button36.Location = new Point(484, 9);
      this.button36.Name = "button36";
      this.button36.Size = new Size(35, 35);
      this.button36.TabIndex = 76;
      this.button36.UseVisualStyleBackColor = false;
      this.button36.Click += new EventHandler(this.button36_Click);
      this.button35.BackColor = Color.Transparent;
      this.button35.Font = new Font("宋体", 20f);
      this.button35.Image = (Image) componentResourceManager.GetObject("button35.Image");
      this.button35.Location = new Point(382, 9);
      this.button35.Name = "button35";
      this.button35.Size = new Size(35, 35);
      this.button35.TabIndex = 75;
      this.button35.UseVisualStyleBackColor = false;
      this.button35.Click += new EventHandler(this.button35_Click);
      this.panel6.BorderStyle = BorderStyle.FixedSingle;
      this.panel6.Controls.Add((Control) this.label17);
      this.panel6.Controls.Add((Control) this.label16);
      this.panel6.Controls.Add((Control) this.radioButton4);
      this.panel6.Controls.Add((Control) this.radioButton3);
      this.panel6.Controls.Add((Control) this.radioButton2);
      this.panel6.Controls.Add((Control) this.radioButton5);
      this.panel6.Controls.Add((Control) this.listBox1);
      this.panel6.Controls.Add((Control) this.trackBar5);
      this.panel6.Location = new Point((int) sbyte.MaxValue, 271);
      this.panel6.Name = "panel6";
      this.panel6.Size = new Size(303, 290);
      this.panel6.TabIndex = 77;
      this.panel6.Visible = false;
      this.label17.AutoSize = true;
      this.label17.Location = new Point(14, 35);
      this.label17.Name = "label17";
      this.label17.Size = new Size(17, 12);
      this.label17.TabIndex = 13;
      this.label17.Text = "16";
      this.label16.BackColor = Color.FromArgb(128, (int) byte.MaxValue, (int) byte.MaxValue);
      this.label16.Location = new Point(0, 0);
      this.label16.Name = "label16";
      this.label16.Size = new Size(303, 24);
      this.label16.TabIndex = 12;
      this.label16.Text = "字体选择";
      this.label16.TextAlign = ContentAlignment.MiddleCenter;
      this.label16.MouseDown += new MouseEventHandler(this.label16_MouseDown);
      this.label16.MouseMove += new MouseEventHandler(this.label16_MouseMove);
      this.label16.MouseUp += new MouseEventHandler(this.label16_MouseUp);
      this.radioButton4.AutoSize = true;
      this.radioButton4.Location = new Point(198, 253);
      this.radioButton4.Name = "radioButton4";
      this.radioButton4.Size = new Size(71, 16);
      this.radioButton4.TabIndex = 11;
      this.radioButton4.Text = "粗体斜体";
      this.radioButton4.UseVisualStyleBackColor = true;
      this.radioButton4.CheckedChanged += new EventHandler(this.radioButton4_CheckedChanged);
      this.radioButton3.AutoSize = true;
      this.radioButton3.Location = new Point(198, 192);
      this.radioButton3.Name = "radioButton3";
      this.radioButton3.Size = new Size(47, 16);
      this.radioButton3.TabIndex = 10;
      this.radioButton3.Text = "斜体";
      this.radioButton3.UseVisualStyleBackColor = true;
      this.radioButton3.CheckedChanged += new EventHandler(this.radioButton3_CheckedChanged);
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new Point(198, 131);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new Size(47, 16);
      this.radioButton2.TabIndex = 9;
      this.radioButton2.Text = "粗体";
      this.radioButton2.UseVisualStyleBackColor = true;
      this.radioButton2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
      this.radioButton5.AutoSize = true;
      this.radioButton5.Checked = true;
      this.radioButton5.Location = new Point(198, 70);
      this.radioButton5.Name = "radioButton5";
      this.radioButton5.Size = new Size(47, 16);
      this.radioButton5.TabIndex = 8;
      this.radioButton5.TabStop = true;
      this.radioButton5.Text = "常规";
      this.radioButton5.UseVisualStyleBackColor = true;
      this.radioButton5.CheckedChanged += new EventHandler(this.radioButton5_CheckedChanged);
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 12;
      this.listBox1.Location = new Point(20, 68);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(172, 208);
      this.listBox1.TabIndex = 7;
      this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
      this.trackBar5.Location = new Point(38, 29);
      this.trackBar5.Maximum = 100;
      this.trackBar5.Minimum = 1;
      this.trackBar5.Name = "trackBar5";
      this.trackBar5.Size = new Size(244, 45);
      this.trackBar5.TabIndex = 6;
      this.trackBar5.TickStyle = TickStyle.None;
      this.trackBar5.Value = 16;
      this.trackBar5.Scroll += new EventHandler(this.trackBar5_Scroll);
      this.groupBox5.Controls.Add((Control) this.textBox3);
      this.groupBox5.Controls.Add((Control) this.trackBar2);
      this.groupBox5.Location = new Point(532, 191);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(231, 57);
      this.groupBox5.TabIndex = 78;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "groupBox5";
      this.toolTip1.IsBalloon = true;
      this.panel4.Location = new Point(29, 43);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(76, 17);
      this.panel4.TabIndex = 79;
      this.panel4.Paint += new PaintEventHandler(this.panel4_Paint);
      this.panel5.Location = new Point(8, 203);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(17, 77);
      this.panel5.TabIndex = 80;
      this.panel5.Paint += new PaintEventHandler(this.panel5_Paint);
      this.button33.BackColor = Color.Transparent;
      this.button33.Font = new Font("宋体", 20f);
      this.button33.Image = (Image) componentResourceManager.GetObject("button33.Image");
      this.button33.Location = new Point(433, 9);
      this.button33.Name = "button33";
      this.button33.Size = new Size(35, 35);
      this.button33.TabIndex = 81;
      this.button33.UseVisualStyleBackColor = false;
      this.button33.Click += new EventHandler(this.button33_Click);
      this.button34.BackColor = Color.Transparent;
      this.button34.ForeColor = Color.Red;
      this.button34.Location = new Point(825, 43);
      this.button34.Name = "button34";
      this.button34.Size = new Size(94, 30);
      this.button34.TabIndex = 82;
      this.button34.Text = "模拟接收错误";
      this.button34.UseVisualStyleBackColor = false;
      this.button34.Click += new EventHandler(this.button34_Click);
      this.AllowDrop = true;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Gainsboro;
      this.ClientSize = new Size(769, 567);
      this.Controls.Add((Control) this.button34);
      this.Controls.Add((Control) this.button33);
      this.Controls.Add((Control) this.panel5);
      this.Controls.Add((Control) this.panel4);
      this.Controls.Add((Control) this.panel6);
      this.Controls.Add((Control) this.groupBox5);
      this.Controls.Add((Control) this.label13);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.button36);
      this.Controls.Add((Control) this.button35);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.button32);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.trackBar3);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.button31);
      this.Controls.Add((Control) this.button10);
      this.Controls.Add((Control) this.button29);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.button9);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.button27);
      this.Controls.Add((Control) this.button16);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.button18);
      this.Controls.Add((Control) this.button19);
      this.Controls.Add((Control) this.button15);
      this.Controls.Add((Control) this.button25);
      this.Controls.Add((Control) this.button24);
      this.Controls.Add((Control) this.button23);
      this.Controls.Add((Control) this.button22);
      this.Controls.Add((Control) this.button21);
      this.Controls.Add((Control) this.button20);
      this.Controls.Add((Control) this.jdt);
      this.Controls.Add((Control) this.button17);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button7);
      this.Controls.Add((Control) this.button8);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.groupBox4);
      this.Controls.Add((Control) this.groupBox2);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (Form1);
      this.Text = "激光雕刻机";
      this.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new EventHandler(this.Form1_Load);
      this.DragDrop += new DragEventHandler(this.Form1_DragDrop);
      this.DragEnter += new DragEventHandler(this.Form1_DragEnter);
      this.panel2.ResumeLayout(false);
      this.trackBar3.EndInit();
      this.trackBar2.EndInit();
      this.trackBar1.EndInit();
      this.trackBar4.EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      this.trackBar5.EndInit();
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public delegate void MyInvoke();

    public struct wen_ben
    {
      public Bitmap wen_zi;
      public Point diao;
    }

    [Flags]
    private enum ExecutionFlag : uint
    {
      System = 1,
      Display = 2,
      Continus = 2147483648, // 0x80000000
    }
  }
}
