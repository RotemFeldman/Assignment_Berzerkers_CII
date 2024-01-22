using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    struct Dice
    {
        private uint _scalar;
        private uint _baseDie;
        public int Modifier { get; private set; }

        public Dice (uint scalar, uint baseDie, int modifier)
        {
            _baseDie = baseDie;
            _scalar = scalar;
            Modifier = modifier;
        }

        public int Roll()
        {
            int ret = 0;

            for (int i = 0; i < _scalar; i++)
            {
                ret += Random.Shared.Next(1, (int)_baseDie + 1);
            }

            ret += Modifier;
            return ret;
        }

        public void SetModifier(int newModValue)
        {
            Modifier = newModValue;
        }

        public override string ToString()
        {
            if(Modifier == 0)
            {
                return $"{_scalar}d{_baseDie}";
            }
            else if (Modifier > 0) 
            {
                return $"{_scalar}d{_baseDie}+{Modifier}";
            }
            else
            {
                return $"{_scalar}d{_baseDie}{Modifier}";
            }
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            var die = (Dice)obj;

            if(_scalar == die._scalar && _baseDie == die._baseDie && Modifier == die.Modifier)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return (int)((_scalar + 10) * 17) + ((int)_baseDie * 19) + (Modifier * 114);
        }
    }
}
