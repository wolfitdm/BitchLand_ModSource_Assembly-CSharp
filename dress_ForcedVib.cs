// Decompiled with JetBrains decompiler
// Type: dress_ForcedVib
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
