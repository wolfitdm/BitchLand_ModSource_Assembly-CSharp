// Decompiled with JetBrains decompiler
// Type: bl_OnSeen
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_OnSeen : bl_LocalLOD
{
  [Header("On Seen")]
  public MonoBehaviour ScriptOnSeen;
  public string FunctionOnSeen;
  public bool DisableWhenSeen;

  public override void Start()
  {
  }

  public override void Show()
  {
    this.ScriptOnSeen.Invoke(this.FunctionOnSeen, 0.0f);
    if (!this.DisableWhenSeen)
      return;
    this.gameObject.SetActive(false);
  }

  public override void Hide()
  {
  }

  public override void EnableShared()
  {
  }

  public override void OnTriggerEnter(Collider other)
  {
    Person component = other.transform.root.GetComponent<Person>();
    if (!((Object) component != (Object) null) || !component.IsPlayer)
      return;
    this.Show();
  }

  public override void OnTriggerExit(Collider other)
  {
  }
}
