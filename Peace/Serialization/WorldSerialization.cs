// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.WorldSerialization
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

#nullable disable
namespace Peace.Serialization;

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
      to.Add($"${WorldSerialization.ToJson((object) obj)}$");
  }
}
