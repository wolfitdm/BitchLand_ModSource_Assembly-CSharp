// Decompiled with JetBrains decompiler
// Type: AntiFall
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class AntiFall : MonoBehaviour
{
  public void OnTriggerEnter(Collider other)
  {
    Transform root = other.transform.root;
    root.position = new Vector3(root.position.x, 15f, root.position.z);
    root.GetComponent<Rigidbody>().velocity = Vector3.zero;
  }
}
