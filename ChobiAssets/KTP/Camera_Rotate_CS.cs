// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Camera_Rotate_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Camera_Rotate_CS : MonoBehaviour
  {
    private Transform thisTransform;
    private Vector2 previousMousePos;
    private float angY;
    private float angZ;
    private float targetAng_Y;
    private ID_Control_CS idScript;

    private void Awake()
    {
      this.thisTransform = this.transform;
      this.angY = this.thisTransform.eulerAngles.y;
      this.targetAng_Y = this.angY;
      this.angZ = this.thisTransform.eulerAngles.z;
    }

    private void Update()
    {
      if (!this.idScript.isPlayer)
        return;
      this.Desktop_Input();
    }

    private void Desktop_Input() => this.Mouse_Input_Drag(true);

    private void Mouse_Input_Drag(bool isFreeAiming)
    {
      if (!this.idScript.aimButton)
      {
        if (this.idScript.dragButtonDown)
          this.previousMousePos = (Vector2) Input.mousePosition;
        if (this.idScript.dragButton)
        {
          this.targetAng_Y += (float) (((double) Input.mousePosition.x - (double) this.previousMousePos.x) * 0.10000000149011612) * 3f;
          this.angY = this.targetAng_Y;
          this.previousMousePos = (Vector2) Input.mousePosition;
        }
      }
      this.angY = Mathf.MoveTowardsAngle(this.angY, this.targetAng_Y, 180f * Time.deltaTime);
      this.thisTransform.rotation = Quaternion.Euler(0.0f, this.angY, this.angZ);
    }

    private void Get_ID_Script(ID_Control_CS tempScript) => this.idScript = tempScript;

    private void Pause(bool isPaused) => this.enabled = !isPaused;
  }
}
