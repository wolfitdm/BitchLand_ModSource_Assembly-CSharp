// Decompiled with JetBrains decompiler
// Type: bl_CityCharacters
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_CityCharacters : MonoBehaviour
{
  public job_Clinic Clinic;
  public Mis_Hadley HadleyMission;
  public Mis_Xoxa XoxaMis;
  [Space]
  public Vector3 WarPos;
  public Vector3 ZeaPos;
  [Space]
  public Person Dad;
  public Person War;
  public Person Sia;
  public Person Merussy;
  public Person Maylenne;
  public Person Ely;
  public Person Zea;
  public Person Sadie;
  public Person Jeanne;
  public Person Rit;
  public Person Sarah;
  public Person Carol;
  public Person Zala;
  public Person Aya;
  public Person Gabi;
  public Person Shin;
  public Person Hadley;
  public Person Beth;
  public Person Xoxa;
  public Person Ana;
  public Person Lai;

  public void SetPerson(Person person)
  {
    string name = person.Name;
    // ISSUE: reference to a compiler-generated method
    switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(name))
    {
      case 21306588:
        if (!(name == "Hadley"))
          return;
        this.Hadley = person;
        this.Hadley.States[19] = true;
        this.Hadley.States[20] = true;
        this.Hadley.States[0] = false;
        this.Hadley.States[2] = false;
        this.Hadley.SetBodyTexture();
        this.Hadley.PlayerKnowsName = true;
        this.Hadley.ThisPersonInt.SetDefaultInteraction();
        this.Hadley.Favor = 100;
        this.Hadley.VoicePitch = 1f;
        this.Hadley.Fertility = 0.9f;
        this.Hadley.Energy = 100f;
        this.Hadley.NoEnergyLoss = true;
        this.HadleyMission.InitHadley();
        Main.Instance.GameplayMenu.MapTrackers[3] = this.Hadley.transform;
        return;
      case 224488892:
        if (!(name == "Beth"))
          return;
        this.Beth = person;
        int_Vent objectOfType = Object.FindObjectOfType<int_Vent>(true);
        objectOfType.Beth = this.Beth;
        this.Beth.ThisPersonInt.StartTalkMono = (MonoBehaviour) objectOfType;
        this.Beth.ThisPersonInt.StartTalkFunc = "BethTalk";
        Object.FindObjectOfType<bethtraker>().GetComponent<int_basicSit>().Interact(this.Beth);
        return;
      case 255748530:
        if (!(name == "Carol"))
          return;
        this.Carol = person;
        this.Carol.Fertility = 2f;
        this.Carol.Energy = 100f;
        this.Carol.NoEnergyLoss = true;
        (this.Carol as Girl).PhisicsOnlyOnInSex = true;
        (this.Carol as Girl).GirlPhysics = false;
        Main.Instance.GameplayMenu.MapTrackers[2] = this.Carol.transform;
        return;
      case 387322843:
        if (!(name == "Zea"))
          return;
        this.Zea = person;
        this.Zea.Favor = 100000;
        this.Zea.CantBeHit = true;
        this.Zea.PlayerKnowsName = true;
        this.Zea.ThisPersonInt.SetDefaultInteraction();
        this.Zea.Fertility = 0.0f;
        this.Zea.StoryModeFertility = 1f;
        this.Zea.Energy = 100f;
        this.Zea.NoEnergyLoss = true;
        this.Zea.States[17] = false;
        this.Zea.States[18] = false;
        this.Zea.States[19] = false;
        this.Zea.States[0] = false;
        this.Zea.States[2] = false;
        this.Zea.States[12] = false;
        this.Zea.States[13] = false;
        this.Zea.States[14] = false;
        this.Zea.States[15] = false;
        this.Zea.States[16 /*0x10*/] = false;
        this.Zea.States[21] = false;
        this.Zea._DirtySkin = false;
        this.Zea.SetBodyTexture();
        this.Zea.WeaponInv.PickupWeapon(Object.Instantiate<GameObject>(Main.Instance.Prefabs_Weapons[0].gameObject));
        this.Zea.WeaponInv.startingWeaponIndex = 1;
        this.ZeaPos = this.Zea.transform.position;
        this.Zea.gameObject.SetActive(false);
        return;
      case 819845779:
        if (!(name == "Xoxa"))
          return;
        this.Xoxa = person;
        this.Xoxa.ChangeUniform(this.XoxaMis.XoxaClothes);
        this.Xoxa.States[17] = false;
        this.Xoxa.States[18] = false;
        this.Xoxa.States[19] = false;
        this.Xoxa.States[0] = false;
        this.Xoxa.States[2] = false;
        this.Xoxa.States[12] = false;
        this.Xoxa.States[13] = false;
        this.Xoxa.States[14] = false;
        this.Xoxa.States[15] = false;
        this.Xoxa.States[16 /*0x10*/] = false;
        this.Xoxa.States[21] = false;
        this.Xoxa._DirtySkin = false;
        this.Xoxa.SetBodyTexture();
        this.Xoxa.Home = this.XoxaMis.XoxaZone;
        this.Xoxa.CurrentZone = this.XoxaMis.XoxaZone;
        this.Xoxa.ThisPersonInt.StartTalkFunc = "Chat_Xoxa";
        this.Xoxa.ThisPersonInt.StartTalkMono = (MonoBehaviour) this.XoxaMis;
        this.Xoxa.VoicePitch = 1.06f;
        this.Xoxa.Fertility = 1.5f;
        if (!((Object) this.Xoxa.CurrentHair == (Object) null))
          return;
        for (int index = 0; index < Main.Instance.Prefabs_Hair.Count; ++index)
        {
          if ((Object) Main.Instance.Prefabs_Hair[index] != (Object) null && Main.Instance.Prefabs_Hair[index].name == "p2.Hair07")
          {
            this.Xoxa.DressClothe(Main.Instance.Prefabs_Hair[index]);
            break;
          }
        }
        return;
      case 867974480:
        if (!(name == "Sia"))
          return;
        this.Sia = person;
        this.Sia.Fertility = 1f;
        this.Sia.CantBeHit = true;
        (this.Sia as Girl).PhisicsOnlyOnInSex = true;
        (this.Sia as Girl).GirlPhysics = false;
        this.Sia.Favor = 10000;
        this.Sia.VoicePitch = 1.05f;
        this.Sia.Energy = 100f;
        this.Sia.NoEnergyLoss = true;
        if (!((Object) this.Sia.WeaponInv.CurrentWeapon != (Object) null))
          return;
        this.Sia.WeaponInv.CurrentWeapon.Holdster();
        return;
      case 1210402596:
        if (!(name == "Maylenne"))
          return;
        this.Maylenne = person;
        this.Clinic.SetDoctor(this.Maylenne);
        this.Maylenne.States[0] = false;
        this.Maylenne.States[2] = false;
        this.Maylenne._DirtySkin = false;
        this.Maylenne.SetBodyTexture();
        this.Maylenne.HasCondomPut = true;
        this.Maylenne.Energy = 100f;
        this.Maylenne.NoEnergyLoss = true;
        return;
      case 1991636261:
        if (!(name == "Ana"))
          return;
        this.Ana = person;
        this.Ana.CantBeHit = true;
        this.Ana.Energy = 100f;
        this.Ana.NoEnergyLoss = true;
        return;
      case 2036296499:
        if (!(name == "Sephie"))
          return;
        break;
      case 2054090277:
        if (!(name == "War"))
          return;
        this.War = person;
        this.War.Fertility = 0.0f;
        this.War.StoryModeFertility = 1f;
        this.War.Favor = 10000;
        this.War.CantBeHit = true;
        (this.War as Girl).PhisicsOnlyOnInSex = true;
        (this.War as Girl).GirlPhysics = false;
        (this.War as Girl).NoBoobPhysicsOnThisOne = true;
        this.War.DyedHairColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        this.War.Energy = 100f;
        this.War.NoEnergyLoss = true;
        this.War.RefreshColors();
        this.WarPos = this.War.transform.position;
        Main.Instance.GameplayMenu.MapTrackers[0] = this.War.transform;
        return;
      case 2206650621:
        if (!(name == "Sadie"))
          return;
        this.Sadie = person;
        this.Sadie.Favor = 0;
        this.Sadie.VoicePitch = 1.1f;
        this.Sadie.DyedHairColor = new Color(0.9215686f, 0.7176471f, 0.8196079f);
        this.Sadie.RefreshColors();
        this.Sadie.Energy = 100f;
        this.Sadie.NoEnergyLoss = true;
        this.Sadie.PlayerKnowsName = true;
        this.Sadie.ThisPersonInt.SetDefaultInteraction();
        this.Sadie.TheHealth.AlwaysDie = true;
        Object.FindObjectOfType<Mis_Zea2_refs>().SadieSpawn(this.Sadie);
        return;
      case 2512061727:
        if (!(name == "Merussy"))
          return;
        break;
      case 3219858101:
        if (!(name == "Lai"))
          return;
        this.Lai = person;
        this.Lai.States[17] = false;
        this.Lai.States[18] = false;
        this.Lai.States[19] = false;
        this.Lai.States[0] = false;
        this.Lai.States[2] = false;
        this.Lai.States[12] = false;
        this.Lai.States[13] = false;
        this.Lai.States[14] = false;
        this.Lai.States[15] = false;
        this.Lai.States[16 /*0x10*/] = false;
        this.Lai.States[21] = false;
        this.Lai._DirtySkin = false;
        this.Lai.SetBodyTexture();
        return;
      case 3633252167:
        if (!(name == "Ely"))
          return;
        this.Ely = person;
        this.Ely.Fertility = 0.0f;
        this.Ely.StoryModeFertility = 1f;
        this.Ely.CantBeHit = true;
        (this.Ely as Girl).PhisicsOnlyOnInSex = true;
        (this.Ely as Girl).GirlPhysics = false;
        this.Ely.Favor = 10000;
        this.Ely.Energy = 100f;
        this.Ely.NoEnergyLoss = true;
        this.Ely.VoicePitch = 0.96f;
        return;
      case 3919353448:
        if (!(name == "Sarah"))
          return;
        this.Sarah = person;
        this.Sarah.Fertility = 0.0f;
        this.Sarah.StoryModeFertility = 5f;
        this.Sarah.Favor = 10000;
        this.Sarah.FootStepsAudio.gameObject.SetActive(false);
        this.Sarah.CantBeHit = true;
        this.Sarah.Energy = 100f;
        this.Sarah.NoEnergyLoss = true;
        return;
      default:
        return;
    }
    this.Merussy = person;
    this.Merussy.Fertility = 0.0f;
    this.Merussy.StoryModeFertility = 1f;
    this.Merussy.Favor = 10000;
    this.Merussy.CantBeHit = true;
    this.Merussy.VoicePitch = 0.98f;
    this.Merussy.Energy = 100f;
    this.Merussy.NoEnergyLoss = true;
  }
}
