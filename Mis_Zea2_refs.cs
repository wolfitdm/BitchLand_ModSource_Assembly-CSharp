// Decompiled with JetBrains decompiler
// Type: Mis_Zea2_refs
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.AI;

#nullable disable
public class Mis_Zea2_refs : MonoBehaviour
{
  public Mis_Zea2 Zea2;
  public Mis_Zea3 Zea3;
  [Space]
  public GameObject[] HeadQuarters_BeforeAndAfter;
  public MeshRenderer[] CeilingLights;
  public GameObject[] BoardNames;
  public GameObject[] Cameras;
  public GameObject[] OnWar;
  public Interactible[] Zea2Ints;
  public GameObject[] Z2Objs;
  public Transform[] Z3Objs;
  public Transform[] jumpoverspots;

  private void Start()
  {
    this.Zea2 = UnityEngine.Object.FindObjectOfType<Mis_Zea2>();
    this.Zea3 = UnityEngine.Object.FindObjectOfType<Mis_Zea3>();
    this.Zea2.HeadQuarters_BeforeAndAfter = this.HeadQuarters_BeforeAndAfter;
    this.Zea2.Lights = this.CeilingLights;
    this.Zea2.Ints = this.Zea2Ints;
    this.Zea2.Objs = this.Z2Objs;
    this.Zea3.BoardNames = this.BoardNames;
    this.Zea3.Cameras = this.Cameras;
    this.Zea3.OnWar = this.OnWar;
    this.Zea3.Ely_spots[38] = this.Z3Objs[0];
    this.Zea3.Ely_spots[40] = this.Z3Objs[1];
    this.Zea3.Ely_spots[41] = this.Z3Objs[2];
    this.Zea3.Ely_spots[42] = this.Z3Objs[3];
    this.Zea3.Ely_spots[43] = this.Z3Objs[4];
    this.Zea3.Ely_spots[44] = this.Z3Objs[5];
    this.Zea3.Ely_spots[45] = this.Z3Objs[6];
    this.Zea3.Ely_spots[46] = this.Z3Objs[7];
    this.Zea3.Ely_spots[47] = this.Z3Objs[8];
    this.Zea3.Ely_spots[48 /*0x30*/] = this.Z3Objs[9];
    this.Zea3.Ely_spots[49] = this.Z3Objs[10];
    this.Zea3.Ely_spots[50] = this.Z3Objs[11];
    this.Zea3.Ely_spots[51] = this.Z3Objs[12];
    this.Zea3.Ely_spots[58] = this.Z3Objs[13];
    this.Zea3.Ely_spots[59] = this.Z3Objs[14];
  }

  public void OnSitChair() => this.Zea3.OnSitChair();

  public void PlayerEnteredChatZone() => this.Zea3.PlayerEnteredChatZone();

  public void OnSitFirePlace() => this.Zea2.OnSitFirePlace();

  public void OnLightFire() => this.Zea2.OnLightFire();

  public void ESBSpawn(Person person) => this.Zea3.ESBSpawn(person);

  public void ESBSpawn_2(Person person) => this.Zea3.ESBSpawn_2(person);

  public void ESBSpawn_3(Person person) => this.Zea3.ESBSpawn_3(person);

  public void JumpOver()
  {
    if ((double) Main.Instance.Player.transform.position.x > 1834.6710205078125)
    {
      Main.Instance.Player.PlaceAt(this.jumpoverspots[0]);
      Main.Instance.MusicPlayer.PlayOneShot(this.Zea2.VoiceLines[46]);
    }
    else
    {
      Main.Instance.Player.PlaceAt(this.jumpoverspots[1]);
      Main.Instance.MusicPlayer.PlayOneShot(this.Zea2.VoiceLines[46]);
    }
  }

  public void ESBSpawnInside(Person person)
  {
    this.Zea3.ESBSToDespawn.Add(person.gameObject);
    person.TheHealth.AlwaysDie = true;
    Main.RunInSeconds((Action) (() =>
    {
      person.StartFighting(Main.Instance.Player);
      person.AddMoveBlocker("asdasdasd");
      for (int index = 0; index < person.WeaponInv.weapons.Count; ++index)
      {
        if ((UnityEngine.Object) person.WeaponInv.weapons[index] != (UnityEngine.Object) null)
        {
          Weapon component = person.WeaponInv.weapons[index].GetComponent<Weapon>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
            component.power = 10f;
          else
            Debug.LogError((object) "SDGFKLHJFKHJGFSDGLK:DKLSJ:G");
        }
      }
    }), 1f);
  }

  public void SadieSpawn(Person person)
  {
    this.Zea3.ESBSToDespawn.Add(person.gameObject);
    person.LOD.enabled = false;
    person.LodRen.gameObject.SetActive(false);
    person.SetHighLod();
    Main.RunInSeconds((Action) (() =>
    {
      Main.Instance.CityCharacters.Sadie = person;
      person.TheHealth.canDie = false;
      person.AddMoveBlocker("asd");
      person.enabled = false;
      person.PlaceAt(this.jumpoverspots[2]);
      person.Anim.Play("pushing");
      for (int index = 0; index < person.WeaponInv.weapons.Count; ++index)
      {
        if ((UnityEngine.Object) person.WeaponInv.weapons[index] != (UnityEngine.Object) null)
        {
          Weapon component = person.WeaponInv.weapons[index].GetComponent<Weapon>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
            component.power = 10f;
          else
            Debug.LogError((object) "SDGFKLHJFKHJGFSDGLK:DKLSJ:G");
        }
      }
    }), 1f);
  }

  public void TriggerSadie1() => this.Invoke("TriggerSadie1_2", 1.5f);

  public void TriggerSadie1_2()
  {
    Person _sadie = Main.Instance.CityCharacters.Sadie;
    _sadie.enabled = true;
    _sadie.RemoveMoveBlocker("asd");
    _sadie.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "asdasd",
      ActionPlace = this.jumpoverspots[3],
      RunTo = true,
      OnArrive = (Action) (() =>
      {
        _sadie.PlaceAt(this.jumpoverspots[3]);
        _sadie.AddMoveBlocker("asdasd");
        _sadie.TheHealth.canDie = true;
        this.jumpoverspots[6].gameObject.SetActive(false);
      })
    });
  }

  public void TriggerSadie2()
  {
    Person sadie = Main.Instance.CityCharacters.Sadie;
    sadie.StartFighting(Main.Instance.Player);
    sadie.AddMoveBlocker("STOP MOOVING");
    GameObject gameObject = new GameObject("_SuperStopMoving");
    gameObject.SetActive(false);
    gameObject.transform.SetParent(sadie.transform);
    sadie.navMesh.enabled = false;
    sadie.navMesh = gameObject.AddComponent<NavMeshAgent>();
    sadie.navMesh.enabled = false;
    Main.Instance.GameplayMenu.DisplaySubtitle("Stop!  Go away!", this.Zea3.VoiceLines[101], new Action(sadie.ThisPersonInt.EndTheChat), sadie);
    Main.Instance.MusicPlayer.PlayOneShot(this.Zea3.VoiceLines[101]);
  }

  public void EnterDark() => Main.Instance.GameplayMenu.ShowNotification("It's too dark to see");

  public void UseLight()
  {
    this.jumpoverspots[4].gameObject.SetActive(false);
    Main.Instance.Player.TheHealth.canDie = false;
    Main.Instance.Player.AddMoveBlocker("asdasd");
    Main.Instance.Player.PlaceAt(this.Zea2.SpawnSpots[22]);
    Main.Instance.Player.UserControl.FirstPerson = false;
    Main.Instance.Player.enabled = false;
    Main.Instance.Player.Anim.Play("punch_20");
    Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.PunchSounds[0]);
    Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.MeleeHitSounds[1]);
    Main.RunInSeconds((Action) (() =>
    {
      this.Zea2.LightsOn(true);
      this.Zea2.Areas[1].OnEnter();
      Main.Instance.Player.TheHealth.canDie = true;
      Main.Instance.Player.enabled = true;
      Main.Instance.Player.RemoveMoveBlocker("asdasd");
      this.jumpoverspots[5].gameObject.SetActive(true);
    }), 1f);
  }

  public void UseKeypad2()
  {
    Main.Instance.Player.TheHealth.canDie = false;
    Main.Instance.Player.AddMoveBlocker("asdasd");
    this.ShowKeypadOptions();
  }

  public void ShowKeypadOptions()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    _gameplay.DisplaySubtitle("", (AudioClip) null, (Action) (() =>
    {
      _gameplay.RemoveAllChatOptions();
      _gameplay.AddChatOption("2 - 7 - 4", new Action(this.WrongKeypadOption));
      _gameplay.AddChatOption("4 - 7 - 2", new Action(this.WrongKeypadOption));
      _gameplay.AddChatOption("4 - 2 - 7", new Action(this.ActivateKeypadRight));
      _gameplay.AddChatOption("7 - 2 - 4", new Action(this.WrongKeypadOption));
      _gameplay.AddChatOption("7 - 4 - 2", new Action(this.WrongKeypadOption));
      _gameplay.SelectChatOption(0);
      Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
    }));
  }

  public void WrongKeypadOption()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.Zea3.VoiceLines[103]);
    this.ShowKeypadOptions();
  }

  public void ActivateKeypadRight()
  {
    this.jumpoverspots[11].gameObject.SetActive(true);
    Main.Instance.Player.gameObject.SetActive(false);
    Main.Instance.PlayerCam.transform.root.gameObject.SetActive(false);
    Main.Instance.Player.WeaponInv.DropAllWeapons();
    this.Invoke("SelfExplosion1", 1f);
    this.Invoke("SelfExplosion2", 2f);
    this.Invoke("SelfExplosion3", 3f);
    this.Invoke("SelfExplosion4", 4f);
    this.Invoke("FadeoutToEly", 5f);
  }

  public void SelfExplosion1() => this.jumpoverspots[7].gameObject.SetActive(true);

  public void SelfExplosion2() => this.jumpoverspots[8].gameObject.SetActive(true);

  public void SelfExplosion3()
  {
    this.jumpoverspots[9].gameObject.SetActive(true);
    this.jumpoverspots[12].GetComponent<Animation>().Play();
  }

  public void SelfExplosion4() => this.jumpoverspots[10].gameObject.SetActive(true);

  public void FadeoutToEly() => this.Zea3.StartElyCutscene();

  public void WarCatch() => this.Zea3.OnWarCatchPlayer();
}
