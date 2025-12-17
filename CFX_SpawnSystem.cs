// Decompiled with JetBrains decompiler
// Type: CFX_SpawnSystem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class CFX_SpawnSystem : MonoBehaviour
{
  private static CFX_SpawnSystem instance;
  public GameObject[] objectsToPreload = new GameObject[0];
  public int[] objectsToPreloadTimes = new int[0];
  public bool hideObjectsInHierarchy;
  public bool spawnAsChildren = true;
  public bool onlyGetInactiveObjects;
  public bool instantiateIfNeeded;
  private bool allObjectsLoaded;
  private Dictionary<int, List<GameObject>> instantiatedObjects = new Dictionary<int, List<GameObject>>();
  private Dictionary<int, int> poolCursors = new Dictionary<int, int>();

  public static GameObject GetNextObject(GameObject sourceObj, bool activateObject = true)
  {
    int instanceId = sourceObj.GetInstanceID();
    if (!CFX_SpawnSystem.instance.poolCursors.ContainsKey(instanceId))
    {
      Debug.LogError((object) $"[CFX_SpawnSystem.GetNextObject()] Object hasn't been preloaded: {sourceObj.name} (ID:{instanceId.ToString()})\n", (Object) CFX_SpawnSystem.instance);
      return (GameObject) null;
    }
    int poolCursor = CFX_SpawnSystem.instance.poolCursors[instanceId];
    GameObject nextObject;
    if (CFX_SpawnSystem.instance.onlyGetInactiveObjects)
    {
      int num = poolCursor;
      do
      {
        nextObject = CFX_SpawnSystem.instance.instantiatedObjects[instanceId][poolCursor];
        CFX_SpawnSystem.instance.increasePoolCursor(instanceId);
        poolCursor = CFX_SpawnSystem.instance.poolCursors[instanceId];
        if ((Object) nextObject != (Object) null && !nextObject.activeSelf)
          goto label_10;
      }
      while (poolCursor != num);
      if (CFX_SpawnSystem.instance.instantiateIfNeeded)
      {
        Debug.Log((object) $"[CFX_SpawnSystem.GetNextObject()] A new instance has been created for \"{sourceObj.name}\" because no active instance were found in the pool.\n", (Object) CFX_SpawnSystem.instance);
        CFX_SpawnSystem.PreloadObject(sourceObj);
        List<GameObject> instantiatedObject = CFX_SpawnSystem.instance.instantiatedObjects[instanceId];
        nextObject = instantiatedObject[instantiatedObject.Count - 1];
      }
      else
      {
        Debug.LogWarning((object) $"[CFX_SpawnSystem.GetNextObject()] There are no active instances available in the pool for \"{sourceObj.name}\"\nYou may need to increase the preloaded object count for this prefab?", (Object) CFX_SpawnSystem.instance);
        return (GameObject) null;
      }
    }
    else
    {
      nextObject = CFX_SpawnSystem.instance.instantiatedObjects[instanceId][poolCursor];
      CFX_SpawnSystem.instance.increasePoolCursor(instanceId);
    }
label_10:
    if (activateObject && (Object) nextObject != (Object) null)
      nextObject.SetActive(true);
    return nextObject;
  }

  public static void PreloadObject(GameObject sourceObj, int poolSize = 1)
  {
    CFX_SpawnSystem.instance.addObjectToPool(sourceObj, poolSize);
  }

  public static void UnloadObjects(GameObject sourceObj)
  {
    CFX_SpawnSystem.instance.removeObjectsFromPool(sourceObj);
  }

  public static bool AllObjectsLoaded => CFX_SpawnSystem.instance.allObjectsLoaded;

  private void addObjectToPool(GameObject sourceObject, int number)
  {
    int instanceId = sourceObject.GetInstanceID();
    if (!this.instantiatedObjects.ContainsKey(instanceId))
    {
      this.instantiatedObjects.Add(instanceId, new List<GameObject>());
      this.poolCursors.Add(instanceId, 0);
    }
    for (int index = 0; index < number; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(sourceObject);
      gameObject.SetActive(false);
      foreach (CFX_AutoDestructShuriken componentsInChild in gameObject.GetComponentsInChildren<CFX_AutoDestructShuriken>(true))
        componentsInChild.OnlyDeactivate = true;
      foreach (CFX_LightIntensityFade componentsInChild in gameObject.GetComponentsInChildren<CFX_LightIntensityFade>(true))
        componentsInChild.autodestruct = false;
      this.instantiatedObjects[instanceId].Add(gameObject);
      if (this.hideObjectsInHierarchy)
        gameObject.hideFlags = HideFlags.HideInHierarchy;
      if (this.spawnAsChildren)
        gameObject.transform.parent = this.transform;
    }
  }

  private void removeObjectsFromPool(GameObject sourceObject)
  {
    int instanceId = sourceObject.GetInstanceID();
    if (!this.instantiatedObjects.ContainsKey(instanceId))
    {
      Debug.LogWarning((object) $"[CFX_SpawnSystem.removeObjectsFromPool()] There aren't any preloaded object for: {sourceObject.name} (ID:{instanceId.ToString()})\n", (Object) this.gameObject);
    }
    else
    {
      for (int index = this.instantiatedObjects[instanceId].Count - 1; index >= 0; --index)
      {
        GameObject gameObject = this.instantiatedObjects[instanceId][index];
        this.instantiatedObjects[instanceId].RemoveAt(index);
        Object.Destroy((Object) gameObject);
      }
      this.instantiatedObjects.Remove(instanceId);
      this.poolCursors.Remove(instanceId);
    }
  }

  private void increasePoolCursor(int uniqueId)
  {
    CFX_SpawnSystem.instance.poolCursors[uniqueId]++;
    if (CFX_SpawnSystem.instance.poolCursors[uniqueId] < CFX_SpawnSystem.instance.instantiatedObjects[uniqueId].Count)
      return;
    CFX_SpawnSystem.instance.poolCursors[uniqueId] = 0;
  }

  private void Awake()
  {
    if ((Object) CFX_SpawnSystem.instance != (Object) null)
      Debug.LogWarning((object) "CFX_SpawnSystem: There should only be one instance of CFX_SpawnSystem per Scene!\n", (Object) this.gameObject);
    CFX_SpawnSystem.instance = this;
  }

  private void Start()
  {
    this.allObjectsLoaded = false;
    for (int index = 0; index < this.objectsToPreload.Length; ++index)
      CFX_SpawnSystem.PreloadObject(this.objectsToPreload[index], this.objectsToPreloadTimes[index]);
    this.allObjectsLoaded = true;
  }
}
