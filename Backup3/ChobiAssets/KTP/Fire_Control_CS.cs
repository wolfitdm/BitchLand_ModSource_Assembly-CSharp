// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Fire_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
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
}
