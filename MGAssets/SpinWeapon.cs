// Decompiled with JetBrains decompiler
// Type: MGAssets.SpinWeapon
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace MGAssets
{
  public class SpinWeapon : MonoBehaviour
  {
    public bool isActive = true;
    public float factor = 1f;
    public Vector3 angularSpeed = new Vector3(0.0f, 100f, 0.0f);

    private void Update()
    {
      if (!this.isActive)
        return;
      this.transform.Rotate(this.factor * this.angularSpeed * Time.deltaTime);
    }
  }
}
