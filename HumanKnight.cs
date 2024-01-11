using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    sealed class HumanKnight : HeavyUnit
    {
        public override Race UnitRace { get; set; } = Race.Human;
        public override int Damage { get; set; } = 17;
        public override int HP { get; set; } = 95;

        public override void Attack(Unit defender)
        {
            defender.Defend(this, Damage + Fortification);
            Fortification /= 2;
        }
    }
}
