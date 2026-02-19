// Decompiled with JetBrains decompiler
// Type: bl_J_PopulationEntry
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class bl_J_PopulationEntry : MonoBehaviour
{
  public Text TitleName;
  public Dropdown Class_drop;
  public GameObject[] Rels;
  public Image[] RelsValues;
  public Dropdown[] Dropsdowns;
  public Person PersonThisIs;
  public int ThisPersonRel;
  public InputField NoteText;
  public Button InfoBtn;
  public GameObject[] ClassLockIcons;
  public Button ClassLockBtn;
  public int ThisPatrol;

  public void DisplayForPerson(Person person)
  {
    this.PersonThisIs = person;
    this.TitleName.text = person.Name;
    this.Class_drop.value = (int) person.PersonType.ThisType_menu;
    this.RelsValues[2].fillAmount = Main.POfVal(0.0f, 200f, (float) person.ArmySkills);
    this.RelsValues[3].fillAmount = Main.POfVal(0.0f, 200f, (float) person.WorkSkills);
    this.RelsValues[4].fillAmount = Main.POfVal(0.0f, 200f, (float) person.SexSkills);
    string str = person.SaveableVars.Get("Note");
    if (str != null && str.Length > 0)
      this.NoteText.text = str;
    for (int index = 0; index < Main.Instance.GameplayMenu.Relationships.Count; ++index)
    {
      if ((UnityEngine.Object) Main.Instance.GameplayMenu.Relationships[index] == (UnityEngine.Object) this.PersonThisIs)
      {
        this.ThisPersonRel = index;
        this.InfoBtn.interactable = true;
        break;
      }
    }
    this.ClassLockIcons[0].SetActive(this.PersonThisIs.ClassLocked);
    this.ClassLockIcons[1].SetActive(!this.PersonThisIs.ClassLocked);
    if (!Main.Instance.OpenWorld)
    {
      this.Class_drop.interactable = false;
      this.ClassLockBtn.interactable = false;
      this.ClassLockIcons[0].SetActive(true);
      this.ClassLockIcons[1].SetActive(false);
    }
    this.Class_drop.transform.GetComponent<bl_DropdownHandler>().OnDropdownOpened += new bl_DropdownHandler.DropdownOpened(this.DropdownOpened);
    if (this.Class_drop.value <= 1)
    {
      this.Rels[2].SetActive(true);
      this.RelsValues[5].fillAmount = Main.POfVal(100f, 0.0f, person.TrainingValue);
      this.Rels[3].SetActive((double) this.PersonThisIs.TrainingValue >= 99.0);
    }
    else
      this.Rels[2].SetActive(false);
  }

  public void DropdownOpened()
  {
    Main.RunInNextFrame((Action) (() =>
    {
      Transform transform = this.Class_drop.transform.Find("Dropdown List/Viewport/Content");
      if (this.Class_drop.value <= 1)
      {
        this.Rels[2].SetActive(true);
        this.RelsValues[5].fillAmount = Main.POfVal(100f, 0.0f, this.PersonThisIs.TrainingValue);
      }
      if ((double) this.PersonThisIs.TrainingValue < 99.0)
      {
        if (!((UnityEngine.Object) transform != (UnityEngine.Object) null) || !((UnityEngine.Object) transform.GetChild(3) != (UnityEngine.Object) null) || !((UnityEngine.Object) transform.GetChild(3).GetChild(4) != (UnityEngine.Object) null))
          return;
        transform.GetChild(3).GetChild(4).gameObject.SetActive(true);
        transform.GetChild(4).GetChild(4).gameObject.SetActive(true);
        transform.GetChild(5).GetChild(4).gameObject.SetActive(true);
        transform.GetChild(6).GetChild(4).gameObject.SetActive(true);
      }
      else
        this.Rels[3].SetActive(true);
    }), 3);
  }

  public void ChangePersonClass()
  {
    if (Main.Instance.OpenWorld && this.Class_drop.value > 1 && (double) this.PersonThisIs.TrainingValue < 99.0)
    {
      this.Class_drop.value = 1;
      this.Rels[2].SetActive(true);
      this.RelsValues[5].fillAmount = Main.POfVal(100f, 0.0f, this.PersonThisIs.TrainingValue);
    }
    switch (this.Class_drop.value)
    {
      case 1:
        Main.Instance.PersonTypes[2].GetAssignedto(this.PersonThisIs);
        break;
      case 2:
        Main.Instance.PersonTypes[3].GetAssignedto(this.PersonThisIs);
        break;
      case 3:
        Main.Instance.PersonTypes[6].GetAssignedto(this.PersonThisIs);
        break;
      case 4:
        Main.Instance.PersonTypes[4].GetAssignedto(this.PersonThisIs);
        break;
      case 5:
        Main.Instance.PersonTypes[7].GetAssignedto(this.PersonThisIs);
        break;
      default:
        Main.Instance.PersonTypes[0].GetAssignedto(this.PersonThisIs);
        break;
    }
  }

  public void ChangeNote()
  {
    if (this.NoteText.text == null || this.NoteText.text.Length <= 0)
      return;
    this.PersonThisIs.SaveableVars.Set("Note", this.NoteText.text);
  }

  public void Click_Info()
  {
    Main.Instance.GameplayMenu.SelectRels();
    Main.Instance.GameplayMenu.Rels_selectPErson(this.ThisPersonRel);
  }

  public void Click_LockClass()
  {
    this.PersonThisIs.ClassLocked = !this.PersonThisIs.ClassLocked;
    this.ClassLockIcons[0].SetActive(this.PersonThisIs.ClassLocked);
    this.ClassLockIcons[1].SetActive(!this.PersonThisIs.ClassLocked);
  }

  public void ARMY_DisplayForPerson(Person person)
  {
    this.PersonThisIs = person;
    this.TitleName.text = person.Name;
    string str1 = person.SaveableVars.Get("Note");
    if (str1 != null && str1.Length > 0)
      this.NoteText.text = str1;
    if (Main.Instance.OpenWorld)
    {
      string str2 = person.SaveableVars.Get("ArmyData");
      if (str2 != null && str2.Length > 1)
      {
        string[] strArray = str2.Split(":", StringSplitOptions.None);
        switch (strArray[0])
        {
          case "0":
            this.Dropsdowns[0].SetValueWithoutNotify(0);
            break;
          case "1":
            this.Dropsdowns[0].SetValueWithoutNotify(1);
            this.Dropsdowns[1].gameObject.SetActive(true);
            this.RefreshDropOPtionsFor_Patrols(this.Dropsdowns[1], strArray[1]);
            break;
          case "2":
            this.Dropsdowns[0].SetValueWithoutNotify(2);
            this.Dropsdowns[2].gameObject.SetActive(true);
            break;
        }
      }
      else
        this.Dropsdowns[0].SetValueWithoutNotify(0);
    }
    else
      this.Dropsdowns[0].interactable = false;
  }

  public void RefreshDropOPtionsFor_Patrols(Dropdown drop, string optionTopSelect)
  {
    List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
    int input = 0;
    drop.ClearOptions();
    options.Add(new Dropdown.OptionData()
    {
      text = "Wonder"
    });
    options.Add(new Dropdown.OptionData()
    {
      text = "Random Spots"
    });
    for (int index = 0; index < Main.Instance.AllPatrols.Count; ++index)
    {
      Dropdown.OptionData optionData = new Dropdown.OptionData();
      optionData.text = Main.Instance.AllPatrols[index].Name;
      if (optionData.text == optionTopSelect)
        input = index + 2;
      options.Add(optionData);
    }
    if (input == 0 && optionTopSelect == "Random Spots")
      input = 1;
    drop.AddOptions(options);
    drop.SetValueWithoutNotify(input);
  }

  public void RefreshDropOPtionsFor_Training(Dropdown drop, string optionTopSelect)
  {
    List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
    int input = 0;
    drop.ClearOptions();
    options.Add(new Dropdown.OptionData()
    {
      text = "Anyone"
    });
    for (int index = 0; index < Main.Instance.SpawnedPeople_World.Count; ++index)
    {
      Person person = Main.Instance.SpawnedPeople_World[index];
      if ((UnityEngine.Object) person != (UnityEngine.Object) null && person.PersonType.ThisType == Person_Type.Prisioner)
      {
        Dropdown.OptionData optionData = new Dropdown.OptionData();
        optionData.text = person.Name;
        if (optionData.text == optionTopSelect)
          input = index + 1;
        options.Add(optionData);
      }
    }
    drop.AddOptions(options);
    drop.SetValueWithoutNotify(input);
  }

  public void SelectDropOption_ArmyOrder()
  {
    this.PersonThisIs.WorkScheduleTasks.Clear();
    switch (this.Dropsdowns[0].value)
    {
      case 0:
        this.PersonThisIs.SaveableVars.Set("ArmyData", "0");
        this.Dropsdowns[1].gameObject.SetActive(false);
        this.Dropsdowns[2].gameObject.SetActive(false);
        break;
      case 1:
        this.Dropsdowns[1].gameObject.SetActive(true);
        this.Dropsdowns[2].gameObject.SetActive(false);
        this.RefreshDropOPtionsFor_Patrols(this.Dropsdowns[1], string.Empty);
        this.SelectDropOption_ArmyOrderPatrol();
        break;
      case 2:
        this.Dropsdowns[1].gameObject.SetActive(false);
        this.Dropsdowns[2].gameObject.SetActive(true);
        this.RefreshDropOPtionsFor_Training(this.Dropsdowns[2], string.Empty);
        this.SelectDropOption_ArmyOrderTrain();
        break;
    }
  }

  public void SelectDropOption_ArmyOrderPatrol()
  {
    this.PersonThisIs.WorkScheduleTasks.Clear();
    this.PersonThisIs.SaveableVars.Set("ArmyData", "1:" + this.Dropsdowns[1].captionText.text);
  }

  public void SelectDropOption_ArmyOrderTrain()
  {
    this.PersonThisIs.WorkScheduleTasks.Clear();
    this.PersonThisIs.SaveableVars.Set("ArmyData", "2:" + this.Dropsdowns[1].captionText.text);
  }

  public void On_patrolrename()
  {
    Main.Instance.AllPatrols[this.ThisPatrol].Name = this.NoteText.text;
  }

  public void Patrol_ChangeSpot(string which)
  {
    string str = "HUH!? I CAN'T USE A INT AS PARAMETER????????? WHAT THE FUCK???" + string.Empty;
    int index1 = 0;
    switch (which)
    {
      case "1":
        index1 = 1;
        break;
      case "2":
        index1 = 2;
        break;
      case "3":
        index1 = 3;
        break;
      case "4":
        index1 = 4;
        break;
      case "5":
        index1 = 5;
        break;
    }
    int index2 = this.Dropsdowns[index1].value - 1;
    if (index2 == -1)
      Main.Instance.AllPatrols[this.ThisPatrol].Spots[index1] = (Transform) null;
    else
      Main.Instance.AllPatrols[this.ThisPatrol].Spots[index1] = UnityEngine.Object.FindObjectsOfType<int_PatrolSpot>(true)[index2].transform;
  }

  public void Patrol_ChangeSpodfsgfdgdfgt(int dsafadsfadsf)
  {
    string str = "THIS DOES NOT APPEAR IN THE INSPECTOR AS A SELECTABLE INT" + string.Empty;
  }

  public void DeleteThisPatrol()
  {
    Main.Instance.AllPatrols.RemoveAt(this.ThisPatrol);
    Main.Instance.GameplayMenu.Army_SelectPatrol();
  }

  public void ARMY_Train_DisplayForPerson(Person person)
  {
    this.PersonThisIs = person;
    this.TitleName.text = person.Name;
    string str1 = person.SaveableVars.Get("Note");
    if (str1 != null && str1.Length > 0)
      this.NoteText.text = str1;
    if (Main.Instance.OpenWorld)
    {
      string str2 = person.SaveableVars.Get("TrainData");
      if (str2 != null && str2.Length > 1)
      {
        switch (str2)
        {
          case "0":
            this.Dropsdowns[0].SetValueWithoutNotify(0);
            break;
          case "1":
            this.Dropsdowns[0].SetValueWithoutNotify(1);
            break;
          case "2":
            this.Dropsdowns[0].SetValueWithoutNotify(2);
            break;
          case "3":
            this.Dropsdowns[0].SetValueWithoutNotify(3);
            break;
        }
      }
      else
        this.Dropsdowns[0].SetValueWithoutNotify(0);
    }
    else
      this.Dropsdowns[0].interactable = false;
  }

  public void On_TrainDropValue()
  {
    this.PersonThisIs.SaveableVars.Set("TrainData", this.Dropsdowns[0].value.ToString());
  }
}
