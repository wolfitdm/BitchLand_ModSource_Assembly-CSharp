// Decompiled with JetBrains decompiler
// Type: bl_CraftRecipes
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
  public int Subcategory;

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
