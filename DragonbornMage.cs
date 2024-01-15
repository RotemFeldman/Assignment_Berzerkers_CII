//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class DragonbornMage : RangedUnit
    {
        public DragonbornMage() { 
            UnitRace = Race.Dragonborn;
            Damage = 4;
            HP = 35;
            ChanceToActivateAbility = 0.33f;
            Range = 15;
        }


        public override void Attack(Unit defender)
        {
            defender.IsBurning = true;

            if (CheckAbility())
            {
                defender.Defend(this, Damage + (Damage / 2));
                defender.Defend(this, Damage + (Damage / 2));
                defender.Defend(this, Damage + (Damage / 2));
                defender.Defend(this, Damage + (Damage / 2));
                defender.Defend(this, Damage + (Damage / 2));
            }
            else
            {
                defender.Defend(this, Damage);
                defender.Defend(this, Damage);
                defender.Defend(this, Damage);
                defender.Defend(this, Damage);
                defender.Defend(this, Damage);
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
