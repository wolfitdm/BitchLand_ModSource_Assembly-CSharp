// Decompiled with JetBrains decompiler
// Type: CFX_Demo_RotateCamera
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
