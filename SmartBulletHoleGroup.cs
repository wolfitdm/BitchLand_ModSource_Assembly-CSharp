// Decompiled with JetBrains decompiler
// Type: SmartBulletHoleGroup
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
