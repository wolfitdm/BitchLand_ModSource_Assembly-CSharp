// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Track_Scroll_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Track_Scroll_CS : MonoBehaviour
  {
    [Header("Scroll Animation settings")]
    [Tooltip("Reference wheel.")]
    public Transform referenceWheel;
    [Tooltip("Scroll Rate for X axis.")]
    public float scrollRate = 0.0005f;
    [Tooltip("Texture Name in the shader.")]
    public string textureName = "_MainTex";
    private Material thisMaterial;
    private float previousAng;
    private float offsetX;

    private void Awake()
    {
      this.thisMaterial = this.GetComponent<Renderer>().material;
      if (!((Object) this.referenceWheel == (Object) null))
        return;
      Debug.LogError((object) ("Reference Wheel is not assigned in " + this.name));
      Object.Destroy((Object) this);
    }

    private void Update()
    {
      float y = this.referenceWheel.localEulerAngles.y;
      this.offsetX += this.scrollRate * Mathf.DeltaAngle(y, this.previousAng);
      this.thisMaterial.SetTextureOffset(this.textureName, new Vector2(this.offsetX, 0.0f));
      this.previousAng = y;
    }

    private void Pause(bool isPaused) => this.enabled = !isPaused;
  }
}
