// Decompiled with JetBrains decompiler
// Type: CFX_Demo_RotateCamera
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CFX_Demo_RotateCamera : MonoBehaviour
{
  public static bool rotating = true;
  public float speed = 30f;
  public Transform rotationCenter;

  private void Update()
  {
    if (!CFX_Demo_RotateCamera.rotating)
      return;
    this.transform.RotateAround(this.rotationCenter.position, Vector3.up, this.speed * Time.deltaTime);
  }
}
