// Decompiled with JetBrains decompiler
// Type: bl_ThirdPersonUserControl
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.CrossPlatformInput;

#nullable disable
public class bl_ThirdPersonUserControl : MonoBehaviour
{
  public Person ThisPerson;
  public Transform FirstPersonViewSpot;
  public SexCameraController SexCamera;
  public FreeLookCam TheCam;
  public ProtectCameraFromWallClip NoCamClip;
  public bl_ThirdPersonCharacter m_Character;
  public Transform m_Cam;
  public Transform Pivot;
  private Vector3 m_CamForward;
  public Vector3 m_Move;
  public bool m_Jump;
  public Transform[] SpineBonesToRotate;
  public bool _SetupForWeaponAim;
  public bl_ThirdPersonUserControl.MeleeOptions _MeleeOption;
  public bl_ThirdPersonUserControl.MeleeWeaponOptions _MeleeWeaponOption;
  public bl_ThirdPersonUserControl.e_ThirdCamPositionType ThirdCamPositionTypeOnSettings;
  public bl_ThirdPersonUserControl.e_ThirdCamPositionType _ThirdCamPositionType;
  public bool _FirstPerson;
  public bool _CanMove;
  public bool _AimingFpCamera;
  public Vector3 rot;
  public float RunningXPCounter;
  public Transform OriginalResetSpot;
  public Transform ResetSpot;
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
  public bool Aiming;
  public Transform SpineAimSpot;
  public Transform Spine1;
  public Vector3 Spine1OrgPos;
  public NavMeshAgent NavMesh;

  public bool SetupForWeaponAim
  {
    get => this._SetupForWeaponAim;
    set
    {
      if (this._SetupForWeaponAim == value)
        return;
      this._SetupForWeaponAim = value;
      if (value)
      {
        if (this.SpineBonesToRotate != null && this.SpineBonesToRotate.Length > 1)
          this.Spine1.SetParent(this.SpineBonesToRotate[1]);
        if (this.FirstPerson)
          this.ThisPerson.ViewPoint.localPosition = new Vector3(0.0f, 0.0f, 1f);
        else
          this.ThisPerson.ViewPoint.localPosition = new Vector3(0.0f, 0.5f, 4f);
      }
      else
      {
        if (this.SpineBonesToRotate != null && this.SpineBonesToRotate.Length > 1)
        {
          this.Spine1.SetParent(this.SpineBonesToRotate[2]);
          this.Spine1.localPosition = this.Spine1OrgPos;
        }
        this.ThisPerson.ViewPoint.localPosition = new Vector3(0.0f, 0.0f, 1f);
      }
    }
  }

  private void Start()
  {
    if ((Object) Camera.main != (Object) null)
      return;
    Debug.LogWarning((object) "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", (Object) this.gameObject);
  }

  public bl_ThirdPersonUserControl.MeleeOptions MeleeOption
  {
    get => this._MeleeOption;
    set
    {
      this._MeleeOption = value;
      switch (this._MeleeOption)
      {
        case bl_ThirdPersonUserControl.MeleeOptions.None:
          this.ThisPerson.Anim.SetInteger("Weapon", 0);
          Main.Instance.GameplayMenu.MeleeOptionsUI.SetActive(false);
          break;
        case bl_ThirdPersonUserControl.MeleeOptions.Punch:
          this.ThisPerson.Anim.SetInteger("Weapon", -1);
          Main.Instance.GameplayMenu.MeleeOptionsUI.SetActive(true);
          Main.Instance.GameplayMenu.MeleeOptionText.text = "Punch";
          break;
        case bl_ThirdPersonUserControl.MeleeOptions.ThrowDown:
          this.ThisPerson.Anim.SetInteger("Weapon", -1);
          Main.Instance.GameplayMenu.MeleeOptionsUI.SetActive(true);
          Main.Instance.GameplayMenu.MeleeOptionText.text = "Throw Down";
          break;
        case bl_ThirdPersonUserControl.MeleeOptions.Max:
          this._MeleeOption = bl_ThirdPersonUserControl.MeleeOptions.None;
          goto case bl_ThirdPersonUserControl.MeleeOptions.None;
      }
    }
  }

  public bl_ThirdPersonUserControl.MeleeWeaponOptions MeleeWeaponOption
  {
    get => this._MeleeWeaponOption;
    set
    {
      this._MeleeWeaponOption = value;
      switch (this._MeleeWeaponOption)
      {
        case bl_ThirdPersonUserControl.MeleeWeaponOptions.Knockout:
          Main.Instance.GameplayMenu.MeleeOptionsUI.SetActive(true);
          Main.Instance.GameplayMenu.MeleeOptionText.text = "Knockout";
          break;
        case bl_ThirdPersonUserControl.MeleeWeaponOptions.Kill:
          Main.Instance.GameplayMenu.MeleeOptionsUI.SetActive(true);
          Main.Instance.GameplayMenu.MeleeOptionText.text = "Kill";
          break;
        case bl_ThirdPersonUserControl.MeleeWeaponOptions.Max:
          this._MeleeWeaponOption = bl_ThirdPersonUserControl.MeleeWeaponOptions.Knockout;
          goto case bl_ThirdPersonUserControl.MeleeWeaponOptions.Knockout;
      }
    }
  }

  public bl_ThirdPersonUserControl.e_ThirdCamPositionType ThirdCamPositionType
  {
    get => this._ThirdCamPositionType;
    set
    {
      this._ThirdCamPositionType = value;
      if (this.FirstPerson)
        return;
      float x = -0.35f;
      switch (this._ThirdCamPositionType)
      {
        case bl_ThirdPersonUserControl.e_ThirdCamPositionType.Right:
          x = 0.35f;
          break;
        case bl_ThirdPersonUserControl.e_ThirdCamPositionType.Left:
          x = -0.35f;
          break;
        case bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back:
          x = 0.0f;
          break;
      }
      this.Pivot.localPosition = new Vector3(x, this.Pivot.localPosition.y, 0.0f);
    }
  }

  public bool FirstPerson
  {
    get => this._FirstPerson;
    set
    {
      this._FirstPerson = value;
      this.m_Cam.localEulerAngles = Vector3.zero;
      this.ThisPerson.HiddenHead = value;
      if (value)
      {
        this.m_Character.m_Animator.SetBool("Strafe", true);
        this.ThisPerson.Anim.applyRootMotion = false;
        this.ThisPerson.LookAtPlayer.enabled = false;
        this.NoCamClip.enabled = false;
        this.Pivot.position = this.FirstPersonViewSpot.position;
        this.m_Cam.localPosition = Vector3.zero;
        if ((Object) this.ThisPerson.CurrentHair != (Object) null)
        {
          foreach (Renderer componentsInChild in this.ThisPerson.CurrentHair.GetComponentsInChildren<Renderer>())
            componentsInChild.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
        }
        if ((Object) this.ThisPerson.CurrentHat != (Object) null)
        {
          foreach (Renderer componentsInChild in this.ThisPerson.CurrentHat.GetComponentsInChildren<Renderer>())
            componentsInChild.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
        }
        this.ThisPerson.WeaponInv.RayDistance = 3f;
        if (this.Aiming)
          this.ThisPerson.ViewPoint.localPosition = new Vector3(0.0f, 0.0f, 1f);
      }
      else
      {
        this.m_Character.m_Animator.SetBool("Strafe", false);
        float x = -0.35f;
        switch (this._ThirdCamPositionType)
        {
          case bl_ThirdPersonUserControl.e_ThirdCamPositionType.Right:
            x = 0.35f;
            break;
          case bl_ThirdPersonUserControl.e_ThirdCamPositionType.Left:
            x = -0.35f;
            break;
          case bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back:
            x = 0.0f;
            break;
        }
        this.Pivot.localPosition = new Vector3(x, this.Pivot.localPosition.y, 0.0f);
        this._ThirdCamPositionType = this.ThirdCamPositionTypeOnSettings;
        this.ThisPerson.LookAtPlayer.EnableIfNotEnabled();
        this.NoCamClip.enabled = true;
        if ((Object) this.ThisPerson.CurrentHair != (Object) null)
        {
          foreach (Renderer componentsInChild in this.ThisPerson.CurrentHair.GetComponentsInChildren<Renderer>())
            componentsInChild.shadowCastingMode = ShadowCastingMode.On;
        }
        if ((Object) this.ThisPerson.CurrentHat != (Object) null)
        {
          foreach (Renderer componentsInChild in this.ThisPerson.CurrentHat.GetComponentsInChildren<Renderer>())
            componentsInChild.shadowCastingMode = ShadowCastingMode.On;
        }
        this.ThisPerson.WeaponInv.RayDistance = 5f;
        if (this.Aiming)
          this.ThisPerson.ViewPoint.localPosition = new Vector3(0.0f, 0.5f, 4f);
      }
      this.m_Character.StandState = this.m_Character.StandState;
      for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
      {
        if ((Object) Main.Instance.SpawnedPeople[index] != (Object) null && (Object) Main.Instance.SpawnedPeople[index].LookAtPlayer != (Object) null)
          Main.Instance.SpawnedPeople[index].LookAtPlayer.playerTransform = value ? this.m_Cam : Main.Instance.Player.Head;
      }
      for (int index = 0; index < Main.Instance.SpawnedPeople_World.Count; ++index)
      {
        if ((Object) Main.Instance.SpawnedPeople_World[index] != (Object) null && (Object) Main.Instance.SpawnedPeople_World[index].LookAtPlayer != (Object) null)
          Main.Instance.SpawnedPeople_World[index].LookAtPlayer.playerTransform = value ? this.m_Cam : Main.Instance.Player.Head;
      }
      Main.Instance.Player.LookAtPlayer.playerTransform = this.m_Cam;
    }
  }

  public bool CanMove
  {
    get => this._CanMove;
    set
    {
      this._CanMove = value;
      if (value)
        return;
      this.StopMoving();
    }
  }

  public bool AimingFpCamera
  {
    get => this._AimingFpCamera;
    set
    {
      this._AimingFpCamera = value;
      this.GetComponent<Person>();
      int num = value ? 1 : 0;
    }
  }

  public void LateUpdate()
  {
    if (!this.FirstPerson && !this.Aiming)
      return;
    if (this.FirstPerson)
    {
      this.Pivot.position = this.FirstPersonViewSpot.position;
      this.Pivot.eulerAngles = new Vector3(this.Pivot.eulerAngles.x, this.Pivot.eulerAngles.y, 0.0f);
    }
    this.rot = new Vector3(0.0f, this.m_Cam.eulerAngles.y, 0.0f);
    this.transform.eulerAngles = this.rot;
  }

  public void Update()
  {
    if ((double) this.transform.position.y < -100.0)
    {
      this.m_Character.m_Rigidbody.velocity = Vector3.zero;
      this.transform.position = this.ResetSpot.position;
    }
    Vector3 vector3 = this.m_Character.m_Rigidbody.velocity;
    if ((double) vector3.magnitude > 50.0)
      this.m_Character.m_Rigidbody.velocity = Vector3.zero;
    if (Input.GetKeyUp(KeyCode.Tab))
      this.FirstPerson = !this.FirstPerson;
    if (Input.GetKeyDown(KeyCode.Tilde))
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }
    if (Input.GetKeyDown(KeyCode.M))
      Main.Instance.Player.Masturbating = true;
    if (Main.Instance.Player.Masturbating && Input.GetKeyUp(KeyCode.M))
    {
      Main.Instance.Player.Masturbating = false;
      Main.Instance.Player.Anim.Play("GainControl");
    }
    if (Input.GetKeyUp(KeyCode.J))
      Main.Instance.GameplayMenu.OpenJournal();
    if (Input.GetKeyUp(KeyCode.I))
    {
      Main.Instance.GameplayMenu.OpenJournal();
      Main.Instance.GameplayMenu.SelectInventory();
    }
    if (Input.GetKeyUp(KeyCode.F8))
    {
      if (Main.Instance.NewGameMenu.DificultySelected == 3)
        Main.Instance.Player.transform.position = new Vector3(-69f, 0.0f, 10f);
      else
        Main.Instance.Player.transform.position = this.ResetSpot.position;
    }
    if (Input.GetKeyUp(KeyCode.X))
      Main.Instance.Player.SleepOnFloor();
    if (Main.Instance.ScatContent && Input.GetKeyUp(KeyCode.V))
    {
      if ((double) Main.Instance.Player.Toilet > 20.0)
        Main.Instance.Player.ShitOnFloor();
      else
        Debug.Log((object) "Not enough need to evacuate");
    }
    if (Input.GetKeyUp(KeyCode.F1))
    {
      Main.Instance.GameplayMenu.OpenJournal();
      Main.Instance.GameplayMenu.SelectHowTo();
    }
    switch (this.m_Character.StandState)
    {
      case bl_ThirdPersonCharacter.bl_StandState.Standing:
        if (!this.m_Jump)
          this.m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        if (Input.GetKeyUp(KeyCode.C))
        {
          this.m_Character.StandState = bl_ThirdPersonCharacter.bl_StandState.Crouching;
          break;
        }
        if ((Object) this.ThisPerson.WeaponInv.CurrentWeapon == (Object) null && !Main.Instance.GameplayMenu.Crossair.activeSelf)
        {
          if (Input.GetMouseButtonDown(UI_Settings.RightMouseButton))
            ++this.MeleeOption;
          switch (this.MeleeOption)
          {
            case bl_ThirdPersonUserControl.MeleeOptions.Punch:
              if (Input.GetMouseButtonDown(UI_Settings.LeftMouseButton))
              {
                Main.Instance.Player.Punch((Person) null);
                break;
              }
              break;
            case bl_ThirdPersonUserControl.MeleeOptions.ThrowDown:
              if (Input.GetMouseButtonDown(UI_Settings.LeftMouseButton))
              {
                Main.Instance.Player.ThrowDown((Person) null);
                break;
              }
              break;
          }
        }
        else if ((Object) this.ThisPerson.WeaponInv.CurrentWeapon != (Object) null && this.ThisPerson.WeaponInv.CurrentWeapon.HoldingType == WeaponHoldingType.Blunt)
        {
          if (Input.GetMouseButtonDown(UI_Settings.RightMouseButton))
            ++this.MeleeWeaponOption;
          switch (this.MeleeWeaponOption)
          {
            case bl_ThirdPersonUserControl.MeleeWeaponOptions.Knockout:
              if (Input.GetMouseButtonDown(UI_Settings.LeftMouseButton))
              {
                Main.Instance.Player.MeleeHit((Person) null);
                break;
              }
              break;
            case bl_ThirdPersonUserControl.MeleeWeaponOptions.Kill:
              if (Input.GetMouseButtonDown(UI_Settings.LeftMouseButton))
              {
                Main.Instance.Player.MeleeHit((Person) null);
                break;
              }
              break;
          }
        }
        else
          break;
        break;
      case bl_ThirdPersonCharacter.bl_StandState.Crouching:
        if (!this.m_Jump)
          this.m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        if (Input.GetKeyUp(KeyCode.C))
        {
          this.m_Character.StandState = bl_ThirdPersonCharacter.bl_StandState.Crawling;
          break;
        }
        break;
      case bl_ThirdPersonCharacter.bl_StandState.Crawling:
        if (Input.GetKeyUp(KeyCode.C))
        {
          this.m_Character.StandState = bl_ThirdPersonCharacter.bl_StandState.Standing;
          break;
        }
        break;
    }
    float num1 = 0.0f;
    float num2 = 0.0f;
    if (this.CanMove)
    {
      num1 = CrossPlatformInputManager.GetAxis("Horizontal");
      num2 = CrossPlatformInputManager.GetAxis("Vertical");
      this.Aiming = Input.GetMouseButton(UI_Settings.RightMouseButton);
      if (!this.Aiming && (!this.FirstPerson || !((Object) this.ThisPerson.WeaponInv.CurrentWeapon != (Object) null)))
        num2 += Input.GetMouseButton(UI_Settings.LeftMouseButton) ? 1f : 0.0f;
      if ((double) num1 != 0.0 || (double) num2 != 0.0)
      {
        this.RunningXPCounter += Time.deltaTime;
        if ((double) this.RunningXPCounter > 20.0)
        {
          this.RunningXPCounter = 0.0f;
          this.ThisPerson.GainWorkXP(100);
        }
      }
    }
    if ((Object) this.m_Cam != (Object) null)
    {
      vector3 = Vector3.Scale(this.m_Cam.forward, new Vector3(1f, 0.0f, 1f));
      this.m_CamForward = vector3.normalized;
      this.m_Move = num2 * this.m_CamForward + num1 * this.m_Cam.right;
    }
    else
      this.m_Move = num2 * Vector3.forward + num1 * Vector3.right;
    if (!bl_ThirdPersonUserControl.RunByDefault)
      this.m_Move *= 0.5f;
    if (Input.GetKey(KeyCode.LeftShift))
    {
      if (bl_ThirdPersonUserControl.RunByDefault)
        this.m_Move *= 0.5f;
      else
        this.m_Move /= 0.5f;
    }
    if (this.CanMove)
    {
      if (!this.FirstPerson)
      {
        if (this.Aiming)
          this.m_Character.Move1st(this.m_Move, this.m_Jump);
        else
          this.m_Character.Move(this.m_Move, this.m_Jump);
      }
      else
        this.m_Character.Move1st(this.m_Move, this.m_Jump);
    }
    this.m_Jump = false;
  }

  public void StopMoving()
  {
    this.m_Character.m_Animator.SetFloat("Forward", 0.0f);
    this.m_Character.m_Animator.SetFloat("Turn", 0.0f);
    this.m_Character.m_Rigidbody.velocity = Vector3.zero;
  }

  public void UnstuckPlayer()
  {
    this.NavMesh.enabled = true;
    this.Invoke("UnstuckPlayer_fr", 0.1f);
  }

  public void UnstuckPlayer_fr() => this.NavMesh.enabled = false;

  public enum MeleeOptions
  {
    None,
    Punch,
    ThrowDown,
    Max,
  }

  public enum MeleeWeaponOptions
  {
    Knockout,
    Kill,
    Max,
  }

  public enum e_ThirdCamPositionType
  {
    Right,
    Left,
    Back,
    MAX,
  }
}
