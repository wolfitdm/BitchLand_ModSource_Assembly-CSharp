// Decompiled with JetBrains decompiler
// Type: Guy
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Guy : Person
{
  [Header("Guy")]
  public int MaleBodyType;
  public SkinnedMeshRenderer EyesRen;
  public Material[] SavedMats;
  public Material[] MatsWhenNoHead;

  public override void SetHighLod()
  {
    base.SetHighLod();
    this.MainBody.quality = SkinQuality.Bone4;
  }

  public override void SetLowLod()
  {
    base.SetLowLod();
    this.MainBody.enabled = true;
    this.MainBody.quality = SkinQuality.Bone1;
  }

  public override void SetCullLod(bool fullCull = false) => base.SetCullLod(fullCull);

  public override void SetBodyTexture()
  {
  }

  public override void RefreshColors()
  {
    Color color = Color.white;
    switch (this.MaleBodyType)
    {
      case 0:
        if (this.MainBody.materials.Length <= 4)
          return;
        this.MainBody.materials[4] = Main.Instance.MaleMatBody;
        this.MainBody.materials[5] = Main.Instance.MaleMatBody;
        color = this.TannedSkinColor != new Color(0.0f, 0.0f, 0.0f, 0.0f) ? this.TannedSkinColor : this.NaturalSkinColor;
        this.MainBody.materials[3].color = color;
        this.MainBody.materials[4].color = color;
        this.MainBody.materials[5].color = color;
        for (int index = 0; index < this.EquippedClothes.Count; ++index)
        {
          switch (this.EquippedClothes[index].HidesMaleParts)
          {
            case Person.BodyMaleMaterials.Torso:
              this.MainBody.materials[4] = Main.Instance.InvMat;
              break;
            case Person.BodyMaleMaterials.Legs:
              this.MainBody.materials[5] = Main.Instance.InvMat;
              break;
          }
        }
        if (!this._HiddenHead)
        {
          this.MainBody.materials[1] = Main.Instance.MaleMatHead;
          this.MainBody.materials[1].color = color;
          this.MainBody.materials[7].color = this.DyedEyeColor != new Color(0.0f, 0.0f, 0.0f, 0.0f) ? this.DyedEyeColor : this.NaturalEyeColor;
          break;
        }
        this.MainBody.materials[1] = Main.Instance.InvMat;
        break;
      case 1:
        this.MainBody.materials[0] = Main.Instance.MaleMatBody;
        color = this.TannedSkinColor != new Color(0.0f, 0.0f, 0.0f, 0.0f) ? this.TannedSkinColor : this.NaturalSkinColor;
        this.MainBody.materials[0].color = color;
        if (!this._HiddenHead)
        {
          this.MainBody.materials[2].color = color;
          this.EyesRen.materials[1].color = this.DyedEyeColor != new Color(0.0f, 0.0f, 0.0f, 0.0f) ? this.DyedEyeColor : this.NaturalEyeColor;
          break;
        }
        break;
    }
    if ((Object) this.CurrentHair != (Object) null)
    {
      Renderer[] componentsInChildren = this.CurrentHair.GetComponentsInChildren<Renderer>();
      for (int index1 = 0; index1 < componentsInChildren.Length; ++index1)
      {
        for (int index2 = 0; index2 < componentsInChildren[index1].materials.Length; ++index2)
          componentsInChildren[index1].materials[index2].color = this.DyedHairColor != new Color(0.0f, 0.0f, 0.0f, 0.0f) ? this.DyedHairColor : this.NaturalHairColor;
      }
    }
    if ((Object) this.CurrentBeard != (Object) null)
    {
      Renderer[] componentsInChildren = this.CurrentBeard.GetComponentsInChildren<Renderer>();
      for (int index3 = 0; index3 < componentsInChildren.Length; ++index3)
      {
        for (int index4 = 0; index4 < componentsInChildren[index3].materials.Length; ++index4)
          componentsInChildren[index3].materials[index4].color = this.DyedHairColor != new Color(0.0f, 0.0f, 0.0f, 0.0f) ? this.DyedHairColor : this.NaturalHairColor;
      }
    }
    int count = this.CurrentAnys.Count;
    if (!((Object) this.Penis != (Object) null))
      return;
    this.Penis.GetComponentInChildren<Renderer>().material.color = color;
  }

  public override bool HiddenHead
  {
    get => base.HiddenHead;
    set
    {
      this._HiddenHead = value;
      switch (this.MaleBodyType)
      {
        case 0:
          if (!this.IsPlayer)
            break;
          if (value)
          {
            this.MainBody.materials = this.MatsWhenNoHead;
            if ((Object) this.EyesRen != (Object) null)
              this.EyesRen.enabled = false;
            this.RefreshColors();
            break;
          }
          this.MainBody.materials = this.SavedMats;
          if ((Object) this.EyesRen != (Object) null)
            this.EyesRen.enabled = true;
          this.RefreshColors();
          break;
        case 1:
          if (value)
          {
            this.MainBody.materials = new Material[1]
            {
              this.MainBody.material
            };
            this.EyesRen.enabled = false;
            break;
          }
          this.MainBody.materials = new Material[6]
          {
            this.MainBody.material,
            Main.Instance.MatTeeth,
            Main.Instance.MatMale2Head,
            Main.Instance.MatMale2Lash,
            Main.Instance.MatThong,
            Main.Instance.MatTeeth
          };
          this.MainBody.materials[2].color = this.MainBody.material.color;
          this.EyesRen.enabled = true;
          break;
      }
    }
  }

  public override void GenerateRandomFace()
  {
  }

  public override void GenerateRandomBody()
  {
  }
}
