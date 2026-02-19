// Decompiled with JetBrains decompiler
// Type: BulletHolePool
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[Serializable]
public class BulletHolePool : MonoBehaviour
{
  public List<GameObject> bulletHoles = new List<GameObject>();
  public GameObject replacementBulletHole;
  private int currentIndex;

  private void Start()
  {
    if (!((UnityEngine.Object) this.replacementBulletHole == (UnityEngine.Object) null))
      return;
    Debug.LogWarning((object) ("The Replacement Bullet Hole for " + this.gameObject.name + " is null.  Please set this variable in the inspector."));
    this.replacementBulletHole = new GameObject();
  }

  private void Update()
  {
  }

  private void IncrementIndex()
  {
    ++this.currentIndex;
    if (this.currentIndex < this.bulletHoles.Count)
      return;
    this.currentIndex = 0;
  }

  public void PlaceBulletHole(Vector3 pos, Quaternion rot)
  {
    this.VerifyBulletHole();
    this.bulletHoles[this.currentIndex].transform.parent = (Transform) null;
    this.bulletHoles[this.currentIndex].transform.position = pos;
    this.bulletHoles[this.currentIndex].transform.rotation = rot;
    this.bulletHoles[this.currentIndex].transform.localScale = this.bulletHoles[this.currentIndex].transform.localScale;
    if ((UnityEngine.Object) this.bulletHoles[this.currentIndex].GetComponent<BulletHole>() == (UnityEngine.Object) null)
      this.bulletHoles[this.currentIndex].AddComponent<BulletHole>();
    this.bulletHoles[this.currentIndex].GetComponent<BulletHole>().Refresh();
    this.IncrementIndex();
  }

  private void VerifyBulletHole()
  {
    if (!((UnityEngine.Object) this.bulletHoles[this.currentIndex] == (UnityEngine.Object) null))
      return;
    this.bulletHoles[this.currentIndex] = UnityEngine.Object.Instantiate<GameObject>(this.replacementBulletHole, this.transform.position, this.transform.rotation);
  }
}
