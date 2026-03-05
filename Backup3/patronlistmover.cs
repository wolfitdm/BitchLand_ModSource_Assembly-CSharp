// Decompiled with JetBrains decompiler
// Type: patronlistmover
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class patronlistmover : MonoBehaviour
{
  public Transform PatronList;
  public float PatronListSpeed;
  public float Top;
  public float Bottom;

  private void Update()
  {
    this.PatronList.transform.localPosition += new Vector3(0.0f, Time.unscaledDeltaTime * this.PatronListSpeed, 0.0f);
    if ((double) this.PatronList.transform.localPosition.y <= (double) this.Top)
      return;
    this.PatronList.transform.localPosition = new Vector3(0.0f, this.Bottom, 0.0f);
  }
}
