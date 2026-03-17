// Decompiled with JetBrains decompiler
// Type: soundplayeridkscriptig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class soundplayeridkscriptig : MonoBehaviour
{
  public AudioClip PickAxeSound;

  public void pickaxe() => Main.Instance.MusicPlayer.PlayOneShot(this.PickAxeSound);
}
