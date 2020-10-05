using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 微型雕刻机2
{
	public class TransTextBox : TextBox
	{
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
				{
					createParams.ExStyle |= 32;
					createParams.ClassName = "RICHEDIT50W";
				}
				return createParams;
			}
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr LoadLibrary(string lpFileName);
	}
}
