// Decompiled with JetBrains decompiler
// Type: FlashlightToggle
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
