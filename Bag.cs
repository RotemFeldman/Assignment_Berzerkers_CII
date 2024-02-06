using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    public struct Bag : IRandomProvider , IEquatable<Bag>
    {
        private int[] _array;
        private List<int> _bag;

        public Bag(params int[] array) 
        {
            _array = BubbleSortArray(array);
            _bag = new List<int>(_array);
        }

        public int Roll()
        {
            if (!BagNotEmpty())
                RefillBag();
            

            int rnd = Random.Shared.Next(_bag.Count);

            int ret = _bag[rnd];
            _bag.RemoveAt(rnd);
            
            return ret;
        }



        public override string ToString()
        {

            // change to stringbuilder
            string ret = string.Empty;
            for(int i = 0; i < _bag.Count - 1; i++)
            {
                ret += _bag[i].ToString() + ", ";
            }
            ret += _bag[_bag.Count -1];

            return ret;
        }

        public override int GetHashCode()
        {
            int ret = 0;
            for (int i = 0; i< _array.Length;i++)
            {
                ret += 171 * _array[i];
            }
            return ret;
        }

        public bool Equals(Bag other)
        {
            if (_array.Length != other._array.Length)
                return false;

            // how can i put array on stack?
            //int[] array = BubbleSortArray(_array);
            //int[] otherArray = BubbleSortArray(other._array);

            for(int i = 0; i < _array.Length ; i++)
            {
                if (_array[i] != other._array[i])
                    return false;
            }

            return true;
            
        }



        private bool BagNotEmpty()
        {
            return _bag.Count > 0;
        }

        private void RefillBag()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _bag.Add(_array[i]);
            }

        }

        private int[] BubbleSortArray(int[] array)
        {
            int[] newArray = array;
            var n = array.Length;

            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (newArray[j] > newArray[j + 1])
                    {
                        var tempVar = newArray[j];
                        newArray[j] = newArray[j + 1];
                        newArray[j + 1] = tempVar;
                    }
            return newArray;
        }
    }
}
