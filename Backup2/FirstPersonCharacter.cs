// Decompiled with JetBrains decompiler
// Type: FirstPersonCharacter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

#nullable disable
public class FirstPersonCharacter : MonoBehaviour
{
  public Transform Pivot;
  public SexCameraController SexCamera;
  public float CurrentRunSpeed = 6f;
  public float CurrentstrafeSpeed = 4f;
  public float runSpeed = 6f;
  public float strafeSpeed = 4f;
  public float jumpPower = 5f;
  public static bool RunByDefault = true;
  public float RunSpeed = 6f;
  public float WalkSpeed = 1f;
  public float RunSpeed_strafe = 4f;
  public float WalkSpeed_strafe = 0.7f;
  [SerializeField]
  private FirstPersonCharacter.AdvancedSettings advanced = new FirstPersonCharacter.AdvancedSettings();
  [SerializeField]
  private bool lockCursor = true;
  private CapsuleCollider capsule;
  private const float jumpRayLength = 0.7f;
  public bool grounded;
  private Vector2 input;
  private IComparer rayHitComparer;
  public CapsuleCollider HeightCapsule;
  public float HeightMultiplyer = 1f;
  public float HeightMultiplyer2 = 2f;
  private Rigidbody _ThisRigid;
  public Transform FirstPersonNeck;
  public Vector3 HeadFirstPerson_Pos;
  public Vector3 Head3rdPerson_Pos;
  public RPG_cam_2 ThirdPersonScript2;
  public ThirdPersonCamRPG ThirdPersonScript;
  public Transform ThirdrdpPlace;
  public MonoBehaviour[] MouseRotators;
  public Transform Top;
  public Transform Head3rdPersonView;
  public FirstPersonCharacter.PlayerStance _Stance;
  public MouseRotatorZ TorsoPivot;
  public Transform TorsoPivot2;
  public bool _AimingFpCamera;
  public bool _FirstPerson;
  public RaycastScreen PlayerLocalLodScript;
  public bool Basic3rdPerson_;
  public static bool AllowMouseCursor;
  public Vector3 desiredMove;
  public Transform DesiredMoveTransformReference;
  public Transform CameraTransform;
  public float ConstAddForceX;
  public float ConstAddForceY;

  public FirstPersonCharacter.PlayerStance Stance
  {
    get => this._Stance;
    set
    {
      this._Stance = value;
      switch (this._Stance)
      {
        case FirstPersonCharacter.PlayerStance.Standing:
          this.GetComponent<Person>().PostureHeightState = Person_PostureHeightState.Standing;
          this.HeightCapsule.height = 2f;
          this.HeightCapsule.center = new Vector3(0.0f, 1f, 0.0f);
          this.RunSpeed = 6f;
          this.runSpeed = 6f;
          this.strafeSpeed = 4f;
          this.RunSpeed_strafe = 4f;
          break;
        case FirstPersonCharacter.PlayerStance.Crouch:
          this.GetComponent<Person>().PostureHeightState = Person_PostureHeightState.Crouching;
          this.HeightCapsule.height = 1f;
          this.HeightCapsule.center = new Vector3(0.0f, 0.5f, 0.0f);
          this.RunSpeed = 1f;
          this.runSpeed = 1f;
          this.strafeSpeed = 1f;
          this.RunSpeed_strafe = 1f;
          break;
        case FirstPersonCharacter.PlayerStance.Crawl:
          this.GetComponent<Person>().PostureHeightState = Person_PostureHeightState.Crawling;
          this.HeightCapsule.height = 0.2f;
          this.HeightCapsule.center = new Vector3(0.0f, 0.4f, 0.0f);
          this.RunSpeed = 1f;
          this.runSpeed = 1f;
          this.strafeSpeed = 1f;
          this.RunSpeed_strafe = 1f;
          break;
      }
      Main.RunInNextFrame((Action) (() => this.Head3rdPersonView.position = Main.Instance.Player.Neck.position), 2);
    }
  }

  public bool AimingFpCamera
  {
    get => this._AimingFpCamera;
    set
    {
      this._AimingFpCamera = value;
      Person component = this.GetComponent<Person>();
      if (value)
      {
        component.RagdollParts[1].transform.SetParent(this.TorsoPivot2);
        this.TorsoPivot.enabled = true;
        this.TorsoPivot.transform.localEulerAngles = new Vector3(0.0f, -60f, 0.0f);
        this.TorsoPivot2.localEulerAngles = new Vector3(0.0f, 60f, 0.0f);
        this.CameraTransform.SetParent(component.RagdollParts[2].transform.parent);
        this.CameraTransform.localEulerAngles = new Vector3(0.0f, -42.967f, 17.136f);
        this.CameraTransform.localPosition = new Vector3(0.0f, 0.1f, 0.0f);
      }
      else
      {
        component.RagdollParts[1].transform.SetParent(this.TorsoPivot.transform.parent.parent);
        this.TorsoPivot.enabled = false;
        this.CameraTransform.SetParent(this.Pivot);
        this.CameraTransform.localEulerAngles = Vector3.zero;
        this.CameraTransform.localPosition = Vector3.zero;
      }
    }
  }

  public bool FirstPerson
  {
    get => this._FirstPerson;
    set
    {
      this.Basic3rdPerson = false;
      this._FirstPerson = value;
      Person component = this.GetComponent<Person>();
      component._Rigidbody.angularVelocity = Vector3.zero;
      if (value)
      {
        component.LookAtPlayer.enabled = false;
        this.ThirdPersonScript2.CameraObj.localPosition = Vector3.zero;
        if ((UnityEngine.Object) component.CurrentHair != (UnityEngine.Object) null)
        {
          foreach (Renderer componentsInChild in component.CurrentHair.GetComponentsInChildren<Renderer>())
            componentsInChild.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
        }
        if ((UnityEngine.Object) component.CurrentHat != (UnityEngine.Object) null)
        {
          foreach (Renderer componentsInChild in component.CurrentHat.GetComponentsInChildren<Renderer>())
            componentsInChild.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
        }
        this.Pivot.parent.localPosition = this.HeadFirstPerson_Pos;
        this.Pivot.parent.localEulerAngles = Vector3.zero;
        this.ThirdPersonScript.target.localPosition = Vector3.zero;
        this.ThirdPersonScript.target.localEulerAngles = Vector3.zero;
        this.ThirdPersonScript.MainCam.transform.localPosition = Vector3.zero;
        this.ThirdPersonScript.MainCam.transform.localEulerAngles = Vector3.zero;
        component.WeaponInv.RayDistance = 2f;
        this.DesiredMoveTransformReference = this.transform;
      }
      else
      {
        this.AimingFpCamera = false;
        component.LookAtPlayer.EnableIfNotEnabled();
        this.ThirdPersonScript2.CameraObj.localPosition = new Vector3(this.ThirdPersonScript2.CamPointSide_Value, 0.0f, 0.0f);
        if ((UnityEngine.Object) component.CurrentHair != (UnityEngine.Object) null)
        {
          foreach (Renderer componentsInChild in component.CurrentHair.GetComponentsInChildren<Renderer>())
            componentsInChild.shadowCastingMode = ShadowCastingMode.On;
        }
        if ((UnityEngine.Object) component.CurrentHat != (UnityEngine.Object) null)
        {
          foreach (Renderer componentsInChild in component.CurrentHat.GetComponentsInChildren<Renderer>())
            componentsInChild.shadowCastingMode = ShadowCastingMode.On;
        }
        this.Pivot.parent.localPosition = this.Head3rdPerson_Pos;
        this.ThirdPersonScript.target.localPosition = this.ThirdrdpPlace.localPosition;
        this.ThirdPersonScript.target.localEulerAngles = this.ThirdrdpPlace.localEulerAngles;
        this.ThirdPersonScript.MainCam.transform.localPosition = new Vector3(-0.5f, 0.0f, 0.0f);
        this.ThirdPersonScript.MainCam.transform.localEulerAngles = Vector3.zero;
        component.WeaponInv.RayDistance = 5f;
        this.DesiredMoveTransformReference = this.CameraTransform;
      }
      Main.RunInNextFrame((Action) (() => this.Stance = this._Stance), 5);
      component.HiddenHead = value;
      this.ThirdPersonScript2.enabled = !value;
      for (int index = 0; index < this.MouseRotators.Length; ++index)
        this.MouseRotators[index].enabled = value;
      for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.SpawnedPeople[index] != (UnityEngine.Object) null && (UnityEngine.Object) Main.Instance.SpawnedPeople[index].LookAtPlayer != (UnityEngine.Object) null)
          Main.Instance.SpawnedPeople[index].LookAtPlayer.playerTransform = value ? this.CameraTransform : Main.Instance.Player.Head;
      }
      component.LookAtPlayer.playerTransform = this.CameraTransform;
    }
  }

  public bool Basic3rdPerson
  {
    set
    {
      this.Basic3rdPerson_ = value;
      if (!value)
        return;
      this.ThirdPersonScript.MainCam.transform.localPosition = Vector3.zero;
    }
    get => this.Basic3rdPerson_;
  }

  private void Awake()
  {
    this.DesiredMoveTransformReference = this.transform;
    this.capsule = this.GetComponent<CapsuleCollider>();
    this.grounded = true;
    this.rayHitComparer = (IComparer) new FirstPersonCharacter.RayHitComparer();
    this._ThisRigid = this.GetComponent<Rigidbody>();
    if (this.lockCursor)
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
    else
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }
  }

  public void Start()
  {
  }

  private void Update()
  {
    if (!FirstPersonCharacter.AllowMouseCursor && Input.GetMouseButtonUp(UI_Settings.LeftMouseButton))
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
    if (Input.GetKeyDown(KeyCode.Tilde))
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }
    if (Input.GetKeyUp(KeyCode.C))
    {
      this.AimingFpCamera = false;
      if (this._Stance == FirstPersonCharacter.PlayerStance.Crawl)
      {
        this.Top.localPosition = new Vector3(0.0f, 0.81f, 0.0f);
        RaycastHit hitInfo;
        if (!Physics.Raycast(this.Top.position, this.Top.TransformDirection(Vector3.up), out hitInfo, 1.1f, int.MaxValue, QueryTriggerInteraction.Ignore))
          this.Stance = FirstPersonCharacter.PlayerStance.Standing;
        else if (!Physics.Raycast(this.Top.position, this.Top.TransformDirection(Vector3.up), out hitInfo, 0.15f, int.MaxValue, QueryTriggerInteraction.Ignore))
          this.Stance = FirstPersonCharacter.PlayerStance.Crouch;
      }
      else
        ++this.Stance;
    }
    if (this._Stance == FirstPersonCharacter.PlayerStance.Standing && Main.Instance.Player.CanRun)
    {
      if (Input.GetKeyDown(KeyCode.LeftShift))
      {
        this.AimingFpCamera = false;
        if (FirstPersonCharacter.RunByDefault)
        {
          this.CurrentRunSpeed = this.WalkSpeed;
          this.CurrentstrafeSpeed = this.WalkSpeed_strafe;
          this.runSpeed = this.WalkSpeed;
          this.strafeSpeed = this.WalkSpeed_strafe;
        }
        else
        {
          this.CurrentRunSpeed = this.RunSpeed;
          this.CurrentstrafeSpeed = this.RunSpeed_strafe;
          this.runSpeed = this.RunSpeed;
          this.strafeSpeed = this.RunSpeed_strafe;
        }
      }
      if (Input.GetKeyUp(KeyCode.LeftShift))
      {
        this.AimingFpCamera = false;
        if (FirstPersonCharacter.RunByDefault)
        {
          this.CurrentRunSpeed = this.RunSpeed;
          this.CurrentstrafeSpeed = this.RunSpeed_strafe;
          this.runSpeed = this.RunSpeed;
          this.strafeSpeed = this.RunSpeed_strafe;
        }
        else
        {
          this.CurrentRunSpeed = this.WalkSpeed;
          this.CurrentstrafeSpeed = this.WalkSpeed_strafe;
          this.runSpeed = this.WalkSpeed;
          this.strafeSpeed = this.WalkSpeed_strafe;
        }
      }
    }
    if (Input.GetKeyUp(KeyCode.Tab))
    {
      this.AimingFpCamera = false;
      this.FirstPerson = !this._FirstPerson;
    }
    if (Input.GetKeyDown(KeyCode.M))
    {
      this.AimingFpCamera = false;
      Main.Instance.Player.Masturbating = true;
    }
    if (Input.GetKeyUp(KeyCode.M))
    {
      this.AimingFpCamera = false;
      Main.Instance.Player.Masturbating = false;
    }
    if ((UnityEngine.Object) Main.Instance.GameplayMenu != (UnityEngine.Object) null && !Main.Instance.GameplayMenu.Crossair.activeSelf)
    {
      if (!((UnityEngine.Object) Main.Instance.Player.WeaponInv.CurrentWeapon == (UnityEngine.Object) null))
      {
        if (Input.GetMouseButtonDown(UI_Settings.RightMouseButton))
        {
          Main.Instance.Player.Aiming = true;
          if (this.FirstPerson && Main.Instance.Player.WeaponInv.CurrentWeapon.type != WeaponType.Melee && this.Stance == FirstPersonCharacter.PlayerStance.Standing)
            this.AimingFpCamera = true;
        }
        if (Input.GetMouseButtonUp(UI_Settings.RightMouseButton))
        {
          Main.Instance.Player.Aiming = false;
          if (this.FirstPerson)
            this.AimingFpCamera = false;
        }
        if (Main.Instance.Player.WeaponInv.CurrentWeapon.type == WeaponType.Melee)
        {
          if (Input.GetMouseButtonDown(UI_Settings.LeftMouseButton))
            Main.Instance.Player.MeleeHit((Person) null);
          if (!Input.GetMouseButtonDown(UI_Settings.RightMouseButton))
            ;
        }
      }
    }
    else if ((UnityEngine.Object) Main.Instance.Player.WeaponInv.CurrentWeapon == (UnityEngine.Object) null)
    {
      if (!((UnityEngine.Object) Main.Instance.Player.WeaponInv.IntLookingAt != (UnityEngine.Object) null))
        ;
    }
    else if (Main.Instance.Player.WeaponInv.CurrentWeapon.type == WeaponType.Melee)
    {
      Interactible intLookingAt = Main.Instance.Player.WeaponInv.IntLookingAt;
      if ((UnityEngine.Object) intLookingAt != (UnityEngine.Object) null)
      {
        Person component = intLookingAt.GetComponent<Person>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.TheHealth.canDie)
        {
          if (Input.GetMouseButtonDown(UI_Settings.LeftMouseButton))
            Main.Instance.Player.MeleeHit(component);
        }
        else if (Input.GetMouseButtonDown(UI_Settings.LeftMouseButton))
          Main.Instance.Player.MeleeHit((Person) null);
      }
    }
    if (Input.GetKeyUp(KeyCode.J))
      Main.Instance.GameplayMenu.OpenJournal();
    if (Input.GetKeyUp(KeyCode.X))
      Main.Instance.Player.SleepOnFloor();
    if (!Main.Instance.ScatContent || !Input.GetKeyUp(KeyCode.V))
      return;
    if ((double) Main.Instance.Player.Toilet > 20.0)
      Main.Instance.Player.ShitOnFloor();
    else
      Debug.Log((object) "Not need enough to evacuate");
  }

  public void FixedUpdate()
  {
    float num1 = this._Stance == FirstPersonCharacter.PlayerStance.Standing ? this.CurrentRunSpeed : this.runSpeed;
    float num2 = this._Stance == FirstPersonCharacter.PlayerStance.Standing ? this.CurrentstrafeSpeed : this.strafeSpeed;
    float axis1 = Input.GetAxis("Horizontal");
    float axis2 = Input.GetAxis("Vertical");
    bool flag = this._Stance == FirstPersonCharacter.PlayerStance.Standing && Input.GetButton("Jump");
    this.input = new Vector2(axis1, axis2);
    if ((double) this.input.sqrMagnitude > 1.0)
      this.input.Normalize();
    this.desiredMove = this.DesiredMoveTransformReference.forward * this.input.y * num1 + this.transform.right * this.input.x * num2;
    this.desiredMove = new Vector3(this.desiredMove.x, 0.0f, this.desiredMove.z);
    float y = this._ThisRigid.velocity.y;
    if (this.grounded & flag)
    {
      y += this.jumpPower;
      this.grounded = false;
    }
    this._ThisRigid.velocity = this.desiredMove + Vector3.up * y;
    if ((double) this.desiredMove.magnitude > 0.0 || !this.grounded)
      this.capsule.material = this.advanced.zeroFrictionMaterial;
    else
      this.capsule.material = this.advanced.highFrictionMaterial;
    RaycastHit[] raycastHitArray = Physics.RaycastAll(new Ray(this.transform.position, -this.transform.up), this.capsule.height * 0.7f);
    Array.Sort((Array) raycastHitArray, this.rayHitComparer);
    if (this.grounded || (double) this._ThisRigid.velocity.y < (double) this.jumpPower * 0.5)
    {
      this.grounded = false;
      for (int index = 0; index < raycastHitArray.Length; ++index)
      {
        if (!raycastHitArray[index].collider.isTrigger)
        {
          this.grounded = true;
          this._ThisRigid.position = Vector3.MoveTowards(this._ThisRigid.position, raycastHitArray[index].point + Vector3.up * this.capsule.height * 0.5f, Time.deltaTime * this.advanced.groundStickyEffect);
          this._ThisRigid.velocity = new Vector3(this._ThisRigid.velocity.x, 0.0f, this._ThisRigid.velocity.z);
          break;
        }
      }
    }
    this._ThisRigid.AddForce(Physics.gravity * (this.advanced.gravityMultiplier - 1f));
  }

  [Serializable]
  public class AdvancedSettings
  {
    public float gravityMultiplier = 1f;
    public PhysicMaterial zeroFrictionMaterial;
    public PhysicMaterial highFrictionMaterial;
    public float groundStickyEffect = 5f;
  }

  public enum PlayerStance
  {
    Standing,
    Crouch,
    Crawl,
  }

  private class RayHitComparer : IComparer
  {
    public int Compare(object x, object y)
    {
      return ((RaycastHit) x).distance.CompareTo(((RaycastHit) y).distance);
    }
  }
}
