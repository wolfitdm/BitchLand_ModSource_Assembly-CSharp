// Decompiled with JetBrains decompiler
// Type: UI_SexScene
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UI_SexScene : UI_Menu
{
  public Dropdown SexTypeDrop;
  public Dropdown SexPoseDrop;
  public Dropdown DildoDrop;
  public Dropdown LeaderDrop;
  public Slider SpeedSlider;
  public Image QLeaveImage;
  public Image ENextImage;
  public Image FStealImage;
  public Image HIncapacitateImage;
  public Image TGatherJuicesImage;
  public Text TGatherJuicesText;
  public Text SexSubtitle;
  public Image ProgressSlider;
  public GameObject SexNotif;
  public Text SexNotifText;
  public e_BlendShapes[] ForcedFaces;
  public e_BlendShapes[] AheFaces;
  public AudioClip[] ShlickSounds;
  public AudioClip VibratorSound;
  public Image[] ArousalSliders;
  public GameObject PartnerUI;
  public Text PartnerName;
  public GameObject XPGraph;
  public GameObject XPLevelUp;
  public Image XPSlider;
  public Text XPText;
  public GameObject CanControlUI;
  public List<SexPose> FingerPoses;
  public List<SexPose> DildoPoses;
  public List<SexPose> SexPoses;
  public List<SexPose> FemSexPoses;
  public List<SexPose> CurrentPoses;
  public List<SexPose> ForcedPoses;
  public List<SexPose> NoEnergyPoses;
  public List<SexPose> FurniturePoses;
  public List<SexPose> CouchPoses;
  public Transform SexSceneStructure;
  public Transform[] SexSceneStructure_Dildos;
  public SpawnedSexScene PlayerSex;
  public Toggle ToggleVaginalAnal;
  public Text TextVaginalAnal;
  public Transform FocalPoint;
  public Transform SexPositioningArrow;
  public GameObject SexPositioningMenu;
  public bool _DontAdd;
  public float TGatherJuicesTimer;
  public bool _CondomIsOn;
  public bool CanExitSexScene;
  public Toggle ClothingToggle;
  public Vector3 OriginalPos;
  public Vector3 OriginalRot;
  public Slider XPos;
  public Slider YPos;
  public Slider ZPos;
  public Slider XRot;
  public Slider YRot;
  public Slider ZRot;
  public GameObject Sex2;
  public Text Sex2TimerUI;
  public float Sex2Timer;
  public Dropdown Sex2Pose;

  public void Click_SexPositioning()
  {
    this.SexPositioningMenu.SetActive(!this.SexPositioningMenu.activeSelf);
    if (this.SexPositioningMenu.activeSelf)
      this.SexPositioningArrow.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    else
      this.SexPositioningArrow.localEulerAngles = new Vector3(0.0f, 0.0f, 180f);
  }

  public SpawnedSexScene SpawnSexScene(
    int sexType,
    int sexPose,
    Person person1,
    Person person2 = null,
    Person person3 = null,
    bool receiveMoney = false,
    bool canControl = true,
    bool playerForcing = false,
    bool stopInteracting = true)
  {
    this.ProgressSlider.transform.parent.gameObject.SetActive(false);
    SpawnedSexScene spawnedSexScene = new GameObject("sex").AddComponent<SpawnedSexScene>();
    spawnedSexScene.Person1 = person1;
    spawnedSexScene.Person2 = person2;
    spawnedSexScene.Person3 = person3;
    spawnedSexScene.ReceiveMoney = receiveMoney;
    spawnedSexScene.init_StopInteracting = stopInteracting;
    if (!person1.IsPlayer && ((Object) person2 == (Object) null || !person2.IsPlayer))
    {
      spawnedSexScene.UISex = false;
    }
    else
    {
      if ((Object) person2 != (Object) null)
      {
        ++person1.TimesSexedPlayer;
        ++person2.TimesSexedPlayer;
        this.PartnerUI.SetActive(true);
        this.PartnerName.text = person2.Name;
      }
      else
        this.PartnerUI.SetActive(false);
      this.XPGraph.SetActive(false);
      spawnedSexScene.UISex = true;
    }
    spawnedSexScene.PlayerForcing = playerForcing;
    if ((Object) person2 != (Object) null)
      spawnedSexScene.ForcingPersonType = person2.PersonType.ThisType;
    spawnedSexScene.StartSex(sexType, sexPose, canControl);
    spawnedSexScene.transform.SetParent(spawnedSexScene.SpawnedSexSceneStructure);
    if (person1.IsPlayer)
      this.StartSexScene(sexType, sexPose);
    if ((Object) person2 != (Object) null && person2.IsPlayer)
      this.StartSexScene(sexType, sexPose);
    if (person1.IsPlayer || !((Object) person2 == (Object) null) && person2.IsPlayer)
    {
      this.OriginalPos = spawnedSexScene.SpawnedSexSceneStructure.position;
      this.OriginalRot = spawnedSexScene.SpawnedSexSceneStructure.eulerAngles;
    }
    return spawnedSexScene;
  }

  public void UICondomCheck()
  {
    this.TGatherJuicesImage.transform.parent.gameObject.SetActive(false);
    this._CondomIsOn = false;
    if (Main.Instance.Player.HavingSex_Scene.CurrentPose.ScatPose)
    {
      this.TGatherJuicesImage.transform.parent.gameObject.SetActive(true);
      this.TGatherJuicesText.text = "Shart";
      this.TGatherJuicesTimer = 5f;
    }
    else
    {
      if (!((Object) Main.Instance.Player.CurrentBackpack != (Object) null))
        return;
      for (int index = 0; index < Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems.Count; ++index)
      {
        if (Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].name.StartsWith("Condom Box") && Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].GetComponentInChildren<int_CondomBox>(true).Condoms > 0)
        {
          this.TGatherJuicesImage.transform.parent.gameObject.SetActive(true);
          this.TGatherJuicesText.text = "Put Condom";
          this.TGatherJuicesTimer = 5f;
          break;
        }
        if (Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].name == "Condom")
        {
          this.TGatherJuicesImage.transform.parent.gameObject.SetActive(true);
          this.TGatherJuicesText.text = "Put Condom";
          this.TGatherJuicesTimer = 5f;
          break;
        }
        if (Main.Instance.Player.Perks.Contains("Trash3"))
        {
          int_ResourceItem componentInChildren = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].GetComponentInChildren<int_ResourceItem>(true);
          if ((Object) componentInChildren != (Object) null && componentInChildren.ResourceType == e_ResourceType.Condom)
          {
            this.TGatherJuicesImage.transform.parent.gameObject.SetActive(true);
            this.TGatherJuicesText.text = "Put Condom";
            this.TGatherJuicesTimer = 5f;
            break;
          }
        }
      }
    }
  }

  public void SpawnCondomJuices()
  {
    this.TGatherJuicesImage.fillAmount = 0.0f;
    this.ShowNotification_Sex("Made \"Condom Filled with Love Juices\"");
    Main.Spawn(Main.Instance.AllPrefabs[147], saveable: true).transform.position = Main.Instance.Player.transform.position + new Vector3(0.0f, 0.1f, 0.0f);
  }

  public void SpawnCondomEmpty()
  {
    Main.Spawn(Main.Instance.AllPrefabs[152], saveable: true).transform.position = Main.Instance.Player.transform.position + new Vector3(0.0f, 0.1f, 0.0f);
  }

  public void EndSexScene()
  {
    if (this._CondomIsOn)
      this.SpawnCondomEmpty();
    this.HideNotification_Sex();
    Main.Instance.Player.UserControl.SexCamera.NOTGetMouseInput = false;
    if ((Object) this.PlayerSex == (Object) null)
      Debug.LogError((object) "PlayerSex is null!!!");
    else if ((Object) this.PlayerSex.SpawnedSexSceneStructure == (Object) null)
    {
      Debug.LogError((object) "PlayerSex.SpawnedSexSceneStructure is null!!!");
    }
    else
    {
      this.PlayerSex.SpawnedSexSceneStructure.position = this.OriginalPos;
      this.PlayerSex.SpawnedSexSceneStructure.eulerAngles = this.OriginalRot;
    }
    Main.Instance.Player.UserControl.SexCamera.enabled = false;
    Main.Instance.Player.UserControl.SexCamera.isPanning = false;
    Main.Instance.Player.UserControl.TheCam.enabled = true;
    Main.Instance.Player.UserControl.NoCamClip.enabled = true;
    if ((Object) this.PlayerSex != (Object) null)
    {
      this.MakePlayerInvis(false);
      this.PlayerSex.EndSex();
    }
    Main.Instance.OpenMenu("Gameplay");
    this.PlayerSex = (SpawnedSexScene) null;
  }

  public void StartSexScene(int sexType, int sexPose)
  {
    this.ResetPosSliders();
    this.HideNotification_Sex();
    this.CanExitSexScene = true;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    if (this.PlayerSex.Person1.IsPlayer)
    {
      this.PlayerSex.Person1.UserControl._ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
      this.PlayerSex.Person1.UserControl.FirstPerson = false;
    }
    if ((Object) this.PlayerSex.Person2 != (Object) null && this.PlayerSex.Person2.IsPlayer)
    {
      this.PlayerSex.Person2.UserControl._ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
      this.PlayerSex.Person2.UserControl.FirstPerson = false;
    }
    this.LeaderDrop.ClearOptions();
    List<string> options1 = new List<string>();
    options1.Add(this.PlayerSex.Person1.Name);
    if ((Object) this.PlayerSex.Person2 != (Object) null)
      options1.Add(this.PlayerSex.Person2.Name);
    if ((Object) this.PlayerSex.Person3 != (Object) null)
      options1.Add(this.PlayerSex.Person3.Name);
    this.LeaderDrop.AddOptions(options1);
    this.DildoDrop.ClearOptions();
    if (this.PlayerSex.CurrentDildos.Count > 0)
    {
      List<string> options2 = new List<string>();
      for (int index = 0; index < this.PlayerSex.CurrentDildos.Count; ++index)
        options2.Add(this.PlayerSex.CurrentDildos[index].RootObj.name);
      this.DildoDrop.AddOptions(options2);
    }
    else
      this.DildoDrop.AddOptions(new List<string>()
      {
        "None"
      });
    this.SexTypeDrop.SetValueWithoutNotify(sexType);
    this.SexPoseDrop.SetValueWithoutNotify(sexPose);
    Main.Instance.OpenMenu("Sex");
    this.Sex2.SetActive(false);
    this.SexSubtitle.text = string.Empty;
    this.CanControlUI.SetActive(this.PlayerSex.CanControl);
    this.QLeaveImage.fillAmount = 0.0f;
    this.ENextImage.fillAmount = 0.0f;
    this.FStealImage.fillAmount = 0.0f;
    this.HIncapacitateImage.fillAmount = 0.0f;
    this.TGatherJuicesImage.fillAmount = 0.0f;
    this.FStealImage.transform.parent.gameObject.SetActive(Main.Instance.Player.Perks.Contains("Prostitution skill lvl 3"));
    this.HIncapacitateImage.transform.parent.gameObject.SetActive(Main.Instance.Player.Perks.Contains("Prostitution skill lvl 4"));
    this.UICondomCheck();
    this._DontAdd = true;
    this.On_SexTypeChange();
    this.FocalPoint = this.PlayerSex.SpawnedSexSceneStructure.Find("FocalPoint");
    Main.Instance.Player.UserControl.SexCamera.focalPoint = this.FocalPoint;
    Main.Instance.Player.UserControl.SexCamera.enabled = true;
    Main.Instance.Player.UserControl.SexCamera.OnOpen();
    Main.Instance.Player.UserControl.TheCam.enabled = false;
    Main.Instance.Player.UserControl.NoCamClip.enabled = false;
    this.OnSpeedSliderChange();
  }

  public void On_SexTypeChange()
  {
    this.SexPoseDrop.ClearOptions();
    List<string> options = new List<string>();
    bool flag = this._DontAdd;
    switch (this.SexTypeDrop.value)
    {
      case 0:
        this.CurrentPoses = this.FingerPoses;
        goto default;
      case 1:
        if (this.PlayerSex.CurrentDildos.Count > 0)
        {
          this.CurrentPoses = this.DildoPoses;
          goto default;
        }
        else
        {
          this.DildoDrop.captionText.text = "None";
          options.Add("You need a Dildo");
          flag = true;
          break;
        }
      case 2:
        if ((Object) this.PlayerSex.Person2 != (Object) null)
        {
          switch (this.PlayerSex.ThisSexStateType)
          {
            case SexStateType.Normal:
              this.CurrentPoses = this.SexPoses;
              goto label_19;
            case SexStateType.Forced:
              if ((this.PlayerSex.Person1.IsPlayer ? this.PlayerSex.Person2 : this.PlayerSex.Person1).Favor > 0)
              {
                this.CurrentPoses = this.SexPoses;
                goto label_19;
              }
              else
              {
                options.Add("Can't while forcing");
                flag = true;
                break;
              }
            case SexStateType.Sleeping:
              options.Add("Partner is sleeping");
              flag = true;
              break;
            default:
              goto label_19;
          }
        }
        else
        {
          options.Add("You need a Partner");
          flag = true;
          break;
        }
        break;
      case 3:
        if ((Object) this.PlayerSex.Person2 != (Object) null)
        {
          this.CurrentPoses = this.NoEnergyPoses;
          goto default;
        }
        else
        {
          options.Add("You need a Partner");
          flag = true;
          break;
        }
      case 4:
        if ((Object) this.PlayerSex.Person2 != (Object) null)
        {
          this.CurrentPoses = this.ForcedPoses;
          goto default;
        }
        else
        {
          options.Add("You need a Partner");
          flag = true;
          break;
        }
      default:
label_19:
        for (int index = 0; index < this.CurrentPoses.Count; ++index)
        {
          if (Main.Instance.ScatContent || !this.CurrentPoses[index].ScatPose)
            options.Add(this.CurrentPoses[index].Name);
        }
        break;
    }
    this.SexPoseDrop.AddOptions(options);
    if (!flag)
      this.On_SexPoseChange();
    this._DontAdd = false;
  }

  public void On_SexPoseChange()
  {
    this.HideNotification_Sex();
    this.PlayerSex.StartPose(this.SexTypeDrop.value, this.SexPoseDrop.value);
    this.TGatherJuicesImage.fillAmount = 0.0f;
    if (Main.Instance.Player.HavingSex_Scene.CurrentPose.ScatPose)
    {
      this.TGatherJuicesImage.transform.parent.gameObject.SetActive(true);
      this.TGatherJuicesText.text = "Shart";
      this.TGatherJuicesTimer = 5f;
    }
    else
      this.UICondomCheck();
  }

  public void On_DildoChange()
  {
    if (this.PlayerSex.CurrentDildos.Count == 0)
      return;
    if (this.PlayerSex.CurrentDildos[this.DildoDrop.value].LargeDildo && !Main.Instance.Player.Perks.Contains("Gaping"))
      this.ShowNotification_Sex("Need Gaping Perk to use Large dildos");
    else
      this.PlayerSex.On_DildoChange(this.DildoDrop.value);
  }

  public void ShowNotification_Sex(string text)
  {
    this.SexNotifText.text = text;
    this.SexNotif.SetActive(true);
    this.Invoke("HideNotification_Sex", 3f);
  }

  public void HideNotification_Sex()
  {
    this.SexNotif.SetActive(false);
    this.SexNotifText.text = string.Empty;
  }

  public void Update()
  {
    this.ArousalSliders[0].fillAmount = Main.Instance.Player.Arousal;
    this.ArousalSliders[1].fillAmount = Main.Instance.Player.Arousal;
    this.ArousalSliders[2].fillAmount = Main.Instance.Player.Energy / Main.Instance.Player.EnergyMax;
    this.ArousalSliders[3].fillAmount = 0.0f;
    this.ArousalSliders[4].fillAmount = 0.0f;
    if ((Object) this.PlayerSex.Person2 != (Object) null)
    {
      Person person = this.PlayerSex.Person2.IsPlayer ? this.PlayerSex.Person1 : this.PlayerSex.Person2;
      if (person.Favor > 0)
        this.ArousalSliders[4].fillAmount = (float) person.Favor / 100f;
      else
        this.ArousalSliders[3].fillAmount = (float) -person.Favor / 100f;
      this.ArousalSliders[5].fillAmount = person.Arousal;
      this.ArousalSliders[6].fillAmount = person.Arousal;
      this.ArousalSliders[7].fillAmount = person.Energy / person.EnergyMax;
    }
    if (Input.GetKeyUp(KeyCode.Tab))
      Main.Instance.Player.UserControl.SexCamera.FirstPerson = !Main.Instance.Player.UserControl.SexCamera.FirstPerson;
    if (Input.GetKey(KeyCode.O))
      --Main.Instance.SettingsMenu.FOVSlider.value;
    if (Input.GetKey(KeyCode.P))
      ++Main.Instance.SettingsMenu.FOVSlider.value;
    if (!this.CanExitSexScene)
      return;
    this.QLeaveImage.fillAmount += Time.deltaTime / 10f;
    this.ENextImage.fillAmount += Time.deltaTime / 10f;
    if (!Main.Instance.GameplayMenu.gameObject.activeSelf)
    {
      if (this.FStealImage.gameObject.activeInHierarchy)
        this.FStealImage.fillAmount += Time.deltaTime / 15f;
      if (this.HIncapacitateImage.gameObject.activeInHierarchy)
        this.HIncapacitateImage.fillAmount += Time.deltaTime / 20f;
    }
    if (this.TGatherJuicesImage.gameObject.activeInHierarchy)
      this.TGatherJuicesImage.fillAmount += Time.deltaTime / this.TGatherJuicesTimer;
    if ((double) this.QLeaveImage.fillAmount > 0.949999988079071 && (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Q)))
    {
      this.EndSexScene();
    }
    else
    {
      if ((double) this.ENextImage.fillAmount > 0.949999988079071 && Input.GetKeyUp(KeyCode.E))
      {
        this.ENextImage.fillAmount = 0.0f;
        if (this.PlayerSex.TimerForRandomPoseChange)
        {
          this.PlayerSex.TimerPoseChange = 0.0f;
          return;
        }
      }
      if ((double) this.FStealImage.fillAmount > 0.949999988079071 && Input.GetKeyUp(KeyCode.F))
      {
        this.FStealImage.fillAmount = 0.0f;
        this.HIncapacitateImage.fillAmount = 0.0f;
        Person havingSexWith = Main.Instance.Player.HavingSexWith;
        if ((Object) havingSexWith != (Object) null)
        {
          if (havingSexWith.PersonType.ThisType != Person_Type.FES)
          {
            int index = Random.Range(110, 125);
            havingSexWith.InventoryStorage.AddItem(Main.Spawn(Main.Instance.AllPrefabs[index]));
          }
          Main.Instance.GameplayMenu.gameObject.SetActive(true);
          Main.Instance.GameplayMenu.OpenContainer((Int_Storage) havingSexWith.InventoryStorage);
          Main.Instance.GameplayMenu.OnCloseContainer.Clear();
          return;
        }
      }
      if ((double) this.HIncapacitateImage.fillAmount > 0.949999988079071 && Input.GetKeyUp(KeyCode.H))
      {
        this.HIncapacitateImage.fillAmount = 0.0f;
        Person havingSexWith = Main.Instance.Player.HavingSexWith;
        if ((Object) havingSexWith != (Object) null)
          havingSexWith.TheHealth.Incapacitate();
        this.EndSexScene();
      }
      else
      {
        if ((double) this.TGatherJuicesImage.fillAmount <= 0.949999988079071 || !Input.GetKeyUp(KeyCode.T))
          return;
        if (Main.Instance.Player.HavingSex_Scene.CurrentPose.ScatPose)
        {
          this.TGatherJuicesImage.fillAmount = 0.0f;
          Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[Random.Range(0, Main.Instance.ShitSounds.Count)]);
          switch (Main.Instance.Player.HavingSex_Scene.CurrentPose.PersonGettingShat)
          {
            case 0:
              Main.Instance.Player.HavingSex_Scene.Person1.States[33] = true;
              Main.Instance.Player.HavingSex_Scene.Person1.SetBodyTexture();
              Main.Instance.Player.HavingSex_Scene.Person2.Toilet -= 10f;
              if ((double) Main.Instance.Player.HavingSex_Scene.Person2.Toilet < 0.0)
                Main.Instance.Player.HavingSex_Scene.Person2.Toilet = 0.0f;
              Main.Instance.Player.HavingSex_Scene.Person1.GainSexXP(10);
              Main.Instance.Player.HavingSex_Scene.Person1.Hunger -= 10f;
              break;
            case 1:
              Main.Instance.Player.HavingSex_Scene.Person2.States[33] = true;
              Main.Instance.Player.HavingSex_Scene.Person2.SetBodyTexture();
              Main.Instance.Player.HavingSex_Scene.Person1.Toilet -= 10f;
              if ((double) Main.Instance.Player.HavingSex_Scene.Person1.Toilet < 0.0)
                Main.Instance.Player.HavingSex_Scene.Person1.Toilet = 0.0f;
              Main.Instance.Player.HavingSex_Scene.Person2.GainSexXP(10);
              Main.Instance.Player.HavingSex_Scene.Person2.Hunger -= 10f;
              break;
            case 3:
              Main.Instance.Player.HavingSex_Scene.Person1.States[3] = true;
              Main.Instance.Player.HavingSex_Scene.Person1.States[33] = true;
              Main.Instance.Player.HavingSex_Scene.Person1.SetBodyTexture();
              break;
            case 4:
              Main.Instance.Player.HavingSex_Scene.Person2.States[3] = true;
              Main.Instance.Player.HavingSex_Scene.Person2.States[33] = true;
              Main.Instance.Player.HavingSex_Scene.Person2.SetBodyTexture();
              break;
            case 5:
              Main.Instance.Player.HavingSex_Scene.Person1.States[3] = true;
              Main.Instance.Player.HavingSex_Scene.Person1.SetBodyTexture();
              break;
            case 6:
              Main.Instance.Player.HavingSex_Scene.Person2.States[3] = true;
              Main.Instance.Player.HavingSex_Scene.Person2.SetBodyTexture();
              break;
          }
        }
        else if (this._CondomIsOn)
        {
          this.UICondomCheck();
          this.SpawnCondomJuices();
        }
        else if ((double) Random.Range(0.0f, 1f) < 0.05000000074505806)
        {
          this.ShowNotification_Sex("Condom has broken and was discarded");
          for (int index = 0; index < Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems.Count; ++index)
          {
            if (Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].name.StartsWith("Condom Box"))
            {
              int_CondomBox componentInChildren = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].GetComponentInChildren<int_CondomBox>(true);
              if (componentInChildren.Condoms > 0)
              {
                --componentInChildren.Condoms;
                break;
              }
            }
            if (Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].name == "Condom")
            {
              GameObject storageItem = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index];
              Main.Instance.Player.CurrentBackpack.ThisStorage.RemoveItem(storageItem);
              Object.Destroy((Object) storageItem);
              break;
            }
            if (Main.Instance.Player.Perks.Contains("Trash3"))
            {
              int_ResourceItem componentInChildren = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].GetComponentInChildren<int_ResourceItem>(true);
              if ((Object) componentInChildren != (Object) null && componentInChildren.ResourceType == e_ResourceType.Condom)
              {
                GameObject storageItem = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index];
                Main.Instance.Player.CurrentBackpack.ThisStorage.RemoveItem(storageItem);
                Object.Destroy((Object) storageItem);
                break;
              }
            }
          }
        }
        else
        {
          this._CondomIsOn = true;
          if (Main.Instance.Player.Perks.Contains("Fluid Gather"))
          {
            this.TGatherJuicesImage.fillAmount = 0.0f;
            this.TGatherJuicesTimer = 20f;
            this.TGatherJuicesText.text = "Gather Love Juices";
          }
          else
            this.TGatherJuicesImage.transform.parent.gameObject.SetActive(false);
          for (int index = 0; index < Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems.Count; ++index)
          {
            if (Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].name.StartsWith("Condom Box"))
            {
              int_CondomBox componentInChildren = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].GetComponentInChildren<int_CondomBox>(true);
              if (componentInChildren.Condoms > 0)
              {
                --componentInChildren.Condoms;
                this.ShowNotification_Sex("Condom used");
                break;
              }
            }
            if (Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].name == "Condom")
            {
              GameObject storageItem = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index];
              Main.Instance.Player.CurrentBackpack.ThisStorage.RemoveItem(storageItem);
              Object.Destroy((Object) storageItem);
              this.ShowNotification_Sex("Condom used");
              break;
            }
            if (Main.Instance.Player.Perks.Contains("Trash3"))
            {
              int_ResourceItem componentInChildren = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].GetComponentInChildren<int_ResourceItem>(true);
              if ((Object) componentInChildren != (Object) null && componentInChildren.ResourceType == e_ResourceType.Condom)
              {
                GameObject storageItem = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index];
                Main.Instance.Player.CurrentBackpack.ThisStorage.RemoveItem(storageItem);
                Object.Destroy((Object) storageItem);
                this.ShowNotification_Sex("Condom used");
                break;
              }
            }
          }
        }
      }
    }
  }

  public void On_ClothingToggle()
  {
    if (this.PlayerSex.Person1.MainBody.enabled)
      this.PlayerSex.On_ClothingToggle_ind(this.PlayerSex.Person1, this.ClothingToggle.isOn);
    if (!((Object) this.PlayerSex.Person2 != (Object) null) || !this.PlayerSex.Person2.MainBody.enabled)
      return;
    this.PlayerSex.On_ClothingToggle_ind(this.PlayerSex.Person2, this.ClothingToggle.isOn);
  }

  public void On_playerInvis() => this.MakePlayerInvis(this.PlayerSex.Person1.MainBody.enabled);

  public void MakePlayerInvis(bool value)
  {
    if (value)
    {
      this.PlayerSex.Person1.MainBody.enabled = false;
      if ((Object) this.PlayerSex.Person1.CurrentHair != (Object) null)
      {
        foreach (Renderer componentsInChild in this.PlayerSex.Person1.CurrentHair.GetComponentsInChildren<Renderer>())
          componentsInChild.enabled = false;
      }
      this.PlayerSex.On_ClothingToggle_ind(this.PlayerSex.Person1, false);
    }
    else
    {
      this.PlayerSex.Person1.MainBody.enabled = true;
      if ((bool) (Object) this.PlayerSex.Person1.CurrentHair)
      {
        foreach (Renderer componentsInChild in this.PlayerSex.Person1.CurrentHair.GetComponentsInChildren<Renderer>())
          componentsInChild.enabled = true;
      }
      this.PlayerSex.On_ClothingToggle_ind(this.PlayerSex.Person1, this.ClothingToggle.isOn);
    }
  }

  public void OnToggleVaginalAnal()
  {
    if (this.PlayerSex.CurrentPose.HoleGoingInto == 2)
      return;
    if (this.ToggleVaginalAnal.isOn)
    {
      this.TextVaginalAnal.text = "Vaginal";
      this.PlayerSex.CurrentPose.HoleGoingInto = 0;
      this.PlayerSex.CurrentPose.GoIntoHole();
    }
    else
    {
      this.TextVaginalAnal.text = "Anal";
      this.PlayerSex.CurrentPose.HoleGoingInto = 1;
      this.PlayerSex.CurrentPose.GoIntoHole();
    }
  }

  public void OnLeaderChange()
  {
    this.MakePlayerInvis(false);
    switch (this.LeaderDrop.value)
    {
      case 0:
        if (this.PlayerSex.Person1.IsPlayer)
          break;
        if ((Object) this.PlayerSex.Person2 != (Object) null && this.PlayerSex.Person2.IsPlayer)
        {
          this.PlayerSex.SwapPeople(ref this.PlayerSex.Person1, ref this.PlayerSex.Person2);
          break;
        }
        if (!((Object) this.PlayerSex.Person3 != (Object) null) || !this.PlayerSex.Person3.IsPlayer)
          break;
        this.PlayerSex.SwapPeople(ref this.PlayerSex.Person1, ref this.PlayerSex.Person3);
        break;
      case 1:
        this.PlayerSex.SwapPeople(ref this.PlayerSex.Person1, ref this.PlayerSex.Person2);
        break;
      case 2:
        this.PlayerSex.SwapPeople(ref this.PlayerSex.Person1, ref this.PlayerSex.Person3);
        break;
    }
  }

  public void OnSpeedSliderChange()
  {
    this.PlayerSex.Person1.Anim.speed = this.SpeedSlider.value;
    if ((Object) this.PlayerSex.Person2 != (Object) null)
      this.PlayerSex.Person2.Anim.speed = this.SpeedSlider.value;
    if (!((Object) this.PlayerSex.Person3 != (Object) null))
      return;
    this.PlayerSex.Person3.Anim.speed = this.SpeedSlider.value;
  }

  public void ResetPosSliders()
  {
    this.XPos.SetValueWithoutNotify(0.0f);
    this.YPos.SetValueWithoutNotify(0.0f);
    this.ZPos.SetValueWithoutNotify(0.0f);
    this.XRot.SetValueWithoutNotify(0.0f);
    this.YRot.SetValueWithoutNotify(0.0f);
    this.ZRot.SetValueWithoutNotify(0.0f);
  }

  public void OnSliderXPos_Change()
  {
    this.PlayerSex.transform.parent.position = new Vector3(this.OriginalPos.x + this.XPos.value, this.PlayerSex.transform.parent.position.y, this.PlayerSex.transform.parent.position.z);
  }

  public void OnSliderYPos_Change()
  {
    this.PlayerSex.transform.parent.position = new Vector3(this.PlayerSex.transform.parent.position.x, this.OriginalPos.y + this.YPos.value, this.PlayerSex.transform.parent.position.z);
  }

  public void OnSliderZPos_Change()
  {
    this.PlayerSex.transform.parent.position = new Vector3(this.PlayerSex.transform.parent.position.x, this.PlayerSex.transform.parent.position.y, this.OriginalPos.z + this.ZPos.value);
  }

  public void OnSliderXRot_Change()
  {
    this.PlayerSex.transform.parent.eulerAngles = new Vector3(this.OriginalRot.x + this.XRot.value, this.PlayerSex.transform.parent.eulerAngles.y, this.PlayerSex.transform.parent.eulerAngles.z);
  }

  public void OnSliderYRot_Change()
  {
    this.PlayerSex.transform.parent.eulerAngles = new Vector3(this.PlayerSex.transform.parent.eulerAngles.x, this.OriginalRot.y + this.YRot.value, this.PlayerSex.transform.parent.eulerAngles.z);
  }

  public void OnSliderZRot_Change()
  {
    this.PlayerSex.transform.parent.eulerAngles = new Vector3(this.PlayerSex.transform.parent.eulerAngles.x, this.PlayerSex.transform.parent.eulerAngles.y, this.OriginalRot.z + this.ZRot.value);
  }

  public void Pointer_IN() => Main.Instance.Player.UserControl.SexCamera.NOTGetMouseInput = true;

  public void Pointer_OUT() => Main.Instance.Player.UserControl.SexCamera.NOTGetMouseInput = false;

  public void OpenSex2() => this.Sex2.SetActive(true);

  public void CloseSex2() => this.Sex2.SetActive(false);

  public void Sex2ChangePose()
  {
    this.HideNotification_Sex();
    this.PlayerSex.StartPose(6, this.Sex2Pose.value);
  }
}
