// Decompiled with JetBrains decompiler
// Type: int_personStorage
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_personStorage : Int_Storage
{
  public Person ThisPerson;

  public override void AddItem(GameObject item)
  {
    if ((Object) item == (Object) null)
      return;
    MultiInteractible component = item.GetComponent<MultiInteractible>();
    if ((Object) component != (Object) null && (Object) component.Parts[0].gameObject.GetComponent<int_PickableClothingPackage>() != (Object) null)
      this.ThisPerson.DressClothe(item);
    else if ((Object) item.GetComponent<Dressable>() != (Object) null)
      this.ThisPerson.DressClothe(item);
    else
      base.AddItem(item);
  }

  public override void RemoveItem(GameObject item)
  {
    if ((Object) item == (Object) null)
      return;
    Dressable component = item.GetComponent<Dressable>();
    if ((Object) component != (Object) null)
      this.ThisPerson.UndressClothe(component);
    else
      base.RemoveItem(item);
  }

  public override void SendTo(GameObject item, Int_Storage storage)
  {
    GameObject gameObject = this.ThisPerson.UndressClothe(item.GetComponent<Dressable>());
    Main.Instance.Player.CurrentBackpack.ThisStorage.AddItem(gameObject);
  }

  public override void EquipFromInv(GameObject item)
  {
    GameObject prefab = this.ThisPerson.UndressClothe(item.GetComponent<Dressable>());
    Main.Instance.Player.DressClothe(prefab);
  }
}
