// Decompiled with JetBrains decompiler
// Type: bl_OnTriggerEnterZone
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
