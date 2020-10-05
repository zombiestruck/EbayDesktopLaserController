using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 微型雕刻机2
{
	internal static class tu_xiang
	{
		public static Bitmap suofang(Bitmap bmp, int newW, int newH)
		{
			try
			{
				Bitmap bitmap = new Bitmap(newW, newH);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.InterpolationMode = InterpolationMode.Low;
				graphics.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
				graphics.Dispose();
				return bitmap;
			}
			catch
			{
				return null;
			}
		}

		public static int[] qu_bian_jie2(Bitmap bb2)
		{
			if (bb2 == null)
			{
				return new int[4];
			}
			_ = bb2.Width;
			_ = bb2.Height;
			return qu_zuo_you_shang_xia(bb2);
		}

		public static Bitmap jieping_控件(Control control)
		{
			IntPtr windowDC = GetWindowDC(control.Handle);
			if (windowDC == (IntPtr)0)
			{
				return null;
			}
			IntPtr intPtr = CreateCompatibleDC(windowDC);
			if (intPtr == (IntPtr)0)
			{
				return null;
			}
			IntPtr intPtr2 = CreateCompatibleBitmap(windowDC, control.Width - 2, control.Height - 2);
			IntPtr bmp = SelectObject(intPtr, intPtr2);
			if (BitBlt(intPtr, 0, 0, control.Width - 2, control.Height - 2, windowDC, 1, 1, (CopyPixelOperation)1087111200))
			{
				Bitmap result = Image.FromHbitmap(intPtr2);
				SelectObject(intPtr, bmp);
				DeleteObject(intPtr2);
				DeleteDC(intPtr);
				ReleaseDC(control.Handle, windowDC);
				return result;
			}
			return null;
		}

		public static int[] qu_zuo_you_shang_xia(Bitmap b)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			bool flag = false;
			for (num5 = 0; num5 < b.Width; num5++)
			{
				for (num6 = 0; num6 < b.Height; num6++)
				{
					if (200 > b.GetPixel(num5, num6).B)
					{
						num = num5;
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			flag = false;
			for (num5 = b.Width - 1; num5 >= 0; num5--)
			{
				for (num6 = 0; num6 < b.Height; num6++)
				{
					if (200 > b.GetPixel(num5, num6).B)
					{
						num2 = num5;
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			flag = false;
			for (num5 = 0; num5 < b.Height; num5++)
			{
				for (num6 = 0; num6 < b.Width; num6++)
				{
					if (200 > b.GetPixel(num6, num5).B)
					{
						num3 = num5;
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			flag = false;
			for (num5 = b.Height - 1; num5 >= 0; num5--)
			{
				for (num6 = 0; num6 < b.Width; num6++)
				{
					if (200 > b.GetPixel(num6, num5).B)
					{
						num4 = num5;
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			return new int[4]
			{
				num,
				num2,
				num3,
				num4
			};
		}

		public static Bitmap fanse(Bitmap bmp)
		{
			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
			BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			int num = Math.Abs(bitmapData.Stride) * bmp.Height;
			byte[] array = new byte[num];
			byte[] array2 = new byte[num];
			Marshal.Copy(scan, array, 0, num);
			int num2 = 0;
			for (int i = 0; i < array.Length; i += 4)
			{
				num2 = ((array[i] == 0) ? 255 : 0);
				array2[i] = (byte)num2;
				array2[i + 1] = (byte)num2;
				array2[i + 2] = (byte)num2;
				array2[i + 3] = byte.MaxValue;
			}
			Marshal.Copy(array2, 0, scan, num);
			bmp.UnlockBits(bitmapData);
			return bmp;
		}

		public static Bitmap fanse_huidu(Bitmap bmp)
		{
			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
			BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			int num = Math.Abs(bitmapData.Stride) * bmp.Height;
			byte[] array = new byte[num];
			byte[] array2 = new byte[num];
			Marshal.Copy(scan, array, 0, num);
			int num2 = 0;
			for (int i = 0; i < array.Length; i += 4)
			{
				num2 = array[i];
				num2 = 255 - num2;
				array2[i] = (byte)num2;
				array2[i + 1] = (byte)num2;
				array2[i + 2] = (byte)num2;
				array2[i + 3] = byte.MaxValue;
			}
			Marshal.Copy(array2, 0, scan, num);
			bmp.UnlockBits(bitmapData);
			return bmp;
		}

		public static Bitmap fanse2(Bitmap mybm)
		{
			Bitmap bitmap = new Bitmap(mybm.Width, mybm.Height);
			for (int i = 0; i < mybm.Width; i++)
			{
				for (int j = 0; j < mybm.Height; j++)
				{
					Color pixel = mybm.GetPixel(i, j);
					int red = 255 - pixel.R;
					int green = 255 - pixel.G;
					int blue = 255 - pixel.B;
					bitmap.SetPixel(i, j, Color.FromArgb(red, green, blue));
				}
			}
			return bitmap;
		}

		public static Bitmap qu_bian_jie(Bitmap bb2)
		{
			_ = bb2.Width;
			_ = bb2.Height;
			int[] array = qu_zuo_you_shang_xia(bb2);
			if (array[0] != 0 || array[1] != 0 || array[2] != 0 || array[3] != 0)
			{
				int num = 0;
				int num2 = 0;
				num = array[1] - array[0] + 10;
				num2 = array[3] - array[2] + 10;
				if (bb2.Width >= num && bb2.Height >= num2)
				{
					Bitmap bitmap = new Bitmap(num, num2);
					Graphics.FromImage(bitmap).DrawImage(bb2, 0, 0, new Rectangle(array[0] - 5, array[2] - 5, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
					bb2 = bitmap;
				}
			}
			return bb2;
		}

		public static tu_kuan_gao shua_xin(Panel pp, Bitmap bb2, int dx, int dy, int kuan, int gao, bool hui)
		{
			_ = bb2.Width;
			_ = bb2.Height;
			Graphics graphics = pp.CreateGraphics();
			graphics.DrawImage(bb2, dx, dy, (int)((double)bb2.Width * 0.3125), (int)((double)bb2.Height * 0.3125));
			int width = (int)((double)bb2.Width * 0.3125);
			int height = (int)((double)bb2.Height * 0.3125);
			pp.Width = width;
			pp.Height = height;
			graphics.Dispose();
			tu_kuan_gao result = default(tu_kuan_gao);
			result.bb = bb2;
			result.g = (int)((double)bb2.Height * 0.3125);
			result.k = (int)((double)bb2.Width * 0.3125);
			return result;
		}

		public static void shua_xin2(IntPtr 句柄, Bitmap bit, int dx, int dy)
		{
			IntPtr dC = GetDC(句柄);
			IntPtr hbitmap = bit.GetHbitmap();
			IntPtr intPtr = CreateCompatibleDC(dC);
			IntPtr intPtr2 = CreateCompatibleBitmap(dC, 500, 500);
			intPtr2 = hbitmap;
			IntPtr bmp = SelectObject(intPtr, intPtr2);
			BitBlt(intPtr, 50, 0, 500, 500, hbitmap, 0, 0, CopyPixelOperation.SourceCopy);
			BitBlt(dC, dx, dy, 500, 500, intPtr, 0, 0, CopyPixelOperation.SourceCopy);
			SelectObject(intPtr, bmp);
			DeleteObject(dC);
			DeleteObject(hbitmap);
			DeleteObject(intPtr);
			DeleteObject(intPtr2);
			DeleteDC(dC);
			DeleteDC(hbitmap);
			DeleteDC(intPtr);
			DeleteDC(intPtr2);
		}

		[DllImport("User32.dll")]
		private static extern IntPtr GetDC(IntPtr hdc);

		[DllImport("Gdi32.dll")]
		private static extern IntPtr SetStretchBltMode(IntPtr hdc, int ySrc);

		[DllImport("Gdi32.dll")]
		private static extern IntPtr StretchBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, int w, int h, CopyPixelOperation rop);

		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);

		[DllImport("gdi32.dll")]
		private static extern IntPtr DeleteDC(IntPtr hDc);

		[DllImport("gdi32.dll")]
		private static extern IntPtr DeleteObject(IntPtr hDc);

		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

		[DllImport("user32.dll")]
		public static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr ptr);

		[DllImport("user32.dll")]
		public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);

		[DllImport("user32.dll")]
		private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
	}
}
