using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    sealed class HumanMonk : Unit
    {
        public HumanMonk(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating) : base(damage, hitChance, defenseRating) 
        { 
            UnitRace = Race.Human;
            Damage = new Dice(3, 4, +1);
            HP = 65;
            CarryCapacity = 10;
            HitChance = new Dice(3, 6, +3);
            DefenseRating = new Dice(2,6,0);
            Name = "Humanm Monk";
        }

        public override void Attack(Unit defender)
        {
            AttackPrompt(defender);
            if(!HitChanceCheck(defender))
            { return; }

            //int originalMod = Damage.Modifier;

            defender.Defend(this);
            //Damage.SetModifier(Damage.Modifier * 2);
            defender.Defend(this);
            //Damage.SetModifier(Damage.Modifier * 4);
            defender.Defend(this);

            //Damage.SetModifier(originalMod);
        }

        public override void Defend(Unit attacker)
        {
            int dmg = attacker.Damage.Roll();

            DefensePrompt(attacker, dmg);

            ApplyDamage(dmg);
            //Damage.SetModifier(Damage.Modifier + 2) ;
        }
    }
}
