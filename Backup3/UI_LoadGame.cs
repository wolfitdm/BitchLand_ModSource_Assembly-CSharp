// Decompiled with JetBrains decompiler
// Type: UI_LoadGame
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UI_LoadGame : UI_Menu
{
  public RectTransform Content;
  public GameObject LoadSlotPrefab;
  public List<GameObject> SpawnedSlots = new List<GameObject>();
  public GameObject DeleteSaveWindow;
  public Image DeleteImg;
  public string SaveToDelete;
  public int SaveToDeleteIndex;

  public UI_LoadGame() => this.MenuName = "LoadGame";

  public void Update()
  {
    if (!Input.GetKeyUp(KeyCode.Escape))
      return;
    Main.Instance.OpenMenu("MainMenu");
  }

  public override void Open()
  {
    this.CloseDelete();
    base.Open();
    Main.Instance.MainMenuCam.gameObject.SetActive(true);
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) Directory.GetDirectories(Main.AssetsFolder + "/Saves/"));
    stringList.Reverse();
    this.Content.sizeDelta = new Vector2(this.Content.sizeDelta.x, (float) stringList.Count * 110f);
    this.LoadSlotPrefab.SetActive(false);
    for (int index = 0; index < stringList.Count; ++index)
    {
      if (!(Path.GetDirectoryName(stringList[index]) == "HardToMedTransfer"))
      {
        GameObject gameObject = Object.Instantiate<GameObject>(this.LoadSlotPrefab, (Transform) this.Content);
        gameObject.SetActive(true);
        misc_LoadGameSlot component = gameObject.GetComponent<misc_LoadGameSlot>();
        component.TheText.text = "Possibly invalid save";
        string path = stringList[index] + "/info.txt";
        if (File.Exists(path))
          component.TheText.text = File.ReadAllText(path);
        string str = stringList[index] + "/pic.png";
        if (File.Exists(str))
        {
          Texture2D texture = UI_Gameplay.LoadTexture(str);
          component.TheImage.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, (float) texture.width, (float) texture.height), new Vector2(0.0f, 0.0f));
        }
        component.ThisSlot = stringList[index] + "/";
        component.ThisSlotIndex = index;
        component.LoadGameMenu = this;
        this.SpawnedSlots.Add(gameObject);
      }
    }
  }

  public override void Close()
  {
    for (int index = 0; index < this.SpawnedSlots.Count; ++index)
      Object.Destroy((Object) this.SpawnedSlots[index]);
    base.Close();
  }

  public void DeleteSave()
  {
    Directory.Delete(this.SaveToDelete, true);
    this.CloseDelete();
    for (int index = 0; index < this.SpawnedSlots.Count; ++index)
      Object.Destroy((Object) this.SpawnedSlots[index]);
    this.Open();
  }

  public void CloseDelete() => this.DeleteSaveWindow.SetActive(false);
}
