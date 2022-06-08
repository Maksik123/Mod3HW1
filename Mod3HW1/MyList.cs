using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3HW1
{
    public class MyList<T> : IReadOnlyCollection<T>
    {
        private const int DefaultCapacity = 4;
        private const int IncreaseRate = 2;

        private T[] _array;
        private int _capacity;

        public MyList(int capacity)
        {
            _capacity = capacity;
            _array = new T[_capacity];
        }

        public MyList()
            : this(DefaultCapacity)
        {
        }
        public int Capacity
        {
            get => _capacity;
            set { }
        }

        public int Count { get; set; }

        public void Add(T item)
        {
            if (Count == Capacity)
            {
                IncreaseCapacity();
            }
            _array[Count] = item;
            Count++;
        }

        public void AddRange(IEnumerable<T> items)
        {
            var TotalCapacity = Count + items.Count();
            if (TotalCapacity >= Capacity)
            {
                IncreaseCapacity();
                foreach (var i in items)
                {
                    _array[Count] = i;
                    Count++;
                }
            }
            if (TotalCapacity < Capacity)
            {
                foreach (var i in items)
                {
                    _array[Count] = i;
                    Count++;
                }
            }
        }

        private void ShiftArray(int ShiftAmount, int index)
        {
            for (var i = index; i < Count - 1; i++)
            {
                _array[i] = _array[i + ShiftAmount];
            }
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_array[i].Equals(item))
                {
                    var IsTrue = RemoveAt(i);
                    if (!IsTrue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool RemoveAt(int index)
        {
            if (index > Count || index < 0)
            {
                return false;
            }
            var LastIndexOfArray = Count - 1;
            ShiftArray(1, index);
            _array[LastIndexOfArray] = default;
            Count--;

            return true;
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_array, comparer);
        }
        private void IncreaseCapacity()
        {
            Capacity *= IncreaseRate;
            var newArray = _array;
            _array = new T[Capacity];

            for (var i = 0; i < newArray.Length; i++)
            {
                _array[i] = newArray[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        private IEnumerator<T> GetGenericEnumerator()
        {
            foreach (var item in _array)
            {
                if (!item.Equals(default(T)))
                {
                    yield return item;
                }
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetGenericEnumerator();
        }
    }
}
