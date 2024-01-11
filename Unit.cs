//  C#II (Dor Ben Dor) //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class Unit
    {

        public Unit() { UnitList.AllUnits.Add(this); }
        
        public abstract int Damage { get; set; }
        public abstract int HP { get; set;}
        public virtual float ChanceToActivateAbility { get; set; }
        public abstract Race UnitRace { get; set; }

        // Status Effects //

        public virtual bool IsBurning { get; set; }

        public enum Race
        {
            Human, Dragonborn
        }

        public abstract void Attack(Unit defender);
        


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
