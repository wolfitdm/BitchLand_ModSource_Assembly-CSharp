// Decompiled with JetBrains decompiler
// Type: Random_touch
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Random_touch : MonoBehaviour
{
  private System.Random rand;

  private void Start()
  {
    for (int index = 0; index < this.transform.childCount; ++index)
    {
      this.rand = new System.Random(this.transform.GetChild(index).GetInstanceID());
      float num1 = (float) this.rand.Next(500) / 100f;
      this.transform.GetChild(index).transform.Rotate(new Vector3(0.0f, 1f, 0.0f) * num1);
      float num2 = (float) this.rand.Next(500) / 100f;
      this.transform.GetChild(index).transform.Rotate(new Vector3(1f, 0.0f, 0.0f) * num2);
      float num3 = (float) this.rand.Next(500) / 100f;
      this.transform.GetChild(index).transform.Rotate(new Vector3(0.0f, 0.0f, 1f) * num3);
    }
  }
}
