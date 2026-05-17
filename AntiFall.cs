// Decompiled with JetBrains decompiler
// Type: AntiFall
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class AntiFall : MonoBehaviour
{
  public void OnTriggerEnter(Collider other)
  {
    Transform root = other.transform.root;
    root.position = new Vector3(root.position.x, 15f, root.position.z);
    root.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
  }
}
