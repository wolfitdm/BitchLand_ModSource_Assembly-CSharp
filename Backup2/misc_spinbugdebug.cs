// Decompiled with JetBrains decompiler
// Type: misc_spinbugdebug
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class misc_spinbugdebug : MonoBehaviour
{
  public Text Xframe0;
  public Text Xframe1;
  public Text Xframe4;
  public Text Xs1;
  public Text Xs2;
  public Text Yframe0;
  public Text Yframe1;
  public Text Yframe4;
  public Text Ys1;
  public Text Ys2;
  public MonoBehaviour _CRotX;
  public MonoBehaviour _CRotY;
  public MonoBehaviour _CCam1;
  public MonoBehaviour _CCam3;
  public MonoBehaviour _COld3;
  public MonoBehaviour _CF1;
  public Text CRotX;
  public Text CRotY;
  public Text CCam1;
  public Text CCam3;
  public Text COld3;
  public Text CF1;
  private string[] XframeValues = new string[5];
  private string[] YframeValues = new string[5];
  private float Timer;
  private float Timer2;

  private void Update()
  {
    this.Xframe1.text = this.Xframe0.text;
    this.Yframe1.text = this.Yframe0.text;
    this.Xframe0.text = Input.GetAxis("Mouse X").ToString();
    this.Yframe0.text = Input.GetAxis("Mouse Y").ToString();
    this.Xframe4.text = this.XframeValues[4];
    this.Yframe4.text = this.YframeValues[4];
    for (int index = 4; index > 0; --index)
    {
      this.XframeValues[index] = this.XframeValues[index - 1];
      this.YframeValues[index] = this.YframeValues[index - 1];
    }
    this.XframeValues[0] = this.Xframe0.text;
    this.YframeValues[0] = this.Yframe0.text;
    this.Timer -= Time.deltaTime;
    this.Timer2 -= Time.deltaTime;
    if ((double) this.Timer < 0.0)
    {
      this.Timer = 0.1f;
      this.Xs1.text = this.Xframe0.text;
      this.Ys1.text = this.Yframe0.text;
    }
    if ((double) this.Timer2 < 0.0)
    {
      this.Timer2 = 0.2f;
      this.Xs2.text = this.Xframe0.text;
      this.Ys2.text = this.Yframe0.text;
    }
    this.CRotX.text = this._CRotX.enabled.ToString();
    this.CRotY.text = this._CRotY.enabled.ToString();
    this.CCam1.text = this._CCam1.enabled.ToString();
    this.CCam3.text = this._CCam3.enabled.ToString();
    this.COld3.text = this._COld3.enabled.ToString();
    this.CF1.text = this._CF1.enabled.ToString();
  }
}
