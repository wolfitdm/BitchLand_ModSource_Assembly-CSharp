// Decompiled with JetBrains decompiler
// Type: bl_CraftRecipes
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
