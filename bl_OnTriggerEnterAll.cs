// Decompiled with JetBrains decompiler
// Type: bl_OnTriggerEnterAll
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_OnTriggerEnterAll : MonoBehaviour
{
  public MonoBehaviour TheScript;
  public string TheFunction;
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
    if (!((Object) component != (Object) null))
      return;
    if ((Object) this.TheScript != (Object) null)
      this.TheScript.GetType().GetMethod(this.TheFunction).Invoke((object) this.TheScript, new object[1]
      {
        (object) component
      });
    if (this.DontDeleteAfterUse)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
