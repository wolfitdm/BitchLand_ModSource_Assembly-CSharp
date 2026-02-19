// Decompiled with JetBrains decompiler
// Type: LRUCacheDictionary`2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
public class LRUCacheDictionary<K, V>
{
  private int capacity;
  private Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>> cacheMap = new Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>>();
  private LinkedList<LRUCacheItem<K, V>> lruList = new LinkedList<LRUCacheItem<K, V>>();

  public LRUCacheDictionary(int capacity) => this.capacity = capacity;

  [MethodImpl(MethodImplOptions.Synchronized)]
  public V Get(K key)
  {
    LinkedListNode<LRUCacheItem<K, V>> node;
    if (!this.cacheMap.TryGetValue(key, out node))
      return default (V);
    V v = node.Value.value;
    this.lruList.Remove(node);
    this.lruList.AddLast(node);
    return v;
  }

  [MethodImpl(MethodImplOptions.Synchronized)]
  public void Add(K key, V val)
  {
    if (this.cacheMap.Count >= this.capacity)
      this.RemoveFirst();
    LinkedListNode<LRUCacheItem<K, V>> node = new LinkedListNode<LRUCacheItem<K, V>>(new LRUCacheItem<K, V>(key, val));
    this.lruList.AddLast(node);
    this.cacheMap.Add(key, node);
  }

  private void RemoveFirst()
  {
    LinkedListNode<LRUCacheItem<K, V>> first = this.lruList.First;
    this.lruList.RemoveFirst();
    this.cacheMap.Remove(first.Value.key);
  }
}
