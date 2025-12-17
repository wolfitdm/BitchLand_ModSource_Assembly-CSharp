// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Armor_Collider_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP;

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
