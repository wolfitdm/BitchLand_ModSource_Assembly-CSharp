// Decompiled with JetBrains decompiler
// Type: bl_PhotoMode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_PhotoMode : MonoBehaviour
{
  public static Transform _FreeCamGM;

  public static bool Active
  {
    get
    {
      return (UnityEngine.Object) bl_PhotoMode._FreeCamGM != (UnityEngine.Object) null && bl_PhotoMode._FreeCamGM.gameObject.activeSelf;
    }
    set
    {
      if (value)
        bl_PhotoMode.FlyWithCam();
      else
        bl_PhotoMode.StopFlyWithCam();
    }
  }

  public void Update()
  {
    if (Input.GetKeyUp(KeyCode.F2))
    {
      Canvas objectOfType = UnityEngine.Object.FindObjectOfType<Canvas>();
      objectOfType.enabled = !objectOfType.enabled;
    }
    if (Input.GetKeyUp(KeyCode.F3))
    {
      if (bl_PhotoMode.Active)
        bl_PhotoMode.Active = false;
      else if ((UnityEngine.Object) Main.Instance.Player != (UnityEngine.Object) null && Main.Instance.Player.gameObject.activeSelf)
        bl_PhotoMode.Active = true;
    }
    if (!Input.GetKeyUp(KeyCode.F4))
      return;
    if ((double) Time.timeScale == 0.0)
    {
      Main.Instance.Player.Anim.enabled = true;
      FreeCamRotation.NoDeltaTime = false;
      Time.timeScale = 1f;
    }
    else
    {
      Main.Instance.Player.Anim.enabled = false;
      FreeCamRotation.NoDeltaTime = true;
      Time.timeScale = 0.0f;
    }
  }

  public static Transform FreeCamGM
  {
    get
    {
      if ((UnityEngine.Object) bl_PhotoMode._FreeCamGM == (UnityEngine.Object) null)
      {
        bl_PhotoMode._FreeCamGM = new GameObject("PoseMod_FreeCam", new System.Type[1]
        {
          typeof (FreeCamRotation)
        }).transform;
        Camera camera = bl_PhotoMode._FreeCamGM.gameObject.AddComponent<Camera>();
        camera.nearClipPlane = 0.01f;
        camera.farClipPlane = 1000f;
      }
      return bl_PhotoMode._FreeCamGM;
    }
  }

  public static void FlyWithCam()
  {
    Main.Instance.Player.AddMoveBlocker("freecam");
    bl_PhotoMode.FreeCamGM.gameObject.SetActive(true);
  }

  public static void StopFlyWithCam()
  {
    Main.Instance.Player.RemoveMoveBlocker("freecam");
    bl_PhotoMode.FreeCamGM.gameObject.SetActive(false);
  }
}
