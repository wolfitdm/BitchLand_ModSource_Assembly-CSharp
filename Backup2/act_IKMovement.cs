// Decompiled with JetBrains decompiler
// Type: act_IKMovement
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class act_IKMovement : ThingToDo
{
  [Header("   IK")]
  public bool DoLeftLeg;
  public Vector3 LeftLegPos;
  public Vector3 LeftLegRot;
  public bool DoRightLeg;
  public Vector3 RightLegPos;
  public Vector3 RightLegRot;
  public bool DoLeftArm;
  public Vector3 LeftArmPos;
  public Vector3 LeftArmRot;
  public bool DoRightArm;
  public Vector3 RightArmPos;
  public Vector3 RightArmRot;
  public bool DoHead;
  public Vector3 HeadPos;
  public Vector3 HeadRot;
  [Header("   Temp")]
  public float MaxPos;
  public float MinPos;
  public float Speed = 1f;
  private bool _Increasing;

  public override void StartDoing()
  {
    base.StartDoing();
    this.ThisPerson.Anim.enabled = false;
    if (this.DoLeftLeg)
      this.ThisPerson.LeftLegIK.enabled = true;
    if (this.DoRightLeg)
      this.ThisPerson.RightLegIK.enabled = true;
    if (this.DoLeftArm)
      this.ThisPerson.LeftArmIK.enabled = true;
    if (this.DoRightArm)
      this.ThisPerson.RightArmIK.enabled = true;
    if (!this.DoHead)
      return;
    this.ThisPerson.HeadIK.enabled = true;
  }

  public override void Update()
  {
    base.Update();
    if (this._Increasing)
    {
      this.ThisPerson.transform.localPosition += new Vector3(0.0f, Time.deltaTime * this.Speed, 0.0f);
      if ((double) this.ThisPerson.transform.localPosition.y <= (double) this.MaxPos)
        return;
      this._Increasing = false;
    }
    else
    {
      this.ThisPerson.transform.localPosition -= new Vector3(0.0f, Time.deltaTime * this.Speed, 0.0f);
      if ((double) this.ThisPerson.transform.localPosition.y >= (double) this.MinPos)
        return;
      this._Increasing = true;
    }
  }
}
