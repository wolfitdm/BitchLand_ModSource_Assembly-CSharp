// Decompiled with JetBrains decompiler
// Type: Dressable
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
  }

  public virtual void OnUndressed()
  {
    this.BeingUndressed = true;
    if ((Object) this.PersonEquipped == (Object) null || !this.PersonEquipped.IsPlayer || (double) this.IncreasedHeight == 0.0)
      return;
    this.PersonEquipped.UserControl.m_Character.UsingStandingHeight = this.PersonEquipped.UserControl.m_Character.DefaultStandingHeight;
    this.PersonEquipped.UserControl.m_Character.StandState = this.PersonEquipped.UserControl.m_Character.StandState;
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
}
