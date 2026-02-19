// Decompiled with JetBrains decompiler
// Type: int_PickupToHand
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class int_PickupToHand : Interactible
{
  public Vector3 ItemLocalPos;
  public Vector3 ItemLocalRot;
  public bool DisplayInHole;
  public Vector3 VagItemLocalPos;
  public Vector3 VagItemLocalRot;

  public int_PickupToHand()
  {
    this._AvailableUses = new bool[3];
    this._InteractTexts = new string[3]
    {
      "Pickup (Hands)",
      "Pickup (Vagina)",
      "Pickup (Anal)"
    };
  }

  public override bool CheckCanInteract(Person person)
  {
    bool flag = false;
    if (!person.Storage_Hands.Full)
    {
      this.InteractText = "Pickup (Hands)";
      this._AvailableUses[0] = true;
      flag = true;
    }
    if (person.Perks.Contains("Vaginal Storage") && !person.Storage_Vag.Full)
    {
      this._AvailableUses[1] = true;
      flag = true;
    }
    if (person.Perks.Contains("Anal Storage") && !person.Storage_Anal.Full)
    {
      this._AvailableUses[2] = true;
      flag = true;
    }
    return flag;
  }

  public override void Interact(Person person)
  {
    if (!this.CheckCanInteract(person))
      return;
    this.InteractingPerson = person;
    switch (this._SelectedUseIndex)
    {
      case 0:
        if (person.Storage_Hands.Full)
          break;
        this.EquipToHand(person);
        break;
      case 1:
        if (!person.Perks.Contains("Vaginal Storage") || person.Storage_Vag.Full)
          break;
        this.EquipToVag(person);
        break;
      case 2:
        if (!person.Perks.Contains("Anal Storage") || person.Storage_Anal.Full)
          break;
        this.EquipToAss(person);
        break;
    }
  }

  public void EquipToHand(Person person)
  {
    person.Storage_Hands.AddItem(this.RootObj, this.ItemLocalPos, this.ItemLocalRot);
    if (!person.IsPlayer)
      return;
    Main.Instance.GameplayMenu.QLeave.SetActive(true);
    Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Drop";
    Main.Instance.MainThreads.Add(new Action(this.HoldingThread));
  }

  public void EquipToVag(Person person)
  {
    person.Storage_Vag.AddItem(this.RootObj, this.VagItemLocalPos, this.VagItemLocalRot);
    if (this.DisplayInHole)
      return;
    this.RootObj.SetActive(false);
  }

  public void EquipToAss(Person person)
  {
    person.Storage_Anal.AddItem(this.RootObj, this.VagItemLocalPos, this.VagItemLocalRot);
    if (this.DisplayInHole)
      return;
    this.RootObj.SetActive(false);
  }

  public void HoldingThread()
  {
    if (!Main.Instance.Player.Storage_Hands.StorageItems.Contains(this.RootObj))
    {
      Main.Instance.MainThreads.Remove(new Action(this.HoldingThread));
      if (!(Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text == "Drop"))
        return;
      Main.Instance.GameplayMenu.QLeave.SetActive(false);
      Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Leave";
    }
    else
    {
      if (Main.Instance.Player.Interacting)
        return;
      if (!Input.GetKeyUp(KeyCode.Q))
        return;
      try
      {
        Main.Instance.Player.Storage_Hands.RemoveItem(this.RootObj);
      }
      catch
      {
        try
        {
          Main.Instance.Player.Storage_Hands.RemoveItem(Main.Instance.Player.Storage_Hands.StorageItems[0]);
        }
        catch
        {
        }
      }
      Main.Instance.MainThreads.Remove(new Action(this.HoldingThread));
      Main.Instance.GameplayMenu.QLeave.SetActive(false);
      Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Leave";
    }
  }
}
