// Decompiled with JetBrains decompiler
// Type: SaveableBehaviour
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

#nullable disable
public class SaveableBehaviour : MonoBehaviour
{
  public string WorldSaveID;
  public bool AddToSaveableOnStart;
  public bool _AddedToSaveable;
  public bool DontSaveInMain;
  public bool ow_oddsaving;
  public bool HasByte2Data;
  public bool DisableAfterStart;
  public int _CurrentLoadingIndex;
  public SaveableBehaviour[] ExtraSavebles;
  public GameObject RootObj;
  public List<string> CanSaveFlagger = new List<string>();
  public string[] _LatestDataLoading;

  public virtual bool CanSave => this.CanSaveFlagger.Count == 0;

  public virtual void Awake()
  {
    if (!this.AddToSaveableOnStart || !((UnityEngine.Object) Main.Instance != (UnityEngine.Object) null) || Main.Instance.SpawnedObjects == null)
      return;
    if (Main.Instance.OpenWorld)
      Main.Instance.SpawnedObjects_World.Add(this);
    else
      Main.Instance.SpawnedObjects.Add(this);
    this._AddedToSaveable = true;
    if (!this.DisableAfterStart)
      return;
    this.enabled = false;
  }

  public virtual void Start()
  {
    if (!this.AddToSaveableOnStart || this._AddedToSaveable)
      return;
    if (Main.Instance.OpenWorld)
      Main.Instance.SpawnedObjects_World.Add(this);
    else
      Main.Instance.SpawnedObjects.Add(this);
    this._AddedToSaveable = true;
    if (!this.DisableAfterStart)
      return;
    this.enabled = false;
  }

  public virtual string[] SaveableData
  {
    get
    {
      try
      {
        List<string> stringList = new List<string>();
        stringList.AddRange((IEnumerable<string>) this.sd_SaveData());
        for (int index = 0; index < this.ExtraSavebles.Length; ++index)
          stringList.Add(this.ExtraSavebles[index].sv_SaveData());
        return stringList.ToArray();
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("Error: " + ex.Message + "\n" + ex.StackTrace));
      }
      return (string[]) null;
    }
    set
    {
      try
      {
        this._LatestDataLoading = value;
        this._CurrentLoadingIndex = 0;
        this.sd_LoadData(value);
        this.AfterDataLoaded();
        for (int index = 0; index < this.ExtraSavebles.Length; ++index)
        {
          this.ExtraSavebles[index].sv_LoadData(this._LatestDataLoading[this._CurrentLoadingIndex++], removeFirst: false);
          this.ExtraSavebles[index].AfterDataLoaded();
        }
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("Error loading: " + this.gameObject.name + "\n" + ex.Message + "\n" + ex.StackTrace));
      }
    }
  }

  public virtual byte[] ByteSaveableData2
  {
    get => (byte[]) null;
    set
    {
    }
  }

  public virtual byte[] ByteSaveableData
  {
    get => SaveableBehaviour.StringArrayToByteArray(this.SaveableData);
  }

  public virtual string sv_SaveData(char SlitChar = ':')
  {
    string[] strArray = this.sd_SaveData(';');
    string str = string.Empty;
    if (strArray.Length != 0)
    {
      str = strArray[0];
      for (int index = 1; index < strArray.Length; ++index)
        str = str + SlitChar.ToString() + strArray[index];
    }
    return str;
  }

  public virtual void sv_LoadData(string Data, char SlitChar = ':', bool removeFirst = true)
  {
    if (removeFirst)
    {
      string[] sourceArray = Data.Split(SlitChar, StringSplitOptions.None);
      string[] strArray = new string[sourceArray.Length - 1];
      Array.Copy((Array) sourceArray, 1, (Array) strArray, 0, sourceArray.Length - 1);
      this.sd_LoadData(strArray, ';');
    }
    else
      this.sd_LoadData(Data.Split(SlitChar, StringSplitOptions.None), ';');
  }

  public virtual string[] sd_SaveData(char SlitChar = ':')
  {
    return new string[1]{ this.WorldSaveID };
  }

  public virtual void sd_LoadData(string[] Data, char SlitChar = ':')
  {
  }

  public virtual void AfterDataLoaded()
  {
  }

  public virtual void SaveToFile(string filename)
  {
    string[] saveableData = this.SaveableData;
    if (saveableData == null)
      return;
    Debug.Log((object) ("Saving " + this.gameObject.name + "-" + saveableData[0] + "-" + saveableData[1]));
    File.WriteAllLines(filename, saveableData);
  }

  public virtual void LoadFromFile(string filename)
  {
    this.SaveableData = File.ReadAllLines(filename);
  }

  public void SetFromBytes(byte[] data)
  {
    this.SaveableData = SaveableBehaviour.ByteArrayToStringArray(data);
  }

  public static byte[] StringArrayToByteArray(string[] stringArray)
  {
    return Encoding.UTF8.GetBytes(string.Join(string.Empty, stringArray));
  }

  public static string[] ByteArrayToStringArray(byte[] byteArray)
  {
    return SaveableBehaviour.SplitIntoChunks(Encoding.UTF8.GetString(byteArray), 1).ToArray<string>();
  }

  private static IEnumerable<string> SplitIntoChunks(string str, int chunkSize)
  {
    for (int i = 0; i < str.Length; i += chunkSize)
      yield return str.Substring(i, Math.Min(chunkSize, str.Length - i));
  }

  public void WriteVector3(BinaryWriter writer, Vector3 v)
  {
    writer.Write(v.x);
    writer.Write(v.y);
    writer.Write(v.z);
  }

  public Vector3 ReadVector3(BinaryReader reader)
  {
    double x = (double) reader.ReadSingle();
    float num1 = reader.ReadSingle();
    float num2 = reader.ReadSingle();
    double y = (double) num1;
    double z = (double) num2;
    return new Vector3((float) x, (float) y, (float) z);
  }

  public void WriteColor(BinaryWriter writer, Color v)
  {
    writer.Write(v.r);
    writer.Write(v.g);
    writer.Write(v.b);
    writer.Write(v.a);
  }

  public Color ReadColor(BinaryReader reader)
  {
    double r = (double) reader.ReadSingle();
    float num1 = reader.ReadSingle();
    float num2 = reader.ReadSingle();
    float num3 = reader.ReadSingle();
    double g = (double) num1;
    double b = (double) num2;
    double a = (double) num3;
    return new Color((float) r, (float) g, (float) b, (float) a);
  }
}
