// Decompiled with JetBrains decompiler
// Type: int_dildo
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class int_dildo : int_ResourceItem
{
  public Renderer Ren;
  public Rigidbody Rig;
  public Collider Col;
  public bool RandomCOlor;
  public bool CamoShader;
  public int ColorShader;
  public string[] UseAnim;
  public Vector3 BackPos;
  public Vector3 BackRot;
  public Vector3 BackScl;
  public Vector3 FrontPos;
  public Vector3 FrontRot;
  public Vector3 FrontScl;
  public bool LargeDildo;

  public override void Start()
  {
    base.Start();
    if (!this.RandomCOlor)
      return;
    Color color = new Color(UnityEngine.Random.Range(0.0f, 1f), UnityEngine.Random.Range(0.0f, 1f), UnityEngine.Random.Range(0.0f, 1f));
    if (this.CamoShader)
    {
      string name;
      switch (this.ColorShader)
      {
        case 0:
          name = "_CamoBlackTint";
          break;
        case 1:
          name = "_CamoRedTint";
          break;
        case 2:
          name = "_CamoGreenTint";
          break;
        default:
          name = "_CamoBlueTint";
          break;
      }
      this.Ren.material.SetColor(name, color);
    }
    else
      this.Ren.material.color = color;
  }

  public override void Interact(Person person)
  {
    if (this.LargeDildo && person.IsPlayer && !Main.Instance.Player.Perks.Contains("Gaping"))
    {
      Main.Instance.GameplayMenu.ShowNotification("Need Gaping Perk to use Large dildos");
    }
    else
    {
      this.Rig.isKinematic = true;
      this.Col.enabled = false;
      person.PutOnHand(this.RootObj, this.BackPos, this.BackRot);
      this.AddBlocker("BeingUsed");
      if (!person.IsPlayer)
      {
        person.AddMoveBlocker("usingdildo");
        person.Anim.Play("pickup_10");
        this.InteractingPerson = person;
        Main.Instance.MainThreads.Add(new Action(this.AnimCheckThread));
      }
      else
        Main.Instance.SexScene.SpawnSexScene(1, 0, person);
    }
  }

  public void AnimCheckThread()
  {
    if ((double) this.InteractingPerson.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0 || this.InteractingPerson.Anim.IsInTransition(0))
      return;
    this.InteractingPerson.ObjInHand = this.gameObject;
    this.InteractingPerson.RemoveMoveBlocker("usingdildo");
    Main.Instance.SexScene.SpawnSexScene(1, UnityEngine.Random.Range(0, Main.Instance.SexScene.DildoPoses.Count), this.InteractingPerson);
    Main.Instance.MainThreads.Remove(new Action(this.AnimCheckThread));
    this.InteractingPerson.HavingSex_Scene.StopInteractingOnEnd = true;
    this.InteractingPerson.HavingSex_Scene.TimerForRandomSexEnd = true;
    this.InteractingPerson.HavingSex_Scene.TimerSexEnd = this.InteractingPerson.PersonalityData.HowLongWantsSex;
  }

  public void Drop()
  {
    this.RemoveBlocker("BeingUsed");
    this.RootObj.transform.SetParent((Transform) null, true);
    this.Rig.isKinematic = false;
    this.Col.enabled = true;
  }
}
