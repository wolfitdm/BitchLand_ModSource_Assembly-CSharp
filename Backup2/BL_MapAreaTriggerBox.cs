// Decompiled with JetBrains decompiler
// Type: BL_MapAreaTriggerBox
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BL_MapAreaTriggerBox : MonoBehaviour
{
  public Component[] ToRemove;
  public BL_MapArea MapArea;
  public bool AreaEnter;

  public void Start()
  {
    for (int index = 0; index < this.ToRemove.Length; ++index)
    {
      if ((Object) this.ToRemove[index] != (Object) null)
        Object.Destroy((Object) this.ToRemove[index]);
    }
  }

  public void OnTriggerEnter(Collider other)
  {
    if (!(other.tag == "Player"))
      return;
    if (this.AreaEnter)
      this.MapArea.OnEnter();
    else
      this.MapArea.OnLeave();
  }
}
