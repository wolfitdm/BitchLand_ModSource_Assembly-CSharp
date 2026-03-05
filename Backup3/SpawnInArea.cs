// Decompiled with JetBrains decompiler
// Type: SpawnInArea
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SpawnInArea : MonoBehaviour
{
  public Texture2D SpawnMap;
  private float Offset = 10f;
  private float AboveGround = 1f;
  private bool TerrainOnly = true;

  private void RandomPositionOnTerrain(GameObject obj)
  {
    Vector3 size = Terrain.activeTerrain.terrainData.size;
    Vector3 origin = new Vector3();
    bool flag = false;
    while (!flag)
    {
      origin = Terrain.activeTerrain.transform.position;
      float num1 = Random.Range(0.0f, size.x);
      float num2 = Random.Range(0.0f, size.z);
      origin.x += num1;
      origin.y += size.y + this.Offset;
      origin.z += num2;
      if ((bool) (Object) this.SpawnMap)
      {
        float grayscale = this.SpawnMap.GetPixel(Mathf.RoundToInt((float) this.SpawnMap.width * num1 / size.x), Mathf.RoundToInt((float) this.SpawnMap.height * num2 / size.z)).grayscale;
        flag = (double) grayscale > 0.0 && (double) Random.Range(0.0f, 1f) < (double) grayscale;
      }
      else
        flag = true;
      if (flag)
      {
        RaycastHit hitInfo;
        if (Physics.Raycast(origin, -Vector3.up, out hitInfo))
        {
          float distance = hitInfo.distance;
          if (hitInfo.transform.name != "Terrain" && this.TerrainOnly)
            flag = false;
          origin.y -= distance - this.AboveGround;
        }
        else
          flag = false;
      }
    }
    obj.transform.position = origin;
    this.transform.Rotate(Vector3.up * (float) Random.Range(0, 360), Space.World);
  }
}
