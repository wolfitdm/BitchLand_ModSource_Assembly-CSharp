// Decompiled with JetBrains decompiler
// Type: FallChecker
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FallChecker : MonoBehaviour
{
  public Rigidbody rg;

  public void FixedUpdate()
  {
    if ((double) this.rg.transform.position.y >= -100.0)
      return;
    this.rg.velocity = Vector3.zero;
    Vector3 vector3 = new Vector3(0.0f, 0.2f, 0.0f);
    if (Main.Instance.OpenWorld)
    {
      float num1 = 5E+07f;
      for (int index = 0; index < bl_SectionGenerate2.ItemFallRespawnSpots.Count; ++index)
      {
        if ((Object) bl_SectionGenerate2.ItemFallRespawnSpots[index] != (Object) null)
        {
          float num2 = Vector3.Distance(bl_SectionGenerate2.ItemFallRespawnSpots[index].position, this.rg.transform.position);
          if ((double) num2 < (double) num1)
          {
            num1 = num2;
            vector3 = bl_SectionGenerate2.ItemFallRespawnSpots[index].position;
          }
        }
      }
    }
    this.rg.transform.position = vector3;
  }
}
