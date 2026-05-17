// Decompiled with JetBrains decompiler
// Type: LRUCacheItem`2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
