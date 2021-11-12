// Decompiled with JetBrains decompiler
// Type: Fire_Emblem_Three_Houses_Randomizer_V2.Program
// Assembly: Fire Emblem Three Houses Randomizer V2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 800CD4D2-D1E7-4E09-8822-0C2C01D464BA
// Assembly location: C:\Users\ninte\Desktop\Games\Switch\Fire Emblem Three Houses Randomizer.exe

using System;
using System.Windows.Forms;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Randomizer.rng = new RandomLog();
      Randomizer.setKnown();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new RandomizerForm());
    }
  }
}
