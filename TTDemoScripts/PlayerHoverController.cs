// Decompiled with JetBrains decompiler
// Type: TTDemoScripts.PlayerHoverController
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace TTDemoScripts;

public class PlayerHoverController : MonoBehaviour
{
  public float forwardSpeed = 10f;
  public float strafeSpeed = 10f;
  public float runMultiplier = 2f;
  public KeyCode runKey = KeyCode.LeftShift;
  public LayerMask groundLayer;
  private RaycastHit hit;
  private float hoverHeight;

  private void Awake()
  {
  }

  private void Update()
  {
    float z = (float) ((double) Input.GetAxis("Vertical") * (double) this.forwardSpeed * (Input.GetKey(this.runKey) ? (double) this.runMultiplier : 1.0)) * Time.deltaTime;
    float x = Input.GetAxis("Horizontal") * this.strafeSpeed * Time.deltaTime;
    if (Physics.Raycast(this.transform.position + Vector3.up * 9999f, Vector3.down, out this.hit, float.PositiveInfinity, (int) this.groundLayer))
      this.hoverHeight = this.hit.point.y + 1.8f;
    this.transform.Translate(new Vector3(x, (float) ((double) this.hoverHeight - (double) this.transform.position.y + 1.7999999523162842), z));
  }
}
