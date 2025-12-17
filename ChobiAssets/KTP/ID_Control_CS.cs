// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.ID_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP;

public class ID_Control_CS : MonoBehaviour
{
  [Header("ID settings")]
  [Tooltip("ID number")]
  public int id;
  [HideInInspector]
  public bool isPlayer;
  [HideInInspector]
  public Game_Controller_CS controllerScript;
  [HideInInspector]
  public TankProp storedTankProp;
  [HideInInspector]
  public Turret_Control_CS turretScript;
  [HideInInspector]
  public Camera_Zoom_CS mainCamScript;
  [HideInInspector]
  public GunCamera_Control_CS gunCamScript;
  [HideInInspector]
  public bool aimButton;
  [HideInInspector]
  public bool aimButtonDown;
  [HideInInspector]
  public bool aimButtonUp;
  [HideInInspector]
  public bool dragButton;
  [HideInInspector]
  public bool dragButtonDown;
  [HideInInspector]
  public bool fireButton;

  private void Start()
  {
    GameObject gameObjectWithTag = GameObject.FindGameObjectWithTag("GameController");
    if ((bool) (Object) gameObjectWithTag)
      this.controllerScript = gameObjectWithTag.GetComponent<Game_Controller_CS>();
    if ((bool) (Object) this.controllerScript)
      this.controllerScript.Receive_ID(this);
    else
      Debug.LogError((object) "There is no 'Game_Controller' in the scene.");
    this.BroadcastMessage("Get_ID_Script", (object) this, SendMessageOptions.DontRequireReceiver);
  }

  private void Update()
  {
    if (!this.isPlayer)
      return;
    this.aimButton = Input.GetKey(KeyCode.Space);
    this.aimButtonDown = Input.GetKeyDown(KeyCode.Space);
    this.aimButtonUp = Input.GetKeyUp(KeyCode.Space);
    this.dragButton = Input.GetMouseButton(1);
    this.dragButtonDown = Input.GetMouseButtonDown(1);
    this.fireButton = Input.GetMouseButton(0);
  }

  private void Destroy() => this.gameObject.tag = "Finish";

  public void Get_Current_ID(int currentID)
  {
    this.isPlayer = this.id == currentID;
    this.turretScript.Switch_Player(this.isPlayer);
    this.mainCamScript.Switch_Player(this.isPlayer);
    this.gunCamScript.Switch_Player(this.isPlayer);
  }
}
