// Decompiled with JetBrains decompiler
// Type: int_posterCollectible
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_posterCollectible : Interactible
{
  public int _PosterType;
  public int _PosterIndex;

  public override void Interact(Person person)
  {
    Mis_Acheiv_Posters objectOfType = Object.FindObjectOfType<Mis_Acheiv_Posters>();
    bool flag = false;
    switch (this._PosterType)
    {
      case 0:
        flag = Main.Instance.GameplayMenu.HasPostersBC[this._PosterIndex];
        break;
      case 1:
        flag = Main.Instance.GameplayMenu.HasPostersBCLeg[this._PosterIndex];
        break;
      case 2:
        flag = Main.Instance.GameplayMenu.HasPostersBCBEL[this._PosterIndex];
        break;
      case 3:
        flag = Main.Instance.GameplayMenu.HasPostersBCCap[this._PosterIndex];
        break;
    }
    if (!flag)
    {
      switch (this._PosterType)
      {
        case 0:
          Main.Instance.GameplayMenu.HasPostersBC[this._PosterIndex] = true;
          objectOfType.UpdateAcheiv1();
          break;
        case 1:
          Main.Instance.GameplayMenu.HasPostersBCLeg[this._PosterIndex] = true;
          objectOfType.UpdateAcheiv2();
          break;
        case 2:
          Main.Instance.GameplayMenu.HasPostersBCBEL[this._PosterIndex] = true;
          objectOfType.UpdateAcheiv3();
          break;
        case 3:
          Main.Instance.GameplayMenu.HasPostersBCCap[this._PosterIndex] = true;
          objectOfType.UpdateAcheiv4();
          break;
      }
    }
    Object.Destroy((Object) this.GetComponent<Collider>());
    Object.Destroy((Object) this);
  }
}
