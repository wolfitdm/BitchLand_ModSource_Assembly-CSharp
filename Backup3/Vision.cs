// Decompiled with JetBrains decompiler
// Type: Vision
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Vision : MonoBehaviour
{
  public Vision.VisionQuality _Quality;
  public List<string> Flagger = new List<string>();
  public Person ThePerson;
  public Transform Eyes;
  public List<Collider> NewToSee = new List<Collider>();
  public int CurrentFrame;
  public int FrameMax = 5;
  public int CurrentCheck;

  public Vision.VisionQuality Quality
  {
    get => this._Quality;
    set
    {
      this._Quality = value;
      switch (value)
      {
        case Vision.VisionQuality.High:
          this.enabled = true;
          this.FrameMax = 60;
          break;
        case Vision.VisionQuality.Low:
          this.enabled = true;
          this.FrameMax = 180;
          break;
        case Vision.VisionQuality.None:
          this.enabled = true;
          this.FrameMax = 180;
          break;
      }
    }
  }

  public void AddFlagger(string FlagName)
  {
    if (!this.Flagger.Contains(FlagName))
      this.Flagger.Add(FlagName);
    this.gameObject.SetActive(true);
    this.RestartCol();
  }

  public void RemoveFlagger(string FlagName)
  {
    if (this.Flagger.Contains(FlagName))
      this.Flagger.Remove(FlagName);
    if (this.Flagger.Count != 0)
      return;
    this.gameObject.SetActive(false);
  }

  public void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 15 && other.gameObject.layer != 20 || !this.enabled || (UnityEngine.Object) other == (UnityEngine.Object) this.ThePerson.MainCol || (UnityEngine.Object) this.ThePerson.HeadCol != (UnityEngine.Object) null && (UnityEngine.Object) other == (UnityEngine.Object) this.ThePerson.HeadCol)
      return;
    Weapon component1 = other.transform.root.GetComponent<Weapon>();
    if ((UnityEngine.Object) component1 == (UnityEngine.Object) null)
    {
      bl_PersonRedirect component2 = other.GetComponent<bl_PersonRedirect>();
      Health component3 = (!((UnityEngine.Object) component2 != (UnityEngine.Object) null) ? (Component) other.transform.root : (Component) component2.RedirectTarget.transform).GetComponent<Health>();
      if ((UnityEngine.Object) component3 == (UnityEngine.Object) null || component3.dead || component3.Incapacitated)
        return;
    }
    else if (component1.currentAmmo == 0)
      return;
    this.NewToSee.Add(other);
  }

  public void OnTriggerExit(Collider other)
  {
    this.ThePerson.InRange.Remove(other);
    this.NewToSee.Remove(other);
  }

  public void FixedUpdate()
  {
    if (++this.CurrentFrame < this.FrameMax)
      return;
    this.CurrentFrame = 0;
    if (this.CurrentCheck-- <= this.NewToSee.Count)
    {
      Collider other = this.NewToSee[this.CurrentCheck];
      switch (this.CanSee_Internal(other))
      {
        case Vision.SawType.Saw:
          this.ThePerson.InRange.Add(other);
          this.ThePerson.Seen(other.gameObject);
          goto case Vision.SawType.SawbutItsDead;
        case Vision.SawType.SawbutItsDead:
          this.NewToSee.RemoveAt(this.CurrentCheck);
          break;
      }
      this.CurrentCheck += 2;
    }
    else
      this.CurrentCheck = 1;
  }

  public Vision.SawType CanSee_Internal(Collider other, Color rayColor = default (Color))
  {
    Vision.SawType sawType1 = this.RayCastTo(other.transform, other, rayColor, true);
    if (sawType1 != Vision.SawType.DidntSaw)
      return sawType1;
    MultipleSpotView component = other.GetComponent<MultipleSpotView>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
    {
      for (int index = 0; index < component.Spots.Length; ++index)
      {
        Vision.SawType sawType2 = this.RayCastTo(component.Spots[index], other, rayColor);
        if (sawType2 != Vision.SawType.DidntSaw)
          return sawType2;
      }
    }
    return Vision.SawType.DidntSaw;
  }

  public bool CanSee(Collider other, Color rayColor = default (Color))
  {
    return this.CanSee_Internal(other, rayColor) == Vision.SawType.Saw;
  }

  public Vision.SawType RayCastTo(
    Transform place,
    Collider other,
    Color rayColor = default (Color),
    bool LookAtCenter = false,
    bool canSeePlayer = true)
  {
    if (LookAtCenter)
      this.Eyes.LookAt(other.bounds.center);
    else
      this.Eyes.LookAt(place);
    RaycastHit hitInfo;
    if (!Physics.Raycast(this.Eyes.position, this.Eyes.TransformDirection(Vector3.forward), out hitInfo, 50f, (int) (canSeePlayer ? Main.Instance.VisionLayerMask : Main.Instance.VisionLayerMaskWithoutPlayer), QueryTriggerInteraction.Ignore) || !((UnityEngine.Object) hitInfo.collider == (UnityEngine.Object) other))
      return Vision.SawType.DidntSaw;
    bl_PersonRedirect component1 = other.GetComponent<bl_PersonRedirect>();
    Health component2 = (!((UnityEngine.Object) component1 != (UnityEngine.Object) null) ? (Component) other.transform.root : (Component) component1.RedirectTarget.transform).GetComponent<Health>();
    return (UnityEngine.Object) component2 != (UnityEngine.Object) null && !component2.dead && !component2.Incapacitated ? Vision.SawType.Saw : Vision.SawType.SawbutItsDead;
  }

  public Vision.SawType CanSeePerson(Person person, bool simple = false, bool canSeePlayer = true)
  {
    if (simple)
      return this.RayCastTo(person.ViewCols[0].transform, person.ViewCols[0], LookAtCenter: true, canSeePlayer: canSeePlayer);
    for (int index = 0; index < person.ViewCols.Length; ++index)
    {
      Vision.SawType sawType = this.RayCastTo(person.ViewCols[index].transform, person.ViewCols[index], LookAtCenter: true, canSeePlayer: canSeePlayer);
      if (sawType != Vision.SawType.DidntSaw)
        return sawType;
    }
    return Vision.SawType.DidntSaw;
  }

  public void RestartCol()
  {
    Debug.Log((object) "eyes restart called");
    Collider _col = this.GetComponent<Collider>();
    _col.enabled = false;
    this.CurrentCheck = 1;
    this.CurrentFrame = this.FrameMax;
    Main.RunInNextFrame((Action) (() => _col.enabled = true), 2);
  }

  public void OnCull()
  {
    this.Quality = Vision.VisionQuality.None;
    this.gameObject.SetActive(false);
  }

  public void OnLowLOD()
  {
    this.Quality = Vision.VisionQuality.Low;
    this.gameObject.SetActive(this.Flagger.Count != 0);
  }

  public void OnHighLod()
  {
    this.Quality = Vision.VisionQuality.High;
    this.gameObject.SetActive(this.Flagger.Count != 0);
  }

  public float CalcRoomSize()
  {
    float num1 = 0.0f;
    float num2 = 0.0f;
    float num3 = 0.0f;
    float num4 = 0.0f;
    RaycastHit hitInfo;
    if (Physics.Raycast(this.ThePerson.transform.position + new Vector3(0.0f, 0.25f, 0.0f), this.ThePerson.transform.TransformDirection(Vector3.forward), out hitInfo, 50f, (int) Main.Instance.RoomSizeCheckLayers, QueryTriggerInteraction.Ignore))
      num1 = hitInfo.distance;
    if (Physics.Raycast(this.ThePerson.transform.position + new Vector3(0.0f, 0.25f, 0.0f), this.ThePerson.transform.TransformDirection(Vector3.back), out hitInfo, 50f, (int) Main.Instance.RoomSizeCheckLayers, QueryTriggerInteraction.Ignore))
      num2 = hitInfo.distance;
    if (Physics.Raycast(this.ThePerson.transform.position + new Vector3(0.0f, 0.25f, 0.0f), this.ThePerson.transform.TransformDirection(Vector3.left), out hitInfo, 50f, (int) Main.Instance.RoomSizeCheckLayers, QueryTriggerInteraction.Ignore))
      num3 = hitInfo.distance;
    if (Physics.Raycast(this.ThePerson.transform.position + new Vector3(0.0f, 0.25f, 0.0f), this.ThePerson.transform.TransformDirection(Vector3.right), out hitInfo, 50f, (int) Main.Instance.RoomSizeCheckLayers, QueryTriggerInteraction.Ignore))
      num4 = hitInfo.distance;
    return (float) (((double) (num1 + num2) + (double) (num3 + num4)) / 2.0);
  }

  public enum VisionQuality
  {
    High,
    Low,
    None,
  }

  public enum SawType
  {
    DidntSaw,
    Saw,
    SawbutItsDead,
  }
}
