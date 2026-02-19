// Decompiled with JetBrains decompiler
// Type: HelpScreen
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
