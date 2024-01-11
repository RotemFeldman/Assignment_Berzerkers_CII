//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class DragonbornPaladin : HeavyUnit
    {
        public override Race UnitRace { get; set; } = Race.Dragonborn;
        public override int Damage { get; set; } = 25;
        public override int HP { get; set; } = 90;
        public override int Fortification { get; set; } = 3;

        private bool _isAttacking;
        

        public override void Attack(Unit defender, int dmg)
        {
            _isAttacking = true;

            defender.Defend(this, dmg);

            _isAttacking = false;
        }

        public override void Defend(Unit attacker, int dmg)
        {
            if (_isAttacking)
            {
                ApplyDamage(dmg + (dmg / 2));
                return;
            }

            base.Defend(attacker, dmg);
        }
    }
}
