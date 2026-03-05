// Decompiled with JetBrains decompiler
// Type: TTT.ForceGrassDistanceInEditor
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace TTT
{
  [ExecuteInEditMode]
  public class ForceGrassDistanceInEditor : MonoBehaviour
  {
    public float distance = 250f;
    private Terrain terrain;

    private void Start()
    {
      this.terrain = this.GetComponent<Terrain>();
      if (!((Object) this.terrain == (Object) null))
        return;
      Debug.LogError((object) "This gameobject is not terrain, disabling forced details distance", (Object) this.gameObject);
      this.enabled = false;
    }

    private void Update() => this.terrain.detailObjectDistance = this.distance;
  }
}
