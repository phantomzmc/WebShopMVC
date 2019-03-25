using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesWeb1
{
    public class TypeProductList : IDictionary<int, TypeProductList.TypeProduct>
    {
        public Dictionary<int, TypeProductList.TypeProduct> _typeorder = new Dictionary<int, TypeProduct>();

        #region Imprement
        public TypeProduct this[int key] { get => ((IDictionary<int, TypeProduct>)_typeorder)[key]; set => ((IDictionary<int, TypeProduct>)_typeorder)[key] = value; }

        public ICollection<int> Keys => ((IDictionary<int, TypeProduct>)_typeorder).Keys;

        public ICollection<TypeProduct> Values => ((IDictionary<int, TypeProduct>)_typeorder).Values;

        public int Count => ((IDictionary<int, TypeProduct>)_typeorder).Count;

        public bool IsReadOnly => ((IDictionary<int, TypeProduct>)_typeorder).IsReadOnly;

        public void Add(int key, TypeProduct value)
        {
            ((IDictionary<int, TypeProduct>)_typeorder).Add(key, value);
        }

        public void Add(KeyValuePair<int, TypeProduct> item)
        {
            ((IDictionary<int, TypeProduct>)_typeorder).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<int, TypeProduct>)_typeorder).Clear();
        }

        public bool Contains(KeyValuePair<int, TypeProduct> item)
        {
            return ((IDictionary<int, TypeProduct>)_typeorder).Contains(item);
        }

        public bool ContainsKey(int key)
        {
            return ((IDictionary<int, TypeProduct>)_typeorder).ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<int, TypeProduct>[] array, int arrayIndex)
        {
            ((IDictionary<int, TypeProduct>)_typeorder).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<int, TypeProduct>> GetEnumerator()
        {
            return ((IDictionary<int, TypeProduct>)_typeorder).GetEnumerator();
        }

        public bool Remove(int key)
        {
            return ((IDictionary<int, TypeProduct>)_typeorder).Remove(key);
        }

        public bool Remove(KeyValuePair<int, TypeProduct> item)
        {
            return ((IDictionary<int, TypeProduct>)_typeorder).Remove(item);
        }

        public bool TryGetValue(int key, out TypeProduct value)
        {
            return ((IDictionary<int, TypeProduct>)_typeorder).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<int, TypeProduct>)_typeorder).GetEnumerator();
        }

        #endregion
        public class TypeProduct
        {
        }
    }
    
}