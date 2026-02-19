// Decompiled with JetBrains decompiler
// Type: ObjectPlacementType
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class ObjectPlacementType
{
  private System.Random Rand;
  [SerializeField]
  private int Seed;
  public bool ShowTranslateFoldout;
  public bool ShowRotateFoldout;
  public bool ShowScaleFoldout;
  public GameObject Prefab;
  public int MaxObjects = 500;
  public bool AllowsIntersection;
  public float Spread = 10f;
  public int PlacementProbability = 100;
  public float MaxHeight;
  public float MinHeight;
  public bool ConstrainHeight;
  public AnimationCurve HeightProbCurve = AnimationCurve.Linear(0.0f, 1f, 1f, 1f);
  public float MaxAngle;
  public float MinAngle;
  public bool ConstrainAngle;
  public AnimationCurve AngleProbCurve = AnimationCurve.Linear(0.0f, 1f, 180f, 1f);
  public ObjectPlacementType.EvaluateOptions EvaluateOption = ObjectPlacementType.EvaluateOptions.Both;
  public bool IsRandomRotation;
  public Vector3 RotationAmount = Vector3.zero;
  public ObjectPlacementType.RandomTransformExtent RandomRotationExtents;
  public bool IsRandomTranslate;
  public Vector3 TranslationAmount = Vector3.zero;
  public ObjectPlacementType.RandomTransformExtent RandomTranslateExtents;
  public bool IsRandomScale;
  public bool IsUniformScale;
  public float UniformScaleMin = 1f;
  public float UniformScaleMax = 1.5f;
  public Vector3 ScaleAmount = new Vector3(1f, 1f, 1f);
  public ObjectPlacementType.RandomTransformExtent RandomScaleExtents;

  public ObjectPlacementType(int seed = -1)
  {
    this.Seed = seed;
    this.InitRNG();
    this.RandomRotationExtents = new ObjectPlacementType.RandomTransformExtent();
    this.RandomRotationExtents.Max = new Vector3(0.0f, 360f, 0.0f);
    this.RandomScaleExtents = new ObjectPlacementType.RandomTransformExtent();
    this.RandomScaleExtents.Max = new Vector3(1.5f, 1.5f, 1.5f);
    this.RandomScaleExtents.Min = new Vector3(1f, 1f, 1f);
    this.RandomTranslateExtents = new ObjectPlacementType.RandomTransformExtent();
    this.RandomTranslateExtents.Max = new Vector3(1f, 1f, 1f);
    this.RandomTranslateExtents.Min = new Vector3(-1f, -1f, -1f);
  }

  public bool ShouldPlaceAt(float height, float angle)
  {
    if (this.ConstrainHeight && !this.IsInHeightExtents(height) || this.ConstrainAngle && !this.IsInAngleExtents(angle) || !this.EvaluateHeight(height) || !this.EvaluateAngle(angle))
      return false;
    if ((double) this.PlacementProbability == 100.0)
      return true;
    if (this.Rand == null)
      this.InitRNG();
    return this.Rand.Next(0, 100) >= 100 - this.PlacementProbability;
  }

  public bool IsInHeightExtents(float height)
  {
    return (double) height < (double) this.MaxHeight && (double) height > (double) this.MinHeight;
  }

  public bool IsInAngleExtents(float angle)
  {
    return (double) angle < (double) this.MaxAngle && (double) angle > (double) this.MinAngle;
  }

  public bool EvaluateHeight(float height)
  {
    if (!this.ConstrainHeight)
      return true;
    float num1 = this.MaxHeight - this.MinHeight;
    float num2 = this.HeightProbCurve.Evaluate((height + this.MaxHeight) / num1);
    if (this.Rand == null)
      this.InitRNG();
    return (double) this.Rand.Next(0, 100) / 100.0 > 1.0 - (double) num2;
  }

  public bool EvaluateAngle(float angle)
  {
    if (!this.ConstrainAngle)
      return true;
    float num1 = this.MaxAngle - this.MinAngle;
    float num2 = this.AngleProbCurve.Evaluate((angle + this.MaxAngle) / num1);
    if (this.Rand == null)
      this.InitRNG();
    return (double) this.Rand.Next(0, 100) / 100.0 > 1.0 - (double) num2;
  }

  public Vector3 GetRotation()
  {
    if (!this.IsRandomRotation)
      return this.RotationAmount;
    Vector3 max = this.RandomRotationExtents.Max;
    Vector3 min = this.RandomRotationExtents.Min;
    return new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
  }

  public Vector3 GetScale()
  {
    if (!this.IsRandomScale)
      return this.ScaleAmount;
    if (this.IsUniformScale)
    {
      double num = (double) UnityEngine.Random.Range(this.UniformScaleMin, this.UniformScaleMax);
      return new Vector3((float) num, (float) num, (float) num);
    }
    Vector3 max = this.RandomScaleExtents.Max;
    Vector3 min = this.RandomScaleExtents.Min;
    return new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
  }

  public Vector3 GetTranslation(Vector3 pos)
  {
    if (!this.IsRandomTranslate)
      return this.TranslationAmount + pos;
    Vector3 max = this.RandomTranslateExtents.Max;
    Vector3 min = this.RandomTranslateExtents.Min;
    return new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z)) + pos;
  }

  public void TransformGameObject(GameObject go, Vector3 position, int length, Vector3 tileOffset)
  {
    float x = position.x * (float) length - (float) (length / 2) + tileOffset.x;
    float y = position.y;
    float z = position.z * (float) length - (float) (length / 2) + tileOffset.z;
    go.transform.position = this.GetTranslation(new Vector3(x, y, z));
    go.transform.eulerAngles = this.GetRotation();
    go.transform.localScale = this.GetScale();
  }

  private void InitRNG()
  {
    if (this.Seed == -1)
      this.Rand = new System.Random();
    else
      this.Rand = new System.Random(this.Seed);
  }

  [Serializable]
  public struct RandomTransformExtent
  {
    public Vector3 Max;
    public Vector3 Min;
  }

  [Serializable]
  public enum EvaluateOptions
  {
    HeightFirst,
    AngleFirst,
    Both,
  }
}
