// Decompiled with JetBrains decompiler
// Type: WFX_Demo_RandomDir
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
