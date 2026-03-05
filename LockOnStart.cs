// Decompiled with JetBrains decompiler
// Type: LockOnStart
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
