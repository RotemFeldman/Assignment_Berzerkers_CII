using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    sealed class HumanKnight : HeavyUnit
    {       

        public HumanKnight(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating) : base(damage, hitChance, defenseRating)
        { 
            UnitRace = Race.Human;
            Damage = new Dice(3, 6, Fortification);
            HP = 95;
            CarryCapacity = 20;
            HitChance = new Dice(1,10, +1);
            DefenseRating = new Dice(1,10,Fortification);
            Name = "Human Knight";
        }

        public override void Attack(Unit defender)
        {
            AttackPrompt(defender);
            if (!HitChanceCheck(defender))
                return;

            defender.Defend(this);

            Fortification++;
            //Damage.SetModifier(Fortification);
        }
    }
}
