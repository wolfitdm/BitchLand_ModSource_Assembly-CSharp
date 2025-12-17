// Decompiled with JetBrains decompiler
// Type: Int_Storage
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Int_Storage : int_Lockable
{
  [Header("    Storage")]
  public int StorageMax;
  public List<GameObject> StorageItems = new List<GameObject>();
  public Transform StorageObj;
  public AudioSource Sound;
  public AudioClip OpenSound;
  public AudioClip CloseSound;
  public Transform DropSpot;
  public bool AllowMoney;

  public bool Full => this.StorageItems.Count >= this.StorageMax;

  public bool Empty => this.StorageItems.Count == 0;

  public override void Interact(Person person)
  {
    if (!this.Locked)
    {
      base.Interact(person);
      Main.Instance.GameplayMenu.OpenContainer(this);
      if (!((UnityEngine.Object) this.OpenSound != (UnityEngine.Object) null))
        return;
      if ((UnityEngine.Object) this.Sound == (UnityEngine.Object) null)
        this.Sound = Main.Instance.Player.PersonAudio;
      this.Sound.clip = this.OpenSound;
      this.Sound.Play();
    }
    else
    {
      if (!((UnityEngine.Object) this.Sound != (UnityEngine.Object) null))
        return;
      this.Sound.clip = Main.Instance.DoorLocked;
      this.Sound.Play();
    }
  }

  public virtual void AddItem(GameObject item, Vector3 pos, Vector3 rot)
  {
    this.AddItem(item);
    item.transform.localPosition = pos;
    item.transform.localEulerAngles = rot;
  }

  public virtual void AddItem(GameObject item)
  {
    item.transform.SetParent(this.StorageObj);
    item.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    Rigidbody componentInChildren1 = item.GetComponentInChildren<Rigidbody>(false);
    Collider componentInChildren2 = item.GetComponentInChildren<Collider>(false);
    if ((UnityEngine.Object) componentInChildren1 != (UnityEngine.Object) null)
      componentInChildren1.isKinematic = true;
    if ((UnityEngine.Object) componentInChildren2 != (UnityEngine.Object) null)
      componentInChildren2.enabled = false;
    this.StorageItems.Add(item);
  }

  public virtual void RemoveItem(GameObject item)
  {
    if ((UnityEngine.Object) this.DropSpot != (UnityEngine.Object) null)
      item.transform.SetPositionAndRotation(this.DropSpot.position, this.DropSpot.rotation);
    else
      item.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    item.transform.SetParent((Transform) null, true);
    Rigidbody componentInChildren1 = item.GetComponentInChildren<Rigidbody>(false);
    Collider componentInChildren2 = item.GetComponentInChildren<Collider>(false);
    if ((UnityEngine.Object) componentInChildren1 != (UnityEngine.Object) null)
      componentInChildren1.isKinematic = false;
    if ((UnityEngine.Object) componentInChildren2 != (UnityEngine.Object) null)
      componentInChildren2.enabled = true;
    this.StorageItems.Remove(item);
    item.SetActive(true);
  }

  public virtual void RemoveAllItems()
  {
    List<GameObject> gameObjectList = new List<GameObject>();
    gameObjectList.AddRange((IEnumerable<GameObject>) this.StorageItems);
    for (int index = 0; index < gameObjectList.Count; ++index)
      this.RemoveItem(gameObjectList[index]);
  }

  public virtual void SendTo(GameObject item, Int_Storage storage)
  {
    this.RemoveItem(item);
    storage.AddItem(item);
  }

  public virtual void EquipFromInv(GameObject item)
  {
    this.EquipFromInv(item, Main.Instance.Player);
  }

  public virtual void EquipFromInv(GameObject item, Person person)
  {
    this.RemoveItem(item);
    person.DressClothe(item, false);
  }

  public virtual bool HasItem(string itemName)
  {
    for (int index = 0; index < this.StorageItems.Count; ++index)
    {
      if (this.StorageItems[index].name == itemName)
        return true;
    }
    return false;
  }

  public virtual bool HasItem(GameObject item)
  {
    for (int index = 0; index < this.StorageItems.Count; ++index)
    {
      if ((UnityEngine.Object) this.StorageItems[index] == (UnityEngine.Object) item)
        return true;
    }
    return false;
  }

  public virtual bool HasAnyOfItems(params string[] itemNames)
  {
    for (int index1 = 0; index1 < itemNames.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.StorageItems.Count; ++index2)
      {
        if (this.StorageItems[index2].name == itemNames[index1])
          return true;
      }
    }
    return false;
  }

  public virtual List<GameObject> GetOfItem(string itemName)
  {
    List<GameObject> ofItem = new List<GameObject>();
    for (int index = 0; index < this.StorageItems.Count; ++index)
    {
      if (this.StorageItems[index].name == itemName)
        ofItem.Add(this.StorageItems[index]);
    }
    return ofItem;
  }

  public virtual List<GameObject> GetOfItems(params string[] itemNames)
  {
    List<GameObject> ofItems = new List<GameObject>();
    for (int index1 = 0; index1 < itemNames.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.StorageItems.Count; ++index2)
      {
        if (this.StorageItems[index2].name == itemNames[index1])
          ofItems.Add(this.StorageItems[index2]);
      }
    }
    return ofItems;
  }

  public virtual List<GameObject> GetItemsOfType(e_ResourceType ingredientType)
  {
    List<GameObject> itemsOfType = new List<GameObject>();
    for (int index = 0; index < this.StorageItems.Count; ++index)
    {
      int_ResourceItem componentInChildren = this.StorageItems[index].GetComponentInChildren<int_ResourceItem>(true);
      if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null && componentInChildren.ResourceType == ingredientType)
        itemsOfType.Add(this.StorageItems[index]);
    }
    return itemsOfType;
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(this.StorageItems.Count.ToString());
    for (int index = 0; index < this.StorageItems.Count; ++index)
    {
      if ((UnityEngine.Object) this.StorageItems[index] != (UnityEngine.Object) null)
      {
        Interactible component = this.StorageItems[index].GetComponent<Interactible>();
        if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        {
          Debug.LogError((object) "_int == null");
          Debug.LogError((object) this.StorageItems[index].name);
          Debug.LogError((object) this.transform.name);
          Debug.LogError((object) this.transform.root.name);
        }
        else
          stringList.Add(component.sv_SaveData('='));
      }
    }
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    for (int index = 0; index < this.StorageItems.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.StorageItems[index]);
    this.StorageItems.Clear();
    int num = int.Parse(Data[this._CurrentLoadingIndex++]);
    for (int index1 = 0; index1 < num; ++index1)
    {
      try
      {
        string str = Data[this._CurrentLoadingIndex++];
        if (str != null)
        {
          if (str.Length != 0)
          {
            if (str.Contains("="))
            {
              string[] Data1 = str.Split("=", StringSplitOptions.None);
              for (int index2 = 0; index2 < Main.Instance.AllPrefabs.Count; ++index2)
              {
                if (Main.Instance.AllPrefabs[index2].name == Data1[1])
                {
                  GameObject gameObject = Main.Spawn(Main.Instance.AllPrefabs[index2], saveable: true);
                  Interactible component = gameObject.GetComponent<Interactible>();
                  if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                    component.sd_LoadData(Data1, '=');
                  this.AddItem(gameObject);
                  break;
                }
              }
            }
            else
            {
              for (int index3 = 0; index3 < Main.Instance.AllPrefabs.Count; ++index3)
              {
                if (Main.Instance.AllPrefabs[index3].name == str)
                {
                  this.AddItem(Main.Spawn(Main.Instance.AllPrefabs[index3], saveable: true));
                  break;
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Main.Log($"{ex.Message}\n{ex.StackTrace}");
      }
    }
  }
}
