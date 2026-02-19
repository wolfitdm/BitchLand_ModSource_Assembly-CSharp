// Decompiled with JetBrains decompiler
// Type: bl_OnTriggerEnterZone
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
