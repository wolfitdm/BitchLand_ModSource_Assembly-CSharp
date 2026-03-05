// Decompiled with JetBrains decompiler
// Type: Dressable
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Dressable : SaveableBehaviour
{
  public GenderType GenderFor;
  public DressableType BodyPart;
  public bool Skinned;
  public bool DefaultBones;
  public bool AttachBones;
  public bool DoubleSided;
  public Mesh HighLod;
  public Mesh LowLod;
  public bool IsCustomImported;
  public e_MatColorType[] MatTypes;
  public MeshFilter _ThisFilter;
  public Renderer _ThisRen;
  public bool InvItem;
  public int CasualPoints;
  public int SexyPoints;
  public bool NonRemovableOnThrowdown;
  public bool Restrains;
  public bool BlindFolds;
  public bool HidesHair;
  public bool Ugly;
  public bool Good;
  public float RandChance;
  public e_BlendShapes ShapeWhenEquipped;
  [Tooltip("Full Path !")]
  public string AttatchBone;
  [Tooltip("Full Path !")]
  public string MaleAttatchBone;
  public Vector3 AttatchPos;
  public Vector3 AttatchRot;
  public Vector3 AttatchScl = Vector3.one;
  public Vector3 Male_AttatchPos;
  public Vector3 Male_AttatchRot;
  public Vector3 Male_AttatchScl = Vector3.one;
  public Axis ReverseAxis;
  public bool _Equipped;
  public Person PersonEquipped;
  public GameObject OriginalPrefab;
  public GameObject DropablePrefab;
  public Collider[] OnDrop_Col;
  public Rigidbody[] OnDrop_Rig;
  public bool CantBeDroppedByPlayer;
  public bool HideFromInv;
  public bool HidesFeet;
  public bool DisplayDuringSex;
  public int[] PlacedBones;
  public Vector3[] PlacedBonesPos;
  public Vector3[] PlacedBonesRot;
  public Vector3[] PlacedBonesScl;
  public Person.BodyMaleMaterials HidesMaleParts;
  public Transform[] BoneStorage;
  public float IncreasedHeight;
  public Color NaturalColor;
  public Color DyedColor;
  public bool BeingUndressed;
  public SexPose_IKSetting[] UsingIKs;

  public Renderer ThisRen
  {
    get
    {
      if ((Object) this._ThisRen == (Object) null)
        this._ThisRen = this.GetComponent<Renderer>();
      return this._ThisRen;
    }
    set
    {
      if ((Object) this._ThisRen == (Object) null)
        this._ThisRen = this.GetComponent<Renderer>();
      this._ThisRen = value;
    }
  }

  public override void Start()
  {
    base.Start();
    this.RefreshColors();
  }

  public virtual bool Equipped
  {
    get => this._Equipped;
    set
    {
      this._Equipped = value;
      if (this._Equipped)
      {
        if (this.CanSaveFlagger.Contains(nameof (Equipped)))
          return;
        this.CanSaveFlagger.Add(nameof (Equipped));
      }
      else
        this.CanSaveFlagger.Remove(nameof (Equipped));
    }
  }

  public void RefreshColors()
  {
    Color white = Color.white;
    Color color;
    if (this.DyedColor != new Color(0.0f, 0.0f, 0.0f, 0.0f))
    {
      color = this.DyedColor;
    }
    else
    {
      if (!(this.NaturalColor != new Color(0.0f, 0.0f, 0.0f, 0.0f)))
        return;
      color = this.NaturalColor;
    }
    if (this.MatTypes != null && this.MatTypes.Length != 0)
    {
      for (int index = 0; index < this.ThisRen.materials.Length; ++index)
      {
        switch (this.MatTypes[index])
        {
          case e_MatColorType.Colorable:
            this.ThisRen.materials[index].color = color;
            break;
          case e_MatColorType.SkinColor:
            this.ThisRen.materials[index].color = this.PersonEquipped.TannedSkinColor == new Color(0.0f, 0.0f, 0.0f, 0.0f) ? this.PersonEquipped.NaturalSkinColor : this.PersonEquipped.TannedSkinColor;
            break;
        }
      }
    }
    else
    {
      for (int index = 0; index < this.ThisRen.materials.Length; ++index)
        this.ThisRen.materials[index].color = color;
    }
  }

  public virtual void OnDressed()
  {
    this.BeingUndressed = false;
    this.RefreshShapeWhileEquipped();
    if (this.PersonEquipped.IsPlayer && (double) this.IncreasedHeight != 0.0)
    {
      this.PersonEquipped.UserControl.m_Character.UsingStandingHeight = new Vector3(0.0f, this.IncreasedHeight, 0.0f);
      this.PersonEquipped.UserControl.m_Character.StandState = this.PersonEquipped.UserControl.m_Character.StandState;
    }
    this.RefreshColors();
    this.SetIKs();
  }

  public virtual void OnUndressed()
  {
    this.BeingUndressed = true;
    if ((Object) this.PersonEquipped == (Object) null)
      return;
    if (this.PersonEquipped.IsPlayer && (double) this.IncreasedHeight != 0.0)
    {
      this.PersonEquipped.UserControl.m_Character.UsingStandingHeight = this.PersonEquipped.UserControl.m_Character.DefaultStandingHeight;
      this.PersonEquipped.UserControl.m_Character.StandState = this.PersonEquipped.UserControl.m_Character.StandState;
    }
    this.UnsetIKs();
  }

  public virtual void SetLowLod()
  {
    if ((Object) this.LowLod != (Object) null && (Object) this._ThisFilter != (Object) null)
      this._ThisFilter.mesh = this.LowLod;
    if (!this.DoubleSided)
      return;
    for (int index = 0; index < this.ThisRen.materials.Length; ++index)
    {
      try
      {
        this.ThisRen.materials[index].shader = Main.Instance.StandardShader;
      }
      catch
      {
      }
    }
  }

  public virtual void SetHighLod()
  {
    if ((Object) this.HighLod != (Object) null && (Object) this._ThisFilter != (Object) null)
      this._ThisFilter.mesh = this.HighLod;
    if (!this.DoubleSided)
      return;
    for (int index = 0; index < this.ThisRen.materials.Length; ++index)
    {
      try
      {
        this.ThisRen.materials[index].shader = Main.Instance.DoubleSidedStandardShader;
      }
      catch
      {
      }
    }
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    return new List<string>()
    {
      this.OriginalPrefab.name,
      Main.Color2Str(this.NaturalColor),
      Main.Color2Str(this.DyedColor)
    }.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    if (Data.Length >= 2)
    {
      this.NaturalColor = Main.ParseColor(Data[1]);
      this.DyedColor = Main.ParseColor(Data[2]);
    }
    this.RefreshColors();
  }

  public virtual void RefreshShapeWhileEquipped()
  {
    if (this.BeingUndressed || this.ShapeWhenEquipped == e_BlendShapes.None || !this.InvItem && !this.ThisRen.enabled)
      return;
    this.PersonEquipped.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[(int) this.ShapeWhenEquipped], true);
  }

  public virtual void RefreshShapeWhileUnequipped()
  {
  }

  public void SetIKs()
  {
    if (this.PersonEquipped.TheHealth.dead || this.PersonEquipped.TheHealth.Incapacitated || this.UsingIKs == null || this.UsingIKs.Length == 0 || !((Object) this.PersonEquipped.LeftArmIK != (Object) null))
      return;
    for (int index = 0; index < this.UsingIKs.Length; ++index)
    {
      if ((Object) this.UsingIKs[index].tAttatchTo != (Object) null)
      {
        switch (this.UsingIKs[index].Limb)
        {
          case e_IKLimb.LeftArm:
            this.PersonEquipped.LeftArmIK.enabled = true;
            this.PersonEquipped.LeftArmIK.Target.SetParent(this.UsingIKs[index].tAttatchTo);
            this.PersonEquipped.LeftArmIK.Target.localPosition = this.UsingIKs[index].Pos;
            this.PersonEquipped.LeftArmIK.Target.localEulerAngles = this.UsingIKs[index].Rot;
            this.PersonEquipped.LeftArmIK.Pole.localPosition = this.UsingIKs[index].PolePos;
            continue;
          case e_IKLimb.RightArm:
            this.PersonEquipped.RightArmIK.enabled = true;
            this.PersonEquipped.RightArmIK.Target.SetParent(this.UsingIKs[index].tAttatchTo);
            this.PersonEquipped.RightArmIK.Target.localPosition = this.UsingIKs[index].Pos;
            this.PersonEquipped.RightArmIK.Target.localEulerAngles = this.UsingIKs[index].Rot;
            this.PersonEquipped.RightArmIK.Pole.localPosition = this.UsingIKs[index].PolePos;
            continue;
          case e_IKLimb.LeftLeg:
            this.PersonEquipped.LeftLegIK.enabled = true;
            this.PersonEquipped.LeftLegIK.Target.SetParent(this.UsingIKs[index].tAttatchTo);
            this.PersonEquipped.LeftLegIK.Target.localPosition = this.UsingIKs[index].Pos;
            this.PersonEquipped.LeftLegIK.Target.localEulerAngles = this.UsingIKs[index].Rot;
            this.PersonEquipped.LeftLegIK.Pole.localPosition = this.UsingIKs[index].PolePos;
            continue;
          case e_IKLimb.RightLeg:
            this.PersonEquipped.RightLegIK.enabled = true;
            this.PersonEquipped.RightLegIK.Target.SetParent(this.UsingIKs[index].tAttatchTo);
            this.PersonEquipped.RightLegIK.Target.localPosition = this.UsingIKs[index].Pos;
            this.PersonEquipped.RightLegIK.Target.localEulerAngles = this.UsingIKs[index].Rot;
            this.PersonEquipped.RightLegIK.Pole.localPosition = this.UsingIKs[index].PolePos;
            continue;
          default:
            continue;
        }
      }
    }
  }

  public void UnsetIKs()
  {
    if (this.UsingIKs == null || this.UsingIKs.Length == 0 || !((Object) this.PersonEquipped.LeftArmIK != (Object) null))
      return;
    this.PersonEquipped.LeftArmIK.enabled = false;
    this.PersonEquipped.LeftArmIK.Target.SetParent(this.PersonEquipped.LeftArmIK.Pole.parent);
    this.PersonEquipped.RightArmIK.enabled = false;
    this.PersonEquipped.RightArmIK.Target.SetParent(this.PersonEquipped.LeftArmIK.Pole.parent);
    this.PersonEquipped.LeftLegIK.enabled = false;
    this.PersonEquipped.LeftLegIK.Target.SetParent(this.PersonEquipped.LeftArmIK.Pole.parent);
    this.PersonEquipped.RightLegIK.enabled = false;
    this.PersonEquipped.RightLegIK.Target.SetParent(this.PersonEquipped.LeftArmIK.Pole.parent);
  }
}
