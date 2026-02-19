// Decompiled with JetBrains decompiler
// Type: misc_CharacterLoadEntry
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class misc_CharacterLoadEntry : MonoBehaviour
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
    Main.Instance.CustomizeMenu.UnselectCharacters();
    Main.Instance.CustomizeMenu.SelectedCharacter = this;
    this.ThisSelected.gameObject.SetActive(true);
  }
}
