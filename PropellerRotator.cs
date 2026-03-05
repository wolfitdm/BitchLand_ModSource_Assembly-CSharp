// Decompiled with JetBrains decompiler
// Type: PropellerRotator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PropellerRotator : MonoBehaviour
{
  [SerializeField]
  private float _speed = 100f;

  private void Update() => this.transform.Rotate(Vector3.forward * this._speed * Time.deltaTime);
}
