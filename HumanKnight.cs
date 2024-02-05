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
            HP = 95;
            CarryCapacity = 20;
            Name = "Human Knight";
        }

        public HumanKnight() : base()
        {
            UnitRace = Race.Human;
            HP = 95;
            CarryCapacity = 20;
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
