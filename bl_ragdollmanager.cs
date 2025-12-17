// Decompiled with JetBrains decompiler
// Type: bl_ragdollmanager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class bl_ragdollmanager : MonoBehaviour
{
  public GameObject[] DisableOnRagdoll;
  public Rigidbody[] Limbs;
  public Girl ThisGirl;
  public float Timer;

  public void OnBecomeRagdoll()
  {
    for (int index = 0; index < this.DisableOnRagdoll.Length; ++index)
      this.DisableOnRagdoll[index].SetActive(false);
  }

  public void OnBecomeNOTRagdoll()
  {
    for (int index = 0; index < this.DisableOnRagdoll.Length; ++index)
      this.DisableOnRagdoll[index].SetActive(true);
  }

  private void Update()
  {
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer >= 0.0)
      return;
    this.Timer = 1f;
    if (!this.Limbs[0].isKinematic && !this.Limbs[0].IsSleeping() && (double) Vector3.Distance(this.Limbs[0].transform.position, this.Limbs[0].transform.parent.position) > 0.20000000298023224)
      this.ResetRagdoll();
    if ((double) this.transform.position.y >= -50.0)
      return;
    this.transform.position = new Vector3(0.0f, 1f, 0.0f);
    this.transform.eulerAngles = Vector3.zero;
    this.ResetRagdoll();
  }

  public void ResetRagdoll()
  {
    for (int index = 0; index < this.Limbs.Length; ++index)
    {
      this.Limbs[index].isKinematic = true;
      LimbHitbox component = this.Limbs[index].GetComponent<LimbHitbox>();
      this.Limbs[index].transform.localPosition = component.OrgPos;
      this.Limbs[index].transform.localEulerAngles = component.OrgRot;
    }
    if ((UnityEngine.Object) this.ThisGirl != (UnityEngine.Object) null)
      this.ThisGirl.ExSetGirlPhysics(false, false);
    Main.RunInNextFrame(new Action(this.RestorePhysics), 2);
  }

  public void RestorePhysics()
  {
    for (int index = 0; index < this.Limbs.Length; ++index)
    {
      if ((UnityEngine.Object) this.Limbs[index] != (UnityEngine.Object) null)
        this.Limbs[index].isKinematic = false;
    }
    if (!((UnityEngine.Object) this.ThisGirl != (UnityEngine.Object) null))
      return;
    this.ThisGirl.ExSetGirlPhysics(true, true);
  }
}
