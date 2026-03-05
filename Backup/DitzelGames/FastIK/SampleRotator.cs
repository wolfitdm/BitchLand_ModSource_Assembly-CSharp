// Decompiled with JetBrains decompiler
// Type: DitzelGames.FastIK.SampleRotator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DitzelGames.FastIK
{
  public class SampleRotator : MonoBehaviour
  {
    private void Update() => this.transform.Rotate(0.0f, Time.deltaTime * 90f, 0.0f);
  }
}
