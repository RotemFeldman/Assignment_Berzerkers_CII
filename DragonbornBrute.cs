using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    sealed class DragonbornBrute : Unit
    {
        public override Race UnitRace { get; set; } = Race.Dragonborn;
        public override int Damage { get; set; } = 20;
        public override int HP { get; set; } = 55;
        

        public override void Attack(Unit defender)
        {
            defender.Defend(this, Damage);

            if (HP > 0) 
                HP += Convert.ToInt32(Damage * 0.33);
        }

        public override void Defend(Unit attacker, int dmg)
        {
            ApplyDamage(dmg);

            Damage += 2;
        }
    }
}
