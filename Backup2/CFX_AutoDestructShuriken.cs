// Decompiled with JetBrains decompiler
// Type: CFX_AutoDestructShuriken
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
