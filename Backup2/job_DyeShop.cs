// Decompiled with JetBrains decompiler
// Type: job_DyeShop
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class job_DyeShop : bl_WorkJobManager
{
  public AudioClip[] VoiceLines;

  public void Chat_AtWork()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.DisplaySubtitle("Welcome to my dye shop", this.VoiceLines[0], (Action) (() =>
    {
      _gameplay.RemoveAllChatOptions();
      _gameplay.AddChatOption("What do you do here?", (Action) (() =>
      {
        Main.Instance.GameplayMenu.EnableMove();
        _gameplay.DisplaySubtitle("I can re-color your clothing or hair here", this.VoiceLines[1], new Action(person.ThisPersonInt.EndTheChat), person);
      }));
      _gameplay.AddChatOption("(100bn) I want to Dye my hair to...", (Action) (() =>
      {
        if (Main.Instance.Player.Money >= 100)
        {
          Main.Instance.Player.Money -= 100;
          Main.Instance.GameplayMenu.ShowNotification("Paied 100 bitch notes");
          Main.Instance.CustomizeMenu.Open_HairColorOnly((Transform) null);
          Main.Instance.CustomizeMenu.Open_HairStyleOnly((Transform) null);
        }
        else
          _gameplay.DisplaySubtitle(Main.GetLine(63 /*0x3F*/), Main.Instance.Personalities[0].Voice_Generics[5], new Action(person.ThisPersonInt.EndTheChat));
      }));
      _gameplay.AddChatOption("(50bn) I want to Dye my clothing to...", (Action) (() => { }));
      _gameplay.AddChatOption("Is it possible to dye skin and eyes?", (Action) (() => _gameplay.DisplaySubtitle("Uuhmm, not that I know of...?", this.VoiceLines[2], (Action) (() => _gameplay.DisplaySubtitle("But I guess, if they ever put some scientists in the research center to study that", this.VoiceLines[3], new Action(person.ThisPersonInt.EndTheChat), person)), person)));
      _gameplay.AddChatOption("Bye", (Action) (() => person.ThisPersonInt.EndTheChat()));
      _gameplay.SelectChatOption(0);
      Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
    }), person);
  }
}
