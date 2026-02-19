// Decompiled with JetBrains decompiler
// Type: bl_BodyPrepare
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using DitzelGames.FastIK;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#nullable disable
public class bl_BodyPrepare : MonoBehaviour
{
  public Vector3 HeadStuffScl;

  public Girl Prepare()
  {
    Debug.Log((object) "-------------------Prepare initiated");
    bl_editorrefs objectOfType = Object.FindObjectOfType<bl_editorrefs>();
    Transform transform1 = this.transform;
    Animator animator = transform1.gameObject.GetComponent<Animator>();
    if ((Object) animator == (Object) null)
      animator = transform1.gameObject.AddComponent<Animator>();
    Rigidbody rigidbody = transform1.gameObject.AddComponent<Rigidbody>();
    BoxCollider boxCollider1 = transform1.gameObject.AddComponent<BoxCollider>();
    CapsuleCollider capsuleCollider = transform1.gameObject.AddComponent<CapsuleCollider>();
    Girl girl = transform1.gameObject.AddComponent<Girl>();
    Health health = transform1.gameObject.AddComponent<Health>();
    NavMeshAgent navMeshAgent = transform1.gameObject.AddComponent<NavMeshAgent>();
    bl_LookAtPlayer blLookAtPlayer = transform1.gameObject.AddComponent<bl_LookAtPlayer>();
    int_Person intPerson = transform1.gameObject.AddComponent<int_Person>();
    bl_ragdollmanager blRagdollmanager = transform1.gameObject.AddComponent<bl_ragdollmanager>();
    foreach (Renderer componentsInChild in transform1.GetComponentsInChildren<MeshRenderer>())
      componentsInChild.enabled = false;
    capsuleCollider.enabled = false;
    SkinnedMeshRenderer skinnedMeshRenderer1 = (SkinnedMeshRenderer) null;
    Transform transform2 = transform1.Find("SkinnedMeshContainer");
    for (int index = 0; index < transform2.childCount; ++index)
    {
      Transform child = transform2.GetChild(index);
      switch (child.name)
      {
        case "o_body_cf":
          skinnedMeshRenderer1 = child.gameObject.GetComponent<SkinnedMeshRenderer>();
          skinnedMeshRenderer1.material = objectOfType.Mats[0];
          girl.CurrentBody = child.gameObject.AddComponent<Dressable>();
          girl.CurrentBody.BodyPart = DressableType.Body;
          break;
        case "o_eyebase_L":
        case "o_eyebase_R":
          child.gameObject.GetComponent<SkinnedMeshRenderer>().materials = new Material[2]
          {
            objectOfType.Mats[3],
            objectOfType.Mats[4]
          };
          break;
        case "o_eyelashes":
          child.gameObject.GetComponent<SkinnedMeshRenderer>().material = objectOfType.Mats[2];
          break;
        case "o_head":
          child.gameObject.GetComponent<SkinnedMeshRenderer>().material = objectOfType.Mats[1];
          girl.CurrentHead = child.gameObject.AddComponent<Dressable>();
          girl.CurrentHead.BodyPart = DressableType.Head;
          break;
        case "o_tang":
          child.gameObject.GetComponent<SkinnedMeshRenderer>().material = objectOfType.Mats[6];
          break;
        case "o_tooth":
          child.gameObject.GetComponent<SkinnedMeshRenderer>().material = objectOfType.Mats[5];
          break;
        default:
          child.gameObject.SetActive(false);
          break;
      }
    }
    animator.runtimeAnimatorController = objectOfType.GirlScript.Anim.runtimeAnimatorController;
    animator.applyRootMotion = true;
    animator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
    rigidbody.isKinematic = true;
    boxCollider1.center = new Vector3(0.0f, 1f, 0.0f);
    boxCollider1.size = new Vector3(1f / 1000f, 1f / 1000f, 1f / 1000f);
    capsuleCollider.center = new Vector3(0.0f, 1f, 0.0f);
    capsuleCollider.radius = 0.1f;
    capsuleCollider.height = 2f;
    capsuleCollider.direction = 1;
    navMeshAgent.enabled = false;
    navMeshAgent.speed = 4f;
    navMeshAgent.stoppingDistance = 0.1f;
    navMeshAgent.radius = 0.1f;
    navMeshAgent.height = 1.7f;
    navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
    blLookAtPlayer.enabled = false;
    blLookAtPlayer.ThisPerson = (Person) girl;
    blLookAtPlayer.headFrontTransform = transform1.Find("BodyTop/p_cf_anim/cf_J_Root/cf_N_height/cf_J_Hips/cf_J_Spine01/cf_J_Spine02/cf_J_Spine03/cf_J_Neck");
    blLookAtPlayer.headTransform = transform1.Find("BodyTop/p_cf_anim/cf_J_Root/cf_N_height/cf_J_Hips/cf_J_Spine01/cf_J_Spine02/cf_J_Spine03/cf_J_Neck/cf_J_Head");
    blLookAtPlayer.eyeTransforms = new Transform[2]
    {
      transform1.Find("BodyTop/p_cf_anim/cf_J_Root/cf_N_height/cf_J_Hips/cf_J_Spine01/cf_J_Spine02/cf_J_Spine03/cf_J_Neck/cf_J_Head/cf_J_Head_s/p_cf_head_bone/cf_J_FaceRoot/cf_J_FaceBase/cf_J_FaceUp_ty/cf_J_FaceUp_tz/cf_J_Eye_t_L/cf_J_Eye_s_L/cf_J_EyePos_rz_L"),
      transform1.Find("BodyTop/p_cf_anim/cf_J_Root/cf_N_height/cf_J_Hips/cf_J_Spine01/cf_J_Spine02/cf_J_Spine03/cf_J_Neck/cf_J_Head/cf_J_Head_s/p_cf_head_bone/cf_J_FaceRoot/cf_J_FaceBase/cf_J_FaceUp_ty/cf_J_FaceUp_tz/cf_J_Eye_t_R/cf_J_Eye_s_R/cf_J_EyePos_rz_R")
    };
    blLookAtPlayer.maxDistance = 3f;
    intPerson.SetInteracting = false;
    intPerson.CanLeave = false;
    intPerson.InteractText = "Talk";
    intPerson.RootObj = girl.gameObject;
    intPerson.ThisPerson = (Person) girl;
    intPerson.StartTalkMono = (MonoBehaviour) intPerson;
    intPerson.StartTalkFunc = "DefaultTalk";
    blRagdollmanager.enabled = false;
    blRagdollmanager.ThisGirl = girl;
    health.PersonComponent = (Person) girl;
    health.currentHealth = 100f;
    health.DisableScriptsWhenDie = new MonoBehaviour[2]
    {
      (MonoBehaviour) blLookAtPlayer,
      (MonoBehaviour) intPerson
    };
    health.ThisWeaponSystem = (WeaponSystem) null;
    health.Audio = (AudioSource) null;
    health.PainSounds = objectOfType.GirlScript.TheHealth.PainSounds;
    health.IncapacitatedSounds = objectOfType.GirlScript.TheHealth.IncapacitatedSounds;
    Transform transform3 = new GameObject("seencol").transform;
    transform3.SetParent(transform1);
    transform3.localPosition = new Vector3(0.0f, 1.473f, 0.0f);
    transform3.localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
    transform3.localScale = new Vector3(0.71716f, 0.71716f, 0.71716f);
    transform3.gameObject.layer = objectOfType.GirlScript.ProxSeen.gameObject.layer;
    girl.ProxSeen = transform3.gameObject.AddComponent<bl_ProxSeen>();
    BoxCollider boxCollider2 = transform3.gameObject.AddComponent<BoxCollider>();
    boxCollider2.isTrigger = true;
    boxCollider2.size = new Vector3(5f, 0.0f, 5f);
    Transform transform4 = new GameObject("LowPoly").transform;
    transform4.SetParent(transform1);
    transform4.localPosition = Vector3.zero;
    transform4.localEulerAngles = Vector3.zero;
    transform4.localScale = Vector3.one;
    SkinnedMeshRenderer skinnedMeshRenderer2 = transform4.gameObject.AddComponent<SkinnedMeshRenderer>();
    skinnedMeshRenderer2.quality = SkinQuality.Bone1;
    skinnedMeshRenderer2.bones = skinnedMeshRenderer1.bones;
    skinnedMeshRenderer2.sharedMaterials = skinnedMeshRenderer1.sharedMaterials;
    skinnedMeshRenderer2.sharedMesh = skinnedMeshRenderer1.sharedMesh;
    skinnedMeshRenderer2.rootBone = skinnedMeshRenderer1.rootBone;
    skinnedMeshRenderer2.skinnedMotionVectors = false;
    skinnedMeshRenderer2.enabled = false;
    girl.Head = transform1.Find("BodyTop/p_cf_anim/cf_J_Root/cf_N_height/cf_J_Hips/cf_J_Spine01/cf_J_Spine02/cf_J_Spine03/cf_J_Neck/cf_J_Head");
    girl.Neck = girl.Head.parent.Find("cf_J_Neck_s");
    girl.Torso = girl.Neck.parent.parent.Find("cf_J_Spine03_s");
    girl.Ribcage = girl.Torso.parent.parent.Find("cf_J_Spine02_s");
    girl.Waist = girl.Ribcage.parent.parent.Find("cf_J_Spine01_s");
    girl.ActualHips = girl.Waist.parent.parent;
    girl.Belly = girl.ActualHips.Find("cf_J_Kosi01/cf_J_Kosi01_s");
    girl.Hips = girl.ActualHips.Find("cf_J_Kosi01/cf_J_Kosi02");
    girl.Hips2 = girl.Hips.Find("cf_J_Kosi02_s");
    girl.LegLeft = girl.Hips.Find("cf_J_LegUp00_L");
    girl.LegRight = girl.Hips.Find("cf_J_LegUp00_R");
    girl.CalveLeft = girl.LegLeft.Find("cf_J_LegLow01_L");
    girl.CalveRight = girl.LegRight.Find("cf_J_LegLow01_R");
    girl.FootLeft = girl.CalveLeft.Find("cf_J_LegLowRoll_L/cf_J_Foot01_L");
    girl.FootRight = girl.CalveRight.Find("cf_J_LegLowRoll_R/cf_J_Foot01_R");
    girl.HeadStuff = Object.Instantiate<GameObject>(objectOfType.GirlScript.HeadStuff.gameObject, girl.Head).transform;
    girl.HeadStuff.localScale = this.HeadStuffScl;
    Transform parent = transform1.Find("BodyTop/p_cf_anim/cf_J_Root/cf_N_height/cf_J_Hips/cf_J_Kosi01");
    girl.Penis = Object.Instantiate<GameObject>(objectOfType.GirlScript.Penis, parent);
    girl.Penis.SetActive(false);
    girl.Anim = animator;
    girl.navMesh = navMeshAgent;
    girl._Rigidbody = rigidbody;
    girl.Eyes = (Vision) null;
    girl.TheHealth = health;
    girl.ThisPersonInt = intPerson;
    girl.RagdollManager = blRagdollmanager;
    girl.LOD = (CharacterLOD) null;
    girl.ViewPoint = girl.HeadStuff.Find("ViewPoint");
    girl.TorsoViewPoint = new GameObject("TorsoViewpoint").transform;
    girl.TorsoViewPoint.SetParent(girl.Torso);
    girl.TorsoViewPoint.localPosition = new Vector3(0.0f, 0.133f, 0.55f);
    girl.TorsoViewPoint.localEulerAngles = new Vector3(0.0f, -180f, 0.0f);
    girl.ViewCols = new Collider[1]
    {
      (Collider) girl.Head.gameObject.AddComponent<SphereCollider>()
    };
    ((SphereCollider) girl.ViewCols[0]).center = new Vector3(0.0f, 0.08f, 0.0f);
    ((SphereCollider) girl.ViewCols[0]).radius = 0.1f;
    girl.Head.gameObject.AddComponent<InteractRedirect>().Redirect = (Interactible) intPerson;
    girl.MainCol = girl.ViewCols[0];
    girl.HeadCol = girl.ViewCols[0];
    girl.Head.gameObject.layer = objectOfType.GirlScript.Head.gameObject.layer;
    girl.Ground = girl.transform;
    girl.WeaponInv = (WeaponSystem) null;
    girl.InventoryStorage = (int_personStorage) null;
    girl.Storage_Hands = (Int_Storage) null;
    girl.Storage_Vag = (Int_Storage) null;
    girl.Storage_Anal = (Int_Storage) null;
    girl.MainBodyLowPoly = skinnedMeshRenderer2;
    girl.MainBody = skinnedMeshRenderer1;
    girl.LodRen = Object.Instantiate<GameObject>(objectOfType.GirlScript.LOD.gameObject, girl.ActualHips).GetComponent<Renderer>();
    girl.LodRen.transform.localEulerAngles = Vector3.zero;
    girl.LodRen.transform.localPosition = new Vector3(0.0f, -0.26f, 0.0f);
    girl.LodRen.transform.localScale = new Vector3(0.5f, 1.75f, 0.5f);
    girl.LodRen.GetComponent<CharacterLOD>().ThisPerson = (Person) girl;
    girl.LeftArmIK = girl.Torso.parent.Find("cf_J_ShoulderIK_L/cf_J_Shoulder_L/cf_J_ArmUp00_L/cf_J_ArmLow01_L/cf_J_Hand_L").gameObject.AddComponent<FastIKFabric>();
    girl.LeftArmIK.enabled = false;
    Transform transform5 = new GameObject("LeftArmIK").transform;
    transform5.SetParent(transform1);
    girl.LeftArmIK.Target = transform5;
    Transform transform6 = new GameObject("LeftArmIK_Pole").transform;
    transform6.SetParent(transform1);
    girl.LeftArmIK.Pole = transform6;
    girl.RightArmIK = girl.Torso.parent.Find("cf_J_ShoulderIK_R/cf_J_Shoulder_R/cf_J_ArmUp00_R/cf_J_ArmLow01_R/cf_J_Hand_R").gameObject.AddComponent<FastIKFabric>();
    girl.RightArmIK.enabled = false;
    Transform transform7 = new GameObject("RightArmIK").transform;
    transform7.SetParent(transform1);
    girl.RightArmIK.Target = transform7;
    Transform transform8 = new GameObject("RightArmIK_Pole").transform;
    transform8.SetParent(transform1);
    girl.RightArmIK.Pole = transform8;
    girl.LeftLegIK = girl.FootLeft.gameObject.AddComponent<FastIKFabric>();
    girl.LeftLegIK.enabled = false;
    Transform transform9 = new GameObject("LeftLegIK").transform;
    transform9.SetParent(transform1);
    girl.LeftLegIK.Target = transform9;
    Transform transform10 = new GameObject("LeftLegIK_Pole").transform;
    transform10.SetParent(transform1);
    girl.LeftLegIK.Pole = transform10;
    girl.LeftLegIK.Root = girl.Hips;
    girl.LeftLegIK.Bones = new Transform[3]
    {
      girl.LegLeft,
      girl.CalveLeft,
      girl.FootLeft
    };
    girl.RightLegIK = girl.FootRight.gameObject.AddComponent<FastIKFabric>();
    girl.RightLegIK.enabled = false;
    Transform transform11 = new GameObject("RightLegIK").transform;
    transform11.SetParent(transform1);
    girl.RightLegIK.Target = transform11;
    Transform transform12 = new GameObject("RightLegIK_Pole").transform;
    transform12.SetParent(transform1);
    girl.RightLegIK.Pole = transform12;
    girl.RightLegIK.Root = girl.Hips;
    girl.RightLegIK.Bones = new Transform[3]
    {
      girl.LegRight,
      girl.CalveRight,
      girl.FootRight
    };
    girl.LookAtPlayer = blLookAtPlayer;
    girl.EyesObjects = (GameObject[]) null;
    girl.A_Standing_Org = "AGIA_Idle_generic_01";
    girl.A_Standing = girl.A_Standing_Org;
    girl.A_Walking = "AGIA_Other_walking_01";
    girl.A_Running = "UNCombatRunF";
    girl.SquirtSpots = new List<Transform>()
    {
      new GameObject("squirtSpot").transform
    };
    girl.SquirtSpots[0].SetParent(girl.Hips2.Find("cf_J_Kokan"));
    girl.SquirtSpots[0].localPosition = new Vector3(0.0f, -0.02299628f, 0.0f);
    girl.SquirtSpots[0].localEulerAngles = new Vector3(42.064f, 0.0f, 0.0f);
    girl.Holes = new Transform[4];
    Transform transform13 = new GameObject("VagPivot").transform;
    transform13.SetParent(girl.SquirtSpots[0].parent);
    transform13.localPosition = new Vector3(0.0f, -0.0042f, -0.0228f);
    transform13.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    girl.Holes[0] = transform13;
    Transform transform14 = new GameObject("AssPivot").transform;
    transform14.SetParent(girl.Hips2.Find("cf_J_Ana"));
    transform14.localPosition = new Vector3(0.0f, 0.0155f, 0.0f);
    transform14.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    girl.Holes[1] = transform14;
    girl.Holes[2] = girl.HeadStuff.Find("MouthPivot");
    girl.Holes[3] = girl.Holes[2].GetChild(0);
    girl.PenisBones = new Transform[7]
    {
      girl.Penis.transform.Find("Armature/Balls"),
      girl.Penis.transform.Find("Armature/pp1"),
      girl.Penis.transform.Find("Armature/pp1/pp2"),
      girl.Penis.transform.Find("Armature/pp1/pp2/pp3"),
      girl.Penis.transform.Find("Armature/pp1/pp2/pp3/pp4"),
      girl.Penis.transform.Find("Armature/pp1/looker"),
      girl.Penis.transform.Find("Armature/pp1/pp2/pp3/pp4/tip")
    };
    girl.CombatDistance = 50f;
    girl.PregnancyBones = new Transform[2]
    {
      girl.Belly,
      girl.Waist
    };
    girl.PregnancyBones_default = new Vector3[4]
    {
      Vector3.one,
      Vector3.zero,
      Vector3.one,
      Vector3.zero
    };
    girl.PregnancyBones_preg = new Vector3[4]
    {
      new Vector3(1.064f, 1.726f, 1.563f),
      new Vector3(0.009f, 11f / 1000f, 0.061f),
      new Vector3(1.073f, 1f, 1.44f),
      new Vector3(0.0f, 0.015f, 0.029f)
    };
    girl.NoBoobPhysicsOnThisOne = true;
    girl.States = new bool[objectOfType.GirlScript.States.Length];
    girl._SkinStates = new bool[objectOfType.GirlScript._SkinStates.Length];
    girl._FaceSkinStates = new bool[objectOfType.GirlScript._FaceSkinStates.Length];
    girl._CustomSkinStates = new bool[objectOfType.GirlScript._CustomSkinStates.Length];
    girl._CustomFaceSkinStates = new bool[objectOfType.GirlScript._CustomFaceSkinStates.Length];
    girl.MaterialTypeNPC = 1;
    girl.TheHealth.Audio = girl.ActualHips.gameObject.AddComponent<AudioSource>();
    girl.TheHealth.Audio.playOnAwake = false;
    girl.TheHealth.Audio.loop = false;
    girl.TheHealth.Audio.volume = 1f;
    girl.TheHealth.Audio.spatialBlend = 1f;
    girl.TheHealth.Audio.outputAudioMixerGroup = objectOfType.GirlScript.TheHealth.Audio.outputAudioMixerGroup;
    girl.States[22] = true;
    Debug.Log((object) "-------------------Prepare finished");
    return girl;
  }
}
