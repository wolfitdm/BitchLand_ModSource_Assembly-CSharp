// Decompiled with JetBrains decompiler
// Type: RandomSpawner
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RandomSpawner : MonoBehaviour
{
  public GameObject[] RandomObjects;
  public bool SpawnNonDespawnable;
  public bool SpawnNonSaveble;

  private void Start()
  {
    Transform transform = Object.Instantiate<GameObject>(this.RandomObjects[Random.Range(0, this.RandomObjects.Length)]).transform;
    transform.position = this.transform.position;
    transform.rotation = this.transform.rotation;
    if (this.SpawnNonDespawnable)
      transform.GetComponentInChildren<bl_MinableObject>().SpawnNonDespawnable = true;
    if (this.SpawnNonSaveble)
    {
      bl_MinableObject componentInChildren = transform.GetComponentInChildren<bl_MinableObject>();
      componentInChildren.DontSaveInMain = true;
      componentInChildren.AddToSaveableOnStart = false;
      componentInChildren.enabled = false;
    }
    Object.Destroy((Object) this.gameObject);
  }
}
