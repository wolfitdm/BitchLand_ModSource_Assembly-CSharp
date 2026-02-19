// Decompiled with JetBrains decompiler
// Type: int_HealthPod
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class int_HealthPod : int_basicSit
{
  [Header("-----------------------------------")]
  public Transform PersonSpot;
  public int _PodUseType;
  public GameObject Timervisual;
  public GameObject[] TimerSlider;
  public GameObject NamePrompt;
  public float HealTimerMax;
  public float HealTimer;

  public int PodUseType
  {
    get => this._PodUseType;
    set
    {
      Debug.LogError((object) ("_PodUseType set from " + this._PodUseType.ToString() + " to " + value.ToString()));
      this._PodUseType = value;
    }
  }

  public override void Awake()
  {
    base.Awake();
    this.enabled = false;
  }

  public void Update()
  {
    if ((Object) this.InteractingPerson == (Object) null)
    {
      this.enabled = false;
    }
    else
    {
      switch (this.PodUseType)
      {
        case 1:
          this.HealTimer -= Time.deltaTime;
          if (this.Timervisual.activeSelf)
          {
            float num = this.HealTimerMax - Main.POfVal(this.HealTimerMax, 0.0f, this.HealTimer);
            if ((double) num > 0.25)
              this.TimerSlider[0].SetActive(true);
            if ((double) num > 0.5)
              this.TimerSlider[1].SetActive(true);
            if ((double) num > 0.75)
              this.TimerSlider[2].SetActive(true);
          }
          if ((double) this.HealTimer > 0.0)
            break;
          this.HealTimer = 0.0f;
          this.StopInteracting();
          break;
        case 2:
          this.HealTimer -= Time.deltaTime;
          if (this.Timervisual.activeSelf)
          {
            float num = this.HealTimerMax - Main.POfVal(this.HealTimerMax, 0.0f, this.HealTimer);
            if ((double) num > 0.25)
              this.TimerSlider[0].SetActive(true);
            if ((double) num > 0.5)
              this.TimerSlider[1].SetActive(true);
            if ((double) num > 0.75)
              this.TimerSlider[2].SetActive(true);
          }
          if ((double) this.HealTimer > 0.0)
            break;
          this.HealTimer = 0.0f;
          this.NamePrompt.SetActive(true);
          break;
        default:
          this.InteractingPerson.TheHealth.currentHealth += Time.deltaTime;
          if (this.InteractingPerson.IsPlayer)
            Main.Instance.GameplayMenu.UpdateHealth();
          if (this.Timervisual.activeSelf)
          {
            double num = (double) Main.POfVal(this.InteractingPerson.TheHealth.maxHealth, 0.0f, this.InteractingPerson.TheHealth.currentHealth);
            if (num > 0.25)
              this.TimerSlider[0].SetActive(true);
            if (num > 0.5)
              this.TimerSlider[1].SetActive(true);
            if (num > 0.75)
              this.TimerSlider[2].SetActive(true);
          }
          if ((double) this.InteractingPerson.TheHealth.currentHealth < (double) this.InteractingPerson.TheHealth.maxHealth)
            break;
          this.InteractingPerson.TheHealth.currentHealth = this.InteractingPerson.TheHealth.maxHealth;
          this.StopInteracting();
          break;
      }
    }
  }

  public override void Interact(Person person)
  {
    base.Interact(person);
    this.HealTimer = this.HealTimerMax;
    for (int index = 0; index < this.TimerSlider.Length; ++index)
      this.TimerSlider[index].SetActive(false);
  }

  public override void StopInteracting(Person interactingPerson)
  {
    base.StopInteracting(interactingPerson);
    this.PodUseType = 0;
  }

  public void NamePromptUse()
  {
    this.NamePrompt.SetActive(false);
    Main.Instance.GameplayMenu.ShowTextInput("Name", (MonoBehaviour) this, "GiveName");
    Main.Instance.GameplayMenu.TextInputMenu_input.text = this.InteractingPerson.Name;
  }

  public void GiveName()
  {
    this.NamePrompt.SetActive(false);
    this.InteractingPerson.Name = Main.Instance.GameplayMenu.TextInputMenu_input.text;
    this.InteractingPerson.PlayerKnowsName = true;
    this.InteractingPerson.ThisPersonInt.SetDefaultInteraction();
    this.InteractingPerson.Favor = 100;
    this.StopInteracting(this.InteractingPerson);
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    Debug.LogError((object) "it fucking saved");
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(this.PodUseType.ToString());
    stringList.Add(this.HealTimerMax.ToString());
    stringList.Add(this.HealTimer.ToString());
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    Debug.LogError((object) "it fucking loaded");
    base.sd_LoadData(Data, SlitChar);
    this.PodUseType = int.Parse(Data[this._CurrentLoadingIndex++]);
    this.HealTimerMax = Main.ParseFloat(Data[this._CurrentLoadingIndex++]);
    this.HealTimer = Main.ParseFloat(Data[this._CurrentLoadingIndex++]);
  }
}
