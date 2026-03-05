// Decompiled with JetBrains decompiler
// Type: FlashlightToggle
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
