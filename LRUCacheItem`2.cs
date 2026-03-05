// Decompiled with JetBrains decompiler
// Type: LRUCacheItem`2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
