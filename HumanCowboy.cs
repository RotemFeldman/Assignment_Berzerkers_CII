//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class HumanCowboy : RangedUnit
    {
        public HumanCowboy() { 
            UnitRace = Race.Human;
            Damage = 12;
            HP = 45;
            Range = 20f;
            AmmoPerReload = 6;
        }

        private bool _retaliate = true;
        

        public override void Defend(Unit attacker, int dmg)
        {
            ApplyDamage(dmg);
            
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

            defender.Defend(this, Damage);
            _ammoLeft--;

            for (int j = 0; j < abilityCount; j++)
            {
                defender.Defend(this, Damage);

                _ammoLeft--;
            }

            _retaliate = true;

        }
    }
}
