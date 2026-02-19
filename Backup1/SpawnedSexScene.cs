// Decompiled with JetBrains decompiler
// Type: SpawnedSexScene
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SpawnedSexScene : MonoBehaviour
{
  public Person Leading;
  public Person Person1;
  public Person Person2;
  public Person Person3;
  public bool StopInteractingOnEnd;
  public SexStateType _ThisSexStateType;
  public bool init_StopInteracting;
  public bool ReceiveMoney;
  public bool CanControl;
  public bool PlayerForcing;
  public Person_Type ForcingPersonType;
  public bool UISex;
  public Transform SpawnedSexSceneStructure;
  public List<Transform> SpawnedSexSceneStructureDildos = new List<Transform>();
  public List<Transform> SpawnedSexSceneStructurePartnerWait = new List<Transform>();
  public SexPose CurrentPose;
  public int_dildo CurrentDildo;
  public List<int_dildo> CurrentDildos = new List<int_dildo>();
  public int_dildo DildoPrevOnHand;
  public List<int_dildo> DildoPrevOnBackpack = new List<int_dildo>();
  public Action OnSexEnd;
  public bool TimerForRandomPoseChange;
  public bool TimerForRandomSexEnd;
  public float TimerSexEnd;
  public float TimerPoseChange;
  public float TimerMax;
  private bool _PlayedShlick;
  public int CurrentsexType;
  public int CurrentsexPose;

  public SexStateType ThisSexStateType
  {
    get => this._ThisSexStateType;
    set
    {
      this._ThisSexStateType = value;
      switch (value)
      {
      }
    }
  }

  public static bool CanStartSex(Person person1, Person person2 = null)
  {
    return !person1.HavingSex && !person1.Interacting && !person1.TheHealth.dead && (double) person1.TheHealth.RespawnTimer <= 0.0 && (!person1.IsPlayer || !person1.TheHealth.Incapacitated) && !person1.HasMoveBlocker("Chat") && (!((UnityEngine.Object) person2 != (UnityEngine.Object) null) || !person2.HavingSex && !person2.Interacting && !person2.TheHealth.dead && (double) person2.TheHealth.RespawnTimer <= 0.0 && (!person2.IsPlayer || !person2.TheHealth.Incapacitated) && !person2.HasMoveBlocker("Chat"));
  }

  public void StartSex(int sexType, int sexPose, bool canControl = true)
  {
    this.SpawnStructure();
    this.CanControl = canControl;
    this.PreparePerson(this.Person1);
    this.PreparePerson(this.Person2);
    this.PreparePerson(this.Person3);
    if ((UnityEngine.Object) this.Person2 != (UnityEngine.Object) null)
    {
      this.Person1.HavingSexWith = this.Person2;
      this.Person2.HavingSexWith = this.Person1;
      if (this.Person2.IsPlayer)
      {
        Main.Instance.SexScene.PlayerSex = this;
        Main.Instance.SexScene.PlayerSex.CanControl = canControl;
      }
    }
    if (this.Person1.IsPlayer)
    {
      Main.Instance.SexScene.PlayerSex = this;
      Main.Instance.SexScene.PlayerSex.CanControl = canControl;
      if (this.PlayerForcing)
      {
        this.ThisSexStateType = SexStateType.Forced;
        this.TriggerShout();
        switch (this.ForcingPersonType)
        {
          case Person_Type.Wild:
            this.Person1.AddTempAggroToType(Person_Type.Wild, "OnSeeForcedSex");
            for (int index = 0; index < Main.Instance.SpawnedPeopleOfType[0].Count; ++index)
              Main.Instance.SpawnedPeopleOfType[0][index].Eyes.AddFlagger("OnSeeForcedSex");
            break;
          case Person_Type.Worker:
          case Person_Type.Civilian:
          case Person_Type.HigherCivilian:
            this.Person1.AddTempAggroToType(Person_Type.Royal, "OnSeeForcedSex");
            this.Person1.AddTempAggroToType(Person_Type.Army, "OnSeeForcedSex");
            for (int index = 0; index < Main.Instance.SpawnedPeopleOfType[6].Count; ++index)
              Main.Instance.SpawnedPeopleOfType[6][index].Eyes.AddFlagger("OnSeeForcedSex");
            break;
          case Person_Type.Army:
          case Person_Type.Royal:
            this.Person1.AddTempAggroToType(Person_Type.Worker, "OnSeeForcedSex");
            this.Person1.AddTempAggroToType(Person_Type.Civilian, "OnSeeForcedSex");
            this.Person1.AddTempAggroToType(Person_Type.HigherCivilian, "OnSeeForcedSex");
            for (int index = 0; index < Main.Instance.SpawnedPeopleOfType[3].Count; ++index)
              Main.Instance.SpawnedPeopleOfType[3][index].Eyes.AddFlagger("OnSeeForcedSex");
            for (int index = 0; index < Main.Instance.SpawnedPeopleOfType[4].Count; ++index)
              Main.Instance.SpawnedPeopleOfType[4][index].Eyes.AddFlagger("OnSeeForcedSex");
            for (int index = 0; index < Main.Instance.SpawnedPeopleOfType[5].Count; ++index)
              Main.Instance.SpawnedPeopleOfType[5][index].Eyes.AddFlagger("OnSeeForcedSex");
            for (int index = 0; index < Main.Instance.SpawnedPeopleOfType[7].Count; ++index)
              Main.Instance.SpawnedPeopleOfType[7][index].Eyes.AddFlagger("OnSeeForcedSex");
            goto case Person_Type.Worker;
        }
      }
      if ((UnityEngine.Object) this.Person2 != (UnityEngine.Object) null && this.Person2 is Guy)
      {
        Person person1 = this.Person1;
        Person person2 = this.Person2;
        this.Person2 = person1;
        this.Person1 = person2;
      }
    }
    this.CurrentDildo = (int_dildo) null;
    this.CurrentDildos.Clear();
    if ((UnityEngine.Object) this.Person1.ObjInHand != (UnityEngine.Object) null)
    {
      this.DildoPrevOnHand = this.Person1.ObjInHand.GetComponentInChildren<int_dildo>();
      this.CurrentDildos.Add(this.DildoPrevOnHand);
    }
    if ((UnityEngine.Object) this.Person1.CurrentBackpack != (UnityEngine.Object) null)
    {
      this.DildoPrevOnBackpack.AddRange((IEnumerable<int_dildo>) this.Person1.CurrentBackpack.GetComponentsInChildren<int_dildo>());
      this.CurrentDildos.AddRange((IEnumerable<int_dildo>) this.DildoPrevOnBackpack);
    }
    this.PlaceDildosAround();
    if (this.CurrentDildos.Count > 0)
      this.CurrentDildo = this.CurrentDildos[0];
    this.On_ClothingToggle(false);
    this.StartPose(sexType, sexPose);
  }

  public void SafeSexEnd()
  {
    if ((UnityEngine.Object) this == (UnityEngine.Object) Main.Instance.SexScene.PlayerSex)
      Main.Instance.SexScene.EndSexScene();
    else
      this.EndSex();
  }

  public void EndSex()
  {
    this.CurrentPose.SexPoseEnd();
    this.On_ClothingToggle(true, false);
    this.UnPreparePerson(this.Person1);
    this.UnPreparePerson(this.Person2);
    this.UnPreparePerson(this.Person3);
    if (Main.Instance.NewGameMenu.DificultySelected == 3 && (double) Main.Instance.Player.transform.position.x > -30.0)
      Main.Instance.Player.transform.position = new Vector3(-40f, 0.1f, -13f);
    if ((UnityEngine.Object) this.DildoPrevOnHand != (UnityEngine.Object) null)
      this.DildoPrevOnHand.Drop();
    if (this.DildoPrevOnBackpack != null && this.DildoPrevOnBackpack.Count > 0)
    {
      for (int index = 0; index < this.DildoPrevOnBackpack.Count; ++index)
      {
        this.DildoPrevOnBackpack[index].RootObj.transform.SetParent(this.Person1.CurrentBackpack.ThisStorage.transform);
        this.DildoPrevOnBackpack[index].RootObj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
      }
    }
    if (this.PlayerForcing)
    {
      for (int index1 = 0; index1 < 10; ++index1)
      {
        for (int index2 = 0; index2 < Main.Instance.SpawnedPeopleOfType[index1].Count; ++index2)
          Main.Instance.SpawnedPeopleOfType[index1][index2].Eyes.RemoveFlagger("OnSeeForcedSex");
      }
    }
    UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedSexSceneStructure.gameObject);
    UnityEngine.Object.Destroy((UnityEngine.Object) this);
    if (this.ReceiveMoney)
    {
      int _profit = (double) UnityEngine.Random.Range(0.0f, 1f) > 0.10000000149011612 ? UnityEngine.Random.Range(1, 20) : UnityEngine.Random.Range(50, 100);
      Person person = this.Person1.IsPlayer ? this.Person1 : this.Person2;
      person.Money += _profit;
      if (person.Perks.Contains("Prostitution skill lvl 1"))
        person.Money += _profit;
      if (person.Perks.Contains("Prostitution skill lvl 2"))
        person.Money += _profit * 2;
      person.GainWorkXP(1000);
      if (this.Person1.IsPlayer || this.Person2.IsPlayer)
        Main.RunInSeconds((Action) (() => Main.Instance.GameplayMenu.ShowNotification("Received " + _profit.ToString() + " Bitch Notes")), 1f);
    }
    if (this.OnSexEnd == null)
      return;
    this.OnSexEnd();
  }

  public void Update()
  {
    this.Person1.SexUpdate();
    if ((UnityEngine.Object) this.Person2 != (UnityEngine.Object) null)
    {
      this.Person2.SexUpdate();
      if (this.ThisSexStateType != SexStateType.Sleeping && (double) this.Person2.Energy < 10.0)
      {
        this.ThisSexStateType = SexStateType.Sleeping;
        this.Person2.StopFighting();
        if (this.UISex)
        {
          Main.Instance.SexScene._DontAdd = true;
          Main.Instance.SexScene.SexTypeDrop.SetValueWithoutNotify(3);
          Main.Instance.SexScene.On_SexTypeChange();
        }
        this.StartPose(3, this.CurrentPose.TiredSexPose);
      }
    }
    if ((UnityEngine.Object) this.Person3 != (UnityEngine.Object) null)
      this.Person3.SexUpdate();
    if ((UnityEngine.Object) this.CurrentPose != (UnityEngine.Object) null && this.CurrentPose.HasShlicks)
    {
      Person person = (UnityEngine.Object) this.Person2 != (UnityEngine.Object) null ? this.Person2 : this.Person1;
      float num1 = person.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f;
      if ((double) num1 >= (double) this.CurrentPose.ShlickTrigger && !this._PlayedShlick)
      {
        this._PlayedShlick = true;
        AudioClip shlickSound = Main.Instance.SexScene.ShlickSounds[UnityEngine.Random.Range(0, Main.Instance.SexScene.ShlickSounds.Length)];
        if ((UnityEngine.Object) shlickSound != (UnityEngine.Object) null)
          person.PersonAudio.PlayOneShot(shlickSound, UnityEngine.Random.Range(0.05f, 0.2f));
      }
      if ((double) num1 < (double) this.CurrentPose.ShlickTrigger)
        this._PlayedShlick = false;
      if (UI_Settings.BellyBulgeValue != 2 && !this.CurrentPose.NoBulge && person is Girl)
      {
        Girl girl = person as Girl;
        if (!girl.Pregnant || (double) girl._PregnancyPercent <= 0.20000000298023224)
        {
          float num2 = UI_Settings.BellyBulgeValue == 0 ? 2f : 1f;
          float num3 = num2 / 2f;
          float num4 = num1 * num2;
          int num5 = this.CurrentPose.ReversedBulge ? ((double) num4 >= (double) num3 ? 1 : 0) : ((double) num4 <= (double) num3 ? 1 : 0);
          girl.BellyBulgePercent = num5 == 0 ? num2 - num4 : num4;
          --girl.BellyBulgePercent;
          float num6 = (UnityEngine.Object) this.Person2 != (UnityEngine.Object) null ? this.Person1.Penis.transform.localScale.y / 10f : (this.CurrentDildo.LargeDildo ? 0.3f : 0.1f);
          girl.PregnancyBones[0].localScale = new Vector3(girl.PregnancyBones[0].localScale.x, girl.PregnancyBones[0].localScale.y, girl.PregnancyBones_default[0].z + Main.ValOfP(0.0f + num6, 0.0f, girl.BellyBulgePercent));
          girl.PregnancyBones[0].localPosition = new Vector3(girl.PregnancyBones[1].localPosition.x, girl.PregnancyBones[1].localPosition.y, girl.PregnancyBones_default[1].z + Main.ValOfP(num6 / 10f, 0.0f, girl.BellyBulgePercent));
        }
      }
    }
    if (this.TimerForRandomPoseChange)
    {
      this.TimerPoseChange -= Time.deltaTime;
      if ((UnityEngine.Object) Main.Instance.SexScene.PlayerSex == (UnityEngine.Object) this)
      {
        Main.Instance.SexScene.ProgressSlider.transform.parent.gameObject.SetActive(true);
        Main.Instance.SexScene.ProgressSlider.fillAmount = !this.TimerForRandomSexEnd || (double) this.TimerSexEnd >= (double) this.TimerPoseChange ? this.TimerPoseChange / this.TimerMax : this.TimerSexEnd / this.TimerMax;
      }
      if ((double) this.TimerPoseChange <= 0.0)
      {
        this.TimerMax = UnityEngine.Random.Range(5f, 15f);
        this.TimerPoseChange = this.TimerMax;
        this.StartRandomPose();
      }
    }
    if (!this.TimerForRandomSexEnd)
      return;
    this.TimerSexEnd -= Time.deltaTime;
    if ((double) this.TimerSexEnd > 0.0)
      return;
    if ((UnityEngine.Object) Main.Instance.SexScene.PlayerSex == (UnityEngine.Object) this)
      Main.Instance.SexScene.EndSexScene();
    else
      this.EndSex();
  }

  public void FaceExpressionOverwrite()
  {
    Person person1 = this.Person1;
    this.Person1.ResetAllShapes();
    if ((UnityEngine.Object) this.Person2 != (UnityEngine.Object) null)
    {
      Person person2 = this.Person1.IsPlayer ? this.Person2 : this.Person1;
      Person person3 = this.Person1.IsPlayer ? this.Person1 : this.Person2;
      this.Person2.ResetAllShapes();
      if (this.PlayerForcing)
      {
        int forcedFace = (int) Main.Instance.SexScene.ForcedFaces[UnityEngine.Random.Range(0, Main.Instance.SexScene.ForcedFaces.Length)];
        person2.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[forcedFace]);
      }
      else
        person2.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[2]);
      person3.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[2]);
      if ((UnityEngine.Object) this.Person2.HavingSex_Scene == (UnityEngine.Object) null)
      {
        this.EndSex();
        return;
      }
      if (this.Person2.HavingSex_Scene.CurrentPose.PermanentFaceBlendshapes && this.Person2.HavingSex_Scene.CurrentPose.Person2FaceShapes != e_BlendShapes.None)
        this.Person2.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[(int) this.Person2.HavingSex_Scene.CurrentPose.Person2FaceShapes]);
      if ((double) this.Person2.Energy < 10.0)
        this.Person2.BlendShape("e01_close", 100f);
    }
    else
      person1.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[2]);
    if ((double) this.Person1.Energy < 10.0)
      this.Person1.BlendShape("e01_close", 100f);
    if ((UnityEngine.Object) this.Person1.HavingSex_Scene == (UnityEngine.Object) null)
    {
      this.EndSex();
    }
    else
    {
      if (!this.Person1.HavingSex_Scene.CurrentPose.PermanentFaceBlendshapes || this.Person1.HavingSex_Scene.CurrentPose.Person1FaceShapes == e_BlendShapes.None)
        return;
      this.Person1.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[(int) this.Person1.HavingSex_Scene.CurrentPose.Person1FaceShapes]);
    }
  }

  public void StartRandomPose()
  {
    if ((UnityEngine.Object) this.Person2 == (UnityEngine.Object) null)
    {
      if (this.CurrentDildos.Count == 0)
        this.StartPose(0, UnityEngine.Random.Range(0, Main.Instance.SexScene.FingerPoses.Count));
      else if ((double) UnityEngine.Random.Range(0.0f, 1f) > 0.5)
        this.StartPose(0, UnityEngine.Random.Range(0, Main.Instance.SexScene.FingerPoses.Count));
      else
        this.StartPose(1, UnityEngine.Random.Range(0, Main.Instance.SexScene.DildoPoses.Count));
    }
    else if ((double) UnityEngine.Random.Range(0.0f, 1f) > 0.10000000149011612)
      this.StartPose(2, UnityEngine.Random.Range(0, Main.Instance.SexScene.SexPoses.Count));
    else if (this.CurrentDildos.Count == 0)
      this.StartPose(0, UnityEngine.Random.Range(0, Main.Instance.SexScene.FingerPoses.Count));
    else if ((double) UnityEngine.Random.Range(0.0f, 1f) > 0.5)
      this.StartPose(0, UnityEngine.Random.Range(0, Main.Instance.SexScene.FingerPoses.Count));
    else
      this.StartPose(1, UnityEngine.Random.Range(0, Main.Instance.SexScene.DildoPoses.Count));
  }

  public void StartPose(int sexType, int sexPose)
  {
    this.CurrentsexType = sexType;
    this.CurrentsexPose = sexPose;
    if ((UnityEngine.Object) this.CurrentPose != (UnityEngine.Object) null)
      this.CurrentPose.SexPoseEnd();
    this.PlaceDildosAround();
    this.PlacePartnersAround();
    switch (sexType)
    {
      case 0:
        this.CurrentPose = Main.Instance.SexScene.FingerPoses[sexPose];
        break;
      case 1:
        this.CurrentPose = Main.Instance.SexScene.DildoPoses[sexPose];
        break;
      case 2:
        this.CurrentPose = Main.Instance.SexScene.SexPoses[sexPose];
        break;
      case 3:
        this.CurrentPose = Main.Instance.SexScene.NoEnergyPoses[sexPose];
        break;
      case 4:
        this.CurrentPose = Main.Instance.SexScene.ForcedPoses[sexPose];
        break;
      case 5:
        this.CurrentPose = Main.Instance.SexScene.FurniturePoses[sexPose];
        break;
      case 6:
        this.CurrentPose = Main.Instance.SexScene.CouchPoses[sexPose];
        break;
    }
    this.CurrentPose = Main.Spawn(this.CurrentPose.gameObject, this.transform).GetComponent<SexPose>();
    this.CurrentPose.ThisScene = this;
    if (this.CurrentDildos.Count > 0)
      this.CurrentDildo = this.CurrentDildos[UnityEngine.Random.Range(0, this.CurrentDildos.Count)];
    this.CurrentPose.Person1 = this.Person1;
    this.CurrentPose.Person2 = this.Person2;
    this.CurrentPose.Person3 = this.Person3;
    Main.RunInNextFrame(new Action(this.CurrentPose.SexPoseStart));
  }

  public void On_DildoChange(int dildo)
  {
    this.PlaceDildosAround();
    if (this.CurrentDildos.Count > 0)
      this.CurrentDildo = this.CurrentDildos[dildo];
    this.CurrentPose.RefreshDildo();
  }

  public void PlaceDildosAround()
  {
    if (this.CurrentDildos.Count <= 0)
      return;
    for (int index = 0; index < this.CurrentDildos.Count && index < this.SpawnedSexSceneStructureDildos.Count; ++index)
    {
      this.CurrentDildos[index].Rig.isKinematic = true;
      this.CurrentDildos[index].Col.enabled = false;
      Transform transform = this.CurrentDildos[index].RootObj.transform;
      transform.SetParent(this.SpawnedSexSceneStructure);
      transform.SetPositionAndRotation(this.SpawnedSexSceneStructureDildos[index].position, this.SpawnedSexSceneStructureDildos[index].rotation);
    }
  }

  public void PlacePartnersAround()
  {
    if ((UnityEngine.Object) this.Person2 != (UnityEngine.Object) null)
      this.Person2.transform.SetPositionAndRotation(this.SpawnedSexSceneStructurePartnerWait[0].position, this.SpawnedSexSceneStructurePartnerWait[0].rotation);
    if (!((UnityEngine.Object) this.Person3 != (UnityEngine.Object) null))
      return;
    this.Person2.transform.SetPositionAndRotation(this.SpawnedSexSceneStructurePartnerWait[1].position, this.SpawnedSexSceneStructurePartnerWait[1].rotation);
  }

  public void SetPenisMaterial(Person person, bool DefaultMat)
  {
    person.Penis.GetComponentInChildren<SkinnedMeshRenderer>(true).material = DefaultMat ? Main.Instance.PenisMat : Main.Instance.StraponMat;
  }

  public void ErectPenisFor(Person person)
  {
    if ((UnityEngine.Object) person == (UnityEngine.Object) null)
      return;
    if (person is Girl)
    {
      if (((Girl) person).Futa)
      {
        person.Penis.SetActive(true);
        person.PenisErect = true;
      }
      else
      {
        this.SetPenisMaterial(person, false);
        person.Penis.SetActive(true);
        person.PenisErect = true;
        if (!((UnityEngine.Object) (person as Girl).StrapOn == (UnityEngine.Object) null))
          return;
        (person as Girl).StrapOn = person.DressClothe(Main.Instance.TempStraponPanties);
      }
    }
    else
    {
      person.Penis.SetActive(true);
      person.PenisErect = true;
    }
  }

  public void FlacidPenisFor(Person person)
  {
    if ((UnityEngine.Object) person == (UnityEngine.Object) null)
      return;
    if (person is Girl)
    {
      if (((Girl) person).Futa)
      {
        person.Penis.SetActive(true);
        person.PenisErect = false;
      }
      else
      {
        person.Penis.SetActive(false);
        if (!((UnityEngine.Object) (person as Girl).StrapOn != (UnityEngine.Object) null))
          return;
        UnityEngine.Object.Destroy((UnityEngine.Object) person.UndressClothe((person as Girl).StrapOn.GetComponent<Dressable>()));
      }
    }
    else
    {
      person.Penis.SetActive(true);
      person.PenisErect = false;
    }
  }

  public void HidePenisFor(Person person)
  {
    if ((UnityEngine.Object) person == (UnityEngine.Object) null)
      return;
    person.Penis.SetActive(false);
    if (!(person is Girl))
      return;
    ((Girl) person).StrapOn.SetActive(false);
  }

  public void PreparePerson(Person person)
  {
    if (!((UnityEngine.Object) person != (UnityEngine.Object) null))
      return;
    if (!person.IsPlayer)
      person.SetHighLod();
    if ((UnityEngine.Object) person.ProxSeen != (UnityEngine.Object) null)
      person.ProxSeen.AddBlocker("Sex");
    if (!this.CanControl)
      person.NoEnergyLoss = true;
    if (this.init_StopInteracting && person.Interacting && (UnityEngine.Object) person.InteractingWith != (UnityEngine.Object) null)
      person.InteractingWith.StopInteracting();
    if ((UnityEngine.Object) person.WeaponInv != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) person.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
        person.WeaponInv.CurrentWeapon.Holdster();
      if ((UnityEngine.Object) person.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
        person.WeaponInv.CurrentWeapon.enabled = false;
    }
    person.AddMoveBlocker("Sex");
    person.HavingSex = true;
    person.HavingSex_Scene = this;
    person.Anim.speed = 1f;
    person.ResetAllShapes();
    person.enabled = false;
    person.LookAtPlayer.OnlyEyes = true;
    person.LookAtPlayer.DontBlockSides = true;
    if (person.IsPlayer)
    {
      person._Rigidbody.isKinematic = true;
      person.UserControl.enabled = false;
      person.UserControl.m_Character.enabled = false;
      if (!person.DirtySkin && (double) person.transform.position.y < 0.5)
      {
        ++person._TimesHadSexClean;
        if (person._TimesHadSexClean > 4)
          person.DirtySkin = true;
      }
    }
    else
      person.LodRen.GetComponent<CharacterLOD>().enabled = false;
    if (person is Guy)
    {
      person.Anim.applyRootMotion = false;
    }
    else
    {
      person.Anim.applyRootMotion = true;
      ((Girl) person).GirlPhysics = true;
      if (person.RagdollParts != null && person.RagdollParts.Length > 8)
      {
        person.RagdollParts[7].GetComponent<Collider>().enabled = false;
        person.RagdollParts[8].GetComponent<Collider>().enabled = false;
      }
    }
    person.transform.SetParent(this.SpawnedSexSceneStructure);
    person.transform.localPosition = Vector3.zero;
  }

  public void UnPreparePerson(Person person)
  {
    if (!((UnityEngine.Object) person != (UnityEngine.Object) null))
      return;
    if (person is Girl)
    {
      if ((UnityEngine.Object) (person as Girl).StrapOn != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) person.UndressClothe((person as Girl).StrapOn.GetComponent<Dressable>()));
      if (!person.IsPlayer && person.RagdollParts != null && person.RagdollParts.Length > 8)
      {
        person.RagdollParts[7].GetComponent<Collider>().enabled = true;
        person.RagdollParts[8].GetComponent<Collider>().enabled = true;
      }
      if (!(person as Girl).Pregnant || (double) (person as Girl)._PregnancyPercent <= 0.20000000298023224)
      {
        (person as Girl).PregnancyBones[0].localScale = (person as Girl).PregnancyBones_default[0];
        (person as Girl).PregnancyBones[0].localPosition = (person as Girl).PregnancyBones_default[1];
      }
    }
    if (this.StopInteractingOnEnd && (UnityEngine.Object) person.InteractingWith != (UnityEngine.Object) null)
      person.InteractingWith.StopInteracting(person);
    if ((UnityEngine.Object) person.ProxSeen != (UnityEngine.Object) null)
    {
      person.ProxSeen.TimeOut = 4f;
      person.ProxSeen.RemoveBlocker("Sex");
    }
    if (!this.CanControl)
      person.NoEnergyLoss = false;
    if (person.TheHealth.Incapacitated)
    {
      person.SexEnding_bug1 = true;
      person.StartRagdoll(true);
      person.SexEnding_bug1 = false;
    }
    if (!person.HasPenis)
      person.Penis.SetActive(false);
    person.transform.SetParent((Transform) null);
    person.RemoveMoveBlocker("Sex");
    person.HavingSex = false;
    person.HavingSex_Scene = (SpawnedSexScene) null;
    person.HavingSexWith = (Person) null;
    person.enabled = true;
    person.LookAtPlayer.OnlyEyes = false;
    person.LookAtPlayer.DontBlockSides = false;
    person.Anim.speed = 1f;
    person.ResetAllShapes();
    person.SexPoseHasNoArousalIncrease = false;
    if (person.IsPlayer)
    {
      person.UserControl.m_Character.enabled = true;
      person._Rigidbody.isKinematic = false;
      person.Anim.applyRootMotion = false;
      if (person is Girl)
        ((Girl) person).GirlPhysics = false;
      person.UserControl.FirstPerson = false;
      person.UserControl.MeleeOption = bl_ThirdPersonUserControl.MeleeOptions.None;
    }
    else
    {
      person.LodRen.GetComponent<CharacterLOD>().enabled = true;
      person.ThisPersonInt.SetDefaultInteraction();
      person.SetHighLod();
    }
    if ((UnityEngine.Object) person.WeaponInv != (UnityEngine.Object) null && (UnityEngine.Object) person.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
      person.WeaponInv.CurrentWeapon.enabled = true;
    person.RemoveAllTempAggroToFlagger("OnSeeForcedSex");
    if (!((UnityEngine.Object) person.ThisPersonInt != (UnityEngine.Object) null))
      return;
    person.ThisPersonInt.RestrainedCheck();
  }

  public void SpawnStructure()
  {
    this.SpawnedSexSceneStructure = UnityEngine.Object.Instantiate<GameObject>(Main.Instance.SexScene.SexSceneStructure.gameObject).transform;
    this.SpawnedSexSceneStructure.SetPositionAndRotation(this.Person1.transform.position, this.Person1.transform.rotation);
    this.SpawnedSexSceneStructureDildos.AddRange((IEnumerable<Transform>) this.SpawnedSexSceneStructure.Find("Dildos").GetComponentsInChildren<Transform>());
    this.SpawnedSexSceneStructurePartnerWait.AddRange((IEnumerable<Transform>) this.SpawnedSexSceneStructure.Find("Partners").GetComponentsInChildren<Transform>());
    this.SpawnedSexSceneStructureDildos.RemoveAt(0);
    this.SpawnedSexSceneStructurePartnerWait.RemoveAt(0);
  }

  public void On_ClothingToggle_ind(Person person, bool value, bool hideBackpack = true)
  {
    bool flag = false;
    for (int index = 0; index < person.EquippedClothes.Count; ++index)
    {
      switch (person.EquippedClothes[index].BodyPart)
      {
        case DressableType.Pants:
          if (person is Guy || person is Girl && ((Girl) person).Futa)
          {
            person.PutPenis();
            break;
          }
          break;
        case DressableType.Hair:
        case DressableType.Head:
        case DressableType.Body:
        case DressableType.Feet:
          continue;
        case DressableType.BackPack:
          if (hideBackpack)
          {
            foreach (Renderer componentsInChild in person.EquippedClothes[index].GetComponentsInChildren<Renderer>())
              componentsInChild.enabled = false;
            continue;
          }
          break;
      }
      if (!person.EquippedClothes[index].DisplayDuringSex)
      {
        foreach (Renderer componentsInChild in person.EquippedClothes[index].GetComponentsInChildren<Renderer>())
          componentsInChild.enabled = value;
        if (person.EquippedClothes[index].HidesFeet)
          flag = true;
      }
    }
    if (!flag)
      return;
    if (value)
      person.RemoveFeet();
    else
      person.PutFeet();
  }

  public void On_ClothingToggle(bool value, bool hideBackpack = true)
  {
    this.On_ClothingToggle_ind(this.Person1, value, hideBackpack);
    if ((UnityEngine.Object) this.Person2 != (UnityEngine.Object) null)
      this.On_ClothingToggle_ind(this.Person2, value, hideBackpack);
    if (!((UnityEngine.Object) this.Person3 != (UnityEngine.Object) null))
      return;
    this.On_ClothingToggle_ind(this.Person3, value, hideBackpack);
  }

  public void SwapPeople(ref Person person1, ref Person person2)
  {
    Person person = person1;
    person1 = person2;
    person2 = person;
    this.StartPose(this.CurrentsexType, this.CurrentsexPose);
  }

  public void ForcedSexSeen(Person person) => person.StartFighting(Main.Instance.Player);

  public void TriggerShout()
  {
    AudioClip clip = Main.Instance.FemaleForcedStart[UnityEngine.Random.Range(0, Main.Instance.FemaleForcedStart.Length)];
    this.Person2.PersonAudio.pitch = this.Person2.VoicePitch;
    if (!((UnityEngine.Object) clip != (UnityEngine.Object) null))
      return;
    this.Person2.PersonAudio.PlayOneShot(clip);
  }
}
