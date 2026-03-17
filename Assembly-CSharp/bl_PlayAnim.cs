// Decompiled with JetBrains decompiler
// Type: bl_PlayAnim
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_PlayAnim : MonoBehaviour
{
  public Animator Anim;
  public string AnimStr;

  public void Start() => this.Anim.Play(this.AnimStr);
}
