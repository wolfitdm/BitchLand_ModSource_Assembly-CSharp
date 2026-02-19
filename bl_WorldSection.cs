// Decompiled with JetBrains decompiler
// Type: bl_WorldSection
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.AI;

#nullable disable
public class bl_WorldSection : MonoBehaviour
{
  public int SectionID;
  public bool PreviouslyGenerated;
  public bool Loaded;
  public NavMeshData NavMesh_Data;
  public int ChunksX;
  public int ChunksY;
  public int ChunksCount;

  public void SaveToFile()
  {
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    FileStream fileStream = File.Create(Main.Instance.CurrentSavePath + "Section_" + this.SectionID.ToString() + "/navmesh.dat");
    FileStream serializationStream = fileStream;
    NavMeshData navMeshData = this.NavMesh_Data;
    binaryFormatter.Serialize((Stream) serializationStream, (object) navMeshData);
    fileStream.Close();
  }
}
