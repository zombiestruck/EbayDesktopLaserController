// Decompiled with JetBrains decompiler
// Type: 微型雕刻机2.Program
// Assembly: 微型雕刻机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3AF547DE-808E-4700-98FB-6D70B3F08398
// Assembly location: D:\Downloads\Laser engraving machine (3).exe

using System;
using System.Windows.Forms;

namespace 微型雕刻机2
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
