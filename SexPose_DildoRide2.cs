// Decompiled with JetBrains decompiler
// Type: SexPose_DildoRide2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class SexPose_DildoRide2 : SexPose
{
  public Vector3 Pos;
  public Vector3 Rot;

  public override void SexPoseStart()
  {
    base.SexPoseStart();
    this.RefreshDildo();
    Main.RunInNextFrame(new Action(this.PosiotinPerson));
    Main.RunInNextFrame(new Action(this.PosiotinPerson), 5);
  }

  public override void RefreshDildo()
  {
    base.RefreshDildo();
    this.ThisDildo.RootObj.transform.SetParent(this.ThisScene.SpawnedSexSceneStructure);
    this.ThisDildo.RootObj.transform.SetLocalPositionAndRotation(this.Pos, Quaternion.Euler(this.Rot));
  }

  public void PosiotinPerson()
  {
    this.Person1.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
    if (!((UnityEngine.Object) this.Person1.transform != (UnityEngine.Object) this.Person1.Anim.transform))
      return;
    this.Person1.Anim.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
  }
}
