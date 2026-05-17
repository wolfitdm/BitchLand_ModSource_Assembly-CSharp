// Decompiled with JetBrains decompiler
// Type: ThingToDo
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
