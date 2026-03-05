// Decompiled with JetBrains decompiler
// Type: SwitchMoveCorridor2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SwitchMoveCorridor2 : MonoBehaviour
{
  [SerializeField]
  private GameObject corridor;
  [SerializeField]
  private GameObject player;
  [SerializeField]
  private GameObject switch1;
  private Transform corridorTr;
  private Transform playerTr;
  private CharacterController charCtrl;
  private SwitchMoveCorridor1 switch1Ref;

  [HideInInspector]
  public bool isTriggered { get; set; }

  private void Awake()
  {
    this.corridorTr = this.corridor.transform;
    this.playerTr = this.player.transform;
    this.charCtrl = this.player.GetComponent<CharacterController>();
    this.switch1Ref = this.switch1.GetComponent<SwitchMoveCorridor1>();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.name == "player") || this.isTriggered)
      return;
    this.isTriggered = true;
    this.switch1.gameObject.SetActive(true);
    this.switch1Ref.isTriggered = false;
    this.MoveCorridor();
    this.gameObject.SetActive(false);
  }

  private void MoveCorridor()
  {
    this.charCtrl.enabled = false;
    this.corridorTr.localPosition = new Vector3(78.086f, 204.56f, -50.707f);
    this.corridorTr.eulerAngles = new Vector3(0.0f, -90f, 0.0f);
    this.charCtrl.enabled = true;
    this.playerTr.SetParent((Transform) null);
  }
}
