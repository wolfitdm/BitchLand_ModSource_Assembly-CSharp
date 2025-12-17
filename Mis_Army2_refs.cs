// Decompiled with JetBrains decompiler
// Type: Mis_Army2_refs
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Mis_Army2_refs : MonoBehaviour
{
  public Person EsbTankToSet;
  public RandomNPCHere[] OtherEsbSpawners;
  public Transform DriveStartSpot;
  public Transform ResapwnSpot;
  [Header("-------")]
  public Transform Breifing2_WarSpot;
  public Transform Breifing2_ZeaSpot;
  public Transform Breifing2_Spot1;
  public Transform Breifing2_Spot2;
  public Transform Breifing2_Spot3;
  public Transform Breifing2_PlayerSpot;
  [Header("-------")]
  public Transform Breifing3_WarSpot;
  public Transform Breifing3_ZeaSpot;
  public Transform Breifing3_Spot1;
  public Transform Breifing3_Spot2;
  public Transform Breifing3_Spot3;
  [Header("-------")]
  public GameObject ESBTank;
  public RandomNPCHere EsbSpawner;
  public Transform EnterTruckPart2Spot;
  public GameObject Trigger1;
  public GameObject Trigger2;
  public GameObject Trigger3;
  public Int_Door HouseDoor;
  public GameObject Bombs;
  public Transform TankHead;
  public Transform TankCannon;
  public Transform TruckParkSpot;

  public void Start()
  {
    this.EsbSpawner.PersonType = Main.Instance.PersonTypes[1].gameObject;
    for (int index = 0; index < this.OtherEsbSpawners.Length; ++index)
      this.OtherEsbSpawners[index].PersonType = Main.Instance.PersonTypes[1].gameObject;
    this.EsbTankToSet.PersonType = Main.Instance.PersonTypes[1];
    (Main.Instance.AllMissions[8] as Mis_Army2).AfterLoadingMiss();
  }

  public void EnterTrigger1() => (Main.Instance.AllMissions[8] as Mis_Army2).EnterTrigger1();

  public void EnterTrigger2() => (Main.Instance.AllMissions[8] as Mis_Army2).EnterTrigger2();

  public void EnterMiddleArea() => (Main.Instance.AllMissions[8] as Mis_Army2).EnterMiddleArea();

  public void HouseDoorOpened() => (Main.Instance.AllMissions[8] as Mis_Army2).HouseDoorOpened();

  public void ESBSpawn(Person person)
  {
    (Main.Instance.AllMissions[8] as Mis_Army2).ESBSpawn(person);
  }

  public void ESBSpawn2(Person person)
  {
    (Main.Instance.AllMissions[8] as Mis_Army2).ESBSpawn2(person);
  }

  public void EnterTrigger3() => (Main.Instance.AllMissions[8] as Mis_Army2).EnterTrigger3();
}
