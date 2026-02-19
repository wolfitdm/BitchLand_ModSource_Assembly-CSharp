// Decompiled with JetBrains decompiler
// Type: AGIA.AGIAFree_sample
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
namespace AGIA
{
  public class AGIAFree_sample : MonoBehaviour
  {
    public Animator animator;
    public int animBase;
    public int animLayer;

    private void Start()
    {
      this.animator = this.GetComponent<Animator>();
      this.animator.SetInteger("animBaseInt", 1);
    }

    private void Update()
    {
    }

    public void animBaseChange()
    {
      this.animator.SetInteger("animOtherInt", 0);
      switch (EventSystem.current.currentSelectedGameObject.name)
      {
        case "Generic_01":
          this.animator.SetInteger("animBaseInt", 1);
          break;
        case "Angry_01":
          this.animator.SetInteger("animBaseInt", 2);
          break;
        case "Brave_01":
          this.animator.SetInteger("animBaseInt", 3);
          break;
        case "Calm_01":
          this.animator.SetInteger("animBaseInt", 4);
          break;
        case "Concern_01":
          this.animator.SetInteger("animBaseInt", 5);
          break;
        case "Energetic_01":
          this.animator.SetInteger("animBaseInt", 6);
          break;
        case "Energetic_02":
          this.animator.SetInteger("animBaseInt", 7);
          break;
        case "Pitiable_01":
          this.animator.SetInteger("animBaseInt", 8);
          break;
        case "Surprised_01":
          this.animator.SetInteger("animBaseInt", 9);
          break;
      }
    }

    public void animLayerChange()
    {
      switch (EventSystem.current.currentSelectedGameObject.name)
      {
        case "Reset":
          this.animator.Play("Layer_start", 1, 0.0f);
          break;
        case "LookAway_01":
          this.animator.Play("Layer_look_away", 1, 0.0f);
          break;
        case "NoddingOnce_01":
          this.animator.Play("Layer_nodding_once", 1, 0.0f);
          break;
        case "SwingingBody_01":
          this.animator.Play("Layer_swinging_body", 1, 0.0f);
          break;
      }
    }

    public void animOtherChange()
    {
      this.animator.SetInteger("animBaseInt", 0);
      switch (EventSystem.current.currentSelectedGameObject.name)
      {
        case "walking_01":
          this.animator.SetInteger("animOtherInt", 1);
          break;
        case "WavingArm_01":
          this.animator.SetInteger("animOtherInt", 2);
          break;
      }
    }
  }
}
