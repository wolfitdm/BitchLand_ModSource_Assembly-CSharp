// Decompiled with JetBrains decompiler
// Type: FirstPersonAIO
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
[AddComponentMenu("First Person AIO")]
public class FirstPersonAIO : MonoBehaviour
{
  public bool controllerPauseState;
  public bool enableCameraMovement = true;
  public FirstPersonAIO.InvertMouseInput mouseInputInversion;
  public FirstPersonAIO.CameraInputMethod cameraInputMethod;
  public float verticalRotationRange = 170f;
  public float mouseSensitivity = 10f;
  public float fOVToMouseSensitivity = 1f;
  public float cameraSmoothing = 5f;
  public bool lockAndHideCursor;
  public Camera playerCamera;
  public bool enableCameraShake;
  internal Vector3 cameraStartingPosition;
  private float baseCamFOV;
  public bool autoCrosshair;
  public bool drawStaminaMeter = true;
  private float smoothRef;
  private Image StaminaMeter;
  private Image StaminaMeterBG;
  public Sprite Crosshair;
  public Vector3 targetAngles;
  private Vector3 followAngles;
  private Vector3 followVelocity;
  private Vector3 originalRotation;
  public bool playerCanMove = true;
  public bool walkByDefault = true;
  public float walkSpeed = 4f;
  public KeyCode sprintKey = KeyCode.LeftShift;
  public float sprintSpeed = 8f;
  public float jumpPower = 5f;
  public bool canJump = true;
  public bool canHoldJump;
  private bool jumpInput;
  private bool didJump;
  public bool useStamina = true;
  public float staminaDepletionSpeed = 5f;
  public float staminaLevel = 50f;
  public float speed;
  public float staminaInternal;
  internal float walkSpeedInternal;
  internal float sprintSpeedInternal;
  internal float jumpPowerInternal;
  public FirstPersonAIO.CrouchModifiers _crouchModifiers = new FirstPersonAIO.CrouchModifiers();
  public FirstPersonAIO.AdvancedSettings advanced = new FirstPersonAIO.AdvancedSettings();
  private CapsuleCollider capsule;
  private Vector2 inputXY;
  public bool isCrouching;
  private float yVelocity;
  private float checkedSlope;
  private bool isSprinting;
  public Rigidbody fps_Rigidbody;
  public bool useHeadbob = true;
  public Transform head;
  public bool snapHeadjointToCapsul = true;
  public float headbobFrequency = 1.5f;
  public float headbobSwayAngle = 5f;
  public float headbobHeight = 3f;
  public float headbobSideMovement = 5f;
  public float jumpLandIntensity = 3f;
  private Vector3 originalLocalPosition;
  private float nextStepTime = 0.5f;
  private float headbobCycle;
  private float headbobFade;
  private float springPosition;
  private float springVelocity;
  private float springElastic = 1.1f;
  private float springDampen = 0.8f;
  private float springVelocityThreshold = 0.05f;
  private float springPositionThreshold = 0.05f;
  private Vector3 previousPosition;
  private Vector3 previousVelocity = Vector3.zero;
  private Vector3 miscRefVel;
  private bool previousGrounded;
  private AudioSource audioSource;
  public bool enableAudioSFX = true;
  public float Volume = 5f;
  public AudioClip jumpSound;
  public AudioClip landSound;
  public List<AudioClip> footStepSounds;
  public FirstPersonAIO.FSMode fsmode;
  public FirstPersonAIO.DynamicFootStep dynamicFootstep = new FirstPersonAIO.DynamicFootStep();

  public bool IsGrounded { get; private set; }

  private void Awake()
  {
    this.originalRotation = this.transform.localRotation.eulerAngles;
    this.walkSpeedInternal = this.walkSpeed;
    this.sprintSpeedInternal = this.sprintSpeed;
    this.jumpPowerInternal = this.jumpPower;
    this.capsule = this.GetComponent<CapsuleCollider>();
    this.IsGrounded = true;
    this.isCrouching = false;
    this.fps_Rigidbody = this.GetComponent<Rigidbody>();
    this.fps_Rigidbody.interpolation = RigidbodyInterpolation.Extrapolate;
    this.fps_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
    this._crouchModifiers.colliderHeight = this.capsule.height;
  }

  private void Start()
  {
    if (this.autoCrosshair || this.drawStaminaMeter)
    {
      Canvas canvas = new GameObject("AutoCrosshair").AddComponent<Canvas>();
      canvas.gameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
      canvas.renderMode = RenderMode.ScreenSpaceOverlay;
      canvas.pixelPerfect = true;
      canvas.transform.SetParent(this.playerCamera.transform);
      canvas.transform.position = Vector3.zero;
      if (this.autoCrosshair)
      {
        Image image = new GameObject("Crosshair").AddComponent<Image>();
        image.sprite = this.Crosshair;
        image.rectTransform.sizeDelta = new Vector2(25f, 25f);
        image.transform.SetParent(canvas.transform);
        image.transform.position = Vector3.zero;
      }
      if (this.drawStaminaMeter)
      {
        this.StaminaMeterBG = new GameObject("StaminaMeter").AddComponent<Image>();
        this.StaminaMeter = new GameObject("Meter").AddComponent<Image>();
        this.StaminaMeter.transform.SetParent(this.StaminaMeterBG.transform);
        this.StaminaMeterBG.transform.SetParent(canvas.transform);
        this.StaminaMeterBG.transform.position = Vector3.zero;
        this.StaminaMeterBG.rectTransform.anchorMax = new Vector2(0.5f, 0.0f);
        this.StaminaMeterBG.rectTransform.anchorMin = new Vector2(0.5f, 0.0f);
        this.StaminaMeterBG.rectTransform.anchoredPosition = new Vector2(0.0f, 15f);
        this.StaminaMeterBG.rectTransform.sizeDelta = new Vector2(250f, 6f);
        this.StaminaMeterBG.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        this.StaminaMeter.rectTransform.sizeDelta = new Vector2(250f, 6f);
        this.StaminaMeter.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      }
    }
    this.cameraStartingPosition = this.playerCamera.transform.localPosition;
    if (this.lockAndHideCursor)
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
    this.baseCamFOV = this.playerCamera.fieldOfView;
    this.capsule.radius = this.capsule.height / 4f;
    this.staminaInternal = this.staminaLevel;
    this.advanced.zeroFrictionMaterial = new PhysicMaterial("Zero_Friction");
    this.advanced.zeroFrictionMaterial.dynamicFriction = 0.0f;
    this.advanced.zeroFrictionMaterial.staticFriction = 0.0f;
    this.advanced.zeroFrictionMaterial.frictionCombine = PhysicMaterialCombine.Minimum;
    this.advanced.zeroFrictionMaterial.bounceCombine = PhysicMaterialCombine.Minimum;
    this.advanced.highFrictionMaterial = new PhysicMaterial("Max_Friction");
    this.advanced.highFrictionMaterial.dynamicFriction = 1f;
    this.advanced.highFrictionMaterial.staticFriction = 1f;
    this.advanced.highFrictionMaterial.frictionCombine = PhysicMaterialCombine.Maximum;
    this.advanced.highFrictionMaterial.bounceCombine = PhysicMaterialCombine.Average;
    this.originalLocalPosition = this.snapHeadjointToCapsul ? new Vector3(this.head.localPosition.x, this.capsule.height / 2f * this.head.localScale.y, this.head.localPosition.z) : this.head.localPosition;
    if ((UnityEngine.Object) this.GetComponent<AudioSource>() == (UnityEngine.Object) null)
      this.gameObject.AddComponent<AudioSource>();
    this.previousPosition = this.fps_Rigidbody.position;
    this.audioSource = this.GetComponent<AudioSource>();
  }

  private void Update()
  {
    if (this.enableCameraMovement && !this.controllerPauseState)
    {
      float num1 = 0.0f;
      float fieldOfView = this.playerCamera.fieldOfView;
      float num2;
      if (this.cameraInputMethod == FirstPersonAIO.CameraInputMethod.Traditional || this.cameraInputMethod == FirstPersonAIO.CameraInputMethod.TraditionalWithConstraints)
      {
        num1 = this.mouseInputInversion == FirstPersonAIO.InvertMouseInput.None || this.mouseInputInversion == FirstPersonAIO.InvertMouseInput.X ? Input.GetAxis("Mouse Y") : -Input.GetAxis("Mouse Y");
        num2 = this.mouseInputInversion == FirstPersonAIO.InvertMouseInput.None || this.mouseInputInversion == FirstPersonAIO.InvertMouseInput.Y ? Input.GetAxis("Mouse X") : -Input.GetAxis("Mouse X");
      }
      else
        num2 = Input.GetAxis("Horizontal") * (this.mouseInputInversion == FirstPersonAIO.InvertMouseInput.None || this.mouseInputInversion == FirstPersonAIO.InvertMouseInput.Y ? 1f : -1f);
      if ((double) this.targetAngles.y > 180.0)
      {
        this.targetAngles.y -= 360f;
        this.followAngles.y -= 360f;
      }
      else if ((double) this.targetAngles.y < -180.0)
      {
        this.targetAngles.y += 360f;
        this.followAngles.y += 360f;
      }
      if ((double) this.targetAngles.x > 180.0)
      {
        this.targetAngles.x -= 360f;
        this.followAngles.x -= 360f;
      }
      else if ((double) this.targetAngles.x < -180.0)
      {
        this.targetAngles.x += 360f;
        this.followAngles.x += 360f;
      }
      this.targetAngles.y += num2 * (this.mouseSensitivity - (float) (((double) this.baseCamFOV - (double) fieldOfView) * (double) this.fOVToMouseSensitivity / 6.0));
      if (this.cameraInputMethod == FirstPersonAIO.CameraInputMethod.Traditional)
        this.targetAngles.x += num1 * (this.mouseSensitivity - (float) (((double) this.baseCamFOV - (double) fieldOfView) * (double) this.fOVToMouseSensitivity / 6.0));
      else
        this.targetAngles.x = 0.0f;
      this.targetAngles.x = Mathf.Clamp(this.targetAngles.x, -0.5f * this.verticalRotationRange, 0.5f * this.verticalRotationRange);
      this.followAngles = Vector3.SmoothDamp(this.followAngles, this.targetAngles, ref this.followVelocity, this.cameraSmoothing / 100f);
      this.playerCamera.transform.localRotation = Quaternion.Euler(-this.followAngles.x + this.originalRotation.x, 0.0f, 0.0f);
      this.transform.localRotation = Quaternion.Euler(0.0f, this.followAngles.y + this.originalRotation.y, 0.0f);
    }
    if ((this.canHoldJump ? (!this.canJump ? 0 : (Input.GetButton("Jump") ? 1 : 0)) : (!Input.GetButtonDown("Jump") ? 0 : (this.canJump ? 1 : 0))) != 0)
      this.jumpInput = true;
    else if (Input.GetButtonUp("Jump"))
      this.jumpInput = false;
    if (this._crouchModifiers.useCrouch)
    {
      if (!this._crouchModifiers.toggleCrouch)
        this.isCrouching = this._crouchModifiers.crouchOverride || Input.GetKey(this._crouchModifiers.crouchKey);
      else if (Input.GetKeyDown(this._crouchModifiers.crouchKey))
        this.isCrouching = !this.isCrouching || this._crouchModifiers.crouchOverride;
    }
    if (!Input.GetButtonDown("Cancel"))
      return;
    this.ControllerPause();
  }

  private void FixedUpdate()
  {
    if (this.useStamina)
    {
      this.isSprinting = Input.GetKey(this.sprintKey) && !this.isCrouching && (double) this.staminaInternal > 0.0 && ((double) Mathf.Abs(this.fps_Rigidbody.velocity.x) > 0.0099999997764825821 || (double) Mathf.Abs(this.fps_Rigidbody.velocity.z) > 0.0099999997764825821);
      if (this.isSprinting)
      {
        this.staminaInternal -= this.staminaDepletionSpeed * 2f * Time.deltaTime;
        if (this.drawStaminaMeter)
        {
          this.StaminaMeterBG.color = (Color) Vector4.MoveTowards((Vector4) this.StaminaMeterBG.color, new Vector4(0.0f, 0.0f, 0.0f, 0.5f), 0.15f);
          this.StaminaMeter.color = (Color) Vector4.MoveTowards((Vector4) this.StaminaMeter.color, new Vector4(1f, 1f, 1f, 1f), 0.15f);
        }
      }
      else if ((!Input.GetKey(this.sprintKey) || (double) Mathf.Abs(this.fps_Rigidbody.velocity.x) < 0.0099999997764825821 || (double) Mathf.Abs(this.fps_Rigidbody.velocity.z) < 0.0099999997764825821 || this.isCrouching) && (double) this.staminaInternal < (double) this.staminaLevel)
        this.staminaInternal += this.staminaDepletionSpeed * Time.deltaTime;
      if (this.drawStaminaMeter)
      {
        if ((double) this.staminaInternal == (double) this.staminaLevel)
        {
          this.StaminaMeterBG.color = (Color) Vector4.MoveTowards((Vector4) this.StaminaMeterBG.color, new Vector4(0.0f, 0.0f, 0.0f, 0.0f), 0.15f);
          this.StaminaMeter.color = (Color) Vector4.MoveTowards((Vector4) this.StaminaMeter.color, new Vector4(1f, 1f, 1f, 0.0f), 0.15f);
        }
        this.StaminaMeter.transform.localScale = new Vector3(Mathf.Clamp(Mathf.SmoothDamp(this.StaminaMeter.transform.localScale.x, this.staminaInternal / this.staminaLevel * this.StaminaMeterBG.transform.localScale.x, ref this.smoothRef, 1f * Time.deltaTime, 1f), 1f / 1000f, this.StaminaMeterBG.transform.localScale.x), 1f, 1f);
      }
      this.staminaInternal = Mathf.Clamp(this.staminaInternal, 0.0f, this.staminaLevel);
    }
    else
      this.isSprinting = Input.GetKey(this.sprintKey);
    Vector3 vector3_1 = Vector3.zero;
    this.speed = this.walkByDefault ? (this.isCrouching ? this.walkSpeedInternal : (this.isSprinting ? this.sprintSpeedInternal : this.walkSpeedInternal)) : (this.isSprinting ? this.walkSpeedInternal : this.sprintSpeedInternal);
    if ((double) this.advanced.maxSlopeAngle > 0.0)
    {
      if (this.advanced.isTouchingUpright && this.advanced.isTouchingWalkable)
      {
        vector3_1 = this.transform.forward * this.inputXY.y * this.speed + this.transform.right * this.inputXY.x * this.walkSpeedInternal;
        if (!this.didJump)
          this.fps_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
      }
      else if (this.advanced.isTouchingUpright && !this.advanced.isTouchingWalkable)
      {
        this.fps_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
      }
      else
      {
        this.fps_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        vector3_1 = (this.transform.forward * this.inputXY.y * this.speed + this.transform.right * this.inputXY.x * this.walkSpeedInternal) * ((double) this.fps_Rigidbody.velocity.y > 0.0099999997764825821 ? this.SlopeCheck() : 0.8f);
      }
    }
    else
      vector3_1 = this.transform.forward * this.inputXY.y * this.speed + this.transform.right * this.inputXY.x * this.walkSpeedInternal;
    RaycastHit hitInfo1;
    if ((double) this.advanced.maxStepHeight > 0.0 && Physics.Raycast(this.transform.position - new Vector3(0.0f, (float) ((double) this.capsule.height / 2.0 * (double) this.transform.localScale.y - 0.0099999997764825821), 0.0f), vector3_1, out hitInfo1, this.capsule.radius + 0.15f, -1, QueryTriggerInteraction.Ignore) && (double) Vector3.Angle(hitInfo1.normal, Vector3.up) > 88.0 && !Physics.Raycast(this.transform.position - new Vector3(0.0f, this.capsule.height / 2f * this.transform.localScale.y - this.advanced.maxStepHeight, 0.0f), vector3_1, out RaycastHit _, this.capsule.radius + 0.25f, -1, QueryTriggerInteraction.Ignore))
    {
      this.advanced.stairMiniHop = true;
      this.transform.position += new Vector3(0.0f, this.advanced.maxStepHeight * 1.2f, 0.0f);
    }
    Debug.DrawRay(this.transform.position, vector3_1, Color.red, 0.0f, false);
    this.inputXY = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    if ((double) this.inputXY.magnitude > 1.0)
      this.inputXY.Normalize();
    this.yVelocity = this.fps_Rigidbody.velocity.y;
    if (this.IsGrounded && this.jumpInput && (double) this.jumpPowerInternal > 0.0 && !this.didJump)
    {
      if ((double) this.advanced.maxSlopeAngle > 0.0)
      {
        if (this.advanced.isTouchingFlat || this.advanced.isTouchingWalkable)
        {
          this.didJump = true;
          this.jumpInput = false;
          this.yVelocity += (double) this.fps_Rigidbody.velocity.y < 0.0099999997764825821 ? this.jumpPowerInternal : this.jumpPowerInternal / 3f;
          this.advanced.isTouchingWalkable = false;
          this.advanced.isTouchingFlat = false;
          this.advanced.isTouchingUpright = false;
          this.fps_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
      }
      else
      {
        this.didJump = true;
        this.jumpInput = false;
        this.yVelocity += this.jumpPowerInternal;
      }
    }
    if ((double) this.advanced.maxSlopeAngle > 0.0)
    {
      if (!this.didJump && (double) this.advanced.lastKnownSlopeAngle > 5.0 && this.advanced.isTouchingWalkable)
        this.yVelocity *= this.SlopeCheck() / 4f;
      if (this.advanced.isTouchingUpright && !this.advanced.isTouchingWalkable && !this.didJump)
        this.yVelocity += Physics.gravity.y;
    }
    this.fps_Rigidbody.velocity = !this.playerCanMove || this.controllerPauseState ? Vector3.zero : vector3_1 + Vector3.up * this.yVelocity;
    if ((double) this.inputXY.magnitude > 0.0 || !this.IsGrounded)
      this.capsule.sharedMaterial = this.advanced.zeroFrictionMaterial;
    else
      this.capsule.sharedMaterial = this.advanced.highFrictionMaterial;
    this.fps_Rigidbody.AddForce(Physics.gravity * (this.advanced.gravityMultiplier - 1f));
    if ((double) this.advanced.FOVKickAmount > 0.0)
    {
      if (this.isSprinting && !this.isCrouching && (double) this.playerCamera.fieldOfView != (double) this.baseCamFOV + (double) this.advanced.FOVKickAmount * 2.0 - 0.0099999997764825821)
      {
        if ((double) Mathf.Abs(this.fps_Rigidbody.velocity.x) > 0.5 || (double) Mathf.Abs(this.fps_Rigidbody.velocity.z) > 0.5)
          this.playerCamera.fieldOfView = Mathf.SmoothDamp(this.playerCamera.fieldOfView, this.baseCamFOV + this.advanced.FOVKickAmount * 2f, ref this.advanced.fovRef, this.advanced.changeTime);
      }
      else if ((double) this.playerCamera.fieldOfView != (double) this.baseCamFOV)
        this.playerCamera.fieldOfView = Mathf.SmoothDamp(this.playerCamera.fieldOfView, this.baseCamFOV, ref this.advanced.fovRef, this.advanced.changeTime * 0.5f);
    }
    if (this._crouchModifiers.useCrouch)
    {
      if (this.isCrouching)
      {
        this.capsule.height = Mathf.MoveTowards(this.capsule.height, this._crouchModifiers.colliderHeight / 1.5f, 5f * Time.deltaTime);
        this.walkSpeedInternal = this.walkSpeed * this._crouchModifiers.crouchWalkSpeedMultiplier;
        this.jumpPowerInternal = this.jumpPower * this._crouchModifiers.crouchJumpPowerMultiplier;
      }
      else
      {
        this.capsule.height = Mathf.MoveTowards(this.capsule.height, this._crouchModifiers.colliderHeight, 5f * Time.deltaTime);
        this.walkSpeedInternal = this.walkSpeed;
        this.sprintSpeedInternal = this.sprintSpeed;
        this.jumpPowerInternal = this.jumpPower;
      }
    }
    float y = 0.0f;
    float x1 = 0.0f;
    float z = 0.0f;
    float x2 = 0.0f;
    Vector3 vector3_2;
    if (this.useHeadbob || this.enableAudioSFX)
    {
      Vector3 vector3_3 = (this.fps_Rigidbody.position - this.previousPosition) / Time.deltaTime;
      Vector3 vector3_4 = vector3_3 - this.previousVelocity;
      this.previousPosition = this.fps_Rigidbody.position;
      this.previousVelocity = vector3_3;
      this.springVelocity -= vector3_4.y;
      this.springVelocity -= this.springPosition * this.springElastic;
      this.springVelocity *= this.springDampen;
      this.springPosition += this.springVelocity * Time.deltaTime;
      this.springPosition = Mathf.Clamp(this.springPosition, -0.3f, 0.3f);
      if ((double) Mathf.Abs(this.springVelocity) < (double) this.springVelocityThreshold && (double) Mathf.Abs(this.springPosition) < (double) this.springPositionThreshold)
      {
        this.springPosition = 0.0f;
        this.springVelocity = 0.0f;
      }
      vector3_2 = new Vector3(vector3_3.x, 0.0f, vector3_3.z);
      float magnitude = vector3_2.magnitude;
      float num1 = (float) (1.0 + (double) magnitude * ((double) this.headbobFrequency * 2.0 / 10.0));
      this.headbobCycle += (float) ((double) magnitude / (double) num1 * ((double) Time.deltaTime / (double) this.headbobFrequency));
      float num2 = Mathf.Sin((float) ((double) this.headbobCycle * 3.1415927410125732 * 2.0));
      float num3 = Mathf.Sin((float) (3.1415927410125732 * (2.0 * (double) this.headbobCycle + 0.5)));
      float num4 = (float) (1.0 - ((double) num2 * 0.5 + 1.0));
      float num5 = num4 * num4;
      y = 0.0f;
      x1 = 0.0f;
      z = 0.0f;
      if ((double) this.jumpLandIntensity > 0.0 && !this.advanced.stairMiniHop)
        x2 = (float) (-(double) this.springPosition * ((double) this.jumpLandIntensity * 5.5));
      else if (!this.advanced.stairMiniHop)
        x2 = -this.springPosition;
      if (this.IsGrounded)
      {
        vector3_2 = new Vector3(vector3_3.x, 0.0f, vector3_3.z);
        this.headbobFade = (double) vector3_2.magnitude >= 0.10000000149011612 ? Mathf.MoveTowards(this.headbobFade, 1f, Time.deltaTime) : Mathf.MoveTowards(this.headbobFade, 0.0f, 0.5f);
        float num6 = (float) (1.0 + (double) magnitude * 0.30000001192092896);
        x1 = (float) -((double) this.headbobSideMovement / 10.0) * this.headbobFade * num3;
        y = (float) ((double) this.springPosition * ((double) this.jumpLandIntensity / 10.0) + (double) num5 * ((double) this.headbobHeight / 10.0) * (double) this.headbobFade * (double) num6);
        z = num3 * (this.headbobSwayAngle / 10f) * this.headbobFade;
      }
    }
    if (this.useHeadbob)
    {
      vector3_2 = this.fps_Rigidbody.velocity;
      this.head.localPosition = (double) vector3_2.magnitude <= 0.10000000149011612 ? Vector3.SmoothDamp(this.head.localPosition, this.snapHeadjointToCapsul ? new Vector3(this.originalLocalPosition.x, this.capsule.height / 2f * this.head.localScale.y, this.originalLocalPosition.z) + new Vector3(x1, y, 0.0f) : this.originalLocalPosition + new Vector3(x1, y, 0.0f), ref this.miscRefVel, 0.15f) : Vector3.MoveTowards(this.head.localPosition, this.snapHeadjointToCapsul ? new Vector3(this.originalLocalPosition.x, this.capsule.height / 2f * this.head.localScale.y, this.originalLocalPosition.z) + new Vector3(x1, y, 0.0f) : this.originalLocalPosition + new Vector3(x1, y, 0.0f), 0.5f);
      this.head.localRotation = Quaternion.Euler(x2, 0.0f, z);
    }
    if (this.enableAudioSFX)
    {
      if (this.fsmode == FirstPersonAIO.FSMode.Dynamic)
      {
        RaycastHit hitInfo2 = new RaycastHit();
        if (Physics.Raycast(this.transform.position, Vector3.down, out hitInfo2))
        {
          if (this.dynamicFootstep.materialMode == FirstPersonAIO.DynamicFootStep.matMode.physicMaterial)
            this.dynamicFootstep.currentClipSet = !this.dynamicFootstep.woodPhysMat.Any<PhysicMaterial>() || !this.dynamicFootstep.woodPhysMat.Contains(hitInfo2.collider.sharedMaterial) || !this.dynamicFootstep.woodClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.grassPhysMat.Any<PhysicMaterial>() || !this.dynamicFootstep.grassPhysMat.Contains(hitInfo2.collider.sharedMaterial) || !this.dynamicFootstep.grassClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.metalAndGlassPhysMat.Any<PhysicMaterial>() || !this.dynamicFootstep.metalAndGlassPhysMat.Contains(hitInfo2.collider.sharedMaterial) || !this.dynamicFootstep.metalAndGlassClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.rockAndConcretePhysMat.Any<PhysicMaterial>() || !this.dynamicFootstep.rockAndConcretePhysMat.Contains(hitInfo2.collider.sharedMaterial) || !this.dynamicFootstep.rockAndConcreteClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.dirtAndGravelPhysMat.Any<PhysicMaterial>() || !this.dynamicFootstep.dirtAndGravelPhysMat.Contains(hitInfo2.collider.sharedMaterial) || !this.dynamicFootstep.dirtAndGravelClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.mudPhysMat.Any<PhysicMaterial>() || !this.dynamicFootstep.mudPhysMat.Contains(hitInfo2.collider.sharedMaterial) || !this.dynamicFootstep.mudClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.customPhysMat.Any<PhysicMaterial>() || !this.dynamicFootstep.customPhysMat.Contains(hitInfo2.collider.sharedMaterial) || !this.dynamicFootstep.customClipSet.Any<AudioClip>() ? this.footStepSounds : this.dynamicFootstep.customClipSet) : this.dynamicFootstep.mudClipSet) : this.dynamicFootstep.dirtAndGravelClipSet) : this.dynamicFootstep.rockAndConcreteClipSet) : this.dynamicFootstep.metalAndGlassClipSet) : this.dynamicFootstep.grassClipSet) : this.dynamicFootstep.woodClipSet;
          else if ((bool) (UnityEngine.Object) hitInfo2.collider.GetComponent<MeshRenderer>())
            this.dynamicFootstep.currentClipSet = !this.dynamicFootstep.woodMat.Any<Material>() || !this.dynamicFootstep.woodMat.Contains(hitInfo2.collider.GetComponent<MeshRenderer>().sharedMaterial) || !this.dynamicFootstep.woodClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.grassMat.Any<Material>() || !this.dynamicFootstep.grassMat.Contains(hitInfo2.collider.GetComponent<MeshRenderer>().sharedMaterial) || !this.dynamicFootstep.grassClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.metalAndGlassMat.Any<Material>() || !this.dynamicFootstep.metalAndGlassMat.Contains(hitInfo2.collider.GetComponent<MeshRenderer>().sharedMaterial) || !this.dynamicFootstep.metalAndGlassClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.rockAndConcreteMat.Any<Material>() || !this.dynamicFootstep.rockAndConcreteMat.Contains(hitInfo2.collider.GetComponent<MeshRenderer>().sharedMaterial) || !this.dynamicFootstep.rockAndConcreteClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.dirtAndGravelMat.Any<Material>() || !this.dynamicFootstep.dirtAndGravelMat.Contains(hitInfo2.collider.GetComponent<MeshRenderer>().sharedMaterial) || !this.dynamicFootstep.dirtAndGravelClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.mudMat.Any<Material>() || !this.dynamicFootstep.mudMat.Contains(hitInfo2.collider.GetComponent<MeshRenderer>().sharedMaterial) || !this.dynamicFootstep.mudClipSet.Any<AudioClip>() ? (!this.dynamicFootstep.customMat.Any<Material>() || !this.dynamicFootstep.customMat.Contains(hitInfo2.collider.GetComponent<MeshRenderer>().sharedMaterial) || !this.dynamicFootstep.customClipSet.Any<AudioClip>() ? (this.footStepSounds.Any<AudioClip>() ? this.footStepSounds : (List<AudioClip>) null) : this.dynamicFootstep.customClipSet) : this.dynamicFootstep.mudClipSet) : this.dynamicFootstep.dirtAndGravelClipSet) : this.dynamicFootstep.rockAndConcreteClipSet) : this.dynamicFootstep.metalAndGlassClipSet) : this.dynamicFootstep.grassClipSet) : this.dynamicFootstep.woodClipSet;
          if (this.IsGrounded)
          {
            if (!this.previousGrounded)
            {
              if (this.dynamicFootstep.currentClipSet.Any<AudioClip>())
                this.audioSource.PlayOneShot(this.dynamicFootstep.currentClipSet[UnityEngine.Random.Range(0, this.dynamicFootstep.currentClipSet.Count)], this.Volume / 10f);
              this.nextStepTime = this.headbobCycle + 0.5f;
            }
            else if ((double) this.headbobCycle > (double) this.nextStepTime)
            {
              this.nextStepTime = this.headbobCycle + 0.5f;
              if (this.dynamicFootstep.currentClipSet.Any<AudioClip>())
                this.audioSource.PlayOneShot(this.dynamicFootstep.currentClipSet[UnityEngine.Random.Range(0, this.dynamicFootstep.currentClipSet.Count)], this.Volume / 10f);
            }
            this.previousGrounded = true;
          }
          else
          {
            if (this.previousGrounded && this.dynamicFootstep.currentClipSet.Any<AudioClip>())
              this.audioSource.PlayOneShot(this.dynamicFootstep.currentClipSet[UnityEngine.Random.Range(0, this.dynamicFootstep.currentClipSet.Count)], this.Volume / 10f);
            this.previousGrounded = false;
          }
        }
        else
        {
          this.dynamicFootstep.currentClipSet = this.footStepSounds;
          if (this.IsGrounded)
          {
            if (!this.previousGrounded)
            {
              if ((bool) (UnityEngine.Object) this.landSound)
                this.audioSource.PlayOneShot(this.landSound, this.Volume / 10f);
              this.nextStepTime = this.headbobCycle + 0.5f;
            }
            else if ((double) this.headbobCycle > (double) this.nextStepTime)
            {
              this.nextStepTime = this.headbobCycle + 0.5f;
              int index = UnityEngine.Random.Range(0, this.footStepSounds.Count);
              if (this.footStepSounds.Any<AudioClip>())
                this.audioSource.PlayOneShot(this.footStepSounds[index], this.Volume / 10f);
              this.footStepSounds[index] = this.footStepSounds[0];
            }
            this.previousGrounded = true;
          }
          else
          {
            if (this.previousGrounded && (bool) (UnityEngine.Object) this.jumpSound)
              this.audioSource.PlayOneShot(this.jumpSound, this.Volume / 10f);
            this.previousGrounded = false;
          }
        }
      }
      else if (this.IsGrounded)
      {
        if (!this.previousGrounded)
        {
          if ((bool) (UnityEngine.Object) this.landSound)
            this.audioSource.PlayOneShot(this.landSound, this.Volume / 10f);
          this.nextStepTime = this.headbobCycle + 0.5f;
        }
        else if ((double) this.headbobCycle > (double) this.nextStepTime)
        {
          this.nextStepTime = this.headbobCycle + 0.5f;
          int index = UnityEngine.Random.Range(0, this.footStepSounds.Count);
          if (this.footStepSounds.Any<AudioClip>() && (UnityEngine.Object) this.footStepSounds[index] != (UnityEngine.Object) null)
            this.audioSource.PlayOneShot(this.footStepSounds[index], this.Volume / 10f);
        }
        this.previousGrounded = true;
      }
      else
      {
        if (this.previousGrounded && (bool) (UnityEngine.Object) this.jumpSound)
          this.audioSource.PlayOneShot(this.jumpSound, this.Volume / 10f);
        this.previousGrounded = false;
      }
    }
    this.IsGrounded = false;
    if ((double) this.advanced.maxSlopeAngle <= 0.0)
      return;
    if (this.advanced.isTouchingFlat || this.advanced.isTouchingWalkable || this.advanced.isTouchingUpright)
      this.didJump = false;
    this.advanced.isTouchingWalkable = false;
    this.advanced.isTouchingUpright = false;
    this.advanced.isTouchingFlat = false;
  }

  public IEnumerator CameraShake(float Duration, float Magnitude)
  {
    float elapsed = 0.0f;
    while ((double) elapsed < (double) Duration && this.enableCameraShake)
    {
      this.playerCamera.transform.localPosition = Vector3.MoveTowards(this.playerCamera.transform.localPosition, new Vector3(this.cameraStartingPosition.x + (float) UnityEngine.Random.Range(-1, 1) * Magnitude, this.cameraStartingPosition.y + (float) UnityEngine.Random.Range(-1, 1) * Magnitude, this.cameraStartingPosition.z), Magnitude * 2f);
      yield return (object) new WaitForSecondsRealtime(1f / 1000f);
      elapsed += Time.deltaTime;
      yield return (object) null;
    }
    this.playerCamera.transform.localPosition = this.cameraStartingPosition;
  }

  public void RotateCamera(Vector2 Rotation, bool Snap)
  {
    this.enableCameraMovement = !this.enableCameraMovement;
    if (Snap)
    {
      this.followAngles = (Vector3) Rotation;
      this.targetAngles = (Vector3) Rotation;
    }
    else
      this.targetAngles = (Vector3) Rotation;
    this.enableCameraMovement = !this.enableCameraMovement;
  }

  public void ControllerPause()
  {
    this.controllerPauseState = !this.controllerPauseState;
    if (!this.lockAndHideCursor)
      return;
    Cursor.lockState = this.controllerPauseState ? CursorLockMode.None : CursorLockMode.Locked;
    Cursor.visible = this.controllerPauseState;
  }

  private float SlopeCheck()
  {
    this.advanced.lastKnownSlopeAngle = Mathf.MoveTowards(this.advanced.lastKnownSlopeAngle, Vector3.Angle(this.advanced.curntGroundNormal, Vector3.up), 5f);
    return new AnimationCurve(new Keyframe[6]
    {
      new Keyframe(-90f, 1f),
      new Keyframe(0.0f, 1f),
      new Keyframe(this.advanced.maxSlopeAngle + 15f, 0.0f),
      new Keyframe(this.advanced.maxWallShear, 0.0f),
      new Keyframe(this.advanced.maxWallShear + 0.1f, 1f),
      new Keyframe(90f, 1f)
    })
    {
      preWrapMode = WrapMode.Once,
      postWrapMode = WrapMode.ClampForever
    }.Evaluate(this.advanced.lastKnownSlopeAngle);
  }

  private void OnCollisionEnter(Collision CollisionData)
  {
    for (int index = 0; index < CollisionData.contactCount; ++index)
    {
      ContactPoint contact = CollisionData.GetContact(index);
      float num = Vector3.Angle(contact.normal, Vector3.up);
      contact = CollisionData.GetContact(index);
      if ((double) contact.point.y < (double) this.transform.position.y - ((double) this.capsule.height / 2.0 - (double) this.capsule.radius * 0.949999988079071))
      {
        if (!this.IsGrounded)
        {
          this.IsGrounded = true;
          this.advanced.stairMiniHop = false;
          if (this.didJump && (double) num <= 70.0)
            this.didJump = false;
        }
        if ((double) this.advanced.maxSlopeAngle > 0.0)
        {
          if ((double) num < 5.0999999046325684)
          {
            this.advanced.isTouchingFlat = true;
            this.advanced.isTouchingWalkable = true;
          }
          else if ((double) num < (double) this.advanced.maxSlopeAngle + 0.10000000149011612)
            this.advanced.isTouchingWalkable = true;
          else if ((double) num < 90.0)
            this.advanced.isTouchingUpright = true;
          FirstPersonAIO.AdvancedSettings advanced = this.advanced;
          contact = CollisionData.GetContact(index);
          Vector3 normal = contact.normal;
          advanced.curntGroundNormal = normal;
        }
      }
    }
  }

  private void OnCollisionStay(Collision CollisionData)
  {
    for (int index = 0; index < CollisionData.contactCount; ++index)
    {
      ContactPoint contact = CollisionData.GetContact(index);
      float num = Vector3.Angle(contact.normal, Vector3.up);
      contact = CollisionData.GetContact(index);
      if ((double) contact.point.y < (double) this.transform.position.y - ((double) this.capsule.height / 2.0 - (double) this.capsule.radius * 0.949999988079071))
      {
        if (!this.IsGrounded)
        {
          this.IsGrounded = true;
          this.advanced.stairMiniHop = false;
        }
        if ((double) this.advanced.maxSlopeAngle > 0.0)
        {
          if ((double) num < 5.0999999046325684)
          {
            this.advanced.isTouchingFlat = true;
            this.advanced.isTouchingWalkable = true;
          }
          else if ((double) num < (double) this.advanced.maxSlopeAngle + 0.10000000149011612)
            this.advanced.isTouchingWalkable = true;
          else if ((double) num < 90.0)
            this.advanced.isTouchingUpright = true;
          FirstPersonAIO.AdvancedSettings advanced = this.advanced;
          contact = CollisionData.GetContact(index);
          Vector3 normal = contact.normal;
          advanced.curntGroundNormal = normal;
        }
      }
    }
  }

  private void OnCollisionExit(Collision CollisionData)
  {
    this.IsGrounded = false;
    if ((double) this.advanced.maxSlopeAngle <= 0.0)
      return;
    this.advanced.curntGroundNormal = Vector3.up;
    this.advanced.lastKnownSlopeAngle = 0.0f;
    this.advanced.isTouchingWalkable = false;
    this.advanced.isTouchingUpright = false;
  }

  public enum InvertMouseInput
  {
    None,
    X,
    Y,
    Both,
  }

  public enum CameraInputMethod
  {
    Traditional,
    TraditionalWithConstraints,
    Retro,
  }

  [Serializable]
  public class CrouchModifiers
  {
    public bool useCrouch = true;
    public bool toggleCrouch;
    public KeyCode crouchKey = KeyCode.LeftControl;
    public float crouchWalkSpeedMultiplier = 0.5f;
    public float crouchJumpPowerMultiplier;
    public bool crouchOverride;
    internal float colliderHeight;
  }

  [Serializable]
  public class AdvancedSettings
  {
    public float gravityMultiplier = 1f;
    public PhysicMaterial zeroFrictionMaterial;
    public PhysicMaterial highFrictionMaterial;
    public float maxSlopeAngle = 55f;
    internal bool isTouchingWalkable;
    internal bool isTouchingUpright;
    internal bool isTouchingFlat;
    public float maxWallShear = 89f;
    public float maxStepHeight = 0.2f;
    internal bool stairMiniHop;
    public RaycastHit surfaceAngleCheck;
    public Vector3 curntGroundNormal;
    public Vector2 moveDirRef;
    public float lastKnownSlopeAngle;
    public float FOVKickAmount = 2.5f;
    public float changeTime = 0.75f;
    public float fovRef;
  }

  public enum FSMode
  {
    Static,
    Dynamic,
  }

  [Serializable]
  public class DynamicFootStep
  {
    public FirstPersonAIO.DynamicFootStep.matMode materialMode;
    public List<PhysicMaterial> woodPhysMat;
    public List<PhysicMaterial> metalAndGlassPhysMat;
    public List<PhysicMaterial> grassPhysMat;
    public List<PhysicMaterial> dirtAndGravelPhysMat;
    public List<PhysicMaterial> rockAndConcretePhysMat;
    public List<PhysicMaterial> mudPhysMat;
    public List<PhysicMaterial> customPhysMat;
    public List<Material> woodMat;
    public List<Material> metalAndGlassMat;
    public List<Material> grassMat;
    public List<Material> dirtAndGravelMat;
    public List<Material> rockAndConcreteMat;
    public List<Material> mudMat;
    public List<Material> customMat;
    public List<AudioClip> currentClipSet;
    public List<AudioClip> woodClipSet;
    public List<AudioClip> metalAndGlassClipSet;
    public List<AudioClip> grassClipSet;
    public List<AudioClip> dirtAndGravelClipSet;
    public List<AudioClip> rockAndConcreteClipSet;
    public List<AudioClip> mudClipSet;
    public List<AudioClip> customClipSet;

    public enum matMode
    {
      physicMaterial,
      Material,
    }
  }
}
