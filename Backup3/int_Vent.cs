// Decompiled with JetBrains decompiler
// Type: int_Vent
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class int_Vent : Interactible
{
  public Mis_HardTutorial MissionHard;
  public AudioClip[] VoiceLines;
  public AudioClip[] VoiceLines2;
  public Person Beth;
  public Transform TpSpoit;

  public override void Interact(Person person)
  {
    switch (this.MissionHard.CurrentDay)
    {
      case 0:
        Main.Instance.GameplayMenu.ShowNotification("Not possible to fit yet. (60% broken)");
        break;
      case 1:
        Main.Instance.GameplayMenu.ShowNotification("Not possible to fit yet. (70% broken)");
        break;
      case 2:
        Main.Instance.GameplayMenu.ShowNotification("Not possible to fit yet. (80% broken)");
        break;
      case 3:
        Main.Instance.GameplayMenu.ShowNotification("Not possible to fit yet. (99% broken)");
        break;
      case 4:
        Main.Instance.Player.transform.position = this.TpSpoit.position;
        foreach (Interactible interactible in UnityEngine.Object.FindObjectsOfType<int_wallpussy>())
          interactible.AddBlocker("asdasdasd");
        Main.RunInNextFrame((Action) (() => Main.Instance.Player.PersonAudio.PlayOneShot(this.VoiceLines[10])), 2);
        break;
    }
  }

  public void BethTalk()
  {
    if (Main.Instance.GlobalVars.ContainsKey("BethEscape"))
    {
      switch (Main.Instance.GlobalVars["BethEscape"])
      {
        case "1":
          if (Main.Instance.Player.Storage_Hands.StorageItems.Count != 0)
          {
            int_ResourceItem componentInChildren = Main.Instance.Player.Storage_Hands.StorageItems[0].GetComponentInChildren<int_ResourceItem>(true);
            if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null) || componentInChildren.ResourceType != e_ResourceType.Condom)
            {
              Main.Instance.GameplayMenu.DisplaySubtitle("Bring me a condom in your hand, and I'll tell you how to escape", this.VoiceLines[2], new Action(Main.Instance.GameplayMenu.EndChat), this.Beth);
              break;
            }
            Main.Instance.GlobalVars.Add("BethEscape", "2");
            GameObject storageItem = Main.Instance.Player.Storage_Hands.StorageItems[0];
            Main.Instance.Player.Storage_Hands.RemoveItem(storageItem);
            UnityEngine.Object.Destroy((UnityEngine.Object) storageItem);
            Main.Instance.GameplayMenu.DisplaySubtitle("Oh my, you actually got one!", this.VoiceLines[3], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Well you see, inside the building, under the stairs, there's a vent", this.VoiceLines[4], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Inside it there's enough space for us to move, but the vent entrance itself it's too tight", this.VoiceLines[5], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("But my friend is breaking around it a bit every day", this.VoiceLines[6], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Check on it everyday", this.VoiceLines[7], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("But don't be suspicious!", this.VoiceLines[8], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Once we manage to get inside it, we don't know where it leads, but probably an exit...", this.VoiceLines[9], (Action) (() =>
            {
              Main.Instance.GameplayMenu.EndChat();
              this.Beth.ThisPersonInt.StartTalkFunc = "ChatPrisioner";
              this.Beth.ThisPersonInt.StartTalkMono = (MonoBehaviour) UnityEngine.Object.FindObjectOfType<job_CapturedHouse>().GetComponent<job_CapturedHouse>();
            }), this.Beth)), this.Beth)), this.Beth)), this.Beth)), this.Beth)), this.Beth)), this.Beth);
            break;
          }
          Main.Instance.GameplayMenu.DisplaySubtitle("Bring me a condom in your hand, and I'll tell you how to escape", this.VoiceLines[2], new Action(Main.Instance.GameplayMenu.EndChat), this.Beth);
          break;
        case "2":
          this.Beth.ThisPersonInt.StartTalkFunc = "ChatPrisioner";
          this.Beth.ThisPersonInt.StartTalkMono = (MonoBehaviour) UnityEngine.Object.FindObjectOfType<job_CapturedHouse>().GetComponent<job_CapturedHouse>();
          break;
      }
    }
    else
    {
      Main.Instance.GlobalVars.Add("BethEscape", "1");
      Main.Instance.GameplayMenu.DisplaySubtitle("Hey, do you want to escape from here?", this.VoiceLines[0], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("I know how, but first you gotta bring me a condom", this.VoiceLines[1], new Action(Main.Instance.GameplayMenu.EndChat), this.Beth)), this.Beth);
    }
  }
}
