// Decompiled with JetBrains decompiler
// Type: Spawner
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Spawner : MonoBehaviour
{
  public GameObject prefabToSpawn;
  public float spawnFrequency = 6f;
  public bool spawnOnStart;
  public bool move = true;
  public float moveAmount = 5f;
  public float turnAmount = 5f;
  private float spawnTimer;

  private void Start()
  {
    if (!this.spawnOnStart)
      return;
    this.Spawn();
  }

  private void Update()
  {
    this.spawnTimer += Time.deltaTime;
    if ((double) this.spawnTimer >= (double) this.spawnFrequency)
    {
      this.spawnTimer = 0.0f;
      this.Spawn();
    }
    this.transform.Translate(0.0f, 0.0f, this.moveAmount);
    this.transform.Rotate(0.0f, this.turnAmount, 0.0f);
  }

  private void Spawn()
  {
    if (!((Object) this.prefabToSpawn != (Object) null))
      return;
    Object.Instantiate<GameObject>(this.prefabToSpawn, this.transform.position, Quaternion.identity);
  }
}
