// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Fire_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP;

public class Fire_Control_CS : MonoBehaviour
{
  [Header("Fire control settings")]
  [Tooltip("Loading time. (Sec)")]
  public float reloadTime = 4f;
  [Tooltip("Recoil force with firing.")]
  public float recoilForce = 5000f;
  private bool isReady = true;
  private Transform thisTransform;
  private Rigidbody bodyRigidbody;
  private ID_Control_CS idScript;
  private Barrel_Control_CS[] barrelScripts;
  private Fire_Spawn_CS[] fireScripts;

  private void Awake()
  {
    this.thisTransform = this.transform;
    this.barrelScripts = this.GetComponentsInChildren<Barrel_Control_CS>();
    this.fireScripts = this.GetComponentsInChildren<Fire_Spawn_CS>();
  }

  private void Update()
  {
    if (!this.idScript.isPlayer)
      return;
    this.Desktop_Input();
  }

  private void Desktop_Input()
  {
    if (!this.idScript.fireButton || !this.isReady)
      return;
    this.Fire();
  }

  private void Fire()
  {
    for (int index = 0; index < this.barrelScripts.Length; ++index)
      this.barrelScripts[index].Fire();
    for (int index = 0; index < this.fireScripts.Length; ++index)
      this.fireScripts[index].StartCoroutine(nameof (Fire));
    this.bodyRigidbody.AddForceAtPosition(-this.thisTransform.forward * this.recoilForce, this.thisTransform.position, ForceMode.Impulse);
    this.isReady = false;
    this.StartCoroutine("Reload");
  }

  private IEnumerator Reload()
  {
    yield return (object) new WaitForSeconds(this.reloadTime);
    this.isReady = true;
  }

  private void Destroy() => Object.Destroy((Object) this);

  private void Get_ID_Script(ID_Control_CS tempScript)
  {
    this.idScript = tempScript;
    this.bodyRigidbody = this.idScript.storedTankProp.bodyRigidbody;
  }

  private void Pause(bool isPaused) => this.enabled = !isPaused;
}
