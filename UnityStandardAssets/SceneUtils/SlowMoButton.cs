// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.SceneUtils.SlowMoButton
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace UnityStandardAssets.SceneUtils
{
  public class SlowMoButton : MonoBehaviour
  {
    public Sprite FullSpeedTex;
    public Sprite SlowSpeedTex;
    public float fullSpeed = 1f;
    public float slowSpeed = 0.3f;
    public Button button;
    private bool m_SlowMo;

    private void Start() => this.m_SlowMo = false;

    private void OnDestroy() => Time.timeScale = 1f;

    public void ChangeSpeed()
    {
      this.m_SlowMo = !this.m_SlowMo;
      Image targetGraphic = this.button.targetGraphic as Image;
      if ((Object) targetGraphic != (Object) null)
        targetGraphic.sprite = this.m_SlowMo ? this.SlowSpeedTex : this.FullSpeedTex;
      this.button.targetGraphic = (Graphic) targetGraphic;
      Time.timeScale = this.m_SlowMo ? this.slowSpeed : this.fullSpeed;
    }
  }
}
