// Decompiled with JetBrains decompiler
// Type: dress_hidesTeeth
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class dress_hidesTeeth : Dressable
{
  public override bool Equipped
  {
    get => base.Equipped;
    set
    {
      base.Equipped = value;
      if (!(this.PersonEquipped is Girl))
        return;
      try
      {
        if (value)
        {
          Material[] destinationArray = new Material[6];
          Array.Copy((Array) this.PersonEquipped.MainBody.materials, (Array) destinationArray, 6);
          this.PersonEquipped.MainBody.materials = destinationArray;
        }
        else
        {
          Material[] destinationArray = new Material[7];
          Array.Copy((Array) this.PersonEquipped.MainBody.materials, (Array) destinationArray, 6);
          destinationArray[6] = Main.Instance.MatTeeth;
          this.PersonEquipped.MainBody.materials = destinationArray;
        }
      }
      catch
      {
      }
    }
  }
}
