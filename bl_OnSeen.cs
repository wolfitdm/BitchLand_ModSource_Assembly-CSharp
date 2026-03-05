// Decompiled with JetBrains decompiler
// Type: bl_OnSeen
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
