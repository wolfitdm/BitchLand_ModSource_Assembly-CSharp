// Decompiled with JetBrains decompiler
// Type: AntiFall
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
