// Decompiled with JetBrains decompiler
// Type: AirBoneSpawner
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class AirBoneSpawner : MonoBehaviour
{
  public Vector3 AreaSize;
  public GameObject AirbonesPrefabs;
  public float RespawnCount;

  private void OnTriggerEnter(Collider collision)
  {
    if (!(LayerMask.LayerToName(collision.gameObject.layer) == "AirboneTriggerArea"))
      return;
    for (int index = 0; (double) index < (double) this.RespawnCount; ++index)
      Object.Instantiate<GameObject>(this.AirbonesPrefabs, this.transform.position + new Vector3(Random.Range((float) (-(double) this.AreaSize.x / 2.0), this.AreaSize.x / 2f), Random.Range((float) (-(double) this.AreaSize.y / 2.0), this.AreaSize.y / 2f), Random.Range((float) (-(double) this.AreaSize.z / 2.0), this.AreaSize.z / 2f)), this.transform.rotation);
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawCube(this.transform.localPosition, this.AreaSize);
  }
}
