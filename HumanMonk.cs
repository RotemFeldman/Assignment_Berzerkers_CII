using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    sealed class HumanMonk : Unit
    {
        public HumanMonk() { 
            UnitRace = Race.Human;
            Damage = 9;
            HP = 65;
            ChanceToActivateAbility = 0.1f;
        }

        public override void Attack(Unit defender)
        {
            defender.Defend(this,Damage);
            defender.Defend(this, (Damage -4) * 2);
            defender.Defend(this, (Damage - 9) * 4);
        }

        public override void Defend(Unit attacker, int dmg)
        {
            if (CheckAbility())
            {
                Damage++;
                Console.WriteLine("Guarded");
                return;
            }

            ApplyDamage(dmg);
        }
    }
}
