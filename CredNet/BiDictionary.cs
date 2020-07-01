using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredNet
{
    internal class BiDictionary<TKey, TValue>
    {
        protected Dictionary<TKey, TValue> ForwardCollection { get; set; } = new Dictionary<TKey, TValue>();
        protected Dictionary<TValue, TKey> BackwardCollection { get; set; } = new Dictionary<TValue, TKey>();

        public Indexer<TKey, TValue> Forward { get; }
        public Indexer<TValue, TKey> Backward { get; }

        public BiDictionary()
        {
            Forward = new Indexer<TKey, TValue>(ForwardCollection);
            Backward = new Indexer<TValue, TKey>(BackwardCollection);
        }

        public void Add(TKey key, TValue value)
        {
            ForwardCollection.Add(key, value);
            BackwardCollection.Add(value, key);
        }

        public void Remove(TKey key)
        {
            BackwardCollection.Remove(ForwardCollection[key]);
            ForwardCollection.Remove(key);
        }

        public TValue this[TKey key]
        {
            get => Forward[key];
        }

        public class Indexer<TKey, TValue>
        {
            private readonly IDictionary<TKey, TValue> mTarget;
            
            public Indexer(IDictionary<TKey, TValue> dic)
            {
                mTarget = dic;
            }

            public bool TryGetValue(TKey key, out TValue value)
            {
                return mTarget.TryGetValue(key, out value);
            }

            public TValue this[TKey index]
            {
                get => mTarget[index];
            }
        }
    }
}
