// Decompiled with JetBrains decompiler
// Type: FillValueNumber
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class FillValueNumber : MonoBehaviour
{
  public Image TargetImage;

  private void Update()
  {
    float num = this.TargetImage.fillAmount * 100f;
    this.gameObject.GetComponent<Text>().text = num.ToString("F0");
  }
}
