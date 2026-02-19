// Decompiled with JetBrains decompiler
// Type: bl_OnTriggerEnterZone
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_OnTriggerEnterZone : MonoBehaviour
{
  public bool disable;
  public bl_HangZone ThisZone;

  public void OnTriggerEnter(Collider other)
  {
    if (other.isTrigger)
      return;
    Person component = other.transform.root.GetComponent<Person>();
    if (!((Object) component != (Object) null))
      return;
    this.ThisZone.EnterZone(component);
  }

  public void OnTriggerExit(Collider other)
  {
    if (other.isTrigger)
      return;
    Person component = other.transform.root.GetComponent<Person>();
    if (!((Object) component != (Object) null))
      return;
    this.ThisZone.ExitZone(component);
  }
}
