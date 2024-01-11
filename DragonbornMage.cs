//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class DragonbornMage : RangedUnit
    {
        public override Race UnitRace { get; set; } = Race.Dragonborn;
        public override int Damage { get; set; } = 4;
        public override int HP { get; set; } = 35;
        public override float ChanceToActivateAbility { get; set; } = 0.33f;
        public override float Range { get; set; } = 15f;
        public override bool InRange { get; set; } = true;
        public override int AmmoPerReload { get; set; }

        public override void Attack(Unit defender, int dmg)
        {
            defender.IsBurning = true;

            if (CheckAbility())
            {
                defender.Defend(this, dmg + (dmg / 2));
                defender.Defend(this, dmg + (dmg / 2));
                defender.Defend(this, dmg + (dmg / 2));
                defender.Defend(this, dmg + (dmg / 2));
                defender.Defend(this, dmg + (dmg / 2));
            }
            else
            {
                defender.Defend(this, dmg);
                defender.Defend(this, dmg);
                defender.Defend(this, dmg);
                defender.Defend(this, dmg);
                defender.Defend(this, dmg);
            }
        }

        public override void Defend(Unit attacker, int dmg)
        {
            if (attacker.IsBurning)
            {
                attacker.IsBurning = false;
                return;
            }

            ApplyDamage(dmg);
        }
    }
}
