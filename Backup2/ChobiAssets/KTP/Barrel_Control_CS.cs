// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Barrel_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP;

public class Barrel_Control_CS : MonoBehaviour
{
  [Header("Recoil Brake settings")]
  [Tooltip("Time it takes to push back the barrel. (Sec)")]
  public float recoilTime = 0.2f;
  [Tooltip("Time it takes to to return the barrel. (Sec)")]
  public float returnTime = 1f;
  [Tooltip("Movable length for the recoil brake. (Meter)")]
  public float length = 0.3f;
  private Transform thisTransform;
  private bool isReady = true;
  private Vector3 initialPos;
  private const float HALF_PI = 1.57079637f;

  private void Awake()
  {
    this.thisTransform = this.transform;
    this.initialPos = this.thisTransform.localPosition;
  }

  private IEnumerator Recoil_Brake()
  {
    float count = 0.0f;
    while ((double) count < (double) this.recoilTime)
    {
      this.thisTransform.localPosition = new Vector3(this.initialPos.x, this.initialPos.y, this.initialPos.z - Mathf.Sin((float) (1.5707963705062866 * ((double) count / (double) this.recoilTime))) * this.length);
      count += Time.deltaTime;
      yield return (object) null;
    }
    count = 0.0f;
    while ((double) count < (double) this.returnTime)
    {
      this.thisTransform.localPosition = new Vector3(this.initialPos.x, this.initialPos.y, this.initialPos.z - Mathf.Sin((float) (1.5707963705062866 * ((double) count / (double) this.returnTime) + 1.5707963705062866)) * this.length);
      count += Time.deltaTime;
      yield return (object) null;
    }
    this.isReady = true;
  }

  public void Fire()
  {
    if (!this.isReady)
      return;
    this.isReady = false;
    this.StartCoroutine("Recoil_Brake");
  }
}
