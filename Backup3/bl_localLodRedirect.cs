// Decompiled with JetBrains decompiler
// Type: bl_localLodRedirect
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
