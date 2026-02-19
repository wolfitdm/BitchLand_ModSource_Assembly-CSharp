// Decompiled with JetBrains decompiler
// Type: misc_LoadGameSlot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class misc_LoadGameSlot : MonoBehaviour
{
  public static bool Loading;
  public int ThisSlotIndex;
  public string ThisSlot;
  public Text TheText;
  public Image TheImage;
  public UI_LoadGame LoadGameMenu;

  public void OnClick()
  {
    if (misc_LoadGameSlot.Loading)
      return;
    misc_LoadGameSlot.Loading = true;
    Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
    Main.RunInNextFrame((Action) (() =>
    {
      misc_LoadGameSlot.Loading = false;
      Main.Instance.LoadGame(this.ThisSlot);
    }));
  }

  public void DeleteThisSave()
  {
    this.LoadGameMenu.DeleteImg.sprite = this.TheImage.sprite;
    this.LoadGameMenu.SaveToDelete = this.ThisSlot;
    this.LoadGameMenu.SaveToDeleteIndex = this.ThisSlotIndex;
    this.LoadGameMenu.DeleteSaveWindow.SetActive(true);
  }
}
