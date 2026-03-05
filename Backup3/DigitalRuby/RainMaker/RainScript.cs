// Decompiled with JetBrains decompiler
// Type: DigitalRuby.RainMaker.RainScript
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DigitalRuby.RainMaker
{
  public class RainScript : BaseRainScript
  {
    [Tooltip("The height above the camera that the rain will start falling from")]
    public float RainHeight = 25f;
    [Tooltip("How far the rain particle system is ahead of the player")]
    public float RainForwardOffset = -7f;
    [Tooltip("The top y value of the mist particles")]
    public float RainMistHeight = 3f;

    private void UpdateRain()
    {
      if (!((Object) this.RainFallParticleSystem != (Object) null))
        return;
      if (this.FollowCamera)
      {
        this.RainFallParticleSystem.shape.shapeType = ParticleSystemShapeType.ConeVolume;
        this.RainFallParticleSystem.transform.position = this.Camera.transform.position;
        this.RainFallParticleSystem.transform.Translate(0.0f, this.RainHeight, this.RainForwardOffset);
        this.RainFallParticleSystem.transform.rotation = Quaternion.Euler(0.0f, this.Camera.transform.rotation.eulerAngles.y, 0.0f);
        if (!((Object) this.RainMistParticleSystem != (Object) null))
          return;
        this.RainMistParticleSystem.shape.shapeType = ParticleSystemShapeType.Hemisphere;
        Vector3 position = this.Camera.transform.position;
        position.y += this.RainMistHeight;
        this.RainMistParticleSystem.transform.position = position;
      }
      else
      {
        this.RainFallParticleSystem.shape.shapeType = ParticleSystemShapeType.Box;
        if (!((Object) this.RainMistParticleSystem != (Object) null))
          return;
        this.RainMistParticleSystem.shape.shapeType = ParticleSystemShapeType.Box;
        Vector3 position = this.RainFallParticleSystem.transform.position;
        position.y += this.RainMistHeight;
        position.y -= this.RainHeight;
        this.RainMistParticleSystem.transform.position = position;
      }
    }

    protected override void Start() => base.Start();

    protected override void Update()
    {
      base.Update();
      this.UpdateRain();
    }
  }
}
