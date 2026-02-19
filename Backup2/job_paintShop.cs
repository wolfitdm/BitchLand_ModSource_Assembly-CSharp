// Decompiled with JetBrains decompiler
// Type: job_paintShop
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class job_paintShop : bl_WorkJobManager
{
  public Interactible StandSpot;
  public Transform[] Spots;
  public GameObject[] Piereeecings;
  private bool[] _Pierings;
  private Dressable[] _PieringsD;
  private List<Dressable> _canBePainted = new List<Dressable>();
  private int _CanBePaintedIndex;

  public Person.ScheduleTask StandShopTask(Person person)
  {
    person.Home = this.AssociatedZone;
    return new Person.ScheduleTask()
    {
      IDName = "ShopStandSpot",
      ActionPlace = this.StandSpot.NavMeshInteractSpot,
      RunTo = true,
      OnArrive = (Action) (() =>
      {
        person.RandActionTimer = 10f;
        this.StandSpot.Interact(person);
      }),
      WhileDoing = (Action) (() =>
      {
        person.RandActionTimer -= Time.deltaTime;
        if ((double) person.RandActionTimer >= 0.0)
          return;
        person.AddWorkScheduleTask(this.StandShopTask(person));
        person.CompleteScheduleTask();
      })
    };
  }

  public override void AddJobToWorker(Person person)
  {
    base.AddJobToWorker(person);
    person.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    person.ThisPersonInt.StartTalkFunc = "ChatShop";
    if (person.JobIndex != 0)
      return;
    person.AddWorkScheduleTask(this.StandShopTask(person), true);
  }

  public override void _EndWorkFor(Person person)
  {
    person.ThisPersonInt.SetDefaultChat();
    base._EndWorkFor(person);
    if ((UnityEngine.Object) person.InteractingWith != (UnityEngine.Object) null)
      person.InteractingWith.StopInteracting(person);
    person.AddGoHome();
  }

  public void ShowColorableOptions()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person personChattingTo = _gameplay.PersonChattingTo;
    bool flag = false;
    for (int index = 0; index < 4 && this._CanBePaintedIndex + index < this._canBePainted.Count; ++index)
      _gameplay.AddChatOption(this._canBePainted[this._CanBePaintedIndex + index].name, (Action) (() =>
      {
        Main.Instance.CustomizeMenu.Open_RecolorOnly(this.Spots[0], this._canBePainted[this._CanBePaintedIndex + _gameplay.SavedSelectedOption]);
        Main.Instance.GameplayMenu.EnableMove();
      }));
    if (this._CanBePaintedIndex + 4 < this._canBePainted.Count)
      flag = true;
    if (flag)
      _gameplay.AddChatOption("(Next page)", (Action) (() =>
      {
        this._CanBePaintedIndex += 4;
        this.ShowColorableOptions();
      }));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void ChatShop()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.AddChatOption("I wanna change my hair like...", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      Main.Instance.CustomizeMenu.Open_HairStyleBoth(this.Spots[1]);
    }));
    _gameplay.AddChatOption("I wanna change my makeup...", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      Main.Instance.CustomizeMenu.Open_MakeupOnly(this.Spots[0]);
    }));
    _gameplay.AddChatOption("I wanna dye this item...", (Action) (() =>
    {
      _gameplay.RemoveAllChatOptions();
      int num = 0;
      this._CanBePaintedIndex = 0;
      this._canBePainted.Clear();
      for (int index = 0; index < Main.Instance.Player.EquippedClothes.Count; ++index)
      {
        switch (Main.Instance.Player.EquippedClothes[index].BodyPart)
        {
          case DressableType.Any:
          case DressableType.Shoes:
          case DressableType.Pants:
          case DressableType.Top:
          case DressableType.UnderwearTop:
          case DressableType.UnderwearLower:
          case DressableType.Garter:
          case DressableType.Socks:
          case DressableType.Hat:
            ++num;
            this._canBePainted.Add(Main.Instance.Player.EquippedClothes[index]);
            break;
        }
      }
      this.ShowColorableOptions();
    }));
    _gameplay.AddChatOption("About piercings...", (Action) (() =>
    {
      _gameplay.RemoveAllChatOptions();
      _gameplay.AddChatOption("I wanna add piercings...", (Action) (() =>
      {
        _gameplay.RemoveAllChatOptions();
        this._Pierings = new bool[6];
        for (int index = 0; index < Main.Instance.Player.EquippedClothes.Count; ++index)
        {
          switch (Main.Instance.Player.EquippedClothes[index].OriginalPrefab.name)
          {
            case "Piercing (Left Nipple)":
              this._Pierings[0] = true;
              break;
            case "Piercing (Right Nipple)":
              this._Pierings[1] = true;
              break;
            case "Piercing (Clitoris)":
              this._Pierings[2] = true;
              break;
            case "Piercing 2 (Left Nipple)":
              this._Pierings[3] = true;
              break;
            case "Piercing 2 (Right Nipple)":
              this._Pierings[4] = true;
              break;
            case "Piercing 2 (Clitoris)":
              this._Pierings[5] = true;
              break;
          }
        }
        if (!this._Pierings[0])
          _gameplay.AddChatOption("(50BN) Left Nipple", (Action) (() =>
          {
            if (Main.Instance.Player.Money >= 50)
            {
              Main.Instance.Player.Money -= 50;
              Main.Instance.GameplayMenu.ShowNotification("Paied 50BN");
              Main.Instance.Player.DressClothe(this.Piereeecings[0]);
              Main.Instance.GameplayMenu.EndChat();
            }
            else
            {
              Main.Instance.GameplayMenu.EnableMove();
              _gameplay.DisplaySubtitle(Main.GetLine(63 /*0x3F*/), Main.Instance.Personalities[0].Voice_Generics[5], new Action(this.Workers[0].ThisPersonInt.EndTheChat), this.Workers[0]);
            }
          }));
        if (!this._Pierings[1])
          _gameplay.AddChatOption("(50BN) Right Nipple", (Action) (() =>
          {
            if (Main.Instance.Player.Money >= 50)
            {
              Main.Instance.Player.Money -= 50;
              Main.Instance.GameplayMenu.ShowNotification("Paied 50BN");
              Main.Instance.Player.DressClothe(this.Piereeecings[1]);
              Main.Instance.GameplayMenu.EndChat();
            }
            else
            {
              Main.Instance.GameplayMenu.EnableMove();
              _gameplay.DisplaySubtitle(Main.GetLine(63 /*0x3F*/), Main.Instance.Personalities[0].Voice_Generics[5], new Action(this.Workers[0].ThisPersonInt.EndTheChat), this.Workers[0]);
            }
          }));
        if (!this._Pierings[2])
          _gameplay.AddChatOption("(50BN) Clitoris", (Action) (() =>
          {
            if (Main.Instance.Player.Money >= 50)
            {
              Main.Instance.Player.Money -= 50;
              Main.Instance.GameplayMenu.ShowNotification("Paied 50BN");
              Main.Instance.Player.DressClothe(this.Piereeecings[2]);
              Main.Instance.GameplayMenu.EndChat();
            }
            else
            {
              Main.Instance.GameplayMenu.EnableMove();
              _gameplay.DisplaySubtitle(Main.GetLine(63 /*0x3F*/), Main.Instance.Personalities[0].Voice_Generics[5], new Action(this.Workers[0].ThisPersonInt.EndTheChat), this.Workers[0]);
            }
          }));
        _gameplay.AddChatOption("(Next Page)", (Action) (() =>
        {
          _gameplay.RemoveAllChatOptions();
          if (!this._Pierings[3])
            _gameplay.AddChatOption("(100BN) Left Nipple 2", (Action) (() =>
            {
              if (Main.Instance.Player.Money >= 100)
              {
                Main.Instance.Player.Money -= 100;
                Main.Instance.GameplayMenu.ShowNotification("Paied 100BN");
                Main.Instance.Player.DressClothe(this.Piereeecings[3]);
                Main.Instance.GameplayMenu.EndChat();
              }
              else
              {
                Main.Instance.GameplayMenu.EnableMove();
                _gameplay.DisplaySubtitle(Main.GetLine(63 /*0x3F*/), Main.Instance.Personalities[0].Voice_Generics[5], new Action(this.Workers[0].ThisPersonInt.EndTheChat), this.Workers[0]);
              }
            }));
          if (!this._Pierings[4])
            _gameplay.AddChatOption("(100BN) Right Nipple 2", (Action) (() =>
            {
              if (Main.Instance.Player.Money >= 100)
              {
                Main.Instance.Player.Money -= 100;
                Main.Instance.GameplayMenu.ShowNotification("Paied 100BN");
                Main.Instance.Player.DressClothe(this.Piereeecings[4]);
                Main.Instance.GameplayMenu.EndChat();
              }
              else
              {
                Main.Instance.GameplayMenu.EnableMove();
                _gameplay.DisplaySubtitle(Main.GetLine(63 /*0x3F*/), Main.Instance.Personalities[0].Voice_Generics[5], new Action(this.Workers[0].ThisPersonInt.EndTheChat), this.Workers[0]);
              }
            }));
          if (!this._Pierings[5])
            _gameplay.AddChatOption("(100BN) Clitoris 2", (Action) (() =>
            {
              if (Main.Instance.Player.Money >= 100)
              {
                Main.Instance.Player.Money -= 100;
                Main.Instance.GameplayMenu.ShowNotification("Paied 100BN");
                Main.Instance.Player.DressClothe(this.Piereeecings[5]);
                Main.Instance.GameplayMenu.EndChat();
              }
              else
              {
                Main.Instance.GameplayMenu.EnableMove();
                _gameplay.DisplaySubtitle(Main.GetLine(63 /*0x3F*/), Main.Instance.Personalities[0].Voice_Generics[5], new Action(this.Workers[0].ThisPersonInt.EndTheChat), this.Workers[0]);
              }
            }));
          _gameplay.AddChatOption("None", new Action(Main.Instance.GameplayMenu.EndChat));
          _gameplay.SelectChatOption(0);
          Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
        }));
        _gameplay.AddChatOption("None", new Action(Main.Instance.GameplayMenu.EndChat));
        _gameplay.SelectChatOption(0);
        Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
      }));
      _gameplay.AddChatOption("I wanna remove piercings...", (Action) (() =>
      {
        _gameplay.RemoveAllChatOptions();
        this._PieringsD = new Dressable[6];
        for (int index = 0; index < Main.Instance.Player.EquippedClothes.Count; ++index)
        {
          switch (Main.Instance.Player.EquippedClothes[index].OriginalPrefab.name)
          {
            case "Piercing (Left Nipple)":
              this._PieringsD[0] = Main.Instance.Player.EquippedClothes[index];
              break;
            case "Piercing (Right Nipple)":
              this._PieringsD[1] = Main.Instance.Player.EquippedClothes[index];
              break;
            case "Piercing (Clitoris)":
              this._PieringsD[2] = Main.Instance.Player.EquippedClothes[index];
              break;
            case "Piercing 2 (Left Nipple)":
              this._PieringsD[3] = Main.Instance.Player.EquippedClothes[index];
              break;
            case "Piercing 2 (Right Nipple)":
              this._PieringsD[4] = Main.Instance.Player.EquippedClothes[index];
              break;
            case "Piercing 2 (Clitoris)":
              this._PieringsD[5] = Main.Instance.Player.EquippedClothes[index];
              break;
          }
        }
        if ((bool) (UnityEngine.Object) this._PieringsD[0])
          _gameplay.AddChatOption("Left Nipple", (Action) (() =>
          {
            Main.Instance.GameplayMenu.EndChat();
            UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.Player.UndressClothe(this._PieringsD[0]));
          }));
        if ((bool) (UnityEngine.Object) this._PieringsD[1])
          _gameplay.AddChatOption("Right Nipple", (Action) (() =>
          {
            Main.Instance.GameplayMenu.EndChat();
            UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.Player.UndressClothe(this._PieringsD[1]));
          }));
        if ((bool) (UnityEngine.Object) this._PieringsD[2])
          _gameplay.AddChatOption("Clitoris", (Action) (() =>
          {
            Main.Instance.GameplayMenu.EndChat();
            UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.Player.UndressClothe(this._PieringsD[2]));
          }));
        _gameplay.AddChatOption("(Next Page)", (Action) (() =>
        {
          if ((bool) (UnityEngine.Object) this._PieringsD[3])
            _gameplay.AddChatOption("Left Nipple 2", (Action) (() =>
            {
              Main.Instance.GameplayMenu.EndChat();
              UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.Player.UndressClothe(this._PieringsD[3]));
            }));
          if ((bool) (UnityEngine.Object) this._PieringsD[4])
            _gameplay.AddChatOption("Right Nipple 2", (Action) (() =>
            {
              Main.Instance.GameplayMenu.EndChat();
              UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.Player.UndressClothe(this._PieringsD[4]));
            }));
          if ((bool) (UnityEngine.Object) this._PieringsD[5])
            _gameplay.AddChatOption("Clitoris 2", (Action) (() =>
            {
              Main.Instance.GameplayMenu.EndChat();
              UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.Player.UndressClothe(this._PieringsD[5]));
            }));
          _gameplay.AddChatOption("None", new Action(Main.Instance.GameplayMenu.EndChat));
          _gameplay.SelectChatOption(0);
          Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
        }));
        _gameplay.AddChatOption("None", new Action(Main.Instance.GameplayMenu.EndChat));
        _gameplay.SelectChatOption(0);
        Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
      }));
      _gameplay.SelectChatOption(0);
      Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
    }));
    string[] strArray = new string[2]
    {
      "Hey you're really cute.  Let's have sex",
      "You're adorable.  Let's fuck"
    };
    _gameplay.AddChatOption(strArray[UnityEngine.Random.Range(0, strArray.Length)], (Action) (() =>
    {
      _gameplay.DisplaySubtitle("Meet me after work at my place, " + person.HomeAddress, (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
      Main.Instance.GameplayMenu.EnableMove();
    }));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }
}
