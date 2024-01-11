//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class RobotSniper : RangedUnit
    {
        public override Race UnitRace { get; set; } = Race.Robot;
        public override int Damage { get; set; } = 40;
        public override int HP { get; set; } = 30;
        public override float ChanceToActivateAbility { get; set; } = 0.75f;
        public override float Range { get; set; } = 50;
        public override int AmmoPerReload { get; set; } = 1;

        public override void Attack(Unit defender)
        {
            if(_ammoLeft <= 0)
            {
                Reload();
                return;
            }

            if(CheckAbility())
            {
                Attack(defender);
            }

            _ammoLeft--;
        }

        public override void Defend(Unit attacker, int dmg)
        {
            ApplyDamage(dmg);
        }
    }
}
