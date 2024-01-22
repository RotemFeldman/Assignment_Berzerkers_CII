﻿//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////
namespace C_II_1stAssignment
{
    sealed class DragonbornBrute : Unit
    {
        public DragonbornBrute()
        {
            UnitRace = Race.Dragonborn;
            Damage = 20;
            HP = 55;
        }
        

        public override void Attack(Unit defender)
        {
            defender.Defend(this, Damage);

            if (HP > 0) 
                HP += Convert.ToInt32(Damage * 0.33);
        }

        public override void Defend(Unit attacker, int dmg)
        {
            ApplyDamage(dmg);

            Damage += 2;
        }
    }
}
