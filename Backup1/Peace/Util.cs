// Decompiled with JetBrains decompiler
// Type: Peace.Util
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.IO;
using System.Runtime.InteropServices;

#nullable disable
namespace Peace
{
  public static class Util
  {
    public static string[] ToStringArray(IntPtr arrayPtr, int size)
    {
      IntPtr[] numArray = new IntPtr[size];
      Marshal.Copy(arrayPtr, numArray, 0, size);
      return Util.ToStringArray(numArray);
    }

    public static string[] ToStringArray(IntPtr[] ptrArray)
    {
      string[] stringArray = new string[ptrArray.Length];
      for (int index = 0; index < ptrArray.Length; ++index)
        stringArray[index] = Marshal.PtrToStringAnsi(ptrArray[index]);
      return stringArray;
    }

    public static void DeleteTree(DirectoryInfo path)
    {
      if (!path.Exists)
        return;
      foreach (DirectoryInfo enumerateDirectory in path.EnumerateDirectories())
        Util.DeleteTree(enumerateDirectory);
      path.Delete(true);
    }
  }
}
