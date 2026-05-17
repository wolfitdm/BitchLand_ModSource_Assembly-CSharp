// Decompiled with JetBrains decompiler
// Type: CFX_AutoDestructShuriken
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
[RequireComponent(typeof (ParticleSystem))]
public class CFX_AutoDestructShuriken : MonoBehaviour
{
  public bool OnlyDeactivate;

  private void OnEnable() => this.StartCoroutine("CheckIfAlive");

  private IEnumerator CheckIfAlive()
  {
    CFX_AutoDestructShuriken destructShuriken = this;
    do
    {
      yield return (object) new WaitForSeconds(0.5f);
    }
    while (destructShuriken.GetComponent<ParticleSystem>().IsAlive(true));
    if (destructShuriken.OnlyDeactivate)
      destructShuriken.gameObject.SetActive(false);
    else
      Object.Destroy((Object) destructShuriken.gameObject);
  }
}
