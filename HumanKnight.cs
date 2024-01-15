using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    sealed class HumanKnight : HeavyUnit
    {
        public HumanKnight() { 
            UnitRace = Race.Human;
            Damage = 17;
            HP = 95;
        }

        public override void Attack(Unit defender)
        {
            defender.Defend(this, Damage + Fortification);
            Fortification /= 2;
        }
    }
}
