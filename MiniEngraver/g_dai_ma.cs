using System;
using System.Drawing;

namespace MiniEngraver
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
			double[] array = new double[2];
			int num = str.IndexOf("X", 0, StringComparison.Ordinal);
			int num2 = str.IndexOf(" ", num, StringComparison.Ordinal);
			double num3 = array[0] = Convert.ToDouble(str.Substring(num + 1, num2 - num - 1));
			num = str.IndexOf("Y", 0, StringComparison.Ordinal);
			num2 = str.IndexOf(" ", num, StringComparison.Ordinal);
			if (num2 <= 0)
			{
				num2 = str.Length;
			}
			string text = str.Substring(num + 1, num2 - num - 1);
			int num4 = text.IndexOf("F", 0, StringComparison.Ordinal);
			if (num4 >= 1)
			{
				text = str.Substring(num + 1, num4 - 1);
			}
			array[1] = Convert.ToDouble(text);
			return array;
		}

		private static Point[] jiaru(Point[] sz, Point cy)
		{
			Point[] array = new Point[sz.Length + 1];
			for (int i = 0; i < sz.Length; i++)
			{
				array[i] = sz[i];
			}
			array[sz.Length] = cy;
			return array;
		}

		private static int g_qu_g(string str)
		{
			if (str.Length < 4)
			{
				return 4;
			}
			string strA = str.Substring(0, 3);
			string strA2 = str.Substring(0, 4);
			if ((string.Compare(strA, "G01") == 0 || string.Compare(strA, "G1 ") == 0) && string.Compare(strA2, "G1 F") != 0)
			{
				return 1;
			}
			if (string.Compare(strA, "G02") == 0 || string.Compare(strA, "G2 ") == 0)
			{
				return 2;
			}
			if (string.Compare(strA, "G03") == 0 || string.Compare(strA, "G3 ") == 0)
			{
				return 3;
			}
			if ((string.Compare(strA, "G00") == 0 || string.Compare(strA, "G0 ") == 0) && string.Compare(strA2, "G1 F") != 0)
			{
				return 1;
			}
			return 4;
		}

		private static double[] qu_dian2_double(string str)
		{
			double[] array = new double[2];
			int num = str.IndexOf("I", 0, StringComparison.Ordinal);
			int num2 = str.IndexOf(" ", num, StringComparison.Ordinal);
			array[0] = Convert.ToDouble(str.Substring(num + 1, num2 - num - 1));
			num = str.IndexOf("J", 0, StringComparison.Ordinal);
			num2 = str.IndexOf(" ", num, StringComparison.Ordinal);
			if (num2 <= 0)
			{
				num2 = str.Length;
			}
			array[1] = Convert.ToDouble(str.Substring(num + 1, num2 - num - 1));
			return array;
		}

		private static void huayuan(double yx, double yy, double q_jiao, double z_jiao, double banjing, bool shun)
		{
			int num = 0;
			_ = new Point[1];
			if (shun)
			{
				if (z_jiao > q_jiao)
				{
					Point cy = new Point(0, 0);
					for (num = (int)q_jiao; (double)num < z_jiao - (double)bu; num += bu)
					{
						cy.X = (int)(Math.Cos((double)num * (Math.PI / 180.0)) * banjing + yx);
						cy.Y = (int)(Math.Sin((double)num * (Math.PI / 180.0)) * banjing + yy);
						zhixian = jiaru(zhixian, cy);
					}
					cy.X = (int)(Math.Cos(z_jiao * (Math.PI / 180.0)) * banjing + yx);
					cy.Y = (int)(Math.Sin(z_jiao * (Math.PI / 180.0)) * banjing + yy);
					zhixian = jiaru(zhixian, cy);
					return;
				}
				Point cy2 = new Point(0, 0);
				for (num = (int)q_jiao; num < 352; num += bu)
				{
					cy2.X = (int)(Math.Cos((double)num * (Math.PI / 180.0)) * banjing + yx);
					cy2.Y = (int)(Math.Sin((double)num * (Math.PI / 180.0)) * banjing + yy);
					zhixian = jiaru(zhixian, cy2);
				}
				cy2.X = (int)(Math.Cos(6.2657320146596431) * banjing + yx);
				cy2.Y = (int)(Math.Sin(6.2657320146596431) * banjing + yy);
				zhixian = jiaru(zhixian, cy2);
				for (num = 0; (double)num < z_jiao - (double)bu; num += bu)
				{
					cy2.X = (int)(Math.Cos((double)num * (Math.PI / 180.0)) * banjing + yx);
					cy2.Y = (int)(Math.Sin((double)num * (Math.PI / 180.0)) * banjing + yy);
					zhixian = jiaru(zhixian, cy2);
				}
				cy2.X = (int)(Math.Cos(z_jiao * (Math.PI / 180.0)) * banjing + yx);
				cy2.Y = (int)(Math.Sin(z_jiao * (Math.PI / 180.0)) * banjing + yy);
				zhixian = jiaru(zhixian, cy2);
			}
			else if (z_jiao < q_jiao)
			{
				Point cy3 = new Point(0, 0);
				num = (int)q_jiao;
				while ((double)num > z_jiao + (double)bu)
				{
					cy3.X = (int)(Math.Cos((double)num * (Math.PI / 180.0)) * banjing + yx);
					cy3.Y = (int)(Math.Sin((double)num * (Math.PI / 180.0)) * banjing + yy);
					zhixian = jiaru(zhixian, cy3);
					num -= bu;
				}
				cy3.X = (int)(Math.Cos(z_jiao * (Math.PI / 180.0)) * banjing + yx);
				cy3.Y = (int)(Math.Sin(z_jiao * (Math.PI / 180.0)) * banjing + yy);
				zhixian = jiaru(zhixian, cy3);
			}
			else
			{
				Point cy4 = new Point(0, 0);
				for (num = (int)q_jiao; num > bu; num -= bu)
				{
					cy4.X = (int)(Math.Cos((double)num * (Math.PI / 180.0)) * banjing + yx);
					cy4.Y = (int)(Math.Sin((double)num * (Math.PI / 180.0)) * banjing + yy);
					zhixian = jiaru(zhixian, cy4);
				}
				cy4.X = (int)(Math.Cos(0.0) * banjing + yx);
				cy4.Y = (int)(Math.Sin(0.0) * banjing + yy);
				zhixian = jiaru(zhixian, cy4);
				num = 360;
				while ((double)num > z_jiao + (double)bu)
				{
					cy4.X = (int)(Math.Cos((double)num * (Math.PI / 180.0)) * banjing + yx);
					cy4.Y = (int)(Math.Sin((double)num * (Math.PI / 180.0)) * banjing + yy);
					zhixian = jiaru(zhixian, cy4);
					num -= bu;
				}
				cy4.X = (int)(Math.Cos(z_jiao * (Math.PI / 180.0)) * banjing + yx);
				cy4.Y = (int)(Math.Sin(z_jiao * (Math.PI / 180.0)) * banjing + yy);
				zhixian = jiaru(zhixian, cy4);
			}
		}

		private static void jie_xi_g2(string s)
		{
			double[] array = qu_dian_double(s);
			double[] array2 = qu_dian2_double(s);
			array[0] /= fen_bian_lv;
			array[1] /= fen_bian_lv;
			array2[0] /= fen_bian_lv;
			array2[1] /= fen_bian_lv;
			double num = x_double + array2[0];
			double num2 = y_double + array2[1];
			double num3 = num - array[0];
			double num4 = num2 - array[1];
			double num5 = Math.Sqrt(array2[0] * array2[0] + array2[1] * array2[1]);
			if (num4 > num5)
			{
				num4 = num5;
			}
			if (0.0 - num4 > num5)
			{
				num4 = 0.0 - num5;
			}
			if (array2[1] > num5)
			{
				array2[1] = num5;
			}
			if (0.0 - array2[1] > num5)
			{
				array2[1] = 0.0 - num5;
			}
			double q_jiao = 0.0;
			double z_jiao = 0.0;
			if (array2[0].Equals(0.0) && array2[1] > 0.0)
			{
				q_jiao = 270.0;
			}
			if (array2[0].Equals(0.0) && array2[1] < 0.0)
			{
				q_jiao = 90.0;
			}
			if (array2[0].Equals(0.0) && array2[1].Equals(0.0))
			{
				return;
			}
			if (array2[1].Equals(0.0) && array2[0] > 0.0)
			{
				q_jiao = 180.0;
			}
			if (array2[1].Equals(0.0) && array2[0] < 0.0)
			{
				q_jiao = 0.0;
			}
			if (array2[0] > 0.0 && array2[1] > 0.0)
			{
				q_jiao = Math.Asin(array2[1] / num5) * 180.0 / Math.PI + 180.0;
			}
			if (array2[0] > 0.0 && array2[1] < 0.0)
			{
				q_jiao = 180.0 - Math.Asin((0.0 - array2[1]) / num5) * 180.0 / Math.PI;
			}
			if (array2[0] < 0.0 && array2[1] < 0.0)
			{
				q_jiao = Math.Asin((0.0 - array2[1]) / num5) * 180.0 / Math.PI;
			}
			if (array2[0] < 0.0 && array2[1] > 0.0)
			{
				q_jiao = 360.0 - Math.Asin(array2[1] / num5) * 180.0 / Math.PI;
			}
			if (num3.Equals(0.0) && num4 > 0.0)
			{
				z_jiao = 270.0;
			}
			if (num3.Equals(0.0) && num4 < 0.0)
			{
				z_jiao = 90.0;
			}
			if (!num3.Equals(0.0) || !num4.Equals(0.0))
			{
				if (num4.Equals(0.0) && num3 > 0.0)
				{
					z_jiao = 180.0;
				}
				if (num4.Equals(0.0) && num3 < 0.0)
				{
					z_jiao = 0.0;
				}
				if (num3 > 0.0 && num4 > 0.0)
				{
					z_jiao = Math.Asin(num4 / num5) * 180.0 / Math.PI + 180.0;
				}
				if (num3 > 0.0 && num4 < 0.0)
				{
					z_jiao = 180.0 - Math.Asin((0.0 - num4) / num5) * 180.0 / Math.PI;
				}
				if (num3 < 0.0 && num4 < 0.0)
				{
					z_jiao = Math.Asin((0.0 - num4) / num5) * 180.0 / Math.PI;
				}
				if (num3 < 0.0 && num4 > 0.0)
				{
					z_jiao = 360.0 - Math.Asin(num4 / num5) * 180.0 / Math.PI;
				}
				huayuan(num, num2, q_jiao, z_jiao, num5, shun: false);
				x_double = array[0];
				y_double = array[1];
			}
		}

		private static void jie_xi_g3(string s)
		{
			double[] array = qu_dian_double(s);
			double[] array2 = qu_dian2_double(s);
			array[0] /= fen_bian_lv;
			array[1] /= fen_bian_lv;
			array2[0] /= fen_bian_lv;
			array2[1] /= fen_bian_lv;
			double num = x_double + array2[0];
			double num2 = y_double + array2[1];
			double num3 = num - array[0];
			double num4 = num2 - array[1];
			double num5 = Math.Sqrt(array2[0] * array2[0] + array2[1] * array2[1]);
			if (num4 > num5)
			{
				num4 = num5;
			}
			if (0.0 - num4 > num5)
			{
				num4 = 0.0 - num5;
			}
			if (array2[1] > num5)
			{
				array2[1] = num5;
			}
			if (0.0 - array2[1] > num5)
			{
				array2[1] = 0.0 - num5;
			}
			double q_jiao = 0.0;
			double z_jiao = 0.0;
			if (array2[0].Equals(0.0) && array2[1] > 0.0)
			{
				q_jiao = 270.0;
			}
			if (array2[0].Equals(0.0) && array2[1] < 0.0)
			{
				q_jiao = 90.0;
			}
			if (array2[0].Equals(0.0) && array2[1].Equals(0.0))
			{
				return;
			}
			if (array2[1].Equals(0.0) && array2[0] > 0.0)
			{
				q_jiao = 180.0;
			}
			if (array2[1].Equals(0.0) && array2[0] < 0.0)
			{
				q_jiao = 0.0;
			}
			if (array2[0] > 0.0 && array2[1] > 0.0)
			{
				q_jiao = Math.Asin(array2[1] / num5) * 180.0 / Math.PI + 180.0;
			}
			if (array2[0] > 0.0 && array2[1] < 0.0)
			{
				q_jiao = 180.0 - Math.Asin((0.0 - array2[1]) / num5) * 180.0 / Math.PI;
			}
			if (array2[0] < 0.0 && array2[1] < 0.0)
			{
				q_jiao = Math.Asin((0.0 - array2[1]) / num5) * 180.0 / Math.PI;
			}
			if (array2[0] < 0.0 && array2[1] > 0.0)
			{
				q_jiao = 360.0 - Math.Asin(array2[1] / num5) * 180.0 / Math.PI;
			}
			if (num3.Equals(0.0) && num4 > 0.0)
			{
				z_jiao = 270.0;
			}
			if (num3.Equals(0.0) && num4 < 0.0)
			{
				z_jiao = 90.0;
			}
			if (!num3.Equals(0.0) || !num4.Equals(0.0))
			{
				if (num4.Equals(0.0) && num3 > 0.0)
				{
					z_jiao = 180.0;
				}
				if (num4.Equals(0.0) && num3 < 0.0)
				{
					z_jiao = 0.0;
				}
				if (num3 > 0.0 && num4 > 0.0)
				{
					z_jiao = Math.Asin(num4 / num5) * 180.0 / Math.PI + 180.0;
				}
				if (num3 > 0.0 && num4 < 0.0)
				{
					z_jiao = 180.0 - Math.Asin((0.0 - num4) / num5) * 180.0 / Math.PI;
				}
				if (num3 < 0.0 && num4 < 0.0)
				{
					z_jiao = Math.Asin((0.0 - num4) / num5) * 180.0 / Math.PI;
				}
				if (num3 < 0.0 && num4 > 0.0)
				{
					z_jiao = 360.0 - Math.Asin(num4 / num5) * 180.0 / Math.PI;
				}
				huayuan(num, num2, q_jiao, z_jiao, num5, shun: true);
				x_double = array[0];
				y_double = array[1];
			}
		}

		public static Point[] jie_xi(string s)
		{
			string[] array = s.Split(new char[2]
			{
				'\r',
				'\n'
			}, StringSplitOptions.RemoveEmptyEntries);
			zhixian = new Point[0];
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text[0] == 'G')
				{
					switch (g_qu_g(text))
					{
					case 1:
					{
						double[] array3 = qu_dian_double(text);
						x_double = array3[0] / fen_bian_lv;
						y_double = array3[1] / fen_bian_lv;
						int num = 0;
						int num2 = 0;
						num = (int)x_double;
						num2 = (int)y_double;
						zhixian = jiaru(zhixian, new Point(num, num2));
						break;
					}
					case 2:
						jie_xi_g2(text);
						break;
					case 3:
						jie_xi_g3(text);
						break;
					}
				}
				else if (text[0] == 'M')
				{
					if (text[text.Length - 1] == '3')
					{
						zhixian = jiaru(zhixian, new Point(600, 0));
					}
					if (text[text.Length - 1] == '5')
					{
						zhixian = jiaru(zhixian, new Point(601, 0));
					}
				}
			}
			return zhixian;
		}
	}
}
