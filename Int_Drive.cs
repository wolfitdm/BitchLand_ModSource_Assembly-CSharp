// Decompiled with JetBrains decompiler
// Type: Int_Drive
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Int_Drive : int_Lockable
{
  public Rigidbody MyRigidbody;
  public Transform DropPlace;
  public MonoBehaviour[] CarScripts;
  public GameObject[] CarObjs;
  public GameObject[] Lights;
  public Transform ExitFix;
  public GameObject Engine;
  public MonoBehaviour[] CarTurnedOnScripts;
  public NationMarking CurrentNationMarking;
  public Renderer[] NationMarkings;
  public AudioClip TurnOnSound;
  public Person[] PeopleSeated;
  public Transform[] Seats;
  public string[] SittingAnim;
  public List<GameObject> VisibleNPCs = new List<GameObject>();
  [Header(" --")]
  public AudioSource GlobalAudio;
  public AudioClip[] BreakingSounds;
  public GameObject Wings;
  public float UnFlipTimer;
  public bool PlayerCantLeave;
  public float frameunflipper;
  public bool UndoFlipped;
  public bool Flipped;
  public float UnflipTorque = 5000f;
  public GameObject RunOverTrigger;

  public void SetMarkingsTo(NationMarking newMarkings)
  {
    this.CurrentNationMarking = newMarkings;
    for (int index = 0; index < this.NationMarkings.Length; ++index)
    {
      switch (newMarkings)
      {
        case NationMarking.None:
          this.NationMarkings[index].enabled = false;
          break;
        case NationMarking.BL:
          this.NationMarkings[index].enabled = true;
          this.NationMarkings[index].material.color = new Color(0.792f, 0.376f, 0.431f, 1f);
          this.NationMarkings[index].material.mainTexture = Main.Instance.BL_markings[UnityEngine.Random.Range(0, Main.Instance.BL_markings.Length)];
          break;
        case NationMarking.ESB:
          this.NationMarkings[index].enabled = true;
          this.NationMarkings[index].material.color = new Color(1f, 1f, 1f, 1f);
          this.NationMarkings[index].material.mainTexture = Main.Instance.ESB_markings[UnityEngine.Random.Range(0, Main.Instance.ESB_markings.Length)];
          break;
      }
    }
  }

  public bool EngineOn
  {
    get => this.Engine.activeSelf;
    set
    {
      if (value)
        this.TurnEngineOn();
      else
        this.TurnEngineOff();
    }
  }

  public override void Start()
  {
    base.Start();
    this.enabled = false;
    this.SetMarkingsTo(this.CurrentNationMarking);
  }

  private void Update()
  {
    if (this.IsFlipped())
      this.UnFlip();
    if ((double) this.UnFlipTimer <= 0.0 && this.IsFlipped())
    {
      Main.Instance.GameplayMenu.ShowNotification("Repeatedly tap M to unflip");
      this.UnFlipTimer = 2f;
      this.GlobalAudio.PlayOneShot(this.BreakingSounds[UnityEngine.Random.Range(0, this.BreakingSounds.Length)]);
    }
    this.UnFlipTimer -= Time.deltaTime;
    if (Input.GetKeyUp(KeyCode.M))
      this.UnFlip();
    if (!this.PlayerCantLeave && Input.GetButtonUp("Drop"))
      this.StopInteracting();
    if (Input.GetButtonUp("Interact"))
      this.ToogleLights();
    if (!Input.GetKeyUp(KeyCode.T))
      return;
    this.EngineOn = !this.EngineOn;
  }

  public void ToogleLights()
  {
    for (int index = 0; index < this.Lights.Length; ++index)
      this.Lights[index].SetActive(!this.Lights[index].activeSelf);
  }

  public override void Interact(Person person)
  {
    if (this.Locked)
      return;
    base.Interact(person);
    for (int index = 0; index < this.CarScripts.Length; ++index)
      this.CarScripts[index].enabled = true;
    for (int index = 0; index < this.CarObjs.Length; ++index)
      this.CarObjs[index].SetActive(true);
    if (this.Seats != null && this.Seats.Length > 1)
    {
      this.SitOnSeat(this.InteractingPerson, this.GetAvailableSeat());
    }
    else
    {
      this.InteractingPerson.transform.SetParent(this.transform);
      this.InteractingPerson.gameObject.SetActive(false);
    }
    this.gameObject.SendMessage("OnInteract", SendMessageOptions.DontRequireReceiver);
    if (this.EngineOn)
      return;
    Main.Instance.GameplayMenu.ShowNotification("Press T to toggle engine");
    this.TurnEngineOff();
  }

  public int GetAvailableSeat()
  {
    for (int availableSeat = 0; availableSeat < this.Seats.Length; ++availableSeat)
    {
      if (this.Seats[availableSeat].childCount == 0)
        return availableSeat;
    }
    return 0;
  }

  public void SitOnSeat(Person person, int seat)
  {
    if (!person.IsPlayer)
      person.StopFighting(false);
    person.AddMoveBlocker("InCar");
    person.enabled = false;
    person._Rigidbody.isKinematic = true;
    person.TheHealth.enabled = false;
    person.MainCol.enabled = false;
    this.PeopleSeated[seat] = person;
    if (person.IsPlayer)
    {
      person.UserControl.FirstPerson = false;
      person.UserControl.enabled = false;
      person.UserControl.m_Character.enabled = false;
      person.UserControl.TheCam.gameObject.SetActive(false);
    }
    else
    {
      person.navMesh.enabled = false;
      person.LOD.enabled = false;
      person.SetLowLod();
    }
    person.transform.SetParent(this.Seats[seat]);
    person.transform.position = this.Seats[seat].position;
    person.transform.rotation = this.Seats[seat].rotation;
    person.gameObject.SetActive(false);
    Main.RunInNextFrame((Action) (() =>
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PersonPrefab);
      Person component1 = gameObject.GetComponent<Person>();
      this.VisibleNPCs.Add(gameObject);
      gameObject.name = person.WorldSaveID;
      component1.LOD.enabled = false;
      component1.SetLowLod();
      component1.LOD.enabled = false;
      component1.ProxSeen.gameObject.SetActive(false);
      component1.enabled = false;
      component1.TheHealth.enabled = false;
      component1.navMesh.enabled = false;
      UnityEngine.Object.Destroy((UnityEngine.Object) component1._Rigidbody);
      component1.MainCol.enabled = false;
      component1.transform.SetParent(this.Seats[seat]);
      component1.transform.position = this.Seats[seat].position;
      component1.transform.rotation = this.Seats[seat].rotation;
      for (int index = 0; index < component1.RagdollParts.Length; ++index)
      {
        if ((UnityEngine.Object) component1.RagdollParts[index] != (UnityEngine.Object) null)
        {
          Joint component2 = component1.RagdollParts[index].GetComponent<Joint>();
          if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
            UnityEngine.Object.Destroy((UnityEngine.Object) component2);
          UnityEngine.Object.Destroy((UnityEngine.Object) component1.RagdollParts[index]);
        }
      }
      if (component1 is Girl)
      {
        for (int index = 0; index < (component1 as Girl).PhysicsObjs.Length; ++index)
        {
          Joint component3 = (component1 as Girl).PhysicsObjs[index].GetComponent<Joint>();
          if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
            UnityEngine.Object.Destroy((UnityEngine.Object) component3);
          if ((UnityEngine.Object) (component1 as Girl).PhysicsObjs[index] != (UnityEngine.Object) null)
            UnityEngine.Object.Destroy((UnityEngine.Object) (component1 as Girl).PhysicsObjs[index]);
        }
      }
      component1.Anim.Play(this.SittingAnim[seat]);
      for (int index = 0; index < person.EquippedClothes.Count; ++index)
      {
        try
        {
          component1.DressClothe(person.EquippedClothes[index].OriginalPrefab);
        }
        catch
        {
        }
      }
      component1.NaturalSkinColor = person.NaturalSkinColor;
      component1.NaturalHairColor = person.NaturalHairColor;
      component1.DyedHairColor = person.DyedHairColor;
      component1.RefreshColors();
    }));
  }

  public override void StopInteracting(Person interactingPerson)
  {
    for (int index = 0; index < this.PeopleSeated.Length; ++index)
    {
      if ((UnityEngine.Object) this.PeopleSeated[index] == (UnityEngine.Object) interactingPerson)
      {
        this.PeopleSeated[index] = (Person) null;
        break;
      }
    }
    for (int index = 0; index < this.VisibleNPCs.Count; ++index)
    {
      if (this.VisibleNPCs[index].name == interactingPerson.WorldSaveID)
      {
        GameObject visibleNpC = this.VisibleNPCs[index];
        this.VisibleNPCs.RemoveAt(index);
        UnityEngine.Object.Destroy((UnityEngine.Object) visibleNpC);
        break;
      }
    }
    interactingPerson.RemoveMoveBlocker("InCar");
    interactingPerson.enabled = true;
    interactingPerson.TheHealth.enabled = true;
    interactingPerson.MainCol.enabled = true;
    interactingPerson.transform.SetParent((Transform) null);
    interactingPerson.transform.position = this.DropPlace.position;
    interactingPerson.gameObject.SetActive(true);
    if (interactingPerson.IsPlayer)
    {
      interactingPerson._Rigidbody.isKinematic = false;
      interactingPerson.UserControl.FirstPerson = false;
      interactingPerson.UserControl.enabled = true;
      interactingPerson.UserControl.m_Character.enabled = true;
      interactingPerson.UserControl.TheCam.gameObject.SetActive(true);
    }
    else
    {
      interactingPerson._Rigidbody.isKinematic = true;
      interactingPerson.LOD.enabled = true;
      interactingPerson.navMesh.enabled = true;
    }
    for (int index = 0; index < this.CarScripts.Length; ++index)
      this.CarScripts[index].enabled = false;
    for (int index = 0; index < this.CarObjs.Length; ++index)
      this.CarObjs[index].SetActive(false);
    if ((UnityEngine.Object) this.ExitFix != (UnityEngine.Object) null)
      this.ExitFix.localEulerAngles = new Vector3(0.0f, this.ExitFix.localEulerAngles.y, 0.0f);
    base.StopInteracting(interactingPerson);
  }

  public override void StopInteracting() => this.StopInteracting(this.InteractingPerson);

  public virtual void TurnEngineOff()
  {
    this.Engine.SetActive(false);
    for (int index = 0; index < this.CarTurnedOnScripts.Length; ++index)
      this.CarTurnedOnScripts[index].enabled = false;
  }

  public virtual void TurnEngineOn()
  {
    this.Engine.SetActive(true);
    if ((UnityEngine.Object) this.RunOverTrigger != (UnityEngine.Object) null)
      this.RunOverTrigger.SetActive(true);
    this.Engine.GetComponent<AudioSource>().PlayOneShot(this.TurnOnSound);
    for (int index = 0; index < this.CarTurnedOnScripts.Length; ++index)
      this.CarTurnedOnScripts[index].enabled = true;
  }

  public virtual void StartTroubledEngine()
  {
  }

  public virtual bool IsFlipped()
  {
    this.Flipped = false;
    if ((double) this.transform.localEulerAngles.z > 80.0 && (double) this.transform.localEulerAngles.z < 280.0)
      this.Flipped = true;
    return this.Flipped;
  }

  public virtual bool IsVERYFlipped()
  {
    bool flag = false;
    if ((double) this.transform.localEulerAngles.z > 135.0 && (double) this.transform.localEulerAngles.z < 225.0)
      flag = true;
    return flag;
  }

  public virtual void UnFlip()
  {
    if (this.IsVERYFlipped())
      this.transform.localEulerAngles = new Vector3(0.0f, this.transform.localEulerAngles.y, 0.0f);
    else
      this.GetComponent<Rigidbody>().AddTorque(this.UnflipTorque * Vector3.Cross(this.transform.up, Vector3.up), ForceMode.Impulse);
  }

  public void RunOver(Person person)
  {
    person.TheHealth.ChangeHealth(-999f, true, Main.Instance.Player);
  }
}
