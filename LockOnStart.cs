// Decompiled with JetBrains decompiler
// Type: LockOnStart
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class LockOnStart : MonoBehaviour
{
  public Int_Door DOor;

  private void Start()
  {
    if (!(bool) (Object) this.DOor)
      this.DOor = this.GetComponentInChildren<Int_Door>();
    this.DOor.Locked = true;
  }
}
