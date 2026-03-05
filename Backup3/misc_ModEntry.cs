// Decompiled with JetBrains decompiler
// Type: misc_ModEntry
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class misc_ModEntry : MonoBehaviour
{
  public string ModFolder;
  public Assembly ModDll;
  public System.Type ModComponent;
  public MethodInfo EnabledFunction;
  public Func<bool, bool> EnabledFunction_d;
  public Text Title;
  public Text Desc;
  public Toggle ModEnabled;
  public bool RequiresRestart;
  public GameObject RequiresRestart_obj;

  public void OnToggleClick()
  {
    if (this.EnabledFunction != (MethodInfo) null)
      this.EnabledFunction.Invoke((object) this.ModComponent, new object[1]
      {
        (object) this.ModEnabled.isOn
      });
    else if (this.EnabledFunction_d != null)
    {
      int num = this.EnabledFunction_d(this.ModEnabled.isOn) ? 1 : 0;
    }
    misc_ModEntry.SaveEnabledFor(this.ModFolder, this.ModEnabled.isOn);
  }

  public static void SaveEnabledFor(string modfolder, bool value)
  {
    string path = modfolder + "/info.txt";
    string[] contents = File.ReadAllLines(path);
    for (int index = 0; index < contents.Length; ++index)
    {
      if (contents[index].StartsWith("Enabled:"))
      {
        contents[index] = "Enabled:" + value.ToString();
        break;
      }
    }
    File.WriteAllLines(path, contents);
  }
}
