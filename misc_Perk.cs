// Decompiled with JetBrains decompiler
// Type: misc_Perk
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class misc_Perk : MonoBehaviour
{
  public string PerkID;
  [Multiline]
  public string Description;
  public Button TheButton;
  public misc_Perk[] NextPerks;
  public int LvlType;
  public int Cost;
  public bool ScatPerk;

  public void ShowDescription()
  {
    if (!this.TheButton.interactable)
      return;
    if (this.ScatPerk)
    {
      if (Main.Instance.ScatContent)
        Main.Instance.GameplayMenu.ShowDescription(this.Description);
      else
        Main.Instance.GameplayMenu.ShowDescription("Disabled in Settings");
    }
    else
      Main.Instance.GameplayMenu.ShowDescription(this.Description);
  }

  public void HideDescription() => Main.Instance.GameplayMenu.HideDescription();

  public void SetAvailable()
  {
    if (this.TheButton.interactable)
      return;
    this.TheButton.interactable = true;
    this.TheButton.image.color = Main.Instance.GameplayMenu.AvailablePerk;
  }

  public void Click()
  {
    if (!(this.TheButton.image.color == Main.Instance.GameplayMenu.AvailablePerk))
      return;
    switch (this.LvlType)
    {
      case 0:
        if (Main.Instance.Player.SexSkills >= this.Cost)
        {
          Main.Instance.Player.SexSkills -= this.Cost;
          Main.Instance.GameplayMenu.LvlUPAmounts[2].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
          Main.Instance.GameplayMenu.LvlUPLevels[2].text = "Lvl " + Main.Instance.Player.SexSkills.ToString();
          this.TheButton.image.color = Color.white;
          for (int index = 0; index < this.NextPerks.Length; ++index)
            this.NextPerks[index].SetAvailable();
          Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.GameplayMenu.JournalPerkSound, 3f);
          if (Main.Instance.Player.Perks.Contains(this.PerkID))
            break;
          Main.Instance.Player.Perks.Add(this.PerkID);
          this.OnAddSpecificPerk(this.PerkID);
          break;
        }
        Main.Instance.GameplayMenu.PerkDescText.text = $"Costs {this.Cost.ToString()} Sex level";
        break;
      case 1:
        if (Main.Instance.Player.WorkSkills >= this.Cost)
        {
          Main.Instance.Player.WorkSkills -= this.Cost;
          this.TheButton.image.color = Color.white;
          Main.Instance.GameplayMenu.LvlUPAmounts[0].fillAmount = (float) Main.Instance.Player.WorkXpThisLvl / (float) Main.Instance.Player.WorkXpThisLvlMax;
          Main.Instance.GameplayMenu.LvlUPLevels[0].text = "Lvl " + Main.Instance.Player.WorkSkills.ToString();
          for (int index = 0; index < this.NextPerks.Length; ++index)
            this.NextPerks[index].SetAvailable();
          Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.GameplayMenu.JournalPerkSound, 3f);
          if (Main.Instance.Player.Perks.Contains(this.PerkID))
            break;
          Main.Instance.Player.Perks.Add(this.PerkID);
          this.OnAddSpecificPerk(this.PerkID);
          break;
        }
        Main.Instance.GameplayMenu.PerkDescText.text = $"Costs {this.Cost.ToString()} Work level";
        break;
      case 2:
        if (Main.Instance.Player.ArmySkills >= this.Cost)
        {
          Main.Instance.Player.ArmySkills -= this.Cost;
          this.TheButton.image.color = Color.white;
          Main.Instance.GameplayMenu.LvlUPAmounts[1].fillAmount = (float) Main.Instance.Player.ArmyXpThisLvl / (float) Main.Instance.Player.ArmyXpThisLvlMax;
          Main.Instance.GameplayMenu.LvlUPLevels[1].text = "Lvl " + Main.Instance.Player.ArmySkills.ToString();
          for (int index = 0; index < this.NextPerks.Length; ++index)
            this.NextPerks[index].SetAvailable();
          Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.GameplayMenu.JournalPerkSound, 3f);
          if (Main.Instance.Player.Perks.Contains(this.PerkID))
            break;
          Main.Instance.Player.Perks.Add(this.PerkID);
          this.OnAddSpecificPerk(this.PerkID);
          break;
        }
        Main.Instance.GameplayMenu.PerkDescText.text = $"Costs {this.Cost.ToString()} Army level";
        break;
    }
  }

  public void Unlock_NoUI()
  {
    this.TheButton.interactable = true;
    this.TheButton.image.color = Color.white;
    for (int index = 0; index < this.NextPerks.Length; ++index)
      this.NextPerks[index].SetAvailable();
  }

  public void OnAddSpecificPerk(string perk)
  {
    switch (perk)
    {
      case "Trash Comfort":
        Main.Instance.Player.Fetishes.Add(e_Fetish.Dirty);
        if (!Main.Instance.Player.Fetishes.Contains(e_Fetish.Clean))
          break;
        Main.Instance.Player.Fetishes.Remove(e_Fetish.Clean);
        break;
      case "Masochist":
        Main.Instance.Player.Fetishes.Add(e_Fetish.Masochist);
        break;
    }
  }
}
