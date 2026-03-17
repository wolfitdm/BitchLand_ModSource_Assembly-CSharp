// Decompiled with JetBrains decompiler
// Type: MGAssets.SpinWeapon
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
