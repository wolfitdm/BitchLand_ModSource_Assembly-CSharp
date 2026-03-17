// Decompiled with JetBrains decompiler
// Type: Doors
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
