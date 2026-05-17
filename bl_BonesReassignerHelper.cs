// Decompiled with JetBrains decompiler
// Type: bl_BonesReassignerHelper
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_BonesReassignerHelper : MonoBehaviour
{
  public SkinnedMeshRenderer OrgSkinMesh;
  public SkinnedMeshRenderer CopySkinMesh;
  public Transform[] ThisOriginalBones;
  public Transform[] OtherBones;

  public void Click_Sort()
  {
    Transform[] transformArray = new Transform[this.OtherBones.Length];
    for (int index1 = 0; index1 < this.OtherBones.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.ThisOriginalBones.Length; ++index2)
      {
        if (this.OtherBones[index1].name == this.ThisOriginalBones[index2].name)
        {
          transformArray[index1] = this.ThisOriginalBones[index2];
          break;
        }
      }
    }
    this.ThisOriginalBones = transformArray;
  }

  public void Click_AllInOne()
  {
    Transform[] bones1 = this.OrgSkinMesh.bones;
    Transform[] bones2 = this.CopySkinMesh.bones;
    Transform[] transformArray = new Transform[bones2.Length];
    for (int index1 = 0; index1 < bones2.Length; ++index1)
    {
      for (int index2 = 0; index2 < bones1.Length; ++index2)
      {
        if (bones2[index1].name == bones1[index2].name)
        {
          transformArray[index1] = bones1[index2];
          break;
        }
      }
    }
    this.OrgSkinMesh.bones = transformArray;
  }
}
