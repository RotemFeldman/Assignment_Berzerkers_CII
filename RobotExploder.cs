//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class RobotExploder : Unit
    {
        public RobotExploder() {
            UnitRace = Race.Robot;
            Damage = 999;
            HP = 1;
            ChanceToActivateAbility = 0.85f;
        }

        private int _maxHP = 2;

        public override void Attack(Unit defender)
        {
            defender.Defend(this, Damage);
            HP--;
        }

        public override void Defend(Unit attacker, int dmg)
        {
            if (CheckAbility()) { return; }           

            ApplyDamage(dmg);

            if (HP <= 0 && !(attacker is RangedUnit)) { attacker.Defend(this, Damage); }
        }

        public override void Heal(int amount)
        {
            base.Heal(amount);

            if (HP > _maxHP) {  HP = _maxHP; }
        }
    }
}
