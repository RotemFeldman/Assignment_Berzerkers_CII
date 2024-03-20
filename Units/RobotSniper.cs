﻿//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class RobotSniper : RangedUnit
    {

        public RobotSniper(IRandomProvider<int> damage, IRandomProvider<int> hitChance, IRandomProvider<int> defenseRating) : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Robot;
            HP = 30;
            Range = 50;
            AmmoPerReload = 1;
            CarryCapacity = 5;
            Name = "Robot Sniper";
        }

        public RobotSniper() : base()
        {
            UnitRace = Race.Robot;
            HP = 30;
            Range = 50;
            AmmoPerReload = 1;
            CarryCapacity = 5;
            Name = "Robot Sniper";
        }

        public override void Attack(Unit defender)
        {
            AttackPrompt(defender);
            if(_ammoLeft <= 0)
            {
                Reload();
                return;
            }

            if(!HitChanceCheck(defender)) { return; }

            Attack(defender);

            _ammoLeft--;
        }

        public override void Defend(Unit attacker)
        {
            int dmg = attacker.Damage.GetRandom();
            DefensePrompt(attacker, dmg);
            ApplyDamage(dmg);
        }
    }
}
