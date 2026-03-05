// Decompiled with JetBrains decompiler
// Type: HelpScreen
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HelpScreen : MonoBehaviour
{
  public GameObject helpPanel;
  public bool showHelpOnStart = true;
  private bool showHelp;

  private void Start()
  {
    this.showHelp = this.showHelpOnStart;
    this.helpPanel.SetActive(this.showHelp);
  }

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.F1))
      return;
    this.showHelp = !this.showHelp;
    this.helpPanel.SetActive(this.showHelp);
  }
}
