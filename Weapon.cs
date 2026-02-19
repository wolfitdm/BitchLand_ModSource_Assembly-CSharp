// Decompiled with JetBrains decompiler
// Type: Weapon
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using DitzelGames.FastIK;
using KevinIglesias;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Weapon : SaveableBehaviour
{
  public e_MiningTool ThisToolType;
  public Vector3 OrgScale = new Vector3(1f, 1f, 1f);
  public Collider[] WeaponCollider;
  public Rigidbody WeaponRigid;
  public AudioSource WeaponAudioSource;
  public bool IsFiring;
  public GameObject LODHigh;
  public GameObject LODLow;
  public Vector3 PickupPosition;
  public Vector3 PickupRotation;
  public Vector3 Aiming_PickupPosition;
  public Vector3 Aiming_PickupRotation;
  public WeaponHoldingType HoldingType;
  public Transform ActualWeaponModel;
  public string PrefabName;
  public Interactible int_Drag;
  public bool LeftHandIK;
  public bool RightHandIK;
  public Transform HandSpot;
  public IKHelperTool[] IKs;
  public FastIKFabric IK;
  public Vector3 RightHandRotation;
  public Vector3 Holdster1Position;
  public Vector3 Holdster1Rotation;
  public Vector3 Holdster2Position;
  public Vector3 Holdster2Rotation;
  [Header("Originals ---------------------")]
  public WeaponType type;
  public bool shooterAIEnabled;
  public bool bloodyMessEnabled;
  public int weaponType;
  public Auto auto;
  public bool playerWeapon;
  public GameObject weaponModel;
  public Transform raycastStartSpot;
  public float delayBeforeFire;
  public bool warmup;
  public float maxWarmup = 2f;
  public bool multiplyForce = true;
  public bool multiplyPower;
  public float powerMultiplier = 1f;
  public float initialForceMultiplier = 1f;
  public bool allowCancel;
  public float heat;
  public GameObject projectile;
  public Transform projectileSpawnSpot;
  public bool reflect = true;
  public Material reflectionMaterial;
  public int maxReflections = 5;
  public string beamTypeName = "laser_beam";
  public float maxBeamHeat = 1f;
  public bool infiniteBeam;
  public Material beamMaterial;
  public Color beamColor = Color.red;
  public float startBeamWidth = 0.5f;
  public float endBeamWidth = 1f;
  public float beamHeat;
  public bool coolingDown;
  public GameObject beamGO;
  public bool beaming;
  public float power = 80f;
  public float forceMultiplier = 10f;
  public float beamPower = 1f;
  public float range = 9999f;
  public float rateOfFire = 10f;
  public float actualROF;
  public float fireTimer;
  public bool infiniteAmmo;
  public int ammoCapacity = 12;
  public int shotPerRound = 1;
  public int _currentAmmo;
  public float reloadTime = 2f;
  public bool showCurrentAmmo = true;
  public bool reloadAutomatically = true;
  public float accuracy = 80f;
  public float currentAccuracy;
  public float accuracyDropPerShot = 1f;
  public float accuracyRecoverRate = 0.1f;
  public int burstRate = 3;
  public float burstPause;
  public int burstCounter;
  public float burstTimer;
  public bool recoil = true;
  public float recoilKickBackMin = 0.1f;
  public float recoilKickBackMax = 0.3f;
  public float recoilRotationMin = 0.1f;
  public float recoilRotationMax = 0.25f;
  public float recoilRecoveryRate = 0.01f;
  public bool spitShells;
  public GameObject shell;
  public float shellSpitForce = 1f;
  public float shellForceRandom = 0.5f;
  public float shellSpitTorqueX;
  public float shellSpitTorqueY;
  public float shellTorqueRandom = 1f;
  public Transform shellSpitPosition;
  public bool makeMuzzleEffects = true;
  public bool makeMuzzleEffects_parent;
  public GameObject[] muzzleEffects = new GameObject[1];
  public Transform muzzleEffectsPosition;
  public bool makeHitEffects = true;
  public GameObject[] hitEffects = new GameObject[1];
  public bool makeBulletHoles = true;
  public BulletHoleSystem bhSystem;
  public List<string> bulletHolePoolNames = new List<string>();
  public List<string> defaultBulletHolePoolNames = new List<string>();
  public List<SmartBulletHoleGroup> bulletHoleGroups = new List<SmartBulletHoleGroup>();
  public List<BulletHolePool> defaultBulletHoles = new List<BulletHolePool>();
  public List<SmartBulletHoleGroup> bulletHoleExceptions = new List<SmartBulletHoleGroup>();
  public bool showCrosshair = true;
  public Texture2D crosshairTexture;
  public int crosshairLength = 10;
  public int crosshairWidth = 4;
  public float startingCrosshairSize = 10f;
  public float currentCrosshairSize;
  public AudioClip fireSound;
  public AudioClip[] fireSounds;
  public AudioClip ContinuousFireSound;
  public AudioClip reloadSound;
  public AudioClip dryFireSound;
  public bool canFire = true;
  public bool Fireing;
  public bool canDrop = true;
  public WeaponSystem _WeaponSystem;
  public bool UnparentOnStart = true;
  public bool _Started;
  public bool RaycaterOnGun;
  public bool WeaponInRelax;
  private float impactEndTime;
  private Rigidbody impactTarget;
  private Vector3 impact;
  public bool IsActualPickaxe;
  public Action OnEndOfShoot;

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(Main.Vector32Str(this.transform.position));
    stringList.Add(Main.Vector32Str(this.transform.eulerAngles));
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    this._CurrentLoadingIndex = 1;
    this.transform.position = Main.ParseVector3(Data[this._CurrentLoadingIndex++]);
    this.transform.eulerAngles = Main.ParseVector3(Data[this._CurrentLoadingIndex++]);
  }

  public int currentAmmo
  {
    get => this._currentAmmo;
    set
    {
      this._currentAmmo = value;
      if (!this.playerWeapon)
        return;
      Main.Instance.GameplayMenu.UpdateAmmo();
    }
  }

  public bool PickedUp => (UnityEngine.Object) this._WeaponSystem != (UnityEngine.Object) null;

  public new void Start()
  {
    if (this._Started)
      return;
    this._Started = true;
    if (this.UnparentOnStart)
      this.transform.SetParent((Transform) null);
    this.OrgScale = this.transform.localScale;
    this.currentCrosshairSize = this.startingCrosshairSize;
    this.fireTimer = 0.0f;
    this.currentAmmo = this.ammoCapacity;
    if ((UnityEngine.Object) this.raycastStartSpot == (UnityEngine.Object) null)
      this.raycastStartSpot = this.gameObject.transform;
    if ((UnityEngine.Object) this.muzzleEffectsPosition == (UnityEngine.Object) null)
      this.muzzleEffectsPosition = this.gameObject.transform;
    if ((UnityEngine.Object) this.projectileSpawnSpot == (UnityEngine.Object) null)
      this.projectileSpawnSpot = this.gameObject.transform;
    if ((UnityEngine.Object) this.weaponModel == (UnityEngine.Object) null)
      this.weaponModel = this.gameObject;
    if ((UnityEngine.Object) this.crosshairTexture == (UnityEngine.Object) null)
      this.crosshairTexture = new Texture2D(0, 0);
    for (int index = 0; index < this.bulletHolePoolNames.Count; ++index)
    {
      GameObject gameObject = GameObject.Find(this.bulletHolePoolNames[index]);
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null && (UnityEngine.Object) gameObject.GetComponent<BulletHolePool>() != (UnityEngine.Object) null)
        this.bulletHoleGroups[index].bulletHole = gameObject.GetComponent<BulletHolePool>();
      else
        Debug.LogWarning((object) "Bullet Hole Pool does not exist or does not have a BulletHolePool component.  Please assign GameObjects in the inspector that have the BulletHolePool component.");
    }
    for (int index = 0; index < this.defaultBulletHolePoolNames.Count; ++index)
    {
      GameObject gameObject = GameObject.Find(this.defaultBulletHolePoolNames[index]);
      if ((UnityEngine.Object) gameObject.GetComponent<BulletHolePool>() != (UnityEngine.Object) null)
        this.defaultBulletHoles[index] = gameObject.GetComponent<BulletHolePool>();
      else
        Debug.LogWarning((object) "Default Bullet Hole Pool does not have a BulletHolePool component.  Please assign GameObjects in the inspector that have the BulletHolePool component.");
    }
  }

  public void OnPickup()
  {
    this.enabled = true;
    for (int index = 0; index < this.WeaponCollider.Length; ++index)
      this.WeaponCollider[index].enabled = false;
    this.WeaponRigid.isKinematic = true;
    if ((UnityEngine.Object) this.WeaponAudioSource != (UnityEngine.Object) null)
      this.WeaponAudioSource.enabled = true;
    this.playerWeapon = this._WeaponSystem.isPlayer;
    if (this.playerWeapon)
    {
      this.RaycaterOnGun = false;
      if ((UnityEngine.Object) this.raycastStartSpot != (UnityEngine.Object) null)
      {
        this.raycastStartSpot.SetParent(this._WeaponSystem.transform, true);
        this.raycastStartSpot.localPosition = Vector3.zero;
        this.raycastStartSpot.localEulerAngles = Vector3.zero;
      }
    }
    else
    {
      this.RaycaterOnGun = true;
      if ((UnityEngine.Object) this.raycastStartSpot != (UnityEngine.Object) null)
      {
        this.raycastStartSpot.SetParent(this.projectileSpawnSpot, true);
        this.raycastStartSpot.localPosition = Vector3.zero;
        this.raycastStartSpot.localEulerAngles = Vector3.zero;
      }
    }
    this._WeaponSystem.SetActiveWeapon(this.gameObject);
  }

  public void SetInRelax()
  {
    if (this.WeaponInRelax)
      return;
    if (this._WeaponSystem.ThisPerson.IsPlayer)
      this._WeaponSystem.ThisPerson.UserControl.SetupForWeaponAim = false;
    this.WeaponInRelax = true;
    this.ActualWeaponModel.SetParent(this._WeaponSystem.ThisPerson.RightHandStuff, true);
    this.ActualWeaponModel.localPosition = this.PickupPosition;
    this.ActualWeaponModel.localEulerAngles = this.PickupRotation;
    if (!((UnityEngine.Object) this._WeaponSystem.ThisPerson.LeftArmIK != (UnityEngine.Object) null))
      return;
    if (this.LeftHandIK)
    {
      this._WeaponSystem.ThisPerson.LeftArmIK.Target.SetParent(this._WeaponSystem.ThisPerson.transform);
      this._WeaponSystem.ThisPerson.LeftArmIK.enabled = false;
    }
    if (!this.RightHandIK)
      return;
    this._WeaponSystem.ThisPerson.RightArmIK.Target.SetParent(this._WeaponSystem.ThisPerson.transform);
    this._WeaponSystem.ThisPerson.RightArmIK.enabled = false;
  }

  public void SetInAiming()
  {
    if (!this.WeaponInRelax)
      return;
    this.WeaponInRelax = false;
    if (this._WeaponSystem.ThisPerson.IsPlayer)
      this._WeaponSystem.ThisPerson.UserControl.SetupForWeaponAim = true;
    if (this.LeftHandIK)
    {
      this.ActualWeaponModel.SetParent(this._WeaponSystem.ThisPerson.RightHandStuff, true);
      this.ActualWeaponModel.localPosition = this.Aiming_PickupPosition;
      this.ActualWeaponModel.localEulerAngles = this.Aiming_PickupRotation;
      if ((UnityEngine.Object) this._WeaponSystem.ThisPerson.LeftArmIK != (UnityEngine.Object) null)
      {
        this._WeaponSystem.ThisPerson.LeftArmIK.Target.SetParent(this.HandSpot);
        this._WeaponSystem.ThisPerson.LeftArmIK.Target.localPosition = Vector3.zero;
        this._WeaponSystem.ThisPerson.LeftArmIK.Target.localEulerAngles = Vector3.zero;
        this._WeaponSystem.ThisPerson.LeftArmIK.Pole.localPosition = new Vector3(-0.425f, 1.034f, -0.445f);
        this._WeaponSystem.ThisPerson.LeftArmIK.enabled = true;
      }
    }
    if (!this.RightHandIK)
      return;
    this.ActualWeaponModel.SetParent(this._WeaponSystem.ThisPerson.LeftHandStuff, true);
    this.ActualWeaponModel.localPosition = this.Aiming_PickupPosition;
    this.ActualWeaponModel.localEulerAngles = this.Aiming_PickupRotation;
    if (!((UnityEngine.Object) this._WeaponSystem.ThisPerson.RightArmIK != (UnityEngine.Object) null))
      return;
    this._WeaponSystem.ThisPerson.RightArmIK.Target.SetParent(this.HandSpot);
    this._WeaponSystem.ThisPerson.RightArmIK.Target.localPosition = Vector3.zero;
    this._WeaponSystem.ThisPerson.RightArmIK.Target.localEulerAngles = Vector3.zero;
    this._WeaponSystem.ThisPerson.RightArmIK.Pole.localPosition = new Vector3(0.425f, 1.034f, -0.445f);
    this._WeaponSystem.ThisPerson.RightArmIK.enabled = true;
  }

  public bool CanHoldster()
  {
    for (int index = 0; index < this._WeaponSystem.weapons.Count; ++index)
    {
      if ((UnityEngine.Object) this._WeaponSystem.weapons[index] == (UnityEngine.Object) null)
        return true;
    }
    return false;
  }

  public void Holdster()
  {
    for (int index = 0; index < this._WeaponSystem.weapons.Count; ++index)
    {
      if ((UnityEngine.Object) this._WeaponSystem.weapons[index] == (UnityEngine.Object) null)
      {
        this._WeaponSystem.SetActiveWeapon(index);
        break;
      }
    }
  }

  public void SetInHoldster1()
  {
    this.gameObject.SetActive(false);
    this.ActualWeaponModel.gameObject.SetActive(true);
    if (this.HoldingType == WeaponHoldingType.Pistol)
      this.ActualWeaponModel.SetParent(this._WeaponSystem.ThisPerson.ActualHips);
    else
      this.ActualWeaponModel.SetParent(this._WeaponSystem.ThisPerson.Torso);
    this.ActualWeaponModel.localPosition = this.Holdster1Position;
    this.ActualWeaponModel.localEulerAngles = this.Holdster1Rotation;
  }

  public void SetInHoldster2()
  {
    this.gameObject.SetActive(false);
    this.ActualWeaponModel.gameObject.SetActive(true);
    if (this.HoldingType == WeaponHoldingType.Pistol)
      this.ActualWeaponModel.SetParent(this._WeaponSystem.ThisPerson.ActualHips);
    else
      this.ActualWeaponModel.SetParent(this._WeaponSystem.ThisPerson.Torso);
    this.ActualWeaponModel.localPosition = this.Holdster2Position;
    this.ActualWeaponModel.localEulerAngles = this.Holdster2Rotation;
  }

  private void Update()
  {
    this.currentAccuracy = Mathf.Lerp(this.currentAccuracy, this.accuracy, this.accuracyRecoverRate * Time.deltaTime);
    this.currentCrosshairSize = this.startingCrosshairSize + (float) (((double) this.accuracy - (double) this.currentAccuracy) * 0.800000011920929);
    this.fireTimer += Time.deltaTime;
    if (this.playerWeapon)
      this.CheckForUserInput();
    if (this.reloadAutomatically && this.currentAmmo <= 0)
      this.Reload();
    if (this.playerWeapon && this.recoil && this.type != WeaponType.Beam)
    {
      this.weaponModel.transform.position = Vector3.Lerp(this.weaponModel.transform.position, this.transform.position, this.recoilRecoveryRate * Time.deltaTime);
      this.weaponModel.transform.rotation = Quaternion.Lerp(this.weaponModel.transform.rotation, this.transform.rotation, this.recoilRecoveryRate * Time.deltaTime);
    }
    if (this.type != WeaponType.Beam)
      return;
    if (!this.beaming)
      this.StopBeam();
    this.beaming = false;
  }

  private void LateUpdate()
  {
    if (this.type != WeaponType.Raycast || !this.playerWeapon || !Main.Instance.Player.UserControl.Aiming && (!Main.Instance.Player.UserControl.FirstPerson || Main.Instance.Player.UserControl.m_Character.StandState != bl_ThirdPersonCharacter.bl_StandState.Standing))
      return;
    Main.Instance.Player.UserControl.SpineBonesToRotate[0].LookAt(Main.Instance.Player.UserControl.SpineAimSpot);
  }

  private void CheckForUserInput()
  {
    if (Main.Instance.GameplayMenu.JournalMenu.activeSelf || Main.Instance.GameplayMenu.ContainerStorage.activeSelf || Main.Instance.Player.Interacting)
      return;
    if (this.type == WeaponType.Raycast)
    {
      if ((UnityEngine.Object) this.ContinuousFireSound != (UnityEngine.Object) null)
      {
        if (Input.GetMouseButtonDown(UI_Settings.LeftMouseButton))
          this.WeaponAudioSource.Play();
        else if (Input.GetMouseButtonUp(UI_Settings.LeftMouseButton))
          this.WeaponAudioSource.Stop();
      }
      if ((double) this.fireTimer >= (double) this.actualROF && this.burstCounter < this.burstRate && this.canFire)
      {
        if (Input.GetMouseButton(UI_Settings.LeftMouseButton))
        {
          if (!this.warmup)
            this.Fire();
          else if ((double) this.heat < (double) this.maxWarmup)
            this.heat += Time.deltaTime;
        }
        if (this.warmup && Input.GetMouseButtonUp(UI_Settings.LeftMouseButton))
        {
          if (this.allowCancel && Input.GetButton("Cancel"))
            this.heat = 0.0f;
          else
            this.Fire();
        }
      }
    }
    if (this.type == WeaponType.Projectile && (double) this.fireTimer >= (double) this.actualROF && this.burstCounter < this.burstRate && this.canFire)
    {
      if (Input.GetMouseButton(UI_Settings.LeftMouseButton))
      {
        if (!this.warmup)
          this.Launch();
        else if ((double) this.heat < (double) this.maxWarmup)
          this.heat += Time.deltaTime;
      }
      if (this.warmup && Input.GetMouseButtonUp(UI_Settings.LeftMouseButton))
      {
        if (this.allowCancel && Input.GetButton("Cancel"))
          this.heat = 0.0f;
        else
          this.Launch();
      }
    }
    if (this.burstCounter >= this.burstRate)
    {
      this.burstTimer += Time.deltaTime;
      if ((double) this.burstTimer >= (double) this.burstPause)
      {
        this.burstCounter = 0;
        this.burstTimer = 0.0f;
      }
    }
    if (this.type == WeaponType.Beam)
    {
      if (Input.GetMouseButton(UI_Settings.LeftMouseButton) && (double) this.beamHeat <= (double) this.maxBeamHeat && !this.coolingDown)
        this.Beam();
      else
        this.StopBeam();
      if ((double) this.beamHeat >= (double) this.maxBeamHeat)
        this.coolingDown = true;
      else if ((double) this.beamHeat <= (double) this.maxBeamHeat - (double) this.maxBeamHeat / 2.0)
        this.coolingDown = false;
    }
    if (this.type == WeaponType.Melee && !this.Fireing && this.canFire)
      Input.GetMouseButton(UI_Settings.LeftMouseButton);
    if (Input.GetButtonDown("Reload"))
      this.Reload();
    if (!Input.GetMouseButtonUp(UI_Settings.LeftMouseButton))
      return;
    this.canFire = true;
  }

  public void RemoteFire() => this.AIFiring();

  public void AIFiring()
  {
    if (this.type == WeaponType.Raycast && (double) this.fireTimer >= (double) this.actualROF && this.burstCounter < this.burstRate)
    {
      this.canFire = true;
      this.StartCoroutine(this.DelayFire());
    }
    if (this.type == WeaponType.Projectile && (double) this.fireTimer >= (double) this.actualROF && this.canFire)
      this.StartCoroutine(this.DelayLaunch());
    if (this.burstCounter >= this.burstRate)
    {
      this.burstTimer += Time.deltaTime;
      if ((double) this.burstTimer >= (double) this.burstPause)
      {
        this.burstCounter = 0;
        this.burstTimer = 0.0f;
      }
    }
    if (this.type != WeaponType.Beam)
      return;
    if ((double) this.beamHeat <= (double) this.maxBeamHeat && !this.coolingDown)
      this.Beam();
    else
      this.StopBeam();
    if ((double) this.beamHeat >= (double) this.maxBeamHeat)
    {
      this.coolingDown = true;
    }
    else
    {
      if ((double) this.beamHeat > (double) this.maxBeamHeat - (double) this.maxBeamHeat / 2.0)
        return;
      this.coolingDown = false;
    }
  }

  private IEnumerator DelayFire()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    Weapon weapon = this;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      weapon.Fire();
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    weapon.fireTimer = 0.0f;
    ++weapon.burstCounter;
    weapon.SendMessageUpwards("OnEasyWeaponsFire", SendMessageOptions.DontRequireReceiver);
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E2__current = (object) new WaitForSeconds(weapon.delayBeforeFire);
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }

  private IEnumerator DelayLaunch()
  {
    Weapon weapon = this;
    weapon.fireTimer = 0.0f;
    ++weapon.burstCounter;
    if (weapon.auto == Auto.Semi)
      weapon.canFire = false;
    weapon.SendMessageUpwards("OnEasyWeaponsLaunch", SendMessageOptions.DontRequireReceiver);
    yield return (object) new WaitForSeconds(weapon.delayBeforeFire);
    weapon.Launch();
  }

  private IEnumerator DelayBeam()
  {
    yield return (object) new WaitForSeconds(this.delayBeforeFire);
    this.Beam();
  }

  private void OnGUI()
  {
    if (!this.playerWeapon)
      return;
    if (this.type == WeaponType.Projectile || this.type == WeaponType.Beam)
      this.currentAccuracy = this.accuracy;
    if (!this.showCrosshair)
      return;
    Vector2 vector2 = new Vector2((float) (Screen.width / 2), (float) (Screen.height / 2));
    GUI.DrawTexture(new Rect(vector2.x - (float) this.crosshairLength - this.currentCrosshairSize, vector2.y - (float) (this.crosshairWidth / 2), (float) this.crosshairLength, (float) this.crosshairWidth), (Texture) this.crosshairTexture, ScaleMode.StretchToFill);
    GUI.DrawTexture(new Rect(vector2.x + this.currentCrosshairSize, vector2.y - (float) (this.crosshairWidth / 2), (float) this.crosshairLength, (float) this.crosshairWidth), (Texture) this.crosshairTexture, ScaleMode.StretchToFill);
    GUI.DrawTexture(new Rect(vector2.x - (float) (this.crosshairWidth / 2), vector2.y - (float) this.crosshairLength - this.currentCrosshairSize, (float) this.crosshairWidth, (float) this.crosshairLength), (Texture) this.crosshairTexture, ScaleMode.StretchToFill);
    GUI.DrawTexture(new Rect(vector2.x - (float) (this.crosshairWidth / 2), vector2.y + this.currentCrosshairSize, (float) this.crosshairWidth, (float) this.crosshairLength), (Texture) this.crosshairTexture, ScaleMode.StretchToFill);
  }

  public void Fire()
  {
    if (this.playerWeapon && FirstPersonCharacter.AllowMouseCursor && Cursor.visible)
      return;
    if (this.playerWeapon)
    {
      if (this.RaycaterOnGun)
      {
        this.RaycaterOnGun = false;
        this.raycastStartSpot.SetParent(this._WeaponSystem.transform, true);
        this.raycastStartSpot.localPosition = Vector3.zero;
        this.raycastStartSpot.localEulerAngles = Vector3.zero;
      }
    }
    else if ((UnityEngine.Object) this._WeaponSystem.ThisPerson.EnemyFighting != (UnityEngine.Object) null && (UnityEngine.Object) this._WeaponSystem.ThisPerson.EnemyFighting.PersonComponent != (UnityEngine.Object) null && (UnityEngine.Object) this._WeaponSystem.ThisPerson.EnemyFighting.PersonComponent.Torso != (UnityEngine.Object) null)
      this.raycastStartSpot.LookAt(this._WeaponSystem.ThisPerson.EnemyFighting.PersonComponent.Torso);
    this.fireTimer = 0.0f;
    ++this.burstCounter;
    if (this.auto == Auto.Semi)
      this.canFire = false;
    if (this.currentAmmo <= 0)
    {
      this.DryFire();
    }
    else
    {
      if (!this.infiniteAmmo)
        --this.currentAmmo;
      for (int index = 0; index < this.shotPerRound; ++index)
      {
        float maxInclusive = (float) ((100.0 - (double) this.currentAccuracy) / 1000.0);
        Vector3 forward = this.raycastStartSpot.forward;
        forward.x += UnityEngine.Random.Range(-maxInclusive, maxInclusive);
        forward.y += UnityEngine.Random.Range(-maxInclusive, maxInclusive);
        forward.z += UnityEngine.Random.Range(-maxInclusive, maxInclusive);
        this.currentAccuracy -= this.accuracyDropPerShot;
        if ((double) this.currentAccuracy <= 0.0)
          this.currentAccuracy = 0.0f;
        Ray ray = new Ray(this.raycastStartSpot.position, forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, this.range, int.MaxValue, QueryTriggerInteraction.Ignore))
        {
          float power = this.power;
          if (this.warmup)
          {
            power *= this.heat * this.powerMultiplier;
            this.heat = 0.0f;
          }
          LimbHitbox component = hitInfo.transform.GetComponent<LimbHitbox>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          {
            if (this.playerWeapon && (UnityEngine.Object) component.PersonHealth.PersonComponent != (UnityEngine.Object) null && component.PersonHealth.PersonComponent.IsPlayer)
              return;
            if ((double) this.power != 0.0)
            {
              component.PersonHealth.ChangeHealth(-power, component.VitalLimb, this._WeaponSystem.ThisPerson);
              if ((UnityEngine.Object) component.PersonHealth.PersonComponent != (UnityEngine.Object) null)
              {
                if ((UnityEngine.Object) component.PersonHealth.ThisWeaponSystem.Blood != (UnityEngine.Object) null)
                  UnityEngine.Object.Instantiate<GameObject>(component.PersonHealth.ThisWeaponSystem.Blood, hitInfo.point, Quaternion.identity);
                this._WeaponSystem.ThisPerson.OnWeaponFire(component.PersonHealth.PersonComponent);
              }
            }
          }
          if (this.shooterAIEnabled)
            hitInfo.transform.root.SendMessage("Damage", (object) (float) ((double) power / 100.0), SendMessageOptions.DontRequireReceiver);
          if (this.bloodyMessEnabled && hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Limb"))
          {
            Vector3 vector3 = hitInfo.collider.transform.position - this.transform.position;
          }
          bool flag = false;
          if (this.bhSystem == BulletHoleSystem.Tag)
          {
            foreach (SmartBulletHoleGroup bulletHoleException in this.bulletHoleExceptions)
            {
              if (hitInfo.collider.gameObject.tag == bulletHoleException.tag)
              {
                flag = true;
                break;
              }
            }
          }
          else if (this.bhSystem == BulletHoleSystem.Material)
          {
            foreach (SmartBulletHoleGroup bulletHoleException in this.bulletHoleExceptions)
            {
              MeshRenderer meshRenderer = this.FindMeshRenderer(hitInfo.collider.gameObject);
              if ((UnityEngine.Object) meshRenderer != (UnityEngine.Object) null && (UnityEngine.Object) meshRenderer.sharedMaterial == (UnityEngine.Object) bulletHoleException.material)
              {
                flag = true;
                break;
              }
            }
          }
          else if (this.bhSystem == BulletHoleSystem.Physic_Material)
          {
            foreach (SmartBulletHoleGroup bulletHoleException in this.bulletHoleExceptions)
            {
              if ((UnityEngine.Object) hitInfo.collider.sharedMaterial == (UnityEngine.Object) bulletHoleException.physicMaterial)
              {
                flag = true;
                break;
              }
            }
          }
          if (this.makeBulletHoles && !flag)
          {
            List<SmartBulletHoleGroup> smartBulletHoleGroupList1 = new List<SmartBulletHoleGroup>();
            if (this.bhSystem == BulletHoleSystem.Tag)
            {
              foreach (SmartBulletHoleGroup bulletHoleGroup in this.bulletHoleGroups)
              {
                if (hitInfo.collider.gameObject.tag == bulletHoleGroup.tag)
                  smartBulletHoleGroupList1.Add(bulletHoleGroup);
              }
            }
            else if (this.bhSystem == BulletHoleSystem.Material)
            {
              MeshRenderer meshRenderer = this.FindMeshRenderer(hitInfo.collider.gameObject);
              foreach (SmartBulletHoleGroup bulletHoleGroup in this.bulletHoleGroups)
              {
                if ((UnityEngine.Object) meshRenderer != (UnityEngine.Object) null && (UnityEngine.Object) meshRenderer.sharedMaterial == (UnityEngine.Object) bulletHoleGroup.material)
                  smartBulletHoleGroupList1.Add(bulletHoleGroup);
              }
            }
            else if (this.bhSystem == BulletHoleSystem.Physic_Material)
            {
              foreach (SmartBulletHoleGroup bulletHoleGroup in this.bulletHoleGroups)
              {
                if ((UnityEngine.Object) hitInfo.collider.sharedMaterial == (UnityEngine.Object) bulletHoleGroup.physicMaterial)
                  smartBulletHoleGroupList1.Add(bulletHoleGroup);
              }
            }
            SmartBulletHoleGroup smartBulletHoleGroup;
            if (smartBulletHoleGroupList1.Count == 0)
            {
              List<SmartBulletHoleGroup> smartBulletHoleGroupList2 = new List<SmartBulletHoleGroup>();
              foreach (BulletHolePool defaultBulletHole in this.defaultBulletHoles)
                smartBulletHoleGroupList2.Add(new SmartBulletHoleGroup("Default", (Material) null, (PhysicMaterial) null, defaultBulletHole));
              smartBulletHoleGroup = smartBulletHoleGroupList2[UnityEngine.Random.Range(0, smartBulletHoleGroupList2.Count)];
            }
            else
              smartBulletHoleGroup = smartBulletHoleGroupList1[UnityEngine.Random.Range(0, smartBulletHoleGroupList1.Count)];
            if ((UnityEngine.Object) smartBulletHoleGroup.bulletHole != (UnityEngine.Object) null)
              smartBulletHoleGroup.bulletHole.PlaceBulletHole(hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
          }
          if (this.makeHitEffects)
          {
            foreach (GameObject hitEffect in this.hitEffects)
            {
              if ((UnityEngine.Object) hitEffect != (UnityEngine.Object) null)
                UnityEngine.Object.Instantiate<GameObject>(hitEffect, hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
            }
          }
          if ((bool) (UnityEngine.Object) hitInfo.rigidbody)
            hitInfo.rigidbody.AddForce(ray.direction * this.power * this.forceMultiplier);
        }
      }
      if (this.recoil)
        this.Recoil();
      if (this.makeMuzzleEffects)
      {
        GameObject muzzleEffect = this.muzzleEffects[UnityEngine.Random.Range(0, this.muzzleEffects.Length)];
        if ((UnityEngine.Object) muzzleEffect != (UnityEngine.Object) null)
        {
          if (this.makeMuzzleEffects_parent)
            UnityEngine.Object.Instantiate<GameObject>(muzzleEffect, this.muzzleEffectsPosition);
          else
            UnityEngine.Object.Instantiate<GameObject>(muzzleEffect, this.muzzleEffectsPosition.position, this.muzzleEffectsPosition.rotation);
        }
      }
      if (this.spitShells)
      {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.shell, this.shellSpitPosition.position, this.shellSpitPosition.rotation);
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(this.shellSpitForce + UnityEngine.Random.Range(0.0f, this.shellForceRandom), 0.0f, 0.0f), ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(this.shellSpitTorqueX + UnityEngine.Random.Range(-this.shellTorqueRandom, this.shellTorqueRandom), this.shellSpitTorqueY + UnityEngine.Random.Range(-this.shellTorqueRandom, this.shellTorqueRandom), 0.0f), ForceMode.Impulse);
      }
      if (!((UnityEngine.Object) this.WeaponAudioSource != (UnityEngine.Object) null) || (UnityEngine.Object) this.ContinuousFireSound != (UnityEngine.Object) null && !this.WeaponAudioSource.isPlaying)
        return;
      if (this.fireSounds == null || this.fireSounds.Length == 0)
        this.WeaponAudioSource.PlayOneShot(this.fireSound);
      else
        this.WeaponAudioSource.PlayOneShot(this.fireSounds[UnityEngine.Random.Range(0, this.fireSounds.Length)]);
    }
  }

  public void Launch()
  {
    this.fireTimer = 0.0f;
    ++this.burstCounter;
    if (this.auto == Auto.Semi)
      this.canFire = false;
    if (this.currentAmmo <= 0)
    {
      this.DryFire();
    }
    else
    {
      if (!this.infiniteAmmo)
        --this.currentAmmo;
      for (int index = 0; index < this.shotPerRound; ++index)
      {
        if ((UnityEngine.Object) this.projectile != (UnityEngine.Object) null)
        {
          GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.projectile, this.projectileSpawnSpot.position, this.projectileSpawnSpot.rotation);
          Projectile component = gameObject.GetComponent<Projectile>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
            component.ThisPerson = this._WeaponSystem.ThisPerson;
          if (this.warmup)
          {
            if (this.multiplyPower)
              gameObject.SendMessage("MultiplyDamage", (object) (float) ((double) this.heat * (double) this.powerMultiplier), SendMessageOptions.DontRequireReceiver);
            if (this.multiplyForce)
              gameObject.SendMessage("MultiplyInitialForce", (object) (float) ((double) this.heat * (double) this.initialForceMultiplier), SendMessageOptions.DontRequireReceiver);
            this.heat = 0.0f;
          }
        }
        else
          Debug.Log((object) "Projectile to be instantiated is null.  Make sure to set the Projectile field in the inspector.");
      }
      if (this.recoil)
        this.Recoil();
      if (this.makeMuzzleEffects)
      {
        GameObject muzzleEffect = this.muzzleEffects[UnityEngine.Random.Range(0, this.muzzleEffects.Length)];
        if ((UnityEngine.Object) muzzleEffect != (UnityEngine.Object) null)
          UnityEngine.Object.Instantiate<GameObject>(muzzleEffect, this.muzzleEffectsPosition.position, this.muzzleEffectsPosition.rotation);
      }
      if (this.spitShells)
      {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.shell, this.shellSpitPosition.position, this.shellSpitPosition.rotation);
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(this.shellSpitForce + UnityEngine.Random.Range(0.0f, this.shellForceRandom), 0.0f, 0.0f), ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(this.shellSpitTorqueX + UnityEngine.Random.Range(-this.shellTorqueRandom, this.shellTorqueRandom), this.shellSpitTorqueY + UnityEngine.Random.Range(-this.shellTorqueRandom, this.shellTorqueRandom), 0.0f), ForceMode.Impulse);
      }
      if (!((UnityEngine.Object) this.WeaponAudioSource != (UnityEngine.Object) null))
        return;
      this.WeaponAudioSource.PlayOneShot(this.fireSound);
    }
  }

  private void Beam()
  {
    this.SendMessageUpwards("OnEasyWeaponsBeaming", SendMessageOptions.DontRequireReceiver);
    this.beaming = true;
    if (!this.infiniteBeam)
      this.beamHeat += Time.deltaTime;
    if ((UnityEngine.Object) this.beamGO == (UnityEngine.Object) null)
    {
      this.beamGO = new GameObject(this.beamTypeName, new System.Type[1]
      {
        typeof (LineRenderer)
      });
      this.beamGO.transform.parent = this.transform;
    }
    LineRenderer component = this.beamGO.GetComponent<LineRenderer>();
    component.material = this.beamMaterial;
    component.material.SetColor("_TintColor", this.beamColor);
    component.SetWidth(this.startBeamWidth, this.endBeamWidth);
    int num = 0;
    List<Vector3> vector3List = new List<Vector3>();
    vector3List.Add(this.raycastStartSpot.position);
    Vector3 origin1 = this.raycastStartSpot.position;
    bool flag = true;
    Ray ray = new Ray(origin1, this.raycastStartSpot.forward);
    RaycastHit hitInfo;
    do
    {
      Vector3 origin2 = ray.direction * this.range;
      if (Physics.Raycast(ray, out hitInfo, this.range))
      {
        origin2 = hitInfo.point;
        Vector3 direction = Vector3.Reflect(origin2 - origin1, hitInfo.normal);
        ray = new Ray(origin2, direction);
        origin1 = hitInfo.point;
        if (this.makeHitEffects)
        {
          foreach (GameObject hitEffect in this.hitEffects)
          {
            if ((UnityEngine.Object) hitEffect != (UnityEngine.Object) null)
              UnityEngine.Object.Instantiate<GameObject>(hitEffect, hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
          }
        }
        if (this.shooterAIEnabled)
          hitInfo.transform.SendMessageUpwards("Damage", (object) (float) ((double) this.beamPower / 100.0), SendMessageOptions.DontRequireReceiver);
        if (this.bloodyMessEnabled && hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Limb"))
        {
          Vector3 vector3 = hitInfo.collider.transform.position - this.transform.position;
        }
        ++num;
      }
      else
        flag = false;
      vector3List.Add(origin2);
    }
    while (flag && num < this.maxReflections && this.reflect && ((UnityEngine.Object) this.reflectionMaterial == (UnityEngine.Object) null || (UnityEngine.Object) this.FindMeshRenderer(hitInfo.collider.gameObject) != (UnityEngine.Object) null && (UnityEngine.Object) this.FindMeshRenderer(hitInfo.collider.gameObject).sharedMaterial == (UnityEngine.Object) this.reflectionMaterial));
    component.SetVertexCount(vector3List.Count);
    for (int index = 0; index < vector3List.Count; ++index)
    {
      component.SetPosition(index, vector3List[index]);
      if (this.makeMuzzleEffects && index > 0)
      {
        GameObject muzzleEffect = this.muzzleEffects[UnityEngine.Random.Range(0, this.muzzleEffects.Length)];
        if ((UnityEngine.Object) muzzleEffect != (UnityEngine.Object) null)
          UnityEngine.Object.Instantiate<GameObject>(muzzleEffect, vector3List[index], this.muzzleEffectsPosition.rotation);
      }
    }
    if (this.makeMuzzleEffects)
    {
      GameObject muzzleEffect = this.muzzleEffects[UnityEngine.Random.Range(0, this.muzzleEffects.Length)];
      if ((UnityEngine.Object) muzzleEffect != (UnityEngine.Object) null)
        UnityEngine.Object.Instantiate<GameObject>(muzzleEffect, this.muzzleEffectsPosition.position, this.muzzleEffectsPosition.rotation).transform.parent = this.raycastStartSpot;
    }
    if (!((UnityEngine.Object) this.WeaponAudioSource != (UnityEngine.Object) null) || this.WeaponAudioSource.isPlaying)
      return;
    this.WeaponAudioSource.clip = this.fireSound;
    this.WeaponAudioSource.Play();
  }

  public void StopBeam()
  {
    this.beamHeat -= Time.deltaTime;
    if ((double) this.beamHeat < 0.0)
      this.beamHeat = 0.0f;
    if ((UnityEngine.Object) this.WeaponAudioSource != (UnityEngine.Object) null)
      this.WeaponAudioSource.Stop();
    if ((UnityEngine.Object) this.beamGO != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.beamGO);
    this.SendMessageUpwards("OnEasyWeaponsStopBeaming", SendMessageOptions.DontRequireReceiver);
  }

  public void MeleeFire()
  {
    Debug.Log((object) "MeleeFire()");
    switch (this.HoldingType)
    {
      case WeaponHoldingType.Blunt:
        if (this.IsActualPickaxe)
        {
          this._WeaponSystem.ThisPerson.Anim.Play("Pickaxe");
          break;
        }
        this._WeaponSystem.ThisPerson.Anim.Play("MeleeAttackSwing");
        break;
      case WeaponHoldingType.PickAxe:
        this._WeaponSystem.ThisPerson.Anim.Play("Pickaxe");
        break;
    }
    this.canFire = false;
    this.canDrop = false;
    this.Fireing = true;
    this._WeaponSystem.ThisPerson.AddMoveBlocker("Pickaxe");
    this._WeaponSystem.ThisPerson.enabled = false;
    if (this.playerWeapon)
    {
      Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
      Main.Instance.MainThreads.Add(new Action(this.PlayerPickaxing));
    }
    else
      Main.Instance.MainThreads.Add(new Action(this.NPCPickaxing));
    if (!((UnityEngine.Object) this.WeaponAudioSource != (UnityEngine.Object) null) || !((UnityEngine.Object) this.fireSound != (UnityEngine.Object) null))
      return;
    this.WeaponAudioSource.PlayOneShot(this.fireSound);
  }

  public void PlayerPickaxing()
  {
    if (!((UnityEngine.Object) this._WeaponSystem == (UnityEngine.Object) null) && !((UnityEngine.Object) this._WeaponSystem.ThisPerson == (UnityEngine.Object) null) && (double) this._WeaponSystem.ThisPerson.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0)
    {
      Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = this._WeaponSystem.ThisPerson.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    else
    {
      Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
      Main.Instance.MainThreads.Remove(new Action(this.PlayerPickaxing));
      this.canFire = true;
      this.canDrop = true;
      this.Fireing = false;
      this._WeaponSystem.ThisPerson.RemoveMoveBlocker("Pickaxe");
      this._WeaponSystem.ThisPerson.enabled = true;
      if (this.OnEndOfShoot == null)
        return;
      this.OnEndOfShoot();
      this.OnEndOfShoot = (Action) null;
    }
  }

  public void NPCPickaxing()
  {
    if (!((UnityEngine.Object) this._WeaponSystem == (UnityEngine.Object) null) && !((UnityEngine.Object) this._WeaponSystem.ThisPerson == (UnityEngine.Object) null) && (double) this._WeaponSystem.ThisPerson.Anim.GetCurrentAnimatorStateInfo(0).length > (double) this._WeaponSystem.ThisPerson.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.NPCPickaxing));
    this.canFire = true;
    this.canDrop = true;
    this._WeaponSystem.ThisPerson.RemoveMoveBlocker("Pickaxe");
    this._WeaponSystem.ThisPerson.enabled = true;
  }

  private void Reload()
  {
    this.currentAmmo = this.ammoCapacity;
    this.fireTimer = -this.reloadTime;
    if ((UnityEngine.Object) this.WeaponAudioSource != (UnityEngine.Object) null)
      this.WeaponAudioSource.PlayOneShot(this.reloadSound);
    this.SendMessageUpwards("OnEasyWeaponsReload", SendMessageOptions.DontRequireReceiver);
  }

  private void DryFire()
  {
    if (!((UnityEngine.Object) this.WeaponAudioSource != (UnityEngine.Object) null))
      return;
    this.WeaponAudioSource.PlayOneShot(this.dryFireSound);
  }

  private void Recoil()
  {
    if (!this.playerWeapon)
      return;
    if ((UnityEngine.Object) this.weaponModel == (UnityEngine.Object) null)
    {
      Debug.Log((object) "Weapon Model is null.  Make sure to set the Weapon Model field in the inspector.");
    }
    else
    {
      float num1 = UnityEngine.Random.Range(this.recoilKickBackMin, this.recoilKickBackMax);
      float num2 = UnityEngine.Random.Range(this.recoilRotationMin, this.recoilRotationMax);
      this.weaponModel.transform.Translate(new Vector3(0.0f, 0.0f, -num1), Space.Self);
      this.weaponModel.transform.Rotate(new Vector3(-num2, 0.0f, 0.0f), Space.Self);
    }
  }

  private MeshRenderer FindMeshRenderer(GameObject go)
  {
    MeshRenderer meshRenderer;
    if ((UnityEngine.Object) go.GetComponent<Renderer>() != (UnityEngine.Object) null)
    {
      meshRenderer = go.GetComponent<MeshRenderer>();
    }
    else
    {
      meshRenderer = go.GetComponentInChildren<MeshRenderer>();
      if ((UnityEngine.Object) meshRenderer == (UnityEngine.Object) null)
      {
        for (GameObject gameObject = go; (UnityEngine.Object) meshRenderer == (UnityEngine.Object) null && (UnityEngine.Object) gameObject.transform != (UnityEngine.Object) gameObject.transform.root; meshRenderer = gameObject.GetComponent<MeshRenderer>())
          gameObject = gameObject.transform.parent.gameObject;
      }
    }
    return meshRenderer;
  }
}
