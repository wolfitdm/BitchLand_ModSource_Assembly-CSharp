// Decompiled with JetBrains decompiler
// Type: AntiFall
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
