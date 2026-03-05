// Decompiled with JetBrains decompiler
// Type: ThingToDo
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
