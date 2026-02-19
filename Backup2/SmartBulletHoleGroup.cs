// Decompiled with JetBrains decompiler
// Type: SmartBulletHoleGroup
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
