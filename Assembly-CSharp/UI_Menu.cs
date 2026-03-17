// Decompiled with JetBrains decompiler
// Type: UI_Menu
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class UI_Menu : MonoBehaviour
{
  public string MenuName;
  public GameObject Root;
  public List<GameObject> EnableWhileOpen = new List<GameObject>();
  public List<Person> PeopleEnableWhileOpen = new List<Person>();
  public List<Person> PeopleDisableWhileOpen = new List<Person>();

  public bool _IsOpen => this.Root.activeSelf;

  public virtual void Open()
  {
    this.Root.SetActive(true);
    for (int index = 0; index < this.EnableWhileOpen.Count; ++index)
      this.EnableWhileOpen[index].SetActive(true);
    for (int index = 0; index < this.PeopleEnableWhileOpen.Count; ++index)
      this.PeopleEnableWhileOpen[index].CharacterVisible = true;
    for (int index = 0; index < this.PeopleDisableWhileOpen.Count; ++index)
      this.PeopleDisableWhileOpen[index].CharacterVisible = false;
  }

  public virtual void Close()
  {
    this.Root.SetActive(false);
    for (int index = 0; index < this.EnableWhileOpen.Count; ++index)
    {
      if ((Object) this.EnableWhileOpen[index] != (Object) null)
        this.EnableWhileOpen[index].SetActive(false);
    }
  }
}
