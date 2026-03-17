// Decompiled with JetBrains decompiler
// Type: ThingToDo
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ThingToDo : MonoBehaviour
{
  public Person ThisPerson;
  public Vector3 Pos;
  public Vector3 Rot;
  public bool Started;
  public bool Completed;

  public virtual void Start() => this.StartDoing();

  public virtual void Update()
  {
  }

  public virtual void StartDoing()
  {
    this.enabled = true;
    this.Started = true;
  }

  public virtual void Complete() => this.Completed = true;
}
