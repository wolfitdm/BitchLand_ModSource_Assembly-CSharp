// Decompiled with JetBrains decompiler
// Type: int_obtainhiddenresource
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class int_obtainhiddenresource : bl_MinableObject
{
  public override void Interact(Person person)
  {
    base.Interact(person);
    if (!this._StartedMining)
      return;
    person.gameObject.SetActive(false);
  }

  public override void StopInteracting()
  {
    this.InteractingPerson.gameObject.SetActive(true);
    base.StopInteracting();
  }

  public override void FinishMining()
  {
    this.InteractingPerson.gameObject.SetActive(true);
    base.FinishMining();
  }

  public override void CancelMining()
  {
    this.InteractingPerson.gameObject.SetActive(true);
    base.FinishMining();
  }
}
