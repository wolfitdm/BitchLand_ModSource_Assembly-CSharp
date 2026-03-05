// Decompiled with JetBrains decompiler
// Type: Health
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Health : MonoBehaviour
{
  public Person PersonComponent;
  public bool canDie = true;
  public float startingHealth = 100f;
  public float maxHealth = 100f;
  public float currentHealth;
  public bool replaceWhenDead;
  public GameObject deadReplacement;
  public bool makeExplosion;
  public GameObject explosion;
  public bool isPlayer;
  public GameObject deathCam;
  public bool dead;
  public bool Incapacitated;
  public GameObject[] EnableWhenDie;
  public GameObject[] DisableWhenDie;
  public MonoBehaviour[] EnableScriptsWhenDie;
  public MonoBehaviour[] DisableScriptsWhenDie;
  public WeaponSystem ThisWeaponSystem;
  public AudioSource Audio;
  public AudioClip[] PainSounds;
  public AudioClip[] IncapacitatedSounds;
  public float IncapacitatedTimer;
  private bool _PlayerResspawmStart;
  public float RespawnTimer;
  public bool NoLoseRespawn;
  public bool AlwaysDie;
  public bool _BugFix_GetUp;

  private void Start()
  {
    this.currentHealth = this.startingHealth;
    if ((double) this.currentHealth != 0.0)
      return;
    if (this.dead || this.AlwaysDie)
      this.Die();
    else
      this.Incapacitate();
  }

  public void ChangeHealth(float amount, bool vitalLimb, Person responsible)
  {
    if ((UnityEngine.Object) this.PersonComponent != (UnityEngine.Object) null && this.PersonComponent.CantBeHit)
      return;
    this.currentHealth += amount;
    if ((double) amount < 0.0 && (UnityEngine.Object) this.PersonComponent != (UnityEngine.Object) null)
    {
      this.PersonComponent.InCombat = true;
      if ((UnityEngine.Object) this.PersonComponent.EnemyFighting == (UnityEngine.Object) null)
        this.PersonComponent.StartFighting(responsible);
    }
    if ((double) this.currentHealth <= 0.0 && !this.dead && this.canDie)
    {
      if (vitalLimb || this.AlwaysDie)
        this.Die();
      else
        this.Incapacitate();
    }
    else if (!this.dead)
    {
      if (vitalLimb)
        this.ExpressPain();
      else
        this.ExpressPain2();
      if ((UnityEngine.Object) this.PersonComponent != (UnityEngine.Object) null && !this.PersonComponent.IsPlayer && (UnityEngine.Object) this.PersonComponent.EnemyFighting != (UnityEngine.Object) null)
        this.transform.LookAt(this.PersonComponent.EnemyFighting.transform);
    }
    if ((double) this.currentHealth > (double) this.maxHealth)
      this.currentHealth = this.maxHealth;
    if (!this.isPlayer)
      return;
    Main.Instance.GameplayMenu.UpdateHealth();
  }

  public void ExpressPain()
  {
    if (!((UnityEngine.Object) this.Audio != (UnityEngine.Object) null))
      return;
    this.Audio.PlayOneShot(this.PainSounds[UnityEngine.Random.Range(0, this.PainSounds.Length)]);
  }

  public void ExpressPain2()
  {
    if (!((UnityEngine.Object) this.Audio != (UnityEngine.Object) null))
      return;
    this.Audio.PlayOneShot(this.IncapacitatedSounds[UnityEngine.Random.Range(0, this.IncapacitatedSounds.Length)]);
  }

  public void Incapacitate()
  {
    if (this.Incapacitated)
      return;
    this.Die(false, true);
    this.dead = false;
    this.Incapacitated = true;
    this.ExpressPain2();
    if ((UnityEngine.Object) this.PersonComponent.StartSleepingSex != (UnityEngine.Object) null)
      this.PersonComponent.StartSleepingSex.RemoveBlocker("Dead");
    if (this.PersonComponent.IsPlayer)
      return;
    this.IncapacitatedTimer = (float) UnityEngine.Random.Range(20, 60);
    Main.Instance.MainThreads.Add(new Action(this.IncapacitatedThread));
  }

  public void IncapacitatedThread()
  {
    this.IncapacitatedTimer -= Time.deltaTime;
    if ((double) this.IncapacitatedTimer >= 0.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.IncapacitatedThread));
    this.PersonComponent.StopFighting();
    this.dead = false;
    this.Incapacitated = false;
    this.currentHealth = 10f;
    this.PersonComponent.UnRagdoll();
    Main.RunInNextFrame((Action) (() => this.PersonComponent.WakeUp(20f)));
  }

  public void Die() => this.Die(true, false);

  public void Die(bool makeSound = true, bool closeEyes = false)
  {
    this.dead = true;
    if (this.replaceWhenDead)
      UnityEngine.Object.Instantiate<GameObject>(this.deadReplacement, this.transform.position, this.transform.rotation);
    if (this.makeExplosion)
      UnityEngine.Object.Instantiate<GameObject>(this.explosion, this.transform.position, this.transform.rotation);
    if ((UnityEngine.Object) this.PersonComponent != (UnityEngine.Object) null)
    {
      this.PersonComponent.CurrentScheduleTask = (Person.ScheduleTask) null;
      this.PersonComponent.WorkScheduleTasks.Clear();
      this.PersonComponent.FreeScheduleTasks.Clear();
      this.PersonComponent.Do_Schedule_GoingToTargetThread = false;
    }
    for (int index = 0; index < this.EnableWhenDie.Length; ++index)
      this.EnableWhenDie[index].SetActive(true);
    for (int index = 0; index < this.DisableWhenDie.Length; ++index)
      this.DisableWhenDie[index].SetActive(false);
    for (int index = 0; index < this.EnableScriptsWhenDie.Length; ++index)
      this.EnableScriptsWhenDie[index].enabled = true;
    for (int index = 0; index < this.DisableScriptsWhenDie.Length; ++index)
      this.DisableScriptsWhenDie[index].enabled = false;
    if (!((UnityEngine.Object) this.PersonComponent != (UnityEngine.Object) null))
      return;
    this.ThisWeaponSystem.DropAllWeapons();
    this.PersonComponent.StartRagdoll(closeEyes);
    if (makeSound)
      this.ExpressPain();
    this.PersonComponent.OnSeen.Clear();
    if (closeEyes)
      this.PersonComponent.BlendShape("e01_close", 100f);
    if (this.isPlayer)
    {
      this.RespawnTimer = 4f;
      this.PersonComponent.StopFighting();
      Main.Instance.MainThreads.Add(new Action(this.PlayerRespawn));
      this.Invoke("FadeToBlack", 1f);
      if (this.PersonComponent.States[20])
      {
        this.PersonComponent.States[20] = false;
        this.PersonComponent.States[21] = true;
      }
      else
      {
        if (this.PersonComponent.States[21])
          return;
        this.PersonComponent.States[20] = true;
      }
    }
    else
    {
      if (!((UnityEngine.Object) this.PersonComponent.StartSleepingSex != (UnityEngine.Object) null))
        return;
      this.PersonComponent.StartSleepingSex.AddBlocker("Dead");
    }
  }

  public void PlayerRespawnNoRagdoll()
  {
    this.PersonComponent.AddMoveBlocker("Respawning");
    this.ThisWeaponSystem.DropAllWeapons();
    this.PersonComponent.Money /= 2;
    this.RespawnTimer = 4f;
    this.PersonComponent.StopFighting();
    Main.Instance.MainThreads.Add(new Action(this.PlayerRespawn));
    this.Invoke("FadeToBlack", 1f);
  }

  public void FadeToBlack() => Main.Instance.GameplayMenu.TheScreenFader.FadeOut(4f);

  public void Unfade() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);

  public void ThirdPerson() => this.PersonComponent.UserControl.FirstPerson = false;

  public void PlayerRespawn()
  {
    if (!this._PlayerResspawmStart)
    {
      this._PlayerResspawmStart = true;
      Main.Instance.Player.UserControl.MeleeOption = bl_ThirdPersonUserControl.MeleeOptions.None;
      if (!this.PersonComponent._IsSleeping)
        this.PersonComponent.Anim.Play("Sleeping Idle");
    }
    this.RespawnTimer -= Time.deltaTime;
    if ((double) this.RespawnTimer > 0.0)
      return;
    this._PlayerResspawmStart = false;
    if (Main.Instance.NewGameMenu.DificultySelected != 3)
    {
      if (this.NoLoseRespawn || Main.Instance.NewGameMenu.DificultySelected == 2 && Main.Instance.AllMissions[8].Goals[5].Completed && !Main.Instance.AllMissions[8].Goals[12].Completed)
      {
        Main.Instance.GameplayMenu.ShowNotification("You got your ass kicked");
      }
      else
      {
        Main.Instance.GameplayMenu.ShowNotification("You got robbed while sleeping in an unsafe place");
        Main.Instance.DayCycle.timeOfDay = UnityEngine.Random.Range(0.0f, 1f);
        List<Dressable> dressableList = new List<Dressable>();
        for (int index = 0; index < this.PersonComponent.EquippedClothes.Count; ++index)
        {
          switch (this.PersonComponent.EquippedClothes[index].BodyPart)
          {
            case DressableType.Hair:
            case DressableType.Head:
            case DressableType.Body:
            case DressableType.BackPack:
            case DressableType.Feet:
              continue;
            default:
              if (!this.PersonComponent.EquippedClothes[index].NonRemovableOnThrowdown)
              {
                dressableList.Add(this.PersonComponent.EquippedClothes[index]);
                continue;
              }
              continue;
          }
        }
        for (int index = 0; index < dressableList.Count; ++index)
          this.PersonComponent.UndressClothe(dressableList[index]);
        if (this.PersonComponent.HasPenis)
          this.PersonComponent.PutPenis();
        if ((UnityEngine.Object) this.PersonComponent.Storage_Vag != (UnityEngine.Object) null)
        {
          for (int index = 0; index < this.PersonComponent.Storage_Vag.StorageItems.Count; ++index)
            this.PersonComponent.Storage_Vag.RemoveItem(this.PersonComponent.Storage_Vag.StorageItems[index]);
          Main.Spawn(Main.Instance.AddableItemsWhenSlumWake[UnityEngine.Random.Range(0, Main.Instance.AddableItemsWhenSlumWake.Count)], saveable: true).GetComponentInChildren<int_PickupToHand>(true).EquipToVag(this.PersonComponent);
        }
        for (int index = 0; index < this.PersonComponent.Storage_Anal.StorageItems.Count; ++index)
          this.PersonComponent.Storage_Anal.RemoveItem(this.PersonComponent.Storage_Anal.StorageItems[index]);
        Main.Spawn(Main.Instance.AddableItemsWhenSlumWake[UnityEngine.Random.Range(0, Main.Instance.AddableItemsWhenSlumWake.Count)], saveable: true).GetComponentInChildren<int_PickupToHand>(true).EquipToAss(this.PersonComponent);
        int num1 = 0;
        int num2 = UnityEngine.Random.Range(0, Main.Instance.AddableClothesWhenSlumWake.Count);
label_27:
        GameObject prefab = Main.Instance.AddableClothesWhenSlumWake[num2++];
        if (num2 >= Main.Instance.AddableClothesWhenSlumWake.Count)
          num2 = 0;
        for (int index = 0; index < this.PersonComponent.EquippedClothes.Count; ++index)
        {
          if (this.PersonComponent.EquippedClothes[index].OriginalPrefab.name == prefab.name && num1++ < 10)
            goto label_27;
        }
        this.PersonComponent.DressClothe(prefab);
        if (this.PersonComponent.States[17])
        {
          this.PersonComponent.States[17] = false;
          this.PersonComponent.States[18] = true;
        }
        else if (this.PersonComponent.States[18])
        {
          this.PersonComponent.States[18] = false;
          this.PersonComponent.States[19] = true;
        }
        else if (!this.PersonComponent.States[19])
          this.PersonComponent.States[17] = true;
        if (this.PersonComponent.States[22])
          this.PersonComponent.States[23 + UnityEngine.Random.Range(0, 3)] = true;
        this.PersonComponent.States[26] = true;
        switch (UnityEngine.Random.Range(0, 6))
        {
          case 1:
            this.PersonComponent.States[12] = true;
            break;
          case 2:
            this.PersonComponent.States[13] = true;
            break;
          case 3:
            this.PersonComponent.States[14] = true;
            break;
          case 4:
            this.PersonComponent.States[15] = true;
            break;
          case 5:
            this.PersonComponent.States[16] = true;
            break;
        }
      }
    }
    else
      Main.Instance.GameplayMenu.ShowNotification("You woke up in your cell");
    this.Unfade();
    Transform transform;
    if (Main.Instance.OpenWorld)
    {
      int_bed[] objectsOfType = UnityEngine.Object.FindObjectsOfType<int_bed>();
      int_bed intBed = (int_bed) null;
      float num3 = 999999f;
      for (int index = 0; index < objectsOfType.Length; ++index)
      {
        if ((UnityEngine.Object) objectsOfType[index].Owner == (UnityEngine.Object) Main.Instance.Player)
        {
          float num4 = Vector2.Distance(new Vector2(objectsOfType[index].transform.position.x, objectsOfType[index].transform.position.z), new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z));
          if ((double) num4 < (double) num3)
          {
            num3 = num4;
            intBed = objectsOfType[index];
          }
        }
      }
      transform = !((UnityEngine.Object) intBed == (UnityEngine.Object) null) ? intBed.SleepPlace : Main.Instance.PlayerWakeupPlaces[UnityEngine.Random.Range(0, Main.Instance.PlayerWakeupPlaces.Count)];
    }
    else
      transform = Main.Instance.PlayerWakeupPlaces[UnityEngine.Random.Range(0, Main.Instance.PlayerWakeupPlaces.Count)];
    foreach (bl_sceneticsound blSceneticsound in UnityEngine.Object.FindObjectsOfType<bl_sceneticsound>())
      blSceneticsound.OnTriggerExit(Main.Instance.Player.MainCol);
    this.dead = false;
    this.Incapacitated = false;
    if (this.PersonComponent.DirtySkin)
      this.PersonComponent.States[2] = true;
    else
      this.PersonComponent.DirtySkin = true;
    this.currentHealth = 51f;
    Main.Instance.GameplayMenu.UpdateHealth();
    this.PersonComponent.AddMoveBlocker("Respawning");
    this.PersonComponent.transform.position = transform.position;
    this.PersonComponent.RemoveAllTempAggro();
    this.PersonComponent.UnRagdoll();
    this.PersonComponent.enabled = false;
    Main.Instance.MainThreads.Remove(new Action(this.PlayerRespawn));
    this.RespawnTimer = 2f;
    Main.Instance.MainThreads.Add(new Action(this.FinishingRespawn));
  }

  public void FinishingRespawn()
  {
    this.RespawnTimer -= Time.deltaTime;
    if ((double) this.RespawnTimer > 0.0)
      return;
    this.PersonComponent.enabled = true;
    for (int index = 0; index < this.DisableScriptsWhenDie.Length; ++index)
      this.DisableScriptsWhenDie[index].enabled = true;
    Main.Instance.MainThreads.Remove(new Action(this.FinishingRespawn));
    this.PersonComponent.RemoveMoveBlocker("Respawning");
    this.PersonComponent.WakeUp(20f);
  }
}
