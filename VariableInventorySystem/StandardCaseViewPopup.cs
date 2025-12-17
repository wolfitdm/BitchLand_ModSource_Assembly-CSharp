// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardCaseViewPopup
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace VariableInventorySystem;

public class StandardCaseViewPopup : MonoBehaviour
{
  [SerializeField]
  private StandardCaseView standardCaseView;
  [SerializeField]
  private RawImage icon;
  [SerializeField]
  private StandardButton closeButton;
  [SerializeField]
  private RectTransform sizeSampleTarget;
  [SerializeField]
  private RectTransform sizeTarget;
  [SerializeField]
  private Vector2 sizeTargetOffset;

  public StandardCaseView StandardCaseView => this.standardCaseView;

  protected virtual StandardAssetLoader Loader { get; set; } = new StandardAssetLoader();

  public virtual void Open(IStandardCaseCellData caseData, Action onCloseButton)
  {
    this.standardCaseView.Apply((IVariableInventoryViewData) caseData.CaseData);
    this.StartCoroutine(this.Loader.LoadAsync(caseData.ImageAsset, (Action<Texture2D>) (tex => this.icon.texture = (Texture) tex)));
    this.closeButton.SetCallback((Action) (() => onCloseButton()));
    this.StartCoroutine(this.DelayFrame((Action) (() => this.sizeTarget.sizeDelta = this.sizeSampleTarget.rect.size + this.sizeTargetOffset)));
  }

  private IEnumerator DelayFrame(Action action)
  {
    yield return (object) null;
    Action action1 = action;
    if (action1 != null)
      action1();
  }
}
