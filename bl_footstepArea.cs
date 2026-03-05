// Decompiled with JetBrains decompiler
// Type: bl_footstepArea
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
