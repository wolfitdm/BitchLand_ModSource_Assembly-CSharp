// Decompiled with JetBrains decompiler
// Type: FillValueNumber
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
