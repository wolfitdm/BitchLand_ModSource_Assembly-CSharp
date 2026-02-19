// Decompiled with JetBrains decompiler
// Type: ScreenFader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ScreenFader : MonoBehaviour
{
  public Image blackScreen;
  public float FadeTime;
  public Action AfterFade;

  public void FadeIn(float fadeTime)
  {
    this.FadeTime = fadeTime;
    this.StartCoroutine(this.FadeToColor(Color.clear));
  }

  public void FadeOut(float fadeTime) => this.FadeOut(fadeTime, (Action) null);

  public void FadeOut(float fadeTime, Action afterFade)
  {
    this.FadeTime = fadeTime;
    this.AfterFade = afterFade;
    this.StartCoroutine(this.FadeToColor(Color.black));
  }

  private IEnumerator FadeToColor(Color color)
  {
    float elapsedTime = 0.0f;
    Color startColor = this.blackScreen.color;
    while ((double) elapsedTime < (double) this.FadeTime)
    {
      elapsedTime += Time.deltaTime;
      float t = Mathf.Clamp01(elapsedTime / this.FadeTime);
      this.blackScreen.color = Color.Lerp(startColor, color, t);
      yield return (object) null;
    }
    if (this.AfterFade != null)
    {
      this.AfterFade();
      this.AfterFade = (Action) null;
    }
  }
}
