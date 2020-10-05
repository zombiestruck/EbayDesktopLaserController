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
		public delegate void MyInvoke();

		public struct wen_ben
		{
			public Bitmap wen_zi;

			public Point diao;
		}

		[Flags]
		private enum ExecutionFlag : uint
		{
			System = 0x1,
			Display = 0x2,
			Continus = 0x80000000
		}

		private diao_ke_ji diao;

		public int dx;

		public int dy;

		private int[] zysx = new int[4];

		private int zhuang_tai;

		private Point[] zhixian = new Point[0];

		private string wenben = "";

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

		private int[] hua_kg = new int[2];

		private string wen_jian_ming = "";

		private bool feng_shang;

		private bool zan_ting;

		private bool zan_ting2;

		private bool an_xia;

		private Point yi_dian;

		private bool bjk_anxia;

		private int bjk_x;

		private int bjk_y;

		private Point wz_weizhi = new Point(0, 0);

		private Bitmap w_z;

		private bool wzms = true;

		private int hei_dian_shu;

		private int miao60;

		private bool diyi = true;

		private double kg_bi;

		private int[] bj = new int[4];

		private int[] bj2 = new int[4];

		private double bai_bian_k;

		private double bai_bian_g;

		private Bitmap biao_shi_k = new Bitmap(1, 1);

		private Bitmap biao_shi_g = new Bitmap(1, 1);

		private Bitmap tu_pian2 = new Bitmap(1, 1);

		private bool zhong_xin;

		private bool mm_in = true;

		private bool cuo_wu;

		private bool cuo_wu2;

		private int jd;

		private bool xs;

		private bool flash_0;

		private bool fs_wc;

		private bool tj;

		private bool banben;

		private int v_zhu;

		private int v_fu;

		private int v_xing;

		private static string vv = "v1.8";

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

		private string str28 = "Laser engraving machine " + vv;

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

		private Button button37;

		private Panel panel7;

		private Label label14;

		private ProgressBar progressBar1;

		private System.Windows.Forms.Timer timer_flash;

		private TrackBar trackBar3;

		private void shu_xin()
		{
			if (!an_xia)
			{
				quan_bu_shua_xin();
			}
		}

		private void shuxin()
		{
			MyInvoke method = shu_xin;
			BeginInvoke(method);
		}

		private void jin_du()
		{
			if (xs)
			{
				if (flash_0)
				{
					flash_0 = false;
					jd = 0;
				}
				progressBar1.Value = jd;
				panel7.Visible = true;
				label14.Text = jd + "%";
			}
			else
			{
				progressBar1.Value = jd;
				panel7.Visible = false;
				label14.Text = jd + "%";
				timer3.Enabled = false;
				label12.Visible = true;
			}
		}

		private void jidu()
		{
			MyInvoke method = jin_du;
			BeginInvoke(method);
		}

		public Form1()
		{
			InitializeComponent();
		}

		private bool is_tj()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			com.DiscardInBuffer();
			try
			{
				com.Write(new byte[4]
				{
					255,
					0,
					4,
					0
				}, 0, 4);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 10;
			banben = true;
			while (0 < num--)
			{
				Thread.Sleep(10);
				diao_ke_ji.处理事件();
				if (!banben)
				{
					Thread.Sleep(100);
					break;
				}
			}
			double num2 = (double)v_zhu + (double)v_fu * 0.1;
			if (v_xing == 3)
			{
				if (num2 > 1.4)
				{
					return true;
				}
				return false;
			}
			if (v_xing == 4)
			{
				if (num2 >= 1.7)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (button1.Text == str2)
			{
				if (diao.lian_jie())
				{
					timer2.Enabled = true;
					panel3.Visible = true;
					button1.Text = str3;
					panel2.Refresh();
					diao.x = 0;
					diao.y = 0;
					dx = 0;
					dy = 0;
					x = 0;
					y = 0;
					panel1.Location = new Point(25, 60);
					x = 0;
					y = 0;
					tj = is_tj();
				}
				else
				{
					MessageBox.Show(str27);
				}
			}
			else
			{
				if (checkBox2.Checked)
				{
					diao.guan_kuang();
				}
				_ = kai_shi;
				timer2.Enabled = false;
				com.Close();
				diao.lianjie = false;
				panel3.Visible = false;
				button1.Text = str2;
				panel2.Refresh();
			}
		}

		private void suo_fang2(Bitmap bb2, int da)
		{
			int num = 0;
			int num2 = 0;
			double num3 = 0.0;
			if (bb2.Width > bb2.Height)
			{
				num2 = bb2.Width + (trackBar3.Value - 1600);
				if (num2 < 10)
				{
					num2 = 10;
				}
				if (num2 > da)
				{
					num2 = da;
				}
				num3 = (double)bb2.Width * 1.0 / (double)num2;
				num = (int)((double)bb2.Height / num3);
				diao.tu = tu_xiang.suofang(bb2, num2, num);
			}
			else
			{
				num = bb2.Height + (trackBar3.Value - 1600);
				if (num < 10)
				{
					num = 10;
				}
				if (num > da)
				{
					num = da;
				}
				num3 = (double)bb2.Height * 1.0 / (double)num;
				num2 = (int)((double)bb2.Width / num3);
				diao.tu = tu_xiang.suofang(bb2, num2, num);
			}
		}

		private void suo_fang(Bitmap bb2)
		{
			if (bb2 == null)
			{
				return;
			}
			if (textBox7.Text != "" && textBox8.Text != "")
			{
				int num = 0;
				int num2 = 0;
				if (mm_in)
				{
					num = (int)(Convert.ToDouble(textBox7.Text) / 0.05);
					_ = Convert.ToDouble(textBox8.Text) / 0.05;
				}
				else
				{
					num = (int)(Convert.ToDouble(textBox7.Text) / 0.001968505);
					_ = Convert.ToDouble(textBox8.Text) / 0.001968505;
				}
				num2 = bj2[1] - bj2[0];
				_ = bj2[3];
				_ = bj2[2];
				double num3 = (double)num / (double)num2;
				diao.tu = tu_xiang.suofang(bb2, (int)((double)bb2.Width * num3), (int)((double)bb2.Height * num3));
			}
			if (hei_bai.Checked)
			{
				diao.tu_pian = diao.hei_bai(trackBar2.Value);
				if (fan_se)
				{
					diao.tu_pian = tu_xiang.fanse(diao.tu_pian);
				}
			}
			else if (li_san.Checked)
			{
				diao.tu_pian = diao.dou_dong(trackBar2.Value);
				if (fan_se)
				{
					diao.tu_pian = tu_xiang.fanse(diao.tu_pian);
				}
			}
			else
			{
				diao.tu_pian = diao.hui_du(trackBar2.Value);
				if (fan_se)
				{
					diao.tu_pian = tu_xiang.fanse_huidu(diao.tu_pian);
				}
			}
		}

		private void da_kai()
		{
			int num = 0;
			int num2 = 0;
			double num3 = 0.0;
			Bitmap bitmap = new Bitmap(wen_jian_ming);
			tu = new Bitmap(bitmap);
			bitmap.Dispose();
			diao.tu = tu;
			trackBar2.Value = 128;
			trackBar3.Value = trackBar3.Maximum / 2 + 10;
			if (hei_bai.Checked)
			{
				diao.tu_pian = diao.hei_bai(trackBar2.Value);
				if (fan_se)
				{
					diao.tu_pian = tu_xiang.fanse(diao.tu_pian);
				}
			}
			else if (li_san.Checked)
			{
				diao.tu_pian = diao.dou_dong(trackBar2.Value);
				if (fan_se)
				{
					diao.tu_pian = tu_xiang.fanse(diao.tu_pian);
				}
			}
			else
			{
				diao.tu_pian = diao.hui_du(trackBar2.Value);
			}
			bj2 = tu_xiang.qu_bian_jie2(diao.tu_pian);
			bj[0] = bj2[0];
			bj[1] = bj2[1];
			bj[2] = bj2[2];
			bj[3] = bj2[3];
			bai_bian_k = (double)(bj[1] - bj[0]) / (double)diao.tu_pian.Width;
			bai_bian_g = (double)(bj[3] - bj[2]) / (double)diao.tu_pian.Height;
			if (tu.Width > 1600 || tu.Height > 1520)
			{
				if (tu.Width - 1600 > tu.Height - 1520)
				{
					num3 = (double)tu.Width / 1600.0;
					num = (int)((double)tu.Height / num3);
					tu = tu_xiang.suofang(tu, 1600, num);
				}
				else
				{
					num3 = (double)tu.Height / 1520.0;
					num2 = (int)((double)tu.Width / num3);
					tu = tu_xiang.suofang(tu, num2, 1520);
				}
			}
			diao.tu = tu;
			trackBar2.Value = 128;
			trackBar3.Value = trackBar3.Maximum / 2 + 10;
			if (hei_bai.Checked)
			{
				diao.tu_pian = diao.hei_bai(trackBar2.Value);
				if (fan_se)
				{
					diao.tu_pian = tu_xiang.fanse(diao.tu_pian);
				}
			}
			else if (li_san.Checked)
			{
				diao.tu_pian = diao.dou_dong(trackBar2.Value);
				if (fan_se)
				{
					diao.tu_pian = tu_xiang.fanse(diao.tu_pian);
				}
			}
			else
			{
				diao.tu_pian = diao.hui_du(trackBar2.Value);
			}
			bj2 = tu_xiang.qu_bian_jie2(diao.tu_pian);
			bj[0] = bj2[0];
			bj[1] = bj2[1];
			bj[2] = bj2[2];
			bj[3] = bj2[3];
			panel1.Location = new Point(25 + (int)(500.0 - (double)diao.tu_pian.Width * 0.3125) / 2, 60 + (int)(500.0 - (double)diao.tu_pian.Height * 0.3125) / 2);
			diyi = true;
			kg_bi = (double)(bj[1] - bj[0]) / (double)(bj[3] - bj[2]);
			if (mm_in)
			{
				textBox7.Text = ((int)((double)(bj[1] - bj[0]) * 0.05)).ToString();
				textBox8.Text = ((int)((double)(bj[3] - bj[2]) * 0.05)).ToString();
			}
			else
			{
				textBox7.Text = ((double)(bj[1] - bj[0]) * 0.05 * 0.0393701).ToString().Substring(0, 5);
				textBox8.Text = ((double)(bj[3] - bj[2]) * 0.05 * 0.0393701).ToString().Substring(0, 5);
			}
			diyi = false;
			hua_biao_shi();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (!kai_shi)
			{
				if (textBox2.Visible)
				{
					textBox2.Visible = false;
					button9.Visible = false;
				}
				if (dakai.ShowDialog() == DialogResult.OK)
				{
					wzms = false;
					wen_jian_ming = dakai.FileName;
					da_kai();
					gai_bian = true;
					shu_xin();
					pan_yidong();
				}
			}
		}

		private void hua_wen_zi()
		{
			float num = (float)((double)panel1.Width * 3.2) / (float)tu.Width;
			Bitmap bitmap = new Bitmap((int)((float)w_z.Width / num), (int)((float)w_z.Height / num));
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.White);
			graphics.DrawImage(w_z, 0f, 0f, (float)w_z.Width / num, (float)w_z.Height / num);
			graphics.Dispose();
			bitmap = heibai(bitmap);
			for (int i = 1; i < bitmap.Width; i++)
			{
				for (int j = 1; j < bitmap.Height; j++)
				{
					if (bitmap.GetPixel(i, j).B < 1 && (int)((float)wz_weizhi.X / num + (float)i) < tu.Width && (int)((float)wz_weizhi.Y / num + (float)j) < tu.Height && (int)((float)wz_weizhi.X / num + (float)i) > 0 && (int)((float)wz_weizhi.Y / num + (float)j) > 0)
					{
						tu.SetPixel((int)((float)wz_weizhi.X / num + (float)i), (int)((float)wz_weizhi.Y / num + (float)j), Color.Black);
					}
				}
			}
			w_z = null;
		}

		private void quan_bu_shua_xin()
		{
			if (tu == null && !(textBox2.Text != ""))
			{
				return;
			}
			if (!kai_shi && gai_bian)
			{
				if (w_z != null)
				{
					if (wzms)
					{
						bj = tu_xiang.qu_bian_jie2(w_z);
						tu = new Bitmap(w_z.Width, w_z.Height);
						Graphics graphics = Graphics.FromImage(tu);
						graphics.DrawImage(w_z, 0, 0, w_z.Width, w_z.Height);
						graphics.Dispose();
						bj2 = tu_xiang.qu_bian_jie2(tu);
						bj[0] = bj2[0];
						bj[1] = bj2[1];
						bj[2] = bj2[2];
						bj[3] = bj2[3];
						bai_bian_k = (double)(bj[1] - bj[0]) / (double)tu.Width;
						bai_bian_g = (double)(bj[3] - bj[2]) / (double)tu.Height;
						diyi = true;
						kg_bi = (double)(bj[1] - bj[0]) / (double)(bj[3] - bj[2]);
						if (mm_in)
						{
							textBox7.Text = ((int)((double)tu.Width * 0.05)).ToString();
							textBox8.Text = ((int)((double)tu.Height * 0.05)).ToString();
						}
						else
						{
							textBox7.Text = ((int)((double)tu.Width * 0.05 * 0.0393701)).ToString().Substring(0, 5);
							textBox8.Text = ((int)((double)tu.Height * 0.05 * 0.0393701)).ToString().Substring(0, 5);
						}
						diyi = false;
						xianzhi();
						w_z = null;
					}
					else
					{
						hua_wen_zi();
					}
				}
				if (tu != null)
				{
					suo_fang(tu);
					xianzhi();
				}
				gai_bian = false;
			}
			bj = tu_xiang.qu_bian_jie2(diao.tu_pian);
			if (diao.tu_pian != null)
			{
				if (checkBox2.Checked)
				{
					Bitmap bitmap = new Bitmap(diao.tu_pian);
					Graphics graphics2 = Graphics.FromImage(bitmap);
					Pen pen = new Pen(Color.Red, 3f);
					graphics2.DrawRectangle(pen, bj[0] - 2, bj[2] - 2, bj[1] - bj[0] + 4, bj[3] - bj[2] + 4);
					graphics2.Dispose();
					tu_kuan_gao tu_kuan_gao = tu_xiang.shua_xin(panel1, bitmap, 0, 0, bitmap.Width, bitmap.Height, hui_du.Checked);
					diao.tu_pian = tu_kuan_gao.bb;
					hua_kg = new int[2]
					{
						tu_kuan_gao.k,
						tu_kuan_gao.g
					};
				}
				else
				{
					Graphics graphics3 = Graphics.FromImage(new Bitmap(diao.tu_pian));
					Pen pen2 = new Pen(Color.White, 3f);
					graphics3.DrawRectangle(pen2, bj[0] - 2, bj[2] - 2, bj[1] - bj[0] + 4, bj[3] - bj[2] + 4);
					graphics3.Dispose();
					tu_kuan_gao tu_kuan_gao2 = tu_xiang.shua_xin(panel1, diao.tu_pian, 0, 0, diao.tu_pian.Width, diao.tu_pian.Height, hui_du.Checked);
					diao.tu_pian = tu_kuan_gao2.bb;
					hua_kg = new int[2]
					{
						tu_kuan_gao2.k,
						tu_kuan_gao2.g
					};
				}
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			quan_bu_shua_xin();
		}

		private void yu_yan()
		{
			button1.Text = str2;
			label3.Text = str1;
			Text = str28;
			button2.Text = str4;
			button5.Text = str5;
			button4.Text = str7;
			button29.Text = str8;
			button24.Text = str10;
			groupBox1.Text = str11;
			groupBox2.Text = str16;
			groupBox3.Text = str18;
			hei_bai.Text = str12;
			li_san.Text = str13;
			hui_du.Text = str14;
			label2.Text = str15;
			label1.Text = str17;
			label18.Text = str54;
			label19.Text = str55;
			button28.Text = str20;
			button30.Text = str19;
			button26.Text = str21;
			dakai.Filter = str34 + "|*.bmp;*.jpg;*.jpge;*.png";
			label13.Text = str36;
			groupBox4.Text = str37;
			groupBox5.Text = str40;
			trackBar3.Location = new Point(label3.Location.X + label3.Width, trackBar3.Location.Y);
			trackBar3.Width = label13.Location.X - (label3.Location.X + label3.Width);
			toolTip1.SetToolTip(button21, str42);
			toolTip1.SetToolTip(button22, str43);
			toolTip1.SetToolTip(button25, str44);
			toolTip1.SetToolTip(button20, str45);
			toolTip1.SetToolTip(button15, str46);
			toolTip1.SetToolTip(button32, str47);
			toolTip1.SetToolTip(button35, str48);
			toolTip1.SetToolTip(button27, str49);
			toolTip1.SetToolTip(button36, str50);
			toolTip1.SetToolTip(button9, str51);
			toolTip1.SetToolTip(panel1, str52);
			if (str1 == "Scaling")
			{
				hei_bai.Location = new Point(6, 24);
				hui_du.Location = new Point(129, 24);
				li_san.Location = new Point(6, 43);
			}
			else if (str1 == "縮小")
			{
				hei_bai.Location = new Point(6, 24);
				hui_du.Location = new Point(124, 24);
				li_san.Location = new Point(79, 24);
			}
			else
			{
				hei_bai.Location = new Point(6, 24);
				hui_du.Location = new Point(156, 24);
				li_san.Location = new Point(79, 24);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			diao = new diao_ke_ji(com);
			panel1.Width = 20;
			panel1.Height = 20;
			diao.lian_jie();
			com.Close();
			diao.lianjie = false;
			panel3.Visible = false;
			button1.Text = str2;
			yu_yan();
			panel2.Refresh();
			FontFamily[] families = new InstalledFontCollection().Families;
			for (int num = families.Length; num > 0; num--)
			{
				string name = families[num - 1].Name;
				listBox1.Items.Add(name);
			}
			listBox1.SelectedIndex = 0;
		}

		private void trackBar2_MouseUp(object sender, MouseEventArgs e)
		{
			if (!kai_shi)
			{
				gai_bian = true;
				shu_xin();
				textBox3.Text = trackBar2.Value.ToString();
			}
		}

		private void huaxian(Point[] zhixian)
		{
			Graphics graphics = Graphics.FromImage(diao.tu_pian);
			Point point = default(Point);
			bool flag = false;
			for (int i = 0; i < zhixian.Length; i++)
			{
				if (zhixian[i].X == 600 || zhixian[i].X == 601)
				{
					if (zhixian[i].X == 600)
					{
						flag = true;
					}
					if (zhixian[i].X == 601)
					{
						flag = false;
					}
				}
				else
				{
					if (flag)
					{
						graphics.DrawLine(Pens.Blue, new Point(point.X, 500 - point.Y), new Point(zhixian[i].X, 500 - zhixian[i].Y));
					}
					point = zhixian[i];
				}
			}
		}

		private void diaokexian(Point[] zhixian)
		{
			Graphics graphics = Graphics.FromImage(diao.tu_pian);
			Point point = default(Point);
			diao.guan_ruo_guang();
			bool flag = hua2;
			if (flag)
			{
				point = new Point(zhixian[wei_zhi].X + dx, zhixian[wei_zhi].Y + dy);
				diao.gai_bian_F(0);
				diao.kai_deng();
				diao.gai_bian_F(trackBar1.Value);
			}
			else
			{
				diao.gai_bian_F(0);
			}
			for (int i = wei_zhi; i < zhixian.Length; i++)
			{
				if (zhixian[i].X == 600 || zhixian[i].X == 601)
				{
					if (zhixian[i].X == 600)
					{
						flag = true;
						diao.kai_deng();
						diao.gai_bian_F(trackBar1.Value);
					}
					if (zhixian[i].X == 601)
					{
						flag = false;
						diao.guan_deng();
						diao.gai_bian_F(0);
					}
				}
				else
				{
					if (flag)
					{
						graphics.DrawLine(Pens.Red, new Point(point.X, 500 - point.Y), new Point(zhixian[i].X, 500 - zhixian[i].Y));
					}
					point = zhixian[i];
				}
			}
			button4.Refresh();
		}

		private void jie()
		{
			zhixian = g_dai_ma.jie_xi(wenben);
			huaxian(zhixian);
			shuxin();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (!textBox2.Visible && da_kai_g.ShowDialog() == DialogResult.OK)
			{
				Graphics graphics = Graphics.FromImage(diao.tu_pian);
				graphics.Clear(Color.White);
				graphics.Dispose();
				zhuang_tai = 2;
				textBox1.Text = "10";
				trackBar1.Maximum = 35;
				trackBar1.Value = 12;
				textBox1.Text = "12";
				dx = 0;
				dy = 0;
				wenben = File.ReadAllText(da_kai_g.FileName);
				new Thread(jie).Start();
			}
		}

		public bool diaoke2()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			byte b = 0;
			if (li_san.Checked)
			{
				diao.li_san_mo_shi();
			}
			else
			{
				diao.fei_li_san_mo_shi();
			}
			diao.fu_wei();
			diao.kai_feng();
			fen = true;
			diao.kai_shi((int)((double)(panel1.Location.X - 25) * 3.2), (int)((double)(panel1.Location.Y - 60) * 3.2));
			byte[] array = (diao.tu_pian.Width % 8 <= 0) ? new byte[diao.tu_pian.Width / 8 + 9] : new byte[diao.tu_pian.Width / 8 + 10];
			byte[] array2 = new byte[8]
			{
				128,
				64,
				32,
				16,
				8,
				4,
				2,
				1
			};
			hei_dian_shu = diao.qu_hei_dian();
			timer3.Enabled = true;
			miao = 0;
			label12.Visible = true;
			com.DiscardInBuffer();
			for (num = wei_zhi; num < diao.tu_pian.Height; num++)
			{
				num3 = 0;
				for (num2 = 0; num2 < array.Length - 9; num2++)
				{
					int num4 = 0;
					b = 0;
					for (num4 = 0; num4 < 8; num4++)
					{
						if (num2 * 8 + num4 < diao.tu_pian.Width && diao.tu_pian.GetPixel(num2 * 8 + num4, num).R == 0)
						{
							b = (byte)(b | array2[num4]);
							diao.tu_pian.SetPixel(num2 * 8 + num4, num, Color.Red);
						}
					}
					array[num3 + 9] = b;
					num3++;
				}
				array[0] = 9;
				array[1] = (byte)(array.Length >> 8);
				array[2] = (byte)array.Length;
				array[3] = (byte)(trackBar1.Value >> 8);
				array[4] = (byte)trackBar1.Value;
				array[5] = (byte)(trackBar4.Value * 10 >> 8);
				array[6] = (byte)(trackBar4.Value * 10);
				array[7] = (byte)(num >> 8);
				array[8] = (byte)num;
				diao.fanhui = false;
				bool flag = false;
				for (int i = 9; i < array.Length; i++)
				{
					if (array[i] != 0)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				do
				{
					IL_028b:
					try
					{
						if (!cuo_wu)
						{
							com.Write(array, 0, array.Length);
						}
						else
						{
							byte[] array3 = new byte[23];
							com.Write(array3, 0, array3.Length);
							cuo_wu = false;
						}
					}
					catch (Exception)
					{
						com.Close();
						Thread.Sleep(500);
						string portName = com.PortName;
						bool flag2 = false;
						do
						{
							string[] portNames = SerialPort.GetPortNames();
							for (int j = 0; j < portNames.Length; j++)
							{
								if (portNames[j] == portName)
								{
									flag2 = true;
									break;
								}
							}
							Thread.Sleep(100);
							diao_ke_ji.处理事件();
						}
						while (!flag2);
						com.Open();
						goto IL_028b;
					}
					int num5 = 0;
					while (!diao.fanhui)
					{
						if (!com.IsOpen)
						{
							goto IL_028b;
						}
						num5++;
						if (ting_zhi)
						{
							diao.ting_zhi();
							kai_shi = false;
							gai_bian = true;
							timer3.Enabled = false;
							label12.Visible = true;
							shu_xin();
							return false;
						}
						if (feng_shang)
						{
							if (fen)
							{
								diao.kai_feng2();
							}
							else
							{
								diao.guan_feng2();
							}
							feng_shang = false;
						}
						else if (zan_ting)
						{
							if (zan_ting2)
							{
								diao.zan_ting();
								timer3.Enabled = false;
							}
							else
							{
								diao.ji_xu();
								timer3.Enabled = true;
							}
							zan_ting = false;
						}
						diao_ke_ji.处理事件();
						Thread.Sleep(10);
					}
					gai_bian = true;
					shu_xin();
					diao_ke_ji.处理事件();
					Thread.Sleep(10);
				}
				while (diao.fanhui_shu == 8);
			}
			if (!ting_zhi)
			{
				wei_zhi = 0;
				kai_shi = false;
				timer3.Enabled = false;
				timer3.Enabled = false;
				label12.Visible = true;
				diao.ting_zhi();
				kai_shi = false;
				gai_bian = true;
				timer3.Enabled = false;
				label12.Visible = true;
				shu_xin();
				quan_bu_shua_xin();
				return true;
			}
			timer3.Enabled = false;
			label12.Visible = true;
			diao.ting_zhi();
			kai_shi = false;
			gai_bian = true;
			timer3.Enabled = false;
			label12.Visible = true;
			shu_xin();
			return true;
		}

		public bool diaoke3()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			byte b = 0;
			if (li_san.Checked)
			{
				diao.li_san_mo_shi();
			}
			else
			{
				diao.fei_li_san_mo_shi();
			}
			diao.fu_wei();
			diao.kai_feng();
			fen = true;
			diao.kai_shi((int)((double)(panel1.Location.X - 25) * 3.2), (int)((double)(panel1.Location.Y - 60) * 3.2));
			byte[] array = (diao.tu_pian.Width % 8 <= 0) ? new byte[diao.tu_pian.Width / 8 + 9] : new byte[diao.tu_pian.Width / 8 + 10];
			byte[] array2 = new byte[8]
			{
				128,
				64,
				32,
				16,
				8,
				4,
				2,
				1
			};
			hei_dian_shu = diao.qu_hei_dian();
			timer3.Enabled = true;
			miao = 0;
			label12.Visible = true;
			for (num = wei_zhi; num < diao.tu_pian.Height; num++)
			{
				num3 = 0;
				for (num2 = 0; num2 < array.Length - 9; num2++)
				{
					int num4 = 0;
					b = 0;
					for (num4 = 0; num4 < 8; num4++)
					{
						if (num2 * 8 + num4 < diao.tu_pian.Width && diao.tu_pian.GetPixel(num2 * 8 + num4, num).R == 0)
						{
							b = (byte)(b | array2[num4]);
							diao.tu_pian.SetPixel(num2 * 8 + num4, num, Color.Red);
						}
					}
					array[num3 + 9] = b;
					num3++;
				}
				array[0] = 9;
				array[1] = (byte)(array.Length >> 8);
				array[2] = (byte)array.Length;
				array[3] = (byte)(trackBar1.Value >> 8);
				array[4] = (byte)trackBar1.Value;
				array[5] = (byte)(trackBar4.Value * 10 >> 8);
				array[6] = (byte)(trackBar4.Value * 10);
				array[7] = (byte)(num >> 8);
				array[8] = (byte)num;
				diao.fanhui = false;
				bool flag = false;
				for (int i = 9; i < array.Length; i++)
				{
					if (array[i] != 0)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				do
				{
					IL_0280:
					try
					{
						if (!cuo_wu)
						{
							com.Write(array, 0, array.Length);
						}
						else
						{
							byte[] array3 = new byte[23];
							com.Write(array3, 0, array3.Length);
							cuo_wu = false;
						}
					}
					catch (Exception)
					{
						com.Close();
						Thread.Sleep(500);
						string portName = com.PortName;
						bool flag2 = false;
						do
						{
							string[] portNames = SerialPort.GetPortNames();
							for (int j = 0; j < portNames.Length; j++)
							{
								if (portNames[j] == portName)
								{
									flag2 = true;
									break;
								}
							}
							Thread.Sleep(100);
							diao_ke_ji.处理事件();
						}
						while (!flag2);
						com.Open();
						goto IL_0280;
					}
					int num5 = 0;
					while (!diao.fanhui)
					{
						if (!com.IsOpen)
						{
							goto IL_0280;
						}
						num5++;
						if (ting_zhi)
						{
							diao.ting_zhi();
							kai_shi = false;
							gai_bian = true;
							timer3.Enabled = false;
							label12.Visible = true;
							shu_xin();
							return false;
						}
						if (feng_shang)
						{
							if (fen)
							{
								diao.kai_feng2();
							}
							else
							{
								diao.guan_feng2();
							}
							feng_shang = false;
						}
						else if (zan_ting)
						{
							if (zan_ting2)
							{
								diao.zan_ting();
								timer3.Enabled = false;
							}
							else
							{
								diao.ji_xu();
								timer3.Enabled = true;
							}
							zan_ting = false;
						}
						diao_ke_ji.处理事件();
						Thread.Sleep(10);
					}
					gai_bian = true;
					shu_xin();
					diao_ke_ji.处理事件();
					Thread.Sleep(10);
				}
				while (diao.fanhui_shu == 8);
			}
			if (!ting_zhi)
			{
				wei_zhi = 0;
				kai_shi = false;
				timer3.Enabled = false;
				timer3.Enabled = false;
				label12.Visible = true;
				diao.ting_zhi();
				kai_shi = false;
				gai_bian = true;
				timer3.Enabled = false;
				label12.Visible = true;
				shu_xin();
				quan_bu_shua_xin();
				MessageBox.Show(str26);
				return true;
			}
			timer3.Enabled = false;
			label12.Visible = true;
			diao.ting_zhi();
			kai_shi = false;
			gai_bian = true;
			timer3.Enabled = false;
			label12.Visible = true;
			shu_xin();
			return true;
		}

		public bool diaoke_hui()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			diao.fei_li_san_mo_shi();
			diao.fu_wei();
			diao.kai_feng();
			fen = true;
			diao.kai_shi((int)((double)(panel1.Location.X - 25) * 3.2), (int)((double)(panel1.Location.Y - 60) * 3.2));
			byte[] array = new byte[diao.tu_pian.Width + 9];
			num3 = diao.tu_pian.Width;
			num4 = diao.tu_pian.Height;
			_ = new byte[8]
			{
				128,
				64,
				32,
				16,
				8,
				4,
				2,
				1
			};
			timer3.Enabled = true;
			miao = 0;
			label12.Visible = true;
			for (num = 0; num < num4; num++)
			{
				for (num2 = 0; num2 < num3; num2++)
				{
					array[num2 + 9] = (byte)(255 - diao.tu_pian.GetPixel(num2, num).R);
					diao.tu_pian.SetPixel(num2, num, Color.FromArgb(diao.tu_pian.GetPixel(num2, num).R, 0, 0));
				}
				bool flag = false;
				for (num2 = 9; num2 < num3; num2++)
				{
					if (array[num2 + 9] > 20)
					{
						flag = true;
						hei_dian_shu++;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				array[0] = 19;
				array[1] = (byte)(array.Length >> 8);
				array[2] = (byte)array.Length;
				array[3] = (byte)(trackBar1.Value >> 8);
				array[4] = (byte)trackBar1.Value;
				array[5] = (byte)(trackBar4.Value * 10 >> 8);
				array[6] = (byte)(trackBar4.Value * 10);
				array[7] = (byte)(num >> 8);
				array[8] = (byte)num;
				diao.fanhui = false;
				try
				{
					if (!com.IsOpen)
					{
						return false;
					}
					com.Write(array, 0, array.Length);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
				diao_ke_ji.处理事件();
				while (!diao.fanhui)
				{
					if (ting_zhi)
					{
						diao.ting_zhi();
						kai_shi = false;
						gai_bian = true;
						timer3.Enabled = false;
						label12.Visible = true;
						shu_xin();
						ting_zhi = false;
						return false;
					}
					if (feng_shang)
					{
						Thread.Sleep(500);
						if (fen)
						{
							diao.kai_feng2();
						}
						else
						{
							diao.guan_feng2();
						}
						feng_shang = false;
					}
					else if (zan_ting)
					{
						if (zan_ting2)
						{
							timer3.Enabled = false;
							diao.zan_ting();
						}
						else
						{
							timer3.Enabled = true;
							diao.ji_xu();
						}
						zan_ting = false;
					}
					diao_ke_ji.处理事件();
					Thread.Sleep(10);
				}
				gai_bian = true;
				shu_xin();
			}
			if (!ting_zhi)
			{
				wei_zhi = 0;
				kai_shi = false;
				timer3.Enabled = false;
				timer3.Enabled = false;
				label12.Visible = true;
				diao.ting_zhi();
				kai_shi = false;
				gai_bian = true;
				timer3.Enabled = false;
				label12.Visible = true;
				shu_xin();
				quan_bu_shua_xin();
				MessageBox.Show(str26);
				return true;
			}
			timer3.Enabled = false;
			label12.Visible = true;
			diao.ting_zhi();
			kai_shi = false;
			gai_bian = true;
			timer3.Enabled = false;
			label12.Visible = true;
			shu_xin();
			return true;
		}

		private void button4_Click(object sender, EventArgs e)
		{
		}

		public Bitmap heibai(Bitmap bb)
		{
			Bitmap bitmap = new Bitmap(bb);
			Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			int num = Math.Abs(bitmapData.Stride) * bitmap.Height;
			byte[] array = new byte[num];
			byte[] array2 = new byte[num];
			Marshal.Copy(scan, array, 0, num);
			int num2 = 0;
			for (int i = 0; i < array.Length; i += 4)
			{
				num2 = (array[i] * 30 + array[i + 1] * 59 + array[i + 2] * 11) / 100;
				num2 = ((num2 > 150) ? 255 : 0);
				array2[i] = (byte)num2;
				array2[i + 1] = (byte)num2;
				array2[i + 2] = (byte)num2;
				array2[i + 3] = byte.MaxValue;
			}
			Marshal.Copy(array2, 0, scan, num);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}

		private Bitmap GetControlBitmap(TextBox uc)
		{
			if (uc == null)
			{
				return null;
			}
			Bitmap bitmap = new Bitmap(uc.Width - 2, uc.Height - 2);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.White);
			Point point = PointToScreen(uc.Location);
			point = new Point(point.X + 1, point.Y + 1);
			graphics.CopyFromScreen(point, new Point(0, 0), new Size(bitmap.Width, bitmap.Height));
			return bitmap;
		}

		public Bitmap GetBitmap()
		{
			return GetControlBitmap(textBox2);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (kai_shi)
			{
				return;
			}
			if (textBox2.Visible)
			{
				panel6.Visible = false;
				button9.Visible = false;
				button10.Visible = false;
				if (textBox2.Text == "")
				{
					textBox2.Visible = false;
					button9.Visible = false;
					button10.Visible = false;
					button5.Text = str5;
					return;
				}
				Bitmap bitmap = new Bitmap((int)((double)textBox2.Width * 3.2), (int)((double)textBox2.Height * 3.2));
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.Clear(Color.White);
				FontStyle style = FontStyle.Regular;
				if (radioButton5.Checked)
				{
					style = FontStyle.Regular;
				}
				if (radioButton2.Checked)
				{
					style = FontStyle.Bold;
				}
				if (radioButton3.Checked)
				{
					style = FontStyle.Italic;
				}
				if (radioButton4.Checked)
				{
					style = (FontStyle.Bold | FontStyle.Italic);
				}
				Font font = new Font("宋体", 16f, style, GraphicsUnit.Pixel);
				try
				{
					font = new Font(listBox1.Text, (float)((double)trackBar5.Value * 6.4), style, GraphicsUnit.Pixel);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
				graphics.DrawString(textBox2.Text, font, Brushes.Black, 0f, 0f);
				graphics.Dispose();
				w_z = heibai(bitmap);
				w_z = tu_xiang.qu_bian_jie(w_z);
				wz_weizhi = new Point((int)((double)(textBox2.Location.X - panel1.Location.X) * 3.2), (int)((double)(textBox2.Location.Y - panel1.Location.Y) * 3.2));
				button5.Text = str5;
				textBox2.Visible = false;
				gai_bian = true;
				zhuang_tai = 3;
				dx = 0;
				dy = 0;
				wei_zhi = 0;
			}
			else
			{
				zhuang_tai = 3;
				textBox2.Visible = true;
				textBox2.Location = panel1.Location;
				textBox2.Focus();
				button10.Location = new Point(161, 126);
				if (textBox2.Text == "")
				{
					textBox2.Text = "ABC";
				}
				button31_Click(null, null);
				textBox2.BorderStyle = BorderStyle.FixedSingle;
				button9.Location = new Point(textBox2.Location.X + textBox2.Width, textBox2.Location.Y + textBox2.Height);
				button5.Text = str6;
				gai_bian = true;
				shu_xin();
			}
		}

		private void button10_MouseDown(object sender, MouseEventArgs e)
		{
			anxia = true;
			shu_x = e.X;
			shu_y = e.Y;
		}

		private void button10_MouseUp(object sender, MouseEventArgs e)
		{
			anxia = false;
		}

		private void button10_MouseMove(object sender, MouseEventArgs e)
		{
			if (!anxia)
			{
				return;
			}
			Point location = default(Point);
			if (e.X - shu_x > 0)
			{
				if (textBox2.Location.X + textBox2.Size.Width < panel1.Width)
				{
					location.X = textBox2.Location.X + (e.X - shu_x);
					location.Y = textBox2.Location.Y;
					textBox2.Location = location;
					location.X = button10.Location.X + (e.X - shu_x);
					location.Y = button10.Location.Y;
					button10.Location = location;
					location.X = button9.Location.X + (e.X - shu_x);
					location.Y = button9.Location.Y;
					button9.Location = location;
				}
			}
			else if (textBox2.Location.X + (e.X - shu_x) > 0)
			{
				location.X = textBox2.Location.X + (e.X - shu_x);
				location.Y = textBox2.Location.Y;
				textBox2.Location = location;
				location.X = button10.Location.X + (e.X - shu_x);
				location.Y = button10.Location.Y;
				button10.Location = location;
				location.X = button9.Location.X + (e.X - shu_x);
				location.Y = button9.Location.Y;
				button9.Location = location;
			}
			if (e.Y - shu_y > 0)
			{
				if (textBox2.Location.Y + textBox2.Size.Height < panel1.Height)
				{
					location.X = textBox2.Location.X;
					location.Y = textBox2.Location.Y + (e.Y - shu_y);
					textBox2.Location = location;
					location.X = button10.Location.X;
					location.Y = button10.Location.Y + (e.Y - shu_y);
					button10.Location = location;
					location.X = button9.Location.X;
					location.Y = button9.Location.Y + (e.Y - shu_y);
					button9.Location = location;
				}
			}
			else if (textBox2.Location.Y + (e.Y - shu_y) > 0)
			{
				location.X = textBox2.Location.X;
				location.Y = textBox2.Location.Y + (e.Y - shu_y);
				textBox2.Location = location;
				location.X = button10.Location.X;
				location.Y = button10.Location.Y + (e.Y - shu_y);
				button10.Location = location;
				location.X = button9.Location.X;
				location.Y = button9.Location.Y + (e.Y - shu_y);
				button9.Location = location;
			}
		}

		private void button9_MouseDown(object sender, MouseEventArgs e)
		{
			anxia = true;
			shu_x = e.X;
			shu_y = e.Y;
		}

		private void button9_MouseMove(object sender, MouseEventArgs e)
		{
			if (anxia)
			{
				textBox2.Width = button9.Location.X - textBox2.Location.X;
				textBox2.Height = button9.Location.Y - textBox2.Location.Y;
				button9.Location = new Point(button9.Location.X + (e.X - shu_x), button9.Location.Y + (e.Y - shu_y));
			}
		}

		private void button9_MouseUp(object sender, MouseEventArgs e)
		{
			anxia = false;
			if (textBox2.Width > 500)
			{
				textBox2.Width = 500;
				button9.Location = new Point(textBox2.Location.X + 500, button9.Location.Y);
			}
			if (textBox2.Height > 500)
			{
				textBox2.Height = 500;
				button9.Location = new Point(button9.Location.X, textBox2.Location.Y + 500);
			}
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (diao.tu_pian != null)
			{
				if (checkBox2.Checked)
				{
					diao.kai_kuang2(bj[1] - bj[0], bj[3] - bj[2], bj[0], bj[2]);
					gai_bian = true;
					shu_xin();
				}
				else
				{
					gai_bian = true;
					shu_xin();
					diao.guan_kuang2();
				}
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			_ = wei_zhi;
			_ = 0;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			_ = wei_zhi;
			_ = diao.kuan_gao;
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void trackBar1_MouseUp(object sender, MouseEventArgs e)
		{
			if (kai_shi)
			{
				diao.gong_shen(trackBar4.Value * 10, trackBar1.Value);
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (!(textBox1.Text == ""))
			{
				try
				{
					if (Convert.ToInt32(textBox1.Text) < 1000)
					{
						trackBar1.Value = Convert.ToInt32(textBox1.Text);
					}
					else
					{
						textBox1.Text = "1000";
						trackBar1.Value = 1000;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			trackBar2.Value = Convert.ToInt32(textBox3.Text);
		}

		private void button11_Click(object sender, EventArgs e)
		{
			if (kai_shi)
			{
				MessageBox.Show(str25);
				return;
			}
			if (button1.Text == str2)
			{
				MessageBox.Show(str23);
				return;
			}
			if (textBox2.Visible)
			{
				MessageBox.Show(str29);
				return;
			}
			int num = Convert.ToInt16(textBox4.Text);
			num = (int)((double)num * 0.3125);
			panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - num);
			pan_yidong();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			if (kai_shi)
			{
				MessageBox.Show(str25);
				return;
			}
			if (button1.Text == str2)
			{
				MessageBox.Show(str23);
				return;
			}
			if (textBox2.Visible)
			{
				MessageBox.Show(str29);
				return;
			}
			int num = Convert.ToInt16(textBox4.Text);
			num = (int)((double)num * 0.3125);
			panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + num);
			pan_yidong();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			if (kai_shi)
			{
				MessageBox.Show(str25);
				return;
			}
			if (button1.Text == str2)
			{
				MessageBox.Show(str23);
				return;
			}
			if (textBox2.Visible)
			{
				MessageBox.Show(str29);
				return;
			}
			int num = Convert.ToInt16(textBox4.Text);
			num = (int)((double)num * 0.3125);
			panel1.Location = new Point(panel1.Location.X - num, panel1.Location.Y);
			pan_yidong();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			if (kai_shi)
			{
				MessageBox.Show(str25);
				return;
			}
			if (button1.Text == str2)
			{
				MessageBox.Show(str23);
				return;
			}
			if (textBox2.Visible)
			{
				MessageBox.Show(str29);
				return;
			}
			int num = Convert.ToInt16(textBox4.Text);
			num = (int)((double)num * 0.3125);
			panel1.Location = new Point(panel1.Location.X + num, panel1.Location.Y);
			pan_yidong();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			diao.guan_ruo_guang();
			diao.dian_deng(trackBar1.Value);
		}

		private void button16_Click(object sender, EventArgs e)
		{
			diao.tuo_ji_da_yin();
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void button17_Click(object sender, EventArgs e)
		{
			if (!textBox2.Visible)
			{
				if (zhuang_tai == 2)
				{
					diao.duoji2(jdt, zhixian);
				}
				else
				{
					diao.duoji(jdt);
				}
			}
		}

		private void button20_Click(object sender, EventArgs e)
		{
			if (!kai_shi)
			{
				fan_se = !fan_se;
				gai_bian = true;
				shu_xin();
				bj = tu_xiang.qu_bian_jie2(diao.tu_pian);
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			suofang += 5;
			Bitmap image = new Bitmap(tu_xiang.suofang(tu, diao.kuan_gao + suofang, diao.kuan_gao + suofang));
			Graphics.FromImage(diao.tu).DrawImage(image, 0, 0);
			diao.tu_pian = diao.dou_dong(trackBar2.Value);
			shu_xin();
		}

		private void button19_Click(object sender, EventArgs e)
		{
			suofang -= 5;
			Bitmap image = new Bitmap(tu_xiang.suofang(tu, diao.kuan_gao + suofang, diao.kuan_gao + suofang));
			Graphics graphics = Graphics.FromImage(diao.tu);
			graphics.Clear(Color.White);
			graphics.DrawImage(image, 0, 0);
			diao.tu_pian = diao.dou_dong(trackBar2.Value);
			shu_xin();
		}

		private void trackBar3_MouseUp(object sender, MouseEventArgs e)
		{
			gai_bian = true;
			quan_bu_shua_xin();
			if (checkBox2.Checked)
			{
				diao.kai_kuang(diao.tu_pian.Width, diao.tu_pian.Height);
			}
			pan_yidong();
		}

		private void button24_Click(object sender, EventArgs e)
		{
			if (!(button1.Text == str2))
			{
				hei_dian_shu = 0;
				ting_zhi = true;
				kai_shi = false;
				wei_zhi = 0;
				hua2 = false;
				if (tj)
				{
					button29.Text = str8;
					diao.ting_zhi_tj();
				}
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			if (!kai_shi && tu != null)
			{
				tu.RotateFlip(RotateFlipType.RotateNoneFlipX);
				gai_bian = true;
				shu_xin();
			}
		}

		private void button22_Click(object sender, EventArgs e)
		{
			if (!kai_shi && tu != null)
			{
				tu.RotateFlip(RotateFlipType.Rotate180FlipX);
				gai_bian = true;
				shu_xin();
			}
		}

		private void button25_Click(object sender, EventArgs e)
		{
			if (!kai_shi && tu != null)
			{
				tu.RotateFlip(RotateFlipType.Rotate90FlipNone);
				gai_bian = true;
				panel1.Refresh();
				pan_yidong();
			}
		}

		private void button23_Click(object sender, EventArgs e)
		{
			if (zhuang_tai != 2 && diao.tu_pian != null)
			{
				gai_bian = true;
				if (ca)
				{
					ca = false;
					panel1.Cursor = Cursors.Cross;
				}
				else
				{
					ca = true;
					panel1.Cursor = Cursors.No;
				}
			}
		}

		private void button15_Click_1(object sender, EventArgs e)
		{
			if (!kai_shi)
			{
				wenben = "";
				textBox2.Text = "";
				Graphics graphics = Graphics.FromImage(new Bitmap(1, 1));
				graphics.Clear(Color.White);
				graphics.Dispose();
				tu = null;
				diao.tu = null;
				diao.tu_pian = null;
				wen_jian_ming = "";
				w_z = null;
				if (checkBox2.Checked)
				{
					diao.guan_kuang();
					checkBox2.Checked = false;
				}
				wzms = true;
				panel1.Width = 20;
				panel1.Height = 20;
				panel1.Location = new Point(25, 60);
				pan_yidong();
				panel1.Refresh();
			}
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			shubiao_x = e.X;
			shubiao_y = e.Y;
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			anxia3 = false;
			panel1.Refresh();
		}

		private void pictureBox1_LocationChanged(object sender, EventArgs e)
		{
		}

		private void button16_Click_1(object sender, EventArgs e)
		{
			diao.tuo_ji_da_yin();
		}

		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			string text = "";
			if (!kai_shi)
			{
				if (textBox2.Visible)
				{
					textBox2.Visible = false;
					button9.Visible = false;
				}
				text = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
				wzms = false;
				wen_jian_ming = text;
				da_kai();
				gai_bian = true;
				shu_xin();
				pan_yidong();
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Process currentProcess = Process.GetCurrentProcess();
			Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
			foreach (Process process in processesByName)
			{
				if (process.Id == currentProcess.Id)
				{
					process.Kill();
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			cuo_wu = true;
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
		}

		private void tuoji_jindu(byte[] data1)
		{
			if (data1[0] == byte.MaxValue && data1[1] == byte.MaxValue && data1[2] == byte.MaxValue)
			{
				switch (data1[3])
				{
				case byte.MaxValue:
					kai_shi = false;
					button29.Text = str8;
					jd = 0;
					xs = false;
					jidu();
					break;
				case 254:
					timer_flash.Enabled = false;
					flash_0 = true;
					jd = 0;
					xs = true;
					fs_wc = true;
					jidu();
					break;
				}
			}
			else if (data1[0] == byte.MaxValue && data1[1] == byte.MaxValue)
			{
				int num = data1[2];
				num <<= 8;
				num = (jd = (num | data1[3]));
				xs = true;
				jidu();
				kai_shi = true;
			}
		}

		private void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			if (diao.lianjie)
			{
				if (tj)
				{
					if (!com.IsOpen)
					{
						return;
					}
					if (com.BytesToRead == 1)
					{
						diao.fanhui = true;
						diao.fanhui_shu = com.ReadByte();
						if (diao.fanhui_shu == 8)
						{
							diao.fanhui_shu = 8;
						}
					}
					else if (com.BytesToRead == 4)
					{
						byte[] array = new byte[4];
						com.Read(array, 0, 4);
						tuoji_jindu(array);
					}
					else
					{
						com.DiscardInBuffer();
					}
				}
				else
				{
					if (!com.IsOpen)
					{
						return;
					}
					if (banben)
					{
						banben = false;
						if (com.BytesToRead == 3)
						{
							v_zhu = com.ReadByte();
							v_fu = com.ReadByte();
							v_xing = com.ReadByte();
							com.DiscardInBuffer();
						}
						return;
					}
					diao.fanhui = true;
					if (com.BytesToRead == 1)
					{
						diao.fanhui_shu = com.ReadByte();
					}
					if (diao.fanhui_shu == 8)
					{
						diao.fanhui_shu = 8;
					}
					com.DiscardInBuffer();
				}
			}
			else
			{
				diao.fanhui = true;
				if (com.BytesToRead == 1)
				{
					diao.fanhui_shu = com.ReadByte();
				}
			}
		}

		private void com_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
		{
			try
			{
				com.Close();
				com.Open();
			}
			catch (Exception ex)
			{
				MessageBox.Show(str30, ex.ToString());
				throw;
			}
		}

		private void button26_Click(object sender, EventArgs e)
		{
			diao.kai_deng();
		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{
			textBox4.Text = ToDBC(textBox4.Text);
			textBox4.Select(textBox4.Text.Length, 0);
		}

		public static string ToDBC(string input)
		{
			char[] array = input.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == '\u3000')
				{
					array[i] = ' ';
				}
				else if (array[i] > '\uff00' && array[i] < '｟')
				{
					array[i] = (char)(array[i] - 65248);
				}
			}
			return new string(array);
		}

		private void button27_Click(object sender, EventArgs e)
		{
			if (button1.Text == str2)
			{
				return;
			}
			if (kai_shi)
			{
				feng_shang = true;
				if (fen)
				{
					fen = false;
				}
				else
				{
					fen = true;
				}
			}
			else if (fen)
			{
				fen = false;
				diao.guan_feng();
			}
			else
			{
				fen = true;
				diao.kai_feng();
			}
		}

		private void hua_biao_shi()
		{
			if (bj[1] - bj[0] == 0)
			{
				return;
			}
			double num = 0.0;
			double num2 = 0.0;
			num = Convert.ToDouble(textBox7.Text);
			num2 = Convert.ToDouble(textBox8.Text);
			panel4.Width = (int)((double)(bj[1] - bj[0]) / 3.2);
			panel4.Location = new Point((int)((double)panel1.Location.X + (double)bj[0] / 3.2), 43);
			if (panel4.Width != 0)
			{
				biao_shi_k = new Bitmap(panel4.Width, 17);
				Bitmap image = new Bitmap(55, 15);
				Graphics graphics = Graphics.FromImage(image);
				graphics.Clear(BackColor);
				graphics.DrawString(num + label20.Text, Font, Brushes.Blue, new PointF(0f, 0f));
				graphics.Dispose();
				Graphics graphics2 = Graphics.FromImage(biao_shi_k);
				graphics2.Clear(BackColor);
				graphics2.DrawRectangle(Pens.Blue, new Rectangle(0, -1, panel4.Width - 1, 19));
				graphics2.DrawLine(Pens.Blue, 0, 8, panel4.Width, 8);
				graphics2.DrawImage(image, panel4.Width / 2 - 25, 2);
				graphics2.Dispose();
				panel4.Refresh();
				panel5.Height = (int)((double)(bj[3] - bj[2]) / 3.2);
				panel5.Location = new Point(8, (int)((double)panel1.Location.Y + (double)bj[2] / 3.2));
				if (panel4.Height != 0)
				{
					biao_shi_g = new Bitmap(17, panel5.Height);
					Bitmap bitmap = new Bitmap(55, 15);
					Graphics graphics3 = Graphics.FromImage(bitmap);
					graphics3.Clear(BackColor);
					graphics3.DrawString(num2 + label20.Text, Font, Brushes.Blue, new PointF(0f, 0f));
					graphics3.Dispose();
					Graphics graphics4 = Graphics.FromImage(biao_shi_g);
					graphics4.Clear(BackColor);
					graphics4.DrawRectangle(Pens.Blue, new Rectangle(-1, 1, panel5.Width + 2, panel5.Height - 2));
					graphics4.DrawLine(Pens.Blue, 8, 1, 8, panel5.Height);
					bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
					graphics4.DrawImage(bitmap, 1, panel5.Height / 2 - 25);
					graphics4.Dispose();
					panel5.Refresh();
				}
			}
		}

		private void hei_bai_CheckedChanged(object sender, EventArgs e)
		{
			if (!kai_shi)
			{
				gai_bian = true;
				trackBar2.Value = 128;
				textBox1.Text = "10";
				textBox3.Text = "128";
				if (!(wen_jian_ming == ""))
				{
					da_kai();
					gai_bian = true;
					panel1.Refresh();
				}
			}
		}

		private void li_san_CheckedChanged(object sender, EventArgs e)
		{
			if (!kai_shi)
			{
				gai_bian = true;
				trackBar2.Value = 128;
				textBox1.Text = "10";
				textBox3.Text = "128";
				if (!textBox2.Visible && !(wen_jian_ming == ""))
				{
					da_kai();
					gai_bian = true;
					panel1.Refresh();
				}
			}
		}

		private void hui_du_CheckedChanged(object sender, EventArgs e)
		{
			if (!kai_shi && !textBox2.Visible)
			{
				trackBar2.Value = 128;
				gai_bian = true;
				textBox1.Text = "10";
				textBox3.Text = "128";
				if (!(wen_jian_ming == ""))
				{
					da_kai();
					gai_bian = true;
					panel1.Refresh();
				}
			}
		}

		private void trackBar4_Scroll(object sender, EventArgs e)
		{
			textBox5.Text = trackBar4.Value.ToString();
		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{
			trackBar4.Value = Convert.ToInt32(textBox5.Text);
		}

		private void button4_MouseUp(object sender, MouseEventArgs e)
		{
		}

		private void button4_MouseDown(object sender, MouseEventArgs e)
		{
			if (button1.Text == str2)
			{
				MessageBox.Show(str23);
				return;
			}
			if (tu == null && textBox2.Text == "")
			{
				MessageBox.Show(str24);
				return;
			}
			if (kai_shi)
			{
				MessageBox.Show(str25);
				return;
			}
			if (textBox2.Visible)
			{
				button5_Click(null, new EventArgs());
			}
			if (checkBox2.Checked)
			{
				MessageBox.Show(str35);
				return;
			}
			if (zhong_xin)
			{
				button35_Click(null, null);
			}
			kai_shi = true;
			ting_zhi = false;
			if (hui_du.Checked)
			{
				diaoke_hui();
			}
			else if (tj)
			{
				timer3.Enabled = true;
				miao = 0;
				label12.Visible = true;
				button37_Click(null, null);
			}
			else
			{
				diaoke2();
			}
		}

		private byte get_jiayan(byte[] bao)
		{
			int num = 0;
			for (int i = 0; i < bao.Length - 1; i++)
			{
				num += bao[i];
			}
			if (num > 255)
			{
				num = ~num;
				num++;
			}
			num &= 0xFF;
			return (byte)num;
		}

		private void tuo_ji()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			byte b = 0;
			timer_flash.Enabled = true;
			fs_wc = false;
			diao.kai_shi_tuo_ji((byte)((double)((panel1.Location.X + bj[0]) * 1600) / 500.0), (byte)((double)((panel1.Location.Y + bj[1]) * 1600) / 500.0), diao.tu_pian.Width, diao.tu_pian.Height, trackBar4.Value * 10, trackBar1.Value);
			while (!fs_wc)
			{
				diao_ke_ji.处理事件();
			}
			timer_flash.Enabled = false;
			byte[] array = (diao.tu_pian.Width % 8 <= 0) ? new byte[diao.tu_pian.Width / 8 + 4] : new byte[diao.tu_pian.Width / 8 + 5];
			byte[] array2 = new byte[8]
			{
				128,
				64,
				32,
				16,
				8,
				4,
				2,
				1
			};
			for (num = 0; num < diao.tu_pian.Height; num++)
			{
				num3 = 0;
				for (num2 = 0; num2 < array.Length - 4; num2++)
				{
					int num4 = 0;
					b = 0;
					for (num4 = 0; num4 < 8; num4++)
					{
						if (num2 * 8 + num4 < diao.tu_pian.Width && diao.tu_pian.GetPixel(num2 * 8 + num4, num).R == 0)
						{
							b = (byte)(b | array2[num4]);
						}
					}
					b = (array[num3 + 3] = (byte)(~b));
					num3++;
				}
				array[0] = 34;
				array[1] = (byte)(array.Length >> 8);
				array[2] = (byte)array.Length;
				array[array.Length - 1] = get_jiayan(array);
				do
				{
					IL_01e5:
					try
					{
						if (!cuo_wu)
						{
							diao.fanhui = false;
							com.Write(array, 0, array.Length);
						}
						else
						{
							byte[] array3 = new byte[23];
							com.Write(array3, 0, array3.Length);
							cuo_wu = false;
						}
					}
					catch (Exception)
					{
						com.Close();
						Thread.Sleep(500);
						string portName = com.PortName;
						bool flag = false;
						do
						{
							string[] portNames = SerialPort.GetPortNames();
							for (int i = 0; i < portNames.Length; i++)
							{
								if (portNames[i] == portName)
								{
									flag = true;
									break;
								}
							}
							Thread.Sleep(100);
							diao_ke_ji.处理事件();
						}
						while (!flag);
						com.Open();
						goto IL_01e5;
					}
					while (!diao.fanhui)
					{
						if (!com.IsOpen)
						{
							goto IL_01e5;
						}
						diao_ke_ji.处理事件();
						Thread.Sleep(10);
					}
				}
				while (diao.fanhui_shu == 8);
				progressBar1.Value = (int)((double)num / (double)diao.tu_pian.Height * 100.0);
				label14.Text = progressBar1.Value + "%";
				diao_ke_ji.处理事件();
			}
		}

		private void button26_Click_1(object sender, EventArgs e)
		{
			if (kai_shi)
			{
				MessageBox.Show(str25);
				return;
			}
			if (button1.Text == str2)
			{
				MessageBox.Show(str23);
				return;
			}
			if (textBox2.Visible)
			{
				MessageBox.Show(str29);
			}
			diao.dao_yuandian();
			panel1.Location = new Point(25, 60);
			x = 0;
			y = 0;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			_ = kai_shi;
		}

		private void button28_Click(object sender, EventArgs e)
		{
			if (kai_shi)
			{
				MessageBox.Show(str25);
				return;
			}
			if (button1.Text == str2)
			{
				MessageBox.Show(str23);
				return;
			}
			if (tu == null && textBox2.Text == "")
			{
				MessageBox.Show(str24);
				return;
			}
			if (textBox2.Visible)
			{
				MessageBox.Show(str29);
				return;
			}
			if (zhong_xin)
			{
				button35_Click(null, null);
			}
			if (!checkBox2.Checked)
			{
				checkBox2.Checked = true;
			}
			else
			{
				checkBox2.Checked = false;
			}
		}

		private void li_san_MouseDown(object sender, MouseEventArgs e)
		{
			_ = textBox2.Visible;
		}

		private void button29_MouseDown(object sender, MouseEventArgs e)
		{
			if (tj)
			{
				if (kai_shi)
				{
					if (button29.Text == str8)
					{
						diao.zan_ting();
						timer3.Enabled = false;
						button29.Text = str9;
					}
					else
					{
						diao.ji_xu();
						timer3.Enabled = true;
						button29.Text = str8;
					}
				}
			}
			else if (kai_shi)
			{
				zan_ting = true;
				if (button29.Text == str8)
				{
					zan_ting2 = true;
					button29.Text = str9;
				}
				else
				{
					zan_ting2 = false;
					button29.Text = str8;
				}
			}
		}

		private void button29_Click(object sender, EventArgs e)
		{
		}

		private void button30_Click(object sender, EventArgs e)
		{
			if (kai_shi)
			{
				MessageBox.Show(str25);
				return;
			}
			if (button1.Text == str2)
			{
				MessageBox.Show(str23);
				return;
			}
			if (textBox2.Visible)
			{
				MessageBox.Show(str29);
				return;
			}
			if (diao.tu_pian == null)
			{
				panel1.Location = new Point(275, 310);
			}
			else
			{
				panel1.Location = new Point(25 + (int)(500.0 - (double)diao.tu_pian.Width * 0.3125) / 2, 60 + (int)(500.0 - (double)diao.tu_pian.Height * 0.3125) / 2);
			}
			pan_yidong();
		}

		private void button31_Paint(object sender, PaintEventArgs e)
		{
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (!textBox2.Visible)
			{
				quan_bu_shua_xin();
			}
		}

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			an_xia = true;
			yi_dian = new Point(e.X, e.Y);
		}

		private void pan_yidong()
		{
			if (panel1.Location.X < 25)
			{
				panel1.Location = new Point(25, panel1.Location.Y);
			}
			if (panel1.Location.Y < 60)
			{
				panel1.Location = new Point(panel1.Location.X, 60);
			}
			if (panel1.Location.X + panel1.Width > 525)
			{
				panel1.Location = new Point(525 - panel1.Width, panel1.Location.Y);
			}
			if (panel1.Location.Y + panel1.Height > 560)
			{
				panel1.Location = new Point(panel1.Location.X, 560 - panel1.Height);
			}
			if (diao.lianjie)
			{
				diao.yidong((int)((double)(panel1.Location.X - 25 - x) * 3.2), (int)((double)(panel1.Location.Y - 60 - y) * 3.2), new PictureBox(), pp: false);
				x = panel1.Location.X - 25;
				y = panel1.Location.Y - 60;
			}
		}

		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			if (an_xia)
			{
				an_xia = false;
				pan_yidong();
			}
		}

		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (!an_xia)
			{
				return;
			}
			if (button1.Text == str2)
			{
				MessageBox.Show(str23);
				an_xia = false;
				return;
			}
			if (kai_shi)
			{
				MessageBox.Show(str25);
				an_xia = false;
				return;
			}
			int num = panel1.Location.X + (e.X - yi_dian.X);
			int num2 = panel1.Location.Y + (e.Y - yi_dian.Y);
			if (num < 25)
			{
				num = 25;
			}
			if (num > 525 - panel1.Width)
			{
				num = 525 - panel1.Width;
			}
			if (num2 < 60)
			{
				num2 = 60;
			}
			if (num2 > 560 - panel1.Height)
			{
				num2 = 560 - panel1.Height;
			}
			panel1.Location = new Point(num, num2);
		}

		private void button31_Click(object sender, EventArgs e)
		{
			Bitmap bb = tu_xiang.jieping_控件(button1);
			bb = heibai(bb);
		}

		private void button32_Click(object sender, EventArgs e)
		{
			if (panel6.Visible)
			{
				panel6.Visible = false;
			}
			else
			{
				panel6.Visible = true;
			}
		}

		private void textBox2_MouseDown(object sender, MouseEventArgs e)
		{
			bjk_anxia = true;
			bjk_x = e.X;
			bjk_y = e.Y;
		}

		private void textBox2_MouseMove(object sender, MouseEventArgs e)
		{
			if (bjk_anxia)
			{
				textBox2.Location = new Point(textBox2.Location.X + (e.X - bjk_x), textBox2.Location.Y + (e.Y - bjk_y));
			}
		}

		private void textBox2_MouseUp(object sender, MouseEventArgs e)
		{
			bjk_anxia = false;
			if (textBox2.Location.X < 25)
			{
				textBox2.Location = new Point(25, textBox2.Location.Y);
			}
			if (textBox2.Location.X + textBox2.Width > 525)
			{
				textBox2.Location = new Point(525 - textBox2.Width, textBox2.Location.Y);
			}
			if (textBox2.Location.Y < 60)
			{
				textBox2.Location = new Point(textBox2.Location.X, 60);
			}
			if (textBox2.Location.Y + textBox2.Height > 560)
			{
				textBox2.Location = new Point(textBox2.Location.X, 560 - textBox2.Height);
			}
		}

		private void textBox2_LocationChanged(object sender, EventArgs e)
		{
			button9.Location = new Point(textBox2.Location.X + textBox2.Width, textBox2.Location.Y + textBox2.Height);
		}

		[DllImport("kernel32.dll")]
		private static extern uint SetThreadExecutionState(ExecutionFlag flags);

		public static void PreventSleep(bool includeDisplay = false)
		{
			if (includeDisplay)
			{
				SetThreadExecutionState(ExecutionFlag.System | ExecutionFlag.Display | ExecutionFlag.Continus);
			}
			else
			{
				SetThreadExecutionState(ExecutionFlag.System | ExecutionFlag.Continus);
			}
		}

		public static void ResotreSleep()
		{
			SetThreadExecutionState(ExecutionFlag.Continus);
		}

		public static void ResetSleepTimer(bool includeDisplay = false)
		{
			if (includeDisplay)
			{
				SetThreadExecutionState(ExecutionFlag.System | ExecutionFlag.Display);
			}
			else
			{
				SetThreadExecutionState(ExecutionFlag.System);
			}
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			if (kai_shi)
			{
				miao60++;
				if (miao60 > 100)
				{
					miao60 = 0;
					ResetSleepTimer(includeDisplay: true);
				}
			}
			if (diao.lianjie)
			{
				try
				{
					if (!com.IsOpen && !kai_shi)
					{
						com.Close();
						diao.lianjie = false;
						panel3.Visible = false;
						button1.Text = str2;
						if (kai_shi)
						{
							hei_dian_shu = 0;
							ting_zhi = true;
							zan_ting = false;
							zan_ting2 = false;
							kai_shi = false;
							wei_zhi = 0;
							hua2 = false;
							button29.Text = str8;
						}
						panel2.Refresh();
						MessageBox.Show(str22);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
		}

		private void timer3_Tick(object sender, EventArgs e)
		{
			miao++;
			label12.Text = str31 + miao / 60 + str32 + miao % 60 + str33;
			label12.Refresh();
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
			if (mm_in)
			{
				if (Convert.ToDouble(textBox7.Text) > 1600.0 * bai_bian_k * 0.05)
				{
					textBox7.Text = (1600.0 * bai_bian_k * 0.05).ToString();
				}
				if (Convert.ToDouble(textBox8.Text) > 1520.0 * bai_bian_g * 0.05)
				{
					textBox8.Text = (1520.0 * bai_bian_g * 0.05).ToString();
				}
				if (Convert.ToDouble(textBox7.Text) < 1.0)
				{
					diyi = true;
					textBox7.Text = "1";
					textBox8.Text = ((int)((double)Convert.ToInt32(textBox7.Text) / kg_bi)).ToString();
					diyi = false;
				}
				if (Convert.ToDouble(textBox8.Text) < 1.0)
				{
					diyi = true;
					textBox8.Text = "1";
					textBox7.Text = ((int)((double)Convert.ToInt32(textBox8.Text) * kg_bi)).ToString();
					diyi = false;
				}
			}
			else
			{
				if (Convert.ToDouble(textBox7.Text) > 1600.0 * bai_bian_k * 0.05 * 0.0393701)
				{
					textBox7.Text = (1600.0 * bai_bian_k * 0.05 * 0.0393701).ToString().Substring(0, 5);
				}
				if (Convert.ToDouble(textBox8.Text) > 1520.0 * bai_bian_g * 0.05 * 0.0393701)
				{
					textBox8.Text = (1520.0 * bai_bian_g * 0.05 * 0.0393701).ToString().Substring(0, 5);
				}
			}
		}

		private void textBox7_TextChanged2(object sender, EventArgs e)
		{
			if (!kai_shi && !diyi)
			{
				if (textBox7.Text == "")
				{
					textBox7.Text = "1";
				}
				diyi = true;
				textBox8.Text = ((int)(Convert.ToDouble(textBox7.Text) / kg_bi)).ToString();
				diyi = false;
				xianzhi();
				gai_bian = true;
				panel1.Refresh();
				pan_yidong();
				bj = tu_xiang.qu_bian_jie2(diao.tu_pian);
				hua_biao_shi();
			}
		}

		private void textBox8_TextChanged2(object sender, EventArgs e)
		{
			if (!kai_shi && !diyi)
			{
				if (textBox8.Text == "")
				{
					textBox8.Text = "1";
				}
				diyi = true;
				textBox7.Text = ((int)(Convert.ToDouble(textBox8.Text) * kg_bi)).ToString();
				diyi = false;
				xianzhi();
				gai_bian = true;
				panel1.Refresh();
				pan_yidong();
				bj = tu_xiang.qu_bian_jie2(diao.tu_pian);
				hua_biao_shi();
			}
		}

		private void trackBar2_Scroll(object sender, EventArgs e)
		{
			textBox3.Text = trackBar2.Value.ToString();
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			textBox1.Text = trackBar1.Value.ToString();
		}

		private void zi_ti()
		{
			FontStyle style = FontStyle.Regular;
			if (radioButton5.Checked)
			{
				style = FontStyle.Regular;
			}
			if (radioButton2.Checked)
			{
				style = FontStyle.Bold;
			}
			if (radioButton3.Checked)
			{
				style = FontStyle.Italic;
			}
			if (radioButton4.Checked)
			{
				style = (FontStyle.Bold | FontStyle.Italic);
			}
			try
			{
				textBox2.Font = new Font(listBox1.Text, trackBar5.Value * 2, style, GraphicsUnit.Pixel);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			chicun();
		}

		private void trackBar5_Scroll(object sender, EventArgs e)
		{
			label17.Text = trackBar5.Value.ToString();
			zi_ti();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			zi_ti();
		}

		private void radioButton5_CheckedChanged(object sender, EventArgs e)
		{
			zi_ti();
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			zi_ti();
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			zi_ti();
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			zi_ti();
		}

		private void label16_MouseDown(object sender, MouseEventArgs e)
		{
			z_anxia = true;
			z_x = e.X;
			z_y = e.Y;
		}

		private void label16_MouseMove(object sender, MouseEventArgs e)
		{
			if (z_anxia)
			{
				panel6.Location = new Point(panel6.Location.X + (e.X - z_x), panel6.Location.Y + (e.Y - z_y));
			}
		}

		private void button34_Click(object sender, EventArgs e)
		{
			MessageBox.Show(is_tj().ToString());
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{
		}

		private void button37_Click(object sender, EventArgs e)
		{
			progressBar1.Value = 1;
			label14.Text = "1%";
			panel7.Visible = true;
			tuo_ji();
			panel7.Visible = false;
			diao.fasong_lianjie2();
			diao.tuoji_diaoke();
			kai_shi = true;
		}

		private void trackBar4_MouseUp(object sender, MouseEventArgs e)
		{
			if (kai_shi)
			{
				diao.gong_shen(trackBar4.Value * 10, trackBar1.Value);
			}
		}

		private void chicun()
		{
			Graphics graphics = textBox2.CreateGraphics();
			string text = textBox2.Text;
			SizeF sizeF = graphics.MeasureString(text, textBox2.Font);
			textBox2.Size = new Size((int)sizeF.Width, (int)sizeF.Height);
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			if (!(textBox2.Text == ""))
			{
				Graphics graphics = textBox2.CreateGraphics();
				string text = textBox2.Text;
				SizeF sizeF = graphics.MeasureString(text, textBox2.Font);
				textBox2.Size = new Size((int)sizeF.Width, (int)sizeF.Height);
			}
		}

		private void timer_flash_Tick(object sender, EventArgs e)
		{
			if (progressBar1.Value + 10 > 100)
			{
				progressBar1.Value = 100;
			}
			else
			{
				progressBar1.Value += 10;
			}
			label14.Text = progressBar1.Value + "%";
		}

		private void button33_Click(object sender, EventArgs e)
		{
			if (mm_in)
			{
				mm_in = false;
				label20.Text = "in";
				label21.Text = "in";
				textBox7.Text = (Convert.ToDouble(textBox7.Text) * 0.0393701).ToString().Substring(0, 5);
				textBox8.Text = (Convert.ToDouble(textBox8.Text) * 0.0393701).ToString().Substring(0, 5);
			}
			else
			{
				mm_in = true;
				label20.Text = "mm";
				label21.Text = "mm";
				textBox7.Text = (Convert.ToDouble(textBox7.Text) / 0.0393701).ToString().Substring(0, 5);
				textBox8.Text = (Convert.ToDouble(textBox8.Text) / 0.0393701).ToString().Substring(0, 5);
			}
			hua_biao_shi();
		}

		private void label16_MouseUp(object sender, MouseEventArgs e)
		{
			z_anxia = false;
		}

		private void button35_Click(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
			{
				checkBox2.Checked = false;
				Thread.Sleep(500);
			}
			if (bj != null)
			{
				if (zhong_xin)
				{
					diao.yidong2(-(bj[0] + (bj[1] - bj[0]) / 2), -(bj[2] + (bj[3] - bj[2]) / 2), new PictureBox(), pp: false);
					zhong_xin = false;
				}
				else
				{
					diao.yidong2(bj[0] + (bj[1] - bj[0]) / 2, bj[2] + (bj[3] - bj[2]) / 2, new PictureBox(), pp: false);
					zhong_xin = true;
				}
			}
		}

		private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (kai_shi)
			{
				return;
			}
			if (checkBox2.Checked)
			{
				MessageBox.Show(str35);
			}
			else if (e.KeyChar == '\r')
			{
				if (mm_in)
				{
					textBox7_TextChanged2(null, null);
					return;
				}
				textBox8.Text = (Convert.ToDouble(textBox7.Text) / kg_bi).ToString().Substring(0, 5);
				xianzhi();
				gai_bian = true;
				panel1.Refresh();
				pan_yidong();
				bj = tu_xiang.qu_bian_jie2(diao.tu_pian);
				hua_biao_shi();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '-')
			{
				MessageBox.Show(str38);
				textBox1.Text = "";
				e.Handled = true;
			}
		}

		private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (kai_shi)
			{
				return;
			}
			if (checkBox2.Checked)
			{
				MessageBox.Show(str35);
			}
			else if (e.KeyChar == '\r')
			{
				if (mm_in)
				{
					textBox8_TextChanged2(null, null);
					return;
				}
				textBox7.Text = (Convert.ToDouble(textBox8.Text) * kg_bi).ToString().Substring(0, 5);
				xianzhi();
				gai_bian = true;
				panel1.Refresh();
				pan_yidong();
				bj = tu_xiang.qu_bian_jie2(diao.tu_pian);
				hua_biao_shi();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '-')
			{
				MessageBox.Show(str38);
				textBox1.Text = "";
				e.Handled = true;
			}
		}

		private void button36_Click(object sender, EventArgs e)
		{
			if (diao.tu_pian != null)
			{
				DateTime dateTime = default(DateTime);
				dateTime = DateTime.Now;
				int month = dateTime.Month;
				int day = dateTime.Day;
				int hour = dateTime.Hour;
				int minute = dateTime.Minute;
				int second = dateTime.Second;
				string text = month.ToString() + day.ToString() + hour.ToString() + minute.ToString() + second.ToString();
				string str = Directory.GetCurrentDirectory() + "\\";
				try
				{
					diao.tu_pian.Save(str + text + ".bmp", ImageFormat.Bmp);
				}
				catch (Exception ex)
				{
					MessageBox.Show(str53 + "\r\n" + ex.ToString());
					return;
				}
				MessageBox.Show(str39 + str + text + ".bmp");
			}
		}

		private void panel4_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = panel4.CreateGraphics();
			graphics.DrawImage(biao_shi_k, 0, 0);
			graphics.Dispose();
		}

		private void panel5_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = panel5.CreateGraphics();
			graphics.DrawImage(biao_shi_g, 0, 0);
			graphics.Dispose();
		}

		private void panel1_LocationChanged(object sender, EventArgs e)
		{
			hua_biao_shi();
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(微型雕刻机2.Form1));
			panel1 = new System.Windows.Forms.Panel();
			button10 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			button18 = new System.Windows.Forms.Button();
			button19 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			checkBox1 = new System.Windows.Forms.CheckBox();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			com = new System.IO.Ports.SerialPort(components);
			dakai = new System.Windows.Forms.OpenFileDialog();
			da_kai_g = new System.Windows.Forms.OpenFileDialog();
			fontDialog1 = new System.Windows.Forms.FontDialog();
			panel2 = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			button17 = new System.Windows.Forms.Button();
			jdt = new System.Windows.Forms.ProgressBar();
			button20 = new System.Windows.Forms.Button();
			button21 = new System.Windows.Forms.Button();
			button22 = new System.Windows.Forms.Button();
			button23 = new System.Windows.Forms.Button();
			button24 = new System.Windows.Forms.Button();
			button25 = new System.Windows.Forms.Button();
			button15 = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			button16 = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			button27 = new System.Windows.Forms.Button();
			trackBar2 = new System.Windows.Forms.TrackBar();
			label2 = new System.Windows.Forms.Label();
			hei_bai = new System.Windows.Forms.RadioButton();
			li_san = new System.Windows.Forms.RadioButton();
			hui_du = new System.Windows.Forms.RadioButton();
			textBox3 = new System.Windows.Forms.TextBox();
			trackBar1 = new System.Windows.Forms.TrackBar();
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			trackBar4 = new System.Windows.Forms.TrackBar();
			textBox5 = new System.Windows.Forms.TextBox();
			checkBox2 = new System.Windows.Forms.CheckBox();
			button11 = new System.Windows.Forms.Button();
			button12 = new System.Windows.Forms.Button();
			button13 = new System.Windows.Forms.Button();
			button14 = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			textBox8 = new System.Windows.Forms.TextBox();
			textBox7 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			button30 = new System.Windows.Forms.Button();
			button28 = new System.Windows.Forms.Button();
			button26 = new System.Windows.Forms.Button();
			label13 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			timer1 = new System.Windows.Forms.Timer(components);
			button29 = new System.Windows.Forms.Button();
			button31 = new System.Windows.Forms.Button();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			button32 = new System.Windows.Forms.Button();
			timer2 = new System.Windows.Forms.Timer(components);
			label12 = new System.Windows.Forms.Label();
			timer3 = new System.Windows.Forms.Timer(components);
			groupBox4 = new System.Windows.Forms.GroupBox();
			button36 = new System.Windows.Forms.Button();
			button35 = new System.Windows.Forms.Button();
			panel6 = new System.Windows.Forms.Panel();
			label17 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			radioButton4 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton5 = new System.Windows.Forms.RadioButton();
			listBox1 = new System.Windows.Forms.ListBox();
			trackBar5 = new System.Windows.Forms.TrackBar();
			groupBox5 = new System.Windows.Forms.GroupBox();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			panel4 = new System.Windows.Forms.Panel();
			panel5 = new System.Windows.Forms.Panel();
			button33 = new System.Windows.Forms.Button();
			button34 = new System.Windows.Forms.Button();
			button37 = new System.Windows.Forms.Button();
			panel7 = new System.Windows.Forms.Panel();
			label14 = new System.Windows.Forms.Label();
			progressBar1 = new System.Windows.Forms.ProgressBar();
			timer_flash = new System.Windows.Forms.Timer(components);
			trackBar3 = new System.Windows.Forms.TrackBar();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar5).BeginInit();
			groupBox5.SuspendLayout();
			panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			panel1.Location = new System.Drawing.Point(25, 60);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(247, 176);
			panel1.TabIndex = 1;
			panel1.TabStop = true;
			panel1.LocationChanged += new System.EventHandler(panel1_LocationChanged);
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
			panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(panel1_MouseMove);
			panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(panel1_MouseUp);
			button10.BackColor = System.Drawing.Color.Transparent;
			button10.Cursor = System.Windows.Forms.Cursors.SizeAll;
			button10.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			button10.Location = new System.Drawing.Point(438, 187);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(17, 17);
			button10.TabIndex = 2;
			button10.UseVisualStyleBackColor = false;
			button10.Visible = false;
			button10.MouseDown += new System.Windows.Forms.MouseEventHandler(button10_MouseDown);
			button10.MouseMove += new System.Windows.Forms.MouseEventHandler(button10_MouseMove);
			button10.MouseUp += new System.Windows.Forms.MouseEventHandler(button10_MouseUp);
			button9.BackColor = System.Drawing.Color.Transparent;
			button9.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
			button9.Location = new System.Drawing.Point(453, 203);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(17, 17);
			button9.TabIndex = 1;
			button9.UseVisualStyleBackColor = false;
			button9.Visible = false;
			button9.MouseDown += new System.Windows.Forms.MouseEventHandler(button9_MouseDown);
			button9.MouseMove += new System.Windows.Forms.MouseEventHandler(button9_MouseMove);
			button9.MouseUp += new System.Windows.Forms.MouseEventHandler(button9_MouseUp);
			textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			textBox2.Cursor = System.Windows.Forms.Cursors.SizeAll;
			textBox2.Font = new System.Drawing.Font("宋体", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox2.Location = new System.Drawing.Point(278, 61);
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(177, 143);
			textBox2.TabIndex = 0;
			textBox2.Visible = false;
			textBox2.LocationChanged += new System.EventHandler(textBox2_LocationChanged);
			textBox2.TextChanged += new System.EventHandler(textBox2_TextChanged);
			textBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(textBox2_MouseDown);
			textBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(textBox2_MouseMove);
			textBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(textBox2_MouseUp);
			button18.Location = new System.Drawing.Point(1001, 210);
			button18.Name = "button18";
			button18.Size = new System.Drawing.Size(35, 35);
			button18.TabIndex = 30;
			button18.UseVisualStyleBackColor = true;
			button18.Visible = false;
			button18.Click += new System.EventHandler(button18_Click);
			button19.Location = new System.Drawing.Point(984, 211);
			button19.Name = "button19";
			button19.Size = new System.Drawing.Size(35, 35);
			button19.TabIndex = 31;
			button19.UseVisualStyleBackColor = true;
			button19.Visible = false;
			button19.Click += new System.EventHandler(button19_Click);
			button1.BackColor = System.Drawing.Color.Transparent;
			button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			button1.ForeColor = System.Drawing.Color.Blue;
			button1.Location = new System.Drawing.Point(532, 14);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(107, 32);
			button1.TabIndex = 1;
			button1.Text = "設備接続";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(button1_Click);
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(949, 7);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(66, 16);
			checkBox1.TabIndex = 2;
			checkBox1.Text = "250*250";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.Visible = false;
			button2.BackColor = System.Drawing.Color.Transparent;
			button2.Location = new System.Drawing.Point(532, 52);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(107, 33);
			button2.TabIndex = 3;
			button2.Text = "絵図導入";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(button2_Click);
			button3.BackColor = System.Drawing.Color.Transparent;
			button3.ForeColor = System.Drawing.Color.Red;
			button3.Location = new System.Drawing.Point(825, 7);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(94, 30);
			button3.TabIndex = 4;
			button3.Text = "模拟发送错误";
			button3.UseVisualStyleBackColor = false;
			button3.Click += new System.EventHandler(button3_Click);
			button6.BackColor = System.Drawing.Color.Transparent;
			button6.Location = new System.Drawing.Point(917, 73);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(107, 30);
			button6.TabIndex = 6;
			button6.Text = "打开G代码";
			button6.UseVisualStyleBackColor = false;
			button6.Click += new System.EventHandler(button6_Click);
			button7.BackColor = System.Drawing.Color.Transparent;
			button7.Location = new System.Drawing.Point(994, 105);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(107, 30);
			button7.TabIndex = 11;
			button7.Text = "快进>>";
			button7.UseVisualStyleBackColor = false;
			button7.Click += new System.EventHandler(button7_Click);
			button8.BackColor = System.Drawing.Color.Transparent;
			button8.Location = new System.Drawing.Point(917, 109);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(107, 30);
			button8.TabIndex = 10;
			button8.Text = "<<快退";
			button8.UseVisualStyleBackColor = false;
			button8.Click += new System.EventHandler(button8_Click);
			button4.BackColor = System.Drawing.Color.Transparent;
			button4.ForeColor = System.Drawing.Color.Red;
			button4.Location = new System.Drawing.Point(532, 91);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(71, 36);
			button4.TabIndex = 12;
			button4.Text = "スタ\u30fcト";
			button4.UseVisualStyleBackColor = false;
			button4.Click += new System.EventHandler(button4_Click);
			button4.MouseDown += new System.Windows.Forms.MouseEventHandler(button4_MouseDown);
			button4.MouseUp += new System.Windows.Forms.MouseEventHandler(button4_MouseUp);
			button5.BackColor = System.Drawing.Color.Transparent;
			button5.Location = new System.Drawing.Point(655, 52);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(107, 33);
			button5.TabIndex = 13;
			button5.Text = "文字編集";
			button5.UseVisualStyleBackColor = false;
			button5.Click += new System.EventHandler(button5_Click);
			com.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(com_ErrorReceived);
			com.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(com_DataReceived);
			dakai.FileName = "openFileDialog1";
			dakai.Filter = "ビットマップファイル|*.bmp;*.jpg;*.jpge;*.png;";
			da_kai_g.FileName = "openFileDialog1";
			da_kai_g.Filter = "刀路文件|*.NC|所有文件|*.*";
			fontDialog1.Font = new System.Drawing.Font("宋体", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel2.BackColor = System.Drawing.Color.Transparent;
			panel2.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel2.BackgroundImage");
			panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			panel2.Controls.Add(panel3);
			panel2.Location = new System.Drawing.Point(692, 14);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(32, 32);
			panel2.TabIndex = 23;
			panel2.Paint += new System.Windows.Forms.PaintEventHandler(panel2_Paint);
			panel3.BackColor = System.Drawing.Color.Transparent;
			panel3.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel3.BackgroundImage");
			panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			panel3.Location = new System.Drawing.Point(0, 0);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(32, 32);
			panel3.TabIndex = 44;
			panel3.Visible = false;
			button17.BackColor = System.Drawing.Color.Transparent;
			button17.Location = new System.Drawing.Point(962, 387);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(215, 38);
			button17.TabIndex = 28;
			button17.Text = "发送脱机数据";
			button17.UseVisualStyleBackColor = false;
			button17.Click += new System.EventHandler(button17_Click);
			jdt.Location = new System.Drawing.Point(963, 427);
			jdt.Name = "jdt";
			jdt.Size = new System.Drawing.Size(213, 10);
			jdt.TabIndex = 29;
			jdt.Visible = false;
			button20.BackColor = System.Drawing.Color.Transparent;
			button20.Image = (System.Drawing.Image)resources.GetObject("button20.Image");
			button20.Location = new System.Drawing.Point(178, 9);
			button20.Name = "button20";
			button20.Size = new System.Drawing.Size(35, 35);
			button20.TabIndex = 32;
			button20.UseVisualStyleBackColor = false;
			button20.Click += new System.EventHandler(button20_Click);
			button21.BackColor = System.Drawing.Color.Transparent;
			button21.Image = (System.Drawing.Image)resources.GetObject("button21.Image");
			button21.Location = new System.Drawing.Point(25, 9);
			button21.Name = "button21";
			button21.Size = new System.Drawing.Size(35, 35);
			button21.TabIndex = 33;
			button21.UseVisualStyleBackColor = false;
			button21.Click += new System.EventHandler(button21_Click);
			button22.BackColor = System.Drawing.Color.Transparent;
			button22.Image = (System.Drawing.Image)resources.GetObject("button22.Image");
			button22.Location = new System.Drawing.Point(76, 9);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(35, 35);
			button22.TabIndex = 34;
			button22.UseVisualStyleBackColor = false;
			button22.Click += new System.EventHandler(button22_Click);
			button23.BackColor = System.Drawing.Color.Transparent;
			button23.Image = (System.Drawing.Image)resources.GetObject("button23.Image");
			button23.Location = new System.Drawing.Point(928, 29);
			button23.Name = "button23";
			button23.Size = new System.Drawing.Size(35, 35);
			button23.TabIndex = 35;
			button23.UseVisualStyleBackColor = false;
			button23.Click += new System.EventHandler(button23_Click);
			button24.BackColor = System.Drawing.Color.Transparent;
			button24.Location = new System.Drawing.Point(690, 91);
			button24.Name = "button24";
			button24.Size = new System.Drawing.Size(71, 36);
			button24.TabIndex = 37;
			button24.Text = "停止";
			button24.UseVisualStyleBackColor = false;
			button24.Click += new System.EventHandler(button24_Click);
			button25.BackColor = System.Drawing.Color.Transparent;
			button25.Image = (System.Drawing.Image)resources.GetObject("button25.Image");
			button25.Location = new System.Drawing.Point(127, 9);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(35, 35);
			button25.TabIndex = 31;
			button25.UseVisualStyleBackColor = false;
			button25.Click += new System.EventHandler(button25_Click);
			button15.BackColor = System.Drawing.Color.Transparent;
			button15.Image = (System.Drawing.Image)resources.GetObject("button15.Image");
			button15.Location = new System.Drawing.Point(280, 9);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(35, 35);
			button15.TabIndex = 31;
			button15.UseVisualStyleBackColor = false;
			button15.Click += new System.EventHandler(button15_Click_1);
			label3.AutoSize = true;
			label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			label3.Font = new System.Drawing.Font("宋体", 13f);
			label3.Location = new System.Drawing.Point(875, 534);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(44, 18);
			label3.TabIndex = 32;
			label3.Text = "缩放";
			label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label5.Font = new System.Drawing.Font("宋体", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label5.ForeColor = System.Drawing.Color.Blue;
			label5.Location = new System.Drawing.Point(1013, 509);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(92, 31);
			label5.TabIndex = 41;
			label5.Text = "Y：";
			label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label4.Font = new System.Drawing.Font("宋体", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label4.ForeColor = System.Drawing.Color.Blue;
			label4.Location = new System.Drawing.Point(952, 479);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(92, 31);
			label4.TabIndex = 42;
			label4.Text = "X：";
			button16.BackColor = System.Drawing.Color.Transparent;
			button16.ForeColor = System.Drawing.Color.Red;
			button16.Location = new System.Drawing.Point(928, 145);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(53, 30);
			button16.TabIndex = 43;
			button16.Text = "开始";
			button16.UseVisualStyleBackColor = false;
			button16.Visible = false;
			button16.Click += new System.EventHandler(button16_Click_1);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(954, 289);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(65, 12);
			label6.TabIndex = 47;
			label6.Text = "激光功率：";
			button27.BackColor = System.Drawing.Color.Transparent;
			button27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button27.Image = (System.Drawing.Image)resources.GetObject("button27.Image");
			button27.Location = new System.Drawing.Point(229, 9);
			button27.Name = "button27";
			button27.Size = new System.Drawing.Size(35, 35);
			button27.TabIndex = 52;
			button27.UseVisualStyleBackColor = false;
			button27.Click += new System.EventHandler(button27_Click);
			trackBar2.Location = new System.Drawing.Point(3, 20);
			trackBar2.Maximum = 253;
			trackBar2.Name = "trackBar2";
			trackBar2.Size = new System.Drawing.Size(194, 45);
			trackBar2.TabIndex = 16;
			trackBar2.Value = 128;
			trackBar2.Scroll += new System.EventHandler(trackBar2_Scroll);
			trackBar2.MouseUp += new System.Windows.Forms.MouseEventHandler(trackBar2_MouseUp);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(869, 244);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(65, 12);
			label2.TabIndex = 17;
			label2.Text = "絵図調整：";
			label2.Visible = false;
			hei_bai.AutoSize = true;
			hei_bai.Checked = true;
			hei_bai.Location = new System.Drawing.Point(6, 24);
			hei_bai.Name = "hei_bai";
			hei_bai.Size = new System.Drawing.Size(47, 16);
			hei_bai.TabIndex = 49;
			hei_bai.TabStop = true;
			hei_bai.Text = "黒白";
			hei_bai.UseVisualStyleBackColor = true;
			hei_bai.CheckedChanged += new System.EventHandler(hei_bai_CheckedChanged);
			li_san.AutoSize = true;
			li_san.Location = new System.Drawing.Point(6, 43);
			li_san.Name = "li_san";
			li_san.Size = new System.Drawing.Size(47, 16);
			li_san.TabIndex = 50;
			li_san.Text = "离散";
			li_san.UseVisualStyleBackColor = true;
			li_san.CheckedChanged += new System.EventHandler(li_san_CheckedChanged);
			li_san.MouseDown += new System.Windows.Forms.MouseEventHandler(li_san_MouseDown);
			hui_du.AutoSize = true;
			hui_du.Location = new System.Drawing.Point(129, 24);
			hui_du.Name = "hui_du";
			hui_du.Size = new System.Drawing.Size(107, 16);
			hui_du.TabIndex = 51;
			hui_du.Text = "グレ\u30fcスケ\u30fcル";
			hui_du.UseVisualStyleBackColor = true;
			hui_du.Visible = false;
			hui_du.CheckedChanged += new System.EventHandler(hui_du_CheckedChanged);
			textBox3.BackColor = System.Drawing.Color.Gainsboro;
			textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox3.Location = new System.Drawing.Point(195, 23);
			textBox3.Name = "textBox3";
			textBox3.ReadOnly = true;
			textBox3.Size = new System.Drawing.Size(33, 14);
			textBox3.TabIndex = 18;
			textBox3.Text = "128";
			textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3.TextChanged += new System.EventHandler(textBox3_TextChanged);
			trackBar1.Location = new System.Drawing.Point(3, 20);
			trackBar1.Maximum = 100;
			trackBar1.Minimum = 1;
			trackBar1.Name = "trackBar1";
			trackBar1.Size = new System.Drawing.Size(191, 45);
			trackBar1.TabIndex = 8;
			trackBar1.Value = 10;
			trackBar1.Scroll += new System.EventHandler(trackBar1_Scroll);
			trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(trackBar1_MouseUp);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(869, 371);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(101, 12);
			label1.TabIndex = 9;
			label1.Text = "彫刻の深さ調整：";
			label1.Visible = false;
			textBox1.BackColor = System.Drawing.Color.Gainsboro;
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox1.Location = new System.Drawing.Point(195, 23);
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new System.Drawing.Size(33, 14);
			textBox1.TabIndex = 14;
			textBox1.Text = "10";
			textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
			trackBar4.Location = new System.Drawing.Point(2, 15);
			trackBar4.Maximum = 100;
			trackBar4.Name = "trackBar4";
			trackBar4.Size = new System.Drawing.Size(195, 45);
			trackBar4.TabIndex = 46;
			trackBar4.Value = 100;
			trackBar4.Scroll += new System.EventHandler(trackBar4_Scroll);
			trackBar4.MouseUp += new System.Windows.Forms.MouseEventHandler(trackBar4_MouseUp);
			textBox5.BackColor = System.Drawing.Color.Gainsboro;
			textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox5.Location = new System.Drawing.Point(191, 15);
			textBox5.Name = "textBox5";
			textBox5.ReadOnly = true;
			textBox5.Size = new System.Drawing.Size(35, 14);
			textBox5.TabIndex = 48;
			textBox5.Text = "100";
			textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5.TextChanged += new System.EventHandler(textBox5_TextChanged);
			checkBox2.AutoSize = true;
			checkBox2.Location = new System.Drawing.Point(866, 404);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(60, 16);
			checkBox2.TabIndex = 15;
			checkBox2.Text = "框定位";
			checkBox2.UseVisualStyleBackColor = true;
			checkBox2.Visible = false;
			checkBox2.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged);
			button11.BackColor = System.Drawing.Color.Transparent;
			button11.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			button11.Location = new System.Drawing.Point(82, 62);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(67, 35);
			button11.TabIndex = 19;
			button11.Text = "↑";
			button11.UseVisualStyleBackColor = false;
			button11.Click += new System.EventHandler(button11_Click);
			button12.BackColor = System.Drawing.Color.Transparent;
			button12.Location = new System.Drawing.Point(82, 141);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(67, 35);
			button12.TabIndex = 20;
			button12.Text = "↓";
			button12.UseVisualStyleBackColor = false;
			button12.Click += new System.EventHandler(button12_Click);
			button13.BackColor = System.Drawing.Color.Transparent;
			button13.Location = new System.Drawing.Point(9, 101);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(67, 35);
			button13.TabIndex = 21;
			button13.Text = "←";
			button13.UseVisualStyleBackColor = false;
			button13.Click += new System.EventHandler(button13_Click);
			button14.BackColor = System.Drawing.Color.Transparent;
			button14.Location = new System.Drawing.Point(155, 101);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(67, 35);
			button14.TabIndex = 22;
			button14.Text = "→";
			button14.UseVisualStyleBackColor = false;
			button14.Click += new System.EventHandler(button14_Click);
			groupBox1.Controls.Add(hui_du);
			groupBox1.Controls.Add(li_san);
			groupBox1.Controls.Add(hei_bai);
			groupBox1.Location = new System.Drawing.Point(532, 131);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(231, 65);
			groupBox1.TabIndex = 53;
			groupBox1.TabStop = false;
			groupBox1.Text = "彫刻スタイル選択";
			groupBox2.Controls.Add(textBox1);
			groupBox2.Controls.Add(trackBar1);
			groupBox2.Location = new System.Drawing.Point(532, 301);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(230, 50);
			groupBox2.TabIndex = 54;
			groupBox2.TabStop = false;
			groupBox2.Text = "レ\u30fcザ\u30fc彫刻パラメ\u30fcタ調整";
			groupBox3.Controls.Add(textBox8);
			groupBox3.Controls.Add(textBox7);
			groupBox3.Controls.Add(label21);
			groupBox3.Controls.Add(label20);
			groupBox3.Controls.Add(label19);
			groupBox3.Controls.Add(label18);
			groupBox3.Controls.Add(button30);
			groupBox3.Controls.Add(button28);
			groupBox3.Controls.Add(button26);
			groupBox3.Controls.Add(button14);
			groupBox3.Controls.Add(button13);
			groupBox3.Controls.Add(button12);
			groupBox3.Controls.Add(button11);
			groupBox3.Location = new System.Drawing.Point(534, 357);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(229, 204);
			groupBox3.TabIndex = 55;
			groupBox3.TabStop = false;
			groupBox3.Text = "レ\u30fcザ\u30fc位置調整";
			groupBox3.Enter += new System.EventHandler(groupBox3_Enter);
			textBox8.Location = new System.Drawing.Point(156, 178);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(46, 21);
			textBox8.TabIndex = 30;
			textBox8.Text = "10";
			textBox8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox8_KeyPress);
			textBox7.Location = new System.Drawing.Point(41, 178);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(46, 21);
			textBox7.TabIndex = 29;
			textBox7.Text = "10";
			textBox7.TextChanged += new System.EventHandler(textBox7_TextChanged);
			textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox7_KeyPress);
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(206, 183);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(17, 12);
			label21.TabIndex = 38;
			label21.Text = "MM";
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(91, 183);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(17, 12);
			label20.TabIndex = 37;
			label20.Text = "MM";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(119, 181);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(41, 12);
			label19.TabIndex = 36;
			label19.Text = "高度：";
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(6, 181);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(41, 12);
			label18.TabIndex = 35;
			label18.Text = "宽度：";
			button30.BackColor = System.Drawing.Color.Transparent;
			button30.Location = new System.Drawing.Point(82, 101);
			button30.Name = "button30";
			button30.Size = new System.Drawing.Size(67, 34);
			button30.TabIndex = 28;
			button30.Text = "中心に戻る";
			button30.UseVisualStyleBackColor = false;
			button30.Click += new System.EventHandler(button30_Click);
			button28.BackColor = System.Drawing.Color.Transparent;
			button28.Location = new System.Drawing.Point(37, 20);
			button28.Name = "button28";
			button28.Size = new System.Drawing.Size(75, 36);
			button28.TabIndex = 26;
			button28.Text = "彫刻範囲プレビュ\u30fc";
			button28.UseVisualStyleBackColor = false;
			button28.Click += new System.EventHandler(button28_Click);
			button26.BackColor = System.Drawing.Color.Transparent;
			button26.Location = new System.Drawing.Point(117, 20);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(75, 36);
			button26.TabIndex = 25;
			button26.Text = "原点に戻る";
			button26.UseVisualStyleBackColor = false;
			button26.Click += new System.EventHandler(button26_Click_1);
			label13.AutoSize = true;
			label13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			label13.Font = new System.Drawing.Font("宋体", 13f);
			label13.Location = new System.Drawing.Point(1034, 538);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 18);
			label13.TabIndex = 37;
			label13.Text = "缩放";
			label13.Click += new System.EventHandler(label13_Click);
			textBox4.CausesValidation = false;
			textBox4.Location = new System.Drawing.Point(866, 318);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(53, 21);
			textBox4.TabIndex = 24;
			textBox4.Text = "20";
			textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4.TextChanged += new System.EventHandler(textBox4_TextChanged);
			textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox4_KeyPress);
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(851, 420);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(53, 12);
			label7.TabIndex = 27;
			label7.Text = "步进值：";
			label7.Visible = false;
			label7.Click += new System.EventHandler(label7_Click);
			timer1.Enabled = true;
			timer1.Interval = 300;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			button29.BackColor = System.Drawing.Color.Transparent;
			button29.ForeColor = System.Drawing.Color.Blue;
			button29.Location = new System.Drawing.Point(611, 91);
			button29.Name = "button29";
			button29.Size = new System.Drawing.Size(71, 36);
			button29.TabIndex = 56;
			button29.Text = "一時停止";
			button29.UseVisualStyleBackColor = false;
			button29.Click += new System.EventHandler(button29_Click);
			button29.MouseDown += new System.Windows.Forms.MouseEventHandler(button29_MouseDown);
			button31.Location = new System.Drawing.Point(871, 278);
			button31.Name = "button31";
			button31.Size = new System.Drawing.Size(55, 19);
			button31.TabIndex = 57;
			button31.Text = "button31";
			button31.UseVisualStyleBackColor = true;
			button31.Visible = false;
			button31.Click += new System.EventHandler(button31_Click);
			label8.BackColor = System.Drawing.Color.Black;
			label8.Location = new System.Drawing.Point(25, 60);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(500, 1);
			label8.TabIndex = 58;
			label8.Text = "label8";
			label9.BackColor = System.Drawing.Color.Black;
			label9.Location = new System.Drawing.Point(25, 560);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(500, 1);
			label9.TabIndex = 59;
			label9.Text = "label9";
			label10.BackColor = System.Drawing.Color.Black;
			label10.Location = new System.Drawing.Point(25, 60);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(1, 500);
			label10.TabIndex = 60;
			label10.Text = "label10";
			label11.BackColor = System.Drawing.Color.Black;
			label11.Location = new System.Drawing.Point(525, 60);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(1, 500);
			label11.TabIndex = 61;
			label11.Text = "label11";
			button32.BackColor = System.Drawing.Color.Transparent;
			button32.Font = new System.Drawing.Font("宋体", 20f);
			button32.Image = (System.Drawing.Image)resources.GetObject("button32.Image");
			button32.Location = new System.Drawing.Point(331, 9);
			button32.Name = "button32";
			button32.Size = new System.Drawing.Size(35, 35);
			button32.TabIndex = 62;
			button32.UseVisualStyleBackColor = false;
			button32.Click += new System.EventHandler(button32_Click);
			timer2.Enabled = true;
			timer2.Tick += new System.EventHandler(timer2_Tick);
			label12.AutoSize = true;
			label12.BackColor = System.Drawing.Color.Transparent;
			label12.Location = new System.Drawing.Point(32, 543);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(0, 12);
			label12.TabIndex = 63;
			timer3.Interval = 1000;
			timer3.Tick += new System.EventHandler(timer3_Tick);
			groupBox4.Controls.Add(trackBar4);
			groupBox4.Controls.Add(textBox5);
			groupBox4.Location = new System.Drawing.Point(532, 251);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(231, 50);
			groupBox4.TabIndex = 64;
			groupBox4.TabStop = false;
			groupBox4.Text = "レ\u30fcザ\u30fc彫刻パラメ\u30fcタ調整";
			button36.BackColor = System.Drawing.Color.Transparent;
			button36.Font = new System.Drawing.Font("宋体", 20f);
			button36.Image = (System.Drawing.Image)resources.GetObject("button36.Image");
			button36.Location = new System.Drawing.Point(484, 9);
			button36.Name = "button36";
			button36.Size = new System.Drawing.Size(35, 35);
			button36.TabIndex = 76;
			button36.UseVisualStyleBackColor = false;
			button36.Click += new System.EventHandler(button36_Click);
			button35.BackColor = System.Drawing.Color.Transparent;
			button35.Font = new System.Drawing.Font("宋体", 20f);
			button35.Image = (System.Drawing.Image)resources.GetObject("button35.Image");
			button35.Location = new System.Drawing.Point(382, 9);
			button35.Name = "button35";
			button35.Size = new System.Drawing.Size(35, 35);
			button35.TabIndex = 75;
			button35.UseVisualStyleBackColor = false;
			button35.Click += new System.EventHandler(button35_Click);
			panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel6.Controls.Add(label17);
			panel6.Controls.Add(label16);
			panel6.Controls.Add(radioButton4);
			panel6.Controls.Add(radioButton3);
			panel6.Controls.Add(radioButton2);
			panel6.Controls.Add(radioButton5);
			panel6.Controls.Add(listBox1);
			panel6.Controls.Add(trackBar5);
			panel6.Location = new System.Drawing.Point(127, 271);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(303, 290);
			panel6.TabIndex = 77;
			panel6.Visible = false;
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(14, 35);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(17, 12);
			label17.TabIndex = 13;
			label17.Text = "16";
			label16.BackColor = System.Drawing.Color.FromArgb(128, 255, 255);
			label16.Location = new System.Drawing.Point(0, 0);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(303, 24);
			label16.TabIndex = 12;
			label16.Text = "字体选择";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label16.MouseDown += new System.Windows.Forms.MouseEventHandler(label16_MouseDown);
			label16.MouseMove += new System.Windows.Forms.MouseEventHandler(label16_MouseMove);
			label16.MouseUp += new System.Windows.Forms.MouseEventHandler(label16_MouseUp);
			radioButton4.AutoSize = true;
			radioButton4.Location = new System.Drawing.Point(198, 253);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(71, 16);
			radioButton4.TabIndex = 11;
			radioButton4.Text = "粗体斜体";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton4.CheckedChanged += new System.EventHandler(radioButton4_CheckedChanged);
			radioButton3.AutoSize = true;
			radioButton3.Location = new System.Drawing.Point(198, 192);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(47, 16);
			radioButton3.TabIndex = 10;
			radioButton3.Text = "斜体";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton3.CheckedChanged += new System.EventHandler(radioButton3_CheckedChanged);
			radioButton2.AutoSize = true;
			radioButton2.Location = new System.Drawing.Point(198, 131);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(47, 16);
			radioButton2.TabIndex = 9;
			radioButton2.Text = "粗体";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton2.CheckedChanged += new System.EventHandler(radioButton2_CheckedChanged);
			radioButton5.AutoSize = true;
			radioButton5.Checked = true;
			radioButton5.Location = new System.Drawing.Point(198, 70);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(47, 16);
			radioButton5.TabIndex = 8;
			radioButton5.TabStop = true;
			radioButton5.Text = "常规";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton5.CheckedChanged += new System.EventHandler(radioButton5_CheckedChanged);
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 12;
			listBox1.Location = new System.Drawing.Point(20, 68);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(172, 208);
			listBox1.TabIndex = 7;
			listBox1.SelectedIndexChanged += new System.EventHandler(listBox1_SelectedIndexChanged);
			trackBar5.Location = new System.Drawing.Point(38, 29);
			trackBar5.Maximum = 100;
			trackBar5.Minimum = 1;
			trackBar5.Name = "trackBar5";
			trackBar5.Size = new System.Drawing.Size(244, 45);
			trackBar5.TabIndex = 6;
			trackBar5.TickStyle = System.Windows.Forms.TickStyle.None;
			trackBar5.Value = 16;
			trackBar5.Scroll += new System.EventHandler(trackBar5_Scroll);
			groupBox5.Controls.Add(textBox3);
			groupBox5.Controls.Add(trackBar2);
			groupBox5.Location = new System.Drawing.Point(532, 191);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(231, 57);
			groupBox5.TabIndex = 78;
			groupBox5.TabStop = false;
			groupBox5.Text = "groupBox5";
			toolTip1.IsBalloon = true;
			panel4.Location = new System.Drawing.Point(29, 43);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(76, 17);
			panel4.TabIndex = 79;
			panel4.Paint += new System.Windows.Forms.PaintEventHandler(panel4_Paint);
			panel5.Location = new System.Drawing.Point(8, 203);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(17, 77);
			panel5.TabIndex = 80;
			panel5.Paint += new System.Windows.Forms.PaintEventHandler(panel5_Paint);
			button33.BackColor = System.Drawing.Color.Transparent;
			button33.Font = new System.Drawing.Font("宋体", 20f);
			button33.Image = (System.Drawing.Image)resources.GetObject("button33.Image");
			button33.Location = new System.Drawing.Point(433, 9);
			button33.Name = "button33";
			button33.Size = new System.Drawing.Size(35, 35);
			button33.TabIndex = 81;
			button33.UseVisualStyleBackColor = false;
			button33.Click += new System.EventHandler(button33_Click);
			button34.BackColor = System.Drawing.Color.Transparent;
			button34.ForeColor = System.Drawing.Color.Red;
			button34.Location = new System.Drawing.Point(825, 43);
			button34.Name = "button34";
			button34.Size = new System.Drawing.Size(94, 30);
			button34.TabIndex = 82;
			button34.Text = "模拟接收错误";
			button34.UseVisualStyleBackColor = false;
			button34.Click += new System.EventHandler(button34_Click);
			button37.BackColor = System.Drawing.Color.Transparent;
			button37.Font = new System.Drawing.Font("宋体", 20f);
			button37.Image = (System.Drawing.Image)resources.GetObject("button37.Image");
			button37.Location = new System.Drawing.Point(647, 9);
			button37.Name = "button37";
			button37.Size = new System.Drawing.Size(35, 35);
			button37.TabIndex = 83;
			button37.UseVisualStyleBackColor = false;
			button37.Visible = false;
			button37.Click += new System.EventHandler(button37_Click);
			panel7.Controls.Add(label14);
			panel7.Controls.Add(progressBar1);
			panel7.Location = new System.Drawing.Point(25, 564);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(501, 19);
			panel7.TabIndex = 84;
			panel7.Visible = false;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(474, 4);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(17, 12);
			label14.TabIndex = 1;
			label14.Text = "1%";
			progressBar1.Location = new System.Drawing.Point(0, 0);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new System.Drawing.Size(473, 19);
			progressBar1.TabIndex = 0;
			timer_flash.Interval = 1000;
			timer_flash.Tick += new System.EventHandler(timer_flash_Tick);
			trackBar3.AutoSize = false;
			trackBar3.Location = new System.Drawing.Point(924, 526);
			trackBar3.Maximum = 3200;
			trackBar3.Name = "trackBar3";
			trackBar3.Size = new System.Drawing.Size(136, 31);
			trackBar3.TabIndex = 36;
			trackBar3.Value = 1650;
			trackBar3.MouseUp += new System.Windows.Forms.MouseEventHandler(trackBar3_MouseUp);
			AllowDrop = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Gainsboro;
			base.ClientSize = new System.Drawing.Size(769, 584);
			base.Controls.Add(label12);
			base.Controls.Add(panel7);
			base.Controls.Add(button37);
			base.Controls.Add(button34);
			base.Controls.Add(button33);
			base.Controls.Add(panel5);
			base.Controls.Add(panel4);
			base.Controls.Add(panel6);
			base.Controls.Add(groupBox5);
			base.Controls.Add(label13);
			base.Controls.Add(label3);
			base.Controls.Add(button36);
			base.Controls.Add(button35);
			base.Controls.Add(label1);
			base.Controls.Add(button32);
			base.Controls.Add(textBox4);
			base.Controls.Add(trackBar3);
			base.Controls.Add(label11);
			base.Controls.Add(label10);
			base.Controls.Add(label2);
			base.Controls.Add(label9);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(button31);
			base.Controls.Add(button10);
			base.Controls.Add(button29);
			base.Controls.Add(label6);
			base.Controls.Add(button9);
			base.Controls.Add(groupBox3);
			base.Controls.Add(textBox2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(checkBox2);
			base.Controls.Add(button27);
			base.Controls.Add(button16);
			base.Controls.Add(label4);
			base.Controls.Add(label5);
			base.Controls.Add(button18);
			base.Controls.Add(button19);
			base.Controls.Add(button15);
			base.Controls.Add(button25);
			base.Controls.Add(button24);
			base.Controls.Add(button23);
			base.Controls.Add(button22);
			base.Controls.Add(button21);
			base.Controls.Add(button20);
			base.Controls.Add(jdt);
			base.Controls.Add(button17);
			base.Controls.Add(panel2);
			base.Controls.Add(checkBox1);
			base.Controls.Add(button5);
			base.Controls.Add(button4);
			base.Controls.Add(button7);
			base.Controls.Add(button8);
			base.Controls.Add(button6);
			base.Controls.Add(button3);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(panel1);
			base.Controls.Add(groupBox4);
			base.Controls.Add(groupBox2);
			DoubleBuffered = true;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Form1";
			Text = "激光雕刻机";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Form1_FormClosed);
			base.Load += new System.EventHandler(Form1_Load);
			base.DragDrop += new System.Windows.Forms.DragEventHandler(Form1_DragDrop);
			base.DragEnter += new System.Windows.Forms.DragEventHandler(Form1_DragEnter);
			panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar5).EndInit();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			panel7.ResumeLayout(false);
			panel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
