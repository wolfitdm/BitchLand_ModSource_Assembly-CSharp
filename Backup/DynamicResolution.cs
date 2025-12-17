// Decompiled with JetBrains decompiler
// Type: DynamicResolution
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DynamicResolution : MonoBehaviour
{
  [Header("Target Frame Rate")]
  public int targetFrameRate = 60;
  [Header("Resolution Scaling")]
  public float minScale = 0.2f;
  public float maxScale = 1f;
  public float scaleStep = 0.05f;
  private float currentScale = 1f;
  private float timer;
  private float checkInterval = 1f;

  private void Start()
  {
    Application.targetFrameRate = this.targetFrameRate;
    this.currentScale = this.maxScale;
    this.ApplyResolutionScale();
  }

  private void Update()
  {
    this.timer += Time.unscaledDeltaTime;
    if ((double) this.timer < (double) this.checkInterval)
      return;
    this.AdjustResolutionScale();
    this.timer = 0.0f;
  }

  private void AdjustResolutionScale()
  {
    float num = 1f / Time.unscaledDeltaTime;
    if ((double) num < (double) (this.targetFrameRate - 5) && (double) this.currentScale > (double) this.minScale)
    {
      this.currentScale -= this.scaleStep;
      this.currentScale = Mathf.Max(this.currentScale, this.minScale);
    }
    else if ((double) num > (double) (this.targetFrameRate + 5) && (double) this.currentScale < (double) this.maxScale)
    {
      this.currentScale += this.scaleStep;
      this.currentScale = Mathf.Min(this.currentScale, this.maxScale);
    }
    this.ApplyResolutionScale();
  }

  private void ApplyResolutionScale()
  {
    int num1 = 1920;
    int num2 = 1080;
    int a1 = Mathf.RoundToInt((float) num1 * this.currentScale);
    int a2 = Mathf.RoundToInt((float) num2 * this.currentScale);
    int width = Mathf.Max(a1, Mathf.RoundToInt((float) num1 * this.minScale));
    int height = Mathf.Max(a2, Mathf.RoundToInt((float) num2 * this.minScale));
    if (width > num1)
      width = num1;
    if (height > num2)
      height = num2;
    Screen.SetResolution(width, height, Screen.fullScreen);
  }
}
