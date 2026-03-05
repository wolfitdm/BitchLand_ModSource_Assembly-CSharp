// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Delete_Timer_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
