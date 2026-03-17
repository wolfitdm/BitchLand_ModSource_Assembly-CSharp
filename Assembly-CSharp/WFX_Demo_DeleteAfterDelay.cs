// Decompiled with JetBrains decompiler
// Type: WFX_Demo_DeleteAfterDelay
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class WFX_Demo_DeleteAfterDelay : MonoBehaviour
{
  public float delay = 1f;

  private void Update()
  {
    this.delay -= Time.deltaTime;
    if ((double) this.delay >= 0.0)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
