// Decompiled with JetBrains decompiler
// Type: misc_CharacterLoadEntry2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
