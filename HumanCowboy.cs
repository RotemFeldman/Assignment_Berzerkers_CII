//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class Cowboy : RangedUnit
    {
        public override Race UnitRace { get; set; } = Race.Human;

        private bool _retaliate = true;
        public Cowboy(int damage, int hp, float range, int ammoPerReload, float chanceToMultiShot) : base(damage, hp, range, ammoPerReload, chanceToMultiShot)
        {            
        }

        public override void Defend(Unit attacker, int dmg)
        {
            Console.WriteLine("cowboy defends");
            ApplyDamage(dmg);
            
            if(HP > 0 && _retaliate)
            {
                Console.WriteLine("cowboy retaliates");
                _retaliate = false;
                Attack(attacker, dmg/2);
            }

            _retaliate = true;
        }

        public override void Attack(Unit defender, int dmg)
        {
            _retaliate = false;
            int abilityCount = 0;

            if (_ammoLeft == 0)
            {
                Console.WriteLine("no ammo, reloading");
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
                    Console.WriteLine("multishot");
                    abilityCount++;
                }
            }

            defender.Defend(this, dmg);
            _ammoLeft--;

            for (int j = 0; j < abilityCount; j++)
            {
                defender.Defend(this, dmg);

                _ammoLeft--;
            }

        }
    }
}
