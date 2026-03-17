// Decompiled with JetBrains decompiler
// Type: int_readable
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_readable : Interactible
{
  [Multiline]
  public string Text;
  public float TextHeight;

  public override void Interact(Person person)
  {
    base.Interact(person);
    this.enabled = true;
    Main.Instance.GameplayMenu.NoteText.text = this.Text;
    Main.Instance.GameplayMenu.NoteContent.sizeDelta = new Vector2(Main.Instance.GameplayMenu.NoteContent.sizeDelta.x, this.TextHeight);
    Main.Instance.GameplayMenu.ShowNote();
  }

  private void Update()
  {
    if (!Main.Instance.CancelKey())
      return;
    Main.Instance.GameplayMenu.HideNote();
    this.StopInteracting();
  }

  public override void StopInteracting()
  {
    this.enabled = false;
    base.StopInteracting();
  }
}
