// Decompiled with JetBrains decompiler
// Type: dress_hidesTeeth
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
