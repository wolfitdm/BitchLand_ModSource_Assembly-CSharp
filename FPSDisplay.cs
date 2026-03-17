// Decompiled with JetBrains decompiler
// Type: FPSDisplay
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
    string text = string.Format("{0:0.0} ms ({1:0.} fps)", (object) (this.deltaTime * 1000f), (object) (1f / this.deltaTime));
    GUIStyle style = guiStyle;
    GUI.Label(position, text, style);
  }
}
