// Decompiled with JetBrains decompiler
// Type: bl_OnTriggerEnterEvent
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_OnTriggerEnterEvent : MonoBehaviour
{
  public MonoBehaviour TheScript;
  public string TheFunction;
  public Mis_Mines Mines;
  public bool DontDeleteAfterUse;

  public void Awake()
  {
    MeshRenderer component1 = this.GetComponent<MeshRenderer>();
    MeshFilter component2 = this.GetComponent<MeshFilter>();
    if ((Object) component1 != (Object) null)
      Object.Destroy((Object) component1);
    if (!((Object) component2 != (Object) null))
      return;
    Object.Destroy((Object) component2);
  }

  public void OnTriggerEnter(Collider other)
  {
    if (!(other.tag != "ignore"))
      return;
    Person component = other.transform.root.GetComponent<Person>();
    if ((Object) component == (Object) null)
      component = other.transform.GetComponent<Person>();
    if (!((Object) component != (Object) null) || !component.IsPlayer)
      return;
    if ((Object) this.Mines != (Object) null)
      this.Mines.OnEndBuildTrigger();
    if ((Object) this.TheScript != (Object) null)
      this.TheScript.Invoke(this.TheFunction, 0.0f);
    if (this.DontDeleteAfterUse)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
