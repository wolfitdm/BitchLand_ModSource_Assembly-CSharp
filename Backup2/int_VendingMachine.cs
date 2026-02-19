// Decompiled with JetBrains decompiler
// Type: int_VendingMachine
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_VendingMachine : Interactible
{
  public GameObject[] ItemPrefabs;
  public int ItemCost;
  public Transform ItemSpawn;
  public AudioSource Audio;

  public override void Interact(Person person)
  {
    if (person.Money >= this.ItemCost)
    {
      person.Money -= this.ItemCost;
      this.SpawnItem();
      if (!person.IsPlayer)
        return;
      Main.Instance.GameplayMenu.ShowNotification($"Paid {this.ItemCost.ToString()} Bitch Notes");
    }
    else
    {
      if (!person.IsPlayer)
        return;
      Main.Instance.GameplayMenu.ShowNotification($"You don't have {this.ItemCost.ToString()} Bitch Notes");
    }
  }

  public void SpawnItem()
  {
    Main.Spawn(this.ItemPrefabs[Random.Range(0, this.ItemPrefabs.Length)], saveable: true).transform.SetPositionAndRotation(this.ItemSpawn.position, this.ItemSpawn.rotation);
    if (!((Object) this.Audio != (Object) null))
      return;
    this.Audio.Play();
  }
}
