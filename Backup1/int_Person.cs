// Decompiled with JetBrains decompiler
// Type: int_Person
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class int_Person : Interactible
{
  public Person ThisPerson;
  public MonoBehaviour StartTalkMono;
  public string StartTalkFunc;
  public int DefaultChat_PickedOption;
  public PersonInteractType _PersonInteractType;
  public bool _Waiting;
  public bool FollowCheck;
  public bool _HasSexControl;
  public Transform TheLeashRoot;
  public Transform TheLeashTiedSpot;

  public override void Awake()
  {
    base.Awake();
    try
    {
      if (this.ThisPerson.CinematicCharacter)
        return;
      this.SetDefaultInteraction();
    }
    catch
    {
    }
  }

  public override void Interact(Person person)
  {
    if (this.ThisPerson.CurrentScheduleTask != null && this.ThisPerson.CurrentScheduleTask.IDName == "escape" && !this.ThisPerson.Restrained)
      return;
    this.ThisPerson.CreatePersonRelationship();
    switch (this._PersonInteractType)
    {
      case PersonInteractType.DefaultTalk:
        base.Interact(person);
        Main.Instance.GameplayMenu.EnterChatWith(this.ThisPerson, this.StartTalkMono, this.StartTalkFunc);
        break;
      case PersonInteractType.Sex:
        Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
        break;
      case PersonInteractType.NonChat:
        if (!((UnityEngine.Object) this.StartTalkMono != (UnityEngine.Object) null))
          break;
        this.StartTalkMono.Invoke(this.StartTalkFunc, 0.0f);
        break;
    }
  }

  public void NPCTalk(Person person) => base.Interact(person);

  public void SetDefaultInteraction()
  {
    this.InteractText = this.ThisPerson.PlayerKnowsName ? Main.GetLine(1) + this.ThisPerson.Name : Main.GetLine(0);
    this._PersonInteractType = PersonInteractType.DefaultTalk;
  }

  public void SetSexInteraction()
  {
    this.InteractText = Main.GetLine(2);
    this._PersonInteractType = PersonInteractType.Sex;
  }

  public void DefaultTalk()
  {
    Main.Instance.Player.UserControl.StopMoving();
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    int lineIndex = 0;
    string str1 = this.ThisPerson.PersonalityData.Reply_Hello(out lineIndex);
    Action action = new Action(this.DefaultTalk_options);
    if (this.ThisPerson.PersonType.ThisType == Person_Type.Prisioner && Main.Instance.OpenWorld)
      action = new Action(this.RestrainedInteraction_options);
    string subText = str1;
    AudioClip voiceLine = this.ThisPerson.PersonalityData.Voice_Hello[lineIndex];
    Action after = action;
    gameplayMenu.DisplaySubtitle(subText, voiceLine, after);
    bool flag = true;
    if (!((UnityEngine.Object) Main.Instance.GameplayMenu.ShortDesc != (UnityEngine.Object) null & flag))
      return;
    Main.Instance.GameplayMenu.ShortDesc.SetActive(true);
    Main.Instance.GameplayMenu.ShortPositiveSlider.fillAmount = 0.0f;
    Main.Instance.GameplayMenu.ShortNegativeSlider.fillAmount = 0.0f;
    if (this.ThisPerson.Favor > 0)
      Main.Instance.GameplayMenu.ShortPositiveSlider.fillAmount = (float) this.ThisPerson.Favor / 100f;
    else
      Main.Instance.GameplayMenu.ShortNegativeSlider.fillAmount = (float) -this.ThisPerson.Favor / 100f;
    string str2 = (this.ThisPerson.Penis.transform.localScale.x * 10f).ToString("###") + "cm Penis";
    string str3 = "None";
    if (this.ThisPerson.Fetishes.Count > 0)
    {
      str3 = this.ThisPerson.Fetishes[0].ToString();
      for (int index = 1; index < this.ThisPerson.Fetishes.Count; ++index)
        str3 = str3 + ", " + this.ThisPerson.Fetishes[index].ToString();
      if (!Main.Instance.ScatContent)
        str3 = str3.Replace("Scat", "*");
    }
    Main.Instance.GameplayMenu.ShortPersonDesc.text = this.ThisPerson.PersonType.ThisType.ToString() + " (" + this.ThisPerson.Personality.ToString() + ")\nSexed " + this.ThisPerson.TimesSexedPlayer.ToString() + " times\n" + str3 + "\n" + (this.ThisPerson.transform.localScale.y + 0.75f).ToString("##.##") + " Meters " + UI_Gameplay.MetersToFeetAndInches(this.ThisPerson.transform.localScale.y + 0.75f) + "\n" + (this.ThisPerson is Girl ? (((Girl) this.ThisPerson).Futa ? str2 : "No Penis") : str2) + "\n" + (this.ThisPerson is Girl ? (((Girl) this.ThisPerson).Pregnant ? "Pregnancy: " + ((Girl) this.ThisPerson).PregnancyDisplayPercent : "Not Pregnant") : string.Empty);
  }

  public void OnCloseNPCInventory()
  {
    Main.Instance.GameplayMenu.EnableMove();
    this.EndTheChat();
  }

  public void DefaultTalk_options()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption(Main.GetLine(3), (Action) (() =>
    {
      int lineIndex = 0;
      _gameplay.DisplaySubtitle(this.ThisPerson.PersonalityData.Reply_Hello(out lineIndex), this.ThisPerson.PersonalityData.Voice_Hello[lineIndex], new Action(this.EndTheChat));
      Main.Instance.GameplayMenu.EnableMove();
    }));
    if (!this.ThisPerson.PlayerKnowsName)
      _gameplay.AddChatOption(Main.GetLine(4), (Action) (() =>
      {
        Main.Instance.GameplayMenu.EnableMove();
        this.ThisPerson.PlayerKnowsName = true;
        this.InteractText = Main.GetLine(1) + this.ThisPerson.Name;
        string[] strArray = new string[3]
        {
          this.ThisPerson.Name,
          Main.GetLine(5) + this.ThisPerson.Name,
          Main.GetLine(6) + this.ThisPerson.Name
        };
        _gameplay.DisplaySubtitle(strArray[UnityEngine.Random.Range(0, strArray.Length)], (AudioClip) null, new Action(this.EndTheChat));
      }));
    else
      _gameplay.AddChatOption(Main.GetLine(7), (Action) (() =>
      {
        if (this.ThisPerson.Favor < 10)
        {
          Main.Instance.GameplayMenu.EnableMove();
          _gameplay.DisplaySubtitle(Main.GetLine(59), Main.Instance.Personalities[0].Voice_Generics[2], new Action(this.EndTheChat));
        }
        else
        {
          _gameplay.RemoveAllChatOptions();
          _gameplay.AddChatOption(Main.GetLine(8), (Action) (() =>
          {
            Main.Instance.GameplayMenu.EnableMove();
            _gameplay.DisplaySubtitle(Main.GetLine(9), Main.Instance.Personalities[0].Voice_Generics[1], new Action(this.EndTheChat));
            this.ThisPerson.AddCullBlocker("Following");
            if (!Main.Instance.PeopleFollowingPlayer.Contains(this.ThisPerson))
              Main.Instance.PeopleFollowingPlayer.Add(this.ThisPerson);
            this.StartTalkFunc = "FollowingChat";
            this.ThisPerson.RandActionTimer = 5f;
            this.ThisPerson.DecideTimer = 5f;
            this.ThisPerson.CompleteScheduleTask(false);
            this.ThisPerson.FreeScheduleTasks.Clear();
            Main.RunInNextFrame((Action) (() => this.ThisPerson.StartScheduleTask(new Person.ScheduleTask()
            {
              IDName = "FollowPlayer",
              ActionPlace = Main.Instance.Player.transform,
              OnArrive = (Action) (() => { }),
              WhileGoing = (Action) (() =>
              {
                this.ThisPerson.RandActionTimer += Time.deltaTime;
                if ((double) this.ThisPerson.RandActionTimer <= 0.25)
                  return;
                this.ThisPerson.RandActionTimer = 0.0f;
                float num = Vector3.Distance(Main.Instance.Player.transform.position, this.transform.position);
                if ((double) num > 1.0)
                  this.ThisPerson.SetDestination(this.ThisPerson.CurrentScheduleTask.ActionPlace);
                else if (this.ThisPerson.navMesh.isOnNavMesh)
                  this.ThisPerson.navMesh.isStopped = true;
                this.ThisPerson.navMesh.speed = (double) num > 4.0 ? 4f : 1f;
              }),
              OnInterrupt_WhileGoing = (Action) (() =>
              {
                this.ThisPerson.RemoveCullBlocker("Following");
                Main.Instance.PeopleFollowingPlayer.Remove(this.ThisPerson);
              })
            })));
          }));
          _gameplay.AddChatOption(Main.GetLine(11), (Action) (() =>
          {
            this.ThisPerson.RemoveCullBlocker("Following");
            Main.Instance.PeopleFollowingPlayer.Remove(this.ThisPerson);
            Main.Instance.GameplayMenu.EnableMove();
            _gameplay.DisplaySubtitle(Main.GetLine(9), Main.Instance.Personalities[0].Voice_Generics[1], new Action(this.EndTheChat));
            this.StartTalkFunc = "FollowingChat";
            this.ThisPerson.RandActionTimer = 0.0f;
            this.ThisPerson.StartScheduleTask(new Person.ScheduleTask()
            {
              IDName = "WaitPlayer",
              ActionPlace = this.ThisPerson.transform,
              OnArrive = (Action) (() => { })
            });
          }));
          _gameplay.AddChatOption(Main.GetLine(12), (Action) (() =>
          {
            this.ThisPerson.RemoveCullBlocker("Following");
            Main.Instance.PeopleFollowingPlayer.Remove(this.ThisPerson);
            Main.Instance.GameplayMenu.EnableMove();
            _gameplay.DisplaySubtitle(Main.GetLine(9), Main.Instance.Personalities[0].Voice_SexLead[1], new Action(this.EndTheChat));
            this.ThisPerson.Home = this.ThisPerson.CurrentZone;
            if (!((UnityEngine.Object) this.ThisPerson.Home.Location != (UnityEngine.Object) null))
              return;
            this.ThisPerson.HomeSpot = this.ThisPerson.Home.Location;
          }));
          _gameplay.AddChatOption(Main.GetLine(13), (Action) (() =>
          {
            if (this.ThisPerson.Favor < 70)
            {
              Main.Instance.GameplayMenu.EnableMove();
              _gameplay.DisplaySubtitle(Main.GetLine(59), Main.Instance.Personalities[0].Voice_Generics[2], new Action(this.EndTheChat));
            }
            else
            {
              Main.Instance.GameplayMenu.OpenContainer((Int_Storage) this.ThisPerson.InventoryStorage);
              Main.Instance.GameplayMenu.OnCloseContainer.Clear();
              Main.Instance.GameplayMenu.OnCloseContainer.Add(new Action(this.OnCloseNPCInventory));
              Main.Instance.GameplayMenu.ShortDesc.SetActive(false);
            }
          }));
          _gameplay.SelectChatOption(0);
          Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
        }
      }));
    if (this.ThisPerson.PersonType.ThisType != Person_Type.FES)
      _gameplay.AddChatOption(Main.GetLine(14), (Action) (() =>
      {
        Main.Instance.GameplayMenu.EnableMove();
        if ((UnityEngine.Object) this.ThisPerson.WorkJob == (UnityEngine.Object) null)
        {
          if ((UnityEngine.Object) this.ThisPerson.PersonType != (UnityEngine.Object) null)
          {
            switch (this.ThisPerson.PersonType.ThisType)
            {
              case Person_Type.ESB:
                _gameplay.DisplaySubtitle("I serve the ESB", (AudioClip) null, new Action(this.EndTheChat));
                return;
              case Person_Type.Worker:
                _gameplay.DisplaySubtitle("Any worker class jobs available when I feel like it", (AudioClip) null, new Action(this.EndTheChat));
                return;
              case Person_Type.Civilian:
                _gameplay.DisplaySubtitle("Sometimes at the clubs, sometimes in science, depends", (AudioClip) null, new Action(this.EndTheChat));
                return;
              case Person_Type.HigherCivilian:
              case Person_Type.Royal:
                _gameplay.DisplaySubtitle("I'm usually busy with a few things", (AudioClip) null, new Action(this.EndTheChat));
                return;
              case Person_Type.Army:
                _gameplay.DisplaySubtitle("Just army work", (AudioClip) null, new Action(this.EndTheChat));
                return;
            }
          }
          _gameplay.DisplaySubtitle(Main.GetLine(15), (AudioClip) null, new Action(this.EndTheChat));
        }
        else
          _gameplay.DisplaySubtitle(this.ThisPerson.WorkJob.JobName, (AudioClip) null, new Action(this.EndTheChat));
      }));
    if (Main.Instance.FreeWorldPatch || !this.ThisPerson.IsPlayerDescendant)
      _gameplay.AddChatOption(Main.GetLine(37), (Action) (() =>
      {
        _gameplay.RemoveAllChatOptions();
        if (this.ThisPerson.State == Person_State.Work)
        {
          _gameplay.DisplaySubtitle(Main.GetLine(21), Main.Instance.Personalities[0].Voice_Generics[0], new Action(this.EndTheChat));
          Main.Instance.GameplayMenu.EnableMove();
        }
        else if (this.ThisPerson.PersonType.ThisType == Person_Type.FES)
        {
          if (Main.Instance.Player.HasPenis)
            Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
          else if (this.ThisPerson.HasPenis)
            Main.Instance.SexScene.SpawnSexScene(2, 0, this.ThisPerson, Main.Instance.Player);
          else
            Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
          this.EndTheChat();
        }
        else
        {
          string str1 = "(+Relationship) ";
          string[] strArray1 = new string[4]
          {
            str1 + Main.GetLine(16),
            str1 + Main.GetLine(17),
            str1 + Main.GetLine(18),
            str1 + Main.GetLine(19)
          };
          _gameplay.AddChatOption(strArray1[UnityEngine.Random.Range(0, strArray1.Length)], (Action) (() =>
          {
            this._HasSexControl = true;
            if (this.ThisPerson.Favor < 20)
            {
              int lineIndex;
              _gameplay.DisplaySubtitle(this.ThisPerson.PersonalityData.Reply_SexReject(out lineIndex), Main.Instance.Personalities[0].Voice_SexReject[lineIndex], new Action(this.EndTheChat));
              Main.Instance.GameplayMenu.EnableMove();
            }
            else
            {
              this.ThisPerson.Favor += 5;
              this.ThisPerson.RandActionTimer = 0.0f;
              int num = this.ThisPerson.PersonalityData.PickSexOption();
              int lineIndex = 0;
              switch (num)
              {
                case 0:
                  _gameplay.DisplaySubtitle(this.ThisPerson.PersonalityData.Reply_SexFollow(out lineIndex), Main.Instance.Personalities[0].Voice_SexFollow[lineIndex], new Action(this.EndTheChat));
                  Main.Instance.GameplayMenu.EnableMove();
                  this.ThisPerson.CompleteScheduleTask(false);
                  this.ThisPerson.FreeScheduleTasks.Clear();
                  if ((UnityEngine.Object) this.ThisPerson.InteractingWith != (UnityEngine.Object) null)
                    this.ThisPerson.InteractingWith.StopInteracting();
                  this.StartTalkFunc = "SexHereChat";
                  this.ThisPerson.AddFreeScheduleTask(new Person.ScheduleTask()
                  {
                    IDName = "SexFollow",
                    ActionPlace = Main.Instance.Player.transform,
                    OnArrive = (Action) (() =>
                    {
                      this.FollowCheck = true;
                      this.ThisPerson.CurrentScheduleTask.ActionPlace = Main.Instance.Player.transform;
                      this.ThisPerson.CurrentScheduleTask.State = 0;
                      this.ThisPerson.SetDestination(this.ThisPerson.CurrentScheduleTask.ActionPlace);
                    }),
                    WhileGoing = (Action) (() =>
                    {
                      this.ThisPerson.RandActionTimer += Time.deltaTime;
                      if ((double) this.ThisPerson.RandActionTimer <= 1.0)
                        return;
                      this.ThisPerson.RandActionTimer = 0.0f;
                      if ((double) Vector3.Distance(Main.Instance.Player.transform.position, this.transform.position) > 1.0)
                      {
                        this.ThisPerson.SetDestination(this.ThisPerson.CurrentScheduleTask.ActionPlace);
                      }
                      else
                      {
                        if (!this.ThisPerson.navMesh.isOnNavMesh)
                          return;
                        this.ThisPerson.navMesh.isStopped = true;
                      }
                    })
                  }, true);
                  break;
                case 1:
                  if (!((UnityEngine.Object) this.ThisPerson.CurrentZone == (UnityEngine.Object) null) || !((UnityEngine.Object) this.ThisPerson.Home == (UnityEngine.Object) null))
                  {
                    Transform sexSpot;
                    if ((UnityEngine.Object) this.ThisPerson.CurrentZone != (UnityEngine.Object) null && this.ThisPerson.CurrentZone.SexSpots.Count != 0)
                      sexSpot = this.ThisPerson.CurrentZone.SexSpots[UnityEngine.Random.Range(0, this.ThisPerson.CurrentZone.SexSpots.Count)];
                    else if ((UnityEngine.Object) this.ThisPerson.Home != (UnityEngine.Object) null && this.ThisPerson.Home.SexSpots.Count != 0)
                    {
                      sexSpot = this.ThisPerson.Home.SexSpots[UnityEngine.Random.Range(0, this.ThisPerson.Home.SexSpots.Count)];
                      this.ThisPerson.AddGoHome();
                    }
                    else
                      goto case 0;
                    _gameplay.DisplaySubtitle(this.ThisPerson.PersonalityData.Reply_SexLead(out lineIndex), Main.Instance.Personalities[0].Voice_SexLead[lineIndex], new Action(this.EndTheChat));
                    Main.Instance.GameplayMenu.EnableMove();
                    this.ThisPerson.CompleteScheduleTask(false);
                    this.ThisPerson.FreeScheduleTasks.Clear();
                    if ((UnityEngine.Object) this.ThisPerson.InteractingWith != (UnityEngine.Object) null)
                      this.ThisPerson.InteractingWith.StopInteracting();
                    this.ThisPerson.AddFreeScheduleTask(new Person.ScheduleTask()
                    {
                      IDName = "GoToSexSpot",
                      ActionPlace = sexSpot,
                      OnArrive = (Action) (() => this.ThisPerson.CompleteScheduleTask())
                    }, true);
                    this.ThisPerson.AddFreeScheduleTask(new Person.ScheduleTask()
                    {
                      IDName = "SexCheck",
                      ActionPlace = this.ThisPerson.transform,
                      OnStartGoing = (Action) (() =>
                      {
                        this.ThisPerson.RandActionTimer = 10f;
                        this._Waiting = false;
                        this.ThisPerson.CurrentScheduleTask.State = 1;
                        this.ThisPerson.Do_Schedule_GoingToTargetThread = true;
                      }),
                      OnArrive = (Action) (() =>
                      {
                        if (!this._Waiting)
                          this.ThisPerson.RandActionTimer = 10f;
                        this._Waiting = true;
                        this.ThisPerson.CurrentScheduleTask.State = 1;
                        this.ThisPerson.Do_Schedule_GoingToTargetThread = true;
                      }),
                      WhileGoing = (Action) (() =>
                      {
                        if (!this._Waiting || Main.Instance.Player.HavingSex)
                          return;
                        if (this.ThisPerson.navMesh.isOnNavMesh)
                          this.ThisPerson.navMesh.isStopped = true;
                        if ((double) Vector3.Distance(this.ThisPerson.transform.position, Main.Instance.Player.transform.position) <= 2.5)
                        {
                          this._Waiting = false;
                          this.ThisPerson.CompleteScheduleTask();
                          if (Main.Instance.Player.HasPenis)
                            Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
                          else if (this.ThisPerson.HasPenis)
                            Main.Instance.SexScene.SpawnSexScene(2, 0, this.ThisPerson, Main.Instance.Player);
                          else
                            Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
                        }
                        else
                        {
                          this.ThisPerson.RandActionTimer -= Time.deltaTime;
                          if ((double) this.ThisPerson.RandActionTimer > 0.0)
                            return;
                          this._Waiting = false;
                          this.ThisPerson.CompleteScheduleTask();
                        }
                      })
                    }, true);
                    break;
                  }
                  goto case 0;
                case 2:
                  if (Main.Instance.Player.HasPenis)
                    Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
                  else if (this.ThisPerson.HasPenis)
                    Main.Instance.SexScene.SpawnSexScene(2, 0, this.ThisPerson, Main.Instance.Player);
                  else
                    Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
                  this.EndTheChat();
                  break;
              }
            }
          }));
          int _priceValue = 0;
          switch (this.ThisPerson.PersonType.ThisType)
          {
            case Person_Type.Wild:
              _priceValue = 10;
              break;
            case Person_Type.ESB:
              _priceValue = 1;
              break;
            case Person_Type.Prisioner:
              _priceValue = 1;
              break;
            case Person_Type.Worker:
              _priceValue = 20;
              break;
            case Person_Type.Civilian:
              _priceValue = 50;
              break;
            case Person_Type.HigherCivilian:
              _priceValue = 500;
              break;
            case Person_Type.Army:
              _priceValue = 20;
              break;
            case Person_Type.Royal:
              _priceValue = 500;
              break;
          }
          string str2 = "(" + _priceValue.ToString() + "BN) ";
          string[] strArray2 = new string[7]
          {
            str2 + Main.GetLine(38),
            str2 + Main.GetLine(39),
            str2 + Main.GetLine(41),
            str2 + Main.GetLine(42),
            str2 + Main.GetLine(43),
            str2 + Main.GetLine(44),
            str2 + Main.GetLine(45)
          };
          _gameplay.AddChatOption(strArray2[UnityEngine.Random.Range(0, strArray2.Length)], (Action) (() =>
          {
            if (Main.Instance.Player.Money < _priceValue)
            {
              Main.Instance.GameplayMenu.EnableMove();
              _gameplay.DisplaySubtitle(Main.GetLine(63), Main.Instance.Personalities[0].Voice_Generics[5], new Action(this.EndTheChat));
            }
            else
            {
              Main.Instance.Player.Money -= _priceValue;
              Main.Instance.GameplayMenu.ShowNotification("Paied " + _priceValue.ToString() + " Bitch notes");
              this._HasSexControl = true;
              this.ThisPerson.RandActionTimer = 0.0f;
              int num = this.ThisPerson.PersonalityData.PickSexOption();
              int lineIndex = 0;
              switch (num)
              {
                case 0:
                  _gameplay.DisplaySubtitle(this.ThisPerson.PersonalityData.Reply_SexFollow(out lineIndex), Main.Instance.Personalities[0].Voice_SexFollow[lineIndex], new Action(this.EndTheChat));
                  Main.Instance.GameplayMenu.EnableMove();
                  this.ThisPerson.CompleteScheduleTask(false);
                  this.ThisPerson.FreeScheduleTasks.Clear();
                  if ((UnityEngine.Object) this.ThisPerson.InteractingWith != (UnityEngine.Object) null)
                    this.ThisPerson.InteractingWith.StopInteracting();
                  this.StartTalkFunc = "SexHereChat";
                  this.ThisPerson.AddFreeScheduleTask(new Person.ScheduleTask()
                  {
                    IDName = "SexFollow",
                    ActionPlace = Main.Instance.Player.transform,
                    OnArrive = (Action) (() =>
                    {
                      this.FollowCheck = true;
                      this.ThisPerson.CurrentScheduleTask.ActionPlace = Main.Instance.Player.transform;
                      this.ThisPerson.CurrentScheduleTask.State = 0;
                      this.ThisPerson.SetDestination(this.ThisPerson.CurrentScheduleTask.ActionPlace);
                    }),
                    WhileGoing = (Action) (() =>
                    {
                      this.ThisPerson.RandActionTimer += Time.deltaTime;
                      if ((double) this.ThisPerson.RandActionTimer <= 1.0)
                        return;
                      this.ThisPerson.RandActionTimer = 0.0f;
                      if ((double) Vector3.Distance(Main.Instance.Player.transform.position, this.transform.position) > 1.0)
                      {
                        this.ThisPerson.SetDestination(this.ThisPerson.CurrentScheduleTask.ActionPlace);
                      }
                      else
                      {
                        if (!this.ThisPerson.navMesh.isOnNavMesh)
                          return;
                        this.ThisPerson.navMesh.isStopped = true;
                      }
                    })
                  }, true);
                  break;
                case 1:
                  if (!((UnityEngine.Object) this.ThisPerson.CurrentZone == (UnityEngine.Object) null) || !((UnityEngine.Object) this.ThisPerson.Home == (UnityEngine.Object) null))
                  {
                    Transform sexSpot;
                    if ((UnityEngine.Object) this.ThisPerson.CurrentZone != (UnityEngine.Object) null && this.ThisPerson.CurrentZone.SexSpots.Count != 0)
                      sexSpot = this.ThisPerson.CurrentZone.SexSpots[UnityEngine.Random.Range(0, this.ThisPerson.CurrentZone.SexSpots.Count)];
                    else if ((UnityEngine.Object) this.ThisPerson.Home != (UnityEngine.Object) null && this.ThisPerson.Home.SexSpots.Count != 0)
                    {
                      sexSpot = this.ThisPerson.Home.SexSpots[UnityEngine.Random.Range(0, this.ThisPerson.Home.SexSpots.Count)];
                      this.ThisPerson.AddGoHome();
                    }
                    else
                      goto case 0;
                    _gameplay.DisplaySubtitle(this.ThisPerson.PersonalityData.Reply_SexLead(out lineIndex), Main.Instance.Personalities[0].Voice_SexLead[lineIndex], new Action(this.EndTheChat));
                    Main.Instance.GameplayMenu.EnableMove();
                    this.ThisPerson.CompleteScheduleTask(false);
                    this.ThisPerson.FreeScheduleTasks.Clear();
                    if ((UnityEngine.Object) this.ThisPerson.InteractingWith != (UnityEngine.Object) null)
                      this.ThisPerson.InteractingWith.StopInteracting();
                    this.ThisPerson.AddFreeScheduleTask(new Person.ScheduleTask()
                    {
                      IDName = "GoToSexSpot",
                      ActionPlace = sexSpot,
                      OnArrive = (Action) (() => this.ThisPerson.CompleteScheduleTask())
                    }, true);
                    this.ThisPerson.AddFreeScheduleTask(new Person.ScheduleTask()
                    {
                      IDName = "SexCheck",
                      ActionPlace = this.ThisPerson.transform,
                      OnStartGoing = (Action) (() =>
                      {
                        this.ThisPerson.RandActionTimer = 10f;
                        this._Waiting = false;
                        this.ThisPerson.CurrentScheduleTask.State = 1;
                        this.ThisPerson.Do_Schedule_GoingToTargetThread = true;
                      }),
                      OnArrive = (Action) (() =>
                      {
                        if (!this._Waiting)
                          this.ThisPerson.RandActionTimer = 10f;
                        this._Waiting = true;
                        this.ThisPerson.CurrentScheduleTask.State = 1;
                        this.ThisPerson.Do_Schedule_GoingToTargetThread = true;
                      }),
                      WhileGoing = (Action) (() =>
                      {
                        if (!this._Waiting || Main.Instance.Player.HavingSex)
                          return;
                        if (this.ThisPerson.navMesh.isOnNavMesh)
                          this.ThisPerson.navMesh.isStopped = true;
                        if ((double) Vector3.Distance(this.ThisPerson.transform.position, Main.Instance.Player.transform.position) <= 2.5)
                        {
                          this._Waiting = false;
                          this.ThisPerson.CompleteScheduleTask();
                          if (Main.Instance.Player.HasPenis)
                            Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
                          else if (this.ThisPerson.HasPenis)
                            Main.Instance.SexScene.SpawnSexScene(2, 0, this.ThisPerson, Main.Instance.Player);
                          else
                            Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
                        }
                        else
                        {
                          this.ThisPerson.RandActionTimer -= Time.deltaTime;
                          if ((double) this.ThisPerson.RandActionTimer > 0.0)
                            return;
                          this._Waiting = false;
                          this.ThisPerson.CompleteScheduleTask();
                        }
                      })
                    }, true);
                    break;
                  }
                  goto case 0;
                case 2:
                  if (Main.Instance.Player.HasPenis)
                    Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
                  else if (this.ThisPerson.HasPenis)
                    Main.Instance.SexScene.SpawnSexScene(2, 0, this.ThisPerson, Main.Instance.Player);
                  else
                    Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
                  this.EndTheChat();
                  break;
              }
            }
          }));
          string str3 = "(+BN) ";
          string[] strArray3 = new string[6]
          {
            str3 + Main.GetLine(22),
            str3 + Main.GetLine(23),
            str3 + Main.GetLine(24),
            str3 + Main.GetLine(25),
            str3 + Main.GetLine(26),
            str3 + Main.GetLine(27)
          };
          _gameplay.AddChatOption(strArray3[UnityEngine.Random.Range(0, strArray3.Length)], (Action) (() =>
          {
            this._HasSexControl = false;
            float num3 = (float) ((Main.Instance.Player.ClothingCondition == e_ClothingCondition.Sexy ? 0.699999988079071 : 0.20000000298023224) - (Main.Instance.Player.Perks.Contains("Smell") ? 0.10000000149011612 : 0.0));
            bool flag3 = (double) UnityEngine.Random.Range(0.0f, 1f) < (double) num3;
            bool flag4 = false;
            for (int index3 = 0; index3 < this.ThisPerson.Fetishes.Count; ++index3)
            {
              switch (this.ThisPerson.Fetishes[index3])
              {
                case e_Fetish.Clean:
                  if (Main.Instance.Player.DirtySkin != flag4)
                  {
                    string[] strArray4 = new string[2]
                    {
                      Main.GetLine(61),
                      Main.GetLine(62)
                    };
                    int index4 = UnityEngine.Random.Range(0, strArray4.Length);
                    _gameplay.DisplaySubtitle(strArray4[index4], Main.Instance.Personalities[0].Voice_Generics[index4 + 3], new Action(this.EndTheChat));
                    Main.Instance.GameplayMenu.EnableMove();
                    return;
                  }
                  goto label_8;
                case e_Fetish.Dirty:
                  flag4 = true;
                  goto case e_Fetish.Clean;
                default:
                  continue;
              }
            }
label_8:
            if (flag3)
            {
              this.ThisPerson.RandActionTimer = 0.0f;
              int num4 = this.ThisPerson.PersonalityData.PickSexOption();
              int lineIndex = 0;
              switch (num4)
              {
                case 0:
                  _gameplay.DisplaySubtitle(this.ThisPerson.PersonalityData.Reply_SexFollow(out lineIndex), Main.Instance.Personalities[0].Voice_SexFollow[lineIndex], new Action(this.EndTheChat));
                  Main.Instance.GameplayMenu.EnableMove();
                  this.ThisPerson.CompleteScheduleTask(false);
                  this.ThisPerson.FreeScheduleTasks.Clear();
                  if ((UnityEngine.Object) this.ThisPerson.InteractingWith != (UnityEngine.Object) null)
                    this.ThisPerson.InteractingWith.StopInteracting();
                  this.StartTalkFunc = "SexHereChat";
                  this.ThisPerson.AddFreeScheduleTask(new Person.ScheduleTask()
                  {
                    IDName = "SexFollow",
                    ActionPlace = Main.Instance.Player.transform,
                    OnArrive = (Action) (() =>
                    {
                      this.FollowCheck = true;
                      this.ThisPerson.CurrentScheduleTask.ActionPlace = Main.Instance.Player.transform;
                      this.ThisPerson.CurrentScheduleTask.State = 0;
                      this.ThisPerson.SetDestination(this.ThisPerson.CurrentScheduleTask.ActionPlace);
                    }),
                    WhileGoing = (Action) (() =>
                    {
                      this.ThisPerson.RandActionTimer += Time.deltaTime;
                      if ((double) this.ThisPerson.RandActionTimer <= 1.0)
                        return;
                      this.ThisPerson.RandActionTimer = 0.0f;
                      if ((double) Vector3.Distance(Main.Instance.Player.transform.position, this.transform.position) > 1.0)
                      {
                        this.ThisPerson.SetDestination(this.ThisPerson.CurrentScheduleTask.ActionPlace);
                      }
                      else
                      {
                        if (!this.ThisPerson.navMesh.isOnNavMesh)
                          return;
                        this.ThisPerson.navMesh.isStopped = true;
                      }
                    })
                  }, true);
                  break;
                case 1:
                  if (!((UnityEngine.Object) this.ThisPerson.CurrentZone == (UnityEngine.Object) null) || !((UnityEngine.Object) this.ThisPerson.Home == (UnityEngine.Object) null))
                  {
                    Transform sexSpot;
                    if ((UnityEngine.Object) this.ThisPerson.CurrentZone != (UnityEngine.Object) null && this.ThisPerson.CurrentZone.SexSpots.Count != 0)
                      sexSpot = this.ThisPerson.CurrentZone.SexSpots[UnityEngine.Random.Range(0, this.ThisPerson.CurrentZone.SexSpots.Count)];
                    else if ((UnityEngine.Object) this.ThisPerson.Home != (UnityEngine.Object) null && this.ThisPerson.Home.SexSpots.Count != 0)
                    {
                      sexSpot = this.ThisPerson.Home.SexSpots[UnityEngine.Random.Range(0, this.ThisPerson.Home.SexSpots.Count)];
                      this.ThisPerson.AddGoHome();
                    }
                    else
                      goto case 0;
                    _gameplay.DisplaySubtitle(this.ThisPerson.PersonalityData.Reply_SexLead(out lineIndex), Main.Instance.Personalities[0].Voice_SexLead[lineIndex], new Action(this.EndTheChat));
                    Main.Instance.GameplayMenu.EnableMove();
                    this.ThisPerson.CompleteScheduleTask(false);
                    this.ThisPerson.FreeScheduleTasks.Clear();
                    if ((UnityEngine.Object) this.ThisPerson.InteractingWith != (UnityEngine.Object) null)
                      this.ThisPerson.InteractingWith.StopInteracting();
                    this.ThisPerson.AddFreeScheduleTask(new Person.ScheduleTask()
                    {
                      IDName = "GoToSexSpot",
                      ActionPlace = sexSpot,
                      OnArrive = (Action) (() => this.ThisPerson.CompleteScheduleTask())
                    });
                    this.ThisPerson.AddFreeScheduleTask(new Person.ScheduleTask()
                    {
                      IDName = "SexCheck",
                      ActionPlace = this.ThisPerson.transform,
                      OnStartGoing = (Action) (() =>
                      {
                        this.ThisPerson.RandActionTimer = 10f;
                        this._Waiting = false;
                        this.ThisPerson.CurrentScheduleTask.State = 1;
                        this.ThisPerson.Do_Schedule_GoingToTargetThread = true;
                      }),
                      OnArrive = (Action) (() =>
                      {
                        if (!this._Waiting)
                          this.ThisPerson.RandActionTimer = 10f;
                        this._Waiting = true;
                        this.ThisPerson.CurrentScheduleTask.State = 1;
                        this.ThisPerson.Do_Schedule_GoingToTargetThread = true;
                      }),
                      WhileGoing = (Action) (() =>
                      {
                        if (!this._Waiting || Main.Instance.Player.HavingSex)
                          return;
                        if (this.ThisPerson.navMesh.isOnNavMesh)
                          this.ThisPerson.navMesh.isStopped = true;
                        if ((double) Vector3.Distance(this.ThisPerson.transform.position, Main.Instance.Player.transform.position) <= 2.5)
                        {
                          this._Waiting = false;
                          this.ThisPerson.CompleteScheduleTask();
                          SpawnedSexScene spawnedSexScene = !this.ThisPerson.HasPenis ? (!Main.Instance.Player.HasPenis ? Main.Instance.SexScene.SpawnSexScene(2, 1, this.ThisPerson, Main.Instance.Player, receiveMoney: true, canControl: false) : Main.Instance.SexScene.SpawnSexScene(2, 1, Main.Instance.Player, this.ThisPerson, receiveMoney: true, canControl: false)) : Main.Instance.SexScene.SpawnSexScene(2, 3, this.ThisPerson, Main.Instance.Player, receiveMoney: true, canControl: false);
                          spawnedSexScene.TimerForRandomPoseChange = true;
                          spawnedSexScene.TimerMax = UnityEngine.Random.Range(10f, 20f);
                          spawnedSexScene.TimerPoseChange = spawnedSexScene.TimerMax;
                          spawnedSexScene.TimerForRandomSexEnd = true;
                          spawnedSexScene.TimerSexEnd = UnityEngine.Random.Range(60f, 120f);
                        }
                        else
                        {
                          this.ThisPerson.RandActionTimer -= Time.deltaTime;
                          if ((double) this.ThisPerson.RandActionTimer > 0.0)
                            return;
                          this._Waiting = false;
                          this.ThisPerson.CompleteScheduleTask();
                        }
                      })
                    }, true);
                    break;
                  }
                  goto case 0;
                case 2:
                  SpawnedSexScene spawnedSexScene = !this.ThisPerson.HasPenis ? (!Main.Instance.Player.HasPenis ? Main.Instance.SexScene.SpawnSexScene(2, 1, this.ThisPerson, Main.Instance.Player, receiveMoney: true, canControl: false) : Main.Instance.SexScene.SpawnSexScene(2, 1, Main.Instance.Player, this.ThisPerson, receiveMoney: true, canControl: false)) : Main.Instance.SexScene.SpawnSexScene(2, 3, this.ThisPerson, Main.Instance.Player, receiveMoney: true, canControl: false);
                  spawnedSexScene.TimerForRandomPoseChange = true;
                  spawnedSexScene.TimerMax = UnityEngine.Random.Range(10f, 20f);
                  spawnedSexScene.TimerPoseChange = spawnedSexScene.TimerMax;
                  spawnedSexScene.TimerForRandomSexEnd = true;
                  spawnedSexScene.TimerSexEnd = UnityEngine.Random.Range(60f, 120f);
                  this.EndTheChat();
                  break;
              }
            }
            else
            {
              int lineIndex;
              _gameplay.DisplaySubtitle(Main.Instance.Personalities[0].Reply_SexProstReject(out lineIndex), Main.Instance.Personalities[0].Voice_SexProstReject[lineIndex], new Action(this.EndTheChat));
              Main.Instance.GameplayMenu.EnableMove();
            }
          }));
          _gameplay.AddChatOption("Never mind.", new Action(this.EndTheChat));
          _gameplay.SelectChatOption(0);
          Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
        }
      }));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void EndTheChat()
  {
    this.StopInteracting();
    Main.Instance.GameplayMenu.EndChat();
  }

  public void SetDefaultChat()
  {
    this.StartTalkMono = (MonoBehaviour) this;
    this.StartTalkFunc = "DefaultTalk";
  }

  public void SexHereChat()
  {
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    gameplayMenu.RemoveAllChatOptions();
    gameplayMenu.AddChatOption(Main.GetLine(32), (Action) (() =>
    {
      this.EndTheChat();
      this.SetDefaultChat();
      this.ThisPerson.CompleteScheduleTask();
      if (this._HasSexControl)
      {
        if (Main.Instance.Player.HasPenis)
          Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
        else if (this.ThisPerson.HasPenis)
          Main.Instance.SexScene.SpawnSexScene(2, 0, this.ThisPerson, Main.Instance.Player);
        else
          Main.Instance.SexScene.SpawnSexScene(2, 0, Main.Instance.Player, this.ThisPerson);
      }
      else
      {
        SpawnedSexScene spawnedSexScene = !this.ThisPerson.HasPenis ? (!Main.Instance.Player.HasPenis ? Main.Instance.SexScene.SpawnSexScene(2, 1, this.ThisPerson, Main.Instance.Player, receiveMoney: true, canControl: false) : Main.Instance.SexScene.SpawnSexScene(2, 1, Main.Instance.Player, this.ThisPerson, receiveMoney: true, canControl: false)) : Main.Instance.SexScene.SpawnSexScene(2, 3, this.ThisPerson, Main.Instance.Player, receiveMoney: true, canControl: false);
        spawnedSexScene.TimerForRandomPoseChange = true;
        spawnedSexScene.TimerMax = UnityEngine.Random.Range(10f, 20f);
        spawnedSexScene.TimerPoseChange = spawnedSexScene.TimerMax;
        spawnedSexScene.TimerForRandomSexEnd = true;
        spawnedSexScene.TimerSexEnd = UnityEngine.Random.Range(60f, 120f);
      }
    }));
    gameplayMenu.AddChatOption(Main.GetLine(33), (Action) (() => this.EndTheChat()));
    gameplayMenu.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void FollowingChat()
  {
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    gameplayMenu.RemoveAllChatOptions();
    gameplayMenu.AddChatOption("Stay here", (Action) (() =>
    {
      this.ThisPerson.RemoveCullBlocker("Following");
      Main.Instance.PeopleFollowingPlayer.Remove(this.ThisPerson);
      this.EndTheChat();
      this.SetDefaultChat();
      this.ThisPerson.CompleteScheduleTask();
    }));
    gameplayMenu.AddChatOption("You're gonna live here now", (Action) (() =>
    {
      this.ThisPerson.RemoveCullBlocker("Following");
      Main.Instance.PeopleFollowingPlayer.Remove(this.ThisPerson);
      this.EndTheChat();
      this.SetDefaultChat();
      this.ThisPerson.CompleteScheduleTask();
      if ((UnityEngine.Object) this.ThisPerson.CurrentZone == (UnityEngine.Object) null)
        this.ThisPerson.CurrentZone = this.ThisPerson.TempLivingSpace_hang;
      this.ThisPerson.Home = this.ThisPerson.CurrentZone;
      if ((UnityEngine.Object) this.ThisPerson.Home.Location != (UnityEngine.Object) null)
        this.ThisPerson.HomeSpot = this.ThisPerson.Home.Location;
      this.ThisPerson.TempLivingSpace = this.transform.position;
    }));
    gameplayMenu.AddChatOption("Keep following me", (Action) (() => this.EndTheChat()));
    gameplayMenu.AddChatOption("Stop following me", (Action) (() =>
    {
      this.ThisPerson.RemoveCullBlocker("Following");
      Main.Instance.PeopleFollowingPlayer.Remove(this.ThisPerson);
      this.EndTheChat();
      this.SetDefaultChat();
      this.ThisPerson.CompleteScheduleTask();
      this.ThisPerson.RandActionTimer = 0.0f;
      this.ThisPerson.DecideTimer = 0.0f;
    }));
    gameplayMenu.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void RestrainedCheck()
  {
    if (this.ThisPerson.Restrained)
    {
      if (!this.ThisPerson.Leashed)
      {
        this.InteractText = "Leash";
        this.StartTalkMono = (MonoBehaviour) this;
        this.StartTalkFunc = "Leash";
        this._PersonInteractType = PersonInteractType.NonChat;
        this.ThisPerson.RunAway();
      }
      else
      {
        this.SetDefaultInteraction();
        this.StartTalkMono = (MonoBehaviour) this;
        this.StartTalkFunc = "RestrainedInteraction";
      }
      for (int index = 0; index < this.ThisPerson.EquippedClothes.Count; ++index)
        this.ThisPerson.EquippedClothes[index].SetIKs();
    }
    else
    {
      if (this.ThisPerson.Leashed)
        this.Unleash();
      this.ThisPerson.PrisionerEscapeCheck();
    }
  }

  public void Leash()
  {
    if (!Main.Instance.PeopleFollowingPlayer.Contains(this.ThisPerson))
      Main.Instance.PeopleFollowingPlayer.Add(this.ThisPerson);
    this.StartTalkFunc = "RestrainedInteraction";
    this.ThisPerson.RandActionTimer = 5f;
    this.ThisPerson.DecideTimer = 5f;
    this.ThisPerson.FreeScheduleTasks.Clear();
    this.ThisPerson.CompleteScheduleTask(false);
    this.ThisPerson.FreeScheduleTasks.Clear();
    this.ThisPerson.Leashed = true;
    Main.RunInNextFrame((Action) (() =>
    {
      this.ThisPerson.AddCullBlocker("Following_Leash");
      this.ThisPerson.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "FollowPlayer_restrained",
        ActionPlace = Main.Instance.Player.transform,
        OnArrive = (Action) (() => { }),
        WhileGoing = (Action) (() =>
        {
          this.ThisPerson.RandActionTimer += Time.deltaTime;
          if ((double) this.ThisPerson.RandActionTimer <= 0.25)
            return;
          this.ThisPerson.RandActionTimer = 0.0f;
          float num = Vector3.Distance(Main.Instance.Player.transform.position, this.transform.position);
          if ((double) num > 1.0)
            this.ThisPerson.SetDestination(this.ThisPerson.CurrentScheduleTask.ActionPlace);
          else if (this.ThisPerson.navMesh.isOnNavMesh)
            this.ThisPerson.navMesh.isStopped = true;
          this.ThisPerson.navMesh.speed = (double) num > 4.0 ? 4f : 1f;
        }),
        OnInterrupt_WhileGoing = (Action) (() =>
        {
          this.ThisPerson.RemoveCullBlocker("Following_Leash");
          Main.Instance.PeopleFollowingPlayer.Remove(this.ThisPerson);
        })
      });
    }));
    this.TheLeashRoot = UnityEngine.Object.Instantiate<GameObject>(Main.Instance.AllPrefabs[265]).transform;
    this.TheLeashRoot.SetParent(Main.Instance.Player.RightHandStuff);
    this.TheLeashRoot.localScale = Vector3.one;
    this.TheLeashRoot.localPosition = Vector3.zero;
    this.TheLeashRoot.localEulerAngles = Vector3.zero;
    this.TheLeashRoot = this.TheLeashRoot.Find("Tip");
    this.TheLeashTiedSpot = this.ThisPerson.Neck;
    Main.Instance.MainThreads_Late.Add(new Action(this.LeashThread));
    this.SetDefaultInteraction();
    this.StartTalkMono = (MonoBehaviour) this;
    this.StartTalkFunc = "RestrainedInteraction";
  }

  public void LeashThread()
  {
    this.TheLeashRoot.LookAt(this.TheLeashTiedSpot);
    this.TheLeashRoot.localScale = new Vector3(1f, 1f, Vector3.Distance(this.TheLeashRoot.position, this.TheLeashTiedSpot.position));
  }

  public void RestrainedInteraction()
  {
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Main.Instance.Player.UserControl.StopMoving();
    int lineIndex = 0;
    string subText = this.ThisPerson.PersonalityData.Reply_Hello(out lineIndex);
    AudioClip voiceLine = this.ThisPerson.PersonalityData.Voice_Hello[lineIndex];
    gameplayMenu.DisplaySubtitle(subText, voiceLine);
    this.RestrainedInteraction_options();
  }

  public void RestrainedInteraction_options()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    _gameplay.RemoveAllChatOptions();
    if (this.ThisPerson.Leashed)
      _gameplay.AddChatOption("(Unleash)", (Action) (() =>
      {
        this.Unleash();
        this.EndTheChat();
        Main.Instance.GameplayMenu.EnableMove();
      }));
    else
      _gameplay.AddChatOption("(Leash)", (Action) (() =>
      {
        this.EndTheChat();
        Main.Instance.GameplayMenu.EnableMove();
        this.Leash();
      }));
    _gameplay.AddChatOption("(Inventory)", (Action) (() =>
    {
      Main.Instance.GameplayMenu.OpenContainer((Int_Storage) this.ThisPerson.InventoryStorage);
      Main.Instance.GameplayMenu.OnCloseContainer.Clear();
      Main.Instance.GameplayMenu.OnCloseContainer.Add(new Action(this.OnCloseNPCInventory));
    }));
    _gameplay.AddChatOption("What's your name?", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      this.ThisPerson.PlayerKnowsName = true;
      this.InteractText = Main.GetLine(1) + this.ThisPerson.Name;
      string[] strArray = new string[3]
      {
        this.ThisPerson.Name,
        Main.GetLine(5) + this.ThisPerson.Name,
        Main.GetLine(6) + this.ThisPerson.Name
      };
      _gameplay.DisplaySubtitle(strArray[UnityEngine.Random.Range(0, strArray.Length)], (AudioClip) null, new Action(this.EndTheChat));
    }));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void Unleash()
  {
    Main.Instance.MainThreads_Late.Remove(new Action(this.LeashThread));
    if ((UnityEngine.Object) this.TheLeashRoot != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TheLeashRoot.parent.gameObject);
    this.ThisPerson.Leashed = false;
    this.SetDefaultInteraction();
    this.SetDefaultChat();
    this.ThisPerson.TempLivingSpace = this.transform.position;
    this.ThisPerson.RemoveCullBlocker("Following_Leash");
    this.ThisPerson.RemoveCullBlocker("Following");
    Main.Instance.PeopleFollowingPlayer.Remove(this.ThisPerson);
    if (this.ThisPerson.CurrentScheduleTask != null && (this.ThisPerson.CurrentScheduleTask.IDName == "FollowPlayer_restrained" || this.ThisPerson.CurrentScheduleTask.IDName == "FollowPlayer"))
      this.ThisPerson.CompleteScheduleTask();
    this.RestrainedCheck();
  }

  public void TrainingChat_options()
  {
  }
}
