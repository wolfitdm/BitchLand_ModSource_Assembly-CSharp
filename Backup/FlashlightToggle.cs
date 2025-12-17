// Decompiled with JetBrains decompiler
// Type: FlashlightToggle
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
