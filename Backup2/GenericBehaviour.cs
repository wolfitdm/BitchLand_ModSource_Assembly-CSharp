// Decompiled with JetBrains decompiler
// Type: GenericBehaviour
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class GenericBehaviour : MonoBehaviour
{
  protected int speedFloat;
  protected PlayerBasicCode behaviourManager;
  protected int behaviourCode;
  protected bool canSprint;

  private void Awake()
  {
    this.behaviourManager = this.GetComponent<PlayerBasicCode>();
    this.speedFloat = Animator.StringToHash("Speed");
    this.canSprint = true;
    this.behaviourCode = this.GetType().GetHashCode();
  }

  public virtual void LocalFixedUpdate()
  {
  }

  public virtual void LocalLateUpdate()
  {
  }

  public virtual void OnOverride()
  {
  }

  public int GetBehaviourCode() => this.behaviourCode;

  public bool AllowSprint() => this.canSprint;
}
