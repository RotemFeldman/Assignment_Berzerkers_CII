//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class DragonbornPaladin : HeavyUnit
    {
        public DragonbornPaladin() { 
            UnitRace = Race.Dragonborn;
            Damage = 25;
            HP = 90;
            Fortification = 3;
        }

        private bool _isAttacking;
        

        public override void Attack(Unit defender)
        {
            _isAttacking = true;

            defender.Defend(this, Damage);

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
