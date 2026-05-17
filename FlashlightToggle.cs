// Decompiled with JetBrains decompiler
// Type: FlashlightToggle
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
