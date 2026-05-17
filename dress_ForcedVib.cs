// Decompiled with JetBrains decompiler
// Type: dress_ForcedVib
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class dress_ForcedVib : Dressable
{
  public bool VibEnabled = true;
  public ShakerVib[] VibEngines;
  public float ArousalIncrease = 1f / 1000f;

  public void LateUpdate()
  {
    if (this.VibEnabled)
    {
      if (this.Equipped && (Object) this.PersonEquipped != (Object) null)
        this.PersonEquipped.Arousal += this.ArousalIncrease;
      if (!Input.GetKeyUp(KeyCode.N))
        return;
      this.VibEnabled = false;
      for (int index = 0; index < this.VibEngines.Length; ++index)
        this.VibEngines[index].enabled = false;
    }
    else
    {
      if (!Input.GetKeyUp(KeyCode.N))
        return;
      this.VibEnabled = true;
      for (int index = 0; index < this.VibEngines.Length; ++index)
        this.VibEngines[index].enabled = true;
    }
  }
}
