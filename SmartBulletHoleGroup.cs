// Decompiled with JetBrains decompiler
// Type: SmartBulletHoleGroup
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class SmartBulletHoleGroup
{
  public string tag;
  public Material material;
  public PhysicsMaterial physicMaterial;
  public BulletHolePool bulletHole;

  public SmartBulletHoleGroup()
  {
    this.tag = "Everything";
    this.material = (Material) null;
    this.physicMaterial = (PhysicsMaterial) null;
    this.bulletHole = (BulletHolePool) null;
  }

  public SmartBulletHoleGroup(string t, Material m, PhysicsMaterial pm, BulletHolePool bh)
  {
    this.tag = t;
    this.material = m;
    this.physicMaterial = pm;
    this.bulletHole = bh;
  }
}
