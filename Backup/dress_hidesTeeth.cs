// Decompiled with JetBrains decompiler
// Type: dress_hidesTeeth
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
