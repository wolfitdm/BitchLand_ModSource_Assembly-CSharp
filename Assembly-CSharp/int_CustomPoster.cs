// Decompiled with JetBrains decompiler
// Type: int_CustomPoster
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.IO;
using UnityEngine;

#nullable disable
public class int_CustomPoster : Interactible
{
  [Header(" ----------------------------")]
  public string ThisCustomTexture;
  public int[] Mats;
  public MeshRenderer[] Rens;
  public Texture2D TextureContainer;

  public override void Interact(Person person)
  {
    Main.Instance.GameplayMenu.OpenJournal();
    Main.Instance.GameplayMenu.Select_ImagesList(this);
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(this.ThisCustomTexture);
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    this.ThisCustomTexture = Data[this._CurrentLoadingIndex++];
    this.AssignTexture();
  }

  public void AssignTexture()
  {
    string path = Main.AssetsFolder + "/CustomTextures/Objects/" + this.ThisCustomTexture;
    if ((Object) this.TextureContainer == (Object) null)
      this.TextureContainer = new Texture2D(0, 0);
    if (!File.Exists(path))
      return;
    this.TextureContainer.LoadImage(File.ReadAllBytes(path));
    for (int index = 0; index < this.Rens.Length; ++index)
    {
      if ((Object) this.Rens[index] != (Object) null)
        this.Rens[index].materials[this.Mats[index]].mainTexture = (Texture) this.TextureContainer;
    }
  }
}
