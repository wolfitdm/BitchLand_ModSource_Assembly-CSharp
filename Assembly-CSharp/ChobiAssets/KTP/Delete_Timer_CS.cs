// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Delete_Timer_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Delete_Timer_CS : MonoBehaviour
  {
    [Header("Life time settings")]
    [Tooltip("Life time of this gameobject. (Sec)")]
    public float lifeTime = 2f;

    private void Awake() => Object.Destroy((Object) this.gameObject, this.lifeTime);
  }
}
