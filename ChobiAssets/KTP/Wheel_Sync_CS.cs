// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Wheel_Sync_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP;

public class Wheel_Sync_CS : MonoBehaviour
{
  [Header("Wheel Synchronizing settings")]
  [Tooltip("Set the RoadWheel to synchronize with.")]
  public Transform referenceWheel;
  [Tooltip("Offset value for the size of this wheel.")]
  public float radiusOffset;
  private Transform thisTransform;
  private bool isLeft;
  private float previousAng;
  private float radiusRate;

  private void Awake()
  {
    this.thisTransform = this.transform;
    this.isLeft = (double) this.transform.localPosition.y > 0.0;
    if ((Object) this.referenceWheel == (Object) null)
      this.Find_Reference_Wheel();
    MeshFilter component = this.referenceWheel.GetComponent<MeshFilter>();
    if (!(bool) (Object) component)
      return;
    float num = this.GetComponent<MeshFilter>().mesh.bounds.extents.z + this.radiusOffset;
    float z = component.mesh.bounds.extents.z;
    if ((double) z <= 0.0 || (double) num <= 0.0)
      return;
    this.radiusRate = z / num;
  }

  private void Find_Reference_Wheel()
  {
    foreach (Track_Scroll_CS componentsInChild in this.thisTransform.parent.parent.GetComponentsInChildren<Track_Scroll_CS>())
    {
      if (this.isLeft && (double) componentsInChild.referenceWheel.localPosition.y > 0.0 || !this.isLeft && (double) componentsInChild.referenceWheel.localPosition.y < 0.0)
      {
        this.referenceWheel = componentsInChild.referenceWheel;
        break;
      }
    }
    if (!((Object) this.referenceWheel == (Object) null))
      return;
    Debug.LogError((object) ("Reference Wheel is not assigned in " + this.name));
    Object.Destroy((Object) this);
  }

  private void Update()
  {
    if (!(bool) (Object) this.referenceWheel)
      return;
    float y = this.referenceWheel.localEulerAngles.y;
    this.thisTransform.localEulerAngles = new Vector3(this.thisTransform.localEulerAngles.x, this.thisTransform.localEulerAngles.y - this.radiusRate * Mathf.DeltaAngle(y, this.previousAng), this.thisTransform.localEulerAngles.z);
    this.previousAng = y;
  }

  private void Pause(bool isPaused) => this.enabled = !isPaused;
}
