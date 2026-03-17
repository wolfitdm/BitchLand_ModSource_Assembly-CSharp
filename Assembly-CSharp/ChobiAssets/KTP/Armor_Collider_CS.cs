// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Armor_Collider_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Armor_Collider_CS : MonoBehaviour
  {
    [Header("Armor settings")]
    [Tooltip("Multiplier for the damage.")]
    public float damageMultiplier = 1f;

    private void Awake()
    {
      this.GetComponent<Collider>().isTrigger = true;
      this.GetComponent<MeshRenderer>().enabled = false;
    }
  }
}
