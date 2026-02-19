// Decompiled with JetBrains decompiler
// Type: DitzelGames.FastIK.FastIKFabric
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DitzelGames.FastIK
{
  public class FastIKFabric : MonoBehaviour
  {
    public int ChainLength = 2;
    public Transform Target;
    public Transform Pole;
    [Header("Solver Parameters")]
    public int Iterations = 10;
    public float Delta = 1f / 1000f;
    [Range(0.0f, 1f)]
    public float SnapBackStrength = 1f;
    [Header("privates")]
    public float[] BonesLength;
    public float CompleteLength;
    public Transform[] Bones;
    public Vector3[] Positions;
    public Vector3[] StartDirectionSucc;
    public Quaternion[] StartRotationBone;
    public Quaternion StartRotationTarget;
    public Transform Root;

    private void Awake()
    {
      try
      {
        this.Init();
      }
      catch
      {
      }
    }

    private void Init()
    {
      bool flag = this.Bones != null && this.Bones.Length != 0;
      if (!flag)
        this.Bones = new Transform[this.ChainLength + 1];
      this.Positions = new Vector3[this.ChainLength + 1];
      this.BonesLength = new float[this.ChainLength];
      this.StartDirectionSucc = new Vector3[this.ChainLength + 1];
      this.StartRotationBone = new Quaternion[this.ChainLength + 1];
      if ((Object) this.Root == (Object) null)
      {
        this.Root = this.transform;
        for (int index = 0; index <= this.ChainLength; ++index)
          this.Root = !((Object) this.Root == (Object) null) ? this.Root.parent : throw new UnityException("The chain value is longer than the ancestor chain!");
      }
      if ((Object) this.Target == (Object) null)
      {
        this.Target = new GameObject(this.gameObject.name + " Target").transform;
        this.SetPositionRootSpace(this.Target, this.GetPositionRootSpace(this.transform));
      }
      this.StartRotationTarget = this.GetRotationRootSpace(this.Target);
      Transform current = this.transform;
      this.CompleteLength = 0.0f;
      if (flag)
      {
        for (int index = this.Bones.Length - 1; index >= 0; current = this.Bones[--index])
        {
          this.StartRotationBone[index] = this.GetRotationRootSpace(current);
          if (index == this.Bones.Length - 1)
          {
            this.StartDirectionSucc[index] = this.GetPositionRootSpace(this.Target) - this.GetPositionRootSpace(current);
          }
          else
          {
            this.StartDirectionSucc[index] = this.GetPositionRootSpace(this.Bones[index + 1]) - this.GetPositionRootSpace(current);
            this.BonesLength[index] = this.StartDirectionSucc[index].magnitude;
            this.CompleteLength += this.BonesLength[index];
          }
        }
      }
      else
      {
        for (int index = this.Bones.Length - 1; index >= 0; --index)
        {
          this.Bones[index] = current;
          this.StartRotationBone[index] = this.GetRotationRootSpace(current);
          if (index == this.Bones.Length - 1)
          {
            this.StartDirectionSucc[index] = this.GetPositionRootSpace(this.Target) - this.GetPositionRootSpace(current);
          }
          else
          {
            this.StartDirectionSucc[index] = this.GetPositionRootSpace(this.Bones[index + 1]) - this.GetPositionRootSpace(current);
            this.BonesLength[index] = this.StartDirectionSucc[index].magnitude;
            this.CompleteLength += this.BonesLength[index];
          }
          current = current.parent;
        }
      }
    }

    private void LateUpdate() => this.ResolveIK();

    private void ResolveIK()
    {
      if ((Object) this.Target == (Object) null)
        return;
      if (this.BonesLength.Length != this.ChainLength)
        this.Init();
      for (int index = 0; index < this.Bones.Length; ++index)
        this.Positions[index] = this.GetPositionRootSpace(this.Bones[index]);
      Vector3 positionRootSpace1 = this.GetPositionRootSpace(this.Target);
      Quaternion rotationRootSpace = this.GetRotationRootSpace(this.Target);
      Vector3 vector3_1 = positionRootSpace1 - this.GetPositionRootSpace(this.Bones[0]);
      if ((double) vector3_1.sqrMagnitude >= (double) this.CompleteLength * (double) this.CompleteLength)
      {
        vector3_1 = positionRootSpace1 - this.Positions[0];
        Vector3 normalized = vector3_1.normalized;
        for (int index = 1; index < this.Positions.Length; ++index)
          this.Positions[index] = this.Positions[index - 1] + normalized * this.BonesLength[index - 1];
      }
      else
      {
        for (int index = 0; index < this.Positions.Length - 1; ++index)
          this.Positions[index + 1] = Vector3.Lerp(this.Positions[index + 1], this.Positions[index] + this.StartDirectionSucc[index], this.SnapBackStrength);
        for (int index1 = 0; index1 < this.Iterations; ++index1)
        {
          for (int index2 = this.Positions.Length - 1; index2 > 0; --index2)
          {
            if (index2 == this.Positions.Length - 1)
            {
              this.Positions[index2] = positionRootSpace1;
            }
            else
            {
              Vector3[] positions = this.Positions;
              int index3 = index2;
              Vector3 position = this.Positions[index2 + 1];
              vector3_1 = this.Positions[index2] - this.Positions[index2 + 1];
              Vector3 vector3_2 = vector3_1.normalized * this.BonesLength[index2];
              Vector3 vector3_3 = position + vector3_2;
              positions[index3] = vector3_3;
            }
          }
          for (int index4 = 1; index4 < this.Positions.Length; ++index4)
          {
            Vector3[] positions = this.Positions;
            int index5 = index4;
            Vector3 position = this.Positions[index4 - 1];
            vector3_1 = this.Positions[index4] - this.Positions[index4 - 1];
            Vector3 vector3_4 = vector3_1.normalized * this.BonesLength[index4 - 1];
            Vector3 vector3_5 = position + vector3_4;
            positions[index5] = vector3_5;
          }
          vector3_1 = this.Positions[this.Positions.Length - 1] - positionRootSpace1;
          if ((double) vector3_1.sqrMagnitude < (double) this.Delta * (double) this.Delta)
            break;
        }
      }
      if ((Object) this.Pole != (Object) null)
      {
        Vector3 positionRootSpace2 = this.GetPositionRootSpace(this.Pole);
        for (int index = 1; index < this.Positions.Length - 1; ++index)
        {
          Plane plane = new Plane(this.Positions[index + 1] - this.Positions[index - 1], this.Positions[index - 1]);
          Vector3 vector3_6 = plane.ClosestPointOnPlane(positionRootSpace2);
          float angle = Vector3.SignedAngle(plane.ClosestPointOnPlane(this.Positions[index]) - this.Positions[index - 1], vector3_6 - this.Positions[index - 1], plane.normal);
          this.Positions[index] = Quaternion.AngleAxis(angle, plane.normal) * (this.Positions[index] - this.Positions[index - 1]) + this.Positions[index - 1];
        }
      }
      for (int index = 0; index < this.Positions.Length; ++index)
      {
        if (index == this.Positions.Length - 1)
          this.SetRotationRootSpace(this.Bones[index], Quaternion.Inverse(rotationRootSpace) * this.StartRotationTarget * Quaternion.Inverse(this.StartRotationBone[index]));
        else
          this.SetRotationRootSpace(this.Bones[index], Quaternion.FromToRotation(this.StartDirectionSucc[index], this.Positions[index + 1] - this.Positions[index]) * Quaternion.Inverse(this.StartRotationBone[index]));
        this.SetPositionRootSpace(this.Bones[index], this.Positions[index]);
      }
    }

    private Vector3 GetPositionRootSpace(Transform current)
    {
      return (Object) this.Root == (Object) null ? current.position : Quaternion.Inverse(this.Root.rotation) * (current.position - this.Root.position);
    }

    private void SetPositionRootSpace(Transform current, Vector3 position)
    {
      if ((Object) this.Root == (Object) null)
        current.position = position;
      else
        current.position = this.Root.rotation * position + this.Root.position;
    }

    private Quaternion GetRotationRootSpace(Transform current)
    {
      return (Object) this.Root == (Object) null ? current.rotation : Quaternion.Inverse(current.rotation) * this.Root.rotation;
    }

    private void SetRotationRootSpace(Transform current, Quaternion rotation)
    {
      if ((Object) this.Root == (Object) null)
        current.rotation = rotation;
      else
        current.rotation = this.Root.rotation * rotation;
    }

    private void OnDrawGizmos()
    {
    }
  }
}
