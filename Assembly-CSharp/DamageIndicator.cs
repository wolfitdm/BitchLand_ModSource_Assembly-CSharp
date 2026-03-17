// Decompiled with JetBrains decompiler
// Type: DamageIndicator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class DamageIndicator : MonoBehaviour
{
  [SerializeField]
  private Shader shader;
  [SerializeField]
  private List<DamageIndicator.Part> parts;

  private void Start()
  {
    foreach (DamageIndicator.Part part in this.parts)
    {
      Material material = new Material(this.shader);
      material.SetTexture("_DamagedTex", (Texture) part.DamagedSprite.texture);
      part.Target.material = material;
    }
  }

  [Serializable]
  public class Part
  {
    [SerializeField]
    public Image Target;
    [SerializeField]
    public Sprite DamagedSprite;
  }
}
