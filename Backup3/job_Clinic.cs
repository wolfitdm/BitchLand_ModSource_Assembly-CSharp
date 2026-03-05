// Decompiled with JetBrains decompiler
// Type: job_Clinic
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class job_Clinic : MonoBehaviour
{
  public Transform PregnancySpot;
  public GameObject PlayerDetector;
  public Transform PregnancyGirlSpot;
  public Transform PregnancyDoctorSpot;
  public Transform PregnancyDoctorSpotTool;
  public Interactible DoctorSitSpot;
  public Person Doctor;
  public AudioClip[] VoiceLines;
  public int_HealthPod[] VatPodSpots;
  public Int_Door PodsDoor;
  public Transform ShowPodsSpot;
  public bool PlayerBirthKeep;
  public Girl Client;
  public float UnPregTimer;

  public void SetDoctor(Person person)
  {
    this.Doctor = person;
    this.Doctor.ThisPersonInt.StartTalkFunc = "Chat_Doctor";
    this.Doctor.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    this.DoctorSitSpot.Interact(this.Doctor);
  }

  public void Chat_Doctor()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("What's your name?", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      person.PlayerKnowsName = true;
      person.ThisPersonInt.InteractText = "Talk to " + person.Name;
      string[] strArray = new string[3]
      {
        person.Name,
        "It's " + person.Name,
        "My name's " + person.Name
      };
      _gameplay.DisplaySubtitle(strArray[UnityEngine.Random.Range(0, strArray.Length)], (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
    }));
    _gameplay.AddChatOption("You're cute, let's have sex", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      _gameplay.DisplaySubtitle("I can't right now", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
    }));
    _gameplay.AddChatOption("I'm hurt, can you heal me?", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      _gameplay.DisplaySubtitle("Take this pill, and now eat some food out there", this.VoiceLines[0], new Action(person.ThisPersonInt.EndTheChat));
      Main.Instance.GameplayMenu.ShowNotification("Ate a sugar pill");
      Main.Instance.Player.States[20] = false;
      Main.Instance.Player.States[21] = false;
      Main.Instance.Player.SetBodyTexture();
    }));
    Girl _npcFemalePreg = (Girl) null;
    if (Main.Instance.PeopleFollowingPlayer.Count != 0)
    {
      for (int index = 0; index < Main.Instance.PeopleFollowingPlayer.Count; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.PeopleFollowingPlayer[index] != (UnityEngine.Object) null && Main.Instance.PeopleFollowingPlayer[index] is Girl && (Main.Instance.PeopleFollowingPlayer[index] as Girl).Pregnant)
        {
          _npcFemalePreg = Main.Instance.PeopleFollowingPlayer[index] as Girl;
          break;
        }
      }
    }
    if ((UnityEngine.Object) _npcFemalePreg != (UnityEngine.Object) null)
    {
      _gameplay.AddChatOption("(Abortion) " + _npcFemalePreg.Name + " is pregnant, can you get rid of it?", (Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeOut(1f, (Action) (() =>
      {
        Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f)));
        _npcFemalePreg.GiveBirth();
        this.Doctor.ThisPersonInt.EndTheChat();
      }))));
      _gameplay.AddChatOption("(500bn) " + _npcFemalePreg.Name + " is pregnant, can you help them give birth?", (Action) (() =>
      {
        if (!this.PodAvailable())
        {
          Main.Instance.GameplayMenu.EnableMove();
          _gameplay.DisplaySubtitle("No pods are available right now", (AudioClip) null, new Action(this.Doctor.ThisPersonInt.EndTheChat));
        }
        else if (Main.Instance.Player.Money >= 500)
        {
          Main.Instance.Player.Money -= 500;
          Main.Instance.GameplayMenu.ShowNotification("Paied 500bn");
          Main.Instance.GameplayMenu.TheScreenFader.FadeOut(1f, (Action) (() =>
          {
            Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f)));
            Person pregnancyParent3 = _npcFemalePreg.PregnancyParent;
            if ((UnityEngine.Object) pregnancyParent3 == (UnityEngine.Object) null && pregnancyParent3 is Girl && (pregnancyParent3 as Girl).s_PregnancyParent.Length > 0)
            {
              string pregnancyParent4 = (pregnancyParent3 as Girl).s_PregnancyParent;
              for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
              {
                if (Main.Instance.SpawnedPeople[index].WorldSaveID == pregnancyParent4)
                {
                  pregnancyParent3 = Main.Instance.SpawnedPeople[index];
                  break;
                }
              }
            }
            this.SpawnBirthIntoPod((Person) _npcFemalePreg, pregnancyParent3);
            this.Doctor.ThisPersonInt.EndTheChat();
            Main.Instance.GameplayMenu.DisplaySubtitle("Alright, done", this.VoiceLines[3], new Action(this.Doctor.ThisPersonInt.EndTheChat));
            _npcFemalePreg.GiveBirth();
          }));
        }
        else
        {
          Main.Instance.GameplayMenu.EnableMove();
          _gameplay.DisplaySubtitle("You don't have 500bn", (AudioClip) null, new Action(this.Doctor.ThisPersonInt.EndTheChat));
        }
      }));
    }
    else if (Main.Instance.Player is Girl)
    {
      _gameplay.AddChatOption("(Abortion) I'm pregnant, can you get rid of it?", (Action) (() =>
      {
        this.PlayerBirthKeep = false;
        Main.Instance.GameplayMenu.EnableMove();
        _gameplay.DisplaySubtitle("Oh yes I can. Come this way", this.VoiceLines[1], new Action(person.ThisPersonInt.EndTheChat));
        Main.Instance.CityCharacters.Maylenne.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "HelpPregnancy",
          ActionPlace = this.PregnancyDoctorSpotTool,
          OnArrive = (Action) (() => this.PlayerDetector.SetActive(true))
        });
      }));
      string chattext = this.HadFirstChild ? "(500bn) (Spawns npc) I'm pregnant, can you help me give birth?" : "(Spawns npc) I'm pregnant, can you help me give birth?";
      _gameplay.AddChatOption(chattext, (Action) (() =>
      {
        if (!(Main.Instance.Player as Girl).Pregnant)
        {
          Main.Instance.GameplayMenu.EnableMove();
          _gameplay.DisplaySubtitle("You're not pregnant", this.VoiceLines[5], new Action(person.ThisPersonInt.EndTheChat));
        }
        else
        {
          if (this.HadFirstChild)
          {
            if (Main.Instance.Player.Money >= 500)
            {
              Main.Instance.Player.Money -= 500;
              Main.Instance.GameplayMenu.ShowNotification("Paied 500bn");
            }
            else
            {
              Main.Instance.GameplayMenu.EnableMove();
              _gameplay.DisplaySubtitle("You don't have 500bn", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
              return;
            }
          }
          this.PlayerBirthKeep = true;
          Main.Instance.GameplayMenu.EnableMove();
          _gameplay.DisplaySubtitle("Oh yes I can. Come this way", this.VoiceLines[1], new Action(person.ThisPersonInt.EndTheChat));
          Main.Instance.CityCharacters.Maylenne.StartScheduleTask(new Person.ScheduleTask()
          {
            IDName = "HelpPregnancyBirth",
            ActionPlace = this.PregnancyDoctorSpotTool,
            OnArrive = (Action) (() => this.PlayerDetector.SetActive(true))
          });
        }
      }));
    }
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public bool HadFirstChild
  {
    set => Main.Instance.GlobalVars[nameof (HadFirstChild)] = value ? "1" : "0";
    get => Main.Instance.GlobalVars[nameof (HadFirstChild)] == "1";
  }

  public void PlayerDetectorInside()
  {
    this.PlayerDetector.SetActive(false);
    Main.Instance.Player.NoEnergyLoss = true;
    Main.Instance.CityCharacters.Maylenne.NoEnergyLoss = true;
    Main.Instance.Player.AddMoveBlocker("PregBirthing");
    Main.Instance.Player.Anim.Play("PregBirth");
    Main.Instance.Player.transform.SetPositionAndRotation(this.PregnancyGirlSpot.position, this.PregnancyGirlSpot.rotation);
    Main.Instance.CityCharacters.Maylenne.transform.SetPositionAndRotation(this.PregnancyDoctorSpotTool.position, this.PregnancyDoctorSpotTool.rotation);
    if (this.PlayerBirthKeep)
    {
      Main.Instance.GameplayMenu.PersonChattingTo = Main.Instance.CityCharacters.Maylenne;
      Main.Instance.GameplayMenu.DisplaySubtitle("Okay just spit it out", this.VoiceLines[6], (Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeOut(1f, (Action) (() =>
      {
        Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f)));
        this.SpawnBirthIntoPod(Main.Instance.Player, (Main.Instance.Player as Girl).PregnancyParent);
        Main.Instance.Player.RemoveMoveBlocker("PregBirthing");
        Main.Instance.Player.NoEnergyLoss = false;
        this.PodsDoor.OpenDoor();
        if (!this.HadFirstChild)
        {
          this.HadFirstChild = true;
          this.Client = Main.Instance.Player as Girl;
          this.CompleteBirth(false);
          Main.Instance.GameplayMenu.DisplaySubtitle("Alright, your newborn is now in the growth vat's room", this.VoiceLines[7], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Just throu this door if you wanna see them", this.VoiceLines[8], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("The pods make them instantly turn into a full grown adult", this.VoiceLines[9], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("How does it work? The answer is \"Don't question it.\"", this.VoiceLines[10], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("This first one is free, next ones will be 500bn", this.VoiceLines[11], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("if you don't wanna pay, you'll need to have them outside this city (in next build)", this.VoiceLines[12], (Action) (() =>
          {
            this.Doctor.ThisPersonInt.EndTheChat();
            Main.Instance.CityCharacters.Maylenne.StartScheduleTask(new Person.ScheduleTask()
            {
              IDName = "DoctorSit",
              ActionPlace = this.DoctorSitSpot.NavMeshInteractSpot,
              OnArrive = (Action) (() => this.DoctorSitSpot.Interact(Main.Instance.CityCharacters.Maylenne))
            });
          }), this.Doctor)), this.Doctor)), this.Doctor)), this.Doctor)), this.Doctor)), this.Doctor);
        }
        else
        {
          this.Client = Main.Instance.Player as Girl;
          this.CompleteBirth();
        }
      }))), this.Doctor);
    }
    else
    {
      Main.Instance.CityCharacters.Maylenne.PutPenis();
      Main.Instance.GameplayMenu.PersonChattingTo = Main.Instance.CityCharacters.Maylenne;
      Main.Instance.GameplayMenu.DisplaySubtitle("I'm now gonna...take my tool out", this.VoiceLines[2], (Action) (() =>
      {
        Main.Instance.CityCharacters.Maylenne.transform.SetPositionAndRotation(this.PregnancyDoctorSpot.position, this.PregnancyDoctorSpot.rotation);
        Main.Instance.SexScene.SpawnSexScene(5, 3, Main.Instance.CityCharacters.Maylenne, Main.Instance.Player, canControl: false).On_ClothingToggle(false);
        Main.Instance.SexScene.CanExitSexScene = false;
        this.UnPregTimer = 20f;
        this.Client = Main.Instance.Player as Girl;
        Main.Instance.SexScene.ProgressSlider.transform.parent.gameObject.SetActive(true);
        Main.Instance.MainThreads.Add(new Action(this.UnPregnating));
      }), this.Doctor);
    }
  }

  public void CompleteBirth(bool speak = true)
  {
    this.UnPregTimer = 20f;
    Main.Instance.MainThreads.Remove(new Action(this.UnPregnating));
    Main.Instance.SexScene.EndSexScene();
    Main.Instance.Player.RemoveMoveBlocker("PregBirthing");
    Main.Instance.Player.NoEnergyLoss = false;
    if ((UnityEngine.Object) this.Client != (UnityEngine.Object) null)
      this.Client.GiveBirth();
    Main.Instance.SexScene.ProgressSlider.transform.parent.gameObject.SetActive(false);
    this.Client.transform.position = this.PregnancySpot.position;
    if (speak)
      Main.Instance.GameplayMenu.DisplaySubtitle("Alright, done", this.VoiceLines[3], new Action(this.Doctor.ThisPersonInt.EndTheChat), this.Doctor);
    Main.Instance.CityCharacters.Maylenne.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "DoctorSit",
      ActionPlace = this.DoctorSitSpot.NavMeshInteractSpot,
      OnArrive = (Action) (() => this.DoctorSitSpot.Interact(Main.Instance.CityCharacters.Maylenne))
    });
    this.Client = (Girl) null;
  }

  public void UnPregnating()
  {
    this.Client.PregnancyPercent -= Time.deltaTime / 10f;
    this.UnPregTimer -= Time.deltaTime;
    Main.Instance.SexScene.ProgressSlider.fillAmount = this.UnPregTimer / 20f;
    if ((double) this.UnPregTimer >= 0.0)
      return;
    this.Client = Main.Instance.Player as Girl;
    this.CompleteBirth();
  }

  public int_HealthPod GetPodAvailable()
  {
    for (int index = 0; index < this.VatPodSpots.Length; ++index)
    {
      if (this.VatPodSpots[index].CanInteract)
        return this.VatPodSpots[index];
    }
    return (int_HealthPod) null;
  }

  public bool PodAvailable() => (UnityEngine.Object) this.GetPodAvailable() != (UnityEngine.Object) null;

  public void SpawnBirthIntoPod(Person parent1, Person parent2)
  {
    int_HealthPod podAvailable = this.GetPodAvailable();
    if (!((UnityEngine.Object) podAvailable != (UnityEngine.Object) null))
      return;
    Person offspring = Main.Instance.CreateOffspring(parent1, parent2);
    podAvailable.PodUseType = 2;
    podAvailable.Interact(offspring);
    offspring.IsPlayerDescendant = true;
    offspring.CantBeForced = true;
  }
}
