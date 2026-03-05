// Decompiled with JetBrains decompiler
// Type: Scroll_Track
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
