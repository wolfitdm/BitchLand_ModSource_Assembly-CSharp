// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Wheel_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP;

public class Wheel_Control_CS : MonoBehaviour
{
  [Header("Driving settings")]
  [Tooltip("Torque added to each wheel.")]
  public float wheelTorque = 3000f;
  [Tooltip("Maximum Speed (Meter per Second)")]
  public float maxSpeed = 7f;
  [Tooltip("Rate for ease of turning.")]
  [Range(0.0f, 2f)]
  public float turnClamp = 0.8f;
  [Tooltip("'Solver Iteration Count' of all the rigidbodies in this tank.")]
  public int solverIterationCount = 7;
  [HideInInspector]
  public float leftRate;
  [HideInInspector]
  public float rightRate;
  private Rigidbody thisRigidbody;
  private bool isParkingBrake;
  private float lagCount;
  private float speedStep;
  private float autoParkingBrakeVelocity = 0.5f;
  private float autoParkingBrakeLag = 0.5f;
  private ID_Control_CS idScript;

  private void Awake()
  {
    this.gameObject.layer = 11;
    this.thisRigidbody = this.GetComponent<Rigidbody>();
    this.thisRigidbody.solverIterations = this.solverIterationCount;
  }

  private void Update()
  {
    if (!this.idScript.isPlayer)
      return;
    this.Desktop_Input();
  }

  private void Desktop_Input()
  {
    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
    {
      this.speedStep += 0.5f;
      this.speedStep = Mathf.Clamp(this.speedStep, -1f, 1f);
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
    {
      this.speedStep -= 0.5f;
      this.speedStep = Mathf.Clamp(this.speedStep, -1f, 1f);
    }
    else if (Input.GetKeyDown(KeyCode.X))
      this.speedStep = 0.0f;
    float speedStep = this.speedStep;
    float axis = Input.GetAxis("Horizontal");
    float max = Mathf.Lerp(this.turnClamp, 1f, Mathf.Abs(speedStep / 1f));
    float num = Mathf.Clamp(axis, -max, max);
    if ((double) speedStep < 0.0)
      num = -num;
    this.leftRate = Mathf.Clamp(-speedStep - num, -1f, 1f);
    this.rightRate = Mathf.Clamp(speedStep - num, -1f, 1f);
  }

  private void FixedUpdate()
  {
    if ((double) this.leftRate == 0.0 && (double) this.rightRate == 0.0)
    {
      float magnitude1 = this.thisRigidbody.velocity.magnitude;
      float magnitude2 = this.thisRigidbody.angularVelocity.magnitude;
      if (!this.isParkingBrake)
      {
        if ((double) magnitude1 >= (double) this.autoParkingBrakeVelocity || (double) magnitude2 >= (double) this.autoParkingBrakeVelocity)
          return;
        this.lagCount += Time.fixedDeltaTime;
        if ((double) this.lagCount <= (double) this.autoParkingBrakeLag)
          return;
        this.isParkingBrake = true;
        this.thisRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;
      }
      else
      {
        if ((double) magnitude1 <= (double) this.autoParkingBrakeVelocity && (double) magnitude2 <= (double) this.autoParkingBrakeVelocity)
          return;
        this.isParkingBrake = false;
        this.thisRigidbody.constraints = RigidbodyConstraints.None;
        this.lagCount = 0.0f;
      }
    }
    else
    {
      this.isParkingBrake = false;
      this.thisRigidbody.constraints = RigidbodyConstraints.None;
      this.lagCount = 0.0f;
    }
  }

  private void Destroy() => this.StartCoroutine("Disable_Constraints");

  private IEnumerator Disable_Constraints()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    Wheel_Control_CS wheelControlCs = this;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      wheelControlCs.thisRigidbody.constraints = RigidbodyConstraints.None;
      Object.Destroy((Object) wheelControlCs);
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E2__current = (object) new WaitForFixedUpdate();
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }

  private void Get_ID_Script(ID_Control_CS tempScript) => this.idScript = tempScript;

  private void Pause(bool isPaused) => this.enabled = !isPaused;
}
