// Decompiled with JetBrains decompiler
// Type: MGAssets.SpinWeapon
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace MGAssets;

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
