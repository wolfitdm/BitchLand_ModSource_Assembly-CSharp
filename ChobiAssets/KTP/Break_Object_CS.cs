// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Break_Object_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP;

public class Break_Object_CS : MonoBehaviour
{
  [Header("Broken object settings")]
  [Tooltip("Prefab of the broken object.")]
  public GameObject brokenPrefab;
  [Tooltip("Lag time for breaking. (Sec)")]
  public float lagTime = 1f;
  private Transform thisTransform;

  private void Awake() => this.thisTransform = this.transform;

  private void OnJointBreak() => this.StartCoroutine("Broken");

  private void OnTriggerEnter(Collider collider)
  {
    if (collider.isTrigger)
      return;
    this.StartCoroutine("Broken");
  }

  private IEnumerator Broken()
  {
    Break_Object_CS breakObjectCs = this;
    yield return (object) new WaitForSeconds(breakObjectCs.lagTime);
    if ((bool) (Object) breakObjectCs.brokenPrefab)
      Object.Instantiate<GameObject>(breakObjectCs.brokenPrefab, breakObjectCs.thisTransform.position, breakObjectCs.thisTransform.rotation);
    Object.Destroy((Object) breakObjectCs.gameObject);
  }
}
