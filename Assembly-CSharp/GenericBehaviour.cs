// Decompiled with JetBrains decompiler
// Type: GenericBehaviour
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
