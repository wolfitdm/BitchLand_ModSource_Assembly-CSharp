// Decompiled with JetBrains decompiler
// Type: dress_hidesTeeth
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
