// Decompiled with JetBrains decompiler
// Type: WaterFloat
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
