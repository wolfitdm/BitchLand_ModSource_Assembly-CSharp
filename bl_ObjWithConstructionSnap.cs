// Decompiled with JetBrains decompiler
// Type: bl_ObjWithConstructionSnap
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_ObjWithConstructionSnap : MonoBehaviour
{
  public e_SnapScale SnapScale;
  public int_ConstructionPlan ThisPlan;
  public GameObject[] Spots;
  public bl_ConstructionSnapSpot[] Data;

  public void Show(int_ConstructionPlan.e_BuildSnapType buildSnapType)
  {
    if ((Object) this.ThisPlan != (Object) null && this.ThisPlan.BeingMoved)
      return;
    for (int index = 0; index < this.Spots.Length; ++index)
    {
      if (buildSnapType == int_ConstructionPlan.e_BuildSnapType.Floor)
      {
        if (this.Data[index].Floor == bl_ConstructionSnapSpot.e_snapSpotUse.Free)
          this.Spots[index].SetActive(true);
      }
      else if (this.Data[index].Wall == bl_ConstructionSnapSpot.e_snapSpotUse.Free)
        this.Spots[index].SetActive(true);
    }
  }

  public void Hide()
  {
    for (int index = 0; index < this.Spots.Length; ++index)
      this.Spots[index].SetActive(false);
  }
}
