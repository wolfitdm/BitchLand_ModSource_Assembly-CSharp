// Decompiled with JetBrains decompiler
// Type: UI_Customize
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

#nullable disable
public class UI_Customize : UI_Menu
{
  public GameObject CustomizeRoom;
  public Person DisplayPerson;
  public Person DisplayPersonMale;
  public Person DisplayPersonMale2;
  public Person PresetLoaderNPC_F;
  public Color AmbientLight;
  public Image rot;
  public Toggle Clothes;
  public Toggle FaceView;
  public GameObject MainCam;
  public GameObject FaceCam;
  public GameObject DisableInPresets;
  public Dropdown CustomMenuList;
  public GameObject[] CustomMenus;
  public GameObject Warning;
  public GameObject ScatQuestion;
  public Dropdown GenderSettings;
  public GameObject MaleUnfinishedWarning3;
  public GameObject SeedQuestion;
  public InputField SeedInput;
  public GameObject[] EnabledWhileFemale;
  public GameObject[] EnabledWhileMale;
  [Header("hair")]
  public Dropdown HairList;
  public Toggle ReverseHairToggle;
  public Slider HairRedColor;
  public Slider HairGreenColor;
  public Slider HairBlueColor;
  public Dropdown BeardList;
  [Header("color")]
  public Slider EyeRedColor;
  public Slider EyeGreenColor;
  public Slider EyeBlueColor;
  public Slider SkinRedColor;
  public Slider SkinGreenColor;
  public Slider SkinBlueColor;
  [Header("body shapes")]
  public Slider BoobsPosX;
  public Slider BoobsPosY;
  public Slider BoobsPosZ;
  public Slider BoobsRotX;
  public Slider BoobsRotY;
  public Slider BoobsRotZ;
  public Slider BoobsSclX;
  public Slider BoobsSclY;
  public Slider BoobsSclZ;
  public Slider NipplesPosX;
  public Slider NipplesPosY;
  public Slider NipplesPosZ;
  public Slider NipplesRotX;
  public Slider NipplesRotY;
  public Slider NipplesRotZ;
  public Slider NipplesSclX;
  public Slider NipplesSclY;
  public Slider NipplesSclZ;
  public Slider AssPosX;
  public Slider AssPosY;
  public Slider AssPosZ;
  public Slider AssRotX;
  public Slider AssRotY;
  public Slider AssRotZ;
  public Slider AssSclX;
  public Slider AssSclY;
  public Slider AssSclZ;
  public Slider HipsSclX;
  public Slider HipsSclY;
  public Slider HipsSclZ;
  public Slider Hips2SclX;
  public Slider Hips2SclY;
  public Slider Hips2SclZ;
  public Slider BellySclX;
  public Slider BellySclY;
  public Slider BellySclZ;
  public Slider WaistSclX;
  public Slider WaistSclY;
  public Slider WaistSclZ;
  public Slider TorsoSclX;
  public Slider TorsoSclY;
  public Slider TorsoSclZ;
  public Slider NeckSclX;
  public Slider NeckSclY;
  public Slider NeckSclZ;
  public Slider UpperThighsSclX;
  public Slider UpperThighsSclY;
  public Slider UpperThighsSclZ;
  public Slider MidThighsSclX;
  public Slider MidThighsSclY;
  public Slider MidThighsSclZ;
  public Slider LowerThighsSclX;
  public Slider LowerThighsSclY;
  public Slider LowerThighsSclZ;
  public Slider CalvesSclX;
  public Slider CalvesSclY;
  public Slider CalvesSclZ;
  public Slider FeetSclX;
  public Slider FeetSclY;
  public Slider FeetSclZ;
  public Slider ShouldersSclX;
  public Slider ShouldersSclY;
  public Slider ShouldersSclZ;
  public Slider UpperArmsSclX;
  public Slider UpperArmsSclY;
  public Slider UpperArmsSclZ;
  public Slider ForeArmsSclX;
  public Slider ForeArmsSclY;
  public Slider ForeArmsSclZ;
  public Slider HandsSclX;
  public Slider HandsSclY;
  public Slider HandsSclZ;
  [Header("face shapes")]
  public Slider HeadPosX;
  public Slider HeadPosY;
  public Slider HeadPosZ;
  public Slider HeadRotX;
  public Slider HeadRotY;
  public Slider HeadRotZ;
  public Slider HeadSclX;
  public Slider HeadSclY;
  public Slider HeadSclZ;
  public Slider MouthPosX;
  public Slider MouthPosY;
  public Slider MouthPosZ;
  public Slider MouthRot;
  public Slider MouthSclX;
  public Slider MouthSclY;
  public Slider MouthSclZ;
  public Slider MouthSidesPosX;
  public Slider MouthSidesPosY;
  public Slider MouthSidesPosZ;
  public Slider MouthSidesSclX;
  public Slider MouthSidesSclY;
  public Slider MouthSidesSclZ;
  public Slider MouthTop;
  public Slider MouthLow;
  public Slider CheeksPosX;
  public Slider CheeksPosY;
  public Slider CheeksPosZ;
  public Slider JawPosX;
  public Slider JawPosY;
  public Slider JawPosZ;
  public Slider JawRotX;
  public Slider JawRotY;
  public Slider JawRotZ;
  public Slider JawSclX;
  public Slider JawSclY;
  public Slider JawSclZ;
  public Slider JawLowPosX;
  public Slider JawLowPosY;
  public Slider JawLowPosZ;
  public Slider JawLowRotX;
  public Slider JawLowRotY;
  public Slider JawLowRotZ;
  public Slider JawLowSclX;
  public Slider JawLowSclY;
  public Slider JawLowSclZ;
  public Slider ChinPosX;
  public Slider ChinPosY;
  public Slider ChinPosZ;
  public Slider ChinRotX;
  public Slider ChinRotY;
  public Slider ChinRotZ;
  public Slider ChinSclX;
  public Slider ChinSclY;
  public Slider ChinSclZ;
  public Slider EarsPosX;
  public Slider EarsPosY;
  public Slider EarsPosZ;
  public Slider EarsRotX;
  public Slider EarsRotY;
  public Slider EarsRotZ;
  public Slider EarsSclX;
  public Slider EarsSclY;
  public Slider EarsSclZ;
  public Slider EarsLowPosX;
  public Slider EarsLowPosY;
  public Slider EarsLowPosZ;
  public Slider EarsLowRotX;
  public Slider EarsLowRotY;
  public Slider EarsLowRotZ;
  public Slider EarsLowSclX;
  public Slider EarsLowSclY;
  public Slider EarsLowSclZ;
  public Slider EarsHighPosX;
  public Slider EarsHighPosY;
  public Slider EarsHighPosZ;
  public Slider EarsHighRotX;
  public Slider EarsHighRotY;
  public Slider EarsHighRotZ;
  public Slider EarsHighSclX;
  public Slider EarsHighSclY;
  public Slider EarsHighSclZ;
  public Slider NosePosX;
  public Slider NosePosY;
  public Slider NosePosZ;
  public Slider NoseRotX;
  public Slider NoseRotY;
  public Slider NoseRotZ;
  public Slider NoseSclX;
  public Slider NoseSclY;
  public Slider NoseSclZ;
  public Slider NoseBridgePosX;
  public Slider NoseBridgePosY;
  public Slider NoseBridgePosZ;
  public Slider NoseBridgeRotX;
  public Slider NoseBridgeRotY;
  public Slider NoseBridgeRotZ;
  public Slider NoseBridgeSclX;
  public Slider NoseBridgeSclY;
  public Slider NoseBridgeSclZ;
  public Slider NoseTipPosX;
  public Slider NoseTipPosY;
  public Slider NoseTipPosZ;
  public Slider NoseTipRotX;
  public Slider NoseTipRotY;
  public Slider NoseTipRotZ;
  public Slider NoseTipSclX;
  public Slider NoseTipSclY;
  public Slider NoseTipSclZ;
  public Slider NostrilsPosX;
  public Slider NostrilsPosY;
  public Slider NostrilsPosZ;
  public Slider NostrilsRotX;
  public Slider NostrilsRotY;
  public Slider NostrilsRotZ;
  public Slider NostrilsSclX;
  public Slider NostrilsSclY;
  public Slider NostrilsSclZ;
  public Slider EyesPosX;
  public Slider EyesPosY;
  public Slider EyesPosZ;
  public Slider EyesRotX;
  public Slider EyesRotY;
  public Slider EyesRotZ;
  public Slider EyesSclX;
  public Slider EyesSclY;
  public Slider EyesSclZ;
  public Slider EyesTopPosX;
  public Slider EyesTopPosY;
  public Slider EyesTopPosZ;
  public Slider EyesTopRotX;
  public Slider EyesTopRotY;
  public Slider EyesTopRotZ;
  public Slider EyesTopSclX;
  public Slider EyesTopSclY;
  public Slider EyesTopSclZ;
  public Slider EyesLowPosX;
  public Slider EyesLowPosY;
  public Slider EyesLowPosZ;
  public Slider EyesLowRotX;
  public Slider EyesLowRotY;
  public Slider EyesLowRotZ;
  public Slider EyesLowSclX;
  public Slider EyesLowSclY;
  public Slider EyesLowSclZ;
  public Slider EyesInnerPosX;
  public Slider EyesInnerPosY;
  public Slider EyesInnerPosZ;
  public Slider EyesInnerRotX;
  public Slider EyesInnerRotY;
  public Slider EyesInnerRotZ;
  public Slider EyesInnerSclX;
  public Slider EyesInnerSclY;
  public Slider EyesInnerSclZ;
  public Slider EyesOuterPosX;
  public Slider EyesOuterPosY;
  public Slider EyesOuterPosZ;
  public Slider EyesOuterRotX;
  public Slider EyesOuterRotY;
  public Slider EyesOuterRotZ;
  public Slider EyesOuterSclX;
  public Slider EyesOuterSclY;
  public Slider EyesOuterSclZ;
  public Slider Malejaw;
  public Slider MaleChin;
  public Slider MaleNoseRot;
  public Slider MaleNoseSclX;
  public Slider MaleNoseSclY;
  public Slider MaleNoseSclZ;
  public Slider MaleEyesPosX;
  public Slider MaleEyesPosY;
  public Slider MaleEyesRot;
  public Slider MaleEyesScl;
  public RectTransform[] CustomTexContent;
  public GameObject[] CustomTexEntry;
  public List<GameObject>[] CustomTexEntrySpawned;
  public bool NotFirstOpen;
  public Transform ZoomCam;
  public float t;
  public float scrollInput;
  public float transitionSpeed = 1f;
  public bool ClothesEnabled = true;
  private bool RotateChar;
  public GameObject RotImage;
  public Toggle Female;
  public Toggle Futa;
  public Toggle HasBalls;
  public Slider PenisSize;
  public UnityEngine.UI.Text StoryGenderText;
  public Toggle AltBody;
  public GameObject MaleWarningMsg;
  public Dropdown GenderDrop;
  public GameObject NotAvailableLabel;
  public GameObject NotAvailableLabel2;
  public Button FinishBtn;
  public Slider FutaChanceSlider;
  public UnityEngine.UI.Text FutaChanceText;
  public static float FutaChanceValue = 0.2f;
  [Header("save -----")]
  public GameObject PictureFrame;
  public Vector2Int Camposition = new Vector2Int(0, 0);
  public RenderTexture RenTex;
  public RenderTexture RenTexUI;
  public GameObject MainCustomMenu;
  public UnityEngine.UI.Text PicSavedText;
  public GameObject SaveTorsoCam;
  public GameObject SaveFaceCam;
  public Transform SaveTorsoCam_Position;
  public Transform SaveFaceCam_Position;
  public Transform SaveTorsoCam_Position_preset;
  public Transform SaveFaceCam_Position_preset;
  public bool InPresets;
  public bool PresetsFace;
  [Header("Character list-----------------")]
  public RectTransform CharacterListRect;
  public GameObject CharacterEntry;
  public List<GameObject> CharacterEntries = new List<GameObject>();
  public List<misc_CharacterLoadEntry> CharacterEntries2 = new List<misc_CharacterLoadEntry>();
  public misc_CharacterLoadEntry SelectedCharacter;
  public GameObject LoadCharcterListMenu;
  public bool CurrentLoadFolderGirls;
  public InputField PlayerNameField;
  public Toggle[] FetishToggles;
  public Toggle[] FaceStateToggles;
  public Toggle[] BodyStateToggles;
  public Slider HeightSlider;
  public UnityEngine.UI.Text HeightText;
  public Dropdown PersonalityDrop;
  public Slider PregnancySlider;
  public string[] PersonaIdles;
  public UnityEngine.UI.Text PreviewNameLabel;
  [Space]
  public GameObject[] ThingsToDisableOnGameplayCustomize;
  public GameObject[] ThingsToEnableOnGameplayHairStyle;
  public GameObject[] ThingsToEnableOnGameplayHairColor;
  public GameObject[] ThingsToEnableOnGameplayMakeup;
  public GameObject[] ThingsToEnableOnGameplayRecolor;
  public Toggle[] StateTogglesToDisableInGameplay;
  public bool DURINGGAMEPLAY;
  public Slider ClotheColorR;
  public Slider ClotheColorG;
  public Slider ClotheColorB;
  public Dressable SelectedClothe;
  public GameObject Debug_Menu;
  public UnityEngine.UI.Text Debug_ValuesNow;
  public UnityEngine.UI.Text Debug_ValuesToSet;

  public UI_Customize() => this.MenuName = "CustomizePlayer";

  public override void Open()
  {
    this.MaleUnfinishedWarning3.SetActive(false);
    if (!this.NotFirstOpen)
    {
      this.NotFirstOpen = true;
      this.DisplayPerson.States[22] = true;
      this.CustomTexEntrySpawned = new List<GameObject>[2];
      this.CustomTexEntrySpawned[0] = new List<GameObject>();
      this.CustomTexEntrySpawned[1] = new List<GameObject>();
    }
    for (int index = 0; index < this.CustomTexEntrySpawned[0].Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.CustomTexEntrySpawned[0][index]);
    for (int index = 0; index < this.CustomTexEntrySpawned[1].Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.CustomTexEntrySpawned[1][index]);
    this.CustomTexEntrySpawned[0].Clear();
    this.CustomTexEntrySpawned[1].Clear();
    Main.Instance.GetCustomTextures();
    if (this.DisplayPerson._CustomSkinStates.Length != Main.Instance._CustomBodySkinsName.Count)
      this.DisplayPerson._CustomSkinStates = new bool[Main.Instance._CustomBodySkinsName.Count];
    if (this.DisplayPerson._CustomFaceSkinStates.Length != Main.Instance._CustomFaceSkinsName.Count)
      this.DisplayPerson._CustomFaceSkinStates = new bool[Main.Instance._CustomFaceSkinsName.Count];
    for (int index = 0; index < Main.Instance._CustomBodySkinsName.Count; ++index)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.CustomTexEntry[0], (Transform) this.CustomTexContent[0]);
      gameObject.SetActive(true);
      bl_misqToggleClick component = gameObject.GetComponent<bl_misqToggleClick>();
      component.Index = index;
      component.OnClick = new Action<bool, int>(this.Click_CustomBodyTex);
      gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = Main.Instance._CustomBodySkinsName[index];
      this.CustomTexEntrySpawned[0].Add(gameObject);
    }
    for (int index = 0; index < Main.Instance._CustomFaceSkinsName.Count; ++index)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.CustomTexEntry[1], (Transform) this.CustomTexContent[1]);
      gameObject.SetActive(true);
      bl_misqToggleClick component = gameObject.GetComponent<bl_misqToggleClick>();
      component.Index = index;
      component.OnClick = new Action<bool, int>(this.Click_CustomFaceTex);
      gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = Main.Instance._CustomFaceSkinsName[index];
      this.CustomTexEntrySpawned[1].Add(gameObject);
    }
    this.CustomTexContent[0].sizeDelta = new Vector2(0.0f, (float) (this.CustomTexContent[0].childCount * 20));
    this.CustomTexContent[1].sizeDelta = new Vector2(0.0f, (float) (this.CustomTexContent[1].childCount * 20));
    List<string> options = new List<string>();
    if (!this.DURINGGAMEPLAY)
    {
      this.Click_LockMorfScales();
      this.CLoseSaveMenus();
      this.CurrentLoadFolderGirls = true;
      if ((UnityEngine.Object) Main.Instance.NewGameMenu.NewGameThings != (UnityEngine.Object) null)
        Main.Instance.NewGameMenu.NewGameThings.SetActive(false);
    }
    base.Open();
    if (!this.DURINGGAMEPLAY)
    {
      this.CustomizeRoom.SetActive(true);
      this.ShowDisplayClothes();
      RenderSettings.ambientLight = this.AmbientLight;
      Main.Instance.Lights.SetActive(false);
      this.Clothes.isOn = true;
      this.Warning.SetActive(false);
      this.ScatQuestion.SetActive(false);
      for (int index = 0; index < this.BodyStateToggles.Length; ++index)
      {
        if ((UnityEngine.Object) this.BodyStateToggles[index] != (UnityEngine.Object) null)
          this.BodyStateToggles[index].SetIsOnWithoutNotify(this.DisplayPerson.States[index]);
      }
      for (int index = 0; index < this.FaceStateToggles.Length; ++index)
      {
        if ((UnityEngine.Object) this.FaceStateToggles[index] != (UnityEngine.Object) null)
          this.FaceStateToggles[index].SetIsOnWithoutNotify(this.DisplayPerson.States[index]);
      }
      this.CustomMenuList.value = 0;
      this.ChangeCustomMenu();
    }
    if (!this.DURINGGAMEPLAY)
    {
      this.HairRedColor.value = Main.Instance.Player.NaturalHairColor.r;
      this.HairGreenColor.value = Main.Instance.Player.NaturalHairColor.g;
      this.HairBlueColor.value = Main.Instance.Player.NaturalHairColor.b;
    }
    else
    {
      Color color = Main.Instance.Player.NaturalHairColor;
      if (Main.Instance.Player.DyedHairColor != new Color(0.0f, 0.0f, 0.0f, 0.0f))
        color = Main.Instance.Player.DyedHairColor;
      this.HairRedColor.SetValueWithoutNotify(color.r);
      this.HairGreenColor.SetValueWithoutNotify(color.g);
      this.HairBlueColor.SetValueWithoutNotify(color.b);
    }
    for (int index = 0; index < Main.Instance.Prefabs_Hair.Count; ++index)
    {
      if ((UnityEngine.Object) Main.Instance.Prefabs_Hair[index] != (UnityEngine.Object) null)
        options.Add(Main.Instance.Prefabs_Hair[index].name);
    }
    this.HairList.ClearOptions();
    this.HairList.AddOptions(options);
    this.HairList.RefreshShownValue();
    if (!this.DURINGGAMEPLAY)
    {
      this.EyeRedColor.value = Main.Instance.Player.NaturalEyeColor.r;
      this.EyeGreenColor.value = Main.Instance.Player.NaturalEyeColor.g;
      this.EyeBlueColor.value = Main.Instance.Player.NaturalEyeColor.b;
      this.SkinRedColor.value = Main.Instance.Player.NaturalSkinColor.r;
      this.SkinGreenColor.value = Main.Instance.Player.NaturalSkinColor.g;
      this.SkinBlueColor.value = Main.Instance.Player.NaturalSkinColor.b;
      this.UpdateValuesFrom(Main.Instance.Player);
      this.PregnancySlider.value = 0.0f;
      this.HeightSlider.value = 1f;
      this.PersonalityDrop.value = 0;
      for (int index = 0; index < this.FetishToggles.Length; ++index)
        this.FetishToggles[index].SetIsOnWithoutNotify(false);
      this.Click_AddFaceState(22);
    }
    else
    {
      for (int index = 0; index < this.BodyStateToggles.Length; ++index)
      {
        if ((UnityEngine.Object) this.BodyStateToggles[index] != (UnityEngine.Object) null)
          this.BodyStateToggles[index].SetIsOnWithoutNotify(Main.Instance.Player.States[index]);
      }
      for (int index = 0; index < this.FaceStateToggles.Length; ++index)
      {
        if ((UnityEngine.Object) this.FaceStateToggles[index] != (UnityEngine.Object) null)
          this.FaceStateToggles[index].SetIsOnWithoutNotify(Main.Instance.Player.States[index]);
      }
    }
  }

  public float ARGHTHENUMBERROTATION(float value, float max)
  {
    return (double) value <= (double) max ? value : value - 360f;
  }

  public void UpdateValuesFrom(Person person)
  {
    this.BoobsPosX.SetValueWithoutNotify(person.BoobLeft.localPosition.x);
    this.BoobsPosY.SetValueWithoutNotify(person.BoobLeft.localPosition.y);
    this.BoobsPosZ.SetValueWithoutNotify(person.BoobLeft.localPosition.z);
    this.BoobsRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.BoobLeft.localEulerAngles.x, this.BoobsRotX.maxValue));
    this.BoobsRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.BoobLeft.localEulerAngles.y, this.BoobsRotY.maxValue));
    this.BoobsRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.BoobLeft.localEulerAngles.z, this.BoobsRotZ.maxValue));
    this.BoobsSclX.SetValueWithoutNotify(person.BoobLeft.localScale.x);
    this.BoobsSclY.SetValueWithoutNotify(person.BoobLeft.localScale.y);
    this.BoobsSclZ.SetValueWithoutNotify(person.BoobLeft.localScale.z);
    this.NipplesPosX.SetValueWithoutNotify(person.NippleLeft.localPosition.x);
    this.NipplesPosY.SetValueWithoutNotify(person.NippleLeft.localPosition.y);
    this.NipplesPosZ.SetValueWithoutNotify(person.NippleLeft.localPosition.z);
    this.NipplesRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NippleLeft.localEulerAngles.x, this.NipplesRotX.maxValue));
    this.NipplesRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NippleLeft.localEulerAngles.y, this.NipplesRotY.maxValue));
    this.NipplesRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NippleLeft.localEulerAngles.z, this.NipplesRotZ.maxValue));
    this.NipplesSclX.SetValueWithoutNotify(person.NippleLeft.localScale.x);
    this.NipplesSclY.SetValueWithoutNotify(person.NippleLeft.localScale.y);
    this.NipplesSclZ.SetValueWithoutNotify(person.NippleLeft.localScale.z);
    this.AssPosX.SetValueWithoutNotify(person.AssCheekLeft.localPosition.x);
    this.AssPosY.SetValueWithoutNotify(person.AssCheekLeft.localPosition.y);
    this.AssPosZ.SetValueWithoutNotify(person.AssCheekLeft.localPosition.z);
    this.AssRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.AssCheekLeft.localEulerAngles.x, this.AssRotX.maxValue));
    this.AssRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.AssCheekLeft.localEulerAngles.y, this.AssRotX.maxValue));
    this.AssRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.AssCheekLeft.localEulerAngles.z, this.AssRotX.maxValue));
    this.AssSclX.SetValueWithoutNotify(person.AssCheekLeft.localScale.x);
    this.AssSclY.SetValueWithoutNotify(person.AssCheekLeft.localScale.y);
    this.AssSclZ.SetValueWithoutNotify(person.AssCheekLeft.localScale.z);
    this.HipsSclX.SetValueWithoutNotify(person.Hips.localScale.x);
    this.HipsSclY.SetValueWithoutNotify(person.Hips.localScale.y);
    this.HipsSclZ.SetValueWithoutNotify(person.Hips.localScale.z);
    this.Hips2SclX.SetValueWithoutNotify(person.Hips2.localScale.x);
    this.Hips2SclY.SetValueWithoutNotify(person.Hips2.localScale.y);
    this.Hips2SclZ.SetValueWithoutNotify(person.Hips2.localScale.z);
    this.BellySclX.SetValueWithoutNotify(person.Belly.localScale.x);
    this.BellySclY.SetValueWithoutNotify(person.Belly.localScale.y);
    this.BellySclZ.SetValueWithoutNotify(person.Belly.localScale.z);
    this.WaistSclX.SetValueWithoutNotify(person.Waist.localScale.x);
    this.WaistSclY.SetValueWithoutNotify(person.Waist.localScale.y);
    this.WaistSclZ.SetValueWithoutNotify(person.Waist.localScale.z);
    this.TorsoSclX.SetValueWithoutNotify(person.Torso.localScale.x);
    this.TorsoSclY.SetValueWithoutNotify(person.Torso.localScale.y);
    this.TorsoSclZ.SetValueWithoutNotify(person.Torso.localScale.z);
    this.NeckSclX.SetValueWithoutNotify(person.Neck.localScale.x);
    this.NeckSclY.SetValueWithoutNotify(person.Neck.localScale.y);
    this.NeckSclZ.SetValueWithoutNotify(person.Neck.localScale.z);
    this.UpperThighsSclX.SetValueWithoutNotify(person.UpperThighLeft.localScale.x);
    this.UpperThighsSclY.SetValueWithoutNotify(person.UpperThighLeft.localScale.y);
    this.UpperThighsSclZ.SetValueWithoutNotify(person.UpperThighLeft.localScale.z);
    this.MidThighsSclX.SetValueWithoutNotify(person.MidThighLeft.localScale.x);
    this.MidThighsSclY.SetValueWithoutNotify(person.MidThighLeft.localScale.y);
    this.MidThighsSclZ.SetValueWithoutNotify(person.MidThighLeft.localScale.z);
    this.LowerThighsSclX.SetValueWithoutNotify(person.LowerThighLeft.localScale.x);
    this.LowerThighsSclY.SetValueWithoutNotify(person.LowerThighLeft.localScale.y);
    this.LowerThighsSclZ.SetValueWithoutNotify(person.LowerThighLeft.localScale.z);
    this.CalvesSclX.SetValueWithoutNotify(person.CalveLeft.localScale.x);
    this.CalvesSclY.SetValueWithoutNotify(person.CalveLeft.localScale.y);
    this.CalvesSclZ.SetValueWithoutNotify(person.CalveLeft.localScale.z);
    this.FeetSclX.SetValueWithoutNotify(person.FootLeft.localScale.x);
    this.FeetSclY.SetValueWithoutNotify(person.FootLeft.localScale.y);
    this.FeetSclZ.SetValueWithoutNotify(person.FootLeft.localScale.z);
    this.ShouldersSclX.SetValueWithoutNotify(person.ShoulderLeft.localScale.x);
    this.ShouldersSclY.SetValueWithoutNotify(person.ShoulderLeft.localScale.y);
    this.ShouldersSclZ.SetValueWithoutNotify(person.ShoulderLeft.localScale.z);
    this.UpperArmsSclX.SetValueWithoutNotify(person.UpperArmLeft.localScale.x);
    this.UpperArmsSclY.SetValueWithoutNotify(person.UpperArmLeft.localScale.y);
    this.UpperArmsSclZ.SetValueWithoutNotify(person.UpperArmLeft.localScale.z);
    this.ForeArmsSclX.SetValueWithoutNotify(person.ForeArmLeft.localScale.x);
    this.ForeArmsSclY.SetValueWithoutNotify(person.ForeArmLeft.localScale.y);
    this.ForeArmsSclZ.SetValueWithoutNotify(person.ForeArmLeft.localScale.z);
    this.HandsSclX.SetValueWithoutNotify(person.HandLeft.localScale.x);
    this.HandsSclY.SetValueWithoutNotify(person.HandLeft.localScale.y);
    this.HandsSclZ.SetValueWithoutNotify(person.HandLeft.localScale.z);
    this.HeadSclX.SetValueWithoutNotify(person.Head.localScale.x);
    this.HeadSclY.SetValueWithoutNotify(person.Head.localScale.y);
    this.HeadSclZ.SetValueWithoutNotify(person.Head.localScale.z);
    this.MouthPosX.SetValueWithoutNotify(person.MouthBase.localPosition.x);
    this.MouthPosY.SetValueWithoutNotify(person.MouthBase.localPosition.y);
    this.MouthPosZ.SetValueWithoutNotify(person.MouthBase.localPosition.z);
    this.MouthRot.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.MouthBase.localEulerAngles.x, this.MouthRot.maxValue));
    this.MouthSclX.SetValueWithoutNotify(person.MouthBase.localScale.x);
    this.MouthSclY.SetValueWithoutNotify(person.MouthBase.localScale.y);
    this.MouthSclZ.SetValueWithoutNotify(person.MouthBase.localScale.z);
    this.MouthSidesPosX.SetValueWithoutNotify(person.MouthLeft.localPosition.x);
    this.MouthSidesPosY.SetValueWithoutNotify(person.MouthLeft.localPosition.y);
    this.MouthSidesPosZ.SetValueWithoutNotify(person.MouthLeft.localPosition.z);
    this.MouthSidesSclX.SetValueWithoutNotify(person.MouthLeft.localScale.x);
    this.MouthSidesSclY.SetValueWithoutNotify(person.MouthLeft.localScale.y);
    this.MouthSidesSclZ.SetValueWithoutNotify(person.MouthLeft.localScale.z);
    this.MouthTop.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.MouthTop.localEulerAngles.x, this.MouthTop.maxValue));
    this.MouthLow.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.MouthBottom.localEulerAngles.x, this.MouthLow.maxValue));
    this.CheeksPosX.SetValueWithoutNotify(person.CheekUpLeft.localPosition.x);
    this.CheeksPosY.SetValueWithoutNotify(person.CheekUpLeft.localPosition.y);
    this.CheeksPosZ.SetValueWithoutNotify(person.CheekUpLeft.localPosition.z);
    this.JawPosX.SetValueWithoutNotify(person.Jaw.localPosition.x);
    this.JawPosY.SetValueWithoutNotify(person.Jaw.localPosition.y);
    this.JawPosZ.SetValueWithoutNotify(person.Jaw.localPosition.z);
    this.JawRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.Jaw.localEulerAngles.x, this.JawRotX.maxValue));
    this.JawRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.Jaw.localEulerAngles.y, this.JawRotY.maxValue));
    this.JawRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.Jaw.localEulerAngles.z, this.JawRotZ.maxValue));
    this.JawSclX.SetValueWithoutNotify(person.Jaw.localScale.x);
    this.JawSclY.SetValueWithoutNotify(person.Jaw.localScale.y);
    this.JawSclZ.SetValueWithoutNotify(person.Jaw.localScale.z);
    this.JawLowPosX.SetValueWithoutNotify(person.JawLow.localPosition.x);
    this.JawLowPosY.SetValueWithoutNotify(person.JawLow.localPosition.y);
    this.JawLowPosZ.SetValueWithoutNotify(person.JawLow.localPosition.z);
    this.JawLowRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.JawLow.localEulerAngles.x, this.JawLowRotX.maxValue));
    this.JawLowRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.JawLow.localEulerAngles.y, this.JawLowRotY.maxValue));
    this.JawLowRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.JawLow.localEulerAngles.z, this.JawLowRotZ.maxValue));
    this.JawLowSclX.SetValueWithoutNotify(person.JawLow.localScale.x);
    this.JawLowSclY.SetValueWithoutNotify(person.JawLow.localScale.y);
    this.JawLowSclZ.SetValueWithoutNotify(person.JawLow.localScale.z);
    this.ChinPosX.SetValueWithoutNotify(person.Chin.localPosition.x);
    this.ChinPosY.SetValueWithoutNotify(person.Chin.localPosition.y);
    this.ChinPosZ.SetValueWithoutNotify(person.Chin.localPosition.z);
    this.ChinRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.Chin.localEulerAngles.x, this.ChinRotX.maxValue));
    this.ChinRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.Chin.localEulerAngles.y, this.ChinRotY.maxValue));
    this.ChinRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.Chin.localEulerAngles.z, this.ChinRotZ.maxValue));
    this.ChinSclX.SetValueWithoutNotify(person.Chin.localScale.x);
    this.ChinSclY.SetValueWithoutNotify(person.Chin.localScale.y);
    this.ChinSclZ.SetValueWithoutNotify(person.Chin.localScale.z);
    this.EarsPosX.SetValueWithoutNotify(person.EarLeft.localPosition.x);
    this.EarsPosY.SetValueWithoutNotify(person.EarLeft.localPosition.y);
    this.EarsPosZ.SetValueWithoutNotify(person.EarLeft.localPosition.z);
    this.EarsRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EarLeft.localEulerAngles.x, this.EarsRotX.maxValue));
    this.EarsRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EarLeft.localEulerAngles.y, this.EarsRotY.maxValue));
    this.EarsRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EarLeft.localEulerAngles.z, this.EarsRotZ.maxValue));
    this.EarsSclX.SetValueWithoutNotify(person.EarLeft.localScale.x);
    this.EarsSclY.SetValueWithoutNotify(person.EarLeft.localScale.y);
    this.EarsSclZ.SetValueWithoutNotify(person.EarLeft.localScale.z);
    this.EarsLowPosX.SetValueWithoutNotify(person.EarLeftLow.localPosition.x);
    this.EarsLowPosY.SetValueWithoutNotify(person.EarLeftLow.localPosition.y);
    this.EarsLowPosZ.SetValueWithoutNotify(person.EarLeftLow.localPosition.z);
    this.EarsLowRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EarLeftLow.localEulerAngles.x, this.EarsLowRotX.maxValue));
    this.EarsLowRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EarLeftLow.localEulerAngles.y, this.EarsLowRotY.maxValue));
    this.EarsLowRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EarLeftLow.localEulerAngles.z, this.EarsLowRotZ.maxValue));
    this.EarsLowSclX.SetValueWithoutNotify(person.EarLeftLow.localScale.x);
    this.EarsLowSclY.SetValueWithoutNotify(person.EarLeftLow.localScale.y);
    this.EarsLowSclZ.SetValueWithoutNotify(person.EarLeftLow.localScale.z);
    this.EarsHighPosX.SetValueWithoutNotify(person.EarLeftHigh.localPosition.x);
    this.EarsHighPosY.SetValueWithoutNotify(person.EarLeftHigh.localPosition.y);
    this.EarsHighPosZ.SetValueWithoutNotify(person.EarLeftHigh.localPosition.z);
    this.EarsHighRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EarLeftHigh.localEulerAngles.x, this.EarsHighRotX.maxValue));
    this.EarsHighRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EarLeftHigh.localEulerAngles.y, this.EarsHighRotY.maxValue));
    this.EarsHighRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EarLeftHigh.localEulerAngles.z, this.EarsHighRotZ.maxValue));
    this.EarsHighSclX.SetValueWithoutNotify(person.EarLeftHigh.localScale.x);
    this.EarsHighSclY.SetValueWithoutNotify(person.EarLeftHigh.localScale.y);
    this.EarsHighSclZ.SetValueWithoutNotify(person.EarLeftHigh.localScale.z);
    this.NosePosX.SetValueWithoutNotify(person.Nose.localPosition.x);
    this.NosePosY.SetValueWithoutNotify(person.Nose.localPosition.y);
    this.NosePosZ.SetValueWithoutNotify(person.Nose.localPosition.z);
    this.NoseRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.Nose.localEulerAngles.x, this.NoseRotX.maxValue));
    this.NoseRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.Nose.localEulerAngles.y, this.NoseRotY.maxValue));
    this.NoseRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.Nose.localEulerAngles.z, this.NoseRotZ.maxValue));
    this.NoseSclX.SetValueWithoutNotify(person.Nose.localScale.x);
    this.NoseSclY.SetValueWithoutNotify(person.Nose.localScale.y);
    this.NoseSclZ.SetValueWithoutNotify(person.Nose.localScale.z);
    this.NoseBridgePosX.SetValueWithoutNotify(person.NoseBridge.localPosition.x);
    this.NoseBridgePosY.SetValueWithoutNotify(person.NoseBridge.localPosition.y);
    this.NoseBridgePosZ.SetValueWithoutNotify(person.NoseBridge.localPosition.z);
    this.NoseBridgeRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NoseBridge.localEulerAngles.x, this.NoseBridgeRotX.maxValue));
    this.NoseBridgeRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NoseBridge.localEulerAngles.y, this.NoseBridgeRotY.maxValue));
    this.NoseBridgeRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NoseBridge.localEulerAngles.z, this.NoseBridgeRotZ.maxValue));
    this.NoseBridgeSclX.SetValueWithoutNotify(person.NoseBridge.localScale.x);
    this.NoseBridgeSclY.SetValueWithoutNotify(person.NoseBridge.localScale.y);
    this.NoseBridgeSclZ.SetValueWithoutNotify(person.NoseBridge.localScale.z);
    this.NoseTipPosX.SetValueWithoutNotify(person.NoseTip.localPosition.x);
    this.NoseTipPosY.SetValueWithoutNotify(person.NoseTip.localPosition.y);
    this.NoseTipPosZ.SetValueWithoutNotify(person.NoseTip.localPosition.z);
    this.NoseTipRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NoseTip.localEulerAngles.x, this.NoseTipRotX.maxValue));
    this.NoseTipRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NoseTip.localEulerAngles.y, this.NoseTipRotY.maxValue));
    this.NoseTipRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NoseTip.localEulerAngles.z, this.NoseTipRotZ.maxValue));
    this.NoseTipSclX.SetValueWithoutNotify(person.NoseTip.localScale.x);
    this.NoseTipSclY.SetValueWithoutNotify(person.NoseTip.localScale.y);
    this.NoseTipSclZ.SetValueWithoutNotify(person.NoseTip.localScale.z);
    this.NostrilsPosX.SetValueWithoutNotify(person.NostrilLeft.localPosition.x);
    this.NostrilsPosY.SetValueWithoutNotify(person.NostrilLeft.localPosition.y);
    this.NostrilsPosZ.SetValueWithoutNotify(person.NostrilLeft.localPosition.z);
    this.NostrilsRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NostrilLeft.localEulerAngles.x, this.NostrilsRotX.maxValue));
    this.NostrilsRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NostrilLeft.localEulerAngles.y, this.NostrilsRotY.maxValue));
    this.NostrilsRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.NostrilLeft.localEulerAngles.z, this.NostrilsRotZ.maxValue));
    this.NostrilsSclX.SetValueWithoutNotify(person.NostrilLeft.localScale.x);
    this.NostrilsSclY.SetValueWithoutNotify(person.NostrilLeft.localScale.y);
    this.NostrilsSclZ.SetValueWithoutNotify(person.NostrilLeft.localScale.z);
    this.EyesPosX.SetValueWithoutNotify(person.EyeLeft.localPosition.x);
    this.EyesPosY.SetValueWithoutNotify(person.EyeLeft.localPosition.y);
    this.EyesPosZ.SetValueWithoutNotify(person.EyeLeft.localPosition.z);
    this.EyesRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeft.localEulerAngles.x, this.EyesRotX.maxValue));
    this.EyesRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeft.localEulerAngles.y, this.EyesRotY.maxValue));
    this.EyesRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeft.localEulerAngles.z, this.EyesRotZ.maxValue));
    this.EyesSclX.SetValueWithoutNotify(person.EyeLeft.localScale.x);
    this.EyesSclY.SetValueWithoutNotify(person.EyeLeft.localScale.y);
    this.EyesSclZ.SetValueWithoutNotify(person.EyeLeft.localScale.z);
    this.EyesTopPosX.SetValueWithoutNotify(person.EyeLeftTop.localPosition.x);
    this.EyesTopPosY.SetValueWithoutNotify(person.EyeLeftTop.localPosition.y);
    this.EyesTopPosZ.SetValueWithoutNotify(person.EyeLeftTop.localPosition.z);
    this.EyesTopRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftTop.localEulerAngles.x, this.EyesTopRotX.maxValue));
    this.EyesTopRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftTop.localEulerAngles.y, this.EyesTopRotY.maxValue));
    this.EyesTopRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftTop.localEulerAngles.z, this.EyesTopRotZ.maxValue));
    this.EyesTopSclX.SetValueWithoutNotify(person.EyeLeftTop.localScale.x);
    this.EyesTopSclY.SetValueWithoutNotify(person.EyeLeftTop.localScale.y);
    this.EyesTopSclZ.SetValueWithoutNotify(person.EyeLeftTop.localScale.z);
    this.EyesLowPosX.SetValueWithoutNotify(person.EyeLeftLow.localPosition.x);
    this.EyesLowPosY.SetValueWithoutNotify(person.EyeLeftLow.localPosition.y);
    this.EyesLowPosZ.SetValueWithoutNotify(person.EyeLeftLow.localPosition.z);
    this.EyesLowRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftLow.localEulerAngles.x, this.EyesLowRotX.maxValue));
    this.EyesLowRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftLow.localEulerAngles.y, this.EyesLowRotY.maxValue));
    this.EyesLowRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftLow.localEulerAngles.z, this.EyesLowRotZ.maxValue));
    this.EyesLowSclX.SetValueWithoutNotify(person.EyeLeftLow.localScale.x);
    this.EyesLowSclY.SetValueWithoutNotify(person.EyeLeftLow.localScale.y);
    this.EyesLowSclZ.SetValueWithoutNotify(person.EyeLeftLow.localScale.z);
    this.EyesInnerPosX.SetValueWithoutNotify(person.EyeLeftInner.localPosition.x);
    this.EyesInnerPosY.SetValueWithoutNotify(person.EyeLeftInner.localPosition.y);
    this.EyesInnerPosZ.SetValueWithoutNotify(person.EyeLeftInner.localPosition.z);
    this.EyesInnerRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftInner.localEulerAngles.x, this.EyesInnerRotX.maxValue));
    this.EyesInnerRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftInner.localEulerAngles.y, this.EyesInnerRotY.maxValue));
    this.EyesInnerRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftInner.localEulerAngles.z, this.EyesInnerRotZ.maxValue));
    this.EyesInnerSclX.SetValueWithoutNotify(person.EyeLeftInner.localScale.x);
    this.EyesInnerSclY.SetValueWithoutNotify(person.EyeLeftInner.localScale.y);
    this.EyesInnerSclZ.SetValueWithoutNotify(person.EyeLeftInner.localScale.z);
    this.EyesOuterPosX.SetValueWithoutNotify(person.EyeLeftOuter.localPosition.x);
    this.EyesOuterPosY.SetValueWithoutNotify(person.EyeLeftOuter.localPosition.y);
    this.EyesOuterPosZ.SetValueWithoutNotify(person.EyeLeftOuter.localPosition.z);
    this.EyesOuterRotX.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftOuter.localEulerAngles.x, this.EyesOuterRotX.maxValue));
    this.EyesOuterRotY.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftOuter.localEulerAngles.y, this.EyesOuterRotY.maxValue));
    this.EyesOuterRotZ.SetValueWithoutNotify(this.ARGHTHENUMBERROTATION(person.EyeLeftOuter.localEulerAngles.z, this.EyesOuterRotZ.maxValue));
    this.EyesOuterSclX.SetValueWithoutNotify(person.EyeLeftOuter.localScale.x);
    this.EyesOuterSclY.SetValueWithoutNotify(person.EyeLeftOuter.localScale.y);
    this.EyesOuterSclZ.SetValueWithoutNotify(person.EyeLeftOuter.localScale.z);
  }

  public override void Close()
  {
    base.Close();
    if (!((UnityEngine.Object) this.CustomizeRoom != (UnityEngine.Object) null))
      return;
    this.CustomizeRoom.SetActive(false);
  }

  public void HideDisplayClothes()
  {
    for (int index = 0; index < this.DisplayPerson.EquippedClothes.Count; ++index)
    {
      if (this.DisplayPerson.EquippedClothes[index].BodyPart != DressableType.Hair && this.DisplayPerson.EquippedClothes[index].BodyPart != DressableType.Feet)
        this.DisplayPerson.EquippedClothes[index].gameObject.SetActive(false);
    }
    for (int index = 0; index < this.DisplayPersonMale.EquippedClothes.Count; ++index)
    {
      if (this.DisplayPersonMale.EquippedClothes[index].BodyPart != DressableType.Hair && this.DisplayPersonMale.EquippedClothes[index].BodyPart != DressableType.Feet)
        this.DisplayPersonMale.EquippedClothes[index].gameObject.SetActive(false);
    }
    for (int index = 0; index < this.DisplayPersonMale2.EquippedClothes.Count; ++index)
    {
      if (this.DisplayPersonMale2.EquippedClothes[index].BodyPart != DressableType.Hair && this.DisplayPersonMale2.EquippedClothes[index].BodyPart != DressableType.Feet)
        this.DisplayPersonMale2.EquippedClothes[index].gameObject.SetActive(false);
    }
    if (this.DisplayPerson.HasPenis)
      this.DisplayPerson.PutPenis();
    this.DisplayPersonMale.PutPenis();
    this.DisplayPersonMale2.PutPenis();
  }

  public void ShowDisplayClothes()
  {
    for (int index = 0; index < this.DisplayPerson.EquippedClothes.Count; ++index)
      this.DisplayPerson.EquippedClothes[index].gameObject.SetActive(true);
    for (int index = 0; index < this.DisplayPersonMale.EquippedClothes.Count; ++index)
      this.DisplayPersonMale.EquippedClothes[index].gameObject.SetActive(true);
    for (int index = 0; index < this.DisplayPersonMale2.EquippedClothes.Count; ++index)
      this.DisplayPersonMale2.EquippedClothes[index].gameObject.SetActive(true);
    this.DisplayPerson.RemovePenis();
    this.DisplayPersonMale.RemovePenis();
    this.DisplayPersonMale2.RemovePenis();
  }

  public void Update()
  {
    if (!this.RotateChar)
      return;
    if ((double) this.rot.color.a == 0.5)
      this.Click_OffRotater();
    else if (Input.GetMouseButton(UI_Settings.LeftMouseButton))
    {
      this.DisplayPerson.transform.parent.eulerAngles += new Vector3(0.0f, (float) (-(double) Input.GetAxis("Mouse X") * 2.0), 0.0f);
    }
    else
    {
      this.scrollInput = Input.GetAxis("Mouse ScrollWheel");
      if ((double) this.scrollInput != 0.0)
      {
        this.t += this.scrollInput * this.transitionSpeed * Time.deltaTime;
        this.t = Mathf.Clamp01(this.t);
      }
      this.ZoomCam.position = Vector3.Lerp(this.MainCam.transform.position, this.FaceCam.transform.position, this.t);
      this.ZoomCam.rotation = Quaternion.Slerp(this.MainCam.transform.rotation, this.FaceCam.transform.rotation, this.t);
    }
  }

  public void Click_ToogleClothes()
  {
    this.DisplayPerson.transform.localPosition = Vector3.zero;
    this.DisplayPersonMale.transform.localPosition = Vector3.zero;
    this.DisplayPersonMale2.transform.localPosition = Vector3.zero;
    this.ClothesEnabled = !this.ClothesEnabled;
    if (this.ClothesEnabled)
      this.ShowDisplayClothes();
    else
      this.HideDisplayClothes();
  }

  public void Click_ToggleFaceView()
  {
    this.DisplayPerson.Anim.enabled = this.FaceView.isOn;
    if ((UnityEngine.Object) this.DisplayPersonMale != (UnityEngine.Object) null)
      this.DisplayPersonMale.Anim.enabled = this.FaceView.isOn;
    if (!((UnityEngine.Object) this.DisplayPersonMale2 != (UnityEngine.Object) null))
      return;
    this.DisplayPersonMale2.Anim.enabled = this.FaceView.isOn;
  }

  public void Click_Rotater()
  {
    this.DisplayPerson.transform.localPosition = Vector3.zero;
    this.DisplayPersonMale.transform.localPosition = Vector3.zero;
    this.DisplayPersonMale2.transform.localPosition = Vector3.zero;
    this.rot.color = new Color(1f, 1f, 1f, 1f);
    this.RotateChar = true;
  }

  public void Click_OffRotater()
  {
    this.DisplayPerson.transform.localPosition = Vector3.zero;
    this.DisplayPersonMale.transform.localPosition = Vector3.zero;
    this.DisplayPersonMale2.transform.localPosition = Vector3.zero;
    this.rot.color = new Color(1f, 1f, 1f, 0.5f);
    if (Input.GetMouseButton(UI_Settings.LeftMouseButton))
      return;
    this.RotateChar = false;
  }

  public void Click_Finish()
  {
    if (this.DURINGGAMEPLAY)
    {
      Main.Instance.Player.RemoveMoveBlocker("Customization");
      Main.Instance.OpenMenu("Gameplay");
      Main.Instance.Player.UserControl.enabled = true;
      Main.Instance.Player.UserControl.ThirdCamPositionType = Main.Instance.Player.UserControl.ThirdCamPositionTypeOnSettings;
      Main.Instance.GameplayMenu.DisallowCursor();
    }
    else
    {
      switch (this.GenderDrop.value)
      {
        case 1:
          Main.Instance.Player = Main.Instance.MalePlayer;
          this.DisplayPerson = this.DisplayPersonMale;
          goto case 3;
        case 2:
          Main.Instance.Player = Main.Instance.MalePlayer2;
          this.DisplayPerson = this.DisplayPersonMale2;
          goto case 3;
        case 3:
          FreeLookCam objectOfType = UnityEngine.Object.FindObjectOfType<FreeLookCam>(true);
          objectOfType.m_Target = Main.Instance.Player.transform;
          WeaponSystem componentInChildren = objectOfType.GetComponentInChildren<WeaponSystem>(true);
          componentInChildren.ThisPerson = Main.Instance.Player;
          Main.Instance.Player.WeaponInv = componentInChildren;
          Main.Instance.Player.HasPenis = true;
          break;
      }
      Main.Instance.Player.StartingClothes.Clear();
      for (int index = 0; index < this.DisplayPerson.EquippedClothes.Count; ++index)
      {
        if (this.DisplayPerson.EquippedClothes[index].BodyPart == DressableType.Hair)
        {
          Main.Instance.Player.StartingClothes.Add(this.DisplayPerson.EquippedClothes[index].OriginalPrefab);
          break;
        }
      }
      if (Main.Instance.Player is Girl)
      {
        Girl player = (Girl) Main.Instance.Player;
        player.Futa = ((Girl) this.DisplayPerson).Futa;
        Main.Instance.Player.HasPenis = player.Futa;
        Main.Instance.Player.HasBalls = this.DisplayPerson.HasBalls;
        (Main.Instance.Player as Girl).PregnancyPercent = ((Girl) this.DisplayPerson).PregnancyPercent;
      }
      Main.Instance.Player.Penis.transform.localScale = this.DisplayPerson.Penis.transform.localScale;
      Main.Instance.Player.NaturalHairColor = this.DisplayPerson.NaturalHairColor;
      Main.Instance.Player.NaturalEyeColor = this.DisplayPerson.NaturalEyeColor;
      Main.Instance.Player.NaturalSkinColor = this.DisplayPerson.NaturalSkinColor;
      Main.Instance.Player.transform.localScale = this.DisplayPerson.transform.localScale;
      Main.Instance.Player.Personality = (Personality_Type) this.PersonalityDrop.value;
      Main.Instance.Player.Name = this.PlayerNameField.text;
      Main.Instance.Player.Fetishes = this.DisplayPerson.Fetishes;
      Main.Instance.Player.States = this.DisplayPerson.States;
      Main.Instance.Player._CustomSkinStates = this.DisplayPerson._CustomSkinStates;
      Main.Instance.Player._CustomFaceSkinStates = this.DisplayPerson._CustomFaceSkinStates;
      if (Main.Instance.Player is Girl)
      {
        Main.Instance.Player.BoobLeft.localPosition = this.DisplayPerson.BoobLeft.localPosition;
        Main.Instance.Player.BoobLeft.localEulerAngles = this.DisplayPerson.BoobLeft.localEulerAngles;
        Main.Instance.Player.BoobLeft.localScale = this.DisplayPerson.BoobLeft.localScale;
        Main.Instance.Player.BoobRight.localPosition = this.DisplayPerson.BoobRight.localPosition;
        Main.Instance.Player.BoobRight.localEulerAngles = this.DisplayPerson.BoobRight.localEulerAngles;
        Main.Instance.Player.BoobRight.localScale = this.DisplayPerson.BoobRight.localScale;
        Main.Instance.Player.NippleLeft.localPosition = this.DisplayPerson.NippleLeft.localPosition;
        Main.Instance.Player.NippleLeft.localEulerAngles = this.DisplayPerson.NippleLeft.localEulerAngles;
        Main.Instance.Player.NippleLeft.localScale = this.DisplayPerson.NippleLeft.localScale;
        Main.Instance.Player.NippleRight.localPosition = this.DisplayPerson.NippleRight.localPosition;
        Main.Instance.Player.NippleRight.localEulerAngles = this.DisplayPerson.NippleRight.localEulerAngles;
        Main.Instance.Player.NippleRight.localScale = this.DisplayPerson.NippleRight.localScale;
        Main.Instance.Player.AssCheekLeft.localPosition = this.DisplayPerson.AssCheekLeft.localPosition;
        Main.Instance.Player.AssCheekLeft.localEulerAngles = this.DisplayPerson.AssCheekLeft.localEulerAngles;
        Main.Instance.Player.AssCheekLeft.localScale = this.DisplayPerson.AssCheekLeft.localScale;
        Main.Instance.Player.AssCheekRight.localPosition = this.DisplayPerson.AssCheekRight.localPosition;
        Main.Instance.Player.AssCheekRight.localEulerAngles = this.DisplayPerson.AssCheekRight.localEulerAngles;
        Main.Instance.Player.AssCheekRight.localScale = this.DisplayPerson.AssCheekRight.localScale;
        Main.Instance.Player.Hips.localScale = this.DisplayPerson.Hips.localScale;
        if (Main.Instance.Player is Girl)
          Main.Instance.Player.Hips2.localScale = this.DisplayPerson.Hips2.localScale;
        Main.Instance.Player.Belly.localScale = this.DisplayPerson.Belly.localScale;
        Main.Instance.Player.Waist.localScale = this.DisplayPerson.Waist.localScale;
        Main.Instance.Player.Torso.localScale = this.DisplayPerson.Torso.localScale;
        Main.Instance.Player.Neck.localScale = this.DisplayPerson.Neck.localScale;
        Main.Instance.Player.UpperThighLeft.localScale = this.DisplayPerson.UpperThighLeft.localScale;
        Main.Instance.Player.UpperThighRight.localScale = this.DisplayPerson.UpperThighRight.localScale;
        if (Main.Instance.Player is Girl)
        {
          Main.Instance.Player.MidThighLeft.localScale = this.DisplayPerson.MidThighLeft.localScale;
          Main.Instance.Player.MidThighRight.localScale = this.DisplayPerson.MidThighRight.localScale;
          Main.Instance.Player.LowerThighLeft.localScale = this.DisplayPerson.LowerThighLeft.localScale;
          Main.Instance.Player.LowerThighRight.localScale = this.DisplayPerson.LowerThighRight.localScale;
        }
        Main.Instance.Player.CalveLeft.localScale = this.DisplayPerson.CalveLeft.localScale;
        Main.Instance.Player.CalveRight.localScale = this.DisplayPerson.CalveRight.localScale;
        Main.Instance.Player.FootLeft.localScale = this.DisplayPerson.FootLeft.localScale;
        Main.Instance.Player.FootRight.localScale = this.DisplayPerson.FootRight.localScale;
        Main.Instance.Player.ShoulderLeft.localScale = this.DisplayPerson.ShoulderLeft.localScale;
        Main.Instance.Player.ShoulderRight.localScale = this.DisplayPerson.ShoulderRight.localScale;
        Main.Instance.Player.UpperArmLeft.localScale = this.DisplayPerson.UpperArmLeft.localScale;
        Main.Instance.Player.ForeArmLeft.localScale = this.DisplayPerson.ForeArmLeft.localScale;
        Main.Instance.Player.ForeArmRight.localScale = this.DisplayPerson.ForeArmRight.localScale;
        Main.Instance.Player.HandLeft.localScale = this.DisplayPerson.HandLeft.localScale;
        Main.Instance.Player.HandRight.localScale = this.DisplayPerson.HandRight.localScale;
        Main.Instance.Player.Head.localPosition = this.DisplayPerson.Head.localPosition;
        Main.Instance.Player.Head.localEulerAngles = this.DisplayPerson.Head.localEulerAngles;
        Main.Instance.Player.Head.localScale = this.DisplayPerson.Head.localScale;
      }
      else
      {
        Main.Instance.Player.Jaw.localScale = this.DisplayPerson.Jaw.localScale;
        Main.Instance.Player.Chin.localScale = this.DisplayPerson.Chin.localScale;
        Main.Instance.Player.Nose.localRotation = this.DisplayPerson.Nose.localRotation;
        Main.Instance.Player.Nose.localScale = this.DisplayPerson.Nose.localScale;
        Main.Instance.Player.EyeLeft.localPosition = this.DisplayPerson.EyeLeft.localPosition;
        Main.Instance.Player.EyeLeft.localRotation = this.DisplayPerson.EyeLeft.localRotation;
        Main.Instance.Player.EyeLeft.localScale = this.DisplayPerson.EyeLeft.localScale;
        Main.Instance.Player.EyeRight.localPosition = this.DisplayPerson.EyeRight.localPosition;
        Main.Instance.Player.EyeRight.localRotation = this.DisplayPerson.EyeRight.localRotation;
        Main.Instance.Player.EyeRight.localScale = this.DisplayPerson.EyeRight.localScale;
      }
      if (Main.Instance.Player is Girl)
      {
        Main.Instance.Player.MouthBase.localPosition = this.DisplayPerson.MouthBase.localPosition;
        Main.Instance.Player.MouthBase.localEulerAngles = this.DisplayPerson.MouthBase.localEulerAngles;
        Main.Instance.Player.MouthBase.localScale = this.DisplayPerson.MouthBase.localScale;
        Main.Instance.Player.MouthLeft.localPosition = this.DisplayPerson.MouthLeft.localPosition;
        Main.Instance.Player.MouthLeft.localEulerAngles = this.DisplayPerson.MouthLeft.localEulerAngles;
        Main.Instance.Player.MouthLeft.localScale = this.DisplayPerson.MouthLeft.localScale;
        Main.Instance.Player.MouthRight.localPosition = this.DisplayPerson.MouthRight.localPosition;
        Main.Instance.Player.MouthRight.localEulerAngles = this.DisplayPerson.MouthRight.localEulerAngles;
        Main.Instance.Player.MouthRight.localScale = this.DisplayPerson.MouthRight.localScale;
        Main.Instance.Player.MouthTop.localEulerAngles = this.DisplayPerson.MouthTop.localEulerAngles;
        Main.Instance.Player.MouthBottom.localEulerAngles = this.DisplayPerson.MouthBottom.localEulerAngles;
        Main.Instance.Player.CheekUpLeft.localPosition = this.DisplayPerson.CheekUpLeft.localPosition;
        Main.Instance.Player.CheekUpRight.localPosition = this.DisplayPerson.CheekUpRight.localPosition;
        Main.Instance.Player.Jaw.localPosition = this.DisplayPerson.Jaw.localPosition;
        Main.Instance.Player.Jaw.localEulerAngles = this.DisplayPerson.Jaw.localEulerAngles;
        Main.Instance.Player.Jaw.localScale = this.DisplayPerson.Jaw.localScale;
        Main.Instance.Player.JawLow.localPosition = this.DisplayPerson.JawLow.localPosition;
        Main.Instance.Player.JawLow.localEulerAngles = this.DisplayPerson.JawLow.localEulerAngles;
        Main.Instance.Player.JawLow.localScale = this.DisplayPerson.JawLow.localScale;
        Main.Instance.Player.Chin.localPosition = this.DisplayPerson.Chin.localPosition;
        Main.Instance.Player.Chin.localEulerAngles = this.DisplayPerson.Chin.localEulerAngles;
        Main.Instance.Player.Chin.localScale = this.DisplayPerson.Chin.localScale;
        Main.Instance.Player.EarLeft.localPosition = this.DisplayPerson.EarLeft.localPosition;
        Main.Instance.Player.EarLeft.localEulerAngles = this.DisplayPerson.EarLeft.localEulerAngles;
        Main.Instance.Player.EarLeft.localScale = this.DisplayPerson.EarLeft.localScale;
        Main.Instance.Player.EarRight.localPosition = this.DisplayPerson.EarRight.localPosition;
        Main.Instance.Player.EarRight.localEulerAngles = this.DisplayPerson.EarRight.localEulerAngles;
        Main.Instance.Player.EarRight.localScale = this.DisplayPerson.EarRight.localScale;
        Main.Instance.Player.EarLeftLow.localPosition = this.DisplayPerson.EarLeftLow.localPosition;
        Main.Instance.Player.EarLeftLow.localEulerAngles = this.DisplayPerson.EarLeftLow.localEulerAngles;
        Main.Instance.Player.EarLeftLow.localScale = this.DisplayPerson.EarLeftLow.localScale;
        Main.Instance.Player.EarRightLow.localPosition = this.DisplayPerson.EarRightLow.localPosition;
        Main.Instance.Player.EarRightLow.localEulerAngles = this.DisplayPerson.EarRightLow.localEulerAngles;
        Main.Instance.Player.EarRightLow.localScale = this.DisplayPerson.EarRightLow.localScale;
        Main.Instance.Player.EarLeftHigh.localPosition = this.DisplayPerson.EarLeftHigh.localPosition;
        Main.Instance.Player.EarLeftHigh.localEulerAngles = this.DisplayPerson.EarLeftHigh.localEulerAngles;
        Main.Instance.Player.EarLeftHigh.localScale = this.DisplayPerson.EarLeftHigh.localScale;
        Main.Instance.Player.EarRightHigh.localPosition = this.DisplayPerson.EarRightHigh.localPosition;
        Main.Instance.Player.EarRightHigh.localEulerAngles = this.DisplayPerson.EarRightHigh.localEulerAngles;
        Main.Instance.Player.EarRightHigh.localScale = this.DisplayPerson.EarRightHigh.localScale;
        Main.Instance.Player.Nose.localPosition = this.DisplayPerson.Nose.localPosition;
        Main.Instance.Player.Nose.localEulerAngles = this.DisplayPerson.Nose.localEulerAngles;
        Main.Instance.Player.Nose.localScale = this.DisplayPerson.Nose.localScale;
        Main.Instance.Player.NoseBridge.localPosition = this.DisplayPerson.NoseBridge.localPosition;
        Main.Instance.Player.NoseBridge.localEulerAngles = this.DisplayPerson.NoseBridge.localEulerAngles;
        Main.Instance.Player.NoseBridge.localScale = this.DisplayPerson.NoseBridge.localScale;
        Main.Instance.Player.NoseTip.localPosition = this.DisplayPerson.NoseTip.localPosition;
        Main.Instance.Player.NoseTip.localEulerAngles = this.DisplayPerson.NoseTip.localEulerAngles;
        Main.Instance.Player.NoseTip.localScale = this.DisplayPerson.NoseTip.localScale;
        Main.Instance.Player.NostrilLeft.localPosition = this.DisplayPerson.NostrilLeft.localPosition;
        Main.Instance.Player.NostrilLeft.localEulerAngles = this.DisplayPerson.NostrilLeft.localEulerAngles;
        Main.Instance.Player.NostrilLeft.localScale = this.DisplayPerson.NostrilLeft.localScale;
        Main.Instance.Player.NostrilRight.localPosition = this.DisplayPerson.NostrilRight.localPosition;
        Main.Instance.Player.NostrilRight.localEulerAngles = this.DisplayPerson.NostrilRight.localEulerAngles;
        Main.Instance.Player.NostrilRight.localScale = this.DisplayPerson.NostrilRight.localScale;
        Main.Instance.Player.EyeLeft.localPosition = this.DisplayPerson.EyeLeft.localPosition;
        Main.Instance.Player.EyeLeft.localEulerAngles = this.DisplayPerson.EyeLeft.localEulerAngles;
        Main.Instance.Player.EyeLeft.localScale = this.DisplayPerson.EyeLeft.localScale;
        Main.Instance.Player.EyeRight.localPosition = this.DisplayPerson.EyeRight.localPosition;
        Main.Instance.Player.EyeRight.localEulerAngles = this.DisplayPerson.EyeRight.localEulerAngles;
        Main.Instance.Player.EyeRight.localScale = this.DisplayPerson.EyeRight.localScale;
        Main.Instance.Player.EyeLeftTop.localPosition = this.DisplayPerson.EyeLeftTop.localPosition;
        Main.Instance.Player.EyeLeftTop.localEulerAngles = this.DisplayPerson.EyeLeftTop.localEulerAngles;
        Main.Instance.Player.EyeLeftTop.localScale = this.DisplayPerson.EyeLeftTop.localScale;
        Main.Instance.Player.EyeRightTop.localPosition = this.DisplayPerson.EyeRightTop.localPosition;
        Main.Instance.Player.EyeRightTop.localEulerAngles = this.DisplayPerson.EyeRightTop.localEulerAngles;
        Main.Instance.Player.EyeRightTop.localScale = this.DisplayPerson.EyeRightTop.localScale;
        Main.Instance.Player.EyeLeftLow.localPosition = this.DisplayPerson.EyeLeftLow.localPosition;
        Main.Instance.Player.EyeLeftLow.localEulerAngles = this.DisplayPerson.EyeLeftLow.localEulerAngles;
        Main.Instance.Player.EyeLeftLow.localScale = this.DisplayPerson.EyeLeftLow.localScale;
        Main.Instance.Player.EyeRightLow.localPosition = this.DisplayPerson.EyeRightLow.localPosition;
        Main.Instance.Player.EyeRightLow.localEulerAngles = this.DisplayPerson.EyeRightLow.localEulerAngles;
        Main.Instance.Player.EyeRightLow.localScale = this.DisplayPerson.EyeRightLow.localScale;
        Main.Instance.Player.EyeLeftInner.localPosition = this.DisplayPerson.EyeLeftInner.localPosition;
        Main.Instance.Player.EyeLeftInner.localEulerAngles = this.DisplayPerson.EyeLeftInner.localEulerAngles;
        Main.Instance.Player.EyeLeftInner.localScale = this.DisplayPerson.EyeLeftInner.localScale;
        Main.Instance.Player.EyeRightInner.localPosition = this.DisplayPerson.EyeRightInner.localPosition;
        Main.Instance.Player.EyeRightInner.localEulerAngles = this.DisplayPerson.EyeRightInner.localEulerAngles;
        Main.Instance.Player.EyeRightInner.localScale = this.DisplayPerson.EyeRightInner.localScale;
        Main.Instance.Player.EyeLeftOuter.localPosition = this.DisplayPerson.EyeLeftOuter.localPosition;
        Main.Instance.Player.EyeLeftOuter.localEulerAngles = this.DisplayPerson.EyeLeftOuter.localEulerAngles;
        Main.Instance.Player.EyeLeftOuter.localScale = this.DisplayPerson.EyeLeftOuter.localScale;
        Main.Instance.Player.EyeRightOuter.localPosition = this.DisplayPerson.EyeRightOuter.localPosition;
        Main.Instance.Player.EyeRightOuter.localEulerAngles = this.DisplayPerson.EyeRightOuter.localEulerAngles;
        Main.Instance.Player.EyeRightOuter.localScale = this.DisplayPerson.EyeRightOuter.localScale;
      }
      this.RotImage.SetActive(false);
      if (Main.Instance.ScatContent)
        this.ScatQuestion.SetActive(true);
      else if (Main.Instance.NewGameMenu.DificultySelected == 3)
        this.Warning.SetActive(true);
      else
        Main.Instance.NewGameMenu.Click_Finally();
    }
  }

  public void Click_ScatYes()
  {
    this.ScatQuestion.SetActive(false);
    Main.Instance.ScatContent = true;
    if (Main.Instance.NewGameMenu.DificultySelected == 3)
      this.Warning.SetActive(true);
    else
      Main.Instance.NewGameMenu.Click_Finally();
  }

  public void Click_ScatNo()
  {
    this.ScatQuestion.SetActive(false);
    Main.Instance.ScatContent = false;
    if (Main.Instance.NewGameMenu.DificultySelected == 3)
      this.Warning.SetActive(true);
    else
      Main.Instance.NewGameMenu.Click_Finally();
  }

  public void Click_WarningOkay() => Main.Instance.NewGameMenu.Click_Finally();

  public void ChangeCustomMenu()
  {
    this.DisplayPerson.transform.localPosition = Vector3.zero;
    for (int index = 0; index < this.CustomMenus.Length; ++index)
      this.CustomMenus[index].SetActive(false);
    this.CustomMenus[this.CustomMenuList.value].SetActive(true);
  }

  public void RemoveCurrentHair()
  {
    this.ReverseHairToggle.SetIsOnWithoutNotify(false);
    for (int index = 0; index < this.DisplayPerson.EquippedClothes.Count; ++index)
    {
      if (this.DisplayPerson.EquippedClothes[index].BodyPart == DressableType.Hair)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.DisplayPerson.EquippedClothes[index].gameObject);
        this.DisplayPerson.EquippedClothes.RemoveAt(index);
        break;
      }
    }
    if ((UnityEngine.Object) this.DisplayPersonMale != (UnityEngine.Object) null)
    {
      for (int index = 0; index < this.DisplayPersonMale.EquippedClothes.Count; ++index)
      {
        if (this.DisplayPersonMale.EquippedClothes[index].BodyPart == DressableType.Hair)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.DisplayPersonMale.EquippedClothes[index].gameObject);
          this.DisplayPersonMale.EquippedClothes.RemoveAt(index);
          break;
        }
      }
    }
    if (!(bool) (UnityEngine.Object) this.DisplayPersonMale2)
      return;
    for (int index = 0; index < this.DisplayPersonMale2.EquippedClothes.Count; ++index)
    {
      if (this.DisplayPersonMale2.EquippedClothes[index].BodyPart == DressableType.Hair)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.DisplayPersonMale2.EquippedClothes[index].gameObject);
        this.DisplayPersonMale2.EquippedClothes.RemoveAt(index);
        break;
      }
    }
  }

  public void Click_NextHair()
  {
    int num = this.HairList.value + 1;
    if (num == Main.Instance.Prefabs_Hair.Count)
      num = 0;
    this.HairList.value = num;
  }

  public void Click_PrevHair()
  {
    int num = this.HairList.value - 1;
    if (num == -1)
      num = Main.Instance.Prefabs_Hair.Count - 1;
    this.HairList.value = num;
  }

  public void Click_ChangeHair()
  {
    this.RemoveCurrentHair();
    this.DisplayPerson.DressClothe(Main.Instance.Prefabs_Hair[this.HairList.value]);
    if (!this.DURINGGAMEPLAY)
      this.DisplayPerson.CurrentHair.gameObject.layer = 16 /*0x10*/;
    if ((UnityEngine.Object) this.DisplayPersonMale != (UnityEngine.Object) null)
    {
      this.DisplayPersonMale.DressClothe(Main.Instance.Prefabs_Hair[this.HairList.value]);
      if (!this.DURINGGAMEPLAY)
        this.DisplayPersonMale.CurrentHair.gameObject.layer = 16 /*0x10*/;
    }
    if ((UnityEngine.Object) this.DisplayPersonMale2 != (UnityEngine.Object) null)
    {
      this.DisplayPersonMale2.DressClothe(Main.Instance.Prefabs_Hair[this.HairList.value]);
      if (!this.DURINGGAMEPLAY)
        this.DisplayPersonMale2.CurrentHair.gameObject.layer = 16 /*0x10*/;
    }
    this.Click_UpdateHairColor();
  }

  public void Click_ReverseHair()
  {
    if (!((UnityEngine.Object) this.DisplayPerson.CurrentHair != (UnityEngine.Object) null))
      return;
    switch (this.DisplayPerson.CurrentHair.ReverseAxis)
    {
      case Axis.X:
        this.DisplayPerson.CurrentHair.transform.localScale = new Vector3(-this.DisplayPerson.CurrentHair.transform.localScale.x, this.DisplayPerson.CurrentHair.transform.localScale.y, this.DisplayPerson.CurrentHair.transform.localScale.z);
        break;
      case Axis.Y:
        this.DisplayPerson.CurrentHair.transform.localScale = new Vector3(this.DisplayPerson.CurrentHair.transform.localScale.x, -this.DisplayPerson.CurrentHair.transform.localScale.y, this.DisplayPerson.CurrentHair.transform.localScale.z);
        break;
      case Axis.Z:
        this.DisplayPerson.CurrentHair.transform.localScale = new Vector3(this.DisplayPerson.CurrentHair.transform.localScale.x, this.DisplayPerson.CurrentHair.transform.localScale.y, -this.DisplayPerson.CurrentHair.transform.localScale.z);
        break;
    }
  }

  public void Click_UpdateHairColor()
  {
    switch (this.CustomMenuList.value)
    {
      case 0:
        if (this.DURINGGAMEPLAY)
        {
          this.DisplayPerson.DyedHairColor = new Color(this.HairRedColor.value, this.HairGreenColor.value, this.HairBlueColor.value, 1f);
          this.DisplayPerson.RefreshColors();
          if ((UnityEngine.Object) this.DisplayPersonMale != (UnityEngine.Object) null)
          {
            this.DisplayPersonMale.DyedHairColor = new Color(this.HairRedColor.value, this.HairGreenColor.value, this.HairBlueColor.value, 1f);
            this.DisplayPersonMale.RefreshColors();
          }
          if (!((UnityEngine.Object) this.DisplayPersonMale2 != (UnityEngine.Object) null))
            break;
          this.DisplayPersonMale2.DyedHairColor = new Color(this.HairRedColor.value, this.HairGreenColor.value, this.HairBlueColor.value, 1f);
          this.DisplayPersonMale2.RefreshColors();
          break;
        }
        this.DisplayPerson.NaturalHairColor = new Color(this.HairRedColor.value, this.HairGreenColor.value, this.HairBlueColor.value, 1f);
        this.DisplayPerson.RefreshColors();
        if ((UnityEngine.Object) this.DisplayPersonMale != (UnityEngine.Object) null)
        {
          this.DisplayPersonMale.NaturalHairColor = new Color(this.HairRedColor.value, this.HairGreenColor.value, this.HairBlueColor.value, 1f);
          this.DisplayPersonMale.RefreshColors();
        }
        if (!((UnityEngine.Object) this.DisplayPersonMale2 != (UnityEngine.Object) null))
          break;
        this.DisplayPersonMale2.NaturalHairColor = new Color(this.HairRedColor.value, this.HairGreenColor.value, this.HairBlueColor.value, 1f);
        this.DisplayPersonMale2.RefreshColors();
        break;
      case 2:
        this.Click_UpdateBodyShapes();
        break;
      case 3:
        this.Click_UpdateFaceShapes();
        break;
    }
  }

  public void Click_UpdateColors()
  {
    this.DisplayPerson.NaturalEyeColor = new Color(this.EyeRedColor.value, this.EyeGreenColor.value, this.EyeBlueColor.value);
    this.DisplayPerson.NaturalSkinColor = new Color(this.SkinRedColor.value, this.SkinGreenColor.value, this.SkinBlueColor.value);
    this.DisplayPerson.RefreshColors();
    if ((UnityEngine.Object) this.DisplayPersonMale != (UnityEngine.Object) null)
    {
      this.DisplayPersonMale.NaturalEyeColor = new Color(this.EyeRedColor.value, this.EyeGreenColor.value, this.EyeBlueColor.value);
      this.DisplayPersonMale.NaturalSkinColor = new Color(this.SkinRedColor.value, this.SkinGreenColor.value, this.SkinBlueColor.value);
      this.DisplayPersonMale.RefreshColors();
    }
    if (!((UnityEngine.Object) this.DisplayPersonMale2 != (UnityEngine.Object) null))
      return;
    this.DisplayPersonMale2.NaturalEyeColor = new Color(this.EyeRedColor.value, this.EyeGreenColor.value, this.EyeBlueColor.value);
    this.DisplayPersonMale2.NaturalSkinColor = new Color(this.SkinRedColor.value, this.SkinGreenColor.value, this.SkinBlueColor.value);
    this.DisplayPersonMale2.RefreshColors();
  }

  public void Click_UpdateBodyShapes()
  {
    this.DisplayPerson.BoobLeft.localPosition = new Vector3(this.BoobsPosX.value, this.BoobsPosY.value, this.BoobsPosZ.value);
    this.DisplayPerson.BoobLeft.localEulerAngles = new Vector3(this.BoobsRotX.value, this.BoobsRotY.value, this.BoobsRotZ.value);
    this.DisplayPerson.BoobLeft.localScale = new Vector3(this.BoobsSclX.value, this.BoobsSclY.value, this.BoobsSclZ.value);
    this.DisplayPerson.BoobRight.localPosition = new Vector3(-this.BoobsPosX.value, this.BoobsPosY.value, this.BoobsPosZ.value);
    this.DisplayPerson.BoobRight.localEulerAngles = new Vector3(this.BoobsRotX.value, -this.BoobsRotY.value, -this.BoobsRotZ.value);
    this.DisplayPerson.BoobRight.localScale = new Vector3(this.BoobsSclX.value, this.BoobsSclY.value, this.BoobsSclZ.value);
    this.DisplayPerson.NippleLeft.localPosition = new Vector3(this.NipplesPosX.value, this.NipplesPosY.value, this.NipplesPosZ.value);
    this.DisplayPerson.NippleLeft.localEulerAngles = new Vector3(this.NipplesRotX.value, this.NipplesRotY.value, this.NipplesRotZ.value);
    this.DisplayPerson.NippleLeft.localScale = new Vector3(this.NipplesSclX.value, this.NipplesSclY.value, this.NipplesSclZ.value);
    this.DisplayPerson.NippleRight.localPosition = new Vector3(-this.NipplesPosX.value, this.NipplesPosY.value, this.NipplesPosZ.value);
    this.DisplayPerson.NippleRight.localEulerAngles = new Vector3(this.NipplesRotX.value, -this.NipplesRotY.value, -this.NipplesRotZ.value);
    this.DisplayPerson.NippleRight.localScale = new Vector3(this.NipplesSclX.value, this.NipplesSclY.value, this.NipplesSclZ.value);
    this.DisplayPerson.AssCheekLeft.localPosition = new Vector3(this.AssPosX.value, this.AssPosY.value, this.AssPosZ.value);
    this.DisplayPerson.AssCheekLeft.localEulerAngles = new Vector3(this.AssRotX.value, this.AssRotY.value, this.AssRotZ.value);
    this.DisplayPerson.AssCheekLeft.localScale = new Vector3(this.AssSclX.value, this.AssSclY.value, this.AssSclZ.value);
    this.DisplayPerson.AssCheekRight.localPosition = new Vector3(-this.AssPosX.value, this.AssPosY.value, this.AssPosZ.value);
    this.DisplayPerson.AssCheekRight.localEulerAngles = new Vector3(this.AssRotX.value, -this.AssRotY.value, -this.AssRotZ.value);
    this.DisplayPerson.AssCheekRight.localScale = new Vector3(this.AssSclX.value, this.AssSclY.value, this.AssSclZ.value);
    this.DisplayPerson.Hips.localScale = new Vector3(this.HipsSclX.value, this.HipsSclY.value, this.HipsSclZ.value);
    this.DisplayPerson.Hips2.localScale = new Vector3(this.Hips2SclX.value, this.Hips2SclY.value, this.Hips2SclZ.value);
    this.DisplayPerson.Belly.localScale = new Vector3(this.BellySclX.value, this.BellySclY.value, this.BellySclZ.value);
    this.DisplayPerson.Waist.localScale = new Vector3(this.WaistSclX.value, this.WaistSclY.value, this.WaistSclZ.value);
    this.DisplayPerson.Torso.localScale = new Vector3(this.TorsoSclX.value, this.TorsoSclY.value, this.TorsoSclZ.value);
    this.DisplayPerson.Neck.localScale = new Vector3(this.NeckSclX.value, this.NeckSclY.value, this.NeckSclZ.value);
    this.DisplayPerson.UpperThighLeft.localScale = new Vector3(this.UpperThighsSclX.value, this.UpperThighsSclY.value, this.UpperThighsSclZ.value);
    this.DisplayPerson.UpperThighRight.localScale = new Vector3(this.UpperThighsSclX.value, this.UpperThighsSclY.value, this.UpperThighsSclZ.value);
    this.DisplayPerson.MidThighLeft.localScale = new Vector3(this.MidThighsSclX.value, this.MidThighsSclY.value, this.MidThighsSclZ.value);
    this.DisplayPerson.MidThighRight.localScale = new Vector3(this.MidThighsSclX.value, this.MidThighsSclY.value, this.MidThighsSclZ.value);
    this.DisplayPerson.LowerThighLeft.localScale = new Vector3(this.LowerThighsSclX.value, this.LowerThighsSclY.value, this.LowerThighsSclZ.value);
    this.DisplayPerson.LowerThighRight.localScale = new Vector3(this.LowerThighsSclX.value, this.LowerThighsSclY.value, this.LowerThighsSclZ.value);
    this.DisplayPerson.CalveLeft.localScale = new Vector3(this.CalvesSclX.value, this.CalvesSclY.value, this.CalvesSclZ.value);
    this.DisplayPerson.CalveRight.localScale = new Vector3(this.CalvesSclX.value, this.CalvesSclY.value, this.CalvesSclZ.value);
    this.DisplayPerson.FootLeft.localScale = new Vector3(this.FeetSclX.value, this.FeetSclY.value, this.FeetSclZ.value);
    this.DisplayPerson.FootRight.localScale = new Vector3(this.FeetSclX.value, this.FeetSclY.value, this.FeetSclZ.value);
    this.DisplayPerson.ShoulderLeft.localScale = new Vector3(this.ShouldersSclX.value, this.ShouldersSclY.value, this.ShouldersSclZ.value);
    this.DisplayPerson.ShoulderRight.localScale = new Vector3(this.ShouldersSclX.value, this.ShouldersSclY.value, this.ShouldersSclZ.value);
    this.DisplayPerson.UpperArmLeft.localScale = new Vector3(this.UpperArmsSclX.value, this.UpperArmsSclY.value, this.UpperArmsSclZ.value);
    this.DisplayPerson.UpperArmRight.localScale = new Vector3(this.UpperArmsSclX.value, this.UpperArmsSclY.value, this.UpperArmsSclZ.value);
    this.DisplayPerson.ForeArmLeft.localScale = new Vector3(this.ForeArmsSclX.value, this.ForeArmsSclY.value, this.ForeArmsSclZ.value);
    this.DisplayPerson.ForeArmRight.localScale = new Vector3(this.ForeArmsSclX.value, this.ForeArmsSclY.value, this.ForeArmsSclZ.value);
    this.DisplayPerson.HandLeft.localScale = new Vector3(this.HandsSclX.value, this.HandsSclY.value, this.HandsSclZ.value);
    this.DisplayPerson.HandRight.localScale = new Vector3(this.HandsSclX.value, this.HandsSclY.value, this.HandsSclZ.value);
  }

  public void Click_UpdateFaceShapes()
  {
    this.DisplayPerson.Head.localScale = new Vector3(this.HeadSclX.value, this.HeadSclY.value, this.HeadSclZ.value);
    this.DisplayPerson.MouthBase.localPosition = new Vector3(this.MouthPosX.value, this.MouthPosY.value, this.MouthPosZ.value);
    this.DisplayPerson.MouthBase.localEulerAngles = new Vector3(this.MouthRot.value, this.DisplayPerson.MouthBase.localEulerAngles.y, this.DisplayPerson.MouthBase.localEulerAngles.z);
    this.DisplayPerson.MouthBase.localScale = new Vector3(this.MouthSclX.value, this.MouthSclY.value, this.MouthSclZ.value);
    this.DisplayPerson.MouthLeft.localPosition = new Vector3(this.MouthSidesPosX.value, this.MouthSidesPosY.value, this.MouthSidesPosZ.value);
    this.DisplayPerson.MouthLeft.localScale = new Vector3(this.MouthSidesSclX.value, this.MouthSidesSclY.value, this.MouthSidesSclZ.value);
    this.DisplayPerson.MouthRight.localPosition = new Vector3(-this.MouthSidesPosX.value, this.MouthSidesPosY.value, this.MouthSidesPosZ.value);
    this.DisplayPerson.MouthRight.localScale = new Vector3(this.MouthSidesSclX.value, this.MouthSidesSclY.value, this.MouthSidesSclZ.value);
    this.DisplayPerson.MouthTop.localEulerAngles = new Vector3(this.MouthTop.value, this.DisplayPerson.MouthTop.localEulerAngles.y, this.DisplayPerson.MouthTop.localEulerAngles.z);
    this.DisplayPerson.MouthBottom.localEulerAngles = new Vector3(this.MouthLow.value, this.DisplayPerson.MouthBottom.localEulerAngles.y, this.DisplayPerson.MouthBottom.localEulerAngles.z);
    this.DisplayPerson.CheekUpLeft.localPosition = new Vector3(this.CheeksPosX.value, this.CheeksPosY.value, this.CheeksPosZ.value);
    this.DisplayPerson.CheekUpRight.localPosition = new Vector3(-this.CheeksPosX.value, this.CheeksPosY.value, this.CheeksPosZ.value);
    this.DisplayPerson.Jaw.localPosition = new Vector3(this.JawPosX.value, this.JawPosY.value, this.JawPosZ.value);
    this.DisplayPerson.Jaw.localEulerAngles = new Vector3(this.JawRotX.value, this.JawRotY.value, this.JawRotZ.value);
    this.DisplayPerson.Jaw.localScale = new Vector3(this.JawSclX.value, this.JawSclY.value, this.JawSclZ.value);
    this.DisplayPerson.JawLow.localPosition = new Vector3(this.JawLowPosX.value, this.JawLowPosY.value, this.JawLowPosZ.value);
    this.DisplayPerson.JawLow.localEulerAngles = new Vector3(this.JawLowRotX.value, this.JawLowRotY.value, this.JawLowRotZ.value);
    this.DisplayPerson.JawLow.localScale = new Vector3(this.JawLowSclX.value, this.JawLowSclY.value, this.JawLowSclZ.value);
    this.DisplayPerson.Chin.localPosition = new Vector3(this.ChinPosX.value, this.ChinPosY.value, this.ChinPosZ.value);
    this.DisplayPerson.Chin.localEulerAngles = new Vector3(this.ChinRotX.value, this.ChinRotY.value, this.ChinRotZ.value);
    this.DisplayPerson.Chin.localScale = new Vector3(this.ChinSclX.value, this.ChinSclY.value, this.ChinSclZ.value);
    this.DisplayPerson.EarLeft.localPosition = new Vector3(this.EarsPosX.value, this.EarsPosY.value, this.EarsPosZ.value);
    this.DisplayPerson.EarLeft.localEulerAngles = new Vector3(this.EarsRotX.value, this.EarsRotY.value, this.EarsRotZ.value);
    this.DisplayPerson.EarLeft.localScale = new Vector3(this.EarsSclX.value, this.EarsSclY.value, this.EarsSclZ.value);
    this.DisplayPerson.EarRight.localPosition = new Vector3(-this.EarsPosX.value, this.EarsPosY.value, this.EarsPosZ.value);
    this.DisplayPerson.EarRight.localEulerAngles = new Vector3(this.EarsRotX.value, -this.EarsRotY.value, -this.EarsRotZ.value);
    this.DisplayPerson.EarRight.localScale = new Vector3(this.EarsSclX.value, this.EarsSclY.value, this.EarsSclZ.value);
    this.DisplayPerson.EarLeftLow.localPosition = new Vector3(this.EarsLowPosX.value, this.EarsLowPosY.value, this.EarsLowPosZ.value);
    this.DisplayPerson.EarLeftLow.localEulerAngles = new Vector3(this.EarsLowRotX.value, this.EarsLowRotY.value, this.EarsLowRotZ.value);
    this.DisplayPerson.EarLeftLow.localScale = new Vector3(this.EarsLowSclX.value, this.EarsLowSclY.value, this.EarsLowSclZ.value);
    this.DisplayPerson.EarRightLow.localPosition = new Vector3(-this.EarsLowPosX.value, this.EarsLowPosY.value, this.EarsLowPosZ.value);
    this.DisplayPerson.EarRightLow.localEulerAngles = new Vector3(this.EarsLowRotX.value, -this.EarsLowRotY.value, -this.EarsLowRotZ.value);
    this.DisplayPerson.EarRightLow.localScale = new Vector3(this.EarsLowSclX.value, this.EarsLowSclY.value, this.EarsLowSclZ.value);
    this.DisplayPerson.EarLeftHigh.localPosition = new Vector3(this.EarsHighPosX.value, this.EarsHighPosY.value, this.EarsHighPosZ.value);
    this.DisplayPerson.EarLeftHigh.localEulerAngles = new Vector3(this.EarsHighRotX.value, this.EarsHighRotY.value, this.EarsHighRotZ.value);
    this.DisplayPerson.EarLeftHigh.localScale = new Vector3(this.EarsHighSclX.value, this.EarsHighSclY.value, this.EarsHighSclZ.value);
    this.DisplayPerson.EarRightHigh.localPosition = new Vector3(-this.EarsHighPosX.value, this.EarsHighPosY.value, this.EarsHighPosZ.value);
    this.DisplayPerson.EarRightHigh.localEulerAngles = new Vector3(this.EarsHighRotX.value, -this.EarsHighRotY.value, -this.EarsHighRotZ.value);
    this.DisplayPerson.EarRightHigh.localScale = new Vector3(this.EarsHighSclX.value, this.EarsHighSclY.value, this.EarsHighSclZ.value);
    this.DisplayPerson.Nose.localPosition = new Vector3(this.NosePosX.value, this.NosePosY.value, this.NosePosZ.value);
    this.DisplayPerson.Nose.localEulerAngles = new Vector3(this.NoseRotX.value, this.NoseRotY.value, this.NoseRotZ.value);
    this.DisplayPerson.Nose.localScale = new Vector3(this.NoseSclX.value, this.NoseSclY.value, this.NoseSclZ.value);
    this.DisplayPerson.NoseBridge.localPosition = new Vector3(this.NoseBridgePosX.value, this.NoseBridgePosY.value, this.NoseBridgePosZ.value);
    this.DisplayPerson.NoseBridge.localEulerAngles = new Vector3(this.NoseBridgeRotX.value, this.NoseBridgeRotY.value, this.NoseBridgeRotZ.value);
    this.DisplayPerson.NoseBridge.localScale = new Vector3(this.NoseBridgeSclX.value, this.NoseBridgeSclY.value, this.NoseBridgeSclZ.value);
    this.DisplayPerson.NoseTip.localPosition = new Vector3(this.NoseTipPosX.value, this.NoseTipPosY.value, this.NoseTipPosZ.value);
    this.DisplayPerson.NoseTip.localEulerAngles = new Vector3(this.NoseTipRotX.value, this.NoseTipRotY.value, this.NoseTipRotZ.value);
    this.DisplayPerson.NoseTip.localScale = new Vector3(this.NoseTipSclX.value, this.NoseTipSclY.value, this.NoseTipSclZ.value);
    this.DisplayPerson.NostrilLeft.localPosition = new Vector3(this.NostrilsPosX.value, this.NostrilsPosY.value, this.NostrilsPosZ.value);
    this.DisplayPerson.NostrilLeft.localEulerAngles = new Vector3(this.NostrilsRotX.value, this.NostrilsRotY.value, this.NostrilsRotZ.value);
    this.DisplayPerson.NostrilLeft.localScale = new Vector3(this.NostrilsSclX.value, this.NostrilsSclY.value, this.NostrilsSclZ.value);
    this.DisplayPerson.NostrilRight.localPosition = new Vector3(-this.NostrilsPosX.value, this.NostrilsPosY.value, this.NostrilsPosZ.value);
    this.DisplayPerson.NostrilRight.localEulerAngles = new Vector3(this.NostrilsRotX.value, -this.NostrilsRotY.value, -this.NostrilsRotZ.value);
    this.DisplayPerson.NostrilRight.localScale = new Vector3(this.NostrilsSclX.value, this.NostrilsSclY.value, this.NostrilsSclZ.value);
    this.DisplayPerson.EyeLeft.localPosition = new Vector3(this.EyesPosX.value, this.EyesPosY.value, this.EyesPosZ.value);
    this.DisplayPerson.EyeLeft.localEulerAngles = new Vector3(this.EyesRotX.value, this.EyesRotY.value, this.EyesRotZ.value);
    this.DisplayPerson.EyeLeft.localScale = new Vector3(this.EyesSclX.value, this.EyesSclY.value, this.EyesSclZ.value);
    this.DisplayPerson.EyeRight.localPosition = new Vector3(-this.EyesPosX.value, this.EyesPosY.value, this.EyesPosZ.value);
    this.DisplayPerson.EyeRight.localEulerAngles = new Vector3(this.EyesRotX.value, -this.EyesRotY.value, -this.EyesRotZ.value);
    this.DisplayPerson.EyeRight.localScale = new Vector3(this.EyesSclX.value, this.EyesSclY.value, this.EyesSclZ.value);
    this.DisplayPerson.EyeLeftTop.localPosition = new Vector3(this.EyesTopPosX.value, this.EyesTopPosY.value, this.EyesTopPosZ.value);
    this.DisplayPerson.EyeLeftTop.localEulerAngles = new Vector3(this.EyesTopRotX.value, this.EyesTopRotY.value, this.EyesTopRotZ.value);
    this.DisplayPerson.EyeLeftTop.localScale = new Vector3(this.EyesTopSclX.value, this.EyesTopSclY.value, this.EyesTopSclZ.value);
    this.DisplayPerson.EyeRightTop.localPosition = new Vector3(-this.EyesTopPosX.value, this.EyesTopPosY.value, this.EyesTopPosZ.value);
    this.DisplayPerson.EyeRightTop.localEulerAngles = new Vector3(this.EyesTopRotX.value, -this.EyesTopRotY.value, -this.EyesTopRotZ.value);
    this.DisplayPerson.EyeRightTop.localScale = new Vector3(this.EyesTopSclX.value, this.EyesTopSclY.value, this.EyesTopSclZ.value);
    this.DisplayPerson.EyeLeftLow.localPosition = new Vector3(this.EyesLowPosX.value, this.EyesLowPosY.value, this.EyesLowPosZ.value);
    this.DisplayPerson.EyeLeftLow.localEulerAngles = new Vector3(this.EyesLowRotX.value, this.EyesLowRotY.value, this.EyesLowRotZ.value);
    this.DisplayPerson.EyeLeftLow.localScale = new Vector3(this.EyesLowSclX.value, this.EyesLowSclY.value, this.EyesLowSclZ.value);
    this.DisplayPerson.EyeRightLow.localPosition = new Vector3(-this.EyesLowPosX.value, this.EyesLowPosY.value, this.EyesLowPosZ.value);
    this.DisplayPerson.EyeRightLow.localEulerAngles = new Vector3(this.EyesLowRotX.value, -this.EyesLowRotY.value, -this.EyesLowRotZ.value);
    this.DisplayPerson.EyeRightLow.localScale = new Vector3(this.EyesLowSclX.value, this.EyesLowSclY.value, this.EyesLowSclZ.value);
    this.DisplayPerson.EyeLeftInner.localPosition = new Vector3(this.EyesInnerPosX.value, this.EyesInnerPosY.value, this.EyesInnerPosZ.value);
    this.DisplayPerson.EyeLeftInner.localEulerAngles = new Vector3(this.EyesInnerRotX.value, this.EyesInnerRotY.value, this.EyesInnerRotZ.value);
    this.DisplayPerson.EyeLeftInner.localScale = new Vector3(this.EyesInnerSclX.value, this.EyesInnerSclY.value, this.EyesInnerSclZ.value);
    this.DisplayPerson.EyeRightInner.localPosition = new Vector3(-this.EyesInnerPosX.value, this.EyesInnerPosY.value, this.EyesInnerPosZ.value);
    this.DisplayPerson.EyeRightInner.localEulerAngles = new Vector3(this.EyesInnerRotX.value, -this.EyesInnerRotY.value, -this.EyesInnerRotZ.value);
    this.DisplayPerson.EyeRightInner.localScale = new Vector3(this.EyesInnerSclX.value, this.EyesInnerSclY.value, this.EyesInnerSclZ.value);
    this.DisplayPerson.EyeLeftOuter.localPosition = new Vector3(this.EyesOuterPosX.value, this.EyesOuterPosY.value, this.EyesOuterPosZ.value);
    this.DisplayPerson.EyeLeftOuter.localEulerAngles = new Vector3(this.EyesOuterRotX.value, this.EyesOuterRotY.value, this.EyesOuterRotZ.value);
    this.DisplayPerson.EyeLeftOuter.localScale = new Vector3(this.EyesOuterSclX.value, this.EyesOuterSclY.value, this.EyesOuterSclZ.value);
    this.DisplayPerson.EyeRightOuter.localPosition = new Vector3(-this.EyesOuterPosX.value, this.EyesOuterPosY.value, this.EyesOuterPosZ.value);
    this.DisplayPerson.EyeRightOuter.localEulerAngles = new Vector3(this.EyesOuterRotX.value, -this.EyesOuterRotY.value, -this.EyesOuterRotZ.value);
    this.DisplayPerson.EyeRightOuter.localScale = new Vector3(this.EyesOuterSclX.value, this.EyesOuterSclY.value, this.EyesOuterSclZ.value);
  }

  public void Click_UpdateMaleFaceShapes()
  {
    this.DisplayPersonMale.Jaw.localScale = new Vector3(1f, this.Malejaw.value, 1f);
    this.DisplayPersonMale.Chin.localScale = new Vector3(1f, this.MaleChin.value, 1f);
    this.DisplayPersonMale.Nose.localEulerAngles = new Vector3(-180f, this.MaleNoseRot.value, 0.0f);
    this.DisplayPersonMale.Nose.localScale = new Vector3(this.MaleNoseSclX.value, this.MaleNoseSclY.value, this.MaleNoseSclZ.value);
    this.DisplayPersonMale.EyeLeft.localPosition = new Vector3(this.MaleEyesPosX.value, this.MaleEyesPosY.value, 0.0f);
    this.DisplayPersonMale.EyeRight.localPosition = new Vector3(-this.MaleEyesPosX.value, this.MaleEyesPosY.value, 0.0f);
    this.DisplayPersonMale.EyeLeft.localEulerAngles = new Vector3(this.MaleEyesRot.value, 0.0f, 0.0f);
    this.DisplayPersonMale.EyeRight.localEulerAngles = new Vector3(this.MaleEyesRot.value, 0.0f, 0.0f);
    this.DisplayPersonMale.EyeLeft.localScale = new Vector3(this.MaleEyesScl.value, this.MaleEyesScl.value, this.MaleEyesScl.value);
    this.DisplayPersonMale.EyeRight.localScale = new Vector3(this.MaleEyesScl.value, this.MaleEyesScl.value, this.MaleEyesScl.value);
    this.DisplayPersonMale2.Jaw.localScale = new Vector3(1f, this.Malejaw.value, 1f);
    this.DisplayPersonMale2.Chin.localScale = new Vector3(1f, this.MaleChin.value, 1f);
    this.DisplayPersonMale2.Nose.localEulerAngles = new Vector3(-180f, this.MaleNoseRot.value, 0.0f);
    this.DisplayPersonMale2.Nose.localScale = new Vector3(this.MaleNoseSclX.value, this.MaleNoseSclY.value, this.MaleNoseSclZ.value);
    this.DisplayPersonMale2.EyeLeft.localPosition = new Vector3(this.MaleEyesPosX.value, this.MaleEyesPosY.value, 0.0f);
    this.DisplayPersonMale2.EyeRight.localPosition = new Vector3(-this.MaleEyesPosX.value, this.MaleEyesPosY.value, 0.0f);
    this.DisplayPersonMale2.EyeLeft.localEulerAngles = new Vector3(this.MaleEyesRot.value, 0.0f, 0.0f);
    this.DisplayPersonMale2.EyeRight.localEulerAngles = new Vector3(this.MaleEyesRot.value, 0.0f, 0.0f);
    this.DisplayPersonMale2.EyeLeft.localScale = new Vector3(this.MaleEyesScl.value, this.MaleEyesScl.value, this.MaleEyesScl.value);
    this.DisplayPersonMale2.EyeRight.localScale = new Vector3(this.MaleEyesScl.value, this.MaleEyesScl.value, this.MaleEyesScl.value);
  }

  public void Click_RandomBody()
  {
    this.DisplayPerson.GenerateRandomBody();
    this.DisplayPerson.transform.localScale = Vector3.one;
    this.UpdateValuesFrom(this.DisplayPerson);
  }

  public void Click_RandomFace()
  {
    this.DisplayPerson.GenerateRandomFace();
    this.UpdateValuesFrom(this.DisplayPerson);
  }

  public void Click_RandomHair()
  {
    this.DisplayPerson.NaturalHairColor = Main.Instance.NaturalHairColors[UnityEngine.Random.Range(0, Main.Instance.NaturalHairColors.Length)];
    this.HairRedColor.SetValueWithoutNotify(this.DisplayPerson.NaturalHairColor.r);
    this.HairGreenColor.SetValueWithoutNotify(this.DisplayPerson.NaturalHairColor.g);
    this.HairBlueColor.SetValueWithoutNotify(this.DisplayPerson.NaturalHairColor.b);
    int index;
    do
    {
      index = UnityEngine.Random.Range(0, this.HairList.options.Count);
    }
    while (Main.Instance.Prefabs_Hair[index].GetComponent<Dressable>().Ugly);
    this.HairList.value = index;
  }

  public void Click_RandomColors()
  {
    this.DisplayPerson.NaturalEyeColor = Main.Instance.NaturalEyeColors[UnityEngine.Random.Range(0, Main.Instance.NaturalEyeColors.Length)];
    this.DisplayPerson.NaturalSkinColor = Main.Instance.NaturalSkinColors[UnityEngine.Random.Range(0, Main.Instance.NaturalSkinColors.Length)];
    this.DisplayPerson.RefreshColors();
    this.EyeRedColor.SetValueWithoutNotify(this.DisplayPerson.NaturalEyeColor.r);
    this.EyeGreenColor.SetValueWithoutNotify(this.DisplayPerson.NaturalEyeColor.g);
    this.EyeBlueColor.SetValueWithoutNotify(this.DisplayPerson.NaturalEyeColor.b);
    this.SkinRedColor.SetValueWithoutNotify(this.DisplayPerson.NaturalSkinColor.r);
    this.SkinGreenColor.SetValueWithoutNotify(this.DisplayPerson.NaturalSkinColor.g);
    this.SkinBlueColor.SetValueWithoutNotify(this.DisplayPerson.NaturalSkinColor.b);
  }

  public void Click_FixBoobs()
  {
    this.DisplayPerson.FixAverageScaleFor(this.DisplayPerson.BoobLeft);
    this.DisplayPerson.FixAverageScaleFor(this.DisplayPerson.BoobRight);
    this.BoobsSclX.SetValueWithoutNotify(this.DisplayPerson.BoobLeft.localScale.x);
    this.BoobsSclY.SetValueWithoutNotify(this.DisplayPerson.BoobLeft.localScale.y);
    this.BoobsSclZ.SetValueWithoutNotify(this.DisplayPerson.BoobLeft.localScale.z);
  }

  public void Click_FixLegs()
  {
    this.DisplayPerson.FixAverageScaleFor(this.DisplayPerson.UpperThighLeft);
    this.DisplayPerson.FixAverageScaleFor(this.DisplayPerson.UpperThighRight);
    this.UpperThighsSclX.SetValueWithoutNotify(this.DisplayPerson.UpperThighLeft.localScale.x);
    this.UpperThighsSclY.SetValueWithoutNotify(this.DisplayPerson.UpperThighLeft.localScale.y);
    this.UpperThighsSclZ.SetValueWithoutNotify(this.DisplayPerson.UpperThighLeft.localScale.z);
  }

  public void RandomizeAll()
  {
    this.Click_Futa();
    this.Click_RandomColors();
    this.Click_RandomHair();
    this.Click_RandomFace();
    this.Click_RandomBody();
    this.Click_FixLegs();
    this.Click_FixLegs();
    this.Click_FixLegs();
    this.Click_FixLegs();
    this.Click_FixBoobs();
    this.Click_FixBoobs();
    this.Click_FixBoobs();
    this.Click_FixBoobs();
  }

  public void TempClick_Female() => this.MaleWarningMsg.SetActive(true);

  public void CloseMaleWarning()
  {
    this.MaleUnfinishedWarning3.SetActive(false);
    this.MaleWarningMsg.SetActive(false);
  }

  public void Click_Female()
  {
    if (this.Female.isOn)
    {
      this.DisplayPerson.gameObject.SetActive(true);
      this.DisplayPersonMale.gameObject.SetActive(false);
      this.DisplayPersonMale2.gameObject.SetActive(false);
      this.Futa.interactable = true;
      this.HasBalls.interactable = true;
      this.BeardList.gameObject.SetActive(false);
      for (int index = 0; index < this.EnabledWhileFemale.Length; ++index)
        this.EnabledWhileFemale[index].SetActive(true);
      for (int index = 0; index < this.EnabledWhileMale.Length; ++index)
        this.EnabledWhileMale[index].SetActive(false);
    }
    else
    {
      this.DisplayPerson.gameObject.SetActive(false);
      this.DisplayPersonMale2.gameObject.SetActive(false);
      this.DisplayPersonMale.gameObject.SetActive(true);
      this.Futa.interactable = false;
      this.HasBalls.interactable = false;
      this.AltBody.gameObject.SetActive(true);
      this.AltBody.SetIsOnWithoutNotify(true);
      this.BeardList.gameObject.SetActive(true);
      for (int index = 0; index < this.EnabledWhileFemale.Length; ++index)
        this.EnabledWhileFemale[index].SetActive(false);
      for (int index = 0; index < this.EnabledWhileMale.Length; ++index)
        this.EnabledWhileMale[index].SetActive(true);
    }
  }

  public void Click_DropdownGender()
  {
    this.DisplayPerson.gameObject.SetActive(false);
    this.DisplayPersonMale.gameObject.SetActive(false);
    this.DisplayPersonMale2.gameObject.SetActive(false);
    this.NotAvailableLabel.SetActive(false);
    this.NotAvailableLabel2.SetActive(false);
    this.FinishBtn.interactable = true;
    this.Futa.interactable = false;
    this.HasBalls.interactable = false;
    for (int index = 0; index < this.EnabledWhileFemale.Length; ++index)
      this.EnabledWhileFemale[index].SetActive(false);
    for (int index = 0; index < this.EnabledWhileMale.Length; ++index)
      this.EnabledWhileMale[index].SetActive(false);
    switch (this.GenderDrop.value)
    {
      case 1:
        int dificultySelected = Main.Instance.NewGameMenu.DificultySelected;
        this.MaleUnfinishedWarning3.SetActive(true);
        this.DisplayPersonMale.gameObject.SetActive(true);
        for (int index = 0; index < this.EnabledWhileMale.Length; ++index)
          this.EnabledWhileMale[index].SetActive(true);
        break;
      case 2:
        this.NotAvailableLabel.SetActive(true);
        this.FinishBtn.interactable = false;
        this.DisplayPersonMale2.gameObject.SetActive(true);
        for (int index = 0; index < this.EnabledWhileMale.Length; ++index)
          this.EnabledWhileMale[index].SetActive(true);
        break;
      default:
        this.DisplayPerson.gameObject.SetActive(true);
        this.Futa.interactable = true;
        this.HasBalls.interactable = true;
        for (int index = 0; index < this.EnabledWhileFemale.Length; ++index)
          this.EnabledWhileFemale[index].SetActive(true);
        break;
    }
  }

  public void Click_Futa()
  {
    ((Girl) this.DisplayPerson).Futa = this.Futa.isOn;
    this.DisplayPerson.RefreshColors();
    this.Clothes.isOn = false;
    this.DisplayPerson.Penis.SetActive(this.Futa.isOn);
    this.DisplayPerson.PenisErect = true;
    Main.RunInNextFrame((Action) (() => this.DisplayPerson.PenisErect = false));
    this.HasBalls.gameObject.SetActive(((Girl) this.DisplayPerson).Futa);
  }

  public void Click_Balls() => this.DisplayPerson.HasBalls = this.HasBalls.isOn;

  public void Click_PPSize()
  {
    this._RefresPP(this.DisplayPerson);
    this._RefresPP(this.DisplayPersonMale);
    this._RefresPP(this.DisplayPersonMale2);
  }

  public void _RefresPP(Person person)
  {
    person.PenisErect = true;
    person.Penis.transform.localScale = new Vector3(this.PenisSize.value, this.PenisSize.value, this.PenisSize.value);
    Main.RunInNextFrame((Action) (() => person.PenisErect = false));
  }

  public void OnFutaChance()
  {
    UI_Customize.FutaChanceValue = this.FutaChanceSlider.value;
    this.FutaChanceText.text = (this.FutaChanceSlider.value * 100f).ToString("##0") + "%";
    Main.Instance.GlobalVars.Set("FutaChance", UI_Customize.FutaChanceValue.ToString("0.0##"));
  }

  public void OnGenderSettings()
  {
    this.StoryGenderText.enabled = false;
    if (this.GenderSettings.value == 1)
    {
      this.StoryGenderText.text = "(Plot Related) Protagonist's Father will always be Male";
      this.StoryGenderText.enabled = true;
    }
    else
    {
      if (this.GenderSettings.value != 2)
        return;
      this.StoryGenderText.text = "(Plot Related) Some characters will always be Female    /    NOT RECOMENDED YET!  Use at least [Mostly Males]";
      this.StoryGenderText.enabled = true;
    }
  }

  public void Click_SaveCamType()
  {
    this.SaveTorsoCam.SetActive(!this.SaveTorsoCam.activeSelf);
    this.SaveFaceCam.SetActive(!this.SaveFaceCam.activeSelf);
    this.DisplayPerson.LookAtPlayer.playerTransform = !this.SaveTorsoCam.activeSelf ? this.SaveFaceCam.transform : this.SaveTorsoCam.transform;
    SexPose_Miss.AdjustCharacterPosition(this.SaveTorsoCam.transform, this.SaveTorsoCam_Position, this.SaveTorsoCam.transform);
    SexPose_Miss.AdjustCharacterPosition(this.SaveFaceCam.transform, this.SaveFaceCam_Position, this.SaveFaceCam.transform);
  }

  public void Click_CancelSave()
  {
    this.InPresets = false;
    if ((UnityEngine.Object) this.DisplayPerson.CurrentHair != (UnityEngine.Object) null)
      this.DisplayPerson.CurrentHair.gameObject.SetActive(true);
    this.CLoseSaveMenus();
  }

  public void Click_Save()
  {
    this.InPresets = false;
    this.MainCustomMenu.SetActive(false);
    this.PictureFrame.SetActive(true);
    this.DisableInPresets.SetActive(true);
    if (this.MainCam.activeSelf)
    {
      this.SaveTorsoCam.SetActive(true);
      this.DisplayPerson.LookAtPlayer.playerTransform = this.SaveTorsoCam.transform;
    }
    else
    {
      this.SaveFaceCam.SetActive(true);
      this.DisplayPerson.LookAtPlayer.playerTransform = this.SaveFaceCam.transform;
    }
    SexPose_Miss.AdjustCharacterPosition(this.SaveTorsoCam.transform, this.SaveTorsoCam_Position, this.SaveTorsoCam.transform);
    SexPose_Miss.AdjustCharacterPosition(this.SaveFaceCam.transform, this.SaveFaceCam_Position, this.SaveFaceCam.transform);
  }

  public void Click_Load()
  {
    this.CustomMenuList.value = 0;
    this.ChangeCustomMenu();
    this.CLoseSaveMenus();
    this.MainCustomMenu.SetActive(false);
    this.LoadCharcterListMenu.SetActive(true);
    this.Open_LoadCharacterList();
  }

  public void CLoseSaveMenus()
  {
    this.InPresets = false;
    this.LoadCharcterListMenu.SetActive(false);
    this.PictureFrame.SetActive(false);
    this.MainCustomMenu.SetActive(true);
    if (!((UnityEngine.Object) this.SaveTorsoCam != (UnityEngine.Object) null))
      return;
    this.SaveTorsoCam.SetActive(false);
    this.SaveFaceCam.SetActive(false);
    this.DisplayPerson.LookAtPlayer.playerTransform = this.ZoomCam.transform;
  }

  public void FadeText(UnityEngine.UI.Text text, float duration)
  {
    this.StartCoroutine(this.FadeTextCoroutine(text, duration));
  }

  private IEnumerator FadeTextCoroutine(UnityEngine.UI.Text text, float duration)
  {
    Color color1 = text.color;
    float fadeAmountPerFrame = (float) (1.0 / ((double) duration * 60.0));
    while ((double) text.color.a > 0.0)
    {
      Color color2 = text.color;
      color2.a -= fadeAmountPerFrame;
      text.color = color2;
      yield return (object) null;
    }
  }

  public void LoadCharacter(string filename, bool loadClothing = true)
  {
    this.Female.isOn = true;
    if ((UnityEngine.Object) this.DisplayPerson.CurrentHair != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.DisplayPerson.UndressClothe(this.DisplayPerson.CurrentHair));
    this.DisplayPerson.StartingClothes.Clear();
    this.DisplayPerson._StartingClothes.Clear();
    this.DisplayPerson._States = new bool[0];
    this.DisplayPerson._SkinStates = new bool[0];
    this.DisplayPerson._FaceSkinStates = new bool[0];
    this.DisplayPerson._DontLoadClothing = !loadClothing;
    this.DisplayPerson.LoadFromFile(filename);
    this.DisplayPerson.Inited = false;
    this.DisplayPerson.Init();
    this.Futa.isOn = this.DisplayPerson.HasPenis;
    this.PenisSize.value = this.DisplayPerson.Penis.transform.localScale.x;
    this.DisplayPerson.transform.localPosition = Vector3.zero;
    this.DisplayPerson.transform.localEulerAngles = Vector3.zero;
    this.DisplayPerson.DyedEyeColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.DisplayPerson.DyedHairColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.DisplayPerson.TannedSkinColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.HairRedColor.SetValueWithoutNotify(this.DisplayPerson.NaturalHairColor.r);
    this.HairGreenColor.SetValueWithoutNotify(this.DisplayPerson.NaturalHairColor.g);
    this.HairBlueColor.SetValueWithoutNotify(this.DisplayPerson.NaturalHairColor.b);
    this.Click_UpdateHairColor();
    this.EyeRedColor.SetValueWithoutNotify(this.DisplayPerson.NaturalEyeColor.r);
    this.EyeGreenColor.SetValueWithoutNotify(this.DisplayPerson.NaturalEyeColor.g);
    this.EyeBlueColor.SetValueWithoutNotify(this.DisplayPerson.NaturalEyeColor.b);
    this.SkinRedColor.SetValueWithoutNotify(this.DisplayPerson.NaturalSkinColor.r);
    this.SkinGreenColor.SetValueWithoutNotify(this.DisplayPerson.NaturalSkinColor.g);
    this.SkinBlueColor.SetValueWithoutNotify(this.DisplayPerson.NaturalSkinColor.b);
    this.Click_UpdateColors();
    this.PlayerNameField.text = this.DisplayPerson.Name;
    this.PregnancySlider.value = (this.DisplayPerson as Girl).PregnancyPercent;
    this.HeightSlider.value = this.DisplayPerson.transform.localScale.y;
    this.DisplayPerson.Height = this.HeightSlider.value;
    this.PersonalityDrop.value = (int) this.DisplayPerson.Personality;
    for (int index = 0; index < this.FetishToggles.Length; ++index)
      this.FetishToggles[index].SetIsOnWithoutNotify(false);
    for (int index = 0; index < this.DisplayPerson.Fetishes.Count; ++index)
      this.FetishToggles[(int) this.DisplayPerson.Fetishes[index]].SetIsOnWithoutNotify(true);
    for (int index = 0; index < this.BodyStateToggles.Length; ++index)
    {
      if ((UnityEngine.Object) this.BodyStateToggles[index] != (UnityEngine.Object) null)
        this.BodyStateToggles[index].SetIsOnWithoutNotify(this.DisplayPerson.States[index]);
    }
    for (int index = 0; index < this.FaceStateToggles.Length; ++index)
    {
      if ((UnityEngine.Object) this.FaceStateToggles[index] != (UnityEngine.Object) null)
        this.FaceStateToggles[index].SetIsOnWithoutNotify(this.DisplayPerson.States[index]);
    }
    try
    {
      this.DisplayPerson.SetBodyTexture();
    }
    catch
    {
    }
    this.PlayerNameField.text = this.DisplayPerson.name;
    this.Input_NameChanged();
  }

  public void LoadCharacterMale(string filename)
  {
    this.Female.isOn = false;
    if ((UnityEngine.Object) this.DisplayPersonMale.CurrentHair != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.DisplayPersonMale.UndressClothe(this.DisplayPersonMale.CurrentHair));
    this.DisplayPersonMale.StartingClothes.Clear();
    this.DisplayPersonMale._StartingClothes.Clear();
    this.DisplayPersonMale.LoadFromFile(filename);
    this.PenisSize.value = this.DisplayPersonMale.Penis.transform.localScale.x;
    this.DisplayPersonMale.transform.localPosition = Vector3.zero;
    this.DisplayPersonMale.transform.localEulerAngles = Vector3.zero;
  }

  public void LoadCharacterMale2(string filename)
  {
    this.Female.isOn = false;
    if ((UnityEngine.Object) this.DisplayPersonMale2.CurrentHair != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.DisplayPersonMale2.UndressClothe(this.DisplayPersonMale2.CurrentHair));
    this.DisplayPersonMale2.StartingClothes.Clear();
    this.DisplayPersonMale2._StartingClothes.Clear();
    this.DisplayPersonMale2.LoadFromFile(filename);
    this.PenisSize.value = this.DisplayPersonMale2.Penis.transform.localScale.x;
    this.DisplayPersonMale2.transform.localPosition = Vector3.zero;
    this.DisplayPersonMale2.transform.localEulerAngles = Vector3.zero;
  }

  public void Click_ActualSave()
  {
    string str1;
    if (this.InPresets)
      str1 = $"{Main.AssetsFolder}/Characters/{(this.Female.isOn ? $"Girls/{(this.PresetsFace ? "Face" : "Body")}Presets/" : $"Guys/{(this.PresetsFace ? "Face" : "Body")}Presets/")}{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss_")}{UnityEngine.Random.Range(0, 999).ToString()}.png";
    else
      str1 = $"{Main.AssetsFolder}/Characters/{(this.Female.isOn ? "Girls/" : "Guys/")}{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss_")}{UnityEngine.Random.Range(0, 999).ToString()}.png";
    string str2 = str1 + "dara";
    this.TakeFaceScreenshot(str1);
    if (this.Female.isOn)
      this.DisplayPerson.SaveToFile(str2);
    else if (this.AltBody.isOn)
      this.DisplayPersonMale2.SaveToFile(str2);
    else
      this.DisplayPersonMale.SaveToFile(str2);
    this.PicSavedText.color = Color.white;
    this.FadeText(this.PicSavedText, 3f);
    List<byte> byteList = new List<byte>();
    byteList.AddRange((IEnumerable<byte>) UI_Customize.StringToBytes("DataStart"));
    byteList.AddRange((IEnumerable<byte>) File.ReadAllBytes(str2));
    UI_Customize.AddCustomChunkToPng(str1, byteList.ToArray(), "blch");
    File.Delete(str2);
  }

  public static byte[] StringToBytes(string str) => Encoding.UTF8.GetBytes(str);

  public static byte[] ConvertIntToByteArray(int number)
  {
    byte[] bytes = BitConverter.GetBytes(number);
    if (BitConverter.IsLittleEndian)
      Array.Reverse<byte>(bytes);
    return bytes;
  }

  public static int ConvertByteArrayToInt(byte[] byteArray)
  {
    if (BitConverter.IsLittleEndian)
      Array.Reverse<byte>(byteArray);
    return BitConverter.ToInt32(byteArray, 0);
  }

  public static long FindDataStart(string filePath, byte[] sequence)
  {
    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    {
      byte[] numArray = new byte[sequence.Length];
      for (long index = fileStream.Length - (long) sequence.Length; index >= 0L; --index)
      {
        fileStream.Position = index;
        fileStream.Read(numArray, 0, numArray.Length);
        if (((IEnumerable<byte>) sequence).SequenceEqual<byte>((IEnumerable<byte>) numArray))
          return index + (long) sequence.Length;
      }
      return -1;
    }
  }

  public void TakeFaceScreenshot(string filepath)
  {
    (this.SaveTorsoCam.activeSelf ? this.SaveTorsoCam : this.SaveFaceCam).GetComponent<Camera>();
    Texture2D texture2D = ScreenCapture.CaptureScreenshotAsTexture();
    Rect rect = new Rect(0.316f, 0.01f, 0.368f, 0.98f);
    int x = Mathf.FloorToInt(rect.x * (float) texture2D.width);
    int y = Mathf.FloorToInt(rect.y * (float) texture2D.height);
    int num1 = Mathf.FloorToInt(rect.width * (float) texture2D.width);
    int num2 = Mathf.FloorToInt(rect.height * (float) texture2D.height);
    Texture2D tex = new Texture2D(num1, num2);
    tex.SetPixels(texture2D.GetPixels(x, y, num1, num2));
    tex.Apply();
    byte[] png = tex.EncodeToPNG();
    File.WriteAllBytes(filepath, png);
  }

  public static void AddCustomChunkToPng(string pngFilePath, byte[] chunkData, string chunkType)
  {
    using (FileStream fileStream = new FileStream(pngFilePath, FileMode.Open, FileAccess.ReadWrite))
    {
      byte[] numArray1 = new byte[8];
      fileStream.Read(numArray1, 0, 8);
      if (!UI_Customize.IsPngFile(numArray1))
        throw new Exception("Not a valid PNG file.");
      long iendPosition = UI_Customize.FindIendPosition((Stream) fileStream);
      fileStream.SetLength(iendPosition);
      byte[] bytes1 = BitConverter.GetBytes(chunkData.Length);
      Array.Reverse<byte>(bytes1);
      byte[] bytes2 = Encoding.ASCII.GetBytes(chunkType);
      byte[] numArray2 = new byte[chunkData.Length + 12];
      Array.Copy((Array) bytes1, (Array) numArray2, 4);
      Array.Copy((Array) bytes2, 0, (Array) numArray2, 4, 4);
      Array.Copy((Array) chunkData, 0, (Array) numArray2, 8, chunkData.Length);
      byte[] bytes3 = BitConverter.GetBytes(UI_Customize.CalculateCrc(bytes2, chunkData));
      Array.Reverse<byte>(bytes3);
      Array.Copy((Array) bytes3, 0, (Array) numArray2, chunkData.Length + 8, 4);
      fileStream.Write(numArray2, 0, numArray2.Length);
      byte[] buffer = new byte[12]
      {
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 73,
        (byte) 69,
        (byte) 78,
        (byte) 68,
        (byte) 174,
        (byte) 66,
        (byte) 96 /*0x60*/,
        (byte) 130
      };
      fileStream.Write(buffer, 0, buffer.Length);
    }
  }

  private static long FindIendPosition(Stream stream)
  {
    int int32;
    for (long offset = stream.Length - 12L; offset >= 8L; offset -= (long) (int32 + 12))
    {
      stream.Seek(offset, SeekOrigin.Begin);
      byte[] buffer = new byte[4];
      stream.Read(buffer, 0, 4);
      Array.Reverse<byte>(buffer);
      int32 = BitConverter.ToInt32(buffer, 0);
      byte[] numArray = new byte[4];
      stream.Read(numArray, 0, 4);
      if (Encoding.ASCII.GetString(numArray) == "IEND")
        return offset;
    }
    throw new Exception("No IEND chunk found.");
  }

  private static bool IsPngFile(byte[] pngHeader)
  {
    return pngHeader[0] == (byte) 137 && pngHeader[1] == (byte) 80 /*0x50*/ && pngHeader[2] == (byte) 78 && pngHeader[3] == (byte) 71 && pngHeader[4] == (byte) 13 && pngHeader[5] == (byte) 10 && pngHeader[6] == (byte) 26 && pngHeader[7] == (byte) 10;
  }

  private static uint CalculateCrc(byte[] chunkTypeBytes, byte[] chunkData)
  {
    byte[] numArray = new byte[4];
    BitConverter.GetBytes(UI_Customize.UpdateCrc(UI_Customize.UpdateCrc(uint.MaxValue, chunkTypeBytes), chunkData) ^ uint.MaxValue).CopyTo((Array) numArray, 0);
    return BitConverter.ToUInt32(numArray, 0);
  }

  private static uint UpdateCrc(uint crc, byte[] data)
  {
    for (int index1 = 0; index1 < data.Length; ++index1)
    {
      crc ^= (uint) data[index1];
      for (int index2 = 0; index2 < 8; ++index2)
      {
        if (((int) crc & 1) != 0)
          crc = crc >> 1 ^ 3988292384U;
        else
          crc >>= 1;
      }
    }
    return crc;
  }

  public void UnselectCharacters()
  {
    for (int index = 0; index < this.CharacterEntries2.Count; ++index)
      this.CharacterEntries2[index].ThisSelected.gameObject.SetActive(false);
  }

  public void Open_LoadCharacterList()
  {
    string path = !this.InPresets ? (this.CurrentLoadFolderGirls ? Main.AssetsFolder + "/Characters/Girls/" : Main.AssetsFolder + "/Characters/Guys/") : (this.CurrentLoadFolderGirls ? $"{Main.AssetsFolder}/Characters/Girls/{(this.PresetsFace ? "Face" : "Body")}Presets/" : $"{Main.AssetsFolder}/Characters/Guys/{(this.PresetsFace ? "Face" : "Body")}Presets/");
    for (int index = 0; index < this.CharacterEntries.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.CharacterEntries[index]);
    this.CharacterEntries2.Clear();
    string[] files = Directory.GetFiles(path, "*.png");
    this.CharacterListRect.sizeDelta = new Vector2(0.0f, (float) ((files.Length + 3) / 4 * 150));
    for (int index = 0; index < files.Length; ++index)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.CharacterEntry, this.CharacterEntry.transform.parent);
      this.CharacterEntries.Add(gameObject);
      gameObject.SetActive(true);
      misc_CharacterLoadEntry component = gameObject.GetComponent<misc_CharacterLoadEntry>();
      component.LoadImage(files[index]);
      this.CharacterEntries2.Add(component);
    }
  }

  public void Click_OpenInFolder()
  {
    Application.OpenURL($"file://{Main.AssetsFolder}/Characters/");
  }

  public void Click_LoadSelectedCharacter()
  {
    int num = 0;
    if (this.CurrentLoadFolderGirls)
    {
      if (this.InPresets)
      {
        num = this.PresetsFace ? 1 : 2;
        this.LoadCharacter_Preset(this.SelectedCharacter.ThisFile);
        this.UpdateValuesFrom(this.DisplayPerson);
      }
      else
      {
        this.LoadCharacter(this.SelectedCharacter.ThisFile, false);
        this.UpdateValuesFrom(this.DisplayPerson);
      }
    }
    else
    {
      this.LoadCharacterMale(this.SelectedCharacter.ThisFile);
      this.UpdateValuesFrom(this.DisplayPersonMale);
    }
    this.CLoseSaveMenus();
    if (num != 1)
    {
      if (num != 2)
        return;
      this.CustomMenuList.value = 2;
      this.ChangeCustomMenu();
    }
    else
    {
      this.CustomMenuList.value = 3;
      this.ChangeCustomMenu();
    }
  }

  public void Click_SaveNPC()
  {
    Person relationship = Main.Instance.GameplayMenu.Relationships[Main.Instance.GameplayMenu._SelectedRelsPerson];
    string sourceFileName = $"{Main.AssetsFolder}/Saves/{relationship.WorldSaveID}.png";
    string str1 = $"{Main.AssetsFolder}/Characters/{(relationship is Girl ? "Girls/" : "Guys/")}{relationship.WorldSaveID}.png";
    string str2 = str1 + "dara";
    File.Copy(sourceFileName, str1);
    relationship.SaveToFile(str2);
    List<byte> byteList = new List<byte>();
    byteList.AddRange((IEnumerable<byte>) UI_Customize.StringToBytes("DataStart"));
    byteList.AddRange((IEnumerable<byte>) File.ReadAllBytes(str2));
    UI_Customize.AddCustomChunkToPng(str1, byteList.ToArray(), "blch");
    File.Delete(str2);
    Main.Instance.GameplayMenu.ShowNotification("Saved NPC to Characters/");
  }

  public void RemoveCurrentBeard()
  {
    for (int index = 0; index < this.DisplayPersonMale.EquippedClothes.Count; ++index)
    {
      if (this.DisplayPersonMale.EquippedClothes[index].BodyPart == DressableType.Beard)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.DisplayPersonMale.EquippedClothes[index].gameObject);
        this.DisplayPersonMale.EquippedClothes.RemoveAt(index);
        break;
      }
    }
    for (int index = 0; index < this.DisplayPersonMale2.EquippedClothes.Count; ++index)
    {
      if (this.DisplayPersonMale2.EquippedClothes[index].BodyPart == DressableType.Beard)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.DisplayPersonMale2.EquippedClothes[index].gameObject);
        this.DisplayPersonMale2.EquippedClothes.RemoveAt(index);
        break;
      }
    }
  }

  public void OnChangeBeard()
  {
    this.RemoveCurrentBeard();
    switch (this.BeardList.value)
    {
      case 1:
        this.DisplayPersonMale.DressClothe(Main.Instance.Prefabs_Beards[0]);
        this.DisplayPersonMale.CurrentBeard.gameObject.layer = 16 /*0x10*/;
        this.DisplayPersonMale2.DressClothe(Main.Instance.Prefabs_Beards[0]);
        this.DisplayPersonMale2.CurrentBeard.gameObject.layer = 16 /*0x10*/;
        this.Click_UpdateHairColor();
        break;
      case 2:
        this.DisplayPersonMale.DressClothe(Main.Instance.Prefabs_Beards[1]);
        this.DisplayPersonMale.CurrentBeard.gameObject.layer = 16 /*0x10*/;
        this.DisplayPersonMale2.DressClothe(Main.Instance.Prefabs_Beards[1]);
        this.DisplayPersonMale2.CurrentBeard.gameObject.layer = 16 /*0x10*/;
        this.Click_UpdateHairColor();
        break;
      case 3:
        this.DisplayPersonMale.DressClothe(Main.Instance.Prefabs_Beards[2]);
        this.DisplayPersonMale.CurrentBeard.gameObject.layer = 16 /*0x10*/;
        this.DisplayPersonMale2.DressClothe(Main.Instance.Prefabs_Beards[2]);
        this.DisplayPersonMale2.CurrentBeard.gameObject.layer = 16 /*0x10*/;
        this.Click_UpdateHairColor();
        break;
      case 4:
        this.DisplayPersonMale.DressClothe(Main.Instance.Prefabs_Beards[3]);
        this.DisplayPersonMale.CurrentBeard.gameObject.layer = 16 /*0x10*/;
        this.DisplayPersonMale2.DressClothe(Main.Instance.Prefabs_Beards[3]);
        this.DisplayPersonMale2.CurrentBeard.gameObject.layer = 16 /*0x10*/;
        this.Click_UpdateHairColor();
        break;
    }
  }

  public void Click_ChangeGenderLoadFolder()
  {
    this.CurrentLoadFolderGirls = !this.CurrentLoadFolderGirls;
    this.Open_LoadCharacterList();
  }

  public void Click_LockMorfScales()
  {
    this.HipsSclX.minValue = 0.8f;
    this.HipsSclX.maxValue = 1.2f;
    this.HipsSclY.value = 1f;
    this.HipsSclY.interactable = false;
    this.HipsSclZ.minValue = 0.8f;
    this.HipsSclZ.maxValue = 1.2f;
    this.Hips2SclX.minValue = 0.8f;
    this.Hips2SclX.maxValue = 1.2f;
    this.Hips2SclY.minValue = 0.8f;
    this.Hips2SclY.maxValue = 1.2f;
    this.Hips2SclZ.minValue = 0.8f;
    this.Hips2SclZ.maxValue = 1.2f;
  }

  public void Click_UnlockMorfScales()
  {
    this.HipsSclX.minValue = 0.0f;
    this.HipsSclX.maxValue = 3f;
    this.HipsSclY.interactable = true;
    this.HipsSclZ.minValue = 0.0f;
    this.HipsSclZ.maxValue = 3f;
    this.Hips2SclX.minValue = 0.0f;
    this.Hips2SclX.maxValue = 3f;
    this.Hips2SclY.minValue = 0.0f;
    this.Hips2SclY.maxValue = 3f;
    this.Hips2SclZ.minValue = 0.0f;
    this.Hips2SclZ.maxValue = 3f;
  }

  public void Click_AltBody()
  {
    if (this.Female.isOn)
      return;
    if (this.AltBody.isOn)
    {
      this.DisplayPersonMale2.gameObject.SetActive(false);
      this.DisplayPersonMale.gameObject.SetActive(true);
    }
    else
    {
      this.DisplayPersonMale2.gameObject.SetActive(true);
      this.DisplayPersonMale.gameObject.SetActive(false);
    }
  }

  public void Click_PresetColor_Eyes(int value)
  {
    this.EyeRedColor.value = Main.Instance.NaturalEyeColors[value].r;
    this.EyeGreenColor.value = Main.Instance.NaturalEyeColors[value].g;
    this.EyeBlueColor.value = Main.Instance.NaturalEyeColors[value].b;
    this.Click_UpdateColors();
  }

  public void Click_PresetColor_Skin(int value)
  {
    this.SkinRedColor.value = Main.Instance.NaturalSkinColors[value].r;
    this.SkinGreenColor.value = Main.Instance.NaturalSkinColors[value].g;
    this.SkinBlueColor.value = Main.Instance.NaturalSkinColors[value].b;
    this.Click_UpdateColors();
  }

  public void Click_PresetColor_Hair(int value)
  {
    this.HairRedColor.value = Main.Instance.NaturalHairColors[value].r;
    this.HairGreenColor.value = Main.Instance.NaturalHairColors[value].g;
    this.HairBlueColor.value = Main.Instance.NaturalHairColors[value].b;
    this.Click_UpdateHairColor();
  }

  public void Click_AddFetish(int fetish)
  {
    if (this.FetishToggles[fetish].isOn)
    {
      if (this.DisplayPerson.Fetishes.Contains((e_Fetish) fetish))
        return;
      this.DisplayPerson.Fetishes.Add((e_Fetish) fetish);
    }
    else
      this.DisplayPerson.Fetishes.Remove((e_Fetish) fetish);
  }

  public void Click_AddFaceState(int value)
  {
    switch (value)
    {
      case 28:
        this.FaceStateToggles[30].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[30] = false;
        this.FaceStateToggles[31 /*0x1F*/].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[31 /*0x1F*/] = false;
        this.FaceStateToggles[29].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[29] = false;
        break;
      case 29:
        this.FaceStateToggles[28].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[28] = false;
        break;
      case 30:
        this.FaceStateToggles[28].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[28] = false;
        this.FaceStateToggles[31 /*0x1F*/].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[31 /*0x1F*/] = false;
        break;
      case 31 /*0x1F*/:
        this.FaceStateToggles[28].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[28] = false;
        this.FaceStateToggles[30].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[30] = false;
        break;
    }
    this.DisplayPerson.States[value] = this.FaceStateToggles[value].isOn;
    this.DisplayPerson.SetBodyTexture();
  }

  public void Click_AddBodyState(int value)
  {
    switch (value)
    {
      case 0:
        this.BodyStateToggles[2].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[2] = false;
        break;
      case 2:
        bool isOn = this.BodyStateToggles[2].isOn;
        this.BodyStateToggles[0].SetIsOnWithoutNotify(isOn);
        this.DisplayPerson.States[0] = isOn;
        break;
      case 17:
        this.BodyStateToggles[18].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[18] = false;
        this.BodyStateToggles[19].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[19] = false;
        break;
      case 18:
        this.BodyStateToggles[17].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[17] = false;
        this.BodyStateToggles[19].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[19] = false;
        break;
      case 19:
        this.BodyStateToggles[17].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[17] = false;
        this.BodyStateToggles[18].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[18] = false;
        break;
      case 20:
        this.BodyStateToggles[21].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[21] = false;
        break;
      case 21:
        this.BodyStateToggles[20].SetIsOnWithoutNotify(false);
        this.DisplayPerson.States[20] = false;
        break;
    }
    this.DisplayPerson.States[value] = this.BodyStateToggles[value].isOn;
    this.DisplayPerson.SetBodyTexture();
  }

  public void Click_CustomBodyTex(bool isOn, int index)
  {
    Debug.Log((object) ("index " + index.ToString()));
    Debug.Log((object) ("DisplayPerson._CustomSkinStates.Length " + this.DisplayPerson._CustomSkinStates.Length.ToString()));
    this.DisplayPerson._CustomSkinStates[index] = isOn;
    this.DisplayPerson.SetBodyTexture();
  }

  public void Click_CustomFaceTex(bool isOn, int index)
  {
    Debug.Log((object) ("index " + index.ToString()));
    Debug.Log((object) ("DisplayPerson._CustomFaceSkinStates.Length " + this.DisplayPerson._CustomFaceSkinStates.Length.ToString()));
    this.DisplayPerson._CustomFaceSkinStates[index] = isOn;
    this.DisplayPerson.SetBodyTexture();
  }

  public void Slide_HeightChange()
  {
    this.DisplayPerson.transform.localScale = new Vector3(this.HeightSlider.value, this.HeightSlider.value, this.HeightSlider.value);
    this.HeightText.text = $"Height ({(this.DisplayPerson.transform.localScale.y + 0.75f).ToString("##.##")}m / {UI_Gameplay.MetersToFeetAndInches(this.DisplayPerson.transform.localScale.y + 0.75f)})";
    this.DisplayPerson.Height = this.HeightSlider.value;
    if ((UnityEngine.Object) this.DisplayPersonMale != (UnityEngine.Object) null)
      this.DisplayPersonMale.Height = this.HeightSlider.value;
    if (!((UnityEngine.Object) this.DisplayPersonMale2 != (UnityEngine.Object) null))
      return;
    this.DisplayPersonMale2.Height = this.HeightSlider.value;
  }

  public void Slide_Pregnancy()
  {
    (this.DisplayPerson as Girl).PregnancyPercent = this.PregnancySlider.value;
  }

  public void Drop_Personality()
  {
    this.DisplayPerson.Personality = (Personality_Type) this.PersonalityDrop.value;
    this.DisplayPerson.A_Standing = this.PersonaIdles[this.PersonalityDrop.value];
    this.DisplayPerson.PersonalityData = Main.Instance.Personalities[(int) this.DisplayPerson.Personality];
    this.DisplayPerson.PersonalityData.OnSpawn(this.DisplayPerson);
  }

  public void Click_RandomName()
  {
    this.PlayerNameField.text = Main.Instance.GenerateRandomName();
    this.Input_NameChanged();
  }

  public void Input_NameChanged()
  {
    string str = this.PlayerNameField.text;
    if (str == null || str.Length == 0)
      str = "No Name";
    this.DisplayPerson.Name = str;
    this.PreviewNameLabel.text = str;
  }

  public void Open_HairColorOnly(Transform playerSpot)
  {
    this.DURINGGAMEPLAY = true;
    Main.Instance.OpenMenu("CustomizePlayer");
    for (int index = 0; index < this.ThingsToDisableOnGameplayCustomize.Length; ++index)
      this.ThingsToDisableOnGameplayCustomize[index].SetActive(false);
    for (int index = 0; index < this.ThingsToEnableOnGameplayHairColor.Length; ++index)
      this.ThingsToEnableOnGameplayHairColor[index].SetActive(true);
    Main.Instance.Player.UserControl.enabled = false;
    Main.Instance.Player.AddMoveBlocker("Customization");
    Main.Instance.Player.transform.SetPositionAndRotation(playerSpot.position, playerSpot.rotation);
    Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
    Main.Instance.GameplayMenu.AllowCursor();
    this.DisplayPerson = Main.Instance.Player;
    this.CustomMenuList.SetValueWithoutNotify(0);
  }

  public void Open_HairStyleOnly(Transform playerSpot)
  {
    this.DURINGGAMEPLAY = true;
    Main.Instance.OpenMenu("CustomizePlayer");
    for (int index = 0; index < this.ThingsToDisableOnGameplayCustomize.Length; ++index)
      this.ThingsToDisableOnGameplayCustomize[index].SetActive(false);
    for (int index = 0; index < this.ThingsToEnableOnGameplayHairStyle.Length; ++index)
      this.ThingsToEnableOnGameplayHairStyle[index].SetActive(true);
    Main.Instance.Player.UserControl.enabled = false;
    Main.Instance.Player.AddMoveBlocker("Customization");
    Main.Instance.Player.transform.SetPositionAndRotation(playerSpot.position, playerSpot.rotation);
    Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
    Main.Instance.GameplayMenu.AllowCursor();
    this.DisplayPerson = Main.Instance.Player;
    this.CustomMenuList.SetValueWithoutNotify(0);
  }

  public void Open_HairStyleBoth(Transform playerSpot)
  {
    Main.Instance.Player.UserControl.FirstPerson = false;
    this.DURINGGAMEPLAY = true;
    Main.Instance.OpenMenu("CustomizePlayer");
    for (int index = 0; index < this.ThingsToDisableOnGameplayCustomize.Length; ++index)
      this.ThingsToDisableOnGameplayCustomize[index].SetActive(false);
    for (int index = 0; index < this.ThingsToEnableOnGameplayHairColor.Length; ++index)
      this.ThingsToEnableOnGameplayHairColor[index].SetActive(true);
    for (int index = 0; index < this.ThingsToEnableOnGameplayHairStyle.Length; ++index)
      this.ThingsToEnableOnGameplayHairStyle[index].SetActive(true);
    Main.Instance.Player.UserControl.enabled = false;
    Main.Instance.Player.AddMoveBlocker("Customization");
    Main.Instance.Player.transform.SetPositionAndRotation(playerSpot.position, playerSpot.rotation);
    Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
    Main.Instance.GameplayMenu.AllowCursor();
    this.DisplayPerson = Main.Instance.Player;
    this.CustomMenuList.SetValueWithoutNotify(0);
  }

  public void Open_MakeupOnly(Transform playerSpot)
  {
    Main.Instance.Player.UserControl.FirstPerson = false;
    this.DURINGGAMEPLAY = true;
    Main.Instance.OpenMenu("CustomizePlayer");
    for (int index = 0; index < this.ThingsToDisableOnGameplayCustomize.Length; ++index)
      this.ThingsToDisableOnGameplayCustomize[index].SetActive(false);
    for (int index = 0; index < this.ThingsToEnableOnGameplayMakeup.Length; ++index)
      this.ThingsToEnableOnGameplayMakeup[index].SetActive(true);
    Main.Instance.Player.UserControl.enabled = false;
    Main.Instance.Player.AddMoveBlocker("Customization");
    Main.Instance.Player.transform.SetPositionAndRotation(playerSpot.position, playerSpot.rotation);
    Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
    Main.Instance.GameplayMenu.AllowCursor();
    this.DisplayPerson = Main.Instance.Player;
    this.CustomMenuList.SetValueWithoutNotify(5);
    for (int index = 0; index < this.StateTogglesToDisableInGameplay.Length; ++index)
      this.StateTogglesToDisableInGameplay[index].interactable = false;
  }

  public void OnClotheRecolor()
  {
    this.SelectedClothe.DyedColor = new Color(this.ClotheColorR.value, this.ClotheColorG.value, this.ClotheColorB.value);
    this.SelectedClothe.RefreshColors();
  }

  public void Open_RecolorOnly(Transform playerSpot, Dressable dress)
  {
    this.DURINGGAMEPLAY = true;
    Main.Instance.OpenMenu("CustomizePlayer");
    for (int index = 0; index < this.ThingsToDisableOnGameplayCustomize.Length; ++index)
      this.ThingsToDisableOnGameplayCustomize[index].SetActive(false);
    for (int index = 0; index < this.ThingsToEnableOnGameplayRecolor.Length; ++index)
      this.ThingsToEnableOnGameplayRecolor[index].SetActive(true);
    Main.Instance.Player.UserControl.enabled = false;
    Main.Instance.Player.AddMoveBlocker("Customization");
    Main.Instance.Player.transform.SetPositionAndRotation(playerSpot.position, playerSpot.rotation);
    Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
    Main.Instance.GameplayMenu.AllowCursor();
    this.SelectedClothe = dress;
    this.ClotheColorR.SetValueWithoutNotify(this.SelectedClothe.DyedColor.r);
    this.ClotheColorR.SetValueWithoutNotify(this.SelectedClothe.DyedColor.g);
    this.ClotheColorR.SetValueWithoutNotify(this.SelectedClothe.DyedColor.b);
  }

  public void Click_ClothePresetColor(int index)
  {
  }

  public void TakePresetSave(bool face)
  {
    this.InPresets = true;
    this.PresetsFace = face;
    this.MainCustomMenu.SetActive(false);
    this.PictureFrame.SetActive(true);
    this.DisableInPresets.SetActive(false);
    this.DisplayPerson.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.SaveTorsoCam.SetActive(!face);
    this.SaveFaceCam.SetActive(face);
    this.DisplayPerson.LookAtPlayer.playerTransform = !this.SaveTorsoCam.activeSelf ? this.SaveFaceCam.transform : this.SaveTorsoCam.transform;
    SexPose_Miss.AdjustCharacterPosition(this.SaveTorsoCam.transform, this.SaveTorsoCam_Position_preset, this.SaveTorsoCam.transform);
    SexPose_Miss.AdjustCharacterPosition(this.SaveFaceCam.transform, this.SaveFaceCam_Position_preset, this.SaveFaceCam.transform);
    this.HideDisplayClothes();
    if (!((UnityEngine.Object) this.DisplayPerson.CurrentHair != (UnityEngine.Object) null))
      return;
    this.DisplayPerson.CurrentHair.gameObject.SetActive(false);
  }

  public void Click_SavePresetFace() => this.TakePresetSave(true);

  public void Click_SavePresetBody() => this.TakePresetSave(false);

  public void LoadCharacter_Preset(string filename)
  {
    this.PresetLoaderNPC_F.StartingClothes.Clear();
    this.PresetLoaderNPC_F._StartingClothes.Clear();
    this.PresetLoaderNPC_F._States = new bool[0];
    this.PresetLoaderNPC_F._SkinStates = new bool[0];
    this.PresetLoaderNPC_F._FaceSkinStates = new bool[0];
    this.PresetLoaderNPC_F._DontLoadClothing = true;
    this.PresetLoaderNPC_F.LoadFromFile(filename);
    this.PresetLoaderNPC_F.Inited = false;
    this.PresetLoaderNPC_F.Init();
    if ((UnityEngine.Object) this.PresetLoaderNPC_F.CurrentHair != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.PresetLoaderNPC_F.CurrentHair.gameObject);
    if (this.PresetsFace)
    {
      for (int index = 0; index < this.PresetLoaderNPC_F.AllFaceBones.Length; ++index)
      {
        this.DisplayPerson.AllFaceBones[index].localPosition = this.PresetLoaderNPC_F.AllFaceBones[index].localPosition;
        this.DisplayPerson.AllFaceBones[index].localEulerAngles = this.PresetLoaderNPC_F.AllFaceBones[index].localEulerAngles;
        this.DisplayPerson.AllFaceBones[index].localScale = this.PresetLoaderNPC_F.AllFaceBones[index].localScale;
      }
    }
    else
    {
      for (int index = 0; index < this.PresetLoaderNPC_F.AllBodyBones.Length; ++index)
      {
        this.DisplayPerson.AllBodyBones[index].localPosition = this.PresetLoaderNPC_F.AllBodyBones[index].localPosition;
        this.DisplayPerson.AllBodyBones[index].localEulerAngles = this.PresetLoaderNPC_F.AllBodyBones[index].localEulerAngles;
        this.DisplayPerson.AllBodyBones[index].localScale = this.PresetLoaderNPC_F.AllBodyBones[index].localScale;
      }
    }
  }

  public void LoadPresetopen(bool face)
  {
    this.HideDisplayClothes();
    this.CustomMenuList.value = 0;
    this.ChangeCustomMenu();
    this.CLoseSaveMenus();
    this.InPresets = true;
    this.PresetsFace = face;
    this.MainCustomMenu.SetActive(false);
    this.LoadCharcterListMenu.SetActive(true);
    this.Open_LoadCharacterList();
  }

  public void Click_LoadPresetFace() => this.LoadPresetopen(true);

  public void Click_LoadPresetBody() => this.LoadPresetopen(false);
}
