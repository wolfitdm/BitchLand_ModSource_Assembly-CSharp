// Decompiled with JetBrains decompiler
// Type: KevinIglesias.IKHelperTool
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace KevinIglesias;

public class IKHelperTool : MonoBehaviour
{
  public Transform iKSwitch;
  public Transform handEffector;
  public IKHelperHand hand;
  public Animator animator;
  public float weight;

  private void Awake() => this.weight = 0.0f;

  private void Update()
  {
    this.weight = Mathf.Lerp(0.0f, 1f, 1f - Mathf.Cos((float) ((double) this.iKSwitch.localPosition.y * 3.1415927410125732 * 0.5)));
  }

  private void OnAnimatorIK(int layerIndex)
  {
    if (this.hand == IKHelperHand.LeftHand)
    {
      this.animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
      this.animator.SetIKPosition(AvatarIKGoal.LeftHand, this.handEffector.position);
      this.animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
      this.animator.SetIKRotation(AvatarIKGoal.LeftHand, this.handEffector.rotation);
    }
    else
    {
      this.animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
      this.animator.SetIKPosition(AvatarIKGoal.RightHand, this.handEffector.position);
      this.animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
      this.animator.SetIKRotation(AvatarIKGoal.RightHand, this.handEffector.rotation);
    }
  }
}
