// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.SE_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
  public class SE_Control_CS : MonoBehaviour
  {
    [Header("Engine Sound settings")]
    [Tooltip("Set the Left RoadWheel to synchronize with.")]
    public Rigidbody leftReferenceWheel;
    [Tooltip("Set the Left RoadWheel to synchronize with.")]
    public Rigidbody rightReferenceWheel;
    [Tooltip("Minimum Pitch")]
    public float minPitch = 1f;
    [Tooltip("Maximum Pitch")]
    public float maxPitch = 2f;
    [Tooltip("Minimum Volume")]
    public float minVolume = 0.1f;
    [Tooltip("Maximum Volume")]
    public float maxVolume = 0.3f;
    private AudioSource thisAudioSource;
    private float leftCircumference;
    private float rightCircumference;
    private float currentRate;
    private const float DOUBLE_PI = 6.28318548f;
    private float maxSpeed;

    private void Awake()
    {
      this.thisAudioSource = this.GetComponent<AudioSource>();
      if ((Object) this.thisAudioSource == (Object) null)
      {
        Debug.LogError((object) ("AudioSource is not attached to" + this.name));
        Object.Destroy((Object) this);
      }
      this.thisAudioSource.loop = true;
      this.thisAudioSource.volume = 0.0f;
      this.thisAudioSource.Play();
      if ((Object) this.leftReferenceWheel == (Object) null || (Object) this.rightReferenceWheel == (Object) null)
        this.Find_Reference_Wheels();
      this.leftCircumference = 6.28318548f * this.leftReferenceWheel.GetComponent<SphereCollider>().radius;
      this.rightCircumference = 6.28318548f * this.rightReferenceWheel.GetComponent<SphereCollider>().radius;
    }

    private void Start()
    {
      this.maxSpeed = this.transform.parent.GetComponent<Wheel_Control_CS>().maxSpeed;
    }

    private void Find_Reference_Wheels()
    {
      foreach (Track_Scroll_CS componentsInChild in this.transform.parent.GetComponentsInChildren<Track_Scroll_CS>())
      {
        Rigidbody component = componentsInChild.referenceWheel.GetComponent<Rigidbody>();
        if ((double) component.transform.localPosition.y > 0.0)
          this.leftReferenceWheel = component;
        else
          this.rightReferenceWheel = component;
      }
      if (!((Object) this.leftReferenceWheel == (Object) null) && !((Object) this.rightReferenceWheel == (Object) null))
        return;
      Debug.LogError((object) "Reference Wheels are not assigned in the 'Engine_Sound'.");
      Object.Destroy((Object) this);
    }

    private void Update()
    {
      if (!(bool) (Object) this.leftReferenceWheel || !(bool) (Object) this.rightReferenceWheel)
        return;
      this.currentRate = Mathf.MoveTowards(this.currentRate, (float) (((double) this.leftReferenceWheel.angularVelocity.magnitude / 6.2831854820251465 * (double) this.leftCircumference + (double) (this.rightReferenceWheel.angularVelocity.magnitude / 6.28318548f * this.rightCircumference)) / 2.0) / this.maxSpeed, 0.02f);
      this.thisAudioSource.pitch = Mathf.Lerp(this.minPitch, this.maxPitch, this.currentRate);
      this.thisAudioSource.volume = Mathf.Lerp(this.minVolume, this.maxVolume, this.currentRate);
    }

    private void Destroy() => Object.Destroy((Object) this.gameObject);

    private void Pause(bool isPaused)
    {
      this.enabled = !isPaused;
      if (!isPaused)
        return;
      this.thisAudioSource.volume = 0.0f;
    }
  }
}
