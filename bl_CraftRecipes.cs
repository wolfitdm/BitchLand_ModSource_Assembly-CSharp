// Decompiled with JetBrains decompiler
// Type: bl_CraftRecipes
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class bl_CraftRecipes
{
  [Multiline]
  public string Name;
  public bl_RecipesNeed[] Ingredients;
  public string[] OutCome;
  public string ResearchNeeded;
  public string TableNeeded;
  public bool scat;

  public bool IsAvailableFor(Person person)
  {
    if (this.ResearchNeeded.Length <= 0)
      return true;
    for (int index = 0; index < person.Perks.Count; ++index)
    {
      if (person.Perks[index] == this.ResearchNeeded)
        return true;
    }
    return false;
  }
}
