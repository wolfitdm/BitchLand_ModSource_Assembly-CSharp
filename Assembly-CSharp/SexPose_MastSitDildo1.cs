// Decompiled with JetBrains decompiler
// Type: SexPose_MastSitDildo1
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SexPose_MastSitDildo1 : SexPose
{
  public bool DefaultDildoPos;
  public Vector3 DildoPos;
  public Vector3 DildoRot;
  public bool AttatchLeftBoob;
  public Vector3 LeftBoobPos;
  public Vector3 LeftBoobRot;

  public override void SexPoseStart()
  {
    base.SexPoseStart();
    this.RefreshDildo();
    if (!this.AttatchLeftBoob || !(this.Person1 is Girl))
      return;
    ((Girl) this.Person1).AttatchLeftBoobToLeftHand(this.Person1.LeftHandStuff);
  }

  public override void RefreshDildo()
  {
    base.RefreshDildo();
    if (this.DefaultDildoPos)
      this.Person1.PutOnHand(this.ThisDildo.RootObj.gameObject, this.ThisDildo.BackPos, this.ThisDildo.BackRot);
    else
      this.Person1.PutOnHand(this.ThisDildo.RootObj.gameObject, this.DildoPos, this.DildoRot);
  }

  public override void SexPoseEnd()
  {
    if (this.AttatchLeftBoob && this.Person1 is Girl)
      ((Girl) this.Person1).UnattatchBoobsToHands();
    base.SexPoseEnd();
  }
}
