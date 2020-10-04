// Decompiled with JetBrains decompiler
// Type: 微型雕刻机2.tu_xiang
// Assembly: 微型雕刻机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3AF547DE-808E-4700-98FB-6D70B3F08398
// Assembly location: D:\Downloads\Laser engraving machine (3).exe

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
        Graphics graphics = Graphics.FromImage((Image) bitmap);
        graphics.InterpolationMode = InterpolationMode.Low;
        graphics.DrawImage((Image) bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
        graphics.Dispose();
        return bitmap;
      }
      catch
      {
        return (Bitmap) null;
      }
    }

    public static int[] qu_bian_jie2(Bitmap bb2)
    {
      if (bb2 == null)
        return new int[4];
      int width = bb2.Width;
      int height = bb2.Height;
      return tu_xiang.qu_zuo_you_shang_xia(bb2);
    }

    public static Bitmap jieping_控件(Control control)
    {
      IntPtr windowDc = tu_xiang.GetWindowDC(control.Handle);
      if (windowDc == (IntPtr) 0)
        return (Bitmap) null;
      IntPtr compatibleDc = tu_xiang.CreateCompatibleDC(windowDc);
      if (compatibleDc == (IntPtr) 0)
        return (Bitmap) null;
      IntPtr compatibleBitmap = tu_xiang.CreateCompatibleBitmap(windowDc, control.Width, control.Height);
      IntPtr bmp = tu_xiang.SelectObject(compatibleDc, compatibleBitmap);
      if (!tu_xiang.BitBlt(compatibleDc, 0, 0, control.Width, control.Height, windowDc, 0, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt))
        return (Bitmap) null;
      Bitmap bitmap = Image.FromHbitmap(compatibleBitmap);
      tu_xiang.SelectObject(compatibleDc, bmp);
      tu_xiang.DeleteObject(compatibleBitmap);
      tu_xiang.DeleteDC(compatibleDc);
      tu_xiang.ReleaseDC(control.Handle, windowDc);
      return bitmap;
    }

    public static int[] qu_zuo_you_shang_xia(Bitmap b)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      bool flag1 = false;
      for (int x = 0; x < b.Width; ++x)
      {
        for (int y = 0; y < b.Height; ++y)
        {
          if ((byte) 200 > b.GetPixel(x, y).B)
          {
            num1 = x;
            flag1 = true;
            break;
          }
        }
        if (flag1)
          break;
      }
      bool flag2 = false;
      for (int x = b.Width - 1; x >= 0; --x)
      {
        for (int y = 0; y < b.Height; ++y)
        {
          if ((byte) 200 > b.GetPixel(x, y).B)
          {
            num2 = x;
            flag2 = true;
            break;
          }
        }
        if (flag2)
          break;
      }
      bool flag3 = false;
      for (int y = 0; y < b.Height; ++y)
      {
        for (int x = 0; x < b.Width; ++x)
        {
          if ((byte) 200 > b.GetPixel(x, y).B)
          {
            num3 = y;
            flag3 = true;
            break;
          }
        }
        if (flag3)
          break;
      }
      bool flag4 = false;
      for (int y = b.Height - 1; y >= 0; --y)
      {
        for (int x = 0; x < b.Width; ++x)
        {
          if ((byte) 200 > b.GetPixel(x, y).B)
          {
            num4 = y;
            flag4 = true;
            break;
          }
        }
        if (flag4)
          break;
      }
      return new int[4]{ num1, num2, num3, num4 };
    }

    public static Bitmap fanse(Bitmap bmp)
    {
      Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
      BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = Math.Abs(bitmapdata.Stride) * bmp.Height;
      byte[] destination = new byte[length];
      byte[] source = new byte[length];
      Marshal.Copy(scan0, destination, 0, length);
      for (int index = 0; index < destination.Length; index += 4)
      {
        int num = destination[index] != (byte) 0 ? 0 : (int) byte.MaxValue;
        source[index] = (byte) num;
        source[index + 1] = (byte) num;
        source[index + 2] = (byte) num;
        source[index + 3] = byte.MaxValue;
      }
      Marshal.Copy(source, 0, scan0, length);
      bmp.UnlockBits(bitmapdata);
      return bmp;
    }

    public static Bitmap fanse_huidu(Bitmap bmp)
    {
      Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
      BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = Math.Abs(bitmapdata.Stride) * bmp.Height;
      byte[] destination = new byte[length];
      byte[] source = new byte[length];
      Marshal.Copy(scan0, destination, 0, length);
      for (int index = 0; index < destination.Length; index += 4)
      {
        int num = (int) byte.MaxValue - (int) destination[index];
        source[index] = (byte) num;
        source[index + 1] = (byte) num;
        source[index + 2] = (byte) num;
        source[index + 3] = byte.MaxValue;
      }
      Marshal.Copy(source, 0, scan0, length);
      bmp.UnlockBits(bitmapdata);
      return bmp;
    }

    public static Bitmap fanse2(Bitmap mybm)
    {
      Bitmap bitmap = new Bitmap(mybm.Width, mybm.Height);
      for (int x = 0; x < mybm.Width; ++x)
      {
        for (int y = 0; y < mybm.Height; ++y)
        {
          Color pixel = mybm.GetPixel(x, y);
          int red = (int) byte.MaxValue - (int) pixel.R;
          int green = (int) byte.MaxValue - (int) pixel.G;
          int blue = (int) byte.MaxValue - (int) pixel.B;
          bitmap.SetPixel(x, y, Color.FromArgb(red, green, blue));
        }
      }
      return bitmap;
    }

    public static Bitmap qu_bian_jie(Bitmap bb2)
    {
      int width1 = bb2.Width;
      int height1 = bb2.Height;
      int[] numArray = tu_xiang.qu_zuo_you_shang_xia(bb2);
      if (numArray[0] != 0 || numArray[1] != 0 || (numArray[2] != 0 || numArray[3] != 0))
      {
        int width2 = numArray[1] - numArray[0] + 10;
        int height2 = numArray[3] - numArray[2] + 10;
        if (bb2.Width >= width2 && bb2.Height >= height2)
        {
          Bitmap bitmap = new Bitmap(width2, height2);
          Graphics.FromImage((Image) bitmap).DrawImage((Image) bb2, 0, 0, new Rectangle(numArray[0] - 5, numArray[2] - 5, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
          bb2 = bitmap;
        }
      }
      return bb2;
    }

    public static tu_kuan_gao shua_xin(
      Panel pp,
      Bitmap bb2,
      int dx,
      int dy,
      int kuan,
      int gao,
      bool hui)
    {
      int width = bb2.Width;
      int height = bb2.Height;
      Graphics graphics = pp.CreateGraphics();
      graphics.DrawImage((Image) bb2, dx, dy, (int) ((double) bb2.Width * (5.0 / 16.0)), (int) ((double) bb2.Height * (5.0 / 16.0)));
      int num1 = (int) ((double) bb2.Width * (5.0 / 16.0));
      int num2 = (int) ((double) bb2.Height * (5.0 / 16.0));
      pp.Width = num1;
      pp.Height = num2;
      graphics.Dispose();
      tu_kuan_gao tuKuanGao;
      tuKuanGao.bb = bb2;
      tuKuanGao.g = (int) ((double) bb2.Height * (5.0 / 16.0));
      tuKuanGao.k = (int) ((double) bb2.Width * (5.0 / 16.0));
      return tuKuanGao;
    }

    public static void shua_xin2(IntPtr 句柄, Bitmap bit, int dx, int dy)
    {
      IntPtr dc = tu_xiang.GetDC(句柄);
      IntPtr hbitmap = bit.GetHbitmap();
      IntPtr compatibleDc = tu_xiang.CreateCompatibleDC(dc);
      tu_xiang.CreateCompatibleBitmap(dc, 500, 500);
      IntPtr num = hbitmap;
      IntPtr bmp = tu_xiang.SelectObject(compatibleDc, num);
      tu_xiang.BitBlt(compatibleDc, 50, 0, 500, 500, hbitmap, 0, 0, CopyPixelOperation.SourceCopy);
      tu_xiang.BitBlt(dc, dx, dy, 500, 500, compatibleDc, 0, 0, CopyPixelOperation.SourceCopy);
      tu_xiang.SelectObject(compatibleDc, bmp);
      tu_xiang.DeleteObject(dc);
      tu_xiang.DeleteObject(hbitmap);
      tu_xiang.DeleteObject(compatibleDc);
      tu_xiang.DeleteObject(num);
      tu_xiang.DeleteDC(dc);
      tu_xiang.DeleteDC(hbitmap);
      tu_xiang.DeleteDC(compatibleDc);
      tu_xiang.DeleteDC(num);
    }

    [DllImport("User32.dll")]
    private static extern IntPtr GetDC(IntPtr hdc);

    [DllImport("Gdi32.dll")]
    private static extern IntPtr SetStretchBltMode(IntPtr hdc, int ySrc);

    [DllImport("Gdi32.dll")]
    private static extern IntPtr StretchBlt(
      IntPtr hdcDest,
      int xDest,
      int yDest,
      int wDest,
      int hDest,
      IntPtr hdcSource,
      int xSrc,
      int ySrc,
      int w,
      int h,
      CopyPixelOperation rop);

    [DllImport("gdi32.dll")]
    private static extern bool BitBlt(
      IntPtr hdcDest,
      int xDest,
      int yDest,
      int wDest,
      int hDest,
      IntPtr hdcSource,
      int xSrc,
      int ySrc,
      CopyPixelOperation rop);

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
