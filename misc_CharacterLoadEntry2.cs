// Decompiled with JetBrains decompiler
// Type: misc_CharacterLoadEntry2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class misc_CharacterLoadEntry2 : MonoBehaviour
{
  public Image ThisImg;
  public Image ThisSelected;
  public string ThisFile;

  public void LoadImage(string filename)
  {
    this.ThisFile = filename;
    Texture2D texture = UI_Gameplay.LoadTexture(filename);
    this.ThisImg.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, (float) texture.width, (float) texture.height), new Vector2(0.0f, 0.0f));
  }

  public void Click()
  {
    Main.Instance.LoadCustomNPCMenu.UnselectCharacters();
    Main.Instance.LoadCustomNPCMenu.SelectedCharacter = this;
    this.ThisSelected.gameObject.SetActive(true);
  }
}
