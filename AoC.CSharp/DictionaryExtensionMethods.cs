using System.Collections.Generic;
using System.Linq.Expressions;

namespace AoC.CSharp
{
    public static class DictionaryExtensionMethods
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            if (dict.TryGetValue(key, out var v))
                return v;
            
            return default(TValue);
        }
    }
}