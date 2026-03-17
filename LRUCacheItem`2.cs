// Decompiled with JetBrains decompiler
// Type: LRUCacheItem`2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
internal class LRUCacheItem<K, V>
{
  public K key;
  public V value;

  public LRUCacheItem(K k, V v)
  {
    this.key = k;
    this.value = v;
  }
}
