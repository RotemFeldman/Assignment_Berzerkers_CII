using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    internal class HumanMonk : Unit
    {
        public override Race UnitRace { get; set; } = Race.Human;

        public HumanMonk(int damage, int hp, float chanceToGuard) : base(damage, hp)
        {
            ChanceToActivateAbility = chanceToGuard;
        }

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
