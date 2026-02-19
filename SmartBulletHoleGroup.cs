// Decompiled with JetBrains decompiler
// Type: SmartBulletHoleGroup
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class SmartBulletHoleGroup
{
  public string tag;
  public Material material;
  public PhysicMaterial physicMaterial;
  public BulletHolePool bulletHole;

  public SmartBulletHoleGroup()
  {
    this.tag = "Everything";
    this.material = (Material) null;
    this.physicMaterial = (PhysicMaterial) null;
    this.bulletHole = (BulletHolePool) null;
  }

  public SmartBulletHoleGroup(string t, Material m, PhysicMaterial pm, BulletHolePool bh)
  {
    this.tag = t;
    this.material = m;
    this.physicMaterial = pm;
    this.bulletHole = bh;
  }
}
