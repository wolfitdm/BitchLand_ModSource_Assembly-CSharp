// Decompiled with JetBrains decompiler
// Type: SkinnedMeshCombiner
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SkinnedMeshCombiner : MonoBehaviour
{
  private Material baseMat;
  private SkinnedMeshRenderer newSkin;
  private List<SkinnedMeshRenderer> smRenderers;

  private void Start()
  {
    this.smRenderers = new List<SkinnedMeshRenderer>();
    List<Transform> transformList = new List<Transform>();
    List<BoneWeight> boneWeightList = new List<BoneWeight>();
    List<CombineInstance> combineInstanceList = new List<CombineInstance>();
    SkinnedMeshRenderer[] componentsInChildren = this.GetComponentsInChildren<SkinnedMeshRenderer>();
    MonoBehaviour.print((object) componentsInChildren.Length);
    foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
    {
      if (skinnedMeshRenderer.enabled)
      {
        if ((Object) this.baseMat == (Object) null)
        {
          MonoBehaviour.print((object) skinnedMeshRenderer.name);
          this.baseMat = skinnedMeshRenderer.sharedMaterial;
        }
        if ((Object) skinnedMeshRenderer.sharedMaterial == (Object) this.baseMat)
        {
          MonoBehaviour.print((object) skinnedMeshRenderer.name);
          this.smRenderers.Add(skinnedMeshRenderer);
        }
      }
    }
    int length = 0;
    foreach (SkinnedMeshRenderer smRenderer in this.smRenderers)
      length += smRenderer.sharedMesh.subMeshCount;
    int[] numArray = new int[length];
    for (int index = 0; index < this.smRenderers.Count; ++index)
    {
      SkinnedMeshRenderer smRenderer = this.smRenderers[index];
      foreach (Transform bone in smRenderer.bones)
      {
        if (!transformList.Contains(bone))
          transformList.Add(bone);
      }
      foreach (BoneWeight boneWeight1 in smRenderer.sharedMesh.boneWeights)
      {
        BoneWeight boneWeight2 = boneWeight1 with
        {
          boneIndex0 = transformList.IndexOf(smRenderer.bones[boneWeight1.boneIndex0]),
          boneIndex1 = transformList.IndexOf(smRenderer.bones[boneWeight1.boneIndex1]),
          boneIndex2 = transformList.IndexOf(smRenderer.bones[boneWeight1.boneIndex2]),
          boneIndex3 = transformList.IndexOf(smRenderer.bones[boneWeight1.boneIndex3])
        };
        boneWeightList.Add(boneWeight2);
      }
      CombineInstance combineInstance = new CombineInstance();
      combineInstance.transform = smRenderer.transform.localToWorldMatrix;
      combineInstance.mesh = smRenderer.sharedMesh;
      numArray[index] = combineInstance.mesh.vertexCount;
      combineInstanceList.Add(combineInstance);
      smRenderer.enabled = false;
    }
    List<Matrix4x4> matrix4x4List = new List<Matrix4x4>();
    for (int index = 0; index < transformList.Count; ++index)
      matrix4x4List.Add(transformList[index].worldToLocalMatrix);
    this.newSkin = this.gameObject.AddComponent<SkinnedMeshRenderer>();
    this.newSkin.sharedMesh = new Mesh();
    this.newSkin.sharedMesh.CombineMeshes(combineInstanceList.ToArray(), true, true);
    this.newSkin.bones = transformList.ToArray();
    this.newSkin.material = this.baseMat;
    this.newSkin.sharedMesh.boneWeights = boneWeightList.ToArray();
    this.newSkin.sharedMesh.bindposes = matrix4x4List.ToArray();
    this.newSkin.sharedMesh.RecalculateBounds();
  }
}
