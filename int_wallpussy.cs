// Decompiled with JetBrains decompiler
// Type: int_wallpussy
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class int_wallpussy : int_basicSit
{
  [Header("----")]
  public Collider Col_AvailableTouse;
  public Person Client;
  public Transform ClientPos;
  public Transform HipsPos;
  public Transform HipsPlacer;
  public Transform ClientHipsPos;
  public GameObject PrefabEquipWhenUsing;
  public Dressable SpawnedEquipWhenUsing;
  public Transform[] Lookable;
  public Transform[] LookableAt;
  public int SexType;
  public int SexPose;
  public SpawnedSexScene TheSexScene;
  public float NPCTimer;
  public Transform Pos;
  public Transform SexPos;
  public float Counter;
  public float CounterMax = 1f;
  public bool DontRepos;
  public bool Repos3;

  public override bool CheckCanInteract(Person person)
  {
    return Main.Instance.NewGameMenu.DificultySelected != 3 && base.CheckCanInteract(person);
  }

  public override void Interact(Person person)
  {
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
      this.AddProst(person);
    else
      this.AddClient(person);
  }

  public void AddProst(Person person, bool repos = true)
  {
    if ((UnityEngine.Object) this.Pos != (UnityEngine.Object) null)
      person.transform.position = this.Pos.position;
    base.Interact(person);
    this.RunTo = true;
    this.GenderOnly = GenderType.Both;
    if ((UnityEngine.Object) this.PrefabEquipWhenUsing != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.SpawnedEquipWhenUsing != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedEquipWhenUsing.PersonEquipped.UndressClothe(this.SpawnedEquipWhenUsing));
      this.SpawnedEquipWhenUsing = this.InteractingPerson.DressClothe(this.PrefabEquipWhenUsing).GetComponentInChildren<Dressable>();
    }
    if ((UnityEngine.Object) this.InteractingPerson.navMesh != (UnityEngine.Object) null)
      this.InteractingPerson.navMesh.enabled = false;
    this.InteractingPerson.transform.localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
    if ((UnityEngine.Object) this.HipsPos != (UnityEngine.Object) null)
      this.PlaceHips(this.InteractingPerson, this.HipsPos);
    if (this.LookableAt.Length > 1)
    {
      this.LookableAt[0] = this.InteractingPerson.Head.Find("w");
      if ((UnityEngine.Object) this.LookableAt[0] == (UnityEngine.Object) null)
      {
        this.LookableAt[0] = new GameObject("w").transform;
        this.LookableAt[0].SetParent(this.InteractingPerson.Head);
      }
      this.LookableAt[0].localPosition = new Vector3(0.0f, 0.0f, 0.34f);
      this.LookableAt[1] = this.InteractingPerson.Belly;
    }
    this.enabled = true;
    if ((UnityEngine.Object) this.InteractingPerson.LOD != (UnityEngine.Object) null)
      this.InteractingPerson.LOD.DistanceOnly = true;
    this.Col_AvailableTouse.enabled = true;
    this.CanInteract = true;
    if (this.InteractingPerson.HasPenis)
    {
      this.InteractingPerson.PutPenis();
      this.InteractingPerson.Penis.SetActive(true);
    }
    if (!person.CallWhenHighCol.Contains(new Action(this.Reposition)))
      person.CallWhenHighCol.Add(new Action(this.Reposition));
    this.Reposition();
    Main.RunInNextFrame(new Action(this.Reposition));
    Main.RunInNextFrame(new Action(this.Reposition), 5);
    Main.RunInNextFrame(new Action(this.Reposition), 10);
  }

  public void AddClient(Person person)
  {
    this.Col_AvailableTouse.enabled = false;
    this.CanInteract = false;
    this.CanLeave = false;
    this.Client = person;
    this.Client.Interacting = true;
    this.Client.transform.SetParent(this.transform);
    this.Client.AddMoveBlocker("Sit");
    this.Client.transform.position = this.ClientPos.position;
    this.Client.transform.rotation = this.ClientPos.rotation;
    if ((UnityEngine.Object) this.PrefabEquipWhenUsing != (UnityEngine.Object) null && (UnityEngine.Object) this.SpawnedEquipWhenUsing != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedEquipWhenUsing.PersonEquipped.UndressClothe(this.SpawnedEquipWhenUsing));
    if (this.Client.IsPlayer)
    {
      this.PlayerCanLeave = true;
    }
    else
    {
      this.NPCTimer = (float) UnityEngine.Random.Range(10, 30);
      Main.Instance.MainThreads.Add(new Action(this.Thread_NPCLeave));
    }
    this.InteractingPerson.NoEnergyLoss = true;
    this.TheSexScene = Main.Instance.SexScene.SpawnSexScene(this.SexType, this.SexPose, this.Client, this.InteractingPerson, canControl: false, stopInteracting: false);
    this.TheSexScene.On_ClothingToggle(true);
    if (this.Client.IsPlayer)
      Main.Instance.SexScene.CanExitSexScene = false;
    this.Reposition();
    Main.RunInNextFrame(new Action(this.Reposition));
    Main.RunInNextFrame(new Action(this.Reposition), 5);
    Main.RunInNextFrame(new Action(this.Reposition), 10);
  }

  public void Thread_NPCLeave()
  {
    this.NPCTimer -= Time.deltaTime;
    if ((double) this.NPCTimer >= 0.0)
      return;
    this.StopInteracting();
  }

  public void RemoveClient()
  {
    if (this.Client.IsPlayer || this.InteractingPerson.IsPlayer)
      Main.Instance.SexScene.EndSexScene();
    else
      this.TheSexScene.EndSex();
    Main.Instance.MainThreads.Remove(new Action(this.Thread_NPCLeave));
    this.Col_AvailableTouse.enabled = true;
    this.CanInteract = true;
    this.CanLeave = true;
    this.Client.Interacting = false;
    this.Client.transform.SetParent((Transform) null);
    this.Client.RemoveMoveBlocker("Sit");
    this.Client = (Person) null;
    this.Reposition();
    Main.RunInNextFrame(new Action(this.Reposition));
    Main.RunInNextFrame(new Action(this.Reposition), 5);
    Main.RunInNextFrame(new Action(this.Reposition), 10);
    this.ProcessIK();
    this.AddProst(this.InteractingPerson, false);
  }

  public override void StopInteracting()
  {
    if ((UnityEngine.Object) this.Client != (UnityEngine.Object) null)
    {
      this.RemoveClient();
    }
    else
    {
      if ((UnityEngine.Object) this.PrefabEquipWhenUsing != (UnityEngine.Object) null && (UnityEngine.Object) this.SpawnedEquipWhenUsing != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.SpawnedEquipWhenUsing.PersonEquipped == (UnityEngine.Object) null)
          UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedEquipWhenUsing);
        else
          UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedEquipWhenUsing.PersonEquipped.UndressClothe(this.SpawnedEquipWhenUsing));
        this.SpawnedEquipWhenUsing = (Dressable) null;
      }
      this.RunTo = false;
      this.GenderOnly = this.DefaultGenderOnly;
      this.enabled = false;
      this.Col_AvailableTouse.enabled = false;
      base.StopInteracting();
      if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
        return;
      if (!this.InteractingPerson.IsPlayer)
      {
        this.InteractingPerson.LOD.DistanceOnly = false;
        this.InteractingPerson.navMesh.enabled = true;
      }
      this.InteractingPerson.NoEnergyLoss = false;
      this.InteractingPerson = (Person) null;
    }
  }

  public void PlaceAt(Transform rootObj, Transform childObj, Transform targetPosition)
  {
    Vector3 vector3 = targetPosition.position - childObj.position;
    rootObj.position = new Vector3(rootObj.position.x, rootObj.position.y + vector3.y, rootObj.position.z + vector3.z);
  }

  public void PlaceHips(Person person, Transform location)
  {
    this.HipsPlacer.position = person.Hips.transform.position;
    person.transform.SetParent(this.HipsPlacer, true);
    this.HipsPlacer.position = location.position;
    person.transform.SetParent((UnityEngine.Object) this.Pos == (UnityEngine.Object) null ? this.transform : this.Pos, true);
  }

  public void LateUpdate()
  {
    if ((UnityEngine.Object) this.InteractingPerson.navMesh != (UnityEngine.Object) null && this.InteractingPerson.navMesh.enabled)
      this.Reposition();
    if ((UnityEngine.Object) this.Client != (UnityEngine.Object) null && this.Client.IsPlayer && Main.Instance.CancelKey())
      this.RemoveClient();
    if (!((UnityEngine.Object) this.InteractingPerson != (UnityEngine.Object) null))
      return;
    for (int index = 0; index < this.LookableAt.Length; ++index)
      this.Lookable[index].LookAt(this.LookableAt[index]);
  }

  public void Reposition()
  {
    this.Counter = 0.0f;
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null || this.DontRepos)
      return;
    if ((UnityEngine.Object) this.InteractingPerson.navMesh != (UnityEngine.Object) null)
      this.InteractingPerson.navMesh.enabled = false;
    if ((UnityEngine.Object) this.TheSexScene != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.SexPos != (UnityEngine.Object) null)
        this.InteractingPerson.transform.position = this.SexPos.position;
    }
    else if ((UnityEngine.Object) this.Pos != (UnityEngine.Object) null)
      this.InteractingPerson.transform.position = this.Pos.position;
    this.InteractingPerson.transform.localEulerAngles = this.Sit_Anim[0].LocalRot;
    if ((UnityEngine.Object) this.HipsPos != (UnityEngine.Object) null)
      this.PlaceHips(this.InteractingPerson, this.HipsPos);
    if (this.Repos3)
      this.AdjustCharacterPosition(this.HeightRegulator, this.InteractingPerson.RagdollParts[this.HeightRegRagBone].transform);
    if (!((UnityEngine.Object) this.Client != (UnityEngine.Object) null))
      return;
    this.Client.transform.position = this.ClientPos.position;
    if (!((UnityEngine.Object) this.ClientHipsPos != (UnityEngine.Object) null))
      return;
    this.AdjustCharacterPosition(this.ClientHipsPos, this.Client.ActualHips, this.Client.transform);
  }
}
