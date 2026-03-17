// Decompiled with JetBrains decompiler
// Type: PoolObject
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PoolObject : MonoBehaviour
{
  [HideInInspector]
  public bool IsPooling;

  public virtual void OnobjectReuse()
  {
  }

  public virtual void OnobjectReuse(Vector3 target, float speed)
  {
  }

  protected void Destroy(GameObject gameObject) => gameObject.SetActive(false);
}
