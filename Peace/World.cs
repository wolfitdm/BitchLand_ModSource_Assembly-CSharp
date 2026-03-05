// Decompiled with JetBrains decompiler
// Type: Peace.World
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Peace.Serialization;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Peace
{
  public class World : IDisposable
  {
    internal IntPtr _handle;

    public static World CreateDemo(string demoId) => new World(World.createDemoWorld(demoId));

    private World(IntPtr handle) => this._handle = handle;

    ~World()
    {
      if (!(this._handle != IntPtr.Zero))
        return;
      World.freeWorld(this._handle);
    }

    public World(string configFile) => this._handle = World.createWorldFromFile(configFile);

    public World(WorldDef worldDef)
    {
      this._handle = World.createWorldFromJson(WorldSerialization.ToJson((object) worldDef));
    }

    public void Dispose()
    {
      if (!(this._handle != IntPtr.Zero))
        return;
      World.freeWorld(this._handle);
      this._handle = IntPtr.Zero;
    }

    public void SetCacheLocation(string cacheLocation)
    {
      this.CheckAccess();
      World.setWorldCache(this._handle, cacheLocation);
    }

    private void CheckAccess()
    {
      if (this._handle == IntPtr.Zero)
        throw new MethodAccessException("This object was deleted manually");
    }

    [DllImport("peace")]
    private static extern IntPtr createTestWorld();

    [DllImport("peace")]
    private static extern IntPtr createDemoWorld(string name);

    [DllImport("peace")]
    private static extern IntPtr createWorldFromJson(string jsonStr);

    [DllImport("peace")]
    private static extern IntPtr createWorldFromFile(string name);

    [DllImport("peace")]
    private static extern void setWorldCache(IntPtr worldPtr, string cacheLocation);

    [DllImport("peace")]
    private static extern void freeWorld(IntPtr handle);
  }
}
