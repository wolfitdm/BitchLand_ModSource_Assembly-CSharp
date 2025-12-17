// Decompiled with JetBrains decompiler
// Type: bl_localLodRedirect
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
