// Decompiled with JetBrains decompiler
// Type: ShpalaInit
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ShpalaInit : MonoBehaviour
{
  public bool Generatator;
  public GameObject ShpalasToInit;
  public int count;
  public float Dist;
  private Quaternion direction;

  private void Start()
  {
    this.direction = this.transform.rotation;
    if (!this.Generatator)
      return;
    int num = 0;
    while (num < this.count)
    {
      Vector3 position1 = new Vector3(this.transform.position.x + this.Dist * (float) ++num, this.transform.position.y, this.transform.position.z);
      Vector3 position2 = new Vector3(this.transform.position.x - this.Dist * (float) num, this.transform.position.y, this.transform.position.z);
      Object.Instantiate<GameObject>(this.ShpalasToInit, position1, this.direction);
      Object.Instantiate<GameObject>(this.ShpalasToInit, position2, this.direction);
    }
  }
}
