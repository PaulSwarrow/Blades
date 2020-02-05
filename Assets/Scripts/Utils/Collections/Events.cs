using System.Collections.Generic;

public delegate void DictionaryChangedEventHandler<TKey, TValue>(TKey[] keys, TValue[] values);
