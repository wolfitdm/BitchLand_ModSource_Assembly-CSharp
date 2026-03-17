// Decompiled with JetBrains decompiler
// Type: bl_OnTriggerEnterZone
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
