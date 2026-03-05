// Decompiled with JetBrains decompiler
// Type: WFX_Demo_DeleteAfterDelay
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class WFX_Demo_DeleteAfterDelay : MonoBehaviour
{
  public float delay = 1f;

  private void Update()
  {
    this.delay -= Time.deltaTime;
    if ((double) this.delay >= 0.0)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
