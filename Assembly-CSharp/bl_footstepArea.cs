// Decompiled with JetBrains decompiler
// Type: bl_footstepArea
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_footstepArea : MonoBehaviour
{
  public e_CurrentTerrain ThisTerrain;

  public void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 20)
      return;
    Main.Instance.Player.FootStepsAudio.CurrentTerrain = this.ThisTerrain;
  }
}
