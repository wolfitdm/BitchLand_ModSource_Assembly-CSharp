// Decompiled with JetBrains decompiler
// Type: Deener6.OverCameraParticle
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
