// Decompiled with JetBrains decompiler
// Type: GenericBehaviour
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
