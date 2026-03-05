// Decompiled with JetBrains decompiler
// Type: Random_touch
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
