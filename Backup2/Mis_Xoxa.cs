// Decompiled with JetBrains decompiler
// Type: Mis_Xoxa
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class Mis_Xoxa : Mission
{
  public bl_HangZone XoxaZone;
  public AudioClip[] VoiceLines;
  public GameObject[] XoxaClothes;

  public bool AlreadyTalkedFor1stTime
  {
    get
    {
      return Main.Instance.GlobalVars.ContainsKey("FirstTimeTalking_Xoxa") && Main.Instance.GlobalVars.Get("FirstTimeTalking_Xoxa") == "1";
    }
    set => Main.Instance.GlobalVars.Set("FirstTimeTalking_Xoxa", value ? "1" : "0");
  }

  public bool AlreadyTalkedFor1stTimeAboutBl3
  {
    get
    {
      return Main.Instance.GlobalVars.ContainsKey("FirstTimeTalking_Xoxa_bl3") && Main.Instance.GlobalVars.Get("FirstTimeTalking_Xoxa_bl3") == "1";
    }
    set => Main.Instance.GlobalVars.Set("FirstTimeTalking_Xoxa_bl3", value ? "1" : "0");
  }

  public void Chat_Xoxa()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    if ((UnityEngine.Object) person.CurrentZone == (UnityEngine.Object) this.XoxaZone)
    {
      if (!this.AlreadyTalkedFor1stTime)
      {
        _gameplay.DisplaySubtitle("Hey welcome to my little inn", this.VoiceLines[0], (Action) (() =>
        {
          person.ResetAllShapes();
          _gameplay.DisplaySubtitle("The place is falling apart, but that's fine", this.VoiceLines[1], (Action) (() =>
          {
            person.ResetAllShapes();
            _gameplay.DisplaySubtitle("More death or less death makes no difference, to me atleast", this.VoiceLines[2], (Action) (() =>
            {
              person.ResetAllShapes();
              _gameplay.DisplaySubtitle("You can pay for a short stay", this.VoiceLines[3], (Action) (() =>
              {
                person.ResetAllShapes();
                _gameplay.DisplaySubtitle("Or you can pass the night with me, with the only cost of temporary love", this.VoiceLines[4], (Action) (() =>
                {
                  person.ResetAllShapes();
                  _gameplay.DisplaySubtitle("That would be usefull for my potion crafting needs", this.VoiceLines[5], (Action) (() =>
                  {
                    person.ResetAllShapes();
                    this.AlreadyTalkedFor1stTime = true;
                    this.Chat_Xoxa2();
                  }), person, e_BlendShapes.Smug);
                }), person, e_BlendShapes.Ahegao2);
              }), person, e_BlendShapes.Sad);
            }), person, e_BlendShapes.None);
          }), person, e_BlendShapes.None);
        }), person, e_BlendShapes.Smile);
      }
      else
      {
        int lineIndex = 0;
        string subText = Main.Instance.CityCharacters.Xoxa.PersonalityData.Reply_Hello(out lineIndex);
        _gameplay.DisplaySubtitle(subText, Main.Instance.CityCharacters.Xoxa.PersonalityData.Voice_Hello[lineIndex], new Action(this.Chat_Xoxa2));
      }
    }
    else
      person.ThisPersonInt.DefaultTalk();
  }

  public void Chat_Xoxa2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("What's your name?", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      _gameplay.DisplaySubtitle("My name is Xoxa", this.VoiceLines[64 /*0x40*/], new Action(person.ThisPersonInt.EndTheChat));
    }));
    _gameplay.AddChatOption("(100BN) I'd like a room please", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      if (Main.Instance.Player.Money >= 100)
        _gameplay.DisplaySubtitle("None are available at the moment", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
      else
        _gameplay.DisplaySubtitle(Main.GetLine(63 /*0x3F*/), Main.Instance.Personalities[0].Voice_Generics[5], new Action(person.ThisPersonInt.EndTheChat));
    }));
    _gameplay.AddChatOption("Yeh I'd like a night with you (INCOMPLETE)", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      person.ThisPersonInt.EndTheChat();
    }));
    if (!this.AlreadyTalkedFor1stTimeAboutBl3)
      _gameplay.AddChatOption("It says there \"Open since BL3\", what was BL3?", (Action) (() =>
      {
        this.AlreadyTalkedFor1stTimeAboutBl3 = true;
        _gameplay.DisplaySubtitle("What? You don't know what are the eras? How is that possible? Are you a really bad spy?", this.VoiceLines[7], (Action) (() => _gameplay.DisplaySubtitle("Must be a case of amnesia", this.VoiceLines[8], (Action) (() => _gameplay.DisplaySubtitle("Anyway maybe talking about them will bring your memories back", this.VoiceLines[9], (Action) (() => _gameplay.DisplaySubtitle("Currently we are in BL5, but if you want I can tell you about each of them individually", this.VoiceLines[10], new Action(this.Chat_History), person)), person)), person)), person);
      }));
    else
      _gameplay.AddChatOption("Tell me the history of...", new Action(this.Chat_History));
    _gameplay.AddChatOption("Bye", new Action(person.ThisPersonInt.EndTheChat));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void Chat_History()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("Thanks, I'm good for now", (Action) (() => _gameplay.DisplaySubtitle("What a pity", this.VoiceLines[6], new Action(person.ThisPersonInt.EndTheChat))));
    _gameplay.AddChatOption("...BL1", (Action) (() => _gameplay.DisplaySubtitle("Some big war happened many decades ago, and the world got destroyed as fuck", this.VoiceLines[11], (Action) (() => _gameplay.DisplaySubtitle("And everything was going to turn into anarchy sooner or later", this.VoiceLines[12], (Action) (() => _gameplay.DisplaySubtitle("But our glorious leader started trying to create this new nation", this.VoiceLines[13], (Action) (() => _gameplay.DisplaySubtitle("Where there would be order and peace, and also importantly, lots of sex", this.VoiceLines[14], (Action) (() => _gameplay.DisplaySubtitle("His first try was BL1, he literally just tried to get a few girls", this.VoiceLines[15], (Action) (() => _gameplay.DisplaySubtitle("and impregnate them, to repopulate under his education", this.VoiceLines[16 /*0x10*/], (Action) (() => _gameplay.DisplaySubtitle("But they all escaped.", this.VoiceLines[17], new Action(this.Chat_History), person)), person)), person)), person)), person)), person)), person)));
    _gameplay.AddChatOption("...BL2", (Action) (() => _gameplay.DisplaySubtitle("After BL1's girls escaped, our glorious leader went to try again", this.VoiceLines[18], (Action) (() => _gameplay.DisplaySubtitle("in a local community, trying to turn the people already there with his ideals", this.VoiceLines[19], (Action) (() => _gameplay.DisplaySubtitle("And it did saw some progress with the willing ones", this.VoiceLines[20], (Action) (() => _gameplay.DisplaySubtitle("But things were taking a bit too long when dealing with other people", this.VoiceLines[21], (Action) (() => _gameplay.DisplaySubtitle("who do not go straight into making things happen.", this.VoiceLines[22], (Action) (() => _gameplay.DisplaySubtitle("So without wasting more time, he selected only the people that were willing", this.VoiceLines[23], (Action) (() => _gameplay.DisplaySubtitle("Moved a bit away from there and created something akin to an educational and training structure", this.VoiceLines[24], (Action) (() => _gameplay.DisplaySubtitle("And there he found his first love too, Jeanne.", this.VoiceLines[25], (Action) (() => _gameplay.DisplaySubtitle("But things weren't perfect with everyone else there.", this.VoiceLines[26], (Action) (() => _gameplay.DisplaySubtitle("Especially the ones that were still in contact with the local community", this.VoiceLines[27], (Action) (() => _gameplay.DisplaySubtitle("So he had to take Jeanne and a few others away. Somewhere else", this.VoiceLines[28], new Action(this.Chat_History), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)));
    _gameplay.AddChatOption("...BL3", (Action) (() => _gameplay.DisplaySubtitle("After finding a new nice and safe piece of land", this.VoiceLines[29], (Action) (() => _gameplay.DisplaySubtitle("our small population at the time started building the BL3 city", this.VoiceLines[30], (Action) (() => _gameplay.DisplaySubtitle("that piece of land was right here", this.VoiceLines[31 /*0x1F*/], (Action) (() => _gameplay.DisplaySubtitle("every other BL era that came after has been built on top of BL3", this.VoiceLines[32 /*0x20*/], (Action) (() => _gameplay.DisplaySubtitle("Originally it was more like a small village", this.VoiceLines[33], (Action) (() => _gameplay.DisplaySubtitle("with wood buildings that could be build in a few days.", this.VoiceLines[34], (Action) (() => _gameplay.DisplaySubtitle("remember that there is no time to waste", this.VoiceLines[35], (Action) (() => _gameplay.DisplaySubtitle("things Have to be build and done Fast.", this.VoiceLines[36], (Action) (() => _gameplay.DisplaySubtitle("Wood was limited tho, so they started testing with concrete making, from recycling rumble around.", this.VoiceLines[37], (Action) (() => _gameplay.DisplaySubtitle("You can still find some old floor parts of those buildings near the fountain area.", this.VoiceLines[38], (Action) (() => _gameplay.DisplaySubtitle("Most those buildings themselves are just gone nowdays.", this.VoiceLines[39], (Action) (() => _gameplay.DisplaySubtitle("This building was one of the very first mostly concrete buildings in BL3.", this.VoiceLines[40], (Action) (() => _gameplay.DisplaySubtitle("But they reused a lot of bricks that were around.", this.VoiceLines[41], (Action) (() => _gameplay.DisplaySubtitle("Life was poor in BL3. but they kept growing.", this.VoiceLines[42], (Action) (() => _gameplay.DisplaySubtitle("At the time, they managed to make the biggest training center yet.", this.VoiceLines[43], (Action) (() => _gameplay.DisplaySubtitle("it's that huge windowless structure on the other side of the road.", this.VoiceLines[44], (Action) (() => _gameplay.DisplaySubtitle("And in there, massive amounts of people were trained into civilians", this.VoiceLines[45], (Action) (() => _gameplay.DisplaySubtitle("But like a curse from BL1, some of them didn't liked it here", this.VoiceLines[46], (Action) (() => _gameplay.DisplaySubtitle("and managed not only to escape, but also to fight back", this.VoiceLines[47], (Action) (() => _gameplay.DisplaySubtitle("they became the ESB.", this.VoiceLines[48 /*0x30*/], (Action) (() => _gameplay.DisplaySubtitle("The ruler's family doesn't want us to know that btw, they pretend it's a mystery how the ESB came to exist", this.VoiceLines[63 /*0x3F*/], (Action) (() => _gameplay.DisplaySubtitle("Nowdays they live like stupid tribals out there in the wilderness", this.VoiceLines[49], (Action) (() => _gameplay.DisplaySubtitle("Everytime we capture some and re-train them here, they always want to stay", this.VoiceLines[50], (Action) (() => _gameplay.DisplaySubtitle("But because the ones still out there are fooled.", this.VoiceLines[51], new Action(this.Chat_History), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)), person)));
    _gameplay.AddChatOption("[Next options]", new Action(this.chatHistory2));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void chatHistory2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("...BL4", (Action) (() => _gameplay.DisplaySubtitle("BL4 began when a series of events happened in short distance", this.VoiceLines[52], (Action) (() => _gameplay.DisplaySubtitle("Jeanne misteriously dissapeared", this.VoiceLines[53], (Action) (() => _gameplay.DisplaySubtitle("The ESB became stronger and able to pointlessly fight us back", this.VoiceLines[54], (Action) (() => _gameplay.DisplaySubtitle("And since Jeanne was gone, then Sarah became the leader's new main wife", this.VoiceLines[55], (Action) (() => _gameplay.DisplaySubtitle("Althought to this day, our leader still says", this.VoiceLines[56], (Action) (() => _gameplay.DisplaySubtitle("that if Jeanne ever get's back, she'll become main wife again.", this.VoiceLines[57], new Action(this.chatHistory2), person)), person)), person)), person)), person)), person)));
    _gameplay.AddChatOption("...BL5", (Action) (() => _gameplay.DisplaySubtitle("We are currently in BL5", this.VoiceLines[58], (Action) (() => _gameplay.DisplaySubtitle("it began when the ruler's favourite offspring became of age to start making their own city as well.", this.VoiceLines[59], (Action) (() => _gameplay.DisplaySubtitle("They had went out there in a explorarion trip.", this.VoiceLines[60], (Action) (() => _gameplay.DisplaySubtitle("I haven't seen them in a while too, I can't recognise them if I see them again sadly.", this.VoiceLines[61], (Action) (() => _gameplay.DisplaySubtitle("It would be hilarious if you were them and just forgot everything", this.VoiceLines[62], new Action(this.chatHistory2), person)), person)), person)), person)), person)));
    _gameplay.AddChatOption("[Previous options]", new Action(this.Chat_History));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }
}
