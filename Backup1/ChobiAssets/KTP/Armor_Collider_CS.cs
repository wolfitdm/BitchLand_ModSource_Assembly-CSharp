// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Armor_Collider_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
