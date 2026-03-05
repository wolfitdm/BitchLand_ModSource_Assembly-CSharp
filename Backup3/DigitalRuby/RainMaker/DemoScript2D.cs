// Decompiled with JetBrains decompiler
// Type: DigitalRuby.RainMaker.DemoScript2D
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace DigitalRuby.RainMaker
{
  public class DemoScript2D : MonoBehaviour
  {
    public Slider RainSlider;
    public RainScript2D RainScript;

    private void Start()
    {
      this.RainScript.RainIntensity = this.RainSlider.value = 0.5f;
      this.RainScript.EnableWind = true;
    }

    private void Update()
    {
      Vector3 worldPoint = Camera.main.ViewportToWorldPoint(Vector3.zero);
      float num = Camera.main.ViewportToWorldPoint(Vector3.one).x - worldPoint.x;
      if (Input.GetKey(KeyCode.LeftArrow))
      {
        Camera.main.transform.Translate(Time.deltaTime * (float) -((double) num * 0.10000000149011612), 0.0f, 0.0f);
      }
      else
      {
        if (!Input.GetKey(KeyCode.RightArrow))
          return;
        Camera.main.transform.Translate(Time.deltaTime * (num * 0.1f), 0.0f, 0.0f);
      }
    }

    public void RainSliderChanged(float val) => this.RainScript.RainIntensity = val;

    public void CollisionToggleChanged(bool val)
    {
      this.RainScript.CollisionMask = (LayerMask) (val ? -1 : 0);
    }
  }
}
