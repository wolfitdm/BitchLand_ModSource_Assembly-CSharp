// Decompiled with JetBrains decompiler
// Type: TimedObjectDestroyer
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TimedObjectDestroyer : MonoBehaviour
{
  public float lifeTime = 10f;

  private void Start() => Object.Destroy((Object) this.gameObject, this.lifeTime);
}
