// Decompiled with JetBrains decompiler
// Type: CameraFollowCharacter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
