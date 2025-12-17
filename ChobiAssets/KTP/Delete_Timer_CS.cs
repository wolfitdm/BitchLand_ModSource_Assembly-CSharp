// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Delete_Timer_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP;

public class Delete_Timer_CS : MonoBehaviour
{
  [Header("Life time settings")]
  [Tooltip("Life time of this gameobject. (Sec)")]
  public float lifeTime = 2f;

  private void Awake() => Object.Destroy((Object) this.gameObject, this.lifeTime);
}
