// Decompiled with JetBrains decompiler
// Type: RadarRotation
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RadarRotation : MonoBehaviour
{
  public float Speed = 100f;

  private void Update() => this.transform.Rotate(Vector3.up, this.Speed * Time.deltaTime);
}
