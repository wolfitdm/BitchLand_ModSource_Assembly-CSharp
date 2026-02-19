// Decompiled with JetBrains decompiler
// Type: DigitalRuby.RainMaker.RainScript2D
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DigitalRuby.RainMaker
{
  public class RainScript2D : BaseRainScript
  {
    private static readonly Color32 explosionColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
    private float cameraMultiplier = 1f;
    private Bounds visibleBounds;
    private float yOffset;
    private float visibleWorldWidth;
    private float initialEmissionRain;
    private Vector2 initialStartSpeedRain;
    private Vector2 initialStartSizeRain;
    private Vector2 initialStartSpeedMist;
    private Vector2 initialStartSizeMist;
    private Vector2 initialStartSpeedExplosion;
    private Vector2 initialStartSizeExplosion;
    private readonly ParticleSystem.Particle[] particles = new ParticleSystem.Particle[2048];
    [Tooltip("The starting y offset for rain and mist. This will be offset as a percentage of visible height from the top of the visible world.")]
    public float RainHeightMultiplier = 0.15f;
    [Tooltip("The total width of the rain and mist as a percentage of visible width")]
    public float RainWidthMultiplier = 1.5f;
    [Tooltip("Collision mask for the rain particles")]
    public LayerMask CollisionMask = (LayerMask) -1;
    [Tooltip("Lifetime to assign to rain particles that have collided. 0 for instant death. This can allow the rain to penetrate a little bit beyond the collision point.")]
    [Range(0.0f, 0.5f)]
    public float CollisionLifeTimeRain = 0.02f;
    [Tooltip("Multiply the velocity of any mist colliding by this amount")]
    [Range(0.0f, 0.99f)]
    public float RainMistCollisionMultiplier = 0.75f;

    private void EmitExplosion(ref Vector3 pos)
    {
      for (int index = Random.Range(2, 5); index != 0; --index)
      {
        float x = Random.Range(-2f, 2f) * this.cameraMultiplier;
        float y = Random.Range(1f, 3f) * this.cameraMultiplier;
        float num1 = Random.Range(0.1f, 0.2f);
        float num2 = Random.Range(0.05f, 0.1f) * this.cameraMultiplier;
        this.RainExplosionParticleSystem.Emit(new ParticleSystem.EmitParams()
        {
          position = pos,
          velocity = new Vector3(x, y, 0.0f),
          startLifetime = num1,
          startSize = num2,
          startColor = RainScript2D.explosionColor
        }, 1);
      }
    }

    private void TransformParticleSystem(
      ParticleSystem p,
      Vector2 initialStartSpeed,
      Vector2 initialStartSize)
    {
      if ((Object) p == (Object) null)
        return;
      if (this.FollowCamera)
        p.transform.position = new Vector3(this.Camera.transform.position.x, this.visibleBounds.max.y + this.yOffset, p.transform.position.z);
      else
        p.transform.position = new Vector3(p.transform.position.x, this.visibleBounds.max.y + this.yOffset, p.transform.position.z);
      p.transform.localScale = new Vector3(this.visibleWorldWidth * this.RainWidthMultiplier, 1f, 1f);
      ParticleSystem.MainModule main = p.main;
      ParticleSystem.MinMaxCurve startSpeed = main.startSpeed;
      ParticleSystem.MinMaxCurve startSize = main.startSize;
      startSpeed.constantMin = initialStartSpeed.x * this.cameraMultiplier;
      startSpeed.constantMax = initialStartSpeed.y * this.cameraMultiplier;
      startSize.constantMin = initialStartSize.x * this.cameraMultiplier;
      startSize.constantMax = initialStartSize.y * this.cameraMultiplier;
      main.startSpeed = startSpeed;
      main.startSize = startSize;
    }

    private void CheckForCollisionsRainParticles()
    {
      int size = 0;
      bool flag = false;
      if ((int) this.CollisionMask != 0)
      {
        size = this.RainFallParticleSystem.GetParticles(this.particles);
        for (int index = 0; index < size; ++index)
        {
          Vector3 vector3_1 = this.particles[index].position + this.RainFallParticleSystem.transform.position;
          Vector2 origin = (Vector2) vector3_1;
          Vector3 velocity = this.particles[index].velocity;
          Vector2 normalized = (Vector2) velocity.normalized;
          velocity = this.particles[index].velocity;
          double distance = (double) velocity.magnitude * (double) Time.deltaTime;
          RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, normalized, (float) distance);
          if ((Object) raycastHit2D.collider != (Object) null && (1 << raycastHit2D.collider.gameObject.layer & (int) this.CollisionMask) != 0)
          {
            if ((double) this.CollisionLifeTimeRain == 0.0)
            {
              this.particles[index].remainingLifetime = 0.0f;
            }
            else
            {
              this.particles[index].remainingLifetime = Mathf.Min(this.particles[index].remainingLifetime, Random.Range(this.CollisionLifeTimeRain * 0.5f, this.CollisionLifeTimeRain * 2f));
              Vector3 vector3_2 = vector3_1 + this.particles[index].velocity * Time.deltaTime;
            }
            flag = true;
          }
        }
      }
      if ((Object) this.RainExplosionParticleSystem != (Object) null)
      {
        if (size == 0)
          size = this.RainFallParticleSystem.GetParticles(this.particles);
        for (int index = 0; index < size; ++index)
        {
          if ((double) this.particles[index].remainingLifetime < 0.23999999463558197)
          {
            Vector3 pos = this.particles[index].position + this.RainFallParticleSystem.transform.position;
            this.EmitExplosion(ref pos);
          }
        }
      }
      if (!flag)
        return;
      this.RainFallParticleSystem.SetParticles(this.particles, size);
    }

    private void CheckForCollisionsMistParticles()
    {
      if ((Object) this.RainMistParticleSystem == (Object) null || (int) this.CollisionMask == 0)
        return;
      int particles = this.RainMistParticleSystem.GetParticles(this.particles);
      bool flag = false;
      for (int index = 0; index < particles; ++index)
      {
        Vector2 origin = (Vector2) (this.particles[index].position + this.RainMistParticleSystem.transform.position);
        Vector3 velocity = this.particles[index].velocity;
        Vector2 normalized = (Vector2) velocity.normalized;
        velocity = this.particles[index].velocity;
        double distance = (double) velocity.magnitude * (double) Time.deltaTime;
        int collisionMask = (int) this.CollisionMask;
        if ((Object) Physics2D.Raycast(origin, normalized, (float) distance, collisionMask).collider != (Object) null)
        {
          this.particles[index].velocity *= this.RainMistCollisionMultiplier;
          flag = true;
        }
      }
      if (!flag)
        return;
      this.RainMistParticleSystem.SetParticles(this.particles, particles);
    }

    protected override void Start()
    {
      base.Start();
      this.initialEmissionRain = this.RainFallParticleSystem.emission.rateOverTime.constant;
      ParticleSystem.MinMaxCurve startSpeed = this.RainFallParticleSystem.main.startSpeed;
      double constantMin1 = (double) startSpeed.constantMin;
      startSpeed = this.RainFallParticleSystem.main.startSpeed;
      double constantMax1 = (double) startSpeed.constantMax;
      this.initialStartSpeedRain = new Vector2((float) constantMin1, (float) constantMax1);
      ParticleSystem.MinMaxCurve startSize = this.RainFallParticleSystem.main.startSize;
      double constantMin2 = (double) startSize.constantMin;
      startSize = this.RainFallParticleSystem.main.startSize;
      double constantMax2 = (double) startSize.constantMax;
      this.initialStartSizeRain = new Vector2((float) constantMin2, (float) constantMax2);
      ParticleSystem.MinMaxCurve minMaxCurve1;
      if ((Object) this.RainMistParticleSystem != (Object) null)
      {
        double constantMin3 = (double) this.RainMistParticleSystem.main.startSpeed.constantMin;
        ParticleSystem.MinMaxCurve minMaxCurve2 = this.RainMistParticleSystem.main.startSpeed;
        double constantMax3 = (double) minMaxCurve2.constantMax;
        this.initialStartSpeedMist = new Vector2((float) constantMin3, (float) constantMax3);
        minMaxCurve2 = this.RainMistParticleSystem.main.startSize;
        double constantMin4 = (double) minMaxCurve2.constantMin;
        minMaxCurve1 = this.RainMistParticleSystem.main.startSize;
        double constantMax4 = (double) minMaxCurve1.constantMax;
        this.initialStartSizeMist = new Vector2((float) constantMin4, (float) constantMax4);
      }
      if (!((Object) this.RainExplosionParticleSystem != (Object) null))
        return;
      minMaxCurve1 = this.RainExplosionParticleSystem.main.startSpeed;
      double constantMin5 = (double) minMaxCurve1.constantMin;
      minMaxCurve1 = this.RainExplosionParticleSystem.main.startSpeed;
      double constantMax5 = (double) minMaxCurve1.constantMax;
      this.initialStartSpeedExplosion = new Vector2((float) constantMin5, (float) constantMax5);
      minMaxCurve1 = this.RainExplosionParticleSystem.main.startSize;
      double constantMin6 = (double) minMaxCurve1.constantMin;
      minMaxCurve1 = this.RainExplosionParticleSystem.main.startSize;
      double constantMax6 = (double) minMaxCurve1.constantMax;
      this.initialStartSizeExplosion = new Vector2((float) constantMin6, (float) constantMax6);
    }

    protected override void Update()
    {
      base.Update();
      this.cameraMultiplier = this.Camera.orthographicSize * 0.25f;
      this.visibleBounds.min = Camera.main.ViewportToWorldPoint(Vector3.zero);
      this.visibleBounds.max = Camera.main.ViewportToWorldPoint(Vector3.one);
      this.visibleWorldWidth = this.visibleBounds.size.x;
      this.yOffset = (this.visibleBounds.max.y - this.visibleBounds.min.y) * this.RainHeightMultiplier;
      this.TransformParticleSystem(this.RainFallParticleSystem, this.initialStartSpeedRain, this.initialStartSizeRain);
      this.TransformParticleSystem(this.RainMistParticleSystem, this.initialStartSpeedMist, this.initialStartSizeMist);
      this.TransformParticleSystem(this.RainExplosionParticleSystem, this.initialStartSpeedExplosion, this.initialStartSizeExplosion);
      this.CheckForCollisionsRainParticles();
      this.CheckForCollisionsMistParticles();
    }

    protected override float RainFallEmissionRate()
    {
      return this.initialEmissionRain * this.RainIntensity;
    }

    protected override bool UseRainMistSoftParticles => false;
  }
}
