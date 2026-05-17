// Decompiled with JetBrains decompiler
// Type: BackPack
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;
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

  public override void SaveToFile(string filename)
  {
    if (this.Equipped)
      return;
    base.SaveToFile(filename);
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) this.base_sd_SaveData(SlitChar));
    stringList.AddRange((IEnumerable<string>) new string[6]
    {
      MethodBase.GetCurrentMethod().DeclaringType.Name,
      "PrefabName",
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
    this.base_sd_LoadData(Data, SlitChar);
    if (this.IsThisAfterV13)
      this._CurrentLoadingIndex = SaveableBehaviour.LineFor(Data, MethodBase.GetCurrentMethod().DeclaringType.Name) + 3;
    else
      this._CurrentLoadingIndex = 2;
    transform.position = Main.ParseVector3(Data[this._CurrentLoadingIndex++]);
    transform.eulerAngles = Main.ParseVector3(Data[this._CurrentLoadingIndex++]);
    int num1 = Data[this._CurrentLoadingIndex++] != "NULL" ? 1 : 0;
    int num2 = int.Parse(Data[this._CurrentLoadingIndex++]);
    for (int index1 = 0; index1 < num2; ++index1)
    {
      string str = Data[this._CurrentLoadingIndex++];
      if (str != null && str.Length != 0)
      {
        if (str.Contains("="))
        {
          string[] Data1 = str.Split("=", StringSplitOptions.None);
          int index2 = 1;
          if (SaveableBehaviour.IsAfterV13(Data1))
            index2 = 5;
          GameObject prefab = Main.Instance.GetPrefab(Data1[index2]);
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
          GameObject prefab = Main.Instance.GetPrefab(str);
          if ((UnityEngine.Object) prefab != (UnityEngine.Object) null)
            this.ThisStorage.AddItem(Main.Spawn(prefab, saveable: true));
        }
      }
    }
  }
}
