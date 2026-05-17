// Decompiled with JetBrains decompiler
// Type: EnemyPlane
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class EnemyPlane : MonoBehaviour
{
  public float Speed;
  public float TurnRate;

  private void FixedUpdate()
  {
    this.transform.Rotate(0.0f, this.TurnRate * Time.deltaTime, 0.0f);
    this.transform.Translate(0.0f, 0.0f, this.Speed * Time.deltaTime);
  }
}
