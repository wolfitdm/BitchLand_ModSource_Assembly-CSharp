// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Delete_Timer_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
