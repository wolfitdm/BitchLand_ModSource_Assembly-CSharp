// Decompiled with JetBrains decompiler
// Type: bl_editorrefs
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_editorrefs : MonoBehaviour
{
  public Girl GirlScript;
  public Material[] Mats;
  public GameObject[] Bodies;
  public Transform SpawnLocation;
  public RandomNPCHere Spawner;
  private int _PrevRandom;

  public void Spawn1()
  {
    int index = Random.Range(0, this.Bodies.Length);
    if (index == this._PrevRandom)
    {
      ++index;
      if (index >= this.Bodies.Length)
        index = 0;
    }
    GameObject gameObject = Object.Instantiate<GameObject>(this.Bodies[index]);
    gameObject.transform.position = this.SpawnLocation.position;
    bl_BodyPrepare blBodyPrepare = gameObject.GetComponent<bl_BodyPrepare>();
    if ((Object) blBodyPrepare == (Object) null)
    {
      blBodyPrepare = gameObject.AddComponent<bl_BodyPrepare>();
      blBodyPrepare.HeadStuffScl = Vector3.one;
    }
    this.Spawner.PersonGenerated = (Person) blBodyPrepare.Prepare();
    this.Spawner.LoadSpecificNPC = false;
    this.Spawner.SpecificClothes.Clear();
    this.Spawner.Start();
    this.Spawner.PersonGenerated.NaturalSkinColor = Main.Instance.NaturalSkinColors[Random.Range(0, 5)];
    this.Spawner.PersonGenerated.SetBodyTexture();
    this.Spawner.PersonGenerated.RemovePenis();
    this.Spawner.PersonGenerated.HasPenis = false;
  }
}
