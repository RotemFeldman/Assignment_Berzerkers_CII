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
        private int _modifier;

        public Dice (uint scalar, uint baseDie, int modifier)
        {
            _baseDie = baseDie;
            _scalar = scalar;
            _modifier = modifier;
        }

        public int Roll()
        {
            int ret = 0;

            for (int i = 0; i < _scalar; i++)
            {
                ret += Random.Shared.Next(1, (int)_baseDie + 1);
            }

            ret += _modifier;
            return ret;
        }

        public void UpdateModifier(int newModValue)
        {
            _modifier = newModValue;
        }

        public override string ToString()
        {
            if(_modifier == 0)
            {
                return $"{_scalar}d{_baseDie}";
            }
            else if (_modifier > 0) 
            {
                return $"{_scalar}d{_baseDie}+{_modifier}";
            }
            else
            {
                return $"{_scalar}d{_baseDie}{_modifier}";
            }
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            var die = (Dice)obj;

            if(_scalar == die._scalar && _baseDie == die._baseDie && _modifier == die._modifier)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return (int)((_scalar + 10) * 17) + ((int)_baseDie * 19) + (_modifier * 114);
        }
    }
}
