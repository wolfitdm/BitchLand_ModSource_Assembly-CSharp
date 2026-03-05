// Decompiled with JetBrains decompiler
// Type: BootstrapManager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class BootstrapManager : MonoBehaviour
{
  public void Scene1() => SceneManager.LoadScene("Example Scene");

  public void Scene2() => SceneManager.LoadScene("Example1 Scene");
}
