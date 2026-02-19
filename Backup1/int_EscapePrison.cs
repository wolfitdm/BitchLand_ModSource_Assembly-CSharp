// Decompiled with JetBrains decompiler
// Type: int_EscapePrison
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class int_EscapePrison : Interactible
{
  public Transform Spot;
  public Transform SiaPlaceSpot;
  public RandomNPCHere SiaSpawn;
  public Person Sia;
  public int_Vent Vent;

  public override void Interact(Person person)
  {
    Main.Instance.Player.transform.position = this.Spot.position;
    Main.Instance.Player.AddMoveBlocker("escaping");
    Main.Instance.MusicPlayer.PlayOneShot(this.Vent.VoiceLines[11]);
    this.SiaSpawn.DestroyOnCreate = false;
    this.SiaSpawn.transform.parent = (Transform) null;
    Main.RunInNextFrame((Action) (() =>
    {
      this.Sia = this.SiaSpawn.PersonGenerated;
      this.SiaSpawn.gameObject.SetActive(false);
      this.Sia.transform.position = this.SiaPlaceSpot.position;
      this.Sia.transform.LookAt(Main.Instance.Player.transform);
      Main.Instance.GameplayMenu.DisplaySubtitle("Hey! You can't escape THAT easily!", this.Vent.VoiceLines2[0], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Hold on, you look like the leader's daughter...", this.Vent.VoiceLines2[1], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("I'm either too drunk, or too high, to care anyway", this.Vent.VoiceLines2[2], (Action) (() =>
      {
        Main.Instance.MusicPlayer.PlayOneShot(this.Vent.VoiceLines[12]);
        List<Dressable> dressableList = new List<Dressable>();
        dressableList.AddRange((IEnumerable<Dressable>) Main.Instance.Player.EquippedClothes);
        for (int index = 0; index < dressableList.Count; ++index)
        {
          switch (dressableList[index].BodyPart)
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
            case DressableType.BackPack:
              if ((UnityEngine.Object) dressableList[index] != (UnityEngine.Object) null)
              {
                GameObject gameObject = Main.Instance.Player.UndressClothe(dressableList[index]);
                if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
                {
                  UnityEngine.Object.Destroy((UnityEngine.Object) gameObject);
                  break;
                }
                break;
              }
              break;
          }
        }
        Main.Instance.Player.DyedHairColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        Main.Instance.Player.RefreshColors();
        Main.Instance.GameplayMenu.DisplaySubtitle("Lemme take those restraints from you", this.Vent.VoiceLines2[3], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Off you go. Say hi to Sarah for me", this.Vent.VoiceLines2[4], (Action) (() =>
        {
          Main.Instance.GameplayMenu.EndChat();
          UnityEngine.Object.FindObjectOfType<Mis_HardTutorial>().Escape(1);
        }), this.Sia)), this.Sia);
      }), this.Sia)), this.Sia)), this.Sia);
    }), 2);
  }
}
