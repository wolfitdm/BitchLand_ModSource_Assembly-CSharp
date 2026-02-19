// Decompiled with JetBrains decompiler
// Type: MultiInteractible
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class MultiInteractible : Interactible
{
  [Header(" - MultiInteractible -")]
  public bool NewMulti;
  public bool QuickRelayFix;
  public SaveableBehaviour RelaySavingData;
  public Interactible[] Parts;
  public bool AskWhichOption;
  public Person PersonWantingToInteract;
  [Space]
  public List<Interactible> _PartsToUse;
  public List<int> _PartsUseIndex;

  public override bool CheckCanInteract(Person person)
  {
    bool flag = false;
    for (int index = 0; index < this.Parts.Length; ++index)
    {
      if (this.Parts[index].CanInteract)
      {
        flag = true;
        break;
      }
    }
    return flag && base.CheckCanInteract(person);
  }

  public override void Interact(Person person)
  {
    this.PersonGoingToUse = (Person) null;
    if (this.AskWhichOption && person.IsPlayer)
    {
      this.PersonWantingToInteract = person;
      Main.Instance.GameplayMenu.MultiOptions.SetActive(true);
      Main.Instance.GameplayMenu.PlayerWeaponSystem.PickupText.text = string.Empty;
      Main.Instance.GameplayMenu.PlayerWeaponSystem.PromptIcon.enabled = false;
      for (int index = 0; index < Main.Instance.GameplayMenu.ItemOptions.Length; ++index)
        Main.Instance.GameplayMenu.ItemOptions[index].SetActive(false);
      this._PartsToUse.Clear();
      this._PartsUseIndex.Clear();
      int num = this.Parts.Length >= 8 ? 8 : this.Parts.Length;
      List<(Interactible, int, string)> valueTupleList = new List<(Interactible, int, string)>();
      for (int index1 = 0; index1 < num; ++index1)
      {
        if (this.Parts[index1].CanInteract && this.Parts[index1].CheckCanInteract(Main.Instance.Player))
        {
          valueTupleList.Add((this.Parts[index1], 0, this.Parts[index1].InteractText));
          if (this.Parts[index1]._AvailableUses != null && this.Parts[index1]._AvailableUses.Length > 1)
          {
            for (int index2 = 1; index2 < this.Parts[index1]._AvailableUses.Length; ++index2)
            {
              if (this.Parts[index1]._AvailableUses[index2])
              {
                if (index1 + index2 < 8)
                  valueTupleList.Add((this.Parts[index1], index2, this.Parts[index1]._InteractTexts[index2]));
                else
                  goto label_15;
              }
            }
          }
        }
      }
label_15:
      for (int index = 0; index < valueTupleList.Count; ++index)
      {
        Main.Instance.GameplayMenu.ItemOptions[index].SetActive(true);
        Main.Instance.GameplayMenu.ItemOptions_text[index].text = valueTupleList[index].Item3;
        this._PartsToUse.Add(valueTupleList[index].Item1);
        this._PartsUseIndex.Add(valueTupleList[index].Item2);
      }
      Main.Instance.Player.AddMoveBlocker("MultiOption");
      this.CanInteract = false;
      Main.Instance.MainThreads.Add(new Action(this.WaitForOption));
    }
    else
    {
      for (int part = 0; part < this.Parts.Length; ++part)
      {
        if (this.Parts[part].CanInteract && this.Parts[part].CheckCanInteract(person))
        {
          this.Interact(person, part);
          break;
        }
      }
    }
  }

  public void Interact(Person person, int part)
  {
    if (person.IsPlayer)
    {
      Main.Instance.GameplayMenu.PlayerWeaponSystem.PickupText.text = string.Empty;
      Main.Instance.GameplayMenu.PlayerWeaponSystem.PromptIcon.enabled = false;
      Main.Instance.GameplayMenu.MultiOptions.SetActive(false);
      for (int index = 0; index < Main.Instance.GameplayMenu.ItemOptions.Length; ++index)
        Main.Instance.GameplayMenu.ItemOptions[index].SetActive(false);
    }
    if (this._PartsToUse == null || this._PartsToUse.Count == 0)
      this.Parts[part].Interact(person);
    else
      this._PartsToUse[part].InteractEx(this._PartsUseIndex[part], person);
  }

  public override void StopInteracting()
  {
    for (int index = 0; index < this.Parts.Length; ++index)
      this.Parts[index].StopInteracting();
  }

  public void StopInteracting(Person person, int part = 0) => this.Parts[part].StopInteracting();

  public void WaitForOption()
  {
    if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Tab))
    {
      Main.Instance.Player.RemoveMoveBlocker("MultiOption");
      this.CanInteract = true;
      Main.Instance.MainThreads.Remove(new Action(this.WaitForOption));
      Main.Instance.GameplayMenu.MultiOptions.SetActive(false);
      for (int index = 0; index < Main.Instance.GameplayMenu.ItemOptions.Length; ++index)
        Main.Instance.GameplayMenu.ItemOptions[index].SetActive(false);
      Main.Instance.GameplayMenu.PlayerWeaponSystem.PickupText.text = string.Empty;
      Main.Instance.GameplayMenu.PlayerWeaponSystem.PromptIcon.enabled = false;
    }
    else
    {
      for (int part = 0; part < Main.Instance.GameplayMenu.ItemOptions.Length; ++part)
      {
        if (Main.Instance.GameplayMenu.ItemOptions[part].activeSelf && Input.GetKeyUp((KeyCode) (49 + part)))
        {
          this.Interact(this.PersonWantingToInteract, part);
          Main.Instance.Player.RemoveMoveBlocker("MultiOption");
          this.CanInteract = true;
          Main.Instance.MainThreads.Remove(new Action(this.WaitForOption));
          break;
        }
      }
    }
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    if ((UnityEngine.Object) this.RelaySavingData != (UnityEngine.Object) null)
      this.RelaySavingData.sd_LoadData(Data, SlitChar);
    else if (this.QuickRelayFix)
    {
      this.RelaySavingData = (SaveableBehaviour) this.Parts[0];
      this.RelaySavingData.sd_LoadData(Data, SlitChar);
    }
    else
      base.sd_LoadData(Data, SlitChar);
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    if ((UnityEngine.Object) this.RelaySavingData != (UnityEngine.Object) null)
      return this.RelaySavingData.sd_SaveData(SlitChar);
    if (!this.QuickRelayFix)
      return base.sd_SaveData(SlitChar);
    this.RelaySavingData = (SaveableBehaviour) this.Parts[0];
    return this.RelaySavingData.sd_SaveData(SlitChar);
  }

  public override void sv_LoadData(string Data, char SlitChar = ':', bool removeFirst = true)
  {
    if ((UnityEngine.Object) this.RelaySavingData != (UnityEngine.Object) null)
      this.RelaySavingData.sv_LoadData(Data, SlitChar, removeFirst);
    else if (this.QuickRelayFix)
    {
      this.RelaySavingData = (SaveableBehaviour) this.Parts[0];
      this.RelaySavingData.sv_LoadData(Data, SlitChar, removeFirst);
    }
    else
      base.sv_LoadData(Data, SlitChar, removeFirst);
  }

  public override string sv_SaveData(char SlitChar = ':')
  {
    if ((UnityEngine.Object) this.RelaySavingData != (UnityEngine.Object) null)
      return this.RelaySavingData.sv_SaveData(SlitChar);
    if (!this.QuickRelayFix)
      return base.sv_SaveData(SlitChar);
    this.RelaySavingData = (SaveableBehaviour) this.Parts[0];
    return this.RelaySavingData.sv_SaveData(SlitChar);
  }
}
