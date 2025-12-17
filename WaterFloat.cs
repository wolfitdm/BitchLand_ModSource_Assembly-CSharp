// Decompiled with JetBrains decompiler
// Type: WaterFloat
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class WaterFloat : MonoBehaviour
{
  public float WaterHeight = 15.5f;

  private void Start()
  {
  }

  private void Update()
  {
    if ((double) this.transform.position.y >= (double) this.WaterHeight)
      return;
    this.transform.position = new Vector3(this.transform.position.x, this.WaterHeight, this.transform.position.z);
  }
}
