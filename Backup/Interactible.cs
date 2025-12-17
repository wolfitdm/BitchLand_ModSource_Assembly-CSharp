// Decompiled with JetBrains decompiler
// Type: Interactible
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

#nullable disable
public class Interactible : SaveableBehaviour
{
  public bool _CanInteract = true;
  public bool ScatInteractible;
  public bool NPCCanUseInFollow;
  public bool SetInteracting = true;
  public List<e_Fetish> OffersFetishes;
  public List<Personality_Type> OffersPersonalities;
  public bool RunTo;
  public GenderType DefaultGenderOnly;
  public GenderType GenderOnly;
  public bool UnparentOnStart;
  public float CarryWeight;
  public bool NPCCanBeInteractedWhileUsing;
  public string PrefabName;
  public bool CanLeave = true;
  public Person PersonGoingToUse;
  public string[] RequiredPerks;
  public Transform PivotSpot;
  public bool intDoIK;
  public SexPose_IKSetting[] intUsingIKs;
  public Transform[] ReferenceSpots;
  public List<string> InteractBlockers = new List<string>();
  public bool PlayerCanInteract = true;
  public int DefaultInteractIcon;
  public int InteractIcon;
  public string InteractText;
  public string[] _InteractTexts;
  public Person InteractingPerson;
  public GameObject RootObj;
  public MeshRenderer[] DisableOnStart;
  public GameObject[] ActivateOnInteract;
  public GameObject[] DeactivateOnInteract;
  public Behaviour[] EnableOnInteract;
  public Behaviour[] DisableOnInteract;
  public MonoBehaviour[] ScriptToRun_OnInteract;
  public string[] ScriptFunctionToRun_OnInteract;
  public MonoBehaviour[] ScriptToRun_OnStopInteract;
  public string[] ScriptFunctionToRun_OnStopInteract;
  public Action NPCOnFinishInteract;
  public bool AutomatedStopInteraction;
  public float DoForSeconds;
  public bool PlaceNPCOnInteract = true;
  public bool PlacePlayerOnLeave;
  public Transform NavMeshInteractSpot;
  public bool DisableHeadRotate;
  public Transform HeadRotateTo;
  public bool[] _AvailableUses;
  public int _SelectedUseIndex;
  public Main._runinseconds _RunningForSecs;
  [Header("Despawn")]
  public bool Despawnable;
  public float DespawnTimerMaxHere;
  public float DespawnTimer;
  public float DespawnTimerChecker;
  public bool DoDistanceCheck = true;
  public bool _InsideSafeHouse;

  public bool CanInteract
  {
    set => this._CanInteract = value;
    get => (Main.Instance.ScatContent || !this.ScatInteractible) && this._CanInteract;
  }

  public bool BeingUsed => this.HasBlocker("Interacting");

  public bool AnyoneGoingToIt
  {
    get
    {
      return !((UnityEngine.Object) this.PersonGoingToUse == (UnityEngine.Object) null) && !this.PersonGoingToUse.TheHealth.dead && !this.PersonGoingToUse.TheHealth.Incapacitated && !((UnityEngine.Object) this.PersonGoingToUse.InteractingWith != (UnityEngine.Object) null);
    }
  }

  public void AddBlocker(string blockerID)
  {
    if (!this.InteractBlockers.Contains(blockerID))
      this.InteractBlockers.Add(blockerID);
    this.CanInteract = false;
  }

  public void RemoveBlocker(string blockerID)
  {
    if (this.InteractBlockers.Contains(blockerID))
      this.InteractBlockers.Remove(blockerID);
    if (this.InteractBlockers.Count != 0)
      return;
    this.CanInteract = true;
  }

  public bool HasBlocker(string blockerID) => this.InteractBlockers.Contains(blockerID);

  public virtual bool CheckCanInteract(Person person)
  {
    if ((UnityEngine.Object) person == (UnityEngine.Object) null)
      return false;
    switch (this.GenderOnly)
    {
      case GenderType.Female:
        if (person is Guy)
          return false;
        break;
      case GenderType.Male:
        if (person is Girl)
          return false;
        break;
    }
    for (int index = 0; index < this.RequiredPerks.Length; ++index)
    {
      if (!person.Perks.Contains(this.RequiredPerks[index]))
        return false;
    }
    return true;
  }

  public override void Awake()
  {
    base.Awake();
    if (this.DisableOnStart != null)
    {
      for (int index = 0; index < this.DisableOnStart.Length; ++index)
        this.DisableOnStart[index].enabled = false;
    }
    if (!this.UnparentOnStart)
      return;
    this.transform.SetParent((Transform) null);
  }

  public virtual void Interact(Person person)
  {
    this.PersonGoingToUse = (Person) null;
    if (person.IsPlayer)
    {
      person.UserControl.StopMoving();
      if ((UnityEngine.Object) this.PivotSpot != (UnityEngine.Object) null)
      {
        FreeLookCam objectOfType = UnityEngine.Object.FindObjectOfType<FreeLookCam>(true);
        objectOfType.m_Target = this.PivotSpot.transform;
        objectOfType.transform.Find("Pivot").localPosition = Vector3.zero;
      }
    }
    if (this.SetInteracting)
    {
      this.InteractingPerson = person;
      this.InteractingPerson.Interacting = true;
      this.InteractingPerson.InteractingWith = this;
      this.AddBlocker("Interacting");
      this.ProcessIK();
    }
    if (this.DisableHeadRotate)
      person.LookAtPlayer.Disable = true;
    if (this.DeactivateOnInteract != null)
    {
      for (int index = 0; index < this.DeactivateOnInteract.Length; ++index)
        this.DeactivateOnInteract[index].SetActive(false);
    }
    if (this.DisableOnInteract != null)
    {
      for (int index = 0; index < this.DisableOnInteract.Length; ++index)
        this.DisableOnInteract[index].enabled = false;
    }
    if (this.ActivateOnInteract != null)
    {
      for (int index = 0; index < this.ActivateOnInteract.Length; ++index)
        this.ActivateOnInteract[index].SetActive(true);
    }
    if (this.EnableOnInteract != null)
    {
      for (int index = 0; index < this.EnableOnInteract.Length; ++index)
        this.EnableOnInteract[index].enabled = true;
    }
    if (this.ScriptToRun_OnInteract != null)
    {
      for (int index = 0; index < this.ScriptToRun_OnInteract.Length; ++index)
        this.ScriptToRun_OnInteract[index].Invoke(this.ScriptFunctionToRun_OnInteract[index], 0.0f);
    }
    if ((double) this.DoForSeconds == 0.0)
      return;
    this._RunningForSecs = Main.RunInSeconds((Action) (() => this.StopInteracting()), this.DoForSeconds);
  }

  public virtual void InteractEx(int index, Person person)
  {
    this._SelectedUseIndex = index;
    this.Interact(person);
    this._SelectedUseIndex = 0;
  }

  public void ProcessIK()
  {
    if (!this.intDoIK)
      return;
    Main.RunInNextFrame((Action) (() =>
    {
      if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
        return;
      if ((UnityEngine.Object) this.InteractingPerson.LeftArmIK != (UnityEngine.Object) null)
      {
        for (int index = 0; index < this.intUsingIKs.Length; ++index)
        {
          Transform _attatchTo = this.intUsingIKs[index].tAttatchTo;
          if ((UnityEngine.Object) _attatchTo != (UnityEngine.Object) null)
          {
            switch (this.intUsingIKs[index].Limb)
            {
              case e_IKLimb.LeftArm:
                this.InteractingPerson.LeftArmIK.enabled = true;
                this.InteractingPerson.LeftArmIK.Target.position = this.InteractingPerson.HandLeft.position;
                this.InteractingPerson.LeftArmIK.Target.rotation = this.InteractingPerson.HandLeft.rotation;
                this.InteractingPerson.LeftArmIK.Pole.position = this.intUsingIKs[index].tPolePos.position;
                Main.RunInNextFrame((Action) (() =>
                {
                  this.InteractingPerson.LeftArmIK.Target.SetParent(_attatchTo);
                  this.InteractingPerson.LeftArmIK.Target.localPosition = Vector3.zero;
                  this.InteractingPerson.LeftArmIK.Target.localEulerAngles = Vector3.zero;
                }), 2);
                continue;
              case e_IKLimb.RightArm:
                this.InteractingPerson.RightArmIK.enabled = true;
                this.InteractingPerson.RightArmIK.Target.position = this.InteractingPerson.HandRight.position;
                this.InteractingPerson.RightArmIK.Target.rotation = this.InteractingPerson.HandRight.rotation;
                this.InteractingPerson.RightArmIK.Pole.position = this.intUsingIKs[index].tPolePos.position;
                Main.RunInNextFrame((Action) (() =>
                {
                  this.InteractingPerson.RightArmIK.Target.SetParent(_attatchTo);
                  this.InteractingPerson.RightArmIK.Target.localPosition = Vector3.zero;
                  this.InteractingPerson.RightArmIK.Target.localEulerAngles = Vector3.zero;
                }), 2);
                continue;
              case e_IKLimb.LeftLeg:
                this.InteractingPerson.LeftLegIK.enabled = true;
                this.InteractingPerson.LeftLegIK.Target.position = this.InteractingPerson.FootLeft.position;
                this.InteractingPerson.LeftLegIK.Target.rotation = this.InteractingPerson.FootLeft.rotation;
                this.InteractingPerson.LeftLegIK.Pole.position = this.intUsingIKs[index].tPolePos.position;
                Main.RunInNextFrame((Action) (() =>
                {
                  this.InteractingPerson.LeftLegIK.Target.SetParent(_attatchTo);
                  this.InteractingPerson.LeftLegIK.Target.localPosition = Vector3.zero;
                  this.InteractingPerson.LeftLegIK.Target.localEulerAngles = Vector3.zero;
                }), 2);
                continue;
              case e_IKLimb.RightLeg:
                this.InteractingPerson.RightLegIK.enabled = true;
                this.InteractingPerson.RightLegIK.Target.position = this.InteractingPerson.FootRight.position;
                this.InteractingPerson.RightLegIK.Target.rotation = this.InteractingPerson.FootRight.rotation;
                this.InteractingPerson.RightLegIK.Pole.position = this.intUsingIKs[index].tPolePos.position;
                Main.RunInNextFrame((Action) (() =>
                {
                  this.InteractingPerson.RightLegIK.Target.SetParent(_attatchTo);
                  this.InteractingPerson.RightLegIK.Target.localPosition = Vector3.zero;
                  this.InteractingPerson.RightLegIK.Target.localEulerAngles = Vector3.zero;
                }), 2);
                continue;
              default:
                continue;
            }
          }
        }
      }
      if (!this.DisableHeadRotate)
        return;
      this.InteractingPerson.LookAtPlayer.Disable = true;
    }), 4);
  }

  public virtual void StopInteracting() => this.StopInteracting((Person) null);

  public virtual void StopInteracting(Person interactingPerson)
  {
    this.PersonGoingToUse = (Person) null;
    if ((UnityEngine.Object) interactingPerson == (UnityEngine.Object) null)
      interactingPerson = this.InteractingPerson;
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
      return;
    if (this.InteractingPerson.IsPlayer && (UnityEngine.Object) this.PivotSpot != (UnityEngine.Object) null)
    {
      UnityEngine.Object.FindObjectOfType<FreeLookCam>(true).m_Target = this.InteractingPerson.transform;
      this.InteractingPerson.UserControl.m_Character.StandState = bl_ThirdPersonCharacter.bl_StandState.Standing;
    }
    if ((UnityEngine.Object) this._RunningForSecs != (UnityEngine.Object) null)
    {
      this._RunningForSecs.Stop();
      this._RunningForSecs = (Main._runinseconds) null;
    }
    if (this.ActivateOnInteract != null)
    {
      for (int index = 0; index < this.ActivateOnInteract.Length; ++index)
        this.ActivateOnInteract[index].SetActive(false);
    }
    if (this.EnableOnInteract != null)
    {
      for (int index = 0; index < this.EnableOnInteract.Length; ++index)
        this.EnableOnInteract[index].enabled = false;
    }
    if (this.DeactivateOnInteract != null)
    {
      for (int index = 0; index < this.DeactivateOnInteract.Length; ++index)
        this.DeactivateOnInteract[index].SetActive(true);
    }
    if (this.DisableOnInteract != null)
    {
      for (int index = 0; index < this.DisableOnInteract.Length; ++index)
        this.DisableOnInteract[index].enabled = true;
    }
    if (this.ScriptToRun_OnStopInteract != null)
    {
      for (int index = 0; index < this.ScriptToRun_OnStopInteract.Length; ++index)
        this.ScriptToRun_OnStopInteract[index].Invoke(this.ScriptFunctionToRun_OnStopInteract[index], 0.0f);
    }
    if (this.DisableHeadRotate)
      interactingPerson.LookAtPlayer.Disable = false;
    if (this.PlaceNPCOnInteract && !interactingPerson.IsPlayer && (UnityEngine.Object) this.NavMeshInteractSpot != (UnityEngine.Object) null)
      interactingPerson.transform.position = this.NavMeshInteractSpot.position;
    if (this.PlacePlayerOnLeave && interactingPerson.IsPlayer && (UnityEngine.Object) this.NavMeshInteractSpot != (UnityEngine.Object) null)
    {
      interactingPerson.transform.position = this.NavMeshInteractSpot.position;
      interactingPerson.transform.eulerAngles = new Vector3(0.0f, interactingPerson.transform.eulerAngles.y, 0.0f);
    }
    if (this.SetInteracting)
    {
      interactingPerson.Interacting = false;
      interactingPerson.InteractingWith = (Interactible) null;
      this.RemoveBlocker("Interacting");
      if (this.intDoIK)
      {
        interactingPerson.LeftArmIK.enabled = false;
        interactingPerson.LeftArmIK.Target.SetParent(interactingPerson.LeftArmIK.Pole.parent);
        interactingPerson.RightArmIK.enabled = false;
        interactingPerson.RightArmIK.Target.SetParent(interactingPerson.LeftArmIK.Pole.parent);
        interactingPerson.LeftLegIK.enabled = false;
        interactingPerson.LeftLegIK.Target.SetParent(interactingPerson.LeftArmIK.Pole.parent);
        interactingPerson.RightLegIK.enabled = false;
        interactingPerson.RightLegIK.Target.SetParent(interactingPerson.LeftArmIK.Pole.parent);
      }
    }
    if (this.NPCOnFinishInteract != null)
      this.NPCOnFinishInteract();
    this.NPCOnFinishInteract = (Action) null;
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    Transform transform = (UnityEngine.Object) this.RootObj != (UnityEngine.Object) null ? this.RootObj.transform : this.transform;
    return new string[4]
    {
      this.WorldSaveID,
      this.PrefabName,
      Main.Vector32Str(transform.position),
      Main.Vector32Str(transform.eulerAngles)
    };
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    Transform transform = (UnityEngine.Object) this.RootObj == (UnityEngine.Object) null ? this.transform : this.RootObj.transform;
    transform.position = Main.ParseVector3(Data[2]);
    transform.eulerAngles = Main.ParseVector3(Data[3]);
    this._CurrentLoadingIndex = 4;
  }

  public bool InsideSafeHouse
  {
    get
    {
      Collider component = this.gameObject.GetComponent<Collider>();
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return false;
      if (!component.enabled)
        return true;
      component.enabled = false;
      component.enabled = true;
      return this._InsideSafeHouse;
    }
  }

  public void FixedUpdate()
  {
    if (this.Despawnable)
      this.DespawnTimerThread();
    if (!((UnityEngine.Object) this.RootObj != (UnityEngine.Object) null) || (double) this.RootObj.transform.position.y >= -10000.0)
      return;
    this.RootObj.transform.position = new Vector3(0.0f, 0.2f, 0.0f);
    Rigidbody component = this.RootObj.GetComponent<Rigidbody>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    component.velocity = Vector3.zero;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!this.Despawnable || !other.CompareTag("SafeHouse"))
      return;
    this._InsideSafeHouse = true;
  }

  private void OnTriggerExit(Collider other)
  {
    if (!this.Despawnable || !other.CompareTag("SafeHouse"))
      return;
    this._InsideSafeHouse = false;
  }

  public void DespawnTimerThread()
  {
    this.DespawnTimerChecker += Time.deltaTime;
    if ((double) this.DespawnTimerChecker <= 120.0)
      return;
    this.DespawnTimerChecker = 0.0f;
    if (this.InsideSafeHouse)
      return;
    if (this.DoDistanceCheck)
    {
      double num1 = (double) Main.Instance.Player.transform.position.x - (double) this.transform.position.x;
      float num2 = Main.Instance.Player.transform.position.z - this.transform.position.z;
      if (num1 * num1 + (double) num2 * (double) num2 <= 900.0)
        return;
    }
    this.DespawnTimer += 120f;
    if ((double) this.DespawnTimer <= (double) this.DespawnTimerMaxHere)
      return;
    this.DespawnTimer = 0.0f;
    this.DespawnTimerChecker = 0.0f;
    this.Despawn();
  }

  public virtual void Despawn() => UnityEngine.Object.Destroy((UnityEngine.Object) this.RootObj);
}
