// Decompiled with JetBrains decompiler
// Type: PoolObject
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
