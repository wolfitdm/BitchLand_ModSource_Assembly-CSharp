// Decompiled with JetBrains decompiler
// Type: VibrationDemo
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class VibrationDemo : MonoBehaviour
{
  public GameObject objectToVibrate;
  private Vibration vibration;
  private float xVibe = 0.5f;
  private float yVibe = 0.5f;
  private float zVibe = 0.5f;
  private float xRot = 0.05f;
  private float yRot = -0.05f;
  private float zRot = -0.05f;
  private float speed = 60f;
  private float diminish = 0.5f;
  private int numberOfShakes = 8;
  private float randomMin = -1.4f;
  private float randomMax = 1.4f;
  private float randomRotationMin = -0.2f;
  private float randomRotationMax = 0.2f;

  private void Start() => this.vibration = this.objectToVibrate.GetComponent<Vibration>();

  private void OnGUI()
  {
    GUILayout.BeginArea(new Rect((float) (Screen.width / 4), 10f, (float) (Screen.width / 2), (float) Screen.height));
    GUILayout.BeginHorizontal();
    GUILayout.Label("X Vibration");
    this.xVibe = GUILayout.HorizontalSlider(this.xVibe, -2f, 2f);
    GUILayout.Label("\t" + this.xVibe.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Y Vibration");
    this.yVibe = GUILayout.HorizontalSlider(this.yVibe, -2f, 2f);
    GUILayout.Label("\t" + this.yVibe.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Z Vibration");
    this.zVibe = GUILayout.HorizontalSlider(this.zVibe, -2f, 2f);
    GUILayout.Label("\t" + this.zVibe.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("X Rotation");
    this.xRot = GUILayout.HorizontalSlider(this.xRot, -2f, 2f);
    GUILayout.Label("\t" + this.xRot.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Y Rotation");
    this.yRot = GUILayout.HorizontalSlider(this.yRot, -2f, 2f);
    GUILayout.Label("\t" + this.yRot.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Z Rotation");
    this.zRot = GUILayout.HorizontalSlider(this.zRot, -2f, 2f);
    GUILayout.Label("\t" + this.zRot.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Speed");
    this.speed = GUILayout.HorizontalSlider(this.speed, 10f, 150f);
    GUILayout.Label("\t" + this.speed.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Decrease Multiplier");
    this.diminish = GUILayout.HorizontalSlider(this.diminish, 0.0f, 1f);
    GUILayout.Label("\t" + this.diminish.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Number of Shakes");
    this.numberOfShakes = (int) GUILayout.HorizontalSlider((float) this.numberOfShakes, 1f, 25f);
    GUILayout.Label("\t" + this.numberOfShakes.ToString());
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Random Position Min");
    this.randomMin = GUILayout.HorizontalSlider(this.randomMin, -2f, 2f);
    GUILayout.Label("\t" + this.randomMin.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Random Position Max");
    this.randomMax = GUILayout.HorizontalSlider(this.randomMax, -2f, 2f);
    GUILayout.Label("\t" + this.randomMax.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Random Rotation Min");
    this.randomRotationMin = GUILayout.HorizontalSlider(this.randomRotationMin, -2f, 2f);
    GUILayout.Label("\t" + this.randomRotationMin.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    GUILayout.Label("Random Rotation Max");
    this.randomRotationMax = GUILayout.HorizontalSlider(this.randomRotationMax, -2f, 2f);
    GUILayout.Label("\t" + this.randomRotationMax.ToString("F2"));
    GUILayout.EndHorizontal();
    GUILayout.BeginHorizontal();
    if (GUILayout.Button("Shake", GUILayout.Height(50f)))
      this.vibration.StartShaking(new Vector3(this.xVibe, this.yVibe, this.zVibe), new Quaternion(this.xRot, this.yRot, this.zRot, 1f), this.speed, this.diminish, this.numberOfShakes);
    if (GUILayout.Button("Shake Random", GUILayout.Height(50f)))
      this.vibration.StartShakingRandom(this.randomMin, this.randomMax, this.randomRotationMin, this.randomRotationMax);
    GUILayout.EndHorizontal();
    GUILayout.EndArea();
  }
}
