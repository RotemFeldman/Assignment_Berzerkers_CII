//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

using System.Reflection.Metadata;

namespace C_II_1stAssignment
{
    sealed class HumanCowboy : RangedUnit
    {

        public HumanCowboy(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating) : base(damage, hitChance, defenseRating) 
        { 
            UnitRace = Race.Human;
            HP = 45;
            Range = 20f;
            AmmoPerReload = 6;
            CarryCapacity = 8;
            Name = "Human Cowboy";
        }

        public HumanCowboy() : base()
        {
            UnitRace = Race.Human;
            HP = 45;
            Range = 20f;
            AmmoPerReload = 6;
            CarryCapacity = 8;
            Name = "Human Cowboy";
        }

        private bool _retaliate = true;
        private double _abilityChance = 0.2;

        public override void Defend(Unit attacker)
        {
            int dmg = attacker.Damage.GetRandom();
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
            AttackPrompt(defender);
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

        private bool CheckAbility()
        {
            if (Random.Shared.NextDouble() < _abilityChance)
                return true;

            return false;
        }
    }
}
