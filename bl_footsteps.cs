// Decompiled with JetBrains decompiler
// Type: bl_footsteps
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_footsteps : MonoBehaviour
{
  public AudioSource Footstepper;
  public AudioClip[] Footsteps_Concrete;
  public AudioClip[] Footsteps_Grass;
  public AudioClip[] Footsteps_Carpet;
  public AudioClip[] Footsteps_CurrentWalk;
  public AudioClip[] Footsteps_CurrentRun;
  public Transform[] Feet;
  public bool[] WentUp;
  public Transform RootDown;
  public float WentUpLine = -0.1f;
  public float[] CurrentValues;
  public Rigidbody RB;
  public bool Running;
  public e_CurrentTerrain CurrentTerrain;

  public void TriggerFootstep()
  {
    this.Running = (double) this.RB.velocity.magnitude > 1.7999999523162842;
    switch (this.CurrentTerrain)
    {
      case e_CurrentTerrain.Dirt:
        this.Footsteps_CurrentWalk = this.Footsteps_Carpet;
        this.Footsteps_CurrentRun = this.Footsteps_Carpet;
        break;
      case e_CurrentTerrain.Concrete:
        this.Footsteps_CurrentWalk = this.Footsteps_Carpet;
        this.Footsteps_CurrentRun = this.Footsteps_Concrete;
        break;
      case e_CurrentTerrain.Grass:
        this.Footsteps_CurrentWalk = this.Footsteps_Grass;
        this.Footsteps_CurrentRun = this.Footsteps_Grass;
        break;
    }
    if (this.Running)
      this.Footstepper.PlayOneShot(this.Footsteps_CurrentRun[Random.Range(0, this.Footsteps_CurrentRun.Length)]);
    else
      this.Footstepper.PlayOneShot(this.Footsteps_CurrentWalk[Random.Range(0, this.Footsteps_CurrentWalk.Length)]);
  }

  public void Update()
  {
    for (int index = 0; index < this.Feet.Length; ++index)
    {
      this.CurrentValues[index] = this.RootDown.position.y - this.Feet[index].transform.position.y;
      if ((double) this.CurrentValues[index] > (double) this.WentUpLine)
      {
        if (!this.WentUp[index])
          this.WentUp[index] = true;
      }
      else if (this.WentUp[index])
      {
        this.WentUp[index] = false;
        this.TriggerFootstep();
      }
    }
  }
}
