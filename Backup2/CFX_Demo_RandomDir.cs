// Decompiled with JetBrains decompiler
// Type: CFX_Demo_RandomDir
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CFX_Demo_RandomDir : MonoBehaviour
{
  public Vector3 min = new Vector3(0.0f, 0.0f, 0.0f);
  public Vector3 max = new Vector3(0.0f, 360f, 0.0f);

  private void Awake()
  {
    this.transform.eulerAngles = new Vector3(Random.Range(this.min.x, this.max.x), Random.Range(this.min.y, this.max.y), Random.Range(this.min.z, this.max.z));
  }
}
