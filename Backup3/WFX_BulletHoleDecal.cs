// Decompiled with JetBrains decompiler
// Type: WFX_BulletHoleDecal
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
[RequireComponent(typeof (MeshFilter))]
public class WFX_BulletHoleDecal : MonoBehaviour
{
  private static Vector2[] quadUVs = new Vector2[4]
  {
    new Vector2(0.0f, 0.0f),
    new Vector2(0.0f, 1f),
    new Vector2(1f, 0.0f),
    new Vector2(1f, 1f)
  };
  public float lifetime = 10f;
  public float fadeoutpercent = 80f;
  public Vector2 frames;
  public bool randomRotation;
  public bool deactivate;
  private float life;
  private float fadeout;
  private Color color;
  private float orgAlpha;

  private void Awake()
  {
    this.color = this.GetComponent<Renderer>().material.GetColor("_TintColor");
    this.orgAlpha = this.color.a;
  }

  private void OnEnable()
  {
    int num1;
    int num2 = (int) ((double) (num1 = Random.Range(0, (int) ((double) this.frames.x * (double) this.frames.y))) % (double) this.frames.x);
    int num3 = (int) ((double) num1 / (double) this.frames.y);
    Vector2[] vector2Array = new Vector2[4];
    for (int index = 0; index < 4; ++index)
    {
      vector2Array[index].x = (float) (((double) WFX_BulletHoleDecal.quadUVs[index].x + (double) num2) * (1.0 / (double) this.frames.x));
      vector2Array[index].y = (float) (((double) WFX_BulletHoleDecal.quadUVs[index].y + (double) num3) * (1.0 / (double) this.frames.y));
    }
    this.GetComponent<MeshFilter>().mesh.uv = vector2Array;
    if (this.randomRotation)
      this.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360f), Space.Self);
    this.life = this.lifetime;
    this.fadeout = this.life * (this.fadeoutpercent / 100f);
    this.color.a = this.orgAlpha;
    this.GetComponent<Renderer>().material.SetColor("_TintColor", this.color);
    this.StopAllCoroutines();
    this.StartCoroutine("holeUpdate");
  }

  private IEnumerator holeUpdate()
  {
    WFX_BulletHoleDecal wfxBulletHoleDecal = this;
    while ((double) wfxBulletHoleDecal.life > 0.0)
    {
      wfxBulletHoleDecal.life -= Time.deltaTime;
      if ((double) wfxBulletHoleDecal.life <= (double) wfxBulletHoleDecal.fadeout)
      {
        wfxBulletHoleDecal.color.a = Mathf.Lerp(0.0f, wfxBulletHoleDecal.orgAlpha, wfxBulletHoleDecal.life / wfxBulletHoleDecal.fadeout);
        wfxBulletHoleDecal.GetComponent<Renderer>().material.SetColor("_TintColor", wfxBulletHoleDecal.color);
      }
      yield return (object) null;
    }
  }
}
