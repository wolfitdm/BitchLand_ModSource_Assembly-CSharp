// Decompiled with JetBrains decompiler
// Type: PropellerRotator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PropellerRotator : MonoBehaviour
{
  [SerializeField]
  private float _speed = 100f;

  private void Update() => this.transform.Rotate(Vector3.forward * this._speed * Time.deltaTime);
}
