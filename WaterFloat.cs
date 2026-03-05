// Decompiled with JetBrains decompiler
// Type: WaterFloat
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
