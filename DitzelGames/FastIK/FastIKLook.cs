// Decompiled with JetBrains decompiler
// Type: DitzelGames.FastIK.FastIKLook
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DitzelGames.FastIK;

public class FastIKLook : MonoBehaviour
{
  public Transform Target;
  protected Vector3 StartDirection;
  protected Quaternion StartRotation;

  private void Awake()
  {
    if ((Object) this.Target == (Object) null)
      return;
    this.StartDirection = this.Target.position - this.transform.position;
    this.StartRotation = this.transform.rotation;
  }

  private void Update()
  {
    if ((Object) this.Target == (Object) null)
      return;
    this.transform.rotation = Quaternion.FromToRotation(this.StartDirection, this.Target.position - this.transform.position) * this.StartRotation;
  }
}
