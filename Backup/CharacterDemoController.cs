// Decompiled with JetBrains decompiler
// Type: CharacterDemoController
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CharacterDemoController : MonoBehaviour
{
  private Animator animator;
  public GameObject floorPlane;
  public int WeaponState;
  public bool wasAttacking;
  private float rotateSpeed = 20f;
  public Vector3 movementTargetPosition;
  public Vector3 attackPos;
  public Vector3 lookAtPos;
  private float gravity = 0.3f;
  private RaycastHit hit;
  private Ray ray;
  public bool rightButtonDown;

  private void Start()
  {
    this.animator = this.GetComponentInChildren<Animator>();
    this.movementTargetPosition = this.transform.position;
  }

  private void Update()
  {
    if (!Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(0))
    {
      this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (this.floorPlane.GetComponent<Collider>().Raycast(this.ray, out this.hit, 500f))
      {
        this.movementTargetPosition = this.hit.point;
        this.wasAttacking = false;
      }
    }
    switch (Input.inputString)
    {
      case "0":
        this.WeaponState = 0;
        break;
      case "1":
        this.WeaponState = 1;
        break;
      case "2":
        this.WeaponState = 2;
        break;
      case "3":
        this.WeaponState = 3;
        break;
      case "4":
        this.WeaponState = 4;
        break;
      case "5":
        this.WeaponState = 5;
        break;
      case "6":
        this.WeaponState = 6;
        break;
      case "7":
        this.WeaponState = 7;
        break;
      case "8":
        this.WeaponState = 8;
        break;
      case "a":
        this.animator.SetInteger("Death", 1);
        break;
      case "b":
        this.animator.SetInteger("Death", 2);
        break;
      case "c":
        this.animator.SetInteger("Death", 3);
        break;
      case "n":
        this.animator.SetBool("NonCombat", true);
        break;
      case "p":
        this.animator.SetTrigger("Pain");
        break;
    }
    this.animator.SetInteger("WeaponState", this.WeaponState);
    if (!Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(1) && !this.rightButtonDown)
    {
      this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (this.floorPlane.GetComponent<Collider>().Raycast(this.ray, out this.hit, 500f))
      {
        this.movementTargetPosition = this.transform.position;
        this.attackPos = this.hit.point;
        this.attackPos.y = this.transform.position.y;
        this.attackPos = this.transform.position + (this.attackPos - this.transform.position).normalized * 20f;
        this.animator.SetTrigger("Use");
        this.animator.SetBool("Idling", true);
        this.rightButtonDown = true;
        this.wasAttacking = true;
      }
    }
    if (Input.GetMouseButtonUp(1) && this.rightButtonDown)
      this.rightButtonDown = false;
    Debug.DrawLine(this.movementTargetPosition + this.transform.up * 2f, this.movementTargetPosition);
    Vector3 vector3 = this.movementTargetPosition - this.transform.position;
    if (!this.wasAttacking)
    {
      this.lookAtPos = this.transform.position + vector3.normalized * 2f;
      this.lookAtPos.y = this.transform.position.y;
    }
    else
      this.lookAtPos = this.attackPos;
    Quaternion rotation1 = this.transform.rotation;
    this.transform.LookAt(this.lookAtPos);
    Quaternion rotation2 = this.transform.rotation;
    this.transform.rotation = Quaternion.Slerp(rotation1, rotation2, Time.deltaTime * this.rotateSpeed);
    if ((double) Vector3.Distance(this.movementTargetPosition, this.transform.position) > 0.5)
      this.animator.SetBool("Idling", false);
    else
      this.animator.SetBool("Idling", true);
  }

  private void OnGUI()
  {
    GUI.Label(new Rect(10f, 5f, 1000f, 20f), "LMB=move RMB=attack p=pain abc=deaths 12345678 0=change weapons");
  }
}
