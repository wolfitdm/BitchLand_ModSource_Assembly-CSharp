// Decompiled with JetBrains decompiler
// Type: AntiFall
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
