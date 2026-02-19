// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.NoisePreviewNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise.Texturing;
using UnityEngine;
using XNode;

#nullable disable
namespace Terra.Graph.Noise;

[Node.CreateNodeMenu("Preview")]
public class NoisePreviewNode : Node
{
  [Node.Input(Node.ShowBackingValue.Never, Node.ConnectionType.Override)]
  public AbsGeneratorNode Input;

  public Texture PreviewTexture { get; private set; }

  public bool TextureNeedsUpdating { get; private set; }

  public override void OnCreateConnection(NodePort from, NodePort to)
  {
    base.OnCreateConnection(from, to);
    this.UpdateTexture();
  }

  public override void OnRemoveConnection(NodePort port)
  {
    base.OnRemoveConnection(port);
    this.PreviewTexture = (Texture) null;
  }

  public void InvalidateTexture() => this.TextureNeedsUpdating = true;

  public bool HasTexture() => (Object) this.PreviewTexture != (Object) null;

  public void UpdateTexture()
  {
    AbsGeneratorNode inputValue = this.GetInputValue<AbsGeneratorNode>("Input");
    if ((Object) inputValue != (Object) null && inputValue.GetGenerator() != null)
      this.PreviewTexture = TextureMaker.MonochromeTexture(100, 100, inputValue.GetGenerator());
    this.TextureNeedsUpdating = false;
  }
}
