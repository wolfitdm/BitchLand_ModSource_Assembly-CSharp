// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Game_Controller_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Game_Controller_CS : MonoBehaviour
  {
    [Header("Game settings")]
    [Tooltip("Interval for physics calculations.")]
    public float fixedTimestep = 0.03f;
    [Header("Stage settings")]
    [Tooltip("Set the prefab of 'Touch_Controls'.")]
    public GameObject touchControlsPrefab;
    private List<ID_Control_CS> tankList;
    private int currentID;
    private bool isPaused;

    private void Awake()
    {
      Time.fixedDeltaTime = this.fixedTimestep;
      this.tankList = new List<ID_Control_CS>();
      this.tag = "GameController";
      for (int layer2 = 0; layer2 <= 11; ++layer2)
      {
        Physics.IgnoreLayerCollision(9, layer2, false);
        Physics.IgnoreLayerCollision(11, layer2, false);
      }
      Physics.IgnoreLayerCollision(9, 9, true);
      Physics.IgnoreLayerCollision(9, 11, true);
      for (int layer2 = 0; layer2 <= 11; ++layer2)
        Physics.IgnoreLayerCollision(10, layer2, true);
    }

    public void Receive_ID(ID_Control_CS idScript)
    {
      TankProp tankProp = new TankProp()
      {
        bodyRigidbody = idScript.GetComponentInChildren<Rigidbody>()
      };
      tankProp.bodyTransform = tankProp.bodyRigidbody.transform;
      idScript.storedTankProp = tankProp;
      this.tankList.Add(idScript);
      if (idScript.id == 0)
        idScript.isPlayer = true;
      else
        idScript.isPlayer = false;
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Tab))
      {
        ++this.currentID;
        if (this.currentID > this.tankList.Count - 1)
          this.currentID = 0;
        for (int index = 0; index < this.tankList.Count; ++index)
          this.tankList[index].Get_Current_ID(this.currentID);
      }
      if (Input.GetKeyDown(KeyCode.Escape))
        Application.Quit();
      if (Input.GetKeyDown(KeyCode.Backspace))
      {
        if (this.isPaused)
          this.Pause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
      if (!Input.GetKeyDown("p"))
        return;
      this.Pause();
    }

    private void Pause()
    {
      this.isPaused = !this.isPaused;
      Time.timeScale = !this.isPaused ? 1f : 0.0f;
      foreach (Component component in Object.FindObjectsOfType<ID_Control_CS>())
        component.BroadcastMessage(nameof (Pause), (object) this.isPaused, SendMessageOptions.DontRequireReceiver);
    }
  }
}
