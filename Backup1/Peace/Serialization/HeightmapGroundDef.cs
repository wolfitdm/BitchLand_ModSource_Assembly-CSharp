// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.HeightmapGroundDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Peace.Serialization
{
  [Serializable]
  public class HeightmapGroundDef : ISerializationCallbackReceiver
  {
    [SerializeField]
    public string type = "HeightmapGround";
    public double minAltitude = -2000.0;
    public double maxAltitude = 4000.0;
    public int terrainRes = 65;
    public int textureRes = 128;
    public int texPixSize = 4;
    public TileSystem tileSystem = new TileSystem()
    {
      maxLod = 12,
      factor = 2,
      baseSize = new Vector3(6000f, 6000f, 0.0f),
      bufferRes = new Vector3Int(512, 512, 0)
    };
    [NonSerialized]
    public List<IGroundWorkerDef> workers_list = new List<IGroundWorkerDef>();
    [SerializeField]
    private List<string> workers = new List<string>();

    public void OnBeforeSerialize()
    {
      WorldSerialization.SerializeList<IGroundWorkerDef>(this.workers_list, this.workers);
    }

    public void OnAfterDeserialize()
    {
    }
  }
}
