// Decompiled with JetBrains decompiler
// Type: BL_MapAreaTriggerBox
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
