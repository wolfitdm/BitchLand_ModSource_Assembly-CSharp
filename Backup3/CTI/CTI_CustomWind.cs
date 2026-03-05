// Decompiled with JetBrains decompiler
// Type: CTI.CTI_CustomWind
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace CTI
{
  [RequireComponent(typeof (WindZone))]
  public class CTI_CustomWind : MonoBehaviour
  {
    private WindZone m_WindZone;
    private Vector3 WindDirection;
    private float WindStrength;
    private float WindTurbulence;
    public float WindMultiplier = 1f;
    private bool init;
    private int TerrainLODWindPID;

    private void Init()
    {
      this.m_WindZone = this.GetComponent<WindZone>();
      this.TerrainLODWindPID = Shader.PropertyToID("_TerrainLODWind");
    }

    private void OnValidate() => this.Update();

    private void Update()
    {
      if (!this.init)
        this.Init();
      this.WindDirection = this.transform.forward;
      if ((Object) this.m_WindZone == (Object) null)
        this.m_WindZone = this.GetComponent<WindZone>();
      this.WindStrength = this.m_WindZone.windMain * this.WindMultiplier;
      this.WindStrength += (float) ((double) this.m_WindZone.windPulseMagnitude * (1.0 + (double) Mathf.Sin(Time.time * this.m_WindZone.windPulseFrequency) + 1.0 + (double) Mathf.Sin((float) ((double) Time.time * (double) this.m_WindZone.windPulseFrequency * 3.0))) * 0.5);
      this.WindTurbulence = this.m_WindZone.windTurbulence * this.m_WindZone.windMain * this.WindMultiplier;
      this.WindDirection.x *= this.WindStrength;
      this.WindDirection.y *= this.WindStrength;
      this.WindDirection.z *= this.WindStrength;
      Shader.SetGlobalVector(this.TerrainLODWindPID, new Vector4(this.WindDirection.x, this.WindDirection.y, this.WindDirection.z, this.WindTurbulence));
    }
  }
}
