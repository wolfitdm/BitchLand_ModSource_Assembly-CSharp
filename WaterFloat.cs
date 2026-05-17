// Decompiled with JetBrains decompiler
// Type: WaterFloat
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
