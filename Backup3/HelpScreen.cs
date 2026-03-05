// Decompiled with JetBrains decompiler
// Type: HelpScreen
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
