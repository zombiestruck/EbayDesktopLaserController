// Decompiled with JetBrains decompiler
// Type: 微型雕刻机2.TransTextBox
// Assembly: 微型雕刻机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3AF547DE-808E-4700-98FB-6D70B3F08398
// Assembly location: D:\Downloads\Laser engraving machine (3).exe

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 微型雕刻机2
{
  public class TransTextBox : TextBox
  {
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr LoadLibrary(string lpFileName);

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        if (TransTextBox.LoadLibrary("msftedit.dll") != IntPtr.Zero)
        {
          createParams.ExStyle |= 32;
          createParams.ClassName = "RICHEDIT50W";
        }
        return createParams;
      }
    }
  }
}
