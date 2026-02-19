// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Damage_Display_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Damage_Display_CS : MonoBehaviour
  {
    [Header("Display settings")]
    [Tooltip("Upper offset for displaying the value.")]
    public float offset = 256f;
    [Tooltip("Displaying time.")]
    public float time = 1.5f;
    private Transform thisTransform;
    private Text thisText;
    [HideInInspector]
    public Transform targetTransform;
    private int displayingCount;

    private void Awake()
    {
      this.thisTransform = this.GetComponent<Transform>();
      this.thisText = this.GetComponent<Text>();
      this.thisText.enabled = false;
    }

    public void Get_Damage(float durability, float initialDurability)
    {
      this.thisText.text = Mathf.Ceil(durability).ToString() + "/" + initialDurability.ToString();
      this.StartCoroutine("Display");
    }

    private IEnumerator Display()
    {
      float count = 0.0f;
      ++this.displayingCount;
      int myNum = this.displayingCount;
      Color currentColor = this.thisText.color;
      while ((double) count < (double) this.time)
      {
        if (myNum < this.displayingCount)
          yield break;
        else if ((bool) (UnityEngine.Object) this.targetTransform)
        {
          this.Set_Position();
          currentColor.a = Mathf.Lerp(1f, 0.0f, count / this.time);
          this.thisText.color = currentColor;
          count += Time.deltaTime;
          yield return (object) null;
        }
        else
          break;
      }
      this.displayingCount = 0;
      this.thisText.enabled = false;
    }

    private void Set_Position()
    {
      float num = 2f * Vector3.Distance(this.targetTransform.position, Camera.main.transform.position) * Mathf.Tan((float) ((double) Camera.main.fieldOfView * 0.5 * (Math.PI / 180.0)));
      Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.targetTransform.position);
      if ((double) screenPoint.z > 0.0)
      {
        this.thisText.enabled = true;
        screenPoint.z = 100f;
        screenPoint.y += 5f / num * this.offset;
        this.thisTransform.position = screenPoint;
        this.thisTransform.localScale = Vector3.one;
      }
      else
        this.thisText.enabled = false;
    }
  }
}
