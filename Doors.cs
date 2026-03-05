// Decompiled with JetBrains decompiler
// Type: Doors
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Doors : MonoBehaviour
{
  private void OnTriggerEnter(Collider coll)
  {
    if (!(coll.tag == "Player"))
      return;
    this.GetComponent<Animator>().Play("Door_open");
    this.enabled = false;
  }
}
