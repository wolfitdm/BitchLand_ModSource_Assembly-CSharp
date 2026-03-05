// Decompiled with JetBrains decompiler
// Type: dress_ForcedVib
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
