using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MiniEngraver
{
	internal class engraving_machine
	{
		public SerialPort com;

		public int kuan_gao = 800;

		public int x;

		public int y;

		public Bitmap tu;

		public Bitmap tu_pian;

		public bool lianjie;

		public bool fanhui;

		public int fanhui_shu;

		private bool jinru;

		public engraving_machine(SerialPort p)
		{
			tu_pian = new Bitmap(10, 10);
			Graphics.FromImage(tu_pian).Clear(Color.White);
			tu = tu_pian;
			com = p;
		}

		private void jieshou()
		{
			while (true)
			{
				if (com.IsOpen)
				{
					try
					{
						if (0 < com.BytesToRead && com.ReadByte() == 9)
						{
							fanhui = true;
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}
				}
				Thread.Sleep(1);
			}
		}

		public bool fasong_lianjie()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			int num = 2;
			do
			{
				try
				{
					com.Write(new byte[4]
					{
						10,
						0,
						4,
						0
					}, 0, 4);
				}
				catch (Exception)
				{
					com.Close();
					com.Open();
				}
				int num2 = 200;
				lianjie = false;
				fanhui = false;
				fanhui_shu = 0;
				while (0 < num2--)
				{
					Thread.Sleep(10);
					处理事件();
					if (fanhui && fanhui_shu == 9)
					{
						lianjie = true;
						return true;
					}
				}
			}
			while (--num > 0);
			com.Close();
			return false;
		}

		public bool fasong_lianjie2()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			int num = 2;
			do
			{
				try
				{
					com.Write(new byte[4]
					{
						10,
						0,
						4,
						0
					}, 0, 4);
				}
				catch (Exception)
				{
					com.Close();
					com.Open();
				}
				int num2 = 10;
				fanhui = false;
				while (0 < num2--)
				{
					Thread.Sleep(10);
					处理事件();
					if (fanhui)
					{
						lianjie = true;
						return true;
					}
				}
			}
			while (--num > 0);
			com.Close();
			return false;
		}

		public bool tuoji_engraverke()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			int num = 2;
			do
			{
				try
				{
					com.Write(new byte[4]
					{
						36,
						0,
						4,
						0
					}, 0, 4);
				}
				catch (Exception)
				{
					com.Close();
					com.Open();
				}
				int num2 = 10;
				fanhui = false;
				while (0 < num2--)
				{
					Thread.Sleep(10);
					处理事件();
					if (fanhui)
					{
						return true;
					}
				}
			}
			while (--num > 0);
			return false;
		}

		public bool li_san_mo_shi()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					27,
					0,
					4,
					0
				}, 0, 4);
			}
			catch (Exception)
			{
			}
			int num = 10;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool tuo_ji_engraverke()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					36,
					0,
					4,
					0
				}, 0, 4);
			}
			catch (Exception)
			{
			}
			int num = 10;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool kai_shi_tuo_ji(int zuo, int ding, int kuan, int gao, int gong_lv, int shen_du)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[15]
				{
					35,
					0,
					15,
					(byte)(zuo >> 8),
					(byte)zuo,
					(byte)(ding >> 8),
					(byte)ding,
					(byte)(kuan >> 8),
					(byte)kuan,
					(byte)(gao >> 8),
					(byte)gao,
					(byte)(gong_lv >> 8),
					(byte)gong_lv,
					(byte)(shen_du >> 8),
					(byte)shen_du
				}, 0, 15);
			}
			catch (Exception)
			{
			}
			return false;
		}

		public bool gong_shen(int gong_lv, int shen_du)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[7]
				{
					37,
					0,
					7,
					(byte)(gong_lv >> 8),
					(byte)gong_lv,
					(byte)(shen_du >> 8),
					(byte)shen_du
				}, 0, 7);
			}
			catch (Exception)
			{
			}
			int num = 1000;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool fei_li_san_mo_shi()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					28,
					0,
					4,
					0
				}, 0, 4);
			}
			catch (Exception)
			{
			}
			int num = 10;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public static void 处理事件()
		{
			Application.DoEvents();
		}

		public bool lian_jie()
		{
			if (lianjie)
			{
				return true;
			}
			string[] portNames = SerialPort.GetPortNames();
			foreach (string portName in portNames)
			{
				try
				{
					com.PortName = portName;
					com.BaudRate = 115200;
					com.Open();
				}
				catch (Exception)
				{
				}
				if (fasong_lianjie())
				{
					lianjie = true;
					return true;
				}
			}
			return false;
		}

		public Bitmap grayscale(int zhi)
		{
			Bitmap bitmap = new Bitmap(tu);
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
				if (num2 < 253)
				{
					num2 -= zhi - 128;
				}
				if (num2 > 253)
				{
					num2 = 253;
				}
				if (num2 < 1)
				{
					num2 = 1;
				}
				if (array[i + 3] == 0)
				{
					num2 = 255;
				}
				array2[i] = (byte)num2;
				array2[i + 1] = (byte)num2;
				array2[i + 2] = (byte)num2;
				array2[i + 3] = byte.MaxValue;
			}
			Marshal.Copy(array2, 0, scan, num);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}

		public Bitmap hei_bai(int zhi)
		{
			if (tu == null)
			{
				return null;
			}
			Bitmap bitmap = new Bitmap(tu);
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
				num2 = ((num2 > zhi) ? 255 : 0);
				if (array[i + 3] == 0)
				{
					num2 = 255;
				}
				array2[i] = (byte)num2;
				array2[i + 1] = (byte)num2;
				array2[i + 2] = (byte)num2;
				array2[i + 3] = byte.MaxValue;
			}
			Marshal.Copy(array2, 0, scan, num);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}

		public int qu_hei_dian()
		{
			int num = 0;
			Bitmap bitmap = new Bitmap(tu);
			Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			int num2 = Math.Abs(bitmapData.Stride) * bitmap.Height;
			byte[] array = new byte[num2];
			byte[] source = new byte[num2];
			Marshal.Copy(scan, array, 0, num2);
			for (int i = 0; i < array.Length; i += 4)
			{
				_ = array[i];
				if (array[i] == 0)
				{
					num++;
				}
			}
			Marshal.Copy(source, 0, scan, num2);
			bitmap.UnlockBits(bitmapData);
			return num;
		}

		public Bitmap dou_dong2(int zhi)
		{
			Bitmap bitmap = new Bitmap(tu);
			Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			int num = Math.Abs(bitmapData.Stride) * bitmap.Height;
			byte[] array = new byte[num];
			byte[] array2 = new byte[num];
			Marshal.Copy(scan, array, 0, num);
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < array.Length; i += 4)
			{
				num2 = array[i];
				if (num2 > 128 + (zhi - 128))
				{
					if (num2 > 255)
					{
						num2 = 255;
					}
					num3 = num2 - 255;
					num2 = 255;
				}
				else
				{
					if (num2 < 0)
					{
						num2 = 0;
					}
					num3 = num2;
					num2 = 0;
				}
				int num4 = 375 * num3 / 1000;
				int num5 = 25 * num3 / 100;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				if (i + 4 < array.Length)
				{
					num6 = array[i + 4] + num4;
					if (num6 > 255)
					{
						num6 = 255;
					}
					if (num6 < 0)
					{
						num6 = 0;
					}
					array[i + 4] = (byte)num6;
				}
				if (i + bitmap.Width * 4 < array.Length)
				{
					num7 = array[i + bitmap.Width * 4] + num4;
					if (num7 > 255)
					{
						num7 = 255;
					}
					if (num7 < 0)
					{
						num7 = 0;
					}
					array[i + bitmap.Width * 4] = (byte)num7;
				}
				if (i + bitmap.Width * 4 + 1 < array.Length)
				{
					num8 = array[i + bitmap.Width * 4 + 1] + num5;
					if (num8 > 255)
					{
						num8 = 255;
					}
					if (num8 < 0)
					{
						num8 = 0;
					}
					array[i + bitmap.Width * 4 + 1] = (byte)num8;
				}
				array2[i] = (byte)num2;
				array2[i + 1] = (byte)num2;
				array2[i + 2] = (byte)num2;
				array2[i + 3] = byte.MaxValue;
			}
			Marshal.Copy(array2, 0, scan, num);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}

		public Bitmap dou_dong(int zhi)
		{
			Bitmap bitmap = new Bitmap(tu);
			Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			int num = Math.Abs(bitmapData.Stride) * bitmap.Height;
			byte[] array = new byte[num];
			byte[] array2 = new byte[num];
			Marshal.Copy(scan, array, 0, num);
			int num2 = 0;
			int num3 = 0;
			int num4 = array.Length;
			int width = bitmap.Width;
			for (int i = 0; i < num4; i += 4)
			{
				num2 = array[i];
				if (num2 > zhi)
				{
					if (num2 > 255)
					{
						num2 = 255;
					}
					num3 = num2 - 255;
					num2 = 255;
				}
				else
				{
					if (num2 < 0)
					{
						num2 = 0;
					}
					num3 = num2;
					num2 = 0;
				}
				int num5 = 375 * num3 / 1000;
				int num6 = 25 * num3 / 100;
				int num7 = 0;
				int num8 = 0;
				int num9 = 0;
				int num10 = width * 4;
				int num11 = i + 4;
				int num12 = i + num10;
				if (num11 < num4)
				{
					num7 = array[num11] + num5;
					if (num7 > 255)
					{
						num7 = 255;
					}
					if (num7 < 0)
					{
						num7 = 0;
					}
					array[num11] = (byte)num7;
				}
				if (num12 < num4)
				{
					num8 = array[i + num10] + num5;
					if (num8 > 255)
					{
						num8 = 255;
					}
					if (num8 < 0)
					{
						num8 = 0;
					}
					array[num12] = (byte)num8;
				}
				if (num12 + 1 < num4)
				{
					num9 = array[num12 + 1] + num6;
					if (num9 > 255)
					{
						num9 = 255;
					}
					if (num9 < 0)
					{
						num9 = 0;
					}
					array[num12 + 1] = (byte)num9;
				}
				if (array[i + 3] == 0)
				{
					num2 = 255;
				}
				array2[i] = (byte)num2;
				array2[i + 1] = (byte)num2;
				array2[i + 2] = (byte)num2;
				array2[i + 3] = byte.MaxValue;
			}
			Marshal.Copy(array2, 0, scan, num);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}

		public bool yidong(int xx, int yy, PictureBox p, bool pp)
		{
			if (!jinru)
			{
				jinru = true;
				if (!com.IsOpen)
				{
					jinru = false;
					return false;
				}
				try
				{
					com.Write(new byte[7]
					{
						1,
						0,
						7,
						(byte)(xx >> 8),
						(byte)xx,
						(byte)(yy >> 8),
						(byte)yy
					}, 0, 7);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					jinru = false;
					return false;
				}
				int num = 10;
				fanhui = false;
				while (0 < num--)
				{
					Thread.Sleep(10);
					处理事件();
					if (fanhui)
					{
						x = xx;
						y = yy;
						if (pp)
						{
							p.Location = new Point(x - 3, y - 3);
						}
						jinru = false;
						return true;
					}
				}
			}
			jinru = false;
			return false;
		}

		public bool yidong3(int xx, int yy, PictureBox p, bool pp)
		{
			if (!jinru)
			{
				jinru = true;
				if (!com.IsOpen)
				{
					jinru = false;
					return false;
				}
				try
				{
					com.Write(new byte[7]
					{
						1,
						0,
						7,
						(byte)(xx >> 8),
						(byte)xx,
						(byte)(yy >> 8),
						(byte)yy
					}, 0, 7);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					jinru = false;
					return false;
				}
				int num = 120;
				fanhui = false;
				while (0 < num--)
				{
					Thread.Sleep(10);
					处理事件();
					if (fanhui)
					{
						x = xx;
						y = yy;
						if (pp)
						{
							p.Location = new Point(x - 3, y - 3);
						}
						jinru = false;
						return true;
					}
				}
			}
			jinru = false;
			return false;
		}

		public bool guan_kuang2()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					33,
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
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool kai_kuang2(int k, int g, int t_x, int t_y)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[11]
				{
					32,
					0,
					11,
					(byte)(k >> 8),
					(byte)k,
					(byte)(g >> 8),
					(byte)g,
					(byte)(t_x >> 8),
					(byte)t_x,
					(byte)(t_y >> 8),
					(byte)t_y
				}, 0, 11);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool yidong2(int xx, int yy, PictureBox p, bool pp)
		{
			if (!jinru)
			{
				jinru = true;
				if (!com.IsOpen)
				{
					jinru = false;
					return false;
				}
				try
				{
					com.Write(new byte[7]
					{
						1,
						0,
						7,
						(byte)(xx >> 8),
						(byte)xx,
						(byte)(yy >> 8),
						(byte)yy
					}, 0, 7);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					jinru = false;
					return false;
				}
				int num = 500;
				fanhui = false;
				while (0 < num--)
				{
					Thread.Sleep(10);
					处理事件();
					if (fanhui)
					{
						x = xx;
						y = yy;
						if (pp)
						{
							p.Location = new Point(x - 3, y - 3);
						}
						jinru = false;
						return true;
					}
				}
			}
			jinru = false;
			return false;
		}

		public bool kai_deng()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					2,
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
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool guan_deng()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					3,
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
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool kai_feng()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					4,
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
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool kai_shi(int xx, int yy)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[7]
				{
					20,
					0,
					7,
					(byte)(xx >> 8),
					(byte)xx,
					(byte)(yy >> 8),
					(byte)yy
				}, 0, 7);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 10;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool jie_shu()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					21,
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
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool stop_tj()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					39,
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
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool guan_feng()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					5,
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
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool guan_feng2()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[1]
				{
					5
				}, 0, 1);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 10;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool kai_feng2()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[1]
				{
					4
				}, 0, 1);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 10;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool zan_ting()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					24,
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
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool ji_xu()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					25,
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
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool fu_wei()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					6,
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
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					x = 0;
					y = 0;
					return true;
				}
			}
			return false;
		}

		public bool hui_ling()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					8,
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
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool dian_deng(int s)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[5]
				{
					7,
					0,
					5,
					(byte)(s >> 8),
					(byte)s
				}, 0, 5);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 10;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool go_x(int s)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[5]
				{
					11,
					0,
					5,
					(byte)(s >> 8),
					(byte)s
				}, 0, 5);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool go_y(int s)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[5]
				{
					12,
					0,
					5,
					(byte)(s >> 8),
					(byte)s
				}, 0, 5);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool shang(int s)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[5]
				{
					15,
					0,
					5,
					(byte)(s >> 8),
					(byte)s
				}, 0, 5);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool xia(int s)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[5]
				{
					16,
					0,
					5,
					(byte)(s >> 8),
					(byte)s
				}, 0, 5);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool zuo(int s)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[5]
				{
					17,
					0,
					5,
					(byte)(s >> 8),
					(byte)s
				}, 0, 5);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool you(int s)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[5]
				{
					18,
					0,
					5,
					(byte)(s >> 8),
					(byte)s
				}, 0, 5);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool kai_kuang(int k, int g)
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[7]
				{
					13,
					0,
					7,
					(byte)(k >> 8),
					(byte)k,
					(byte)(g >> 8),
					(byte)g
				}, 0, 7);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool guan_kuang()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					14,
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
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool dao_yuandian()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					23,
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
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool dao_zhongxin()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					26,
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
			int num = 300;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool stop()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[4]
				{
					22,
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
			return true;
		}

		public bool guan_ruo_guang()
		{
			return true;
		}

		public bool tuo_ji_da_yin()
		{
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[7]
				{
					255,
					23,
					0,
					0,
					0,
					0,
					0
				}, 0, 7);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 10;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool zhi_lei_xing(int a)
		{
			byte b = 0;
			b = (byte)((a != 1) ? 26 : 24);
			if (!com.IsOpen)
			{
				return false;
			}
			try
			{
				com.Write(new byte[7]
				{
					255,
					b,
					0,
					0,
					0,
					0,
					0
				}, 0, 7);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
			int num = 1000;
			fanhui = false;
			while (0 < num--)
			{
				Thread.Sleep(10);
				处理事件();
				if (fanhui)
				{
					return true;
				}
			}
			return false;
		}

		public bool gai_bian_F(int s)
		{
			return false;
		}

		public static byte[] sheng_cheng_tuoji(Bitmap bit)
		{
			int num = 0;
			int num2 = 0;
			byte[] array = new byte[31500];
			uint num3 = 0u;
			byte b = 0;
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
			for (num = 0; num < bit.Height; num++)
			{
				for (num2 = 0; num2 < bit.Width; num2 += 8)
				{
					int num4 = 0;
					b = 0;
					for (num4 = 0; num4 < 8; num4++)
					{
						if (num2 + num4 < 500 && bit.GetPixel(num2 + num4, num).R == 0)
						{
							b = (byte)(b | array2[num4]);
						}
					}
					array[num3++] = b;
				}
			}
			return array;
		}

		public void duoji(ProgressBar jdt)
		{
			int num = 0;
			if (!lianjie)
			{
				MessageBox.Show("没有连接设备！");
				return;
			}
			jdt.Visible = true;
			byte[] buffer = sheng_cheng_tuoji(tu_pian);
			if (!zhi_lei_xing(1))
			{
				return;
			}
			Thread.Sleep(10);
			处理事件();
			for (int i = 0; i < 50; i++)
			{
				fanhui = false;
				com.Write(buffer, 630 * i, 630);
				num = 1800;
				jdt.Value = i * 2;
				while (!fanhui)
				{
					Thread.Sleep(1);
					处理事件();
					if (num-- == 0)
					{
						return;
					}
				}
			}
			jdt.Value = 0;
			jdt.Visible = false;
		}

		private byte[] sheng_cheng_tuoji2(Point[] line)
		{
			byte[] array = new byte[line.Length * 4 + 2];
			for (int i = 0; i < line.Length; i++)
			{
				array[i * 4] = (byte)(line[i].X >> 8);
				array[i * 4 + 1] = (byte)line[i].X;
				array[i * 4 + 2] = (byte)(line[i].Y >> 8);
				array[i * 4 + 3] = (byte)line[i].Y;
			}
			array[array.Length - 2] = 254;
			array[array.Length - 1] = 254;
			return array;
		}

		public void duoji2(ProgressBar jdt, Point[] line)
		{
			int num = 0;
			if (!lianjie)
			{
				MessageBox.Show("没有连接设备！");
				return;
			}
			jdt.Visible = true;
			byte[] array = sheng_cheng_tuoji2(line);
			if (!zhi_lei_xing(2))
			{
				return;
			}
			Thread.Sleep(10);
			处理事件();
			int num2 = array.Length / 630;
			int i;
			for (i = 0; i < num2; i++)
			{
				fanhui = false;
				com.Write(array, 630 * i, 630);
				num = 1800;
				jdt.Value = i * 2;
				while (!fanhui)
				{
					Thread.Sleep(1);
					处理事件();
					if (num-- == 0)
					{
						return;
					}
				}
			}
			fanhui = false;
			com.Write(array, 630 * num2, array.Length - 630 * num2);
			num = 1800;
			jdt.Value = i / 5;
			while (!fanhui)
			{
				Thread.Sleep(1);
				处理事件();
				if (num-- == 0)
				{
					return;
				}
			}
			jdt.Value = 0;
			jdt.Visible = false;
		}
	}
}
