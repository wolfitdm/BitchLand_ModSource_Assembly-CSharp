// Decompiled with JetBrains decompiler
// Type: DitzelGames.FastIK.FastIKLook
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DitzelGames.FastIK
{
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
}
