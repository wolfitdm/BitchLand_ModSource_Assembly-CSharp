// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Armor_Collider_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
