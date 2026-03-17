// Decompiled with JetBrains decompiler
// Type: DitzelGames.FastIK.SampleSinMover
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DitzelGames.FastIK
{
  public class SampleSinMover : MonoBehaviour
  {
    public Vector3 Dir;
    public Vector3 Start;

    private void Awake() => this.Start = this.transform.position;

    private void Update()
    {
      this.transform.position = this.Start + this.Dir * Mathf.Sin(Time.timeSinceLevelLoad);
    }
  }
}
