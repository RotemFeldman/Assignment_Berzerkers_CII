﻿using System;
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

            List<int> objList = new List<int>(other._array);

            for (int i = 0; i > _array.Length; i++)
            {
                for (int j = 0; j < objList.Count; j++)
                {

                    if (_array[i] == objList[j])
                    {
                        objList.Remove(j);
                        break;
                    }
                }
            }

            if (objList.Count == 0)
                return true;
            else
                return false;
        }
    }
}