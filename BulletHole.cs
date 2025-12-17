// Decompiled with JetBrains decompiler
// Type: BulletHole
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BulletHole : MonoBehaviour
{
  public GameObject bulletHoleMesh;
  public bool usePooling = true;
  public float lifetime = 28f;
  public float startFadeTime = 10f;
  private float timer;
  public float fadeRate = 1f / 1000f;
  private Color targetColor;

  private void Start()
  {
    this.timer = 0.0f;
    this.targetColor = this.bulletHoleMesh.GetComponent<Renderer>().material.color;
    this.targetColor.a = 0.0f;
  }

  private void Update()
  {
    if (this.usePooling)
      return;
    this.FadeAndDieOverTime();
  }

  public void Refresh() => this.AttachToParent();

  private void AttachToParent()
  {
    RaycastHit hitInfo;
    if (Physics.Raycast(this.bulletHoleMesh.transform.position, -this.bulletHoleMesh.transform.up, out hitInfo, 0.1f))
    {
      if (hitInfo.collider.gameObject.layer == 20)
        Object.Destroy((Object) this.transform.gameObject);
      else
        this.transform.parent = hitInfo.collider.transform;
    }
    else
      Object.Destroy((Object) this.transform.gameObject);
  }

  private void FadeAndDieOverTime()
  {
    this.timer += Time.deltaTime;
    if ((double) this.timer >= (double) this.startFadeTime)
      this.bulletHoleMesh.GetComponent<Renderer>().material.color = Color.Lerp(this.bulletHoleMesh.GetComponent<Renderer>().material.color, this.targetColor, this.fadeRate * Time.deltaTime);
    if ((double) this.timer < (double) this.lifetime)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
