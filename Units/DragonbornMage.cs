//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class DragonbornMage : RangedUnit
    {
        public DragonbornMage(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating) : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Dragonborn;
            HP = 35;
            Range = 15;
            CarryCapacity = 7;
            Name = "Dragonborn Mage";
        }
        public DragonbornMage() : base()
        { 
            UnitRace = Race.Dragonborn;
            HP = 35;
            Range = 15;
            CarryCapacity = 7;
            Name = "Dragonborn Mage";
        }


        public override void Attack(Unit defender)
        {
            AttackPrompt(defender);
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
