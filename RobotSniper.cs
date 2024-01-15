//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class RobotSniper : RangedUnit
    {

        public RobotSniper() {

            UnitRace = Race.Robot;
            Damage = 40;
            HP = 30;
            ChanceToActivateAbility = 0.5f;
            Range = 50;
            AmmoPerReload = 1;
        }

        public override void Attack(Unit defender)
        {
            if(_ammoLeft <= 0)
            {
                Reload();
                return;
            }

            if (defender is HeavyUnit)
            {
                Attack(defender);
            }
            else if(CheckAbility())
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
