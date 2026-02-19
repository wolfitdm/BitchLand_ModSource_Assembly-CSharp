// Decompiled with JetBrains decompiler
// Type: bl_AddOn
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class bl_AddOn
{
  public static void PlaceAt(this Transform tr, Transform Spot)
  {
    tr.SetPositionAndRotation(Spot.position, Spot.rotation);
  }

  public static void PlaceAt(this Transform tr, GameObject Spot)
  {
    tr.SetPositionAndRotation(Spot.transform.position, Spot.transform.rotation);
  }

  public static void PlaceAt(this GameObject tr, Transform Spot)
  {
    tr.transform.SetPositionAndRotation(Spot.position, Spot.rotation);
  }

  public static void PlaceAt(this GameObject tr, GameObject Spot)
  {
    tr.transform.SetPositionAndRotation(Spot.transform.position, Spot.transform.rotation);
  }

  public static void PlaceAt(this Person tr, Transform Spot)
  {
    tr.transform.SetPositionAndRotation(Spot.position, Spot.rotation);
  }

  public static void PlaceAt(this Person tr, Vector3 Spot)
  {
    tr.transform.SetPositionAndRotation(Spot, Quaternion.identity);
  }

  public static List<T> ToList<T>(this T[] stuff)
  {
    List<T> list = new List<T>();
    list.AddRange((IEnumerable<T>) stuff);
    return list;
  }

  public static List<string> ToNameList(this Object[] stuff)
  {
    List<string> nameList = new List<string>();
    for (int index = 0; index < stuff.Length; ++index)
      nameList.Add(stuff[index].name);
    return nameList;
  }

  public static void Log(this string str)
  {
  }

  public static void LogError(this string str)
  {
  }
}
