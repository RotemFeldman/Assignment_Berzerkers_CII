//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class DragonbornPaladin : HeavyUnit
    {
        public DragonbornPaladin(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating): base(damage,hitChance,defenseRating) 
        { 
            UnitRace = Race.Dragonborn;
            HP = 90;
            Fortification = 3;
            CarryCapacity = 15;
            Name = "Dragonborn Paladin";
        }

        public DragonbornPaladin(): base()
        {
            UnitRace = Race.Dragonborn;
            HP = 90;
            Fortification = 3;
            CarryCapacity = 15;
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
            int dmg = attacker.Damage.GetRandom();
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
