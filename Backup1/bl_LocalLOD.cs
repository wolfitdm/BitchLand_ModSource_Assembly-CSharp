// Decompiled with JetBrains decompiler
// Type: bl_LocalLOD
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_LocalLOD : MonoBehaviour
{
  public bool Onrn = true;
  public bool AlwaysON;
  public bl_HangZone HangZone;
  public List<GameObject> RenRoots = new List<GameObject>();
  public List<Renderer> Rens = new List<Renderer>();
  public List<Light> Lights = new List<Light>();
  public List<Renderer> SharedRens = new List<Renderer>();
  public bool LimitMaxCamDistance;
  public float MaxCamDistance;
  public int Frames;

  public virtual void Start()
  {
    MeshRenderer component1 = this.GetComponent<MeshRenderer>();
    if ((Object) component1 != (Object) null)
      Object.Destroy((Object) component1);
    MeshFilter component2 = this.GetComponent<MeshFilter>();
    if ((Object) component2 != (Object) null)
      Object.Destroy((Object) component2);
    for (int index1 = 0; index1 < this.RenRoots.Count; ++index1)
    {
      Renderer[] componentsInChildren1 = this.RenRoots[index1].GetComponentsInChildren<Renderer>();
      List<Renderer> rendererList = new List<Renderer>();
      for (int index2 = 0; index2 < componentsInChildren1.Length; ++index2)
      {
        if (componentsInChildren1[index2].renderingLayerMask != 2097152U)
          rendererList.Add(componentsInChildren1[index2]);
      }
      for (int index3 = 0; index3 < rendererList.Count; ++index3)
      {
        if (!this.Rens.Contains(rendererList[index3]))
          this.Rens.Add(rendererList[index3]);
      }
      Light[] componentsInChildren2 = this.RenRoots[index1].GetComponentsInChildren<Light>();
      if (this.Lights == null)
        this.Lights = new List<Light>();
      for (int index4 = 0; index4 < componentsInChildren2.Length; ++index4)
      {
        if (!this.Lights.Contains(componentsInChildren2[index4]))
          this.Lights.Add(componentsInChildren2[index4]);
      }
    }
  }

  public virtual void Show()
  {
    Main.Instance.PlayerCam.farClipPlane = !this.LimitMaxCamDistance ? 400f : this.MaxCamDistance;
    this.Frames = 20;
    if (this.Onrn)
      return;
    this.Onrn = true;
    this.enabled = true;
    int index1 = 0;
    while (index1 < this.Rens.Count)
    {
      if ((Object) this.Rens[index1] != (Object) null)
      {
        this.Rens[index1].enabled = true;
        ++index1;
      }
      else
        this.Rens.RemoveAt(index1);
    }
    int index2 = 0;
    while (index2 < this.Lights.Count)
    {
      if ((Object) this.Lights[index2] != (Object) null)
      {
        this.Lights[index2].enabled = true;
        ++index2;
      }
      else
        this.Lights.RemoveAt(index2);
    }
    this.EnableShared();
  }

  public virtual void Hide()
  {
    if (this.AlwaysON || !this.Onrn || (Object) this.HangZone != (Object) null && this.HangZone.PeopleInZone.Contains(Main.Instance.Player))
      return;
    this.Onrn = false;
    this.enabled = false;
    int index1 = 0;
    while (index1 < this.Rens.Count)
    {
      if ((Object) this.Rens[index1] != (Object) null)
      {
        this.Rens[index1].enabled = false;
        ++index1;
      }
      else
        this.Rens.RemoveAt(index1);
    }
    int index2 = 0;
    while (index2 < this.Lights.Count)
    {
      if ((Object) this.Lights[index2] != (Object) null)
      {
        this.Lights[index2].enabled = false;
        ++index2;
      }
      else
        this.Lights.RemoveAt(index2);
    }
    if (!((Object) Main.Instance.Player.CurrentLocalLOD != (Object) null))
      return;
    Main.Instance.Player.CurrentLocalLOD.EnableShared();
  }

  public virtual void OnTriggerEnter(Collider other)
  {
    Person component = other.transform.root.GetComponent<Person>();
    if (!((Object) component != (Object) null) || !component.IsPlayer)
      return;
    component.CurrentLocalLOD = this;
    this.Show();
    this.AlwaysON = true;
    this.enabled = false;
  }

  public virtual void OnTriggerExit(Collider other)
  {
    Person component = other.transform.root.GetComponent<Person>();
    if (!((Object) component != (Object) null) || !component.IsPlayer)
      return;
    this.AlwaysON = false;
    this.Hide();
  }

  public void FixedUpdate()
  {
    --this.Frames;
    if (this.Frames > 0)
      return;
    this.Frames = 20;
    this.Hide();
  }

  public virtual void EnableShared()
  {
    int index = 0;
    while (index < this.SharedRens.Count)
    {
      if ((Object) this.SharedRens[index] != (Object) null)
      {
        this.SharedRens[index].enabled = true;
        ++index;
      }
      else
        this.SharedRens.RemoveAt(index);
    }
  }
}
