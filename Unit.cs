//  C#II (Dor Ben Dor) //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class Unit
    {
        public Unit(int damage, int hp) { Damage = damage; HP = hp; }
        public virtual int Damage { get; set; }
        public virtual int HP { get; set;}
        public virtual float ChanceToActivateAbility { get; set; }
        public abstract Race UnitRace { get; set; }

        public enum Race
        {
            Human
        }

        public abstract void Attack(Unit defender, int dmg);
    

        public abstract void Defend(Unit attacker, int dmg);

        protected void ApplyDamage(int dmg)
        {
            HP -= dmg;
        }

        protected bool CheckAbility()
        {
            if (Random.Shared.NextDouble() < ChanceToActivateAbility)
                return true;

            return false;
        }

    }
}
