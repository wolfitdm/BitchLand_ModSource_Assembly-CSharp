// Decompiled with JetBrains decompiler
// Type: Zoom
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
