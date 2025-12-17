// Decompiled with JetBrains decompiler
// Type: LRUCacheItem`2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
