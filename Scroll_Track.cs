// Decompiled with JetBrains decompiler
// Type: Scroll_Track
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Scroll_Track : MonoBehaviour
{
  [SerializeField]
  private float scrollSpeed = 0.05f;
  private float offset;
  private Renderer r;

  private void Start() => this.r = this.GetComponent<Renderer>();

  private void Update()
  {
    this.offset = (float) (((double) this.offset + (double) Time.deltaTime * (double) this.scrollSpeed) % 1.0);
    this.r.material.SetTextureOffset("_MainTex", new Vector2(this.offset, 0.0f));
  }
}
