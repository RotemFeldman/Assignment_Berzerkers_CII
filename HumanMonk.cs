using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    sealed class HumanMonk : Unit
    {
        public override Race UnitRace { get; set; } = Race.Human;
        public override int Damage { get; set; } = 9;
        public override int HP { get; set; } = 65;
        public override float ChanceToActivateAbility { get; set; } = 0.1f;

        public override void Attack(Unit defender, int dmg)
        {
            defender.Defend(this,dmg);
            defender.Defend(this, (dmg -4) * 2);
            defender.Defend(this, (dmg - 9) * 4);
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
