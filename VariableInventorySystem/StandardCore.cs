// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardCore
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
