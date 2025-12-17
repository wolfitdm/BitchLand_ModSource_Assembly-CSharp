// Decompiled with JetBrains decompiler
// Type: penischas_dess
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class penischas_dess : Dressable
{
  public override void OnDressed()
  {
    base.OnDressed();
    this.BoneStorage[0].SetParent(this.PersonEquipped.PenisBones[0].parent);
    this.BoneStorage[1].SetParent(this.PersonEquipped.PenisBones[1]);
    this.BoneStorage[2].SetParent(this.PersonEquipped.PenisBones[2]);
    this.BoneStorage[3].SetParent(this.PersonEquipped.PenisBones[3]);
    this.BoneStorage[4].SetParent(this.PersonEquipped.PenisBones[4]);
    this.BoneStorage[0].localEulerAngles = Vector3.zero;
    this.BoneStorage[0].localPosition = Vector3.zero;
    this.BoneStorage[1].localEulerAngles = Vector3.zero;
    this.BoneStorage[1].localPosition = Vector3.zero;
    this.BoneStorage[2].localEulerAngles = Vector3.zero;
    this.BoneStorage[2].localPosition = Vector3.zero;
    this.BoneStorage[3].localEulerAngles = Vector3.zero;
    this.BoneStorage[3].localPosition = Vector3.zero;
    this.BoneStorage[4].localEulerAngles = Vector3.zero;
    this.BoneStorage[4].localPosition = Vector3.zero;
    this.PersonEquipped.PenisBones[1].gameObject.SetActive(false);
    this.PersonEquipped.PenisBones[1].localPosition = new Vector3(0.0f, 0.0019f, -0.0031f);
    this.PersonEquipped.PenisBones[1].localEulerAngles = new Vector3(93.46399f, 0.0f, 0.0f);
    this.PersonEquipped.PenisBones[2].localPosition = new Vector3(0.0f, 0.02f, 0.0f);
    this.PersonEquipped.PenisBones[2].localEulerAngles = new Vector3(20.331f, 0.0f, 0.0f);
    this.PersonEquipped.PenisBones[3].localPosition = new Vector3(0.0f, 0.02f, 0.0f);
    this.PersonEquipped.PenisBones[3].localEulerAngles = new Vector3(30.063f, 0.0f, 0.0f);
    this.PersonEquipped.PenisBones[4].localPosition = new Vector3(0.0f, 0.02f, 0.0f);
    this.PersonEquipped.PenisBones[4].localEulerAngles = new Vector3(23.033f, 0.0f, 0.0f);
  }

  public override void OnUndressed()
  {
    base.OnUndressed();
    this.PersonEquipped.PenisBones[1].gameObject.SetActive(true);
  }
}
