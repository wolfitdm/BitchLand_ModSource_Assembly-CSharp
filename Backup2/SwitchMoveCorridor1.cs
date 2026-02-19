// Decompiled with JetBrains decompiler
// Type: SwitchMoveCorridor1
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SwitchMoveCorridor1 : MonoBehaviour
{
  [SerializeField]
  private GameObject corridor;
  [SerializeField]
  private GameObject player;
  [SerializeField]
  private GameObject switch2;
  private Transform corridorTr;
  private Transform playerTr;
  private CharacterController charCtrl;
  private SwitchMoveCorridor2 switch2Ref;

  [HideInInspector]
  public bool isTriggered { get; set; }

  private void Awake()
  {
    this.corridorTr = this.corridor.transform;
    this.playerTr = this.player.transform;
    this.charCtrl = this.player.GetComponent<CharacterController>();
    this.switch2Ref = this.switch2.GetComponent<SwitchMoveCorridor2>();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.name == "player") || this.isTriggered)
      return;
    this.isTriggered = true;
    this.switch2.gameObject.SetActive(true);
    this.switch2Ref.isTriggered = false;
    this.MoveCorridor();
    this.gameObject.SetActive(false);
  }

  private void MoveCorridor()
  {
    this.corridorTr.localPosition = new Vector3(12.4f, 111.6f, -77.9f);
    this.corridorTr.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.playerTr.SetParent(this.corridorTr);
  }
}
