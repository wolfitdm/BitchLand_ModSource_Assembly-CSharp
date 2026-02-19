// Decompiled with JetBrains decompiler
// Type: PlayerMoveCode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PlayerMoveCode : GenericBehaviour
{
  public float walkSpeed = 0.15f;
  public float runSpeed = 1f;
  public float sprintSpeed = 2f;
  public float speedDampTime = 0.1f;
  public float jumpHeight = 1.5f;
  public float jumpIntertialForce = 10f;
  private float speed;
  private float speedSeeker;
  private int jumpBool;
  private int groundedBool;
  private bool jump;
  private bool isColliding;
  public bool isLock;

  private void Start()
  {
    this.jumpBool = Animator.StringToHash("Jump");
    this.groundedBool = Animator.StringToHash("Grounded");
    this.behaviourManager.GetAnim.SetBool(this.groundedBool, true);
    this.behaviourManager.SubscribeBehaviour((GenericBehaviour) this);
    this.behaviourManager.RegisterDefaultBehaviour(this.behaviourCode);
    this.speedSeeker = this.runSpeed;
    Time.timeScale = 1f;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  private void Update()
  {
    if (!this.jump && Input.GetKeyDown(KeyCode.Space) && this.behaviourManager.IsCurrentBehaviour(this.behaviourCode) && !this.behaviourManager.IsOverriding())
      this.jump = true;
    if (!Input.GetKeyDown(KeyCode.Escape))
      return;
    this.isLock = !this.isLock;
    if (this.isLock)
    {
      Time.timeScale = 0.0f;
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }
    else
    {
      Time.timeScale = 1f;
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
  }

  public override void LocalFixedUpdate()
  {
    this.MovementManagement(this.behaviourManager.GetH, this.behaviourManager.GetV);
    this.JumpManagement();
  }

  private void JumpManagement()
  {
    if (this.jump && !this.behaviourManager.GetAnim.GetBool(this.jumpBool) && this.behaviourManager.IsGrounded())
    {
      this.behaviourManager.LockTempBehaviour(this.behaviourCode);
      this.behaviourManager.GetAnim.SetBool(this.jumpBool, true);
      if ((double) this.behaviourManager.GetAnim.GetFloat(this.speedFloat) <= 0.1)
        return;
      this.GetComponent<CapsuleCollider>().material.dynamicFriction = 0.0f;
      this.GetComponent<CapsuleCollider>().material.staticFriction = 0.0f;
      this.RemoveVerticalVelocity();
      this.behaviourManager.GetRigidBody.AddForce(Vector3.up * Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y) * this.jumpHeight), ForceMode.VelocityChange);
    }
    else
    {
      if (!this.behaviourManager.GetAnim.GetBool(this.jumpBool))
        return;
      if (!this.behaviourManager.IsGrounded() && !this.isColliding && this.behaviourManager.GetTempLockStatus())
        this.behaviourManager.GetRigidBody.AddForce(this.transform.forward * this.jumpIntertialForce * Physics.gravity.magnitude * this.sprintSpeed, ForceMode.Acceleration);
      if ((double) this.behaviourManager.GetRigidBody.velocity.y >= 0.0 || !this.behaviourManager.IsGrounded())
        return;
      this.behaviourManager.GetAnim.SetBool(this.groundedBool, true);
      this.GetComponent<CapsuleCollider>().material.dynamicFriction = 0.6f;
      this.GetComponent<CapsuleCollider>().material.staticFriction = 0.6f;
      this.jump = false;
      this.behaviourManager.GetAnim.SetBool(this.jumpBool, false);
      this.behaviourManager.UnlockTempBehaviour(this.behaviourCode);
    }
  }

  private void MovementManagement(float horizontal, float vertical)
  {
    if (this.behaviourManager.IsGrounded())
      this.behaviourManager.GetRigidBody.useGravity = true;
    else if (!this.behaviourManager.GetAnim.GetBool(this.jumpBool) && (double) this.behaviourManager.GetRigidBody.velocity.y > 0.0)
      this.RemoveVerticalVelocity();
    this.Rotating(horizontal, vertical);
    this.speed = Vector2.ClampMagnitude(new Vector2(horizontal, vertical), 1f).magnitude;
    this.speedSeeker += Input.GetAxis("Mouse ScrollWheel");
    this.speedSeeker = Mathf.Clamp(this.speedSeeker, this.walkSpeed, this.runSpeed);
    this.speed *= this.speedSeeker;
    if (this.behaviourManager.IsSprinting())
      this.speed = this.sprintSpeed;
    this.behaviourManager.GetAnim.SetFloat(this.speedFloat, this.speed, this.speedDampTime, Time.deltaTime);
  }

  private void RemoveVerticalVelocity()
  {
    this.behaviourManager.GetRigidBody.velocity = this.behaviourManager.GetRigidBody.velocity with
    {
      y = 0.0f
    };
  }

  private Vector3 Rotating(float horizontal, float vertical)
  {
    Vector3 vector3_1 = this.behaviourManager.playerCamera.TransformDirection(Vector3.forward) with
    {
      y = 0.0f
    };
    vector3_1 = vector3_1.normalized;
    Vector3 vector3_2 = new Vector3(vector3_1.z, 0.0f, -vector3_1.x);
    Vector3 vector3_3 = vector3_1 * vertical + vector3_2 * horizontal;
    if (this.behaviourManager.IsMoving() && vector3_3 != Vector3.zero)
    {
      this.behaviourManager.GetRigidBody.MoveRotation(Quaternion.Slerp(this.behaviourManager.GetRigidBody.rotation, Quaternion.LookRotation(vector3_3), this.behaviourManager.turnSmoothing));
      this.behaviourManager.SetLastDirection(vector3_3);
    }
    if ((double) Mathf.Abs(horizontal) <= 0.9 && (double) Mathf.Abs(vertical) <= 0.9)
      this.behaviourManager.Repositioning();
    return vector3_3;
  }

  private void OnCollisionStay(Collision collision)
  {
    this.isColliding = true;
    if (!this.behaviourManager.IsCurrentBehaviour(this.GetBehaviourCode()) || (double) collision.GetContact(0).normal.y > 0.10000000149011612)
      return;
    this.GetComponent<CapsuleCollider>().material.dynamicFriction = 0.0f;
    this.GetComponent<CapsuleCollider>().material.staticFriction = 0.0f;
  }

  private void OnCollisionExit(Collision collision)
  {
    this.isColliding = false;
    this.GetComponent<CapsuleCollider>().material.dynamicFriction = 0.6f;
    this.GetComponent<CapsuleCollider>().material.staticFriction = 0.6f;
  }
}
