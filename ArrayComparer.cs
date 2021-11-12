// Decompiled with JetBrains decompiler
// Type: ArrayComparer
// Assembly: Fire Emblem Three Houses Randomizer V2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 800CD4D2-D1E7-4E09-8822-0C2C01D464BA
// Assembly location: C:\Users\ninte\Desktop\Games\Switch\Fire Emblem Three Houses Randomizer.exe

using System.Collections.Generic;

public class ArrayComparer : IEqualityComparer<int[]>
{
  public bool Equals(int[] x, int[] y)
  {
    if (x.Length != y.Length)
      return false;
    for (int index = 0; index < x.Length; ++index)
    {
      if (x[index] != y[index])
        return false;
    }
    return true;
  }

  public int GetHashCode(int[] obj)
  {
    int num = 17;
    for (int index = 0; index < obj.Length; ++index)
      num = num * 23 + obj[index];
    return num;
  }
}
