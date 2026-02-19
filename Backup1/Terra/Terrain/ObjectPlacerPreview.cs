// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.ObjectPlacerPreview
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using Terra.Terrain.Detail;
using UnityEngine;

#nullable disable
namespace Terra.Terrain
{
  internal class ObjectPlacerPreview
  {
    private TerraSettings Settings;
    private Mesh PreviewMesh;
    private GameObject Parent;
    private ObjectRenderer Placer;
    public static readonly string OBJ_PREVIEW_NAME = "OBJECT_PREVIEW";

    public ObjectPlacerPreview(TerraSettings settings, Mesh m)
    {
      this.Settings = settings;
      this.PreviewMesh = m;
      this.Placer = new ObjectRenderer();
      this.CreateParentGO();
    }

    public void PreviewAllObjects()
    {
      this.ClearExistingObjects();
      foreach (ObjectPlacementType placementSetting in this.Settings.ObjectPlacementSettings)
      {
        List<Vector3> filteredGrid = this.Placer.GetFilteredGrid(this.PreviewMesh, placementSetting);
        int num1 = filteredGrid.Count > placementSetting.MaxObjects ? placementSetting.MaxObjects : filteredGrid.Count;
        for (int index = 0; index < num1; ++index)
        {
          int num2 = (UnityEngine.Object) placementSetting.Prefab != (UnityEngine.Object) null ? 1 : 0;
        }
      }
    }

    private void CreateParentGO()
    {
      if (!((UnityEngine.Object) this.Parent == (UnityEngine.Object) null))
        return;
      IEnumerable<Transform> source = ((IEnumerable<Transform>) this.Settings.GetComponentsInChildren<Transform>()).Where<Transform>((Func<Transform, bool>) (t => t.gameObject.name == ObjectPlacerPreview.OBJ_PREVIEW_NAME));
      if (source.Count<Transform>() > 0)
        this.Parent = source.ToArray<Transform>()[0].gameObject;
      else
        this.Parent = new GameObject(ObjectPlacerPreview.OBJ_PREVIEW_NAME)
        {
          transform = {
            parent = this.Settings.gameObject.transform
          }
        };
    }

    private void ClearExistingObjects()
    {
      Component[] componentsInChildren = (Component[]) this.Parent.GetComponentsInChildren<Transform>();
      for (int index = 0; index < componentsInChildren.Length; ++index)
      {
        if ((UnityEngine.Object) componentsInChildren[index] != (UnityEngine.Object) null && (UnityEngine.Object) componentsInChildren[index].gameObject != (UnityEngine.Object) this.Parent)
          UnityEngine.Object.DestroyImmediate((UnityEngine.Object) componentsInChildren[index].gameObject);
      }
    }
  }
}
