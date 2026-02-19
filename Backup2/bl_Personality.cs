// Decompiled with JetBrains decompiler
// Type: bl_Personality
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class bl_Personality : MonoBehaviour
{
  public e_BlendShapes FaceBlendshape;
  public string IdleAnim;
  public string WalkAnim;
  public float HowLongWantsSex;
  public int PrevHelloRandom = -1;
  public AudioClip[] Voice_Hello;
  public AudioClip[] Voice_SexFollow;
  public AudioClip[] Voice_SexLead;
  public AudioClip[] Voice_SexProstReject;
  public AudioClip[] Voice_SexAfterWork;
  public AudioClip[] Voice_SexReject;
  public AudioClip[] Voice_Generics;

  public virtual void OnSpawn(Person _thisPerson)
  {
    if (this.IdleAnim != null && this.IdleAnim.Length > 0)
    {
      _thisPerson.A_Standing = this.IdleAnim;
      _thisPerson.A_Standing_Org = this.IdleAnim;
    }
    if (this.WalkAnim != null && this.WalkAnim.Length > 0)
      _thisPerson.A_Walking = this.WalkAnim;
    _thisPerson.ResetAllShapes();
    if (this.FaceBlendshape >= e_BlendShapes.Max)
    {
      Debug.LogError((object) "(int)FaceBlendshape >= (int)e_BlendShapes.Max");
    }
    else
    {
      try
      {
        _thisPerson.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[(int) this.FaceBlendshape]);
      }
      catch
      {
        Debug.LogError((object) ("Error: FaceBlendshape = " + ((int) this.FaceBlendshape).ToString()));
      }
    }
  }

  public virtual string Reply_Hello(out int lineIndex)
  {
    string[] strArray = new string[4]
    {
      Main.GetLine(55),
      Main.GetLine(56),
      Main.GetLine(57),
      Main.GetLine(58)
    };
    lineIndex = this.GetRandOf(strArray.Length);
    return strArray[lineIndex];
  }

  public int GetRandOf(int len)
  {
    int randOf = UnityEngine.Random.Range(0, len);
    if (randOf == this.PrevHelloRandom)
    {
      ++randOf;
      if (randOf >= len)
        randOf = 0;
    }
    this.PrevHelloRandom = randOf;
    return randOf;
  }

  public virtual int PickSexOption() => UnityEngine.Random.Range(0, 3);

  public virtual string Reply_SexFollow(out int lineIndex)
  {
    string[] strArray = new string[3]
    {
      Main.GetLine(49),
      Main.GetLine(51),
      Main.GetLine(52)
    };
    lineIndex = UnityEngine.Random.Range(0, strArray.Length);
    return strArray[lineIndex];
  }

  public virtual string Reply_SexLead(out int lineIndex)
  {
    string[] strArray = new string[3]
    {
      Main.GetLine(46),
      Main.GetLine(47),
      Main.GetLine(48 /*0x30*/)
    };
    lineIndex = UnityEngine.Random.Range(0, strArray.Length);
    return strArray[lineIndex];
  }

  public virtual string Reply_SexProstReject(out int lineIndex)
  {
    string[] strArray = new string[3]
    {
      Main.GetLine(28),
      Main.GetLine(29),
      Main.GetLine(31 /*0x1F*/)
    };
    lineIndex = UnityEngine.Random.Range(0, strArray.Length);
    return strArray[lineIndex];
  }

  public virtual string Reply_SexAfterWork(out int lineIndex)
  {
    string[] strArray = new string[1]{ Main.GetLine(53) };
    lineIndex = UnityEngine.Random.Range(0, strArray.Length);
    return strArray[lineIndex];
  }

  public virtual string Reply_SexReject(out int lineIndex)
  {
    string[] strArray = new string[1]{ Main.GetLine(54) };
    lineIndex = UnityEngine.Random.Range(0, strArray.Length);
    return strArray[lineIndex];
  }

  public virtual void OnSeeOtherPerson(Person thisPerson, Person person)
  {
    if (thisPerson.State != Person_State.Free)
      return;
    if (person.ClothingCondition == e_ClothingCondition.Nude)
    {
      if (!person.HasPenis && !thisPerson.HasPenis)
        return;
      this.OnSeeNakedPerson(thisPerson, person);
    }
    else if (person.IsPlayer && (UnityEngine.Object) person.CurrentZone != (UnityEngine.Object) null && person.CurrentZone.UnSafe)
    {
      if ((double) UnityEngine.Random.Range(0.0f, 1f) > 0.699999988079071)
      {
        if (!person.HasPenis && !thisPerson.HasPenis)
          return;
        this.OnSeeNakedPerson(thisPerson, person, true);
      }
      else
        person.ProxSeen.TimeOut = 3f;
    }
    else
    {
      if (person.ClothingCondition != e_ClothingCondition.Sexy)
        return;
      this.OnSeeSexyPerson(thisPerson, person);
    }
  }

  public virtual void OnSeeNakedPerson(Person thisPerson, Person person, bool forceAnyway = false)
  {
    if (person.TheHealth.dead || person.TheHealth.Incapacitated || !Main.Instance.FreeWorldPatch && thisPerson.IsPlayerDescendant && person.IsPlayer || thisPerson.CurrentScheduleTask == null || !(thisPerson.CurrentScheduleTask.IDName != "GoForceNakedPerson") || (double) UnityEngine.Random.Range(0.0f, 1f) <= 0.5)
      return;
    thisPerson.navMesh.stoppingDistance = 0.5f;
    thisPerson.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "GoForceNakedPerson",
      ActionPlace = person.transform,
      RunTo = true,
      WhileGoing = (Action) (() =>
      {
        if ((double) thisPerson.RandActionTimer > 1.0)
          thisPerson.RandActionTimer = 1f;
        thisPerson.RandActionTimer -= Time.deltaTime;
        if ((double) thisPerson.RandActionTimer >= 0.0)
          return;
        thisPerson.RandActionTimer = 1f;
        thisPerson.SetDestination(person.transform);
      }),
      OnArrive = (Action) (() =>
      {
        thisPerson.CompleteScheduleTask();
        thisPerson.RandActionTimer = 1f;
        if (person.HavingSex || person.Interacting || !SpawnedSexScene.CanStartSex(thisPerson, person) || !forceAnyway && person.ClothingCondition != e_ClothingCondition.Nude)
          return;
        if (person.IsPlayer)
        {
          int num = UnityEngine.Random.Range(1, 3);
          do
          {
            for (int index = 0; index < person.EquippedClothes.Count; ++index)
            {
              if (!person.EquippedClothes[index].NonRemovableOnThrowdown && person.EquippedClothes[index].BodyPart == DressableType.Pants || person.EquippedClothes[index].BodyPart == DressableType.Top || person.EquippedClothes[index].BodyPart == DressableType.UnderwearLower || person.EquippedClothes[index].BodyPart == DressableType.UnderwearTop)
                person.UndressClothe(person.EquippedClothes[index]);
            }
          }
          while (--num > 0);
        }
        SpawnedSexScene spawnedSexScene;
        if (!thisPerson.HasPenis && person.HasPenis)
        {
          spawnedSexScene = Main.Instance.SexScene.SpawnSexScene(4, 4, person, thisPerson, canControl: false);
          spawnedSexScene.On_ClothingToggle(false);
        }
        else
        {
          spawnedSexScene = Main.Instance.SexScene.SpawnSexScene(4, UnityEngine.Random.Range(0, 4), thisPerson, person, canControl: false);
          spawnedSexScene.On_ClothingToggle(true);
        }
        spawnedSexScene.TimerForRandomPoseChange = true;
        spawnedSexScene.TimerMax = UnityEngine.Random.Range(10f, 30f);
        spawnedSexScene.TimerPoseChange = spawnedSexScene.TimerMax;
        spawnedSexScene.TimerForRandomSexEnd = true;
        spawnedSexScene.TimerSexEnd = spawnedSexScene.TimerMax - 1f;
        spawnedSexScene.OnSexEnd = (Action) (() => person.Energy -= 20f);
        switch (UnityEngine.Random.Range(0, 6))
        {
          case 1:
            person.States[12] = true;
            break;
          case 2:
            person.States[13] = true;
            break;
          case 3:
            person.States[14] = true;
            break;
          case 4:
            person.States[15] = true;
            break;
          case 5:
            person.States[16 /*0x10*/] = true;
            break;
        }
      })
    });
  }

  public virtual void OnSeeSexyPerson(Person thisPerson, Person person)
  {
  }
}
