// Decompiled with JetBrains decompiler
// Type: int_MineEntrance
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class int_MineEntrance : Interactible
{
  public bool MineEntrance;

  public override void Awake()
  {
    base.Awake();
    if (this.MineEntrance)
      return;
    bl_SectionGenerate2.ItemFallRespawnSpots_Mines.Add(this.RootObj.transform);
  }

  public override void Interact(Person person)
  {
    Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
    if (this.MineEntrance)
      Main.RunInNextFrame((Action) (() =>
      {
        int num = 6;
        if (!SceneManager.GetSceneByBuildIndex(num).isLoaded)
          SceneManager.LoadScene(num, LoadSceneMode.Additive);
        Main.RunInNextFrame((Action) (() => int_MineEntrance.StartLoadingMines((int) ((double) this.RootObj.transform.position.x / 4.5), (int) ((double) this.RootObj.transform.position.z / 4.5))), 2);
      }), 2);
    else
      Main.RunInNextFrame((Action) (() => this.StartExitingMines()), 2);
  }

  public static void StartLoadingMines(int x, int y)
  {
    Debug.Log((object) "StartLoadingMines()");
    Main.Instance.GlobalVars.Set("InsideMines", "1");
    bl_UndergroundMine2 objectOfType = UnityEngine.Object.FindObjectOfType<bl_UndergroundMine2>(true);
    objectOfType.gameObject.SetActive(true);
    objectOfType.PrevOn.Clear();
    foreach (GameObject rootGameObject in SceneManager.GetSceneByBuildIndex(5).GetRootGameObjects())
    {
      if (rootGameObject.activeSelf)
      {
        objectOfType.PrevOn.Add(rootGameObject);
        rootGameObject.SetActive(false);
      }
    }
    foreach (GameObject rootGameObject in SceneManager.GetSceneByBuildIndex(1).GetRootGameObjects())
    {
      if (rootGameObject.activeSelf)
      {
        objectOfType.PrevOn.Add(rootGameObject);
        rootGameObject.SetActive(false);
      }
    }
    Main.Instance.gameObject.SetActive(true);
    Main.Instance.Player.gameObject.SetActive(true);
    Main.Instance.GameplayMenu.transform.root.gameObject.SetActive(true);
    Main.Instance.Player.UserControl.m_Cam.root.gameObject.SetActive(true);
    Main.Instance.SexScene.SexSceneStructure.gameObject.SetActive(true);
    Scene sceneByBuildIndex = SceneManager.GetSceneByBuildIndex(6);
    SceneManager.SetActiveScene(sceneByBuildIndex);
    SceneManager.MoveGameObjectToScene(Main.Instance.Player.gameObject, sceneByBuildIndex);
    foreach (GameObject rootGameObject in sceneByBuildIndex.GetRootGameObjects())
      rootGameObject.SetActive(true);
    objectOfType.CreateNew(x, y, true);
  }

  public void StartExitingMines()
  {
    Main.Instance.GlobalVars.Set("InsideMines", "0");
    bl_UndergroundMine2 objectOfType = UnityEngine.Object.FindObjectOfType<bl_UndergroundMine2>();
    foreach (GameObject rootGameObject in SceneManager.GetSceneByBuildIndex(6).GetRootGameObjects())
      rootGameObject.SetActive(false);
    Scene _mainScene = SceneManager.GetSceneByBuildIndex(1);
    SceneManager.SetActiveScene(_mainScene);
    SceneManager.MoveGameObjectToScene(Main.Instance.Player.gameObject, _mainScene);
    for (int index = 0; index < objectOfType.PrevOn.Count; ++index)
    {
      GameObject gameObject = objectOfType.PrevOn[index];
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null && gameObject.scene.buildIndex != 6)
        gameObject.SetActive(true);
    }
    Main.Instance.gameObject.SetActive(true);
    Main.Instance.Player.gameObject.SetActive(true);
    Main.Instance.GameplayMenu.transform.root.gameObject.SetActive(true);
    Main.Instance.Lights.SetActive(true);
    Main.Instance.Player.UserControl.m_Cam.root.gameObject.SetActive(true);
    objectOfType.OnExitMines();
    foreach (Component component1 in Physics.OverlapSphere(this.transform.position, 100f))
    {
      int_MineEntrance component2 = component1.GetComponent<int_MineEntrance>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
      {
        Main.Instance.Player.transform.position = component2.NavMeshInteractSpot.position;
        for (int index = 0; index < Main.Instance.PeopleFollowingPlayer.Count; ++index)
        {
          Person _pp = Main.Instance.PeopleFollowingPlayer[index];
          _pp.AddMoveBlocker("teleporting");
          Main.RunInNextFrame((Action) (() =>
          {
            _pp.PlaceAt(Main.Instance.Player.transform.position);
            SceneManager.MoveGameObjectToScene(_pp.gameObject, _mainScene);
            _pp.gameObject.SetActive(true);
            _pp.RemoveMoveBlocker("teleporting");
          }), 2);
        }
        break;
      }
    }
    Main.RunInNextFrame((Action) (() => Main.Instance.NewGameMenu.SmallLoading.SetActive(false)), 2);
  }
}
