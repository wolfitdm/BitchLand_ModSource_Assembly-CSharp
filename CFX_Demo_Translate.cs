// Decompiled with JetBrains decompiler
// Type: CFX_Demo_Translate
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CFX_Demo_Translate : MonoBehaviour
{
  public float speed = 30f;
  public Vector3 rotation = Vector3.forward;
  public Vector3 axis = Vector3.forward;
  public bool gravity;
  private Vector3 dir;

  private void Start()
  {
    this.dir = new Vector3(Random.Range(0.0f, 360f), Random.Range(0.0f, 360f), Random.Range(0.0f, 360f));
    this.dir.Scale(this.rotation);
    this.transform.localEulerAngles = this.dir;
  }

  private void Update()
  {
    this.transform.Translate(this.axis * this.speed * Time.deltaTime, Space.Self);
  }
}
