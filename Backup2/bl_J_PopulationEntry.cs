// Decompiled with JetBrains decompiler
// Type: bl_J_PopulationEntry
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class bl_J_PopulationEntry : MonoBehaviour
{
  public Text TitleName;
  public Dropdown Class_drop;
  public GameObject[] Rels;
  public Image[] RelsValues;
  public Person PersonThisIs;
  public int ThisPersonRel;
  public InputField NoteText;
  public Button InfoBtn;

  public void DisplayForPerson(Person person)
  {
    this.PersonThisIs = person;
    this.TitleName.text = person.Name;
    this.Class_drop.value = (int) person.PersonType.ThisType_menu;
    this.RelsValues[2].fillAmount = Main.POfVal(0.0f, 150f, (float) person.ArmySkills);
    this.RelsValues[3].fillAmount = Main.POfVal(0.0f, 150f, (float) person.WorkSkills);
    this.RelsValues[4].fillAmount = Main.POfVal(0.0f, 150f, (float) person.SexSkills);
    string str = person.SaveableVars.Get("Note");
    if (str != null && str.Length > 0)
      this.NoteText.text = str;
    for (int index = 0; index < Main.Instance.GameplayMenu.Relationships.Count; ++index)
    {
      if ((Object) Main.Instance.GameplayMenu.Relationships[index] == (Object) this.PersonThisIs)
      {
        this.ThisPersonRel = index;
        this.InfoBtn.interactable = true;
        break;
      }
    }
  }

  public void ChangePersonClass()
  {
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
}
