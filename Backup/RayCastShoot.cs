// Decompiled with JetBrains decompiler
// Type: RayCastShoot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class RayCastShoot : MonoBehaviour
{
  public GameObject CannonSmokePrefab;
  public Transform CannonSmokePlace;
  public Transform CannonShootingTip;
  public GameObject Shell;
  public float CannonForce = 5f;
  public float weaponRange = 32000f;
  public Transform gunEnd;
  private float time;
  public Camera fpsCam;
  public Light lightEff;
  public GameObject explosion;
  private float bulletOffset;
  private bool fire = true;
  public AudioSource firingAudio;

  private void Start() => this.lightEff.intensity = 0.0f;

  private void Explosion(Vector3 hitPos)
  {
    Object.Destroy((Object) Object.Instantiate<GameObject>(this.explosion, hitPos, Quaternion.identity), 3f);
  }

  private IEnumerator FireReload()
  {
    this.fire = false;
    yield return (object) new WaitForSeconds(4f);
    this.fire = true;
  }

  private void LateUpdate()
  {
    if (Input.GetMouseButton(UI_Settings.LeftMouseButton) && this.fire)
    {
      this.StartCoroutine(this.FireReload());
      this.time = 2f;
      this.firingAudio.Play();
      GameObject gameObject = Object.Instantiate<GameObject>(this.CannonSmokePrefab);
      gameObject.transform.position = this.CannonSmokePlace.position;
      gameObject.transform.rotation = this.CannonSmokePlace.rotation;
      Object.Instantiate<GameObject>(this.Shell, this.CannonShootingTip.position, this.CannonShootingTip.rotation).SendMessage("MultiplyInitialForce", (object) this.CannonForce, SendMessageOptions.DontRequireReceiver);
    }
    if ((double) this.time > 0.0)
      --this.time;
    if ((double) this.time != 0.0)
      return;
    this.lightEff.intensity = 0.0f;
  }
}
