// Decompiled with JetBrains decompiler
// Type: CamTarget
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CamTarget : MonoBehaviour
{
  public Transform target;
  private float camSpeed = 50f;
  private Vector3 lerpPos;

  private void Update()
  {
    this.lerpPos = (this.target.position - this.transform.position) * Time.deltaTime * this.camSpeed;
    this.transform.position += this.lerpPos;
  }
}
