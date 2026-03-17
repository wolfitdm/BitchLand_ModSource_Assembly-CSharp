// Decompiled with JetBrains decompiler
// Type: DitzelGames.FastIK.FastIKLook
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
