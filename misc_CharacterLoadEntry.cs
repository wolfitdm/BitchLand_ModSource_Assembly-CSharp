// Decompiled with JetBrains decompiler
// Type: misc_CharacterLoadEntry
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
    if (UI_Customize.GetPNGDataVer(filename) >= 14)
    {
      Texture2D texture = Main.Instance.CustomizeMenu.LoadTexture(filename);
      if (!((Object) texture != (Object) null))
        return;
      this.ThisImg.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, (float) texture.width, (float) texture.height), new Vector2(0.0f, 0.0f));
    }
    else
      this.ThisImg.sprite = Main.Instance.OldCharData;
  }

  public void Click()
  {
    Main.Instance.CustomizeMenu.UnselectCharacters();
    Main.Instance.CustomizeMenu.SelectedCharacter = this;
    this.ThisSelected.gameObject.SetActive(true);
  }
}
