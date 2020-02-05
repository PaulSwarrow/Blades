using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
{
    public ObservableDictionary() : base() { }
    public ObservableDictionary(int capacity) : base(capacity) { }
    public ObservableDictionary(IEqualityComparer<TKey> comparer) : base(comparer) { }
    public ObservableDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary) { }
    public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer) { }
    public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) : base(dictionary, comparer) { }

    public event DictionaryChangedEventHandler<TKey, TValue> ItemsAdded;
    public event DictionaryChangedEventHandler<TKey, TValue> ItemsRemoved;
    public event DictionaryChangedEventHandler<TKey, TValue> ItemsUpdated;

    public new TValue this[TKey key]
    {
        get
        {
            return base[key];
        }
        set
        {
            TValue oldValue;
            bool exist = base.TryGetValue(key, out oldValue);
            var oldItem = new KeyValuePair<TKey, TValue>(key, oldValue);
            base[key] = value;
            var newItem = new KeyValuePair<TKey, TValue>(key, value);
            if (exist)
            {
                NotifyItemChange(new TKey[] { key }, new TValue[] { value });
            }
            else
            {
                NotifyItemAdd(new TKey[]{ key }, new TValue[]{ value });
            }
        }
    }

    public new void Add(TKey key, TValue value)
    {
        if (!base.ContainsKey(key))
        {
            var item = new KeyValuePair<TKey, TValue>(key, value);
            base.Add(key, value);
            NotifyItemAdd(new TKey[] { key }, new TValue[] { value });
        }
    }

    public new bool Remove(TKey key)
    {
        TValue value;
        if (base.TryGetValue(key, out value))
        {
            var item = new KeyValuePair<TKey, TValue>(key, base[key]);
            bool result = base.Remove(key);
            NotifyItemRemove(new TKey[] { key }, new TValue[] { value });
            return result;
        }
        return false;
    }

    public new void Clear()
    {
        TKey[] keys = Keys.ToArray();
        TValue[] values = Values.ToArray();
        base.Clear();
        NotifyItemRemove(keys, values);
    }

    protected virtual void NotifyItemAdd(TKey[] keys, TValue[] values)
    {
        if (ItemsAdded != null)
        {
            ItemsAdded(keys, values);
        }
    }
    protected virtual void NotifyItemChange(TKey[] keys, TValue[] values)
    {
        if (ItemsUpdated != null)
        {
            ItemsUpdated(keys, values);
        }
    }
    protected virtual void NotifyItemRemove(TKey[] keys, TValue[] values)
    {
        if (ItemsRemoved != null)
        {
            ItemsRemoved(keys, values);
        }
    }

}