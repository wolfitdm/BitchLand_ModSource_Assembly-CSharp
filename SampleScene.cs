// Decompiled with JetBrains decompiler
// Type: SampleScene
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VariableInventorySystem;
using VariableInventorySystem.Sample;

#nullable disable
public class SampleScene : MonoBehaviour
{
  [SerializeField]
  private StandardCore standardCore;
  [SerializeField]
  private StandardStashView standardStashView;
  [SerializeField]
  private Button rotateButton;

  private void Awake()
  {
    this.standardCore.Initialize();
    this.standardCore.AddInventoryView((IVariableInventoryView) this.standardStashView);
    this.rotateButton.onClick.AddListener(new UnityAction(((VariableInventoryCore) this.standardCore).SwitchRotate));
    this.StartCoroutine(this.InsertCoroutine());
  }

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.R))
      return;
    this.standardCore.SwitchRotate();
  }

  private IEnumerator InsertCoroutine()
  {
    StandardStashViewData stashData = new StandardStashViewData(8, 16);
    CaseCellData cellData1 = new CaseCellData(0);
    stashData.InsertInventoryItem(stashData.GetInsertableId((IVariableInventoryCellData) cellData1).Value, (IVariableInventoryCellData) cellData1);
    this.standardStashView.Apply((IVariableInventoryViewData) stashData);
    for (int i = 0; i < 20; ++i)
    {
      ItemCellData cellData2 = new ItemCellData(i % 6);
      stashData.InsertInventoryItem(stashData.GetInsertableId((IVariableInventoryCellData) cellData2).Value, (IVariableInventoryCellData) cellData2);
      this.standardStashView.Apply((IVariableInventoryViewData) stashData);
      yield return (object) null;
    }
  }
}
