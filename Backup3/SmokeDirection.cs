// Decompiled with JetBrains decompiler
// Type: SmokeDirection
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class SmokeDirection : MonoBehaviour
{
  [Range(0.0f, 90f)]
  public float SmokeJitteringSpeed = 90f;
  [Range(0.0f, 90f)]
  public float JitterMaximumAngle = 5f;
  [Range(0.0f, 30f)]
  public float RefreshRate = 15f;
  private Vector3 startingEulers;
  private Vector3 newSmokeRotation;
  private Vector3 smokeRotation = Vector3.zero;

  private void Start()
  {
    this.startingEulers = this.transform.localEulerAngles;
    this.StartCoroutine(this.NewRotationTarget());
  }

  private void Update()
  {
    this.smokeRotation = Vector3.MoveTowards(this.smokeRotation, this.newSmokeRotation, this.SmokeJitteringSpeed * Time.deltaTime);
    this.transform.eulerAngles = this.startingEulers + this.smokeRotation;
  }

  private IEnumerator NewRotationTarget()
  {
    while (true)
    {
      this.newSmokeRotation.x = Random.Range(-this.JitterMaximumAngle, this.JitterMaximumAngle);
      this.newSmokeRotation.y = Random.Range(-this.JitterMaximumAngle, this.JitterMaximumAngle);
      this.newSmokeRotation.z = Random.Range(-this.JitterMaximumAngle, this.JitterMaximumAngle);
      if ((double) this.SmokeJitteringSpeed <= 0.0)
        this.SmokeJitteringSpeed = 1f;
      yield return (object) new WaitForSeconds(1f / this.RefreshRate);
    }
  }
}
