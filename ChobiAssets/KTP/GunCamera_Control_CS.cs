// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.GunCamera_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace ChobiAssets.KTP;

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
