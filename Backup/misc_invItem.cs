// Decompiled with JetBrains decompiler
// Type: misc_invItem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class misc_invItem : MonoBehaviour
{
  public Text Title;
  public GameObject OpenBtn;
  public Button DropBtn;
  public GameObject ThisWeapomn;
  public Dressable ThisDressable;
  public bool TraderBtn;
  [Header("Custom")]
  public Action<int> OnClick;
  public int ThisEntry;
  [Header("Backpack inv")]
  public GameObject SendBtn;
  public Int_Storage ThisStorage;
  public GameObject ThisItem;
  public GameObject EquipBtn;

  public void Click_Drop()
  {
    if ((UnityEngine.Object) this.ThisWeapomn != (UnityEngine.Object) null)
    {
      for (int index = 0; index < Main.Instance.Player.WeaponInv.weapons.Count; ++index)
      {
        if ((UnityEngine.Object) this.ThisWeapomn == (UnityEngine.Object) Main.Instance.Player.WeaponInv.weapons[index])
        {
          Main.Instance.Player.WeaponInv.DropWeapon(index);
          break;
        }
      }
    }
    else if ((UnityEngine.Object) this.ThisStorage == (UnityEngine.Object) null)
      Main.Instance.Player.UndressClothe(this.ThisDressable);
    else
      this.ThisStorage.RemoveItem(this.ThisItem);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    Main.Instance.GameplayMenu.SelectInventory();
  }

  public void Click_Opem()
  {
    Main.Instance.GameplayMenu.CloseJournal();
    Main.Instance.GameplayMenu.OpenContainer((Int_Storage) null);
  }

  public void Click_BackPackDrop()
  {
    if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null && Main.Instance.Player.CurrentBackpack.ThisStorage.HasItem(this.ThisWeapomn))
      Main.Instance.Player.CurrentBackpack.ThisStorage.RemoveItem(this.ThisWeapomn);
    else if (Main.Instance.Player.Storage_Hands.HasItem(this.ThisWeapomn))
      Main.Instance.Player.Storage_Hands.RemoveItem(this.ThisWeapomn);
    else if (Main.Instance.Player.Storage_Anal.HasItem(this.ThisWeapomn))
      Main.Instance.Player.Storage_Anal.RemoveItem(this.ThisWeapomn);
    else if (Main.Instance.Player.Storage_Vag.HasItem(this.ThisWeapomn))
      Main.Instance.Player.Storage_Vag.RemoveItem(this.ThisWeapomn);
    Main.Instance.GameplayMenu.RefreshContainer();
  }

  public void Click_BackpackEquip()
  {
    if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null && Main.Instance.Player.CurrentBackpack.ThisStorage.HasItem(this.ThisWeapomn))
      Main.Instance.Player.CurrentBackpack.ThisStorage.RemoveItem(this.ThisWeapomn);
    else if (Main.Instance.Player.Storage_Hands.HasItem(this.ThisWeapomn))
      Main.Instance.Player.Storage_Hands.RemoveItem(this.ThisWeapomn);
    else if (Main.Instance.Player.Storage_Anal.HasItem(this.ThisWeapomn))
      Main.Instance.Player.Storage_Anal.RemoveItem(this.ThisWeapomn);
    else if (Main.Instance.Player.Storage_Vag.HasItem(this.ThisWeapomn))
      Main.Instance.Player.Storage_Vag.RemoveItem(this.ThisWeapomn);
    Main.Instance.Player.DressClothe(this.ThisWeapomn, false);
    Main.Instance.GameplayMenu.RefreshContainer();
  }

  public void Click_PutButton()
  {
    if (this.TraderBtn)
    {
      int_ResourceItem componentInChildren = this.ThisWeapomn.GetComponentInChildren<int_ResourceItem>(true);
      if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null && componentInChildren.Sellable)
      {
        Main.Instance.Player.Money += componentInChildren.SellPrice;
        Main.Instance.Player.CurrentBackpack.ThisStorage.SendTo(this.ThisWeapomn, this.ThisStorage);
      }
    }
    else if (this.ThisStorage is int_personStorage)
    {
      Main.Instance.Player.CurrentBackpack.ThisStorage.RemoveItem(this.ThisWeapomn);
      this.ThisStorage.EquipFromInv(this.ThisWeapomn, (this.ThisStorage as int_personStorage).ThisPerson);
    }
    else if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null && Main.Instance.Player.CurrentBackpack.ThisStorage.HasItem(this.ThisWeapomn))
      Main.Instance.Player.CurrentBackpack.ThisStorage.SendTo(this.ThisWeapomn, this.ThisStorage);
    else if (Main.Instance.Player.Storage_Hands.HasItem(this.ThisWeapomn))
      Main.Instance.Player.Storage_Hands.SendTo(this.ThisWeapomn, this.ThisStorage);
    else if (Main.Instance.Player.Storage_Anal.HasItem(this.ThisWeapomn))
      Main.Instance.Player.Storage_Anal.SendTo(this.ThisWeapomn, this.ThisStorage);
    else if (Main.Instance.Player.Storage_Vag.HasItem(this.ThisWeapomn))
      Main.Instance.Player.Storage_Vag.SendTo(this.ThisWeapomn, this.ThisStorage);
    Main.Instance.GameplayMenu.RefreshContainer();
  }

  public void Click_TakeButton()
  {
    if (this.TraderBtn)
    {
      int_ResourceItem componentInChildren = this.ThisWeapomn.GetComponentInChildren<int_ResourceItem>(true);
      if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null) || !componentInChildren.Sellable)
        return;
      Main.Instance.Player.Money -= componentInChildren.BuyPrice;
      if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack == (UnityEngine.Object) null || Main.Instance.Player.CurrentBackpack.ThisStorage.Full)
        this.ThisStorage.RemoveItem(this.ThisWeapomn);
      else
        this.ThisStorage.SendTo(this.ThisWeapomn, Main.Instance.Player.CurrentBackpack.ThisStorage);
      Main.Instance.GameplayMenu.RefreshContainer();
    }
    else
    {
      int_money component = this.ThisWeapomn.GetComponent<int_money>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        Main.Instance.Player.Money += component.Value;
        this.ThisStorage.StorageItems.Remove(this.ThisWeapomn);
        UnityEngine.Object.Destroy((UnityEngine.Object) this.ThisWeapomn);
        Main.Instance.GameplayMenu.RefreshContainer();
      }
      else
      {
        if (!((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null))
          return;
        if (Main.Instance.Player.CurrentBackpack.ThisStorage.Full)
        {
          Main.Instance.GameplayMenu.ShowNotification("Back pack is full");
        }
        else
        {
          this.ThisStorage.SendTo(this.ThisWeapomn, Main.Instance.Player.CurrentBackpack.ThisStorage);
          Main.Instance.GameplayMenu.RefreshContainer();
        }
      }
    }
  }

  public void Click_EquipContainer()
  {
    this.ThisStorage.EquipFromInv(this.ThisWeapomn);
    Main.Instance.GameplayMenu.RefreshContainer();
  }

  public void Click_DropContainer()
  {
    this.ThisStorage.RemoveItem(this.ThisWeapomn);
    Main.Instance.GameplayMenu.RefreshContainer();
  }

  public void Click_SendInvToBackpack()
  {
    if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.ThisWeapomn != (UnityEngine.Object) null)
      {
        for (int index = 0; index < Main.Instance.Player.WeaponInv.weapons.Count; ++index)
        {
          if ((UnityEngine.Object) this.ThisWeapomn == (UnityEngine.Object) Main.Instance.Player.WeaponInv.weapons[index])
          {
            Main.Instance.Player.WeaponInv.DropWeapon(index);
            Main.Instance.Player.CurrentBackpack.ThisStorage.AddItem(this.ThisWeapomn);
            break;
          }
        }
      }
      else
      {
        GameObject gameObject = Main.Instance.Player.UndressClothe(this.ThisDressable);
        Main.Instance.Player.CurrentBackpack.ThisStorage.AddItem(gameObject);
      }
    }
    UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    Main.Instance.GameplayMenu.SelectInventory();
  }

  public void Click_Custom()
  {
    if (this.OnClick == null)
      return;
    this.OnClick(this.ThisEntry);
  }
}
