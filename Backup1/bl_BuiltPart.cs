// Decompiled with JetBrains decompiler
// Type: bl_BuiltPart
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_BuiltPart : bl_MinableObject
{
  [ContextMenu("Make Buildable")]
  public void MakeBuildable()
  {
    this.PrefabName = this.gameObject.name;
    this.InteractText = string.Empty;
    this.RootObj = this.gameObject;
    this.PlaceNPCOnInteract = false;
    Transform transform1 = new GameObject("cons1").transform;
    transform1.SetParent(this.transform);
    transform1.localScale = Vector3.one;
    transform1.localPosition = Vector3.zero;
    transform1.localEulerAngles = Vector3.zero;
    Transform transform2 = new GameObject("cons2").transform;
    transform2.SetParent(this.transform);
    transform2.localScale = Vector3.one;
    transform2.localPosition = Vector3.zero;
    transform2.localEulerAngles = Vector3.zero;
    Transform transform3 = new GameObject("cons3").transform;
    transform3.SetParent(this.transform);
    transform3.localScale = Vector3.one;
    transform3.localPosition = Vector3.zero;
    transform3.localEulerAngles = Vector3.zero;
    Transform transform4 = new GameObject("cons4").transform;
    transform4.SetParent(this.transform);
    transform4.localScale = Vector3.one;
    transform4.localPosition = Vector3.zero;
    transform4.localEulerAngles = Vector3.zero;
    this.SpawnSpots = new Transform[4]
    {
      transform1,
      transform2,
      transform3,
      transform4
    };
  }
}
