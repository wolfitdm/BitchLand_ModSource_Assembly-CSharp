// Decompiled with JetBrains decompiler
// Type: bl_NPCEnterTrigger
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_NPCEnterTrigger : MonoBehaviour
{
  public MonoBehaviour TheScript_Enter;
  public string TheFunc_Enter;
  public MonoBehaviour TheScript_Exit;
  public string TheFunc_Exit;
  public Person LatestInteraction;

  public void OnTriggerEnter(Collider other)
  {
    this.LatestInteraction = other.GetComponent<Person>();
    if ((Object) this.LatestInteraction == (Object) null)
      this.LatestInteraction = other.transform.root.GetComponent<Person>();
    if ((Object) this.LatestInteraction == (Object) null)
    {
      bl_PersonRedirect component = other.GetComponent<bl_PersonRedirect>();
      if ((Object) component != (Object) null)
        this.LatestInteraction = component.RedirectTarget;
    }
    if (!((Object) this.LatestInteraction != (Object) null))
      return;
    this.TheScript_Enter.Invoke(this.TheFunc_Enter, 0.0f);
  }

  public void OnTriggerExit(Collider other)
  {
    this.LatestInteraction = other.GetComponent<Person>();
    if ((Object) this.LatestInteraction == (Object) null)
      this.LatestInteraction = other.transform.root.GetComponent<Person>();
    if ((Object) this.LatestInteraction == (Object) null)
    {
      bl_PersonRedirect component = other.GetComponent<bl_PersonRedirect>();
      if ((Object) component != (Object) null)
        this.LatestInteraction = component.RedirectTarget;
    }
    if (!((Object) this.LatestInteraction != (Object) null))
      return;
    this.TheScript_Exit.Invoke(this.TheFunc_Exit, 0.0f);
  }
}
