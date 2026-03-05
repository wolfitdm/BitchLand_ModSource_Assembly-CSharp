// Decompiled with JetBrains decompiler
// Type: Zoom
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[ExecuteInEditMode]
public class Zoom : MonoBehaviour
{
  private Camera camera;
  public float defaultFOV = 60f;
  public float maxZoomFOV = 15f;
  [Range(0.0f, 1f)]
  public float currentZoom;
  public float sensitivity = 1f;

  private void Awake()
  {
    this.camera = this.GetComponent<Camera>();
    if (!(bool) (Object) this.camera)
      return;
    this.defaultFOV = this.camera.fieldOfView;
  }

  private void Update()
  {
    this.currentZoom += (float) ((double) Input.mouseScrollDelta.y * (double) this.sensitivity * 0.05000000074505806);
    this.currentZoom = Mathf.Clamp01(this.currentZoom);
    this.camera.fieldOfView = Mathf.Lerp(this.defaultFOV, this.maxZoomFOV, this.currentZoom);
  }
}
