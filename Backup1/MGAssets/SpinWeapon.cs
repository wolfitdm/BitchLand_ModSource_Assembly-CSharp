// Decompiled with JetBrains decompiler
// Type: MGAssets.SpinWeapon
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
