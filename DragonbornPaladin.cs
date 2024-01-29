//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class DragonbornPaladin : HeavyUnit
    {
        public DragonbornPaladin() { 
            UnitRace = Race.Dragonborn;
            Damage = new Dice(2, 10, +4);
            HP = 90;
            Fortification = 3;
            CarryCapacity = 15;
            HitChance = new Dice(1, 10, +2);
            DefenseRating = new Dice(2,6,Fortification);
            Name = "Dragonborn Paladin";
        }

        private bool _isAttacking;
        

        public override void Attack(Unit defender)
        {
            AttackPrompt(defender);
            if (!HitChanceCheck(defender))
                return;

            _isAttacking = true;

            defender.Defend(this);

            _isAttacking = false;
        }

        public override void Defend(Unit attacker)
        {
            int dmg = attacker.Damage.Roll();
            DefensePrompt(attacker, dmg);

            if (_isAttacking)
            {
                ApplyDamage(dmg);
                Console.WriteLine($"{this} was caught unprepared and lost {dmg} HP.");
                return;
            }

            base.Defend(attacker);
        }
    }
}
