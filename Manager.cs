// Decompiled with JetBrains decompiler
// Type: Manager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Manager : MonoBehaviour
{
  private static Manager instance;
  public Transform[] Waypoints1;

  public static Manager GetInstance() => Manager.instance;

  private void Awake() => Manager.instance = this;

  private void Start()
  {
  }

  private void Update()
  {
  }
}
