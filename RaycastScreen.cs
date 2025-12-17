// Decompiled with JetBrains decompiler
// Type: RaycastScreen
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RaycastScreen : MonoBehaviour
{
  public LayerMask layerMask;
  public Collider col;
  public Camera _camera;
  public int _horizontalRays = 7;
  public int _verticalRays = 6;
  public float _raycastDistance = 100f;
  public int Frames;

  private void Update()
  {
    --this.Frames;
    if (this.Frames > 0)
      return;
    this.Frames = 5;
    float num1 = (float) Screen.width / ((float) this._horizontalRays + 1f);
    float num2 = (float) Screen.height / ((float) this._verticalRays + 1f);
    for (int index1 = 1; index1 <= this._horizontalRays; ++index1)
    {
      for (int index2 = 1; index2 <= this._verticalRays; ++index2)
      {
        RaycastHit hitInfo;
        if (Physics.Raycast(this._camera.ScreenPointToRay(new Vector3((float) index1 * num1, (float) index2 * num2, 0.0f)), out hitInfo, this._raycastDistance, (int) this.layerMask, QueryTriggerInteraction.Collide))
        {
          bl_LocalLOD component = hitInfo.collider.GetComponent<bl_LocalLOD>();
          if ((Object) component != (Object) null)
            component.Show();
        }
      }
    }
  }
}
