// Decompiled with JetBrains decompiler
// Type: UI_LoadCustomNPC
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.IO;
using UnityEngine;

#nullable disable
public class UI_LoadCustomNPC : UI_Menu
{
  [Header("Character list-----------------")]
  public RectTransform CharacterListRect;
  public GameObject CharacterEntry;
  public List<GameObject> CharacterEntries = new List<GameObject>();
  public List<misc_CharacterLoadEntry2> CharacterEntries2 = new List<misc_CharacterLoadEntry2>();
  public misc_CharacterLoadEntry2 SelectedCharacter;
  public bool CurrentLoadFolderGirls;

  public override void Open()
  {
    base.Open();
    Main.Instance.GameplayMenu.AllowCursor();
    Time.timeScale = 0.0f;
    Main.Instance.Player.AddMoveBlocker("LoadCustomNPCMenu");
    for (int index = 0; index < this.CharacterEntries.Count; ++index)
      Object.Destroy((Object) this.CharacterEntries[index]);
    this.CharacterEntries2.Clear();
    string[] files = Directory.GetFiles(this.CurrentLoadFolderGirls ? Main.AssetsFolder + "/Characters/Girls/" : Main.AssetsFolder + "/Characters/Guys/", "*.png");
    this.CharacterListRect.sizeDelta = new Vector2(0.0f, (float) ((files.Length + 3) / 4 * 150));
    for (int index = 0; index < files.Length; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.CharacterEntry, this.CharacterEntry.transform.parent);
      this.CharacterEntries.Add(gameObject);
      gameObject.SetActive(true);
      misc_CharacterLoadEntry2 component = gameObject.GetComponent<misc_CharacterLoadEntry2>();
      component.LoadImage(files[index]);
      this.CharacterEntries2.Add(component);
    }
  }

  public override void Close()
  {
    base.Close();
    for (int index = 0; index < this.CharacterEntries.Count; ++index)
      Object.Destroy((Object) this.CharacterEntries[index]);
    this.CharacterEntries2.Clear();
    Main.Instance.GameplayMenu.DisallowCursor();
    Time.timeScale = 1f;
    Main.Instance.Player.RemoveMoveBlocker("LoadCustomNPCMenu");
  }

  public void Click_Close()
  {
    Main.Instance.Player.InteractingWith = (Interactible) null;
    Main.Instance.OpenMenu("Gameplay");
  }

  public void SpawnNPC()
  {
  }

  public void Click_LoadSelectedCharacter()
  {
    RandomNPCHere theSpawner = (Main.Instance.Player.InteractingWith as int_LoadCustomCharacter).TheSpawner;
    theSpawner.PersonGenerated = (Person) null;
    theSpawner.SpecificClothes.Clear();
    theSpawner.LoadSpecificNPC = true;
    theSpawner.NPCToLoad = this.SelectedCharacter.ThisFile;
    theSpawner.FullPath = true;
    theSpawner.DontLoadInteraction = true;
    theSpawner.SpawnFemale = this.CurrentLoadFolderGirls;
    theSpawner.Start();
    this.Click_Close();
  }

  public void UnselectCharacters()
  {
    for (int index = 0; index < this.CharacterEntries2.Count; ++index)
      this.CharacterEntries2[index].ThisSelected.gameObject.SetActive(false);
  }

  public void Click_ChangeGenderLoadFolder()
  {
    this.CurrentLoadFolderGirls = !this.CurrentLoadFolderGirls;
    this.Open();
  }
}
