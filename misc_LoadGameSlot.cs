// Decompiled with JetBrains decompiler
// Type: misc_LoadGameSlot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
