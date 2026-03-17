// Decompiled with JetBrains decompiler
// Type: HelpScreen
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
