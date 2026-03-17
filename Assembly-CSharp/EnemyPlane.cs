// Decompiled with JetBrains decompiler
// Type: EnemyPlane
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
