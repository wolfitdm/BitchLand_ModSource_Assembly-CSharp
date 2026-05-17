// Decompiled with JetBrains decompiler
// Type: SelfDestroy
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SelfDestroy : MonoBehaviour
{
  public float TimeToDestroy;

  private void Start() => Object.Destroy((Object) this.gameObject, this.TimeToDestroy);
}
