using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredNet
{
    public class DataBindingCollection : ICollection<Binder>
    {
        private List<Binder> List { get; set; } = new List<Binder>();

        public object DataSource { get; }

        public object DataContext { get; set; }

        public DataBindingCollection(object sourceObject)
        {
            DataSource = sourceObject;
        }

        public void SetDataContext(object data) => DataContext = data;

        public IEnumerator<Binder> GetEnumerator() => List.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => List.GetEnumerator();

        public void Add(Binder item) => List.Add(item);

        public void Add(string sourceProperty, string destinationProperty, BindMode mode = BindMode.OneWay)
        {
            Add(new Binder(sourceProperty, DataSource, destinationProperty, DataContext, mode));
        }

        public void Clear() => List.Clear();

        public bool Contains(Binder item) => List.Contains(item);

        public void CopyTo(Binder[] array, int arrayIndex) => List.CopyTo(array, arrayIndex);

        public bool Remove(Binder item) => List.Remove(item);

        public int Count => List.Count;
        public bool IsReadOnly => false;
    }
}
