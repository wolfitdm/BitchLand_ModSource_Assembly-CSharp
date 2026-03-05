// Decompiled with JetBrains decompiler
// Type: BackPack
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class BackPack : Dressable
{
  [Header("     BackPack")]
  public Int_Storage ThisStorage;
  public MultiInteractible ThisMulti;

  public override bool CanSave => true;

  public override void OnUndressed()
  {
    base.OnUndressed();
    this.ThisMulti.CanInteract = true;
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) new string[5]
    {
      this.WorldSaveID,
      this.OriginalPrefab.name,
      Main.Vector32Str(this.ThisMulti.RootObj.transform.position),
      Main.Vector32Str(this.ThisMulti.RootObj.transform.eulerAngles),
      this.Equipped ? this.PersonEquipped.WorldSaveID : "NULL"
    });
    stringList.Add(this.ThisStorage.StorageItems.Count.ToString());
    for (int index = 0; index < this.ThisStorage.StorageItems.Count; ++index)
    {
      string str = this.ThisStorage.StorageItems[index].name;
      Interactible component = this.ThisStorage.StorageItems[index].GetComponent<Interactible>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        str = component.sv_SaveData('=');
      stringList.Add(str);
    }
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    Transform transform = this.transform;
    transform.position = Main.ParseVector3(Data[2]);
    transform.eulerAngles = Main.ParseVector3(Data[3]);
    string str1 = Data[4];
    if (str1 != "NULL")
    {
      for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
      {
        if (Main.Instance.SpawnedPeople[index].WorldSaveID == str1)
        {
          Main.Instance.SpawnedPeople[index].DressClothe(this.gameObject, false);
          break;
        }
      }
    }
    this._CurrentLoadingIndex = 5;
    int num = int.Parse(Data[this._CurrentLoadingIndex++]);
    for (int index = 0; index < num; ++index)
    {
      string str2 = Data[this._CurrentLoadingIndex++];
      if (str2 != null && str2.Length != 0)
      {
        if (str2.Contains("="))
        {
          string[] Data1 = str2.Split("=", StringSplitOptions.None);
          GameObject prefab = Main.Instance.GetPrefab(Data1[1]);
          if ((UnityEngine.Object) prefab != (UnityEngine.Object) null)
          {
            GameObject gameObject = Main.Spawn(prefab, saveable: true);
            Interactible component = gameObject.GetComponent<Interactible>();
            if ((UnityEngine.Object) component != (UnityEngine.Object) null)
              component.sd_LoadData(Data1, '=');
            this.ThisStorage.AddItem(gameObject);
          }
        }
        else
        {
          GameObject prefab = Main.Instance.GetPrefab(str2);
          if ((UnityEngine.Object) prefab != (UnityEngine.Object) null)
            this.ThisStorage.AddItem(Main.Spawn(prefab, saveable: true));
        }
      }
    }
  }
}
