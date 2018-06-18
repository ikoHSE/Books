using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Container<T> : IEnumerable<T> where T : IComparable<T>
    {
        public void Add(T element)
        {
            if (!elements.Contains(element))
            {
                elements.Add(element);
            }
        }
        protected List<T> elements = new List<T>();
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
