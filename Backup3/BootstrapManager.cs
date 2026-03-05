// Decompiled with JetBrains decompiler
// Type: BootstrapManager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class BootstrapManager : MonoBehaviour
{
  public void Scene1() => SceneManager.LoadScene("Example Scene");

  public void Scene2() => SceneManager.LoadScene("Example1 Scene");
}
