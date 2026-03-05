// Decompiled with JetBrains decompiler
// Type: int_basicSit
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class int_basicSit : Interactible
{
  public List<RandomAnimData> Sit_Anim = new List<RandomAnimData>();
  public RandomAnimData CurrentAnim;
  public bool PlayerCanLeave;
  public bool Attach;
  public bool FakeAttach;
  public bool SitTimeDependsOnPreference;
  public bool Unleashes;
  public bool Unrestrains;
  public Collider RemoveColOnUse;
  public string LeaveText = "Stand";
  public bool LoopAnims;
  public bool PlayAnimOnce;
  public float CamHeight;
  public Transform HeightRegulator;
  public int HeightRegRagBone;
  public Transform SitSpot;

  public override void Interact(Person person)
  {
    base.Interact(person);
    if (this.SitTimeDependsOnPreference)
      this.DoForSeconds = person.PersonalityData.HowLongWantsSex;
    if ((bool) (UnityEngine.Object) this.RemoveColOnUse)
      this.RemoveColOnUse.enabled = false;
    this.InteractingPerson._Rigidbody.isKinematic = true;
    if (this.InteractingPerson.IsPlayer)
    {
      Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
      this.InteractingPerson.UserControl.FirstPerson = false;
      Main.Instance.GameplayMenu.QLeave.SetActive(true);
      Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = this.LeaveText;
      if ((double) this.CamHeight != 0.0)
        Main.RunInNextFrame((Action) (() =>
        {
          if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
            return;
          this.InteractingPerson.UserControl.Pivot.localPosition = new Vector3(0.0f, this.CamHeight, 0.0f);
        }));
      if (this.PlayerCanLeave)
        Main.Instance.MainThreads.Add(new Action(this.Thread_LeaveKey));
    }
    this.InteractingPerson.AddMoveBlocker("Sit");
    if (this.Attach)
    {
      if ((UnityEngine.Object) this.SitSpot == (UnityEngine.Object) null)
        this.InteractingPerson.transform.SetParent(this.transform);
      else
        this.InteractingPerson.transform.SetParent(this.SitSpot);
      if (this.NPCCanBeInteractedWhileUsing)
      {
        for (int index = 0; index < this.InteractingPerson.RagdollParts.Length; ++index)
        {
          InteractRedirect component = this.InteractingPerson.RagdollParts[index].GetComponent<InteractRedirect>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
            component.Disabled = false;
        }
      }
    }
    if ((UnityEngine.Object) this.SitSpot == (UnityEngine.Object) null)
    {
      this.InteractingPerson.transform.position = this.transform.position;
      this.InteractingPerson.transform.rotation = this.transform.rotation;
    }
    else
    {
      this.InteractingPerson.transform.position = this.SitSpot.position;
      this.InteractingPerson.transform.rotation = this.SitSpot.rotation;
    }
    if ((UnityEngine.Object) this.HeightRegulator != (UnityEngine.Object) null)
      this.AdjustCharacterPosition(this.HeightRegulator, this.InteractingPerson.RagdollParts[this.HeightRegRagBone].transform);
    this.PlayRandomAnimation();
    this.enabled = this.LoopAnims || this.PlayAnimOnce;
    if (this.Unrestrains)
      person.Unrestrain();
    if (!this.Unleashes || !person.Leashed)
      return;
    person.ThisPersonInt.Unleash();
  }

  public void Thread_LeaveKey()
  {
    if (!Input.GetKeyUp(KeyCode.Q))
      return;
    this.StopInteracting();
    Main.Instance.MainThreads.Remove(new Action(this.Thread_LeaveKey));
  }

  public void PlayRandomAnimation()
  {
    if (this.InteractingPerson is Girl && this.CurrentAnim != null && this.CurrentAnim.AttatchBoobs)
      ((Girl) this.InteractingPerson).UnattatchBoobsToHands();
    if (this.CurrentAnim != null && this.CurrentAnim.DisableHeadRotate)
      this.InteractingPerson.LookAtPlayer.Disable = this.DisableHeadRotate;
    this.CurrentAnim = this.Sit_Anim[UnityEngine.Random.Range(0, this.Sit_Anim.Count)];
    if (this.Attach)
    {
      this.InteractingPerson.transform.localPosition = this.CurrentAnim.LocalPos;
      this.InteractingPerson.transform.localEulerAngles = this.CurrentAnim.LocalRot;
    }
    else if (this.FakeAttach)
    {
      this.InteractingPerson.transform.position = this.transform.position + this.CurrentAnim.LocalPos;
      this.InteractingPerson.transform.eulerAngles = this.transform.eulerAngles + this.CurrentAnim.LocalRot;
    }
    if (this.CurrentAnim.AttatchBoobs && this.InteractingPerson is Girl)
      ((Girl) this.InteractingPerson).AttatchBoobsToHands();
    if (this.CurrentAnim.DisableHeadRotate)
      this.InteractingPerson.LookAtPlayer.Disable = true;
    if ((UnityEngine.Object) this.HeightRegulator != (UnityEngine.Object) null)
      this.AdjustCharacterPosition(this.HeightRegulator, this.InteractingPerson.RagdollParts[this.HeightRegRagBone].transform);
    this.InteractingPerson.Anim.Play(this.CurrentAnim.Anim);
  }

  private void Update()
  {
    if ((double) this.InteractingPerson.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < (double) this.CurrentAnim.RunMoreTimes || this.InteractingPerson.Anim.IsInTransition(0))
      return;
    if (this.LoopAnims)
    {
      this.PlayRandomAnimation();
    }
    else
    {
      if (!this.PlayAnimOnce)
        return;
      this.StopInteracting();
    }
  }

  public override void StopInteracting()
  {
    this.enabled = false;
    if ((bool) (UnityEngine.Object) this.RemoveColOnUse)
      this.RemoveColOnUse.enabled = true;
    if (this.InteractingPerson is Girl && this.CurrentAnim != null && this.CurrentAnim.AttatchBoobs)
      ((Girl) this.InteractingPerson).UnattatchBoobsToHands();
    if (this.CurrentAnim != null && this.CurrentAnim.DisableHeadRotate)
      this.InteractingPerson.LookAtPlayer.Disable = this.DisableHeadRotate;
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
      return;
    this.InteractingPerson.transform.SetParent((Transform) null);
    this.InteractingPerson.RemoveMoveBlocker("Sit");
    if (this.NPCCanBeInteractedWhileUsing)
    {
      for (int index = 0; index < this.InteractingPerson.RagdollParts.Length; ++index)
      {
        InteractRedirect component = this.InteractingPerson.RagdollParts[index].GetComponent<InteractRedirect>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          component.Disabled = true;
      }
    }
    if (this.InteractingPerson.IsPlayer)
    {
      Main.Instance.GameplayMenu.QLeave.SetActive(false);
      this.InteractingPerson.UserControl.FirstPerson = true;
      this.InteractingPerson._Rigidbody.isKinematic = false;
      Main.Instance.Player.UserControl.ThirdCamPositionType = Main.Instance.Player.UserControl.ThirdCamPositionTypeOnSettings;
      Main.Instance.Player.UserControl.m_Character.StandState = bl_ThirdPersonCharacter.bl_StandState.Standing;
    }
    base.StopInteracting(this.InteractingPerson);
  }

  public override void StopInteracting(Person interactingPerson) => this.StopInteracting();

  public void AdjustCharacterPosition(Transform torso1, Transform torso2, Transform personRoot = null)
  {
    Vector3 vector3 = new Vector3(0.0f, torso1.position.y - torso2.position.y + 0.01f, 0.0f);
    if ((UnityEngine.Object) personRoot == (UnityEngine.Object) null)
      this.InteractingPerson.transform.position += vector3;
    else
      personRoot.position += vector3;
  }
}
