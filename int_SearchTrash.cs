// Decompiled with JetBrains decompiler
// Type: int_SearchTrash
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class int_SearchTrash : Interactible
{
  [Header("-----------Pile")]
  public int Items;
  public bool Infinite;
  public Transform DropSpot;
  public AudioSource Audio;
  public GameObject[] RandomItems;
  public GameObject[] RandomDildos;
  public float Timer;
  public bool CanSearch = true;
  public float EmptyTimer;

  public override void Start()
  {
    base.Start();
    this.Items = UnityEngine.Random.Range(3, 5);
  }

  public void Update()
  {
    if ((double) this.EmptyTimer != 0.0)
    {
      this.EmptyTimer -= Time.deltaTime;
      if ((double) this.EmptyTimer < 0.0)
      {
        this.EmptyTimer = 0.0f;
        this.Items = UnityEngine.Random.Range(4, 6);
        this.ResetSearch();
        return;
      }
    }
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer >= 0.0)
      return;
    this.ResetSearch();
  }

  public void AnimCheckThread()
  {
    if ((double) this.InteractingPerson.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0 || this.InteractingPerson.Anim.IsInTransition(0))
      return;
    this.StopInteracting();
    if (!(this.InteractingPerson is Girl))
      return;
    this.InteractingPerson.ObjInHand = Main.Spawn(this.RandomDildos[UnityEngine.Random.Range(0, this.RandomDildos.Length)]);
    Main.Instance.SexScene.SpawnSexScene(1, UnityEngine.Random.Range(0, Main.Instance.SexScene.DildoPoses.Count), this.InteractingPerson);
    Main.Instance.MainThreads.Remove(new Action(this.AnimCheckThread));
    this.InteractingPerson.HavingSex_Scene.StopInteractingOnEnd = true;
    this.InteractingPerson.HavingSex_Scene.TimerForRandomSexEnd = true;
    this.InteractingPerson.HavingSex_Scene.TimerSexEnd = 20f;
  }

  public override void Interact(Person person)
  {
    if (!person.IsPlayer)
    {
      base.Interact(person);
      person.Anim.Play("pickup_10");
      Main.Instance.MainThreads.Add(new Action(this.AnimCheckThread));
    }
    else
    {
      if (!this.CanSearch)
        return;
      this.Audio.PlayOneShot(Main.Instance.SearchTrashSounds[UnityEngine.Random.Range(0, Main.Instance.SearchTrashSounds.Length)]);
      if (!this.Infinite)
      {
        if (this.Items <= 0)
        {
          Main.Instance.GameplayMenu.ShowNotification("It's empty, wait some time");
          if ((double) this.EmptyTimer == 0.0)
          {
            this.EmptyTimer = 10f;
            goto label_9;
          }
          goto label_9;
        }
        --this.Items;
      }
      Main.Spawn(this.RandomItems[UnityEngine.Random.Range(0, this.RandomItems.Length)]).transform.SetPositionAndRotation(this.DropSpot.position, this.DropSpot.rotation);
label_9:
      this.InteractText = "(Searching)";
      this.Timer = 1f;
      this.enabled = true;
      this.CanSearch = false;
    }
  }

  public void ResetSearch()
  {
    this.Timer = 0.0f;
    this.CanSearch = true;
    this.InteractText = "Search";
    if ((double) this.EmptyTimer != 0.0)
      return;
    this.enabled = false;
  }
}
