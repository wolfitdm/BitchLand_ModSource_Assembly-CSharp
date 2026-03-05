// Decompiled with JetBrains decompiler
// Type: bl_MinableObject
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

#nullable disable
public class bl_MinableObject : Interactible
{
  [Header("   -----   bl_MinableObject")]
  public bool RawResources;
  public e_MiningTool MiningTool;
  public e_ResourceType ResourceItOffers;
  public GameObject[] BreaksInto;
  public GameObject[] ExtraOre;
  public bool AlwaysShowPrompt;
  public string PromptWhenAvailable;
  public bool ShowNotifWhenNoWeapon;
  public string MiningAnim;
  public float TimeMiningMax;
  public float _TimeMining;
  public bool SpawnNonDespawnable;
  public Transform[] SpawnSpots;
  public bool BakeNavmeshOnBuild;
  public List<Person> _Builders = new List<Person>();

  public override bool CheckCanInteract(Person person)
  {
    bool flag = false;
    if ((UnityEngine.Object) this.InteractingPerson != (UnityEngine.Object) null)
      return false;
    if (!person.IsPlayer)
      return true;
    if (this.AlwaysShowPrompt)
      flag = true;
    else if (base.CheckCanInteract(person))
    {
      if ((UnityEngine.Object) person.WeaponInv.CurrentWeapon == (UnityEngine.Object) null)
      {
        if (this.ShowNotifWhenNoWeapon)
          flag = true;
      }
      else
        flag = true;
    }
    return flag;
  }

  public override void Interact(Person person)
  {
    if (person.DEBUG)
      Debug.Log((object) ("Interact -> " + person.name));
    if ((UnityEngine.Object) person.WeaponInv.CurrentWeapon == (UnityEngine.Object) null)
    {
      if (!person.IsPlayer)
        return;
      Main.Instance.GameplayMenu.ShowNotification("You need a " + this.MiningTool.ToString() + " for this");
    }
    else if (person.WeaponInv.CurrentWeapon.ThisToolType != this.MiningTool)
    {
      if (!person.IsPlayer)
        return;
      Main.Instance.GameplayMenu.ShowNotification("You need a " + this.MiningTool.ToString() + " for this");
    }
    else
    {
      this.InteractingPerson = person;
      this.InteractingPerson.Interacting = true;
      person.AddMoveBlocker("Mining");
      person.transform.LookAt(this.transform);
      person.transform.eulerAngles = new Vector3(0.0f, person.transform.eulerAngles.y, 0.0f);
      person.Anim.Play(this.MiningAnim);
      if (person.IsPlayer)
        Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
      else
        person.enabled = false;
      this._TimeMining = this.TimeMiningMax;
      Main.Instance.MainThreads.Add(new Action(this.MiningThread));
    }
  }

  public void MiningThread()
  {
    if (!((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null) && !this.InteractingPerson.TheHealth.dead && !this.InteractingPerson.TheHealth.Incapacitated)
    {
      this._TimeMining -= Time.deltaTime;
      if ((double) this._TimeMining >= 0.0)
      {
        Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = Main.POfVal(this.TimeMiningMax, 0.0f, this._TimeMining);
        return;
      }
    }
    Main.Instance.MainThreads.Remove(new Action(this.MiningThread));
    if ((UnityEngine.Object) this.InteractingPerson != (UnityEngine.Object) null)
    {
      this.InteractingPerson.Interacting = false;
      this.InteractingPerson.RemoveMoveBlocker("Mining");
      this.InteractingPerson.enabled = true;
      if (this.InteractingPerson.IsPlayer)
        Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
    }
    this.Break(this.InteractingPerson);
    if (this.NPCOnFinishInteract != null)
      this.NPCOnFinishInteract();
    this.InteractingPerson = (Person) null;
  }

  public void Break(Person person)
  {
    for (int index = 0; index < this.BreaksInto.Length; ++index)
    {
      Transform transform1 = Main.Spawn(this.BreaksInto[index], saveable: true).transform;
      Transform transform2 = this.SpawnSpots == null || this.SpawnSpots.Length == 0 ? this.transform : this.SpawnSpots[index % this.SpawnSpots.Length];
      transform1.position = transform2.position;
      transform1.rotation = transform2.rotation;
      if (this.SpawnNonDespawnable)
      {
        foreach (Interactible componentsInChild in transform1.GetComponentsInChildren<Interactible>())
          componentsInChild.Despawnable = false;
      }
    }
    if ((UnityEngine.Object) person != (UnityEngine.Object) null && person.Perks.Contains("Mining Skill lvl 2"))
    {
      Transform transform3 = Main.Spawn(this.ExtraOre[0], saveable: true).transform;
      Transform transform4 = this.SpawnSpots == null || this.SpawnSpots.Length == 0 ? this.transform : this.SpawnSpots[this.BreaksInto.Length - 1];
      transform3.position = transform4.position;
      transform3.rotation = transform4.rotation;
      if (this.SpawnNonDespawnable)
      {
        foreach (Interactible componentsInChild in transform3.GetComponentsInChildren<Interactible>())
          componentsInChild.Despawnable = false;
      }
    }
    this.OnBreak();
    UnityEngine.Object.Destroy((UnityEngine.Object) this.RootObj);
  }

  public virtual void OnBuilt(List<Person> builders)
  {
    foreach (int_Lockable componentsInChild in this.RootObj.GetComponentsInChildren<int_Lockable>(true))
      componentsInChild.PlayerOwned = true;
    if (!this.BakeNavmeshOnBuild)
      return;
    if (!Main.Instance.HasUpdatedNavmeshAfterBuildYet)
    {
      Main.Instance.HasUpdatedNavmeshAfterBuildYet = true;
      Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
    }
    this._Builders.Clear();
    this._Builders.AddRange((IEnumerable<Person>) builders);
    for (int index = 0; index < this._Builders.Count; ++index)
      this._Builders[index].AddMoveBlocker("NavProcessingAfterBuilt");
    Main.RunInNextFrame((Action) (() =>
    {
      Main.Instance.Nav2.GetType().GetMethod("RequestNavMeshUpdate").Invoke((object) Main.Instance.Nav2, (object[]) null);
      Main.RunInNextFrame((Action) (() =>
      {
        Main.Instance.NewGameMenu.SmallLoading.SetActive(false);
        for (int index = 0; index < this._Builders.Count; ++index)
          this._Builders[index].RemoveMoveBlocker("NavProcessingAfterBuilt");
        Main.Instance.GarbageCollect();
      }), 10);
    }));
  }

  public virtual void OnBreak()
  {
    if (!this.BakeNavmeshOnBuild)
      return;
    if (!Main.Instance.HasUpdatedNavmeshAfterBuildYet)
    {
      Main.Instance.HasUpdatedNavmeshAfterBuildYet = true;
      Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
    }
    Main.RunInNextFrame((Action) (() =>
    {
      Main.Instance.Nav2.GetType().GetMethod("RequestNavMeshUpdate").Invoke((object) Main.Instance.Nav2, (object[]) null);
      Main.RunInNextFrame((Action) (() =>
      {
        Main.Instance.NewGameMenu.SmallLoading.SetActive(false);
        Main.Instance.GarbageCollect();
      }), 10);
    }), 3);
  }

  public void ProcessNavmeshUGH2()
  {
    Bounds bounds = new Bounds(this.transform.position, new Vector3(7f, 10f, 7f));
    List<NavMeshBuildSource> navMeshBuildSourceList = new List<NavMeshBuildSource>();
    Main.Instance.Nav.GetType().GetProperty("collectObjects").SetValue((object) Main.Instance.Nav, (object) 1);
    NavMeshBuilder.CollectSources(bounds, 1, NavMeshCollectGeometry.PhysicsColliders, 1, new List<NavMeshBuildMarkup>(), navMeshBuildSourceList);
    PropertyInfo property = Main.Instance.Nav.GetType().GetProperty("navMeshData");
    MethodInfo method = Main.Instance.Nav.GetType().GetMethod("GetBuildSettings");
    MonoBehaviour nav = Main.Instance.Nav;
    NavMeshBuilder.UpdateNavMeshData((NavMeshData) property.GetValue((object) nav), (NavMeshBuildSettings) method.Invoke((object) Main.Instance.Nav, (object[]) null), navMeshBuildSourceList, bounds);
  }

  public void ProcessNavmeshUGH()
  {
    MonoBehaviour monoBehaviour1 = (MonoBehaviour) this.gameObject.AddComponent(Main.Instance.Nav.GetType());
    monoBehaviour1.GetType().GetProperty("collectObjects").SetValue((object) monoBehaviour1, (object) 1);
    monoBehaviour1.GetType().GetProperty("useGeometry").SetValue((object) monoBehaviour1, (object) 1);
    monoBehaviour1.GetType().GetProperty("size").SetValue((object) monoBehaviour1, (object) new Vector3(7f, 10f, 7f));
    monoBehaviour1.GetType().GetProperty("center").SetValue((object) monoBehaviour1, (object) Vector3.zero);
    PropertyInfo property = monoBehaviour1.GetType().GetProperty("layerMask");
    LayerMask layerMask = (LayerMask) 1;
    MonoBehaviour monoBehaviour2 = monoBehaviour1;
    // ISSUE: variable of a boxed type
    __Boxed<LayerMask> local = (ValueType) layerMask;
    property.SetValue((object) monoBehaviour2, (object) local);
    monoBehaviour1.GetType().GetMethod("BuildNavMesh").Invoke((object) monoBehaviour1, (object[]) null);
  }
}
