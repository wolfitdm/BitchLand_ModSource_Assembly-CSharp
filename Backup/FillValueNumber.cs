// Decompiled with JetBrains decompiler
// Type: FillValueNumber
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
