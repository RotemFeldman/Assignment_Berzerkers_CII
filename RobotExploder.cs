//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class RobotExploder : Unit
    {
        public override Race UnitRace { get; set; } = Race.Robot;
        public override int Damage { get; set; } = 999;
        public override int HP { get; set; } = 2;
        public override float ChanceToActivateAbility { get; set; } = 0.85f;

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
