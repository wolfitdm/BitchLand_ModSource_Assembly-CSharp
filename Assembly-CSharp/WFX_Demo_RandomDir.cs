// Decompiled with JetBrains decompiler
// Type: WFX_Demo_RandomDir
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class WFX_Demo_RandomDir : MonoBehaviour
{
  public Vector3 min = new Vector3(0.0f, 0.0f, 0.0f);
  public Vector3 max = new Vector3(0.0f, 360f, 0.0f);

  private void Awake()
  {
    this.transform.eulerAngles = new Vector3(Random.Range(this.min.x, this.max.x), Random.Range(this.min.y, this.max.y), Random.Range(this.min.z, this.max.z));
  }
}
