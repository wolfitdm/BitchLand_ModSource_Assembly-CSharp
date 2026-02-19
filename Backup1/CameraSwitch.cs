// Decompiled with JetBrains decompiler
// Type: CameraSwitch
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class CameraSwitch : MonoBehaviour
{
  public GameObject[] objects;
  public Text text;
  private int m_CurrentActiveObject;

  private void OnEnable() => this.text.text = this.objects[this.m_CurrentActiveObject].name;

  public void NextCamera()
  {
    int num = this.m_CurrentActiveObject + 1 >= this.objects.Length ? 0 : this.m_CurrentActiveObject + 1;
    for (int index = 0; index < this.objects.Length; ++index)
      this.objects[index].SetActive(index == num);
    this.m_CurrentActiveObject = num;
    this.text.text = this.objects[this.m_CurrentActiveObject].name;
  }
}
