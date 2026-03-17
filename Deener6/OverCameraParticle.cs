// Decompiled with JetBrains decompiler
// Type: Deener6.OverCameraParticle
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Deener6
{
  public class OverCameraParticle : MonoBehaviour
  {
    private Transform Cam;
    private ParticleSystem Myparticle;

    private void Awake()
    {
      this.Cam = Camera.main.transform;
      this.Myparticle = this.GetComponent<ParticleSystem>();
    }

    private void Start() => this.InvokeRepeating("Teleport", 0.0f, 0.2f);

    private void Teleport()
    {
      this.Myparticle.shape.position = this.Cam.position + new Vector3(0.0f, 10f, 0.0f);
    }
  }
}
