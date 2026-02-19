// Decompiled with JetBrains decompiler
// Type: EnemyPlane
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
