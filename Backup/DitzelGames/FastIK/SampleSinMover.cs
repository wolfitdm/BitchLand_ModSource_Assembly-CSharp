// Decompiled with JetBrains decompiler
// Type: DitzelGames.FastIK.SampleSinMover
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DitzelGames.FastIK;

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
