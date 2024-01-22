//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class DragonbornMage : RangedUnit
    {
        public DragonbornMage() { 
            UnitRace = Race.Dragonborn;
            Damage = new Dice(1,6,0);
            HP = 35;
            Range = 15;
            CarryCapacity = 7;
            HitChance = new Dice(3, 6, -2);
            DefenseRating = new Dice(1,10,-1);
        }


        public override void Attack(Unit defender)
        {
            for (int i = 0; i < 5 ; i++)
            {
                AttackSequence(defender);
            }
                    
        }

        public override void Defend(Unit attacker)
        {
            if (attacker.IsMarked)
            {
                attacker.IsMarked = false;
                Console.WriteLine($"{attacker} was under the infulence of {this} spell and missed.");
                return;
            }

            int dmg = attacker.Damage.Roll();
            DefensePrompt(attacker, dmg);

            ApplyDamage(dmg);
        }

        private void AttackSequence(Unit defender)
        {
            if (!HitChanceCheck(defender))
            { return; }

            defender.Defend(this);
            defender.IsMarked = true;
        }
    }
}
