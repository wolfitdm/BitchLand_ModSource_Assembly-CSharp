// Decompiled with JetBrains decompiler
// Type: PlayerBasicCode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class PlayerBasicCode : MonoBehaviour
{
  public Transform playerCamera;
  public float turnSmoothing = 0.06f;
  public float sprintFOV = 100f;
  private float h;
  private float v;
  private int currentBehaviour;
  private int defaultBehaviour;
  private int behaviourLocked;
  private Vector3 lastDirection;
  private Animator anim;
  private ThirdPerson camScript;
  private bool sprint;
  private bool changedFOV;
  private int hFloat;
  private int vFloat;
  private List<GenericBehaviour> behaviours;
  private List<GenericBehaviour> overridingBehaviours;
  private Rigidbody rBody;
  private int groundedBool;
  private Vector3 colExtents;

  public float GetH => this.h;

  public float GetV => this.v;

  public ThirdPerson GetCamScript => this.camScript;

  public Rigidbody GetRigidBody => this.rBody;

  public Animator GetAnim => this.anim;

  public int GetDefaultBehaviour => this.defaultBehaviour;

  private void Awake()
  {
    this.behaviours = new List<GenericBehaviour>();
    this.overridingBehaviours = new List<GenericBehaviour>();
    this.anim = this.GetComponent<Animator>();
    this.hFloat = Animator.StringToHash("H");
    this.vFloat = Animator.StringToHash("V");
    this.camScript = this.playerCamera.GetComponent<ThirdPerson>();
    this.rBody = this.GetComponent<Rigidbody>();
    this.groundedBool = Animator.StringToHash("Grounded");
    this.colExtents = this.GetComponent<Collider>().bounds.extents;
  }

  private void Update()
  {
    this.h = Input.GetAxis("Horizontal");
    this.v = Input.GetAxis("Vertical");
    this.anim.SetFloat(this.hFloat, this.h, 0.1f, Time.deltaTime);
    this.anim.SetFloat(this.vFloat, this.v, 0.1f, Time.deltaTime);
    this.sprint = Input.GetKey(KeyCode.LeftShift);
    if (this.IsSprinting())
    {
      this.changedFOV = true;
      this.camScript.SetFOV(this.sprintFOV);
    }
    else if (this.changedFOV)
    {
      this.camScript.ResetFOV();
      this.changedFOV = false;
    }
    this.anim.SetBool(this.groundedBool, this.IsGrounded());
  }

  private void FixedUpdate()
  {
    bool flag = false;
    if (this.behaviourLocked > 0 || this.overridingBehaviours.Count == 0)
    {
      foreach (GenericBehaviour behaviour in this.behaviours)
      {
        if (behaviour.isActiveAndEnabled && this.currentBehaviour == behaviour.GetBehaviourCode())
        {
          flag = true;
          behaviour.LocalFixedUpdate();
        }
      }
    }
    else
    {
      foreach (GenericBehaviour overridingBehaviour in this.overridingBehaviours)
        overridingBehaviour.LocalFixedUpdate();
    }
    if (flag || this.overridingBehaviours.Count != 0)
      return;
    this.rBody.useGravity = true;
    this.Repositioning();
  }

  private void LateUpdate()
  {
    if (this.behaviourLocked > 0 || this.overridingBehaviours.Count == 0)
    {
      foreach (GenericBehaviour behaviour in this.behaviours)
      {
        if (behaviour.isActiveAndEnabled && this.currentBehaviour == behaviour.GetBehaviourCode())
          behaviour.LocalLateUpdate();
      }
    }
    else
    {
      foreach (GenericBehaviour overridingBehaviour in this.overridingBehaviours)
        overridingBehaviour.LocalLateUpdate();
    }
  }

  public void SubscribeBehaviour(GenericBehaviour behaviour) => this.behaviours.Add(behaviour);

  public void RegisterDefaultBehaviour(int behaviourCode)
  {
    this.defaultBehaviour = behaviourCode;
    this.currentBehaviour = behaviourCode;
  }

  public void RegisterBehaviour(int behaviourCode)
  {
    if (this.currentBehaviour != this.defaultBehaviour)
      return;
    this.currentBehaviour = behaviourCode;
  }

  public void UnregisterBehaviour(int behaviourCode)
  {
    if (this.currentBehaviour != behaviourCode)
      return;
    this.currentBehaviour = this.defaultBehaviour;
  }

  public bool OverrideWithBehaviour(GenericBehaviour behaviour)
  {
    if (this.overridingBehaviours.Contains(behaviour))
      return false;
    if (this.overridingBehaviours.Count == 0)
    {
      foreach (GenericBehaviour behaviour1 in this.behaviours)
      {
        if (behaviour1.isActiveAndEnabled && this.currentBehaviour == behaviour1.GetBehaviourCode())
        {
          behaviour1.OnOverride();
          break;
        }
      }
    }
    this.overridingBehaviours.Add(behaviour);
    return true;
  }

  public bool RevokeOverridingBehaviour(GenericBehaviour behaviour)
  {
    if (!this.overridingBehaviours.Contains(behaviour))
      return false;
    this.overridingBehaviours.Remove(behaviour);
    return true;
  }

  public bool IsOverriding(GenericBehaviour behaviour = null)
  {
    return (Object) behaviour == (Object) null ? this.overridingBehaviours.Count > 0 : this.overridingBehaviours.Contains(behaviour);
  }

  public bool IsCurrentBehaviour(int behaviourCode) => this.currentBehaviour == behaviourCode;

  public bool GetTempLockStatus(int behaviourCodeIgnoreSelf = 0)
  {
    return this.behaviourLocked != 0 && this.behaviourLocked != behaviourCodeIgnoreSelf;
  }

  public void LockTempBehaviour(int behaviourCode)
  {
    if (this.behaviourLocked != 0)
      return;
    this.behaviourLocked = behaviourCode;
  }

  public void UnlockTempBehaviour(int behaviourCode)
  {
    if (this.behaviourLocked != behaviourCode)
      return;
    this.behaviourLocked = 0;
  }

  public virtual bool IsSprinting() => this.sprint && this.IsMoving() && this.CanSprint();

  public bool CanSprint()
  {
    foreach (GenericBehaviour behaviour in this.behaviours)
    {
      if (!behaviour.AllowSprint())
        return false;
    }
    foreach (GenericBehaviour overridingBehaviour in this.overridingBehaviours)
    {
      if (!overridingBehaviour.AllowSprint())
        return false;
    }
    return true;
  }

  public bool IsHorizontalMoving() => (double) this.h != 0.0;

  public bool IsMoving() => (double) this.h != 0.0 || (double) this.v != 0.0;

  public Vector3 GetLastDirection() => this.lastDirection;

  public void SetLastDirection(Vector3 direction) => this.lastDirection = direction;

  public void Repositioning()
  {
    if (!(this.lastDirection != Vector3.zero))
      return;
    this.lastDirection.y = 0.0f;
    this.rBody.MoveRotation(Quaternion.Slerp(this.rBody.rotation, Quaternion.LookRotation(this.lastDirection), this.turnSmoothing));
  }

  public bool IsGrounded()
  {
    return Physics.SphereCast(new Ray(this.transform.position + Vector3.up * 2f * this.colExtents.x, Vector3.down), this.colExtents.x, this.colExtents.x + 0.2f);
  }
}
