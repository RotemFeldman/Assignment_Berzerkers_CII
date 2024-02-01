using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    public struct Bag : IRandomProvider
    {
        private int[] _array;
        private List<int> _bag;

        public Bag(params int[] array) 
        {
            _array = array;
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


        private bool BagNotEmpty()
        {
            return _bag.Count > 0;
        }

        private void RefillBag()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _bag[i] = _array[i];
            }

        }
    }
}
