// Decompiled with JetBrains decompiler
// Type: WaterFloat
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
