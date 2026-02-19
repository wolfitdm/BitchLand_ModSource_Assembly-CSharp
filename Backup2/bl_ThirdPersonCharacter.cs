// Decompiled with JetBrains decompiler
// Type: bl_ThirdPersonCharacter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

#nullable disable
public class bl_ThirdPersonCharacter : MonoBehaviour
{
  public bl_ThirdPersonCharacter.bl_StandState _StandState;
  public Vector3 DefaultStandingHeight = new Vector3(0.0f, 0.9f, 0.0f);
  public Vector3 UsingStandingHeight = new Vector3(0.0f, 0.9f, 0.0f);
  [SerializeField]
  private float m_MovingTurnSpeed = 360f;
  [SerializeField]
  private float m_StationaryTurnSpeed = 180f;
  [SerializeField]
  private float m_JumpPower = 12f;
  [Range(1f, 4f)]
  [SerializeField]
  private float m_GravityMultiplier = 2f;
  [SerializeField]
  private float m_RunCycleLegOffset = 0.2f;
  [SerializeField]
  private float m_MoveSpeedMultiplier = 1f;
  [SerializeField]
  private float m_AnimSpeedMultiplier = 1f;
  [SerializeField]
  private float m_GroundCheckDistance = 0.1f;
  public Rigidbody m_Rigidbody;
  public Animator m_Animator;
  public bool m_IsGrounded;
  public float m_OrigGroundCheckDistance;
  private const float k_Half = 0.5f;
  public float m_TurnAmount;
  public float m_ForwardAmount;
  public Vector3 m_GroundNormal;
  public float m_CapsuleHeight;
  public Vector3 m_CapsuleCenter;
  public CapsuleCollider m_Capsule;
  public bl_ThirdPersonUserControl PlayerController;
  public float FallingTimer;
  public float FallingTimer_timesTried;

  public bl_ThirdPersonCharacter.bl_StandState StandState
  {
    get => this._StandState;
    set
    {
      this._StandState = value;
      this.m_Animator.SetInteger(nameof (StandState), (int) this._StandState);
      switch (this._StandState)
      {
        case bl_ThirdPersonCharacter.bl_StandState.Standing:
          this.PlayerController.Pivot.localPosition = new Vector3(this.PlayerController.Pivot.localPosition.x, 1.4f, this.PlayerController.Pivot.localPosition.z);
          this.m_Capsule.height = 1.8f;
          this.m_Capsule.center = this.UsingStandingHeight;
          break;
        case bl_ThirdPersonCharacter.bl_StandState.Crouching:
          this.PlayerController.Pivot.localPosition = new Vector3(this.PlayerController.Pivot.localPosition.x, 0.8f, this.PlayerController.Pivot.localPosition.z);
          this.m_Capsule.height = 1f;
          this.m_Capsule.center = new Vector3(0.0f, 0.5f, 0.0f);
          break;
        case bl_ThirdPersonCharacter.bl_StandState.Crawling:
          this.PlayerController.Pivot.localPosition = new Vector3(this.PlayerController.Pivot.localPosition.x, 0.5f, this.PlayerController.Pivot.localPosition.z);
          this.m_Capsule.height = 0.5f;
          this.m_Capsule.center = new Vector3(0.0f, 0.3f, 0.0f);
          break;
      }
    }
  }

  private void Start()
  {
    Application.targetFrameRate = 60;
    this.m_Rigidbody = this.GetComponent<Rigidbody>();
    this.m_Capsule = this.GetComponent<CapsuleCollider>();
    this.m_CapsuleHeight = this.m_Capsule.height;
    this.m_CapsuleCenter = this.m_Capsule.center;
    this.m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    this.m_OrigGroundCheckDistance = this.m_GroundCheckDistance;
  }

  public void Move(Vector3 move, bool jump)
  {
    this.m_Animator.SetBool("Strafe", false);
    if ((double) move.magnitude > 1.0)
      move.Normalize();
    move = this.transform.InverseTransformDirection(move);
    this.CheckGroundStatus();
    move = Vector3.ProjectOnPlane(move, this.m_GroundNormal);
    this.m_TurnAmount = Mathf.Atan2(move.x, move.z);
    this.m_ForwardAmount = move.z;
    this.ApplyExtraTurnRotation();
    if (this.m_IsGrounded)
    {
      this.HandleGroundedMovement(jump);
      if ((Object) Main.Instance.Player.WeaponInv.CurrentWeapon != (Object) null && Main.Instance.Player.WeaponInv.CurrentWeapon.type == WeaponType.Raycast)
        Main.Instance.Player.WeaponInv.CurrentWeapon.SetInRelax();
    }
    else
      this.HandleAirborneMovement();
    this.UpdateAnimator(move);
  }

  public void Move1st(Vector3 move, bool jump)
  {
    this.m_Animator.SetBool("Strafe", true);
    if ((double) move.magnitude > 1.0)
      move.Normalize();
    move = this.transform.InverseTransformDirection(move);
    this.CheckGroundStatus();
    if (this.m_IsGrounded)
    {
      this.HandleGroundedMovement(jump);
      if ((Object) Main.Instance.Player.WeaponInv.CurrentWeapon != (Object) null && Main.Instance.Player.WeaponInv.CurrentWeapon.type == WeaponType.Raycast)
      {
        if ((Main.Instance.Player.UserControl.Aiming || Main.Instance.Player.UserControl.FirstPerson) && this.StandState == bl_ThirdPersonCharacter.bl_StandState.Standing && (double) move.magnitude < 0.30000001192092896)
          Main.Instance.Player.WeaponInv.CurrentWeapon.SetInAiming();
        else
          Main.Instance.Player.WeaponInv.CurrentWeapon.SetInRelax();
      }
    }
    else
      this.HandleAirborneMovement();
    this.UpdateAnimator1st(move);
  }

  private void ScaleCapsuleForCrouching()
  {
  }

  private void PreventStandingInLowHeadroom()
  {
  }

  private void UpdateAnimator(Vector3 move)
  {
    this.m_Animator.SetFloat("Forward", this.m_ForwardAmount, 0.1f, Time.deltaTime);
    this.m_Animator.SetFloat("Turn", this.m_TurnAmount, 0.1f, Time.deltaTime);
    this.m_Animator.SetBool("OnGround", this.m_IsGrounded);
    if (!this.m_IsGrounded)
      this.m_Animator.SetFloat("Jump", this.m_Rigidbody.velocity.y);
    else
      this.m_Animator.SetFloat("Jump", 0.0f);
    float num = ((double) Mathf.Repeat(this.m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + this.m_RunCycleLegOffset, 1f) < 0.5 ? 1f : -1f) * this.m_ForwardAmount;
    if (this.m_IsGrounded)
      this.m_Animator.SetFloat("JumpLeg", num);
    if (this.m_IsGrounded && (double) move.magnitude > 0.0)
      this.m_Animator.speed = this.m_AnimSpeedMultiplier;
    else
      this.m_Animator.speed = 1f;
  }

  private void UpdateAnimator1st(Vector3 move)
  {
    this.m_ForwardAmount = CrossPlatformInputManager.GetAxis("Vertical");
    this.m_TurnAmount = CrossPlatformInputManager.GetAxis("Horizontal");
    if (Input.GetKey(KeyCode.LeftShift))
    {
      this.m_ForwardAmount *= 0.5f;
      this.m_TurnAmount *= 0.5f;
    }
    this.m_Animator.SetFloat("Forward", this.m_ForwardAmount, 0.1f, Time.deltaTime);
    this.m_Animator.SetFloat("Turn", this.m_TurnAmount, 0.1f, Time.deltaTime);
    this.m_Animator.SetBool("OnGround", this.m_IsGrounded);
    if (!this.m_IsGrounded)
      this.m_Animator.SetFloat("Jump", this.m_Rigidbody.velocity.y);
    else
      this.m_Animator.SetFloat("Jump", 0.0f);
    float num = ((double) Mathf.Repeat(this.m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + this.m_RunCycleLegOffset, 1f) < 0.5 ? 1f : -1f) * this.m_ForwardAmount;
    if (this.m_IsGrounded)
      this.m_Animator.SetFloat("JumpLeg", num);
    if (this.m_IsGrounded && (double) move.magnitude > 0.0)
      this.m_Animator.speed = this.m_AnimSpeedMultiplier;
    else
      this.m_Animator.speed = 1f;
  }

  private void HandleAirborneMovement()
  {
    this.FallingTimer += Time.deltaTime;
    if ((double) this.FallingTimer > 3.0)
    {
      this.FallingTimer = 0.0f;
      Main.Instance.Player.UserControl.UnstuckPlayer();
    }
    else
    {
      this.m_Rigidbody.AddForce(Physics.gravity * this.m_GravityMultiplier - Physics.gravity);
      this.m_GroundCheckDistance = (double) this.m_Rigidbody.velocity.y < 0.0 ? this.m_OrigGroundCheckDistance : 0.01f;
    }
  }

  private void HandleGroundedMovement(bool jump)
  {
    this.FallingTimer = 0.0f;
    if (!jump)
      return;
    this.m_Rigidbody.velocity = new Vector3(this.m_Rigidbody.velocity.x, this.m_JumpPower, this.m_Rigidbody.velocity.z);
    this.m_IsGrounded = false;
    this.m_Animator.applyRootMotion = false;
    this.m_GroundCheckDistance = 0.1f;
  }

  private void ApplyExtraTurnRotation()
  {
    this.transform.Rotate(0.0f, this.m_TurnAmount * Mathf.Lerp(this.m_StationaryTurnSpeed, this.m_MovingTurnSpeed, this.m_ForwardAmount) * Time.deltaTime, 0.0f);
  }

  public void OnAnimatorMove()
  {
    if (!this.m_IsGrounded || (double) Time.deltaTime <= 0.0)
      return;
    this.m_Rigidbody.velocity = (this.m_Animator.deltaPosition * this.m_MoveSpeedMultiplier / Time.deltaTime) with
    {
      y = this.m_Rigidbody.velocity.y
    };
  }

  private void CheckGroundStatus()
  {
    RaycastHit hitInfo;
    if (Physics.Raycast(this.transform.position + Vector3.up * 0.1f, Vector3.down, out hitInfo, this.m_GroundCheckDistance))
    {
      this.m_GroundNormal = hitInfo.normal;
      this.m_IsGrounded = true;
      this.m_Animator.applyRootMotion = true;
    }
    else
    {
      this.m_IsGrounded = false;
      this.m_GroundNormal = Vector3.up;
      this.m_Animator.applyRootMotion = false;
    }
  }

  public enum bl_StandState
  {
    Standing,
    Crouching,
    Crawling,
    Falling,
    NoMovement,
    Other1,
    MAX,
  }
}
