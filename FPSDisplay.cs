// Decompiled with JetBrains decompiler
// Type: FPSDisplay
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FPSDisplay : MonoBehaviour
{
  private float deltaTime;

  private void Update()
  {
    this.deltaTime += (float) (((double) Time.deltaTime - (double) this.deltaTime) * 0.10000000149011612);
  }

  private void OnGUI()
  {
    int width = Screen.width;
    int height = Screen.height;
    GUIStyle guiStyle = new GUIStyle();
    Rect position = new Rect(0.0f, 0.0f, (float) width, (float) (height * 2 / 100));
    guiStyle.alignment = TextAnchor.UpperLeft;
    guiStyle.fontSize = height * 2 / 100;
    guiStyle.normal.textColor = new Color(1f, 1f, 1f, 1f);
    string text = $"{this.deltaTime * 1000f:0.0} ms ({1f / this.deltaTime:0.} fps)";
    GUIStyle style = guiStyle;
    GUI.Label(position, text, style);
  }
}
