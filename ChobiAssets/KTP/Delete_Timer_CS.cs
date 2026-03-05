// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Delete_Timer_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
