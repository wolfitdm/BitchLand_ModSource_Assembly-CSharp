// Decompiled with JetBrains decompiler
// Type: DamageIndicator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
