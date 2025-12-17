// Decompiled with JetBrains decompiler
// Type: FirstPersonHeadBob
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[DefaultExecutionOrder(10000)]
public class FirstPersonHeadBob : MonoBehaviour
{
  [SerializeField]
  private Transform head;
  public Transform headSpot;
  [SerializeField]
  private float headBobFrequency = 1.5f;
  [SerializeField]
  private float headBobHeight = 0.3f;
  [SerializeField]
  private float headBobSwayAngle = 0.5f;
  [SerializeField]
  private float headBobSideMovement = 0.05f;
  [SerializeField]
  private float bobHeightSpeedMultiplier = 0.3f;
  [SerializeField]
  private float bobStrideSpeedLengthen = 0.3f;
  [SerializeField]
  private float jumpLandMove = 3f;
  [SerializeField]
  private float jumpLandTilt = 60f;
  [SerializeField]
  private AudioClip[] footstepSounds;
  [SerializeField]
  private AudioClip jumpSound;
  [SerializeField]
  private AudioClip landSound;
  private FirstPersonCharacter character;
  private Vector3 originalLocalPos;
  private float headBobCycle;
  private float headBobFade;
  private float springPos;
  private float springVelocity;
  private float springElastic = 1.1f;
  private float springDampen = 0.8f;
  private float springVelocityThreshold = 0.05f;
  private float springPositionThreshold = 0.05f;
  private Vector3 prevPosition;
  private Vector3 prevVelocity = Vector3.zero;
  private bool prevGrounded = true;

  private void Start()
  {
    this.originalLocalPos = this.head.localPosition;
    this.character = this.GetComponent<FirstPersonCharacter>();
    if ((Object) this.GetComponent<AudioSource>() == (Object) null)
      this.gameObject.AddComponent<AudioSource>();
    this.prevPosition = this.GetComponent<Rigidbody>().position;
  }

  public void LateUpdate()
  {
    this.head.position = this.headSpot.position;
    this.head.eulerAngles = new Vector3(this.head.eulerAngles.x, this.head.eulerAngles.y, 0.0f);
  }

  private void FixedUpdate()
  {
    if (this.character.grounded)
    {
      if (!this.prevGrounded)
      {
        this.GetComponent<AudioSource>().clip = this.landSound;
        this.GetComponent<AudioSource>().Play();
      }
      this.prevGrounded = true;
    }
    else
    {
      if (this.prevGrounded)
      {
        this.GetComponent<AudioSource>().clip = this.jumpSound;
        this.GetComponent<AudioSource>().Play();
      }
      this.prevGrounded = false;
    }
  }
}
