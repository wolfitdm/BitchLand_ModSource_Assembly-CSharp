// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.GunCamera_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace ChobiAssets.KTP
{
  public class GunCamera_Control_CS : MonoBehaviour
  {
    [Header("Gun Camera settings")]
    [Tooltip("Main Camera of this tank.")]
    public Camera mainCamera;
    [Tooltip("Name of Image for Reticle.")]
    public string reticleName = "Reticle";
    private Camera thisCamera;
    private Image reticleImage;

    private void Awake()
    {
      this.tag = "MainCamera";
      this.thisCamera = this.GetComponent<Camera>();
      this.thisCamera.enabled = false;
      if ((Object) this.mainCamera == (Object) null)
      {
        Debug.LogError((object) "'Main Camera is not assigned in the Gun_Camera.");
        Object.Destroy((Object) this);
      }
      this.Find_Image();
    }

    private void Find_Image()
    {
      if (!string.IsNullOrEmpty(this.reticleName))
      {
        GameObject gameObject = GameObject.Find(this.reticleName);
        if ((bool) (Object) gameObject)
          this.reticleImage = gameObject.GetComponent<Image>();
      }
      if (!((Object) this.reticleImage == (Object) null))
        return;
      Debug.LogWarning((object) (this.reticleName + " (Image for Reticle) cannot be found in the scene."));
    }

    public void GunCam_On()
    {
      this.mainCamera.enabled = false;
      this.thisCamera.enabled = true;
      if (!(bool) (Object) this.reticleImage)
        return;
      this.reticleImage.enabled = true;
    }

    public void GunCam_Off()
    {
      this.thisCamera.enabled = false;
      this.mainCamera.enabled = true;
      if (!(bool) (Object) this.reticleImage)
        return;
      this.reticleImage.enabled = false;
    }

    private void Get_ID_Script(ID_Control_CS tempScript) => tempScript.gunCamScript = this;

    public void Switch_Player(bool isPlayer)
    {
      this.thisCamera.enabled = false;
      if (!(bool) (Object) this.reticleImage)
        return;
      this.reticleImage.enabled = false;
    }
  }
}
