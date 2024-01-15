//  C#II (Dor Ben Dor) //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class Unit
    {

        public Unit() {
            UnitList.AllUnits.Add(this); 

            switch (UnitRace)
            {
                case Race.Human:
                    UnitList.AllHumans.Add(this);
                    break;
                case Race.Dragonborn:
                    UnitList.AllDragonborns.Add(this);
                    break;
                case Race.Robot:
                    UnitList.AllRobots.Add(this);
                    break;
            }
        }
        
        public virtual int Damage { get; set; }
        public virtual int HP { get; set;}
        public virtual float ChanceToActivateAbility { get; set; }
        public virtual Race UnitRace { get; set; }

        // Status Effects //

        public virtual bool IsBurning { get; set; }

        public enum Race
        {
            Human, Dragonborn, Robot
        }

        public abstract void Attack(Unit defender);       
        public abstract void Defend(Unit attacker, int dmg);


        public virtual void Heal(int amount)
        {
            HP += amount;
        }

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
