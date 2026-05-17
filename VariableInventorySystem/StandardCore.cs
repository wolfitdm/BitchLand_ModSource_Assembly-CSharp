// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardCore
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace VariableInventorySystem
{
  public class StandardCore : VariableInventoryCore
  {
    [SerializeField]
    private GameObject cellPrefab;
    [SerializeField]
    private GameObject casePopupPrefab;
    [SerializeField]
    private RectTransform effectCellParent;
    [SerializeField]
    private RectTransform caseParent;
    protected List<IStandardCaseCellData> popupList = new List<IStandardCaseCellData>();

    protected override GameObject CellPrefab => this.cellPrefab;

    protected override RectTransform EffectCellParent => this.effectCellParent;

    protected override void OnCellClick(IVariableInventoryCell cell)
    {
      IStandardCaseCellData caseData = cell.CellData as IStandardCaseCellData;
      if (caseData == null || this.popupList.Contains(caseData))
        return;
      this.popupList.Add(caseData);
      StandardCaseViewPopup standardCaseViewPopup = UnityEngine.Object.Instantiate<GameObject>(this.casePopupPrefab, (Transform) this.caseParent).GetComponent<StandardCaseViewPopup>();
      this.AddInventoryView((IVariableInventoryView) standardCaseViewPopup.StandardCaseView);
      standardCaseViewPopup.Open(caseData, (Action) (() =>
      {
        this.RemoveInventoryView((IVariableInventoryView) standardCaseViewPopup.StandardCaseView);
        UnityEngine.Object.Destroy((UnityEngine.Object) standardCaseViewPopup.gameObject);
        this.popupList.Remove(caseData);
      }));
    }
  }
}
