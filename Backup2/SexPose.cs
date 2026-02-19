// Decompiled with JetBrains decompiler
// Type: SexPose
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SexPose : MonoBehaviour
{
  public string Name;
  public string Anim;
  public string Partner1Anim;
  public string Partner2Anim;
  public e_BlendShapes Person1FaceShapes;
  public e_BlendShapes Person2FaceShapes;
  public e_BlendShapes Person3FaceShapes;
  public bool PermanentFaceBlendshapes;
  public bool P1_noArousal;
  public bool P2_noArousal;
  public bool P3_noArousal;
  public bool ScatPose;
  public int PersonGettingShat;
  public int LeadingPerson;
  [Header("Runtime")]
  public Person Person1;
  public Person Person2;
  public Person Person3;
  public int_dildo ThisDildo;
  public int HoleGoingInto;
  public SpawnedSexScene ThisScene;
  public int TiredSexPose;
  public bool HasShlicks;
  public float ShlickTrigger;
  public bool NoBulge;
  public bool ReversedBulge;

  public virtual void SexPoseStart()
  {
    switch (this.LeadingPerson)
    {
      case 1:
        this.ThisScene.Leading = this.Person1;
        break;
      case 2:
        this.ThisScene.Leading = this.Person2;
        break;
      case 3:
        this.ThisScene.Leading = this.Person3;
        break;
    }
    if (this.Person1 is Girl && (!(this.Person1 as Girl).Pregnant || (double) (this.Person1 as Girl)._PregnancyPercent <= 0.20000000298023224))
    {
      (this.Person1 as Girl).PregnancyBones[0].localScale = (this.Person1 as Girl).PregnancyBones_default[0];
      (this.Person1 as Girl).PregnancyBones[0].localPosition = (this.Person1 as Girl).PregnancyBones_default[1];
    }
    this.Person1.Anim.Play(this.Anim);
    this.Person1.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
    this.Person1.Anim.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
    this.Person1.ResetAllShapes();
    this.Person1.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[(int) this.Person1FaceShapes]);
    if ((double) this.Person1.Energy < 10.0)
      this.Person1.BlendShape("e01_close", 100f);
    this.Person1.SexPoseHasNoArousalIncrease = this.P1_noArousal;
    if ((Object) this.Person2 != (Object) null)
    {
      if (this.Person2 is Girl && (!(this.Person2 as Girl).Pregnant || (double) (this.Person2 as Girl)._PregnancyPercent <= 0.20000000298023224))
      {
        (this.Person2 as Girl).PregnancyBones[0].localScale = (this.Person2 as Girl).PregnancyBones_default[0];
        (this.Person2 as Girl).PregnancyBones[0].localPosition = (this.Person2 as Girl).PregnancyBones_default[1];
      }
      this.Person2.ResetAllShapes();
      this.Person2.Anim.Play(this.Partner1Anim);
      this.Person2.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[(int) this.Person2FaceShapes]);
      if ((double) this.Person2.Energy < 10.0)
        this.Person2.BlendShape("e01_close", 100f);
      this.Person2.SexPoseHasNoArousalIncrease = this.P2_noArousal;
    }
    if ((Object) this.Person3 != (Object) null)
    {
      this.Person3.ResetAllShapes();
      this.Person3.Anim.Play(this.Partner2Anim);
      this.Person3.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[(int) this.Person3FaceShapes]);
      if ((double) this.Person3.Energy < 10.0)
        this.Person3.BlendShape("e01_close", 100f);
      this.Person3.SexPoseHasNoArousalIncrease = this.P3_noArousal;
    }
    if (this.PermanentFaceBlendshapes)
      return;
    this.ThisScene.FaceExpressionOverwrite();
  }

  public virtual void SexPoseEnd()
  {
  }

  public virtual void RefreshDildo() => this.ThisDildo = this.ThisScene.CurrentDildo;

  public virtual void GoIntoHole()
  {
  }
}
