// Decompiled with JetBrains decompiler
// Type: misc_LoadGameSlot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.IO;
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

  public void DuplicateSave()
  {
    this.CopyDirectory(this.ThisSlot, this.ThisSlot.Remove(this.ThisSlot.Length - 1) + "_/", true);
    Main.Instance.OpenMenu("LoadGame");
  }

  public void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
  {
    DirectoryInfo directoryInfo1 = new DirectoryInfo(sourceDir);
    DirectoryInfo[] directoryInfoArray = directoryInfo1.Exists ? directoryInfo1.GetDirectories() : throw new DirectoryNotFoundException("Source directory not found: " + directoryInfo1.FullName);
    Directory.CreateDirectory(destinationDir);
    foreach (FileInfo file in directoryInfo1.GetFiles())
    {
      string destFileName = Path.Combine(destinationDir, file.Name);
      file.CopyTo(destFileName);
    }
    if (!recursive)
      return;
    foreach (DirectoryInfo directoryInfo2 in directoryInfoArray)
    {
      string destinationDir1 = Path.Combine(destinationDir, directoryInfo2.Name);
      this.CopyDirectory(directoryInfo2.FullName, destinationDir1, true);
    }
  }
}
