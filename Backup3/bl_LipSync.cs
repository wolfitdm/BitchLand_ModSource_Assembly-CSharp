// Decompiled with JetBrains decompiler
// Type: bl_LipSync
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_LipSync : MonoBehaviour
{
  public SkinnedMeshRenderer skinnedMeshRenderer;
  public bl_LipSyncData[] Datas;
  public string LinesToTest;
  public float LineSoundLenght;
  public float transitionTime = 0.1f;
  public bool AnimateMouth;
  public bool Waiting;
  public int CurrentLetter;
  public float Timer;
  public bl_LipSyncData CurrentData;
  public e_BlendShapes ExpressionAtEnd;
  public bool TEST;

  public void InitFor(string text, float soundLenght, e_BlendShapes expressionAtEnd = e_BlendShapes.Max)
  {
    if (this.skinnedMeshRenderer.transform.GetComponentInParent<Girl>().MaterialTypeNPC == 1)
    {
      this.AnimateMouth = false;
      this.enabled = false;
    }
    else
    {
      this.LinesToTest = text.ToUpperInvariant();
      this.transitionTime = soundLenght / ((float) text.Length * 1.8f);
      this.AnimateMouth = true;
      this.CurrentLetter = 0;
      this.Timer = this.transitionTime;
      this.ExpressionAtEnd = expressionAtEnd;
      this.enabled = true;
    }
  }

  public void Update()
  {
    if (this.TEST && Input.GetKeyUp(KeyCode.J))
      this.InitFor(this.LinesToTest, this.LineSoundLenght);
    if (!this.AnimateMouth)
      return;
    if (this.Waiting)
    {
      this.Timer -= Time.deltaTime;
      if ((double) this.Timer >= 0.0)
        return;
      this.Waiting = false;
      this.Timer = this.transitionTime;
      for (int index = 0; index < this.CurrentData.Shapes.Length; ++index)
        this.skinnedMeshRenderer.SetBlendShapeWeight(this.CurrentData.Shapes[index], 0.0f);
    }
    if (this.CurrentLetter >= this.LinesToTest.Length)
    {
      this.AnimateMouth = false;
      this.enabled = false;
      if (this.ExpressionAtEnd == e_BlendShapes.Max)
        return;
      this.skinnedMeshRenderer.transform.parent.GetComponent<Person>().ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[(int) this.ExpressionAtEnd]);
    }
    else
    {
      char ch = this.LinesToTest[this.CurrentLetter++];
      for (int index1 = 0; index1 < this.Datas.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.Datas[index1].Letters.Length; ++index2)
        {
          if ((int) this.Datas[index1].Letters[index2] == (int) ch)
          {
            this.CurrentData = this.Datas[index1];
            this.Timer = this.transitionTime;
            this.Waiting = true;
            for (int index3 = 0; index3 < this.Datas[index1].Shapes.Length; ++index3)
              this.skinnedMeshRenderer.SetBlendShapeWeight(this.Datas[index1].Shapes[index3], this.Datas[index1].ShapeValues[index3]);
            return;
          }
        }
      }
    }
  }
}
