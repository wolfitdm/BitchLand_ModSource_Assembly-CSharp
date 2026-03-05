// Decompiled with JetBrains decompiler
// Type: Vibration
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class Vibration : MonoBehaviour
{
  public bool vibrateOnAwake = true;
  public Vector3 startingShakeDistance;
  public Quaternion startingRotationAmount;
  public float shakeSpeed = 60f;
  public float decreaseMultiplier = 0.5f;
  public int numberOfShakes = 8;
  public bool shakeContinuous;
  private Vector3 actualStartingShakeDistance;
  private Quaternion actualStartingRotationAmount;
  private float actualShakeSpeed;
  private float actualDecreaseMultiplier;
  private int actualNumberOfShakes;
  private Vector3 originalPosition;
  private Quaternion originalRotation;

  private void Awake()
  {
    this.originalPosition = this.transform.localPosition;
    this.originalRotation = this.transform.localRotation;
    if (!this.vibrateOnAwake)
      return;
    this.StartShaking();
  }

  public void StartShaking()
  {
    this.actualStartingShakeDistance = this.startingShakeDistance;
    this.actualStartingRotationAmount = this.startingRotationAmount;
    this.actualShakeSpeed = this.shakeSpeed;
    this.actualDecreaseMultiplier = this.decreaseMultiplier;
    this.actualNumberOfShakes = this.numberOfShakes;
    this.StopShaking();
    this.StartCoroutine("Shake");
  }

  public void StartShaking(
    Vector3 shakeDistance,
    Quaternion rotationAmount,
    float speed,
    float diminish,
    int numOfShakes)
  {
    this.actualStartingShakeDistance = shakeDistance;
    this.actualStartingRotationAmount = rotationAmount;
    this.actualShakeSpeed = speed;
    this.actualDecreaseMultiplier = diminish;
    this.actualNumberOfShakes = numOfShakes;
    this.StopShaking();
    this.StartCoroutine("Shake");
  }

  public void StartShakingRandom(
    float minDistance,
    float maxDistance,
    float minRotationAmount,
    float maxRotationAmount)
  {
    this.actualStartingShakeDistance = new Vector3(Random.Range(minDistance, maxDistance), Random.Range(minDistance, maxDistance), Random.Range(minDistance, maxDistance));
    this.actualStartingRotationAmount = new Quaternion(Random.Range(minRotationAmount, maxRotationAmount), Random.Range(minRotationAmount, maxRotationAmount), Random.Range(minRotationAmount, maxRotationAmount), 1f);
    this.actualShakeSpeed = this.shakeSpeed * Random.Range(0.8f, 1.2f);
    this.actualDecreaseMultiplier = this.decreaseMultiplier * Random.Range(0.8f, 1.2f);
    this.actualNumberOfShakes = this.numberOfShakes + Random.Range(-2, 2);
    this.StopShaking();
    this.StartCoroutine("Shake");
  }

  public void StopShaking()
  {
    this.StopCoroutine("Shake");
    this.transform.localPosition = this.originalPosition;
    this.transform.localRotation = this.originalRotation;
  }

  private IEnumerator Shake()
  {
    Vibration vibration = this;
    vibration.originalPosition = vibration.transform.localPosition;
    vibration.originalRotation = vibration.transform.localRotation;
    float hitTime = Time.time;
    float shake = (float) vibration.actualNumberOfShakes;
    float shakeDistanceX = vibration.actualStartingShakeDistance.x;
    float shakeDistanceY = vibration.actualStartingShakeDistance.y;
    float shakeDistanceZ = vibration.actualStartingShakeDistance.z;
    float shakeRotationX = vibration.actualStartingRotationAmount.x;
    float shakeRotationY = vibration.actualStartingRotationAmount.y;
    float shakeRotationZ = vibration.actualStartingRotationAmount.z;
    while ((double) shake > 0.0 || vibration.shakeContinuous)
    {
      float f = (Time.time - hitTime) * vibration.actualShakeSpeed;
      float x1 = vibration.originalPosition.x + Mathf.Sin(f) * shakeDistanceX;
      float y1 = vibration.originalPosition.y + Mathf.Sin(f) * shakeDistanceY;
      float z1 = vibration.originalPosition.z + Mathf.Sin(f) * shakeDistanceZ;
      float x2 = vibration.originalRotation.x + Mathf.Sin(f) * shakeRotationX;
      float y2 = vibration.originalRotation.y + Mathf.Sin(f) * shakeRotationY;
      float z2 = vibration.originalRotation.z + Mathf.Sin(f) * shakeRotationZ;
      vibration.transform.localPosition = new Vector3(x1, y1, z1);
      vibration.transform.localRotation = new Quaternion(x2, y2, z2, 1f);
      if ((double) f > 6.2831854820251465)
      {
        hitTime = Time.time;
        shakeDistanceX *= vibration.actualDecreaseMultiplier;
        shakeDistanceY *= vibration.actualDecreaseMultiplier;
        shakeDistanceZ *= vibration.actualDecreaseMultiplier;
        shakeRotationX *= vibration.actualDecreaseMultiplier;
        shakeRotationY *= vibration.actualDecreaseMultiplier;
        shakeRotationZ *= vibration.actualDecreaseMultiplier;
        --shake;
      }
      yield return (object) true;
    }
    vibration.transform.localPosition = vibration.originalPosition;
    vibration.transform.localRotation = vibration.originalRotation;
  }
}
