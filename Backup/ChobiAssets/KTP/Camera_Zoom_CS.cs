// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Camera_Zoom_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP;

public class Camera_Zoom_CS : MonoBehaviour
{
  private Transform thisTransform;
  private Transform parentTransform;
  private Transform rootTransform;
  private Camera thisCamera;
  private AudioListener thisAudioListener;
  private float posX;
  private float targetPosX;
  private int layerMask = -1029;
  private float storedPosX;
  private bool autoZoomFlag;
  private float hitCount;
  public float speed = 30f;
  private ID_Control_CS idScript;

  private void Awake()
  {
    this.tag = "MainCamera";
    this.thisCamera = this.GetComponent<Camera>();
    this.thisCamera.enabled = false;
    this.thisAudioListener = this.GetComponent<AudioListener>();
    this.thisAudioListener.enabled = false;
    this.thisTransform = this.transform;
    this.parentTransform = this.thisTransform.parent;
    this.rootTransform = this.thisTransform.root;
    this.posX = this.transform.localPosition.x;
    this.targetPosX = this.posX;
  }

  private void Update()
  {
    if (!this.idScript.isPlayer)
      return;
    float axis = Input.GetAxis("Mouse ScrollWheel");
    if ((double) axis != 0.0)
    {
      this.targetPosX -= axis * 30f;
      this.targetPosX = Mathf.Clamp(this.targetPosX, 3f, 20f);
    }
    if ((double) this.posX != (double) this.targetPosX)
    {
      this.posX = Mathf.MoveTowards(this.posX, this.targetPosX, this.speed * Time.deltaTime);
      this.thisTransform.localPosition = new Vector3(this.posX, this.thisTransform.localPosition.y, this.thisTransform.localPosition.z);
    }
    else
      this.Cast_Ray();
  }

  private void Cast_Ray()
  {
    foreach (RaycastHit raycastHit in Physics.SphereCastAll(new Ray(this.parentTransform.position, this.thisTransform.position - this.parentTransform.position), 0.5f, this.thisTransform.localPosition.x + 1f, this.layerMask))
    {
      if ((Object) raycastHit.transform.root != (Object) this.rootTransform)
      {
        this.hitCount += Time.deltaTime;
        if ((double) this.hitCount <= 0.5)
          return;
        this.hitCount = 0.0f;
        if (!this.autoZoomFlag)
        {
          this.autoZoomFlag = true;
          this.storedPosX = this.posX;
          this.targetPosX = raycastHit.distance;
          this.targetPosX = Mathf.Clamp(this.targetPosX, 3f, 20f);
          return;
        }
        if ((double) this.targetPosX <= (double) raycastHit.distance)
          return;
        this.targetPosX = raycastHit.distance;
        this.targetPosX = Mathf.Clamp(this.targetPosX, 3f, 20f);
        return;
      }
    }
    this.hitCount = 0.0f;
    if (!this.autoZoomFlag)
      return;
    this.autoZoomFlag = false;
    this.targetPosX = this.storedPosX;
  }

  private void Get_ID_Script(ID_Control_CS tempScript)
  {
    this.idScript = tempScript;
    if (this.idScript.isPlayer)
    {
      this.thisAudioListener.enabled = true;
      this.thisCamera.enabled = true;
    }
    this.idScript.mainCamScript = this;
  }

  private void Pause(bool isPaused) => this.enabled = !isPaused;

  public void Switch_Player(bool isPlayer)
  {
    this.thisAudioListener.enabled = isPlayer;
    this.thisCamera.enabled = isPlayer;
  }
}
