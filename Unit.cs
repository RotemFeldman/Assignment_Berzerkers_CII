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
        
        public virtual Dice Damage { get; protected set; }
        public virtual int HP { get; protected set;}
        public virtual float ChanceToActivateAbility { get; protected set; }
        public virtual Race UnitRace { get; protected set; }
        public virtual int CarryCapacity { get; protected set; }
        public virtual Dice HitChance { get; protected set; }
        public virtual Dice DefenseRating { get; protected set; }
        public virtual Weather  WeatherEffect { get; protected set; }
        public virtual bool IsDead { get; protected set; } = false;

        // Status Effects //

        public virtual bool IsMarked { get; set; }

        public enum Race
        {
            Human, Dragonborn, Robot
        }

        public enum Weather
        {

        }

        public abstract void Attack(Unit defender);       
        public abstract void Defend(Unit attacker);


        public virtual void Heal(int amount)
        {
            HP += amount;
        }

        protected void ApplyDamage(int dmg)
        {
            HP -= dmg;
            DamagePrompt(dmg);

            if (HP <= 0)
            {
                IsDead = true;
                Console.WriteLine($"{this} is dead.");
            }
        }



        protected bool CheckAbility()
        {
            if (Random.Shared.NextDouble() < ChanceToActivateAbility)
                return true;

            return false;
        }

        // Rolls

        protected bool HitChanceCheck(Unit defender)
        {
            int hit = HitChance.Roll();
            int dr = defender.DefenseRating.Roll();

            if (hit >= dr)
            {
                return true;
            }
            else
            {
                MissPrompt();
                return false;
            }
        }





        #region Console Prompts

        protected void DefensePrompt(Unit attacker, int dmg)
        {
            Console.WriteLine($"{attacker} is attaking {this} for {dmg} damage.");
        }

        protected void DamagePrompt(int dmg)
        {
            Console.WriteLine($"{this} lost {dmg} HP.");
        }

        protected void MissPrompt()
        {
            Console.WriteLine($"The attack missed.");
        }

        protected void AttackPrompt(Unit defender)
        {
            Console.WriteLine($"{this} is attacking {defender}.");
        }

        #endregion
    }
}
