﻿//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class HumanCowboy : RangedUnit
    {
        public HumanCowboy() { 
            UnitRace = Race.Human;
            Damage = new Dice(4,4,+4);
            HP = 45;
            Range = 20f;
            AmmoPerReload = 6;
            CarryCapacity = 8;
            HitChance = new Dice(2,8,+2);
            DefenseRating = new Dice(1,8,+3);
        }

        private bool _retaliate = true;
        

        public override void Defend(Unit attacker)
        {
            int dmg = attacker.Damage.Roll();
            ApplyDamage(dmg);
            DefensePrompt(attacker, dmg);
            
            if(HP > 0 && _retaliate && !(attacker is RangedUnit))
            {
                _retaliate = false;
                Attack(attacker);
            }

            _retaliate = true;
        }

        public override void Attack(Unit defender)
        {
            _retaliate = false;

            int abilityCount = 0;

            if (_ammoLeft == 0)
            {
                Reload();
                return;
            }

            if (!HitChanceCheck(defender)) { return; }

            for (int i = 0; i < _ammoLeft; i++)
            {
                if (!CheckAbility())
                {
                    i = _ammoLeft;
                }
                else
                {
                    abilityCount++;
                }
            }

            defender.Defend(this);
            _ammoLeft--;

            for (int j = 0; j < abilityCount; j++)
            {
                defender.Defend(this);

                _ammoLeft--;
            }

            _retaliate = true;

        }
    }
}
