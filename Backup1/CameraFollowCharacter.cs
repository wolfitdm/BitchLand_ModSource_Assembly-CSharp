// Decompiled with JetBrains decompiler
// Type: CameraFollowCharacter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CameraFollowCharacter : MonoBehaviour
{
  public Transform playerObject1;
  public Transform playerObject2;
  public float distanceFromObject = 6f;
  public Vector3 playerMiddle = new Vector3(0.0f, 1f, 0.0f);
  public float flyAroudSpeed;

  private void Update()
  {
    Vector3 vector3_1 = (this.playerObject1.position + this.playerObject2.position) / 2f;
    Vector3 vector3_2 = vector3_1 + this.playerMiddle - this.transform.position;
    this.transform.forward = vector3_2.normalized;
    this.transform.position = vector3_1 + this.playerMiddle - vector3_2.normalized * this.distanceFromObject;
  }
}
