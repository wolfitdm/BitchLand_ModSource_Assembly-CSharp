// Decompiled with JetBrains decompiler
// Type: Girl
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class Girl : Person
{
  [Header("        Girl")]
  public GameObject StrapOn;
  public int HadPregnancies;
  public Transform[] PregnancyBones;
  public Vector3[] PregnancyBones_default;
  public Vector3[] PregnancyBones_preg;
  public float PenisInsideSize;
  public float BellyBulgePercent;
  public Vector3[] BellyBulge_Max;
  public bool PhisicsOnlyOnInSex;
  public bool NoBoobPhysicsOnThisOne;
  public string s_PregnancyParent;
  public Person PregnancyParent;
  public float PregnancyTimeMax;
  public float PregnancyTimer;
  public bool Pregnant;
  public float _PregnancyPercent;
  public ParticleSystem BirthWater;
  public bool WaterHasBroke;
  public float LaborStateTimer;
  public float PostPartumStateTimer;
  public Vector3[] DefaultPos;
  public Vector3[] DefaultRot;
  [Header("        Girl Physics")]
  public Rigidbody[] PhysicsObjs;
  public bool _GirlPhysics;
  public bool _BoobPhysics;
  public Rigidbody[] SimplePhysicsObjs;
  public bool _SimplePhysics;
  public bool _PregBonesSet;
  public Transform BoobsParent;
  public Vector3 BoobRightOrgPos;
  public Vector3 BoobRightOrgRot;
  public Vector3 BoobLeftOrgPos;
  public Vector3 BoobLeftOrgRot;
  public bool BoobsAttatched;
  public bool BoobsAttatched_left;
  public bool BoobsAttatched_right;
  public bool TempDisableConstantPhysics;

  public bool Futa
  {
    get => this.HasPenis;
    set => this.HasPenis = value;
  }

  public float PregnancyPercent
  {
    get => this._PregnancyPercent;
    set
    {
      if ((double) value < 0.0)
        value = 0.0f;
      this.Pregnant = (double) value != 0.0;
      if ((double) this._PregnancyPercent == 0.0 && this.Pregnant)
        ++this.HadPregnancies;
      this._PregnancyPercent = value;
      if (!this.Pregnant)
      {
        this.PregnancyTimer = 0.0f;
        this.PregnancyTimeMax = 0.0f;
        this.States[7] = false;
        this.RuntimeActions.Remove(new Action(this.PregnancyThread));
        this.PregnancyBones[0].localScale = this.PregnancyBones_default[0];
        this.PregnancyBones[0].localPosition = this.PregnancyBones_default[1];
        this.PregnancyBones[1].localScale = this.PregnancyBones_default[2];
        this.PregnancyBones[1].localPosition = this.PregnancyBones_default[3];
      }
      else
      {
        this.PregnancyBones[0].localScale = new Vector3(Main.ValOfP(this.PregnancyBones_preg[0].x, this.PregnancyBones_default[0].x, value), Main.ValOfP(this.PregnancyBones_preg[0].y, this.PregnancyBones_default[0].y, value), Main.ValOfP(this.PregnancyBones_preg[0].z, this.PregnancyBones_default[0].z, value));
        this.PregnancyBones[0].localPosition = new Vector3(Main.ValOfP(this.PregnancyBones_preg[1].x, this.PregnancyBones_default[1].x, value), Main.ValOfP(this.PregnancyBones_preg[1].y, this.PregnancyBones_default[1].y, value), Main.ValOfP(this.PregnancyBones_preg[1].z, this.PregnancyBones_default[1].z, value));
        this.PregnancyBones[1].localScale = new Vector3(Main.ValOfP(this.PregnancyBones_preg[2].x, this.PregnancyBones_default[2].x, value), Main.ValOfP(this.PregnancyBones_preg[2].y, this.PregnancyBones_default[2].y, value), Main.ValOfP(this.PregnancyBones_preg[2].z, this.PregnancyBones_default[2].z, value));
        this.PregnancyBones[1].localPosition = new Vector3(Main.ValOfP(this.PregnancyBones_preg[3].x, this.PregnancyBones_default[3].x, value), Main.ValOfP(this.PregnancyBones_preg[3].y, this.PregnancyBones_default[3].y, value), Main.ValOfP(this.PregnancyBones_preg[3].z, this.PregnancyBones_default[3].z, value));
      }
    }
  }

  public string PregnancyDisplayPercent
  {
    get => ((float) ((double) this._PregnancyPercent / 1.5 * 100.0)).ToString("0.#") + "%";
  }

  public void BecomePreg(bool certain = true, float parentFertility = 1f)
  {
    Debug.Log((object) (this.Name + " BecomePreg()"));
    if (!certain)
    {
      float num = UnityEngine.Random.Range(0.0f, 1f);
      if ((double) this.GetPregnancyChance(this.Fertility, parentFertility) <= (double) num)
        return;
      Debug.Log((object) (this.Name + " Preg Yes"));
    }
    this.PregnancyTimer = 0.1f;
    this.PregnancyTimeMax = 5f;
    this.States[7] = true;
    this.PregnancyPercent = 0.1f;
    if ((UnityEngine.Object) this.HavingSexWith != (UnityEngine.Object) null)
      this.PregnancyParent = this.HavingSexWith;
    this.RuntimeActions.Add(new Action(this.PregnancyThread));
  }

  public void PregnancyThread()
  {
    if ((double) this.PregnancyTimeMax == 0.0)
      return;
    if ((double) this.PregnancyTimer > (double) this.PregnancyTimeMax)
    {
      this.RuntimeActions.Remove(new Action(this.PregnancyThread));
      switch (this.PersonType.ThisType)
      {
        case Person_Type.ESB:
          break;
        case Person_Type.Prisioner:
          break;
        default:
          this.WaterBreak();
          if (this.IsPlayer)
            break;
          this.AddFreeScheduleTask(new Person.ScheduleTask()
          {
            IDName = "GiveBirth",
            ActionPlace = Main.Instance.Clinic,
            OnStartGoing = (Action) (() => this.AddCullBlocker("GoingToClinic")),
            OnArrive = (Action) (() => this.GiveBirth())
          }, true);
          break;
      }
    }
    else
    {
      this.PregnancyTimer += Time.deltaTime / Main.Instance.DayCycle.cycleDuration;
      this.PregnancyPercent = Mathf.Clamp((float) ((double) this.PregnancyTimer / (double) this.PregnancyTimeMax * 1.5), 0.0f, 1.5f);
    }
  }

  public void WaterBreak()
  {
    if (this.WaterHasBroke)
      return;
    this.WaterHasBroke = true;
    this.Orgasm();
    this.LaborStateTimer = 20f;
    if (!this.IsPlayer)
      return;
    this.Anim.runtimeAnimatorController = Main.Instance.PregPlayerController;
  }

  public bool InLabor => (double) this.LaborStateTimer != 0.0;

  public bool InPostPartum => (double) this.PostPartumStateTimer != 0.0;

  public void GiveBirth()
  {
    Debug.Log((object) "GiveBirth()");
    this.WaterHasBroke = false;
    ++this.HadPregnancies;
    this.PregnancyTimer = 0.0f;
    this.PregnancyTimeMax = 5f;
    this.States[7] = false;
    this.RuntimeActions.Remove(new Action(this.PregnancyThread));
    this.PregnancyPercent = 0.0f;
    this.PostPartumStateTimer = 100f;
    if (this.IsPlayer)
      this.Anim.runtimeAnimatorController = Main.Instance.OrgPlayerController;
    this.RemoveCullBlocker("GoingToClinic");
    if (this.CurrentScheduleTask == null || !(this.CurrentScheduleTask.IDName == nameof (GiveBirth)))
      return;
    this.CompleteScheduleTask();
  }

  public void UpdatePregnantBelly()
  {
  }

  public bool GirlPhysics
  {
    get => this._GirlPhysics;
    set => this.ExSetGirlPhysics(value, false);
  }

  public void ExSetGirlPhysics(bool value, bool forRagdoll)
  {
    if (this.PhysicsObjs == null || this.PhysicsObjs.Length == 0)
      return;
    if (!Main.Instance.PhysicsAllEnabled)
    {
      if (Main.Instance.Player.HavingSex)
      {
        if (!Main.Instance.PhysicsSexEnabled)
          value = false;
      }
      else
        value = false;
    }
    this._GirlPhysics = value;
    if (this.CinematicCharacter)
      return;
    if (value)
      this.SimplePhysics = false;
    for (int index = 0; index < this.PhysicsObjs.Length; ++index)
    {
      if ((UnityEngine.Object) this.PhysicsObjs[index] != (UnityEngine.Object) null && this.DefaultPos.Length != 0)
      {
        this.PhysicsObjs[index].transform.localPosition = this.DefaultPos[index];
        this.PhysicsObjs[index].transform.localEulerAngles = this.DefaultRot[index];
        this.PhysicsObjs[index].isKinematic = !forRagdoll && !value;
        this.PhysicsObjs[index].GetComponent<Collider>().enabled = value;
      }
    }
  }

  public bool BoobPhysics
  {
    set
    {
      if (!Main.Instance.PhysicsAllEnabled)
      {
        if (Main.Instance.Player.HavingSex)
        {
          if (!Main.Instance.PhysicsSexEnabled)
            value = false;
        }
        else
          value = false;
      }
      if (!this.CinematicCharacter)
      {
        if (value)
          this.SimplePhysics = false;
        if (this.PhysicsObjs != null && this.PhysicsObjs.Length != 0)
        {
          for (int index = 0; index < 2; ++index)
          {
            this.PhysicsObjs[index].transform.localPosition = this.DefaultPos[index];
            this.PhysicsObjs[index].transform.localEulerAngles = this.DefaultRot[index];
            this.PhysicsObjs[index].isKinematic = !value;
            this.PhysicsObjs[index].GetComponent<Collider>().enabled = value;
          }
        }
      }
      this._BoobPhysics = value;
    }
    get => this._BoobPhysics;
  }

  public bool SimplePhysics
  {
    get => this._SimplePhysics;
    set
    {
      if (!Main.Instance.PhysicsAllEnabled)
      {
        if (Main.Instance.Player.HavingSex)
        {
          if (!Main.Instance.PhysicsSexEnabled)
            value = false;
        }
        else
          value = false;
      }
      if (value)
        this.GirlPhysics = false;
      this._SimplePhysics = value;
      if (this.SimplePhysicsObjs == null)
        return;
      for (int index = 0; index < this.SimplePhysicsObjs.Length; ++index)
      {
        this.SimplePhysicsObjs[index].isKinematic = !value;
        this.SimplePhysicsObjs[index].GetComponent<Collider>().enabled = value;
      }
    }
  }

  public void ResetPhysicsPos()
  {
    if (this.PhysicsObjs == null)
      return;
    for (int index = 0; index < this.PhysicsObjs.Length; ++index)
    {
      this.PhysicsObjs[index].transform.localPosition = this.DefaultPos[index];
      this.PhysicsObjs[index].transform.localEulerAngles = this.DefaultRot[index];
    }
  }

  public void SetPhysicsCol(bool value)
  {
    if (this.PhysicsObjs == null)
      return;
    for (int index = 0; index < this.PhysicsObjs.Length; ++index)
      this.PhysicsObjs[index].GetComponent<Collider>().enabled = value;
  }

  public override void Init()
  {
    if (this.PhysicsObjs != null && this.PhysicsObjs.Length != 0)
    {
      this.DefaultPos = new Vector3[this.PhysicsObjs.Length];
      this.DefaultRot = new Vector3[this.PhysicsObjs.Length];
      for (int index = 0; index < this.PhysicsObjs.Length; ++index)
      {
        if ((UnityEngine.Object) this.PhysicsObjs[index] != (UnityEngine.Object) null)
        {
          this.DefaultPos[index] = this.PhysicsObjs[index].transform.localPosition;
          this.DefaultRot[index] = this.PhysicsObjs[index].transform.localEulerAngles;
        }
      }
      this.GirlPhysics = false;
    }
    if (!this._PregBonesSet)
    {
      this._PregBonesSet = true;
      this.PregnancyBones_default[0] = this.PregnancyBones[0].localScale;
      this.PregnancyBones_default[1] = this.PregnancyBones[0].localPosition;
      this.PregnancyBones_default[2] = this.PregnancyBones[1].localScale;
      this.PregnancyBones_default[3] = this.PregnancyBones[1].localPosition;
    }
    base.Init();
    if (this.NoBoobPhysicsOnThisOne || this.RuntimeActions.Contains(new Action(this.BoobPhysicsOnStill)))
      return;
    this.RuntimeActions.Add(new Action(this.BoobPhysicsOnStill));
  }

  public void AttatchBoobsToHands()
  {
    if (this.BoobsAttatched)
      return;
    this.GirlPhysics = false;
    this.BoobsAttatched_left = true;
    this.BoobsAttatched_right = true;
    this.BoobsAttatched = true;
    if ((UnityEngine.Object) this.BoobsParent == (UnityEngine.Object) null)
    {
      this.BoobsParent = this.BoobRight.parent.parent.parent.parent;
      this.BoobRightOrgPos = this.BoobRight.parent.parent.parent.localPosition;
      this.BoobRightOrgRot = this.BoobRight.parent.parent.parent.localEulerAngles;
      this.BoobLeftOrgPos = this.BoobLeft.parent.parent.parent.localPosition;
      this.BoobLeftOrgRot = this.BoobLeft.parent.parent.parent.localEulerAngles;
    }
    Transform parent1 = this.BoobRight.parent.parent.parent;
    parent1.SetParent(this.RightHandStuff);
    parent1.SetLocalPositionAndRotation(new Vector3(-0.006550935f, -0.104523852f, -0.07387954f), Quaternion.Euler(340.490479f, 42.2566643f, 158.964661f));
    Transform parent2 = this.BoobLeft.parent.parent.parent;
    parent2.SetParent(this.LeftHandStuff);
    parent2.SetLocalPositionAndRotation(new Vector3(0.0123876976f, -0.09113806f, -0.0568391755f), Quaternion.Euler(351.6211f, 308.573761f, 200.7974f));
  }

  public void UnattatchBoobsToHands()
  {
    if (!this.BoobsAttatched)
      return;
    this.BoobsAttatched = false;
    if (this.BoobsAttatched_right)
    {
      Transform parent = this.BoobRight.parent.parent.parent;
      parent.SetParent(this.BoobsParent);
      parent.SetLocalPositionAndRotation(this.BoobRightOrgPos, Quaternion.Euler(this.BoobRightOrgRot));
    }
    if (this.BoobsAttatched_left)
    {
      Transform parent = this.BoobLeft.parent.parent.parent;
      parent.SetParent(this.BoobsParent);
      parent.SetLocalPositionAndRotation(this.BoobLeftOrgPos, Quaternion.Euler(this.BoobLeftOrgRot));
    }
    this.BoobsAttatched_left = false;
    this.BoobsAttatched_right = false;
    this.GirlPhysics = true;
  }

  public void AttatchLeftBoobToLeftHand(Transform hand, Vector3 pos = default (Vector3), Vector3 rot = default (Vector3))
  {
    this.GirlPhysics = false;
    this.BoobsAttatched = true;
    this.BoobsAttatched_left = true;
    if ((UnityEngine.Object) this.BoobsParent == (UnityEngine.Object) null)
    {
      this.BoobsParent = this.BoobRight.parent.parent.parent.parent;
      this.BoobRightOrgPos = this.BoobRight.parent.parent.parent.localPosition;
      this.BoobRightOrgRot = this.BoobRight.parent.parent.parent.localEulerAngles;
      this.BoobLeftOrgPos = this.BoobLeft.parent.parent.parent.localPosition;
      this.BoobLeftOrgRot = this.BoobLeft.parent.parent.parent.localEulerAngles;
    }
    Transform boobLeft = this.BoobLeft;
    boobLeft.SetParent(hand);
    if ((double) pos.x == 0.0)
      pos = new Vector3(0.0123876976f, -0.09113806f, -0.0568391755f);
    if ((double) rot.x == 0.0)
      rot = new Vector3(351.6211f, 308.573761f, 200.7974f);
    boobLeft.SetLocalPositionAndRotation(pos, Quaternion.Euler(rot.x, rot.y, rot.z));
  }

  public void AttatchRightBoobToRightHand(Transform hand)
  {
    this.GirlPhysics = false;
    this.BoobsAttatched_left = false;
    Transform boobRight = this.BoobRight;
    boobRight.SetParent(hand);
    boobRight.SetLocalPositionAndRotation(new Vector3(0.05891816f, -0.08301095f, -0.0136660151f), Quaternion.Euler(328.8972f, 13.846324f, 181.165558f));
  }

  public override void SetHighLod()
  {
    base.SetHighLod();
    if (this.PhysicsObjs == null || this.PhysicsObjs.Length == 0)
      return;
    for (int index = 0; index < this.PhysicsObjs.Length; ++index)
    {
      if ((UnityEngine.Object) this.PhysicsObjs[index] != (UnityEngine.Object) null && (UnityEngine.Object) this.PhysicsObjs[index] != (UnityEngine.Object) null)
        this.PhysicsObjs[index].gameObject.SetActive(true);
    }
  }

  public override void SetLowLod()
  {
    base.SetLowLod();
    if (this.PhysicsObjs == null || this.PhysicsObjs.Length == 0)
      return;
    for (int index = 0; index < this.PhysicsObjs.Length; ++index)
    {
      if ((UnityEngine.Object) this.PhysicsObjs[index] != (UnityEngine.Object) null)
        this.PhysicsObjs[index].gameObject.SetActive(false);
    }
  }

  public override void SetCullLod(bool fullCull = false)
  {
    base.SetCullLod(fullCull);
    if (this.PhysicsObjs == null || this.PhysicsObjs.Length == 0)
      return;
    for (int index = 0; index < this.PhysicsObjs.Length; ++index)
    {
      if ((UnityEngine.Object) this.PhysicsObjs[index] != (UnityEngine.Object) null)
        this.PhysicsObjs[index].gameObject.SetActive(false);
    }
  }

  public void BoobPhysicsOnStill()
  {
    if (this.TempDisableConstantPhysics)
      this.BoobPhysics = false;
    else if (this.NoBoobPhysicsOnThisOne)
    {
      this.RuntimeActions.Remove(new Action(this.BoobPhysicsOnStill));
      this.BoobPhysics = false;
    }
    else
    {
      bool flag = (double) this._Rigidbody.velocity.magnitude < 1.0;
      if (flag == this._BoobPhysics)
        return;
      this.BoobPhysics = flag;
    }
  }

  public float GetPregnancyChance(float motherFertility, float fatherFertility)
  {
    return Mathf.Sqrt(motherFertility * fatherFertility);
  }
}
