// Decompiled with JetBrains decompiler
// Type: DitzelGames.FastIK.SampleProcedualAnimation
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DitzelGames.FastIK;

internal class SampleProcedualAnimation : MonoBehaviour
{
  public Transform[] FootTarget;
  public Transform LookTarget;
  public Transform HandTarget;
  public Transform HandPole;
  public Transform Step;
  public Transform Attraction;

  public void LateUpdate()
  {
    this.Step.Translate(Vector3.forward * Time.deltaTime * 0.7f);
    if ((double) this.Step.position.z > 1.0)
      this.Step.position += Vector3.forward * -2f;
    this.Attraction.Translate(Vector3.forward * Time.deltaTime * 0.5f);
    if ((double) this.Attraction.position.z > 1.0)
      this.Attraction.position += Vector3.forward * -2f;
    for (int index = 0; index < this.FootTarget.Length; ++index)
    {
      Transform transform = this.FootTarget[index];
      Ray ray = new Ray(transform.transform.position + Vector3.up * 0.5f, Vector3.down);
      RaycastHit raycastHit = new RaycastHit();
      ref RaycastHit local = ref raycastHit;
      if (Physics.SphereCast(ray, 0.05f, out local, 0.5f))
        transform.position = raycastHit.point + Vector3.up * 0.05f;
    }
    float t = Mathf.Clamp((float) (((double) Vector3.Distance(this.LookTarget.position, this.Attraction.position) - 0.30000001192092896) / 1.0), 0.0f, 1f);
    this.HandTarget.rotation = Quaternion.Lerp(Quaternion.Euler(90f, 0.0f, 0.0f), this.HandTarget.rotation, t);
    this.HandTarget.position = Vector3.Lerp(this.Attraction.position, this.HandTarget.position, t);
    this.HandPole.position = Vector3.Lerp(this.HandTarget.position + Vector3.down * 2f, this.HandTarget.position + Vector3.forward * 2f, t);
    this.LookTarget.position = Vector3.Lerp(this.Attraction.position, this.LookTarget.position, t);
  }
}
