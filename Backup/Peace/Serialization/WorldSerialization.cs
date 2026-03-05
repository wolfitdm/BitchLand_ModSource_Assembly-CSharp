// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.WorldSerialization
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

#nullable disable
namespace Peace.Serialization
{
  public static class WorldSerialization
  {
    private const string DEL = "$";

    public static string ToJson(object obj)
    {
      string input = JsonUtility.ToJson(obj);
      Regex regex = new Regex("\"\\$(.*?)\\$\"", RegexOptions.Compiled);
      for (Match match = regex.Match(input); match.Success; match = regex.Match(input))
      {
        string replacement = match.Groups[1].Value.Replace("\\\"", "\"");
        input = regex.Replace(input, replacement, 1);
      }
      return input;
    }

    public static void SerializeList<T>(List<T> from, List<string> to)
    {
      to.Clear();
      foreach (T obj in from)
        to.Add("$" + WorldSerialization.ToJson((object) obj) + "$");
    }
  }
}
