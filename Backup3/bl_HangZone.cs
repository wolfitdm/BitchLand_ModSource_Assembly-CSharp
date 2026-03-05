// Decompiled with JetBrains decompiler
// Type: bl_HangZone
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

#nullable disable
public class bl_HangZone : MonoBehaviour
{
  public Transform Location;
  public List<Interactible> ThingsToDo = new List<Interactible>();
  public List<Person> PeopleInZone = new List<Person>();
  public List<List<GameObject>> PeopleInZone_EnteredFrom = new List<List<GameObject>>();
  public List<GameObject> ZoneColliders = new List<GameObject>();
  public Int_Door Door;
  public bool UnSafe;
  public bool SafeHouse;
  public List<Transform> SexSpots = new List<Transform>();
  public e_HangZoneType HangZoneType;
  public List<bl_HangZone> LinkedHangZones = new List<bl_HangZone>();
  public List<Person> Owners = new List<Person>();
  public float DistanceSize;
  public bool AllowWondering;

  public void Start()
  {
    for (int index = 0; index < this.ZoneColliders.Count; ++index)
    {
      if ((Object) this.ZoneColliders[index] != (Object) null)
      {
        MeshRenderer component = this.ZoneColliders[index].GetComponent<MeshRenderer>();
        if ((Object) component != (Object) null)
          component.enabled = false;
      }
    }
  }

  public void AddThingDoZone(Interactible interactible)
  {
    if (this.ThingsToDo.Contains(interactible))
      return;
    this.ThingsToDo.Add(interactible);
  }

  public Interactible PickThingToDo(Person person, out Vector3 wonderSpot, out NavMeshPath path)
  {
    wonderSpot = Vector3.zero;
    path = (NavMeshPath) null;
    int[] array = new int[this.ThingsToDo.Count];
    for (int index = 0; index < array.Length; ++index)
      array[index] = index;
    bl_HangZone.Shuffle(ref array);
    if ((double) Random.Range(0.0f, 1f) > 0.5)
    {
      for (int index = 0; index < this.ThingsToDo.Count; ++index)
      {
        if ((Object) this.ThingsToDo[index] != (Object) null && this.ThingsToDo[index].OffersFetishes != null && this.ThingsToDo[index].OffersFetishes.Intersect<e_Fetish>((IEnumerable<e_Fetish>) person.Fetishes).Any<e_Fetish>())
          return this.ThingsToDo[index];
      }
    }
    for (int index = 0; index < this.ThingsToDo.Count; ++index)
    {
      if ((Object) this.ThingsToDo[index] != (Object) null && this.ThingsToDo[array[index]].CheckCanInteract(person) && this.ThingsToDo[array[index]].CanInteract && !this.ThingsToDo[array[index]].AnyoneGoingToIt)
        return this.ThingsToDo[array[index]];
    }
    Vector3 result;
    NavMeshPath resultPath;
    if (!this.AllowWondering || !bl_HangZone.RandomPointOnNavMesh(person.navMesh, this.Location.position, this.DistanceSize, out result, out resultPath))
      return (Interactible) null;
    wonderSpot = result;
    path = resultPath;
    return (Interactible) null;
  }

  public static void Shuffle(ref int[] array)
  {
    int length = array.Length;
    while (length > 1)
    {
      --length;
      int index = Random.Range(0, length + 1);
      int num = array[index];
      array[index] = array[length];
      array[length] = num;
    }
  }

  public void EnterZone(Person person)
  {
    if (!this.PeopleInZone.Contains(person))
    {
      this.PeopleInZone.Add(person);
      this.PeopleInZone_EnteredFrom.Add(new List<GameObject>()
      {
        this.gameObject
      });
    }
    else
      this.PeopleInZone_EnteredFrom[this.PeopleInZone.IndexOf(person)].Add(this.gameObject);
    if (this.UnSafe)
    {
      person.ProxSeen.AddEnabler("UnsafeArea");
      if (person.IsPlayer)
      {
        Main.Instance.GameplayMenu.ShowNotification("Unsafe area, be careful");
        Main.Instance.GameplayMenu.WarningIcon.SetActive(true);
      }
    }
    else
    {
      person.ProxSeen.RemoveEnabler("UnsafeArea");
      if (person.IsPlayer)
      {
        Main.Instance.GameplayMenu.WarningIcon.SetActive(false);
        Main.Instance.GameplayMenu.HomeIcon.SetActive(this.SafeHouse);
      }
    }
    person.CurrentZone = this;
  }

  public void ExitZone(Person person)
  {
    int index = this.PeopleInZone.IndexOf(person);
    if (this.PeopleInZone_EnteredFrom.Count >= index || this.PeopleInZone_EnteredFrom[index] == null)
      return;
    this.PeopleInZone_EnteredFrom[index].Remove(this.gameObject);
    if (this.PeopleInZone_EnteredFrom[index].Count != 0)
      return;
    this.PeopleInZone_EnteredFrom.RemoveAt(index);
    this.PeopleInZone.Remove(person);
    if (!person.IsPlayer)
      return;
    Main.Instance.GameplayMenu.HomeIcon.SetActive(false);
  }

  public void DetectNearbyInteractibles()
  {
    foreach (Component component in Physics.OverlapSphere(this.transform.position, this.DistanceSize))
      this.ThingsToDo.AddRange((IEnumerable<Interactible>) component.GetComponentsInChildren<bl_HangFurniture>());
  }

  public static bool RandomPointOnNavMesh(
    NavMeshAgent person,
    Vector3 center,
    float distance,
    out Vector3 result,
    out NavMeshPath resultPath,
    int areaMask = -1)
  {
    NavMeshPath path = new NavMeshPath();
    for (int index = 0; index < 30; ++index)
    {
      NavMeshHit hit;
      if (NavMesh.SamplePosition(center + Random.insideUnitSphere * distance, out hit, distance, areaMask))
      {
        person.CalculatePath(hit.position, path);
        if (path.status == NavMeshPathStatus.PathComplete)
        {
          result = hit.position;
          resultPath = path;
          return true;
        }
      }
    }
    result = Vector3.zero;
    resultPath = (NavMeshPath) null;
    return false;
  }
}
