// Decompiled with JetBrains decompiler
// Type: SimpleInteract
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SimpleInteract : Interactible
{
  public MonoBehaviour[] OnIntereact_Enable;
  public MonoBehaviour[] OnIntereact_Disable;
  public MonoBehaviour[] OnStopIntereact_Enable;
  public MonoBehaviour[] OnStopIntereact_Disable;
  public GameObject[] OnIntereact_Enable_GM;
  public GameObject[] OnIntereact_Disable_GM;
  public GameObject[] OnStopIntereact_Enable_GM;
  public GameObject[] OnStopIntereact_Disable_GM;

  public override void Interact(Person person)
  {
    base.Interact(person);
    for (int index = 0; index < this.OnIntereact_Enable.Length; ++index)
      this.OnIntereact_Enable[index].enabled = true;
    for (int index = 0; index < this.OnIntereact_Disable.Length; ++index)
      this.OnIntereact_Disable[index].enabled = false;
    for (int index = 0; index < this.OnIntereact_Enable_GM.Length; ++index)
      this.OnIntereact_Enable_GM[index].SetActive(true);
    for (int index = 0; index < this.OnIntereact_Disable_GM.Length; ++index)
      this.OnIntereact_Disable_GM[index].SetActive(false);
  }

  public override void StopInteracting()
  {
    base.StopInteracting();
    for (int index = 0; index < this.OnStopIntereact_Enable.Length; ++index)
      this.OnStopIntereact_Enable[index].enabled = true;
    for (int index = 0; index < this.OnStopIntereact_Disable.Length; ++index)
      this.OnStopIntereact_Disable[index].enabled = false;
    for (int index = 0; index < this.OnStopIntereact_Enable_GM.Length; ++index)
      this.OnStopIntereact_Enable_GM[index].SetActive(true);
    for (int index = 0; index < this.OnStopIntereact_Disable_GM.Length; ++index)
      this.OnStopIntereact_Disable_GM[index].SetActive(false);
  }
}
