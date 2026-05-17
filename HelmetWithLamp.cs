// Decompiled with JetBrains decompiler
// Type: HelmetWithLamp
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HelmetWithLamp : Dressable
{
  public float BatteryMax = 600f;
  public float Battery;
  public Light MainLight;
  public Light SecondLight;
  public Vector3 OrgLightRot;

  public void LateUpdate()
  {
    if (this.PersonEquipped.IsPlayer)
    {
      if (Input.GetKeyUp(KeyCode.T))
      {
        this.MainLight.enabled = !this.MainLight.enabled;
        if (this.MainLight.enabled)
          this.EnableLamp();
        else
          this.DisableLamp();
      }
      if (this.MainLight.enabled)
      {
        if (this.PersonEquipped.UserControl.FirstPerson && (double) this.PersonEquipped._Rigidbody.linearVelocity.x < 1.1000000238418579 && (double) this.PersonEquipped._Rigidbody.linearVelocity.x > -1.1000000238418579 && (double) this.PersonEquipped._Rigidbody.linearVelocity.z < 1.1000000238418579 && (double) this.PersonEquipped._Rigidbody.linearVelocity.z > -1.1000000238418579)
          this.MainLight.transform.LookAt(this.PersonEquipped.ViewPoint);
        else
          this.MainLight.transform.localEulerAngles = this.OrgLightRot;
      }
    }
    if (!this.MainLight.enabled)
      return;
    if ((double) this.Battery > 0.0)
      this.Battery -= Time.deltaTime;
    this.Battery = 1f;
    this.MainLight.intensity = (double) this.Battery / (double) this.BatteryMax < 0.5 ? ((double) this.Battery > 0.0 ? this.Battery / (this.BatteryMax * 0.5f) : 0.01f) : 1f;
    this.MainLight.intensity = 1f;
  }

  public void DisableLamp()
  {
    this.MainLight.enabled = false;
    this.SecondLight.enabled = false;
  }

  public void EnableLamp()
  {
    this.MainLight.enabled = true;
    this.SecondLight.enabled = true;
  }

  public override void OnDressed()
  {
    base.OnDressed();
    this.enabled = true;
    if (!((Object) this.PersonEquipped != (Object) null) || !this.PersonEquipped.IsPlayer)
      return;
    Main.Instance.GameplayMenu.ShowNotification("Press T to toggle light");
  }

  public override void OnUndressed()
  {
    base.OnUndressed();
    this.DisableLamp();
    this.enabled = false;
  }
}
