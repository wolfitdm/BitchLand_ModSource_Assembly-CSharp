// Decompiled with JetBrains decompiler
// Type: CameraSwitch
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
