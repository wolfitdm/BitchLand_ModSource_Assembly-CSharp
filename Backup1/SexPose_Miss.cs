// Decompiled with JetBrains decompiler
// Type: SexPose_Miss
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class SexPose_Miss : SexPose
{
  public Vector3 P1Pos;
  public Vector3 P1Rot;
  public Vector3 P2Pos;
  public Vector3 P2Rot;
  public Vector3 ppAdd;
  public Vector3 pp2Add;
  public bool ppinsidezero;
  public bool NoPpGuide;
  public bool AlignPPMouth;
  public bool InterpolatePPMouth;
  public Vector3 Interpolate09;
  public Vector3 Interpolate10;
  private Transform strapon;
  public string[] BlendShapes;
  public int[] BlendShapesValues;
  public string[] EyeMovementSpots;
  public string[] MaleEyeMovementSpots;
  private Transform[] _EyeMovementSpots;
  public bool DisableEyeLook;
  public bool NormalEyeLook;
  public bool DefaultSetMoans;
  public AudioClip[] OnTriggerSounds;
  public float SoundTrigger;
  public bool HasMoans;
  public SexPose_IKSetting[] UsingIKs;
  public SexPose_IKSetting[] UsingIKs2;
  public SexPose_IKSetting[] DISABLEDFORLATER_UsingIKs;
  private float _EyeTimer;
  private bool _PlayedSound;
  private float _moanTimer;

  public override void SexPoseStart()
  {
    base.SexPoseStart();
    if (!this.DefaultSetMoans)
      this.OnTriggerSounds = !(this.Person2 is Girl) ? Main.Instance.MaleMoans : (this.ThisScene.ThisSexStateType != SexStateType.Sleeping ? Main.Instance.FemaleMoans : Main.Instance.FemaleSleepingMoans);
    this.Person2.PersonAudio.pitch = this.Person2.VoicePitch;
    if (this.EyeMovementSpots.Length != 0)
    {
      this._EyeMovementSpots = new Transform[this.EyeMovementSpots.Length];
      if (this.Person1 is Girl)
      {
        for (int index = 0; index < this.EyeMovementSpots.Length; ++index)
        {
          this._EyeMovementSpots[index] = this.Person1.Anim.transform.Find(this.EyeMovementSpots[index]);
          this._EyeTimer = 3f;
        }
      }
      else
      {
        for (int index = 0; index < this.MaleEyeMovementSpots.Length; ++index)
        {
          this._EyeMovementSpots[index] = this.Person1.Anim.transform.Find(this.MaleEyeMovementSpots[index]);
          this._EyeTimer = 3f;
        }
      }
      this.Person2.LookAtPlayer.playerTransform = this._EyeMovementSpots[0];
    }
    if (this.DisableEyeLook)
      this.Person2.LookAtPlayer.Disable = true;
    if (this.NormalEyeLook)
      this.Person2.LookAtPlayer.OnlyEyes = false;
    this.enabled = true;
    this.PosiotinPerson();
    Main.RunInNextFrame(new Action(this.PosiotinPerson));
    Main.RunInNextFrame(new Action(this.PosiotinPerson), 5);
    this.ThisScene.ErectPenisFor(this.Person1);
    this.ThisScene.FlacidPenisFor(this.Person2);
    this.ThisScene.FlacidPenisFor(this.Person3);
    switch (this.HoleGoingInto)
    {
      case 0:
      case 1:
        Main.Instance.SexScene.ToggleVaginalAnal.interactable = true;
        this.HoleGoingInto = Main.Instance.SexScene.ToggleVaginalAnal.isOn ? 0 : 1;
        break;
      case 2:
        Main.Instance.SexScene.ToggleVaginalAnal.interactable = false;
        if (this.AlignPPMouth)
        {
          SexPose_Miss.AdjustCharacterPosition(this.Person2.transform, this.Person1.Penis.transform, this.Person2.Holes[2]);
          break;
        }
        break;
    }
    this.GoIntoHole();
    if ((UnityEngine.Object) this.Person1.LeftArmIK != (UnityEngine.Object) null)
    {
      for (int index = 0; index < this.UsingIKs.Length; ++index)
      {
        Transform p = this.Person2.transform.Find(this.UsingIKs[index].AttatchTo);
        if ((UnityEngine.Object) p == (UnityEngine.Object) null)
          p = this.Person2.transform.Find(this.UsingIKs[index].AttatchTo.Replace("Armature/", ""));
        if ((UnityEngine.Object) p != (UnityEngine.Object) null)
        {
          switch (this.UsingIKs[index].Limb)
          {
            case e_IKLimb.LeftArm:
              this.Person1.LeftArmIK.enabled = true;
              this.Person1.LeftArmIK.Target.SetParent(p);
              this.Person1.LeftArmIK.Target.localPosition = this.UsingIKs[index].Pos;
              this.Person1.LeftArmIK.Target.localEulerAngles = this.UsingIKs[index].Rot;
              this.Person1.LeftArmIK.Pole.localPosition = this.UsingIKs[index].PolePos;
              continue;
            case e_IKLimb.RightArm:
              this.Person1.RightArmIK.enabled = true;
              this.Person1.RightArmIK.Target.SetParent(p);
              this.Person1.RightArmIK.Target.localPosition = this.UsingIKs[index].Pos;
              this.Person1.RightArmIK.Target.localEulerAngles = this.UsingIKs[index].Rot;
              this.Person1.RightArmIK.Pole.localPosition = this.UsingIKs[index].PolePos;
              continue;
            case e_IKLimb.LeftLeg:
              this.Person1.LeftLegIK.enabled = true;
              this.Person1.LeftLegIK.Target.SetParent(p);
              this.Person1.LeftLegIK.Target.localPosition = this.UsingIKs[index].Pos;
              this.Person1.LeftLegIK.Target.localEulerAngles = this.UsingIKs[index].Rot;
              this.Person1.LeftLegIK.Pole.localPosition = this.UsingIKs[index].PolePos;
              continue;
            case e_IKLimb.RightLeg:
              this.Person1.RightLegIK.enabled = true;
              this.Person1.RightLegIK.Target.SetParent(p);
              this.Person1.RightLegIK.Target.localPosition = this.UsingIKs[index].Pos;
              this.Person1.RightLegIK.Target.localEulerAngles = this.UsingIKs[index].Rot;
              this.Person1.RightLegIK.Pole.localPosition = this.UsingIKs[index].PolePos;
              continue;
            default:
              continue;
          }
        }
      }
    }
    if ((UnityEngine.Object) this.Person2.LeftArmIK != (UnityEngine.Object) null)
    {
      for (int index = 0; index < this.UsingIKs2.Length; ++index)
      {
        Transform p = this.Person1.transform.Find(this.UsingIKs2[index].AttatchTo);
        if ((UnityEngine.Object) p == (UnityEngine.Object) null)
          p = this.Person1.transform.Find(this.UsingIKs2[index].AttatchTo.Replace("Armature/", ""));
        if ((UnityEngine.Object) p != (UnityEngine.Object) null)
        {
          switch (this.UsingIKs2[index].Limb)
          {
            case e_IKLimb.LeftArm:
              this.Person2.LeftArmIK.enabled = true;
              this.Person2.LeftArmIK.Target.SetParent(p);
              this.Person2.LeftArmIK.Target.localPosition = this.UsingIKs2[index].Pos;
              this.Person2.LeftArmIK.Target.localEulerAngles = this.UsingIKs2[index].Rot;
              this.Person2.LeftArmIK.Pole.localPosition = this.UsingIKs2[index].PolePos;
              continue;
            case e_IKLimb.RightArm:
              this.Person2.RightArmIK.enabled = true;
              this.Person2.RightArmIK.Target.SetParent(p);
              this.Person2.RightArmIK.Target.localPosition = this.UsingIKs2[index].Pos;
              this.Person2.RightArmIK.Target.localEulerAngles = this.UsingIKs2[index].Rot;
              this.Person2.RightArmIK.Pole.localPosition = this.UsingIKs2[index].PolePos;
              continue;
            case e_IKLimb.LeftLeg:
              this.Person2.LeftLegIK.enabled = true;
              this.Person2.LeftLegIK.Target.SetParent(p);
              this.Person2.LeftLegIK.Target.localPosition = this.UsingIKs2[index].Pos;
              this.Person2.LeftLegIK.Target.localEulerAngles = this.UsingIKs2[index].Rot;
              this.Person2.LeftLegIK.Pole.localPosition = this.UsingIKs2[index].PolePos;
              continue;
            case e_IKLimb.RightLeg:
              this.Person2.RightLegIK.enabled = true;
              this.Person2.RightLegIK.Target.SetParent(p);
              this.Person2.RightLegIK.Target.localPosition = this.UsingIKs2[index].Pos;
              this.Person2.RightLegIK.Target.localEulerAngles = this.UsingIKs2[index].Rot;
              this.Person2.RightLegIK.Pole.localPosition = this.UsingIKs2[index].PolePos;
              continue;
            default:
              continue;
          }
        }
      }
    }
    for (int index = 0; index < this.BlendShapes.Length; ++index)
      this.Person2.BlendShape(this.BlendShapes[index], (float) this.BlendShapesValues[index]);
  }

  public override void SexPoseEnd()
  {
    for (int index = 0; index < this.BlendShapes.Length; ++index)
      this.Person2.BlendShape(this.BlendShapes[index], 0.0f);
    int length = this.EyeMovementSpots.Length;
    if ((UnityEngine.Object) this.Person1.LeftArmIK != (UnityEngine.Object) null)
    {
      this.Person1.LeftArmIK.enabled = false;
      this.Person1.LeftArmIK.Target.SetParent(this.Person1.LeftArmIK.Pole.parent);
      this.Person1.RightArmIK.enabled = false;
      this.Person1.RightArmIK.Target.SetParent(this.Person1.LeftArmIK.Pole.parent);
      this.Person1.LeftLegIK.enabled = false;
      this.Person1.LeftLegIK.Target.SetParent(this.Person1.LeftArmIK.Pole.parent);
      this.Person1.RightLegIK.enabled = false;
      this.Person1.RightLegIK.Target.SetParent(this.Person1.LeftArmIK.Pole.parent);
    }
    if ((UnityEngine.Object) this.Person2.LeftArmIK != (UnityEngine.Object) null)
    {
      this.Person2.LeftArmIK.enabled = false;
      this.Person2.LeftArmIK.Target.SetParent(this.Person2.LeftArmIK.Pole.parent);
      this.Person2.RightArmIK.enabled = false;
      this.Person2.RightArmIK.Target.SetParent(this.Person2.LeftArmIK.Pole.parent);
      this.Person2.LeftLegIK.enabled = false;
      this.Person2.LeftLegIK.Target.SetParent(this.Person2.LeftArmIK.Pole.parent);
      this.Person2.RightLegIK.enabled = false;
      this.Person2.RightLegIK.Target.SetParent(this.Person2.LeftArmIK.Pole.parent);
    }
    if (this.DisableEyeLook)
      this.Person2.LookAtPlayer.Disable = false;
    this.enabled = false;
    this.Person1.PenisErect = true;
    base.SexPoseEnd();
  }

  public void PosiotinPerson()
  {
    this.Person1.transform.SetLocalPositionAndRotation(this.P1Pos, Quaternion.Euler(this.P1Rot));
    if (this.InterpolatePPMouth)
      this.P2Pos = new Vector3(this.P2Pos.x, this.P2Pos.y, this.InterpolateY(this.Person2.transform.localScale.y));
    if ((UnityEngine.Object) this.Person1.transform != (UnityEngine.Object) this.Person1.Anim.transform)
      this.Person1.Anim.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
    this.Person2.transform.SetLocalPositionAndRotation(this.P2Pos, Quaternion.Euler(this.P2Rot));
    if ((UnityEngine.Object) this.Person2.transform != (UnityEngine.Object) this.Person2.Anim.transform)
      this.Person2.Anim.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
    if (!this.AlignPPMouth)
      return;
    SexPose_Miss.AdjustCharacterPosition(this.Person2.transform, this.Person1.Penis.transform, this.Person2.Holes[2]);
  }

  public void LateUpdate()
  {
    if ((UnityEngine.Object) this.Person1 == (UnityEngine.Object) null || (UnityEngine.Object) this.ThisScene == (UnityEngine.Object) null)
      return;
    if (this.HasMoans && Main.Instance.MoansEnabled)
    {
      double num = (double) this.Person2.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1.0;
      if (num >= (double) this.SoundTrigger && !this._PlayedSound)
      {
        this._PlayedSound = true;
        this.TriggerSound();
      }
      if (num < (double) this.SoundTrigger)
        this._PlayedSound = false;
    }
    if (this.EyeMovementSpots.Length != 0)
    {
      this._EyeTimer -= Time.deltaTime;
      if ((double) this._EyeTimer < 0.0)
      {
        this._EyeTimer = UnityEngine.Random.Range(2f, 3f);
        this.Person2.LookAtPlayer.playerTransform = this._EyeMovementSpots[UnityEngine.Random.Range(0, this._EyeMovementSpots.Length)];
      }
    }
    if (this.NoPpGuide)
      return;
    this.Person1.PenisBones[1].LookAt(this.Person2.Holes[this.HoleGoingInto]);
    this.Person1.PenisBones[1].localEulerAngles += this.ppAdd;
    if (!((UnityEngine.Object) this.strapon != (UnityEngine.Object) null))
      return;
    switch (this.HoleGoingInto)
    {
      case 0:
      case 1:
        this.strapon.LookAt(this.Person2.Holes[this.HoleGoingInto]);
        this.strapon.localEulerAngles += this.pp2Add;
        break;
      case 2:
        this.strapon.LookAt(this.Person2.Holes[3]);
        this.strapon.localEulerAngles += this.pp2Add;
        break;
    }
  }

  public override void GoIntoHole()
  {
    base.GoIntoHole();
    int num = this.Person1.HasPenis ? 1 : 0;
    this.strapon = (Transform) null;
    switch (this.HoleGoingInto)
    {
      case 0:
      case 1:
        this.Person1.PenisBones[3].SetParent(this.Person2.Holes[this.HoleGoingInto]);
        this.Person1.PenisBones[3].localPosition = Vector3.zero;
        this.Person1.PenisBones[3].localEulerAngles = this.pp2Add;
        if (this.ppinsidezero)
          this.Person1.PenisBones[3].localScale = Vector3.zero;
        this.Person1.PenisBones[4].localScale = Vector3.zero;
        break;
      case 2:
        if ((double) this.Person1.Penis.transform.localScale.x > 2.5)
        {
          this.Blowjob_SetupLargePenis();
          break;
        }
        this.Blowjob_SetupMedPenis();
        break;
    }
  }

  public void Blowjob_SetupLargePenis()
  {
    this.ppAdd = new Vector3(107f, 0.0f, 0.0f);
    this.Person1.PenisBones[3].SetParent(this.Person2.Holes[3]);
    this.Person1.PenisBones[3].localPosition = Vector3.zero;
    this.Person1.PenisBones[3].localEulerAngles = Vector3.zero;
    this.Person1.PenisBones[4].localScale = Vector3.zero;
  }

  public void Blowjob_SetupMedPenis()
  {
    this.ppAdd = new Vector3(100f, 0.0f, 0.0f);
    this.Person1.PenisBones[3].SetParent(this.Person2.Holes[3]);
    this.Person1.PenisBones[3].localPosition = Vector3.zero;
    this.Person1.PenisBones[3].localEulerAngles = Vector3.zero;
    this.Person1.PenisBones[4].localScale = Vector3.zero;
  }

  public static void AdjustCharacterPosition(
    Transform character2,
    Transform torso1,
    Transform torso2)
  {
    Vector3 vector3 = new Vector3(0.0f, torso1.position.y - torso2.position.y + 0.01f, 0.0f);
    character2.position += vector3;
  }

  public float InterpolateY(float person2Scale)
  {
    float num1 = 0.9f;
    float z1 = this.Interpolate09.z;
    float num2 = 1f;
    float z2 = this.Interpolate10.z;
    return z1 + (float) (((double) z2 - (double) z1) * (((double) person2Scale - (double) num1) / ((double) num2 - (double) num1)));
  }

  public void TriggerSound()
  {
    AudioClip onTriggerSound = this.OnTriggerSounds[UnityEngine.Random.Range(0, this.OnTriggerSounds.Length)];
    if (!((UnityEngine.Object) onTriggerSound != (UnityEngine.Object) null))
      return;
    this.Person2.PersonAudio.PlayOneShot(onTriggerSound);
  }

  public void GetIKValues()
  {
    if ((UnityEngine.Object) this.Person1 == (UnityEngine.Object) null)
      return;
    for (int index = 0; index < this.UsingIKs.Length; ++index)
    {
      switch (this.UsingIKs[index].Limb)
      {
        case e_IKLimb.LeftArm:
          this.UsingIKs[index].PolePos = this.Person1.LeftArmIK.Pole.localPosition;
          this.UsingIKs[index].Pos = this.Person1.LeftArmIK.Target.localPosition;
          this.UsingIKs[index].Rot = this.Person1.LeftArmIK.Target.localEulerAngles;
          break;
        case e_IKLimb.RightArm:
          this.UsingIKs[index].PolePos = this.Person1.RightArmIK.Pole.localPosition;
          this.UsingIKs[index].Pos = this.Person1.RightArmIK.Target.localPosition;
          this.UsingIKs[index].Rot = this.Person1.RightArmIK.Target.localEulerAngles;
          break;
        case e_IKLimb.LeftLeg:
          this.UsingIKs[index].PolePos = this.Person1.LeftLegIK.Pole.localPosition;
          this.UsingIKs[index].Pos = this.Person1.LeftLegIK.Target.localPosition;
          this.UsingIKs[index].Rot = this.Person1.LeftLegIK.Target.localEulerAngles;
          break;
        case e_IKLimb.RightLeg:
          this.UsingIKs[index].PolePos = this.Person1.RightLegIK.Pole.localPosition;
          this.UsingIKs[index].Pos = this.Person1.RightLegIK.Target.localPosition;
          this.UsingIKs[index].Rot = this.Person1.RightLegIK.Target.localEulerAngles;
          break;
      }
    }
  }

  public void GetIKValues2()
  {
    if ((UnityEngine.Object) this.Person2 == (UnityEngine.Object) null)
      return;
    for (int index = 0; index < this.UsingIKs2.Length; ++index)
    {
      switch (this.UsingIKs2[index].Limb)
      {
        case e_IKLimb.LeftArm:
          this.UsingIKs2[index].PolePos = this.Person2.LeftArmIK.Pole.localPosition;
          this.UsingIKs2[index].Pos = this.Person2.LeftArmIK.Target.localPosition;
          this.UsingIKs2[index].Rot = this.Person2.LeftArmIK.Target.localEulerAngles;
          break;
        case e_IKLimb.RightArm:
          this.UsingIKs2[index].PolePos = this.Person2.RightArmIK.Pole.localPosition;
          this.UsingIKs2[index].Pos = this.Person2.RightArmIK.Target.localPosition;
          this.UsingIKs2[index].Rot = this.Person2.RightArmIK.Target.localEulerAngles;
          break;
        case e_IKLimb.LeftLeg:
          this.UsingIKs2[index].PolePos = this.Person2.LeftLegIK.Pole.localPosition;
          this.UsingIKs2[index].Pos = this.Person2.LeftLegIK.Target.localPosition;
          this.UsingIKs2[index].Rot = this.Person2.LeftLegIK.Target.localEulerAngles;
          break;
        case e_IKLimb.RightLeg:
          this.UsingIKs2[index].PolePos = this.Person2.RightLegIK.Pole.localPosition;
          this.UsingIKs2[index].Pos = this.Person2.RightLegIK.Target.localPosition;
          this.UsingIKs2[index].Rot = this.Person2.RightLegIK.Target.localEulerAngles;
          break;
      }
    }
  }
}
