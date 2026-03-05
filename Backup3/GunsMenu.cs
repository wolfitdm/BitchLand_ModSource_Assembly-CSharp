// Decompiled with JetBrains decompiler
// Type: GunsMenu
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class GunsMenu : MonoBehaviour
{
  public GameObject Buttons;
  public GameObject[] Guns;
  private int currentGun;

  private void Start() => this.Guns[0].SetActive(true);

  public void NextGun()
  {
    this.Guns[this.currentGun].SetActive(false);
    ++this.currentGun;
    if (this.currentGun >= this.Guns.Length)
      this.currentGun = 0;
    this.Guns[this.currentGun].SetActive(true);
  }

  public void PreviousGun()
  {
    this.Guns[this.currentGun].SetActive(false);
    --this.currentGun;
    if (this.currentGun < 0)
      this.currentGun = this.Guns.Length - 1;
    this.Guns[this.currentGun].SetActive(true);
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
    {
      this.Buttons.SetActive(false);
    }
    else
    {
      if (Input.touchCount != 0 || Input.GetMouseButton(0))
        return;
      this.Buttons.SetActive(true);
    }
  }
}
