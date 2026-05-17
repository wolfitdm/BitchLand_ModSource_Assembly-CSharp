// Decompiled with JetBrains decompiler
// Type: ProcGenDebugUI
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ProcGenDebugUI : MonoBehaviour
{
  [SerializeField]
  private Button RegenerateButton;
  [SerializeField]
  private TextMeshProUGUI StatusDisplay;
  [SerializeField]
  private ProcGenManager TargetManager;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void OnRegenerate()
  {
    this.RegenerateButton.interactable = false;
    this.StartCoroutine(this.PerformRegeneration());
  }

  private IEnumerator PerformRegeneration()
  {
    ProcGenDebugUI procGenDebugUi = this;
    yield return (object) procGenDebugUi.TargetManager.AsyncRegenerateWorld(new Action<int, int, string>(procGenDebugUi.OnStatusReported));
    procGenDebugUi.RegenerateButton.interactable = true;
    yield return (object) null;
  }

  private void OnStatusReported(int step, int totalSteps, string status)
  {
    this.StatusDisplay.text = string.Format("Step {0} of {1}: {2}", (object) step, (object) totalSteps, (object) status);
  }
}
