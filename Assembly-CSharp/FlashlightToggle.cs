// Decompiled with JetBrains decompiler
// Type: FlashlightToggle
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FlashlightToggle : MonoBehaviour
{
  public GameObject lightGO;
  private bool isOn;

  private void Start() => this.lightGO.SetActive(this.isOn);

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.X))
      return;
    this.isOn = !this.isOn;
    if (this.isOn)
      this.lightGO.SetActive(true);
    else
      this.lightGO.SetActive(false);
  }
}
