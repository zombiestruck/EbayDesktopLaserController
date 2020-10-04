// Decompiled with JetBrains decompiler
// Type: 微型雕刻机2.g_dai_ma
// Assembly: 微型雕刻机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3AF547DE-808E-4700-98FB-6D70B3F08398
// Assembly location: D:\Downloads\Laser engraving machine (3).exe

using System;
using System.Drawing;

namespace 微型雕刻机2
{
  internal class g_dai_ma
  {
    private static double fen_bian_lv = 0.076;
    private static double x_double = 0.0;
    private static double y_double = 0.0;
    private static int bu = 10;
    private static Point[] zhixian = new Point[0];

    private static double[] qu_dian_double(string str)
    {
      double[] numArray = new double[2];
      int startIndex1 = str.IndexOf("X", 0, StringComparison.Ordinal);
      int num1 = str.IndexOf(" ", startIndex1, StringComparison.Ordinal);
      numArray[0] = Convert.ToDouble(str.Substring(startIndex1 + 1, num1 - startIndex1 - 1));
      int startIndex2 = str.IndexOf("Y", 0, StringComparison.Ordinal);
      int num2 = str.IndexOf(" ", startIndex2, StringComparison.Ordinal);
      if (num2 <= 0)
        num2 = str.Length;
      string str1 = str.Substring(startIndex2 + 1, num2 - startIndex2 - 1);
      int num3 = str1.IndexOf("F", 0, StringComparison.Ordinal);
      if (num3 >= 1)
        str1 = str.Substring(startIndex2 + 1, num3 - 1);
      numArray[1] = Convert.ToDouble(str1);
      return numArray;
    }

    private static Point[] jiaru(Point[] sz, Point cy)
    {
      Point[] pointArray = new Point[sz.Length + 1];
      for (int index = 0; index < sz.Length; ++index)
        pointArray[index] = sz[index];
      pointArray[sz.Length] = cy;
      return pointArray;
    }

    private static int g_qu_g(string str)
    {
      if (str.Length < 4)
        return 4;
      string strA1 = str.Substring(0, 3);
      string strA2 = str.Substring(0, 4);
      if ((string.Compare(strA1, "G01") == 0 || string.Compare(strA1, "G1 ") == 0) && string.Compare(strA2, "G1 F") != 0)
        return 1;
      if (string.Compare(strA1, "G02") == 0 || string.Compare(strA1, "G2 ") == 0)
        return 2;
      if (string.Compare(strA1, "G03") == 0 || string.Compare(strA1, "G3 ") == 0)
        return 3;
      return (string.Compare(strA1, "G00") == 0 || string.Compare(strA1, "G0 ") == 0) && string.Compare(strA2, "G1 F") != 0 ? 1 : 4;
    }

    private static double[] qu_dian2_double(string str)
    {
      double[] numArray = new double[2];
      int startIndex1 = str.IndexOf("I", 0, StringComparison.Ordinal);
      int num1 = str.IndexOf(" ", startIndex1, StringComparison.Ordinal);
      numArray[0] = Convert.ToDouble(str.Substring(startIndex1 + 1, num1 - startIndex1 - 1));
      int startIndex2 = str.IndexOf("J", 0, StringComparison.Ordinal);
      int num2 = str.IndexOf(" ", startIndex2, StringComparison.Ordinal);
      if (num2 <= 0)
        num2 = str.Length;
      numArray[1] = Convert.ToDouble(str.Substring(startIndex2 + 1, num2 - startIndex2 - 1));
      return numArray;
    }

    private static void huayuan(
      double yx,
      double yy,
      double q_jiao,
      double z_jiao,
      double banjing,
      bool shun)
    {
      Point[] pointArray = new Point[1];
      if (shun)
      {
        if (z_jiao > q_jiao)
        {
          Point cy = new Point(0, 0);
          for (int index = (int) q_jiao; (double) index < z_jiao - (double) g_dai_ma.bu; index += g_dai_ma.bu)
          {
            cy.X = (int) (Math.Cos((double) index * (Math.PI / 180.0)) * banjing + yx);
            cy.Y = (int) (Math.Sin((double) index * (Math.PI / 180.0)) * banjing + yy);
            g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
          }
          cy.X = (int) (Math.Cos(z_jiao * (Math.PI / 180.0)) * banjing + yx);
          cy.Y = (int) (Math.Sin(z_jiao * (Math.PI / 180.0)) * banjing + yy);
          g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
        }
        else
        {
          double num = z_jiao;
          Point cy = new Point(0, 0);
          for (int index = (int) q_jiao; index < 352; index += g_dai_ma.bu)
          {
            cy.X = (int) (Math.Cos((double) index * (Math.PI / 180.0)) * banjing + yx);
            cy.Y = (int) (Math.Sin((double) index * (Math.PI / 180.0)) * banjing + yy);
            g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
          }
          cy.X = (int) (Math.Cos(359.0 * Math.PI / 180.0) * banjing + yx);
          cy.Y = (int) (Math.Sin(359.0 * Math.PI / 180.0) * banjing + yy);
          g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
          for (int index = 0; (double) index < num - (double) g_dai_ma.bu; index += g_dai_ma.bu)
          {
            cy.X = (int) (Math.Cos((double) index * (Math.PI / 180.0)) * banjing + yx);
            cy.Y = (int) (Math.Sin((double) index * (Math.PI / 180.0)) * banjing + yy);
            g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
          }
          cy.X = (int) (Math.Cos(num * (Math.PI / 180.0)) * banjing + yx);
          cy.Y = (int) (Math.Sin(num * (Math.PI / 180.0)) * banjing + yy);
          g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
        }
      }
      else if (z_jiao < q_jiao)
      {
        Point cy = new Point(0, 0);
        for (int index = (int) q_jiao; (double) index > z_jiao + (double) g_dai_ma.bu; index -= g_dai_ma.bu)
        {
          cy.X = (int) (Math.Cos((double) index * (Math.PI / 180.0)) * banjing + yx);
          cy.Y = (int) (Math.Sin((double) index * (Math.PI / 180.0)) * banjing + yy);
          g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
        }
        cy.X = (int) (Math.Cos(z_jiao * (Math.PI / 180.0)) * banjing + yx);
        cy.Y = (int) (Math.Sin(z_jiao * (Math.PI / 180.0)) * banjing + yy);
        g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
      }
      else
      {
        double num = z_jiao;
        Point cy = new Point(0, 0);
        for (int index = (int) q_jiao; index > g_dai_ma.bu; index -= g_dai_ma.bu)
        {
          cy.X = (int) (Math.Cos((double) index * (Math.PI / 180.0)) * banjing + yx);
          cy.Y = (int) (Math.Sin((double) index * (Math.PI / 180.0)) * banjing + yy);
          g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
        }
        cy.X = (int) (Math.Cos(0.0) * banjing + yx);
        cy.Y = (int) (Math.Sin(0.0) * banjing + yy);
        g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
        for (int index = 360; (double) index > num + (double) g_dai_ma.bu; index -= g_dai_ma.bu)
        {
          cy.X = (int) (Math.Cos((double) index * (Math.PI / 180.0)) * banjing + yx);
          cy.Y = (int) (Math.Sin((double) index * (Math.PI / 180.0)) * banjing + yy);
          g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
        }
        cy.X = (int) (Math.Cos(num * (Math.PI / 180.0)) * banjing + yx);
        cy.Y = (int) (Math.Sin(num * (Math.PI / 180.0)) * banjing + yy);
        g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, cy);
      }
    }

    private static void jie_xi_g2(string s)
    {
      double[] numArray1 = g_dai_ma.qu_dian_double(s);
      double[] numArray2 = g_dai_ma.qu_dian2_double(s);
      numArray1[0] = numArray1[0] / g_dai_ma.fen_bian_lv;
      numArray1[1] = numArray1[1] / g_dai_ma.fen_bian_lv;
      numArray2[0] = numArray2[0] / g_dai_ma.fen_bian_lv;
      numArray2[1] = numArray2[1] / g_dai_ma.fen_bian_lv;
      double yx = g_dai_ma.x_double + numArray2[0];
      double yy = g_dai_ma.y_double + numArray2[1];
      double num1 = yx - numArray1[0];
      double num2 = yy - numArray1[1];
      double banjing = Math.Sqrt(numArray2[0] * numArray2[0] + numArray2[1] * numArray2[1]);
      if (num2 > banjing)
        num2 = banjing;
      if (-num2 > banjing)
        num2 = -banjing;
      if (numArray2[1] > banjing)
        numArray2[1] = banjing;
      if (-numArray2[1] > banjing)
        numArray2[1] = -banjing;
      double q_jiao = 0.0;
      double z_jiao = 0.0;
      if (numArray2[0].Equals(0.0) && numArray2[1] > 0.0)
        q_jiao = 270.0;
      if (numArray2[0].Equals(0.0) && numArray2[1] < 0.0)
        q_jiao = 90.0;
      if (numArray2[0].Equals(0.0) && numArray2[1].Equals(0.0))
        return;
      if (numArray2[1].Equals(0.0) && numArray2[0] > 0.0)
        q_jiao = 180.0;
      if (numArray2[1].Equals(0.0) && numArray2[0] < 0.0)
        q_jiao = 0.0;
      if (numArray2[0] > 0.0 && numArray2[1] > 0.0)
        q_jiao = Math.Asin(numArray2[1] / banjing) * 180.0 / Math.PI + 180.0;
      if (numArray2[0] > 0.0 && numArray2[1] < 0.0)
        q_jiao = 180.0 - Math.Asin(-numArray2[1] / banjing) * 180.0 / Math.PI;
      if (numArray2[0] < 0.0 && numArray2[1] < 0.0)
        q_jiao = Math.Asin(-numArray2[1] / banjing) * 180.0 / Math.PI;
      if (numArray2[0] < 0.0 && numArray2[1] > 0.0)
        q_jiao = 360.0 - Math.Asin(numArray2[1] / banjing) * 180.0 / Math.PI;
      if (num1.Equals(0.0) && num2 > 0.0)
        z_jiao = 270.0;
      if (num1.Equals(0.0) && num2 < 0.0)
        z_jiao = 90.0;
      if (num1.Equals(0.0) && num2.Equals(0.0))
        return;
      if (num2.Equals(0.0) && num1 > 0.0)
        z_jiao = 180.0;
      if (num2.Equals(0.0) && num1 < 0.0)
        z_jiao = 0.0;
      if (num1 > 0.0 && num2 > 0.0)
        z_jiao = Math.Asin(num2 / banjing) * 180.0 / Math.PI + 180.0;
      if (num1 > 0.0 && num2 < 0.0)
        z_jiao = 180.0 - Math.Asin(-num2 / banjing) * 180.0 / Math.PI;
      if (num1 < 0.0 && num2 < 0.0)
        z_jiao = Math.Asin(-num2 / banjing) * 180.0 / Math.PI;
      if (num1 < 0.0 && num2 > 0.0)
        z_jiao = 360.0 - Math.Asin(num2 / banjing) * 180.0 / Math.PI;
      g_dai_ma.huayuan(yx, yy, q_jiao, z_jiao, banjing, false);
      g_dai_ma.x_double = numArray1[0];
      g_dai_ma.y_double = numArray1[1];
    }

    private static void jie_xi_g3(string s)
    {
      double[] numArray1 = g_dai_ma.qu_dian_double(s);
      double[] numArray2 = g_dai_ma.qu_dian2_double(s);
      numArray1[0] = numArray1[0] / g_dai_ma.fen_bian_lv;
      numArray1[1] = numArray1[1] / g_dai_ma.fen_bian_lv;
      numArray2[0] = numArray2[0] / g_dai_ma.fen_bian_lv;
      numArray2[1] = numArray2[1] / g_dai_ma.fen_bian_lv;
      double yx = g_dai_ma.x_double + numArray2[0];
      double yy = g_dai_ma.y_double + numArray2[1];
      double num1 = yx - numArray1[0];
      double num2 = yy - numArray1[1];
      double banjing = Math.Sqrt(numArray2[0] * numArray2[0] + numArray2[1] * numArray2[1]);
      if (num2 > banjing)
        num2 = banjing;
      if (-num2 > banjing)
        num2 = -banjing;
      if (numArray2[1] > banjing)
        numArray2[1] = banjing;
      if (-numArray2[1] > banjing)
        numArray2[1] = -banjing;
      double q_jiao = 0.0;
      double z_jiao = 0.0;
      if (numArray2[0].Equals(0.0) && numArray2[1] > 0.0)
        q_jiao = 270.0;
      if (numArray2[0].Equals(0.0) && numArray2[1] < 0.0)
        q_jiao = 90.0;
      if (numArray2[0].Equals(0.0) && numArray2[1].Equals(0.0))
        return;
      if (numArray2[1].Equals(0.0) && numArray2[0] > 0.0)
        q_jiao = 180.0;
      if (numArray2[1].Equals(0.0) && numArray2[0] < 0.0)
        q_jiao = 0.0;
      if (numArray2[0] > 0.0 && numArray2[1] > 0.0)
        q_jiao = Math.Asin(numArray2[1] / banjing) * 180.0 / Math.PI + 180.0;
      if (numArray2[0] > 0.0 && numArray2[1] < 0.0)
        q_jiao = 180.0 - Math.Asin(-numArray2[1] / banjing) * 180.0 / Math.PI;
      if (numArray2[0] < 0.0 && numArray2[1] < 0.0)
        q_jiao = Math.Asin(-numArray2[1] / banjing) * 180.0 / Math.PI;
      if (numArray2[0] < 0.0 && numArray2[1] > 0.0)
        q_jiao = 360.0 - Math.Asin(numArray2[1] / banjing) * 180.0 / Math.PI;
      if (num1.Equals(0.0) && num2 > 0.0)
        z_jiao = 270.0;
      if (num1.Equals(0.0) && num2 < 0.0)
        z_jiao = 90.0;
      if (num1.Equals(0.0) && num2.Equals(0.0))
        return;
      if (num2.Equals(0.0) && num1 > 0.0)
        z_jiao = 180.0;
      if (num2.Equals(0.0) && num1 < 0.0)
        z_jiao = 0.0;
      if (num1 > 0.0 && num2 > 0.0)
        z_jiao = Math.Asin(num2 / banjing) * 180.0 / Math.PI + 180.0;
      if (num1 > 0.0 && num2 < 0.0)
        z_jiao = 180.0 - Math.Asin(-num2 / banjing) * 180.0 / Math.PI;
      if (num1 < 0.0 && num2 < 0.0)
        z_jiao = Math.Asin(-num2 / banjing) * 180.0 / Math.PI;
      if (num1 < 0.0 && num2 > 0.0)
        z_jiao = 360.0 - Math.Asin(num2 / banjing) * 180.0 / Math.PI;
      g_dai_ma.huayuan(yx, yy, q_jiao, z_jiao, banjing, true);
      g_dai_ma.x_double = numArray1[0];
      g_dai_ma.y_double = numArray1[1];
    }

    public static Point[] jie_xi(string s)
    {
      string[] strArray = s.Split(new char[2]{ '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
      g_dai_ma.zhixian = new Point[0];
      foreach (string str in strArray)
      {
        if (str[0] == 'G')
        {
          switch (g_dai_ma.g_qu_g(str))
          {
            case 1:
              double[] numArray = g_dai_ma.qu_dian_double(str);
              g_dai_ma.x_double = numArray[0] / g_dai_ma.fen_bian_lv;
              g_dai_ma.y_double = numArray[1] / g_dai_ma.fen_bian_lv;
              int xDouble = (int) g_dai_ma.x_double;
              int yDouble = (int) g_dai_ma.y_double;
              g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, new Point(xDouble, yDouble));
              continue;
            case 2:
              g_dai_ma.jie_xi_g2(str);
              continue;
            case 3:
              g_dai_ma.jie_xi_g3(str);
              continue;
            default:
              continue;
          }
        }
        else if (str[0] == 'M')
        {
          if (str[str.Length - 1] == '3')
            g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, new Point(600, 0));
          if (str[str.Length - 1] == '5')
            g_dai_ma.zhixian = g_dai_ma.jiaru(g_dai_ma.zhixian, new Point(601, 0));
        }
      }
      return g_dai_ma.zhixian;
    }
  }
}
