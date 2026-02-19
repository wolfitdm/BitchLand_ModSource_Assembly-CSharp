// Decompiled with JetBrains decompiler
// Type: CharacterLOD
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CharacterLOD : MonoBehaviour
{
  public Person ThisPerson;
  public bool IsVisible;
  public int PerFrame;
  public int FramesPassed;
  public bool DistanceOnly;
  public bool ChangedState;

  public void Start() => this.PerFrame = Random.Range(5, 10);

  private void Update()
  {
    if (!this.IsVisible || ++this.FramesPassed < this.PerFrame)
      return;
    this.FramesPassed = 0;
    float num = Vector2.Distance(new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z), new Vector2(this.ThisPerson.transform.position.x, this.ThisPerson.transform.position.z));
    switch (this.ThisPerson.CurrentLOD)
    {
      case 0:
        if ((double) num >= 30.0 || !this.IsRaycastVisible(true))
          break;
        if ((double) num < 5.0)
        {
          this.ThisPerson.SetHighLod();
          break;
        }
        this.ThisPerson.SetLowLod();
        break;
      case 1:
        if ((double) num > 30.0 || !this.IsRaycastVisible(true))
        {
          this.ThisPerson.SetCullLod(true);
          break;
        }
        if ((double) num >= 5.0)
          break;
        this.ThisPerson.SetHighLod();
        break;
      case 2:
        if (!this.IsRaycastVisible())
        {
          this.ThisPerson.SetCullLod();
          break;
        }
        if ((double) num <= 5.0)
          break;
        this.ThisPerson.SetLowLod();
        break;
    }
  }

  public bool IsRaycastVisible(bool simple = false)
  {
    return this.DistanceOnly || Main.Instance.Player.Eyes.CanSeePerson(this.ThisPerson, simple, false) != 0;
  }

  public void OnBecameInvisible()
  {
    if (!this.enabled)
      return;
    this.IsVisible = false;
    this.ThisPerson.SetCullLod((double) Vector2.Distance(new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z), new Vector2(this.ThisPerson.transform.position.x, this.ThisPerson.transform.position.z)) >= 10.0);
  }

  public void OnBecameVisible()
  {
    if (!this.enabled)
      return;
    this.IsVisible = true;
    this.FramesPassed = 100;
    float num = Vector2.Distance(new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z), new Vector2(this.ThisPerson.transform.position.x, this.ThisPerson.transform.position.z));
    if ((double) num >= 50.0 || !this.IsRaycastVisible())
      return;
    if ((double) num < 5.0)
      this.ThisPerson.SetHighLod();
    else
      this.ThisPerson.SetLowLod();
  }
}
