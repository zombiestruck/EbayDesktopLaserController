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

namespace MiniEngraver
{
	public class Form1 : Form
	{
		public delegate void MyInvoke();

		[Flags]
		private enum ExecutionFlag : uint
		{
			System = 0x1,
			Display = 0x2,
			Continus = 0x80000000
		}

		private engraving_machine engraver;

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

		private string fileName = "";

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

		private TrackBar contrast;

		private Label label2;

		private RadioButton hei_bai;

		private RadioButton li_san;

		private RadioButton grayscale;

		private TextBox textBox3;

		private TrackBar laserDepth;

		private Label label1;

		private TextBox textBox1;

		private TrackBar laserStrength;

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
				engraving_machine.处理事件();
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
				if (engraver.lian_jie())
				{
					timer2.Enabled = true;
					panel3.Visible = true;
					button1.Text = str3;
					panel2.Refresh();
					engraver.x = 0;
					engraver.y = 0;
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
					engraver.guan_kuang();
				}
				_ = kai_shi;
				timer2.Enabled = false;
				com.Close();
				engraver.lianjie = false;
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
				engraver.tu = tu_xiang.suofang(bb2, num2, num);
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
				engraver.tu = tu_xiang.suofang(bb2, num2, num);
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
				engraver.tu = tu_xiang.suofang(bb2, (int)((double)bb2.Width * num3), (int)((double)bb2.Height * num3));
			}
			if (hei_bai.Checked)
			{
				engraver.tu_pian = engraver.hei_bai(contrast.Value);
				if (fan_se)
				{
					engraver.tu_pian = tu_xiang.fanse(engraver.tu_pian);
				}
			}
			else if (li_san.Checked)
			{
				engraver.tu_pian = engraver.dou_dong(contrast.Value);
				if (fan_se)
				{
					engraver.tu_pian = tu_xiang.fanse(engraver.tu_pian);
				}
			}
			else
			{
				engraver.tu_pian = engraver.grayscale(contrast.Value);
				if (fan_se)
				{
					engraver.tu_pian = tu_xiang.fanse_huidu(engraver.tu_pian);
				}
			}
		}

		private void da_kai()
		{
			int num = 0;
			int num2 = 0;
			double num3 = 0.0;
			Bitmap bitmap = new Bitmap(fileName);
			tu = new Bitmap(bitmap);
			bitmap.Dispose();
			engraver.tu = tu;
			contrast.Value = 128;
			trackBar3.Value = trackBar3.Maximum / 2 + 10;
			if (hei_bai.Checked)
			{
				engraver.tu_pian = engraver.hei_bai(contrast.Value);
				if (fan_se)
				{
					engraver.tu_pian = tu_xiang.fanse(engraver.tu_pian);
				}
			}
			else if (li_san.Checked)
			{
				engraver.tu_pian = engraver.dou_dong(contrast.Value);
				if (fan_se)
				{
					engraver.tu_pian = tu_xiang.fanse(engraver.tu_pian);
				}
			}
			else
			{
				engraver.tu_pian = engraver.grayscale(contrast.Value);
			}
			bj2 = tu_xiang.qu_bian_jie2(engraver.tu_pian);
			bj[0] = bj2[0];
			bj[1] = bj2[1];
			bj[2] = bj2[2];
			bj[3] = bj2[3];
			bai_bian_k = (double)(bj[1] - bj[0]) / (double)engraver.tu_pian.Width;
			bai_bian_g = (double)(bj[3] - bj[2]) / (double)engraver.tu_pian.Height;
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
			engraver.tu = tu;
			contrast.Value = 128;
			trackBar3.Value = trackBar3.Maximum / 2 + 10;
			if (hei_bai.Checked)
			{
				engraver.tu_pian = engraver.hei_bai(contrast.Value);
				if (fan_se)
				{
					engraver.tu_pian = tu_xiang.fanse(engraver.tu_pian);
				}
			}
			else if (li_san.Checked)
			{
				engraver.tu_pian = engraver.dou_dong(contrast.Value);
				if (fan_se)
				{
					engraver.tu_pian = tu_xiang.fanse(engraver.tu_pian);
				}
			}
			else
			{
				engraver.tu_pian = engraver.grayscale(contrast.Value);
			}
			bj2 = tu_xiang.qu_bian_jie2(engraver.tu_pian);
			bj[0] = bj2[0];
			bj[1] = bj2[1];
			bj[2] = bj2[2];
			bj[3] = bj2[3];
			panel1.Location = new Point(25 + (int)(500.0 - (double)engraver.tu_pian.Width * 0.3125) / 2, 60 + (int)(500.0 - (double)engraver.tu_pian.Height * 0.3125) / 2);
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
					fileName = dakai.FileName;
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
			bj = tu_xiang.qu_bian_jie2(engraver.tu_pian);
			if (engraver.tu_pian != null)
			{
				if (checkBox2.Checked)
				{
					Bitmap bitmap = new Bitmap(engraver.tu_pian);
					Graphics graphics2 = Graphics.FromImage(bitmap);
					Pen pen = new Pen(Color.Red, 3f);
					graphics2.DrawRectangle(pen, bj[0] - 2, bj[2] - 2, bj[1] - bj[0] + 4, bj[3] - bj[2] + 4);
					graphics2.Dispose();
					tu_kuan_gao tu_kuan_gao = tu_xiang.shua_xin(panel1, bitmap, 0, 0, bitmap.Width, bitmap.Height, grayscale.Checked);
					engraver.tu_pian = tu_kuan_gao.bb;
					hua_kg = new int[2]
					{
						tu_kuan_gao.k,
						tu_kuan_gao.g
					};
				}
				else
				{
					Graphics graphics3 = Graphics.FromImage(new Bitmap(engraver.tu_pian));
					Pen pen2 = new Pen(Color.White, 3f);
					graphics3.DrawRectangle(pen2, bj[0] - 2, bj[2] - 2, bj[1] - bj[0] + 4, bj[3] - bj[2] + 4);
					graphics3.Dispose();
					tu_kuan_gao tu_kuan_gao2 = tu_xiang.shua_xin(panel1, engraver.tu_pian, 0, 0, engraver.tu_pian.Width, engraver.tu_pian.Height, grayscale.Checked);
					engraver.tu_pian = tu_kuan_gao2.bb;
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
			grayscale.Text = str14;
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
				grayscale.Location = new Point(129, 24);
				li_san.Location = new Point(6, 43);
			}
			else if (str1 == "縮小")
			{
				hei_bai.Location = new Point(6, 24);
				grayscale.Location = new Point(124, 24);
				li_san.Location = new Point(79, 24);
			}
			else
			{
				hei_bai.Location = new Point(6, 24);
				grayscale.Location = new Point(156, 24);
				li_san.Location = new Point(79, 24);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			engraver = new engraving_machine(com);
			panel1.Width = 20;
			panel1.Height = 20;
			engraver.lian_jie();
			com.Close();
			engraver.lianjie = false;
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

		private void contrast_MouseUp(object sender, MouseEventArgs e)
		{
			if (!kai_shi)
			{
				gai_bian = true;
				shu_xin();
				textBox3.Text = contrast.Value.ToString();
			}
		}

		private void huaxian(Point[] zhixian)
		{
			Graphics graphics = Graphics.FromImage(engraver.tu_pian);
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

		private void engraverkexian(Point[] zhixian)
		{
			Graphics graphics = Graphics.FromImage(engraver.tu_pian);
			Point point = default(Point);
			engraver.guan_ruo_guang();
			bool flag = hua2;
			if (flag)
			{
				point = new Point(zhixian[wei_zhi].X + dx, zhixian[wei_zhi].Y + dy);
				engraver.gai_bian_F(0);
				engraver.kai_deng();
				engraver.gai_bian_F(laserDepth.Value);
			}
			else
			{
				engraver.gai_bian_F(0);
			}
			for (int i = wei_zhi; i < zhixian.Length; i++)
			{
				if (zhixian[i].X == 600 || zhixian[i].X == 601)
				{
					if (zhixian[i].X == 600)
					{
						flag = true;
						engraver.kai_deng();
						engraver.gai_bian_F(laserDepth.Value);
					}
					if (zhixian[i].X == 601)
					{
						flag = false;
						engraver.guan_deng();
						engraver.gai_bian_F(0);
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
				Graphics graphics = Graphics.FromImage(engraver.tu_pian);
				graphics.Clear(Color.White);
				graphics.Dispose();
				zhuang_tai = 2;
				textBox1.Text = "10";
				laserDepth.Maximum = 35;
				laserDepth.Value = 12;
				textBox1.Text = "12";
				dx = 0;
				dy = 0;
				wenben = File.ReadAllText(da_kai_g.FileName);
				new Thread(jie).Start();
			}
		}

		public bool engraverke2()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			byte b = 0;
			if (li_san.Checked)
			{
				engraver.li_san_mo_shi();
			}
			else
			{
				engraver.fei_li_san_mo_shi();
			}
			engraver.fu_wei();
			engraver.kai_feng();
			fen = true;
			engraver.kai_shi((int)((double)(panel1.Location.X - 25) * 3.2), (int)((double)(panel1.Location.Y - 60) * 3.2));
			byte[] array = (engraver.tu_pian.Width % 8 <= 0) ? new byte[engraver.tu_pian.Width / 8 + 9] : new byte[engraver.tu_pian.Width / 8 + 10];
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
			hei_dian_shu = engraver.qu_hei_dian();
			timer3.Enabled = true;
			miao = 0;
			label12.Visible = true;
			com.DiscardInBuffer();
			for (num = wei_zhi; num < engraver.tu_pian.Height; num++)
			{
				num3 = 0;
				for (num2 = 0; num2 < array.Length - 9; num2++)
				{
					int num4 = 0;
					b = 0;
					for (num4 = 0; num4 < 8; num4++)
					{
						if (num2 * 8 + num4 < engraver.tu_pian.Width && engraver.tu_pian.GetPixel(num2 * 8 + num4, num).R == 0)
						{
							b = (byte)(b | array2[num4]);
							engraver.tu_pian.SetPixel(num2 * 8 + num4, num, Color.Red);
						}
					}
					array[num3 + 9] = b;
					num3++;
				}
				array[0] = 9;
				array[1] = (byte)(array.Length >> 8);
				array[2] = (byte)array.Length;
				array[3] = (byte)(laserDepth.Value >> 8);
				array[4] = (byte)laserDepth.Value;
				array[5] = (byte)(laserStrength.Value * 10 >> 8);
				array[6] = (byte)(laserStrength.Value * 10);
				array[7] = (byte)(num >> 8);
				array[8] = (byte)num;
				engraver.fanhui = false;
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
							engraving_machine.处理事件();
						}
						while (!flag2);
						com.Open();
						goto IL_028b;
					}
					int num5 = 0;
					while (!engraver.fanhui)
					{
						if (!com.IsOpen)
						{
							goto IL_028b;
						}
						num5++;
						if (ting_zhi)
						{
							engraver.ting_zhi();
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
								engraver.kai_feng2();
							}
							else
							{
								engraver.guan_feng2();
							}
							feng_shang = false;
						}
						else if (zan_ting)
						{
							if (zan_ting2)
							{
								engraver.zan_ting();
								timer3.Enabled = false;
							}
							else
							{
								engraver.ji_xu();
								timer3.Enabled = true;
							}
							zan_ting = false;
						}
						engraving_machine.处理事件();
						Thread.Sleep(10);
					}
					gai_bian = true;
					shu_xin();
					engraving_machine.处理事件();
					Thread.Sleep(10);
				}
				while (engraver.fanhui_shu == 8);
			}
			if (!ting_zhi)
			{
				wei_zhi = 0;
				kai_shi = false;
				timer3.Enabled = false;
				timer3.Enabled = false;
				label12.Visible = true;
				engraver.ting_zhi();
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
			engraver.ting_zhi();
			kai_shi = false;
			gai_bian = true;
			timer3.Enabled = false;
			label12.Visible = true;
			shu_xin();
			return true;
		}

		public bool engraverke3()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			byte b = 0;
			if (li_san.Checked)
			{
				engraver.li_san_mo_shi();
			}
			else
			{
				engraver.fei_li_san_mo_shi();
			}
			engraver.fu_wei();
			engraver.kai_feng();
			fen = true;
			engraver.kai_shi((int)((double)(panel1.Location.X - 25) * 3.2), (int)((double)(panel1.Location.Y - 60) * 3.2));
			byte[] array = (engraver.tu_pian.Width % 8 <= 0) ? new byte[engraver.tu_pian.Width / 8 + 9] : new byte[engraver.tu_pian.Width / 8 + 10];
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
			hei_dian_shu = engraver.qu_hei_dian();
			timer3.Enabled = true;
			miao = 0;
			label12.Visible = true;
			for (num = wei_zhi; num < engraver.tu_pian.Height; num++)
			{
				num3 = 0;
				for (num2 = 0; num2 < array.Length - 9; num2++)
				{
					int num4 = 0;
					b = 0;
					for (num4 = 0; num4 < 8; num4++)
					{
						if (num2 * 8 + num4 < engraver.tu_pian.Width && engraver.tu_pian.GetPixel(num2 * 8 + num4, num).R == 0)
						{
							b = (byte)(b | array2[num4]);
							engraver.tu_pian.SetPixel(num2 * 8 + num4, num, Color.Red);
						}
					}
					array[num3 + 9] = b;
					num3++;
				}
				array[0] = 9;
				array[1] = (byte)(array.Length >> 8);
				array[2] = (byte)array.Length;
				array[3] = (byte)(laserDepth.Value >> 8);
				array[4] = (byte)laserDepth.Value;
				array[5] = (byte)(laserStrength.Value * 10 >> 8);
				array[6] = (byte)(laserStrength.Value * 10);
				array[7] = (byte)(num >> 8);
				array[8] = (byte)num;
				engraver.fanhui = false;
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
							engraving_machine.处理事件();
						}
						while (!flag2);
						com.Open();
						goto IL_0280;
					}
					int num5 = 0;
					while (!engraver.fanhui)
					{
						if (!com.IsOpen)
						{
							goto IL_0280;
						}
						num5++;
						if (ting_zhi)
						{
							engraver.ting_zhi();
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
								engraver.kai_feng2();
							}
							else
							{
								engraver.guan_feng2();
							}
							feng_shang = false;
						}
						else if (zan_ting)
						{
							if (zan_ting2)
							{
								engraver.zan_ting();
								timer3.Enabled = false;
							}
							else
							{
								engraver.ji_xu();
								timer3.Enabled = true;
							}
							zan_ting = false;
						}
						engraving_machine.处理事件();
						Thread.Sleep(10);
					}
					gai_bian = true;
					shu_xin();
					engraving_machine.处理事件();
					Thread.Sleep(10);
				}
				while (engraver.fanhui_shu == 8);
			}
			if (!ting_zhi)
			{
				wei_zhi = 0;
				kai_shi = false;
				timer3.Enabled = false;
				timer3.Enabled = false;
				label12.Visible = true;
				engraver.ting_zhi();
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
			engraver.ting_zhi();
			kai_shi = false;
			gai_bian = true;
			timer3.Enabled = false;
			label12.Visible = true;
			shu_xin();
			return true;
		}

		public bool engraverke_hui()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			engraver.fei_li_san_mo_shi();
			engraver.fu_wei();
			engraver.kai_feng();
			fen = true;
			engraver.kai_shi((int)((double)(panel1.Location.X - 25) * 3.2), (int)((double)(panel1.Location.Y - 60) * 3.2));
			byte[] array = new byte[engraver.tu_pian.Width + 9];
			num3 = engraver.tu_pian.Width;
			num4 = engraver.tu_pian.Height;
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
					array[num2 + 9] = (byte)(255 - engraver.tu_pian.GetPixel(num2, num).R);
					engraver.tu_pian.SetPixel(num2, num, Color.FromArgb(engraver.tu_pian.GetPixel(num2, num).R, 0, 0));
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
				array[3] = (byte)(laserDepth.Value >> 8);
				array[4] = (byte)laserDepth.Value;
				array[5] = (byte)(laserStrength.Value * 10 >> 8);
				array[6] = (byte)(laserStrength.Value * 10);
				array[7] = (byte)(num >> 8);
				array[8] = (byte)num;
				engraver.fanhui = false;
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
				engraving_machine.处理事件();
				while (!engraver.fanhui)
				{
					if (ting_zhi)
					{
						engraver.ting_zhi();
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
							engraver.kai_feng2();
						}
						else
						{
							engraver.guan_feng2();
						}
						feng_shang = false;
					}
					else if (zan_ting)
					{
						if (zan_ting2)
						{
							timer3.Enabled = false;
							engraver.zan_ting();
						}
						else
						{
							timer3.Enabled = true;
							engraver.ji_xu();
						}
						zan_ting = false;
					}
					engraving_machine.处理事件();
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
				engraver.ting_zhi();
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
			engraver.ting_zhi();
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
			if (engraver.tu_pian != null)
			{
				if (checkBox2.Checked)
				{
					engraver.kai_kuang2(bj[1] - bj[0], bj[3] - bj[2], bj[0], bj[2]);
					gai_bian = true;
					shu_xin();
				}
				else
				{
					gai_bian = true;
					shu_xin();
					engraver.guan_kuang2();
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
			_ = engraver.kuan_gao;
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void laserDepth_MouseUp(object sender, MouseEventArgs e)
		{
			if (kai_shi)
			{
				engraver.gong_shen(laserStrength.Value * 10, laserDepth.Value);
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
						laserDepth.Value = Convert.ToInt32(textBox1.Text);
					}
					else
					{
						textBox1.Text = "1000";
						laserDepth.Value = 1000;
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
			contrast.Value = Convert.ToInt32(textBox3.Text);
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
			engraver.guan_ruo_guang();
			engraver.dian_deng(laserDepth.Value);
		}

		private void button16_Click(object sender, EventArgs e)
		{
			engraver.tuo_ji_da_yin();
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
					engraver.duoji2(jdt, zhixian);
				}
				else
				{
					engraver.duoji(jdt);
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
				bj = tu_xiang.qu_bian_jie2(engraver.tu_pian);
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			suofang += 5;
			Bitmap image = new Bitmap(tu_xiang.suofang(tu, engraver.kuan_gao + suofang, engraver.kuan_gao + suofang));
			Graphics.FromImage(engraver.tu).DrawImage(image, 0, 0);
			engraver.tu_pian = engraver.dou_dong(contrast.Value);
			shu_xin();
		}

		private void button19_Click(object sender, EventArgs e)
		{
			suofang -= 5;
			Bitmap image = new Bitmap(tu_xiang.suofang(tu, engraver.kuan_gao + suofang, engraver.kuan_gao + suofang));
			Graphics graphics = Graphics.FromImage(engraver.tu);
			graphics.Clear(Color.White);
			graphics.DrawImage(image, 0, 0);
			engraver.tu_pian = engraver.dou_dong(contrast.Value);
			shu_xin();
		}

		private void trackBar3_MouseUp(object sender, MouseEventArgs e)
		{
			gai_bian = true;
			quan_bu_shua_xin();
			if (checkBox2.Checked)
			{
				engraver.kai_kuang(engraver.tu_pian.Width, engraver.tu_pian.Height);
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
					engraver.ting_zhi_tj();
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
			if (zhuang_tai != 2 && engraver.tu_pian != null)
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
				engraver.tu = null;
				engraver.tu_pian = null;
				fileName = "";
				w_z = null;
				if (checkBox2.Checked)
				{
					engraver.guan_kuang();
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
			engraver.tuo_ji_da_yin();
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
				fileName = text;
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
			if (engraver.lianjie)
			{
				if (tj)
				{
					if (!com.IsOpen)
					{
						return;
					}
					if (com.BytesToRead == 1)
					{
						engraver.fanhui = true;
						engraver.fanhui_shu = com.ReadByte();
						if (engraver.fanhui_shu == 8)
						{
							engraver.fanhui_shu = 8;
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
					engraver.fanhui = true;
					if (com.BytesToRead == 1)
					{
						engraver.fanhui_shu = com.ReadByte();
					}
					if (engraver.fanhui_shu == 8)
					{
						engraver.fanhui_shu = 8;
					}
					com.DiscardInBuffer();
				}
			}
			else
			{
				engraver.fanhui = true;
				if (com.BytesToRead == 1)
				{
					engraver.fanhui_shu = com.ReadByte();
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
			engraver.kai_deng();
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
				engraver.guan_feng();
			}
			else
			{
				fen = true;
				engraver.kai_feng();
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
				contrast.Value = 128;
				textBox1.Text = "10";
				textBox3.Text = "128";
				if (!(fileName == ""))
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
				contrast.Value = 128;
				textBox1.Text = "10";
				textBox3.Text = "128";
				if (!textBox2.Visible && !(fileName == ""))
				{
					da_kai();
					gai_bian = true;
					panel1.Refresh();
				}
			}
		}

		private void grayscale_CheckedChanged(object sender, EventArgs e)
		{
			if (!kai_shi && !textBox2.Visible)
			{
				contrast.Value = 128;
				gai_bian = true;
				textBox1.Text = "10";
				textBox3.Text = "128";
				if (!(fileName == ""))
				{
					da_kai();
					gai_bian = true;
					panel1.Refresh();
				}
			}
		}

        // Laser strength
		private void laserStrength_Scroll(object sender, EventArgs e)
		{
			textBox5.Text = laserStrength.Value.ToString();
		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{
			laserStrength.Value = Convert.ToInt32(textBox5.Text);
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
			if (grayscale.Checked)
			{
				engraverke_hui();
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
				engraverke2();
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
			engraver.kai_shi_tuo_ji((byte)((double)((panel1.Location.X + bj[0]) * 1600) / 500.0), (byte)((double)((panel1.Location.Y + bj[1]) * 1600) / 500.0), engraver.tu_pian.Width, engraver.tu_pian.Height, laserStrength.Value * 10, laserDepth.Value);
			while (!fs_wc)
			{
				engraving_machine.处理事件();
			}
			timer_flash.Enabled = false;
			byte[] array = (engraver.tu_pian.Width % 8 <= 0) ? new byte[engraver.tu_pian.Width / 8 + 4] : new byte[engraver.tu_pian.Width / 8 + 5];
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
			for (num = 0; num < engraver.tu_pian.Height; num++)
			{
				num3 = 0;
				for (num2 = 0; num2 < array.Length - 4; num2++)
				{
					int num4 = 0;
					b = 0;
					for (num4 = 0; num4 < 8; num4++)
					{
						if (num2 * 8 + num4 < engraver.tu_pian.Width && engraver.tu_pian.GetPixel(num2 * 8 + num4, num).R == 0)
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
							engraver.fanhui = false;
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
							engraving_machine.处理事件();
						}
						while (!flag);
						com.Open();
						goto IL_01e5;
					}
					while (!engraver.fanhui)
					{
						if (!com.IsOpen)
						{
							goto IL_01e5;
						}
						engraving_machine.处理事件();
						Thread.Sleep(10);
					}
				}
				while (engraver.fanhui_shu == 8);
				progressBar1.Value = (int)((double)num / (double)engraver.tu_pian.Height * 100.0);
				label14.Text = progressBar1.Value + "%";
				engraving_machine.处理事件();
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
			engraver.dao_yuandian();
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
						engraver.zan_ting();
						timer3.Enabled = false;
						button29.Text = str9;
					}
					else
					{
						engraver.ji_xu();
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
			if (engraver.tu_pian == null)
			{
				panel1.Location = new Point(275, 310);
			}
			else
			{
				panel1.Location = new Point(25 + (int)(500.0 - (double)engraver.tu_pian.Width * 0.3125) / 2, 60 + (int)(500.0 - (double)engraver.tu_pian.Height * 0.3125) / 2);
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
			if (engraver.lianjie)
			{
				engraver.yidong((int)((double)(panel1.Location.X - 25 - x) * 3.2), (int)((double)(panel1.Location.Y - 60 - y) * 3.2), new PictureBox(), pp: false);
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
			if (engraver.lianjie)
			{
				try
				{
					if (!com.IsOpen && !kai_shi)
					{
						com.Close();
						engraver.lianjie = false;
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
				bj = tu_xiang.qu_bian_jie2(engraver.tu_pian);
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
				bj = tu_xiang.qu_bian_jie2(engraver.tu_pian);
				hua_biao_shi();
			}
		}

		private void contrast_Scroll(object sender, EventArgs e)
		{
			textBox3.Text = contrast.Value.ToString();
		}

		private void laserDepth_Scroll(object sender, EventArgs e)
		{
			textBox1.Text = laserDepth.Value.ToString();
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
			engraver.fasong_lianjie2();
			engraver.tuoji_engraverke();
			kai_shi = true;
		}

		private void laserStrength_MouseUp(object sender, MouseEventArgs e)
		{
			if (kai_shi)
			{
				engraver.gong_shen(laserStrength.Value * 10, laserDepth.Value);
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
					engraver.yidong2(-(bj[0] + (bj[1] - bj[0]) / 2), -(bj[2] + (bj[3] - bj[2]) / 2), new PictureBox(), pp: false);
					zhong_xin = false;
				}
				else
				{
					engraver.yidong2(bj[0] + (bj[1] - bj[0]) / 2, bj[2] + (bj[3] - bj[2]) / 2, new PictureBox(), pp: false);
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
				bj = tu_xiang.qu_bian_jie2(engraver.tu_pian);
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
				bj = tu_xiang.qu_bian_jie2(engraver.tu_pian);
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
			if (engraver.tu_pian != null)
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
					engraver.tu_pian.Save(str + text + ".bmp", ImageFormat.Bmp);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.com = new System.IO.Ports.SerialPort(this.components);
            this.dakai = new System.Windows.Forms.OpenFileDialog();
            this.da_kai_g = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button17 = new System.Windows.Forms.Button();
            this.jdt = new System.Windows.Forms.ProgressBar();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button27 = new System.Windows.Forms.Button();
            this.contrast = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.hei_bai = new System.Windows.Forms.RadioButton();
            this.li_san = new System.Windows.Forms.RadioButton();
            this.grayscale = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.laserDepth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.laserStrength = new System.Windows.Forms.TrackBar();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button30 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button29 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button32 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button36 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer_flash = new System.Windows.Forms.Timer(this.components);
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserStrength)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel1.Location = new System.Drawing.Point(25, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 191);
            this.panel1.TabIndex = 1;
            this.panel1.TabStop = true;
            this.panel1.LocationChanged += new System.EventHandler(this.panel1_LocationChanged);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.button10.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button10.Location = new System.Drawing.Point(438, 203);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(17, 18);
            this.button10.TabIndex = 2;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Visible = false;
            this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button10_MouseDown);
            this.button10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button10_MouseMove);
            this.button10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.button9.Location = new System.Drawing.Point(453, 220);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(17, 18);
            this.button9.TabIndex = 1;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Visible = false;
            this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button9_MouseDown);
            this.button9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button9_MouseMove);
            this.button9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button9_MouseUp);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.textBox2.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(278, 66);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(177, 155);
            this.textBox2.TabIndex = 0;
            this.textBox2.Visible = false;
            this.textBox2.LocationChanged += new System.EventHandler(this.textBox2_LocationChanged);
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseDown);
            this.textBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseMove);
            this.textBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseUp);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(1001, 228);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(35, 38);
            this.button18.TabIndex = 30;
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Visible = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(984, 229);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(35, 38);
            this.button19.TabIndex = 31;
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Visible = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(532, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Attach Device";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(949, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "250*250";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(532, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Import Pictures";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(825, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 33);
            this.button3.TabIndex = 4;
            this.button3.Text = "模拟发送错误";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(917, 79);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 33);
            this.button6.TabIndex = 6;
            this.button6.Text = "打开G代码";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.Location = new System.Drawing.Point(994, 114);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(107, 33);
            this.button7.TabIndex = 11;
            this.button7.Text = "快进>>";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.Location = new System.Drawing.Point(917, 118);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(107, 33);
            this.button8.TabIndex = 10;
            this.button8.Text = "<<快退";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(532, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 39);
            this.button4.TabIndex = 12;
            this.button4.Text = "Start";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button4_MouseDown);
            this.button4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button4_MouseUp);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(655, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 36);
            this.button5.TabIndex = 13;
            this.button5.Text = "Add Text";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // com
            // 
            this.com.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.com_ErrorReceived);
            this.com.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.com_DataReceived);
            // 
            // dakai
            // 
            this.dakai.FileName = "openFileDialog1";
            this.dakai.Filter = "ビットマップファイル|*.bmp;*.jpg;*.jpge;*.png;";
            // 
            // da_kai_g
            // 
            this.da_kai_g.FileName = "openFileDialog1";
            this.da_kai_g.Filter = "刀路文件|*.NC|所有文件|*.*";
            // 
            // fontDialog1
            // 
            this.fontDialog1.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(692, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 35);
            this.panel2.TabIndex = 23;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(32, 35);
            this.panel3.TabIndex = 44;
            this.panel3.Visible = false;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Transparent;
            this.button17.Location = new System.Drawing.Point(962, 419);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(215, 41);
            this.button17.TabIndex = 28;
            this.button17.Text = "发送脱机数据";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // jdt
            // 
            this.jdt.Location = new System.Drawing.Point(963, 463);
            this.jdt.Name = "jdt";
            this.jdt.Size = new System.Drawing.Size(213, 11);
            this.jdt.TabIndex = 29;
            this.jdt.Visible = false;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.Transparent;
            this.button20.Image = ((System.Drawing.Image)(resources.GetObject("button20.Image")));
            this.button20.Location = new System.Drawing.Point(178, 10);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(35, 38);
            this.button20.TabIndex = 32;
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Transparent;
            this.button21.Image = ((System.Drawing.Image)(resources.GetObject("button21.Image")));
            this.button21.Location = new System.Drawing.Point(25, 10);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(35, 38);
            this.button21.TabIndex = 33;
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.Transparent;
            this.button22.Image = ((System.Drawing.Image)(resources.GetObject("button22.Image")));
            this.button22.Location = new System.Drawing.Point(76, 10);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(35, 38);
            this.button22.TabIndex = 34;
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.Transparent;
            this.button23.Image = ((System.Drawing.Image)(resources.GetObject("button23.Image")));
            this.button23.Location = new System.Drawing.Point(928, 31);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(35, 38);
            this.button23.TabIndex = 35;
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.Transparent;
            this.button24.Location = new System.Drawing.Point(690, 99);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(71, 39);
            this.button24.TabIndex = 37;
            this.button24.Text = "Stop";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.Transparent;
            this.button25.Image = ((System.Drawing.Image)(resources.GetObject("button25.Image")));
            this.button25.Location = new System.Drawing.Point(127, 10);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(35, 38);
            this.button25.TabIndex = 31;
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Transparent;
            this.button15.Image = ((System.Drawing.Image)(resources.GetObject("button15.Image")));
            this.button15.Location = new System.Drawing.Point(280, 10);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(35, 38);
            this.button15.TabIndex = 31;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("SimSun", 13F);
            this.label3.Location = new System.Drawing.Point(875, 579);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "缩放";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(1013, 551);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 33);
            this.label5.TabIndex = 41;
            this.label5.Text = "Y：";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(952, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 33);
            this.label4.TabIndex = 42;
            this.label4.Text = "X：";
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Transparent;
            this.button16.ForeColor = System.Drawing.Color.Red;
            this.button16.Location = new System.Drawing.Point(928, 157);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(53, 33);
            this.button16.TabIndex = 43;
            this.button16.Text = "开始";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Visible = false;
            this.button16.Click += new System.EventHandler(this.button16_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(954, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "激光功率：";
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.Transparent;
            this.button27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button27.Image = ((System.Drawing.Image)(resources.GetObject("button27.Image")));
            this.button27.Location = new System.Drawing.Point(229, 10);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(35, 38);
            this.button27.TabIndex = 52;
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // contrast
            // 
            this.contrast.Location = new System.Drawing.Point(3, 22);
            this.contrast.Maximum = 253;
            this.contrast.Name = "contrast";
            this.contrast.Size = new System.Drawing.Size(194, 45);
            this.contrast.TabIndex = 16;
            this.contrast.Value = 128;
            this.contrast.Scroll += new System.EventHandler(this.contrast_Scroll);
            this.contrast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.contrast_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(869, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "絵図調整：";
            this.label2.Visible = false;
            // 
            // hei_bai
            // 
            this.hei_bai.AutoSize = true;
            this.hei_bai.Checked = true;
            this.hei_bai.Location = new System.Drawing.Point(6, 26);
            this.hei_bai.Name = "hei_bai";
            this.hei_bai.Size = new System.Drawing.Size(101, 17);
            this.hei_bai.TabIndex = 49;
            this.hei_bai.TabStop = true;
            this.hei_bai.Text = "Black and white";
            this.hei_bai.UseVisualStyleBackColor = true;
            this.hei_bai.CheckedChanged += new System.EventHandler(this.hei_bai_CheckedChanged);
            // 
            // li_san
            // 
            this.li_san.AutoSize = true;
            this.li_san.Location = new System.Drawing.Point(6, 47);
            this.li_san.Name = "li_san";
            this.li_san.Size = new System.Drawing.Size(49, 17);
            this.li_san.TabIndex = 50;
            this.li_san.Text = "离散";
            this.li_san.UseVisualStyleBackColor = true;
            this.li_san.CheckedChanged += new System.EventHandler(this.li_san_CheckedChanged);
            this.li_san.MouseDown += new System.Windows.Forms.MouseEventHandler(this.li_san_MouseDown);
            // 
            // grayscale
            // 
            this.grayscale.AutoSize = true;
            this.grayscale.Location = new System.Drawing.Point(129, 26);
            this.grayscale.Name = "grayscale";
            this.grayscale.Size = new System.Drawing.Size(72, 17);
            this.grayscale.TabIndex = 51;
            this.grayscale.Text = "Grayscale";
            this.grayscale.UseVisualStyleBackColor = true;
            this.grayscale.Visible = true;
            this.grayscale.CheckedChanged += new System.EventHandler(this.grayscale_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(195, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(33, 13);
            this.textBox3.TabIndex = 18;
            this.textBox3.Text = "128";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // laserDepth
            // 
            this.laserDepth.Location = new System.Drawing.Point(3, 22);
            this.laserDepth.Maximum = 255;
            this.laserDepth.Minimum = 1;
            this.laserDepth.Name = "laserDepth";
            this.laserDepth.Size = new System.Drawing.Size(191, 45);
            this.laserDepth.TabIndex = 8;
            this.laserDepth.Value = 10;
            this.laserDepth.Scroll += new System.EventHandler(this.laserDepth_Scroll);
            this.laserDepth.MouseUp += new System.Windows.Forms.MouseEventHandler(this.laserDepth_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(869, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "彫刻の深さ調整：";
            this.label1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(195, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(33, 13);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "10";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // laserStrength
            // 
            this.laserStrength.Location = new System.Drawing.Point(2, 16);
            this.laserStrength.Maximum = 100;
            this.laserStrength.Name = "laserStrength";
            this.laserStrength.Size = new System.Drawing.Size(195, 45);
            this.laserStrength.TabIndex = 46;
            this.laserStrength.Value = 100;
            this.laserStrength.Scroll += new System.EventHandler(this.laserStrength_Scroll);
            this.laserStrength.MouseUp += new System.Windows.Forms.MouseEventHandler(this.laserStrength_MouseUp);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(191, 16);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(35, 13);
            this.textBox5.TabIndex = 48;
            this.textBox5.Text = "100";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(866, 438);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(62, 17);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "框定位";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button11.Location = new System.Drawing.Point(82, 67);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(67, 38);
            this.button11.TabIndex = 19;
            this.button11.Text = "↑";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.Location = new System.Drawing.Point(82, 153);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(67, 38);
            this.button12.TabIndex = 20;
            this.button12.Text = "↓";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Transparent;
            this.button13.Location = new System.Drawing.Point(9, 109);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(67, 38);
            this.button13.TabIndex = 21;
            this.button13.Text = "←";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Transparent;
            this.button14.Location = new System.Drawing.Point(155, 109);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(67, 38);
            this.button14.TabIndex = 22;
            this.button14.Text = "→";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grayscale);
            this.groupBox1.Controls.Add(this.li_san);
            this.groupBox1.Controls.Add(this.hei_bai);
            this.groupBox1.Location = new System.Drawing.Point(532, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 70);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Engraving mode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.laserDepth);
            this.groupBox2.Location = new System.Drawing.Point(532, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 54);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "レーザー彫刻パラメータ調整";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox8);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.button30);
            this.groupBox3.Controls.Add(this.button28);
            this.groupBox3.Controls.Add(this.button26);
            this.groupBox3.Controls.Add(this.button14);
            this.groupBox3.Controls.Add(this.button13);
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Location = new System.Drawing.Point(534, 387);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 221);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "レーザー位置調整";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(156, 193);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(46, 20);
            this.textBox8.TabIndex = 30;
            this.textBox8.Text = "10";
            this.textBox8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox8_KeyPress);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(41, 193);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(46, 20);
            this.textBox7.TabIndex = 29;
            this.textBox7.Text = "10";
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(206, 198);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 13);
            this.label21.TabIndex = 38;
            this.label21.Text = "MM";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(91, 198);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(25, 13);
            this.label20.TabIndex = 37;
            this.label20.Text = "MM";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(119, 196);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 36;
            this.label19.Text = "高度：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 196);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "宽度：";
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.Transparent;
            this.button30.Location = new System.Drawing.Point(82, 109);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(67, 37);
            this.button30.TabIndex = 28;
            this.button30.Text = "中心に戻る";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.Color.Transparent;
            this.button28.Location = new System.Drawing.Point(37, 22);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(75, 39);
            this.button28.TabIndex = 26;
            this.button28.Text = "彫刻範囲プレビュー";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.Transparent;
            this.button26.Location = new System.Drawing.Point(117, 22);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(75, 39);
            this.button26.TabIndex = 25;
            this.button26.Text = "原点に戻る";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.button26_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label13.Font = new System.Drawing.Font("SimSun", 13F);
            this.label13.Location = new System.Drawing.Point(1034, 583);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 18);
            this.label13.TabIndex = 37;
            this.label13.Text = "缩放";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // textBox4
            // 
            this.textBox4.CausesValidation = false;
            this.textBox4.Location = new System.Drawing.Point(866, 345);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(53, 20);
            this.textBox4.TabIndex = 24;
            this.textBox4.Text = "20";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(851, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "步进值：";
            this.label7.Visible = false;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.Transparent;
            this.button29.ForeColor = System.Drawing.Color.Blue;
            this.button29.Location = new System.Drawing.Point(611, 99);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(71, 39);
            this.button29.TabIndex = 56;
            this.button29.Text = "Pause";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            this.button29.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button29_MouseDown);
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(871, 301);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(55, 21);
            this.button31.TabIndex = 57;
            this.button31.Text = "button31";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Visible = false;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(25, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(500, 1);
            this.label8.TabIndex = 58;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(25, 607);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(500, 1);
            this.label9.TabIndex = 59;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(25, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1, 542);
            this.label10.TabIndex = 60;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(525, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1, 542);
            this.label11.TabIndex = 61;
            this.label11.Text = "label11";
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Transparent;
            this.button32.Font = new System.Drawing.Font("SimSun", 20F);
            this.button32.Image = ((System.Drawing.Image)(resources.GetObject("button32.Image")));
            this.button32.Location = new System.Drawing.Point(331, 10);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(35, 38);
            this.button32.TabIndex = 62;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(32, 588);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 63;
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.laserStrength);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Location = new System.Drawing.Point(532, 272);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(231, 54);
            this.groupBox4.TabIndex = 64;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "レーザー彫刻パラメータ調整";
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.Color.Transparent;
            this.button36.Font = new System.Drawing.Font("SimSun", 20F);
            this.button36.Image = ((System.Drawing.Image)(resources.GetObject("button36.Image")));
            this.button36.Location = new System.Drawing.Point(484, 10);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(35, 38);
            this.button36.TabIndex = 76;
            this.button36.UseVisualStyleBackColor = false;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button35
            // 
            this.button35.BackColor = System.Drawing.Color.Transparent;
            this.button35.Font = new System.Drawing.Font("SimSun", 20F);
            this.button35.Image = ((System.Drawing.Image)(resources.GetObject("button35.Image")));
            this.button35.Location = new System.Drawing.Point(382, 10);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(35, 38);
            this.button35.TabIndex = 75;
            this.button35.UseVisualStyleBackColor = false;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.radioButton4);
            this.panel6.Controls.Add(this.radioButton3);
            this.panel6.Controls.Add(this.radioButton2);
            this.panel6.Controls.Add(this.radioButton5);
            this.panel6.Controls.Add(this.listBox1);
            this.panel6.Controls.Add(this.trackBar5);
            this.panel6.Location = new System.Drawing.Point(127, 294);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(303, 314);
            this.panel6.TabIndex = 77;
            this.panel6.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "16";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(303, 26);
            this.label16.TabIndex = 12;
            this.label16.Text = "字体选择";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label16_MouseDown);
            this.label16.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label16_MouseMove);
            this.label16.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label16_MouseUp);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(198, 274);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(73, 17);
            this.radioButton4.TabIndex = 11;
            this.radioButton4.Text = "粗体斜体";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(198, 208);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(49, 17);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.Text = "斜体";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(198, 142);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(49, 17);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.Text = "粗体";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Checked = true;
            this.radioButton5.Location = new System.Drawing.Point(198, 76);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(49, 17);
            this.radioButton5.TabIndex = 8;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "常规";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(20, 74);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(172, 225);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(38, 31);
            this.trackBar5.Maximum = 100;
            this.trackBar5.Minimum = 1;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(244, 45);
            this.trackBar5.TabIndex = 6;
            this.trackBar5.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar5.Value = 16;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.contrast);
            this.groupBox5.Location = new System.Drawing.Point(532, 207);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(231, 62);
            this.groupBox5.TabIndex = 78;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(29, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(76, 18);
            this.panel4.TabIndex = 79;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(8, 220);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(17, 83);
            this.panel5.TabIndex = 80;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.Color.Transparent;
            this.button33.Font = new System.Drawing.Font("SimSun", 20F);
            this.button33.Image = ((System.Drawing.Image)(resources.GetObject("button33.Image")));
            this.button33.Location = new System.Drawing.Point(433, 10);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(35, 38);
            this.button33.TabIndex = 81;
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.Transparent;
            this.button34.ForeColor = System.Drawing.Color.Red;
            this.button34.Location = new System.Drawing.Point(825, 47);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(94, 33);
            this.button34.TabIndex = 82;
            this.button34.Text = "模拟接收错误";
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.Transparent;
            this.button37.Font = new System.Drawing.Font("SimSun", 20F);
            this.button37.Image = ((System.Drawing.Image)(resources.GetObject("button37.Image")));
            this.button37.Location = new System.Drawing.Point(647, 10);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(35, 38);
            this.button37.TabIndex = 83;
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Visible = false;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label14);
            this.panel7.Controls.Add(this.progressBar1);
            this.panel7.Location = new System.Drawing.Point(25, 611);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(501, 21);
            this.panel7.TabIndex = 84;
            this.panel7.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(474, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "1%";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(473, 21);
            this.progressBar1.TabIndex = 0;
            // 
            // timer_flash
            // 
            this.timer_flash.Interval = 1000;
            this.timer_flash.Tick += new System.EventHandler(this.timer_flash_Tick);
            // 
            // trackBar3
            // 
            this.trackBar3.AutoSize = false;
            this.trackBar3.Location = new System.Drawing.Point(924, 570);
            this.trackBar3.Maximum = 3200;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(136, 34);
            this.trackBar3.TabIndex = 36;
            this.trackBar3.Value = 1650;
            this.trackBar3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar3_MouseUp);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(769, 633);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button33);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.button35);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button31);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.jdt);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "激光雕刻机";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserStrength)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
