// Decompiled with JetBrains decompiler
// Type: bl_CraftRecipes
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
