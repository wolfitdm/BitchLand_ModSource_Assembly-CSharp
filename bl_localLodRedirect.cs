// Decompiled with JetBrains decompiler
// Type: bl_localLodRedirect
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_localLodRedirect : bl_LocalLOD
{
  public bl_LocalLOD RedirectTo;

  public override void Show() => this.RedirectTo.Show();

  public override void Hide() => this.RedirectTo.Hide();

  public override void OnTriggerEnter(Collider other) => this.RedirectTo.OnTriggerEnter(other);

  public override void OnTriggerExit(Collider other) => this.RedirectTo.OnTriggerExit(other);
}
