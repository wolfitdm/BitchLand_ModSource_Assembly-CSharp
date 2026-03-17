// Decompiled with JetBrains decompiler
// Type: RandomItemsInStorage
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class RandomItemsInStorage : Interactible
{
  public int ItemsAmountMin;
  public int ItemsAmountMax;
  [Tooltip("Not Done")]
  [Obsolete]
  public bool AllowRepeat;
  public GameObject[] RandomItems;
  public Int_Storage Storage;

  public RandomItemsInStorage()
  {
    this.PlayerCanInteract = false;
    this.Despawnable = true;
  }

  public new void Start()
  {
    if (Main.Instance.LoadedGame)
      return;
    this.ResetItems();
  }

  public void ResetItems()
  {
    int num = UnityEngine.Random.Range(this.ItemsAmountMin, this.ItemsAmountMax);
    for (int index = 0; index < num && this.Storage.StorageMax != this.Storage.StorageItems.Count; ++index)
      this.Storage.AddItem(Main.Spawn(this.RandomItems[UnityEngine.Random.Range(0, this.RandomItems.Length)]));
  }

  public override void Despawn()
  {
    this.DespawnTimer = 0.0f;
    this.DespawnTimerChecker = 0.0f;
    for (int index = 0; index < this.Storage.StorageItems.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Storage.StorageItems[index]);
    this.Storage.StorageItems.Clear();
    this.ResetItems();
  }
}
