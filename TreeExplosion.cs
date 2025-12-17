// Decompiled with JetBrains decompiler
// Type: TreeExplosion
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class TreeExplosion : MonoBehaviour
{
  public float BlastRange = 30f;
  public float BlastForce = 30000f;
  public GameObject DeadReplace;
  public GameObject Explosion;

  private void Explode()
  {
    Object.Instantiate<GameObject>(this.Explosion, this.transform.position, Quaternion.identity);
    TerrainData terrainData = Terrain.activeTerrain.terrainData;
    ArrayList arrayList = new ArrayList();
    foreach (TreeInstance treeInstance in terrainData.treeInstances)
    {
      if ((double) Vector3.Distance(Vector3.Scale(treeInstance.position, terrainData.size) + Terrain.activeTerrain.transform.position, this.transform.position) < (double) this.BlastRange)
      {
        GameObject gameObject = Object.Instantiate<GameObject>(this.DeadReplace, Vector3.Scale(treeInstance.position, terrainData.size) + Terrain.activeTerrain.transform.position, Quaternion.identity);
        gameObject.GetComponent<Rigidbody>().maxAngularVelocity = 1f;
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(this.BlastForce, this.transform.position, (float) (20.0 + (double) this.BlastRange * 5.0), -20f);
      }
      else
        arrayList.Add((object) treeInstance);
    }
    terrainData.treeInstances = (TreeInstance[]) arrayList.ToArray(typeof (TreeInstance));
  }

  private void Update()
  {
    if (!Input.GetButtonDown("Fire1"))
      return;
    this.Explode();
  }
}
