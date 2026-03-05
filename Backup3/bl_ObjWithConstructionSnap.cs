// Decompiled with JetBrains decompiler
// Type: bl_ObjWithConstructionSnap
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_ObjWithConstructionSnap : MonoBehaviour
{
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
