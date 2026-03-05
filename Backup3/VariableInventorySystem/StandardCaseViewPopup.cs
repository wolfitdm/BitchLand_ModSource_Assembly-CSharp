// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardCaseViewPopup
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace VariableInventorySystem
{
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
}
