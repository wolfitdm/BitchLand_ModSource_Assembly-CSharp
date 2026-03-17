// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Track_Scroll_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
