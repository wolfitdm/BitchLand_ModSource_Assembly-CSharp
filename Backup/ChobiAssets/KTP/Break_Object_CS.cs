// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Break_Object_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
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
}
