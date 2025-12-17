// Decompiled with JetBrains decompiler
// Type: MTDispatch
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class MTDispatch : MonoBehaviour
{
  private static readonly Queue<Action> _executionQueue = new Queue<Action>();
  private static MTDispatch _instance = (MTDispatch) null;

  public void Update()
  {
    lock (MTDispatch._executionQueue)
    {
      while (MTDispatch._executionQueue.Count > 0)
        MTDispatch._executionQueue.Dequeue()();
    }
  }

  public void Enqueue(IEnumerator action)
  {
    lock (MTDispatch._executionQueue)
      MTDispatch._executionQueue.Enqueue((Action) (() => this.StartCoroutine(action)));
  }

  public void Enqueue(Action action) => this.Enqueue(this.ActionWrapper(action));

  private IEnumerator ActionWrapper(Action a)
  {
    a();
    yield return (object) null;
  }

  public static bool Exists() => (UnityEngine.Object) MTDispatch._instance != (UnityEngine.Object) null;

  public static MTDispatch Instance()
  {
    if (!MTDispatch.Exists())
      throw new Exception("MTDispatch could not find the MTDispatch object. Please ensure you have added the MainThreadExecutor Prefab to your scene.");
    return MTDispatch._instance;
  }

  private void Awake()
  {
    if (!((UnityEngine.Object) MTDispatch._instance == (UnityEngine.Object) null))
      return;
    MTDispatch._instance = this;
    UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) this.gameObject);
  }

  private void OnDestroy() => MTDispatch._instance = (MTDispatch) null;
}
