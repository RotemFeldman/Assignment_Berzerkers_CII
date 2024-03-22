using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    class Dice<T> : IRandomProvider<T> , IComparable<T> where T : IComparable<T> 
    {
        private T[] _dieFaces;

        public Dice (params T[] faces)
        {
            _dieFaces = faces;
        }

        public virtual T GetRandom()
        {
            return Roll();
        }

        protected virtual T Roll()
        {           
            int index = Random.Shared.Next(_dieFaces.Length);

            return _dieFaces[index];
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var face in _dieFaces)
            {
                sb.Append(face).Append(", ");
            }

            return sb.ToString().TrimEnd(',', ' ');
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null) 
                throw new ArgumentNullException(nameof(obj));

            var die = (Dice<T>)obj;

            if (die == null) return false;


            return _dieFaces.Equals(die._dieFaces);
        }

        public override int GetHashCode()
        {
            int ret = 0;

            foreach (var item in _dieFaces)
            {
                ret += 17 + item.GetHashCode();
            }

            return ret;
        }

        public int CompareTo(T? other)
        {
            if(other == null)
                return 1;

            return this.Roll().CompareTo(other);
        }
    }
}
