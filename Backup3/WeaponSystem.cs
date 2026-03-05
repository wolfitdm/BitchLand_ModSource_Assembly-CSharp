// Decompiled with JetBrains decompiler
// Type: WeaponSystem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class WeaponSystem : MonoBehaviour
{
  public List<GameObject> weapons = new List<GameObject>();
  public int startingWeaponIndex;
  public int weaponIndex;
  public GameObject Blood;
  public Text PickupText;
  public Image PromptIcon;
  public LayerMask PromptLayers;
  public float _RayDistance = 2f;
  public Person ThisPerson;
  public Weapon _CurrentWeapon;
  public bool isPlayer;
  public Interactible IntLookingAt;
  public Vector3 RaycastPoint;

  public float RayDistance
  {
    get
    {
      return this.ThisPerson.UserControl.MeleeOption == bl_ThirdPersonUserControl.MeleeOptions.None ? this._RayDistance : 0.0f;
    }
    set => this._RayDistance = value;
  }

  public Weapon CurrentWeapon
  {
    get => this._CurrentWeapon;
    set
    {
      this._CurrentWeapon = value;
      if (!this.isPlayer)
        return;
      this.ThisPerson.UserControl.MeleeOption = bl_ThirdPersonUserControl.MeleeOptions.None;
      if ((Object) value != (Object) null)
      {
        switch (this._CurrentWeapon.HoldingType)
        {
          case WeaponHoldingType.Pistol:
            this.ThisPerson.Anim.SetInteger("Weapon", 1);
            break;
          case WeaponHoldingType.Rifle:
            this.ThisPerson.Anim.SetInteger("Weapon", 2);
            break;
          case WeaponHoldingType.Launcher:
            this.ThisPerson.Anim.SetInteger("Weapon", 5);
            break;
          case WeaponHoldingType.Knife:
            this.ThisPerson.Anim.SetInteger("Weapon", 6);
            Main.Instance.Player.UserControl.MeleeWeaponOption = Main.Instance.Player.UserControl.MeleeWeaponOption;
            break;
          case WeaponHoldingType.Sword:
            this.ThisPerson.Anim.SetInteger("Weapon", 7);
            Main.Instance.Player.UserControl.MeleeWeaponOption = Main.Instance.Player.UserControl.MeleeWeaponOption;
            break;
          case WeaponHoldingType.Blunt:
            this.ThisPerson.Anim.SetInteger("Weapon", 3);
            Main.Instance.Player.UserControl.MeleeWeaponOption = Main.Instance.Player.UserControl.MeleeWeaponOption;
            break;
          case WeaponHoldingType.Spear:
            this.ThisPerson.Anim.SetInteger("Weapon", 8);
            Main.Instance.Player.UserControl.MeleeWeaponOption = Main.Instance.Player.UserControl.MeleeWeaponOption;
            break;
          case WeaponHoldingType.PickAxe:
            this.ThisPerson.Anim.SetInteger("Weapon", 4);
            Main.Instance.Player.UserControl.MeleeWeaponOption = Main.Instance.Player.UserControl.MeleeWeaponOption;
            break;
        }
      }
      else
        this.ThisPerson.Anim.SetInteger("Weapon", 0);
      Main.Instance.GameplayMenu.UpdateAmmo();
    }
  }

  private void Start()
  {
    this.weaponIndex = this.startingWeaponIndex;
    this.SetActiveWeapon(this.weaponIndex);
  }

  private void Update()
  {
    if (!this.isPlayer || this.ThisPerson.Interacting || !this.ThisPerson.CanMove)
      return;
    if (Input.GetKeyUp(KeyCode.Alpha1))
      this.SetActiveWeapon(0);
    if (Input.GetKeyUp(KeyCode.Alpha2) && this.weapons.Count > 1)
      this.SetActiveWeapon(1);
    if (Input.GetKeyUp(KeyCode.Alpha3) && this.weapons.Count > 2)
      this.SetActiveWeapon(2);
    if (Input.GetButtonUp("Drop"))
    {
      this.DropWeapon(this.weaponIndex);
    }
    else
    {
      RaycastHit hitInfo;
      if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out hitInfo, this.RayDistance, (int) this.PromptLayers))
      {
        int_Dragable component1 = hitInfo.transform.GetComponent<int_Dragable>();
        if ((Object) component1 != (Object) null && component1.CanInteract && Input.GetKeyDown(KeyCode.Z))
        {
          component1.Interact(Main.Instance.Player);
          return;
        }
        Weapon component2 = hitInfo.transform.root.GetComponent<Weapon>();
        if ((Object) component2 == (Object) null)
          component2 = hitInfo.transform.GetComponent<Weapon>();
        if ((Object) component2 != (Object) null)
        {
          Main.Instance.GameplayMenu.Crossair.SetActive(true);
          Main.Instance.GameplayMenu.PickupText.text = "Pickup " + component2.transform.name;
          Main.Instance.GameplayMenu.PromptIcon.sprite = Main.Instance.PromptIcons[0];
          Main.Instance.GameplayMenu.PromptIcon.enabled = false;
          if (Input.GetButtonUp("Interact") || Input.GetMouseButtonUp(UI_Settings.RightMouseButton))
          {
            Main.Instance.GameplayMenu.Crossair.SetActive(false);
            this.PickupWeapon(component2.gameObject);
            Main.Instance.GameplayMenu.PickupText.text = string.Empty;
            Main.Instance.GameplayMenu.PromptIcon.sprite = Main.Instance.PromptIcons[0];
            Main.Instance.GameplayMenu.PromptIcon.enabled = false;
          }
          if (!Input.GetKeyDown(KeyCode.Z))
            return;
          component2.int_Drag.Interact(Main.Instance.Player);
          return;
        }
        InteractRedirect component3 = hitInfo.transform.GetComponent<InteractRedirect>();
        if ((Object) component3 != (Object) null && !component3.Disabled && (component3.Redirect.FullCheckCanInteract(Main.Instance.Player) || Main.Instance.PeopleFollowingPlayer.Count > 0 && (Object) component3.Redirect.InteractingPerson == (Object) Main.Instance.PeopleFollowingPlayer[0]))
        {
          this.ShowPromptFor(component3.Redirect);
          return;
        }
        Interactible[] components1 = hitInfo.transform.GetComponents<Interactible>();
        for (int index = 0; index < components1.Length; ++index)
        {
          if ((Object) components1[index] != (Object) null && (components1[index].FullCheckCanInteract(Main.Instance.Player) || Main.Instance.PeopleFollowingPlayer.Count > 0 && (Object) components1[index].InteractingPerson == (Object) Main.Instance.PeopleFollowingPlayer[0]))
          {
            this.ShowPromptFor(components1[index]);
            return;
          }
        }
        Interactible[] components2 = hitInfo.transform.root.GetComponents<Interactible>();
        for (int index = 0; index < components2.Length; ++index)
        {
          if ((Object) components2[index] != (Object) null && (components2[index].FullCheckCanInteract(Main.Instance.Player) || Main.Instance.PeopleFollowingPlayer.Count > 0 && (Object) components2[index].InteractingPerson == (Object) Main.Instance.PeopleFollowingPlayer[0]))
          {
            this.ShowPromptFor(components2[index]);
            return;
          }
        }
      }
      this.IntLookingAt = (Interactible) null;
      Main.Instance.GameplayMenu.Crossair.SetActive(false);
      Main.Instance.GameplayMenu.PickupText.text = string.Empty;
      Main.Instance.GameplayMenu.PromptIcon.sprite = Main.Instance.PromptIcons[0];
      Main.Instance.GameplayMenu.PromptIcon.enabled = false;
      Main.Instance.GameplayMenu.NewMultiOption.SetActive(false);
    }
  }

  public void ShowPromptFor(Interactible interactible)
  {
    this.IntLookingAt = interactible;
    Main.Instance.GameplayMenu.Crossair.SetActive(true);
    Main.Instance.GameplayMenu.NewMultiOption.SetActive(false);
    if (interactible is bl_MinableObject)
    {
      bl_MinableObject blMinableObject = (bl_MinableObject) interactible;
      if (blMinableObject.AlwaysShowPrompt || blMinableObject.CheckCanInteract(Main.Instance.Player))
        interactible.InteractText = blMinableObject.PromptWhenAvailable;
      else if (!blMinableObject.AlwaysShowPrompt)
      {
        interactible.InteractText = string.Empty;
        goto label_6;
      }
      else
        goto label_6;
    }
    Main.Instance.GameplayMenu.PickupText.text = interactible.InteractText;
    Main.Instance.GameplayMenu.PromptIcon.sprite = Main.Instance.PromptIcons[interactible.InteractIcon];
    Main.Instance.GameplayMenu.PromptIcon.enabled = interactible.InteractIcon != 0;
label_6:
    if (interactible is MultiInteractible)
    {
      MultiInteractible multiInteractible = (MultiInteractible) interactible;
      if (multiInteractible.NewMulti)
      {
        if (multiInteractible.RelayInteractText)
        {
          for (int index = 0; index < multiInteractible.Parts.Length; ++index)
          {
            if ((Object) multiInteractible.Parts[index] != (Object) null && multiInteractible.Parts[index].CheckCanInteract(Main.Instance.Player))
            {
              Main.Instance.GameplayMenu.PickupText.text = multiInteractible.Parts[index].InteractText;
              break;
            }
          }
        }
        Interactible interactible1 = (Interactible) null;
        for (int index = 1; index < multiInteractible.Parts.Length; ++index)
        {
          if ((Object) multiInteractible.Parts[index] != (Object) null && multiInteractible.Parts[index].CheckCanInteract(Main.Instance.Player))
          {
            interactible1 = multiInteractible.Parts[index];
            break;
          }
        }
        if ((Object) interactible1 != (Object) null)
        {
          Main.Instance.GameplayMenu.NewMultiOption.SetActive(true);
          Main.Instance.GameplayMenu.NewMultiOption_text.text = !multiInteractible.RelayExtraInteractText ? "More options" : interactible1.InteractText;
          if (Input.GetKeyUp(KeyCode.F))
          {
            Main.Instance.GameplayMenu.Crossair.SetActive(false);
            Main.Instance.GameplayMenu.PickupText.text = string.Empty;
            Main.Instance.GameplayMenu.PromptIcon.sprite = Main.Instance.PromptIcons[0];
            Main.Instance.GameplayMenu.PromptIcon.enabled = false;
            Main.Instance.GameplayMenu.NewMultiOption.SetActive(false);
            interactible1.Interact(this.ThisPerson);
          }
        }
      }
      else if (Main.Instance.PeopleFollowingPlayer.Count > 0 && multiInteractible.Parts[0].NPCCanUseInFollow)
      {
        if ((Object) Main.Instance.PeopleFollowingPlayer[0].InteractingWith != (Object) null)
        {
          Main.Instance.GameplayMenu.NewMultiOption.SetActive(true);
          Main.Instance.GameplayMenu.NewMultiOption_text.text = "Ask to stop using";
          if (Input.GetKeyUp(KeyCode.F))
          {
            Main.Instance.GameplayMenu.Crossair.SetActive(false);
            Main.Instance.GameplayMenu.PickupText.text = string.Empty;
            Main.Instance.GameplayMenu.PromptIcon.sprite = Main.Instance.PromptIcons[0];
            Main.Instance.GameplayMenu.PromptIcon.enabled = false;
            Main.Instance.GameplayMenu.NewMultiOption.SetActive(false);
            Interactible interactingWith = Main.Instance.PeopleFollowingPlayer[0].InteractingWith;
            interactingWith.InteractingPerson = Main.Instance.PeopleFollowingPlayer[0];
            interactingWith.StopInteracting();
            interactingWith.InteractingPerson = (Person) null;
            Main.Instance.PeopleFollowingPlayer[0].InteractingWith = (Interactible) null;
          }
        }
        else
        {
          Main.Instance.GameplayMenu.NewMultiOption.SetActive(true);
          Main.Instance.GameplayMenu.NewMultiOption_text.text = "Ask " + Main.Instance.PeopleFollowingPlayer[0].Name + " to use";
          if (Input.GetKeyUp(KeyCode.F))
          {
            Main.Instance.GameplayMenu.Crossair.SetActive(false);
            Main.Instance.GameplayMenu.PickupText.text = string.Empty;
            Main.Instance.GameplayMenu.PromptIcon.sprite = Main.Instance.PromptIcons[0];
            Main.Instance.GameplayMenu.PromptIcon.enabled = false;
            Main.Instance.GameplayMenu.NewMultiOption.SetActive(false);
            multiInteractible.Parts[0].Interact(Main.Instance.PeopleFollowingPlayer[0]);
          }
        }
      }
    }
    else if (Main.Instance.PeopleFollowingPlayer.Count > 0 && interactible.NPCCanUseInFollow)
    {
      if ((Object) Main.Instance.PeopleFollowingPlayer[0].InteractingWith != (Object) null)
      {
        Main.Instance.GameplayMenu.NewMultiOption.SetActive(true);
        Main.Instance.GameplayMenu.NewMultiOption_text.text = "Ask to stop using";
        if (Input.GetKeyUp(KeyCode.F))
        {
          Main.Instance.GameplayMenu.Crossair.SetActive(false);
          Main.Instance.GameplayMenu.PickupText.text = string.Empty;
          Main.Instance.GameplayMenu.PromptIcon.sprite = Main.Instance.PromptIcons[0];
          Main.Instance.GameplayMenu.PromptIcon.enabled = false;
          Main.Instance.GameplayMenu.NewMultiOption.SetActive(false);
          Interactible interactingWith = Main.Instance.PeopleFollowingPlayer[0].InteractingWith;
          interactingWith.InteractingPerson = Main.Instance.PeopleFollowingPlayer[0];
          interactingWith.StopInteracting();
          interactingWith.InteractingPerson = (Person) null;
          Main.Instance.PeopleFollowingPlayer[0].InteractingWith = (Interactible) null;
        }
      }
      else
      {
        Main.Instance.GameplayMenu.NewMultiOption.SetActive(true);
        Main.Instance.GameplayMenu.NewMultiOption_text.text = "Ask " + Main.Instance.PeopleFollowingPlayer[0].Name + " to use";
        if (Input.GetKeyUp(KeyCode.F))
        {
          Main.Instance.GameplayMenu.Crossair.SetActive(false);
          Main.Instance.GameplayMenu.PickupText.text = string.Empty;
          Main.Instance.GameplayMenu.PromptIcon.sprite = Main.Instance.PromptIcons[0];
          Main.Instance.GameplayMenu.PromptIcon.enabled = false;
          Main.Instance.GameplayMenu.NewMultiOption.SetActive(false);
          Main.Instance.PeopleFollowingPlayer[0].InteractingWith = interactible;
          interactible.Interact(Main.Instance.PeopleFollowingPlayer[0]);
        }
      }
    }
    if (!Input.GetButtonUp("Interact") && !Input.GetMouseButtonUp(UI_Settings.RightMouseButton))
      return;
    Main.Instance.GameplayMenu.Crossair.SetActive(false);
    Main.Instance.GameplayMenu.PickupText.text = string.Empty;
    Main.Instance.GameplayMenu.PromptIcon.sprite = Main.Instance.PromptIcons[0];
    Main.Instance.GameplayMenu.PromptIcon.enabled = false;
    interactible.Interact(this.ThisPerson);
  }

  public void DestroyAllWeapons()
  {
  }

  public void DropAllWeapons()
  {
    for (int index = 0; index < this.weapons.Count; ++index)
      this.DropWeapon(index);
  }

  public void DropWeapon(int index)
  {
    if ((Object) this.weapons[index] == (Object) null)
      return;
    Transform transform = this.weapons[index].transform;
    Weapon component = transform.GetComponent<Weapon>();
    if ((Object) component != (Object) null && component.playerWeapon && !component.canDrop)
      return;
    transform.SetParent((Transform) null);
    component.SetInRelax();
    component.enabled = false;
    for (int index1 = 0; index1 < component.WeaponCollider.Length; ++index1)
      component.WeaponCollider[index1].enabled = true;
    component.WeaponRigid.isKinematic = false;
    if ((Object) component.WeaponAudioSource != (Object) null)
      component.WeaponAudioSource.enabled = false;
    component._WeaponSystem = (WeaponSystem) null;
    transform.position = component.ActualWeaponModel.position;
    component.ActualWeaponModel.SetParent(transform);
    for (int index2 = 0; index2 < component.IKs.Length; ++index2)
    {
      component.IKs[index2].enabled = false;
      component.IKs[index2].animator = (Animator) null;
    }
    component.ActualWeaponModel.localPosition = Vector3.zero;
    this.weapons[index].SetActive(true);
    this.weapons[index] = (GameObject) null;
    if ((Object) this.CurrentWeapon == (Object) component)
      this.CurrentWeapon = (Weapon) null;
    if (this.weaponIndex != index)
      return;
    if (this.isPlayer)
      this.ThisPerson.UserControl.MeleeOption = bl_ThirdPersonUserControl.MeleeOptions.None;
    this.SetActiveWeapon(index);
  }

  public void PickupWeapon(GameObject weapon)
  {
    if ((Object) this.CurrentWeapon == (Object) null)
    {
      this.weapons[this.weaponIndex] = weapon;
    }
    else
    {
      for (int index = 0; index < this.weapons.Count; ++index)
      {
        if ((Object) this.weapons[index] == (Object) null)
        {
          this.weapons[index] = weapon;
          goto label_8;
        }
      }
      this.DropWeapon(this.weaponIndex);
      this.weapons[this.weaponIndex] = weapon;
    }
label_8:
    Weapon component = weapon.GetComponent<Weapon>();
    if (!component._Started)
      component.Start();
    weapon.transform.SetParent(this.transform);
    component._WeaponSystem = this;
    component.OnPickup();
  }

  public void SetActiveWeapon(GameObject weapon)
  {
    for (int index = 0; index < this.weapons.Count; ++index)
    {
      if ((Object) this.weapons[index] == (Object) weapon)
      {
        this.SetActiveWeapon(index);
        break;
      }
    }
  }

  public void SetActiveWeapon(int index)
  {
    if (index >= this.weapons.Count || index < 0)
    {
      Debug.LogWarning((object) "Tried to switch to a weapon that does not exist.  Make sure you have all the correct weapons in your weapons array.");
    }
    else
    {
      this.SendMessageUpwards("OnEasyWeaponsSwitch", SendMessageOptions.DontRequireReceiver);
      if ((Object) this.CurrentWeapon != (Object) null)
        this.CurrentWeapon.SetInRelax();
      this.weaponIndex = index;
      for (int index1 = 1; index1 < this.weapons.Count; ++index1)
      {
        if ((Object) this.weapons[index1] != (Object) null)
          this.weapons[index1].SetActive(false);
      }
      switch (index)
      {
        case 0:
          if (this.weapons.Count >= 2 && (Object) this.weapons[1] != (Object) null)
            this.weapons[1].GetComponent<Weapon>().SetInHoldster1();
          if (this.weapons.Count >= 3 && (Object) this.weapons[2] != (Object) null)
          {
            this.weapons[2].GetComponent<Weapon>().SetInHoldster2();
            break;
          }
          break;
        case 1:
          if (this.weapons.Count >= 2 && (Object) this.weapons[0] != (Object) null)
            this.weapons[0].GetComponent<Weapon>().SetInHoldster1();
          if (this.weapons.Count >= 3 && (Object) this.weapons[2] != (Object) null)
          {
            this.weapons[2].GetComponent<Weapon>().SetInHoldster2();
            break;
          }
          break;
        case 2:
          if (this.weapons.Count >= 2 && (Object) this.weapons[0] != (Object) null)
            this.weapons[0].GetComponent<Weapon>().SetInHoldster1();
          if (this.weapons.Count >= 3 && (Object) this.weapons[1] != (Object) null)
          {
            this.weapons[1].GetComponent<Weapon>().SetInHoldster2();
            break;
          }
          break;
      }
      if ((Object) this.weapons[index] != (Object) null)
      {
        Weapon component = this.weapons[index].GetComponent<Weapon>();
        component.StopBeam();
        this.weapons[index].SetActive(true);
        this.CurrentWeapon = component;
        this.CurrentWeapon.WeaponInRelax = false;
        this.CurrentWeapon.SetInRelax();
        if (!this.CurrentWeapon.playerWeapon)
          return;
        int type = (int) this.CurrentWeapon.type;
      }
      else
        this.CurrentWeapon = (Weapon) null;
    }
  }

  public void NextWeapon()
  {
    ++this.weaponIndex;
    if (this.weaponIndex > this.weapons.Count - 1)
      this.weaponIndex = 0;
    this.SetActiveWeapon(this.weaponIndex);
  }

  public void PreviousWeapon()
  {
    --this.weaponIndex;
    if (this.weaponIndex < 0)
      this.weaponIndex = this.weapons.Count - 1;
    this.SetActiveWeapon(this.weaponIndex);
  }
}
