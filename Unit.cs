//  C#II (Dor Ben Dor) //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class Unit
    {
        public Unit(IRandomProvider randomProvider) {
            UnitList.AllUnits.Add(this);
            RandomProvider = randomProvider;

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
        
        public virtual IRandomProvider RandomProvider { get; protected set; }
        public virtual Dice Damage { get; protected set; }
        public virtual int HP { get; protected set;}
        public virtual Race UnitRace { get; protected set; }
        public virtual int CarryCapacity { get; protected set; }
        public virtual Dice HitChance { get; protected set; }
        public virtual Dice DefenseRating { get; protected set; }
        public virtual bool IsDead { get; protected set; } = false;
        public virtual string Name { get; protected set; }

        // Status Effects //

        public virtual bool IsMarked { get; set; }

        public enum Race
        {
            Human, Dragonborn, Robot
        }


        public abstract void Attack(Unit defender);       
        public abstract void Defend(Unit attacker);


        public virtual void Heal(int amount)
        {
            HP += amount;
            Console.WriteLine($"{this.Name} is heald for {amount} HP.");
        }

        protected void ApplyDamage(int dmg)
        {
            HP -= dmg;
            DamagePrompt(dmg);

            if (HP <= 0)
            {
                IsDead = true;
                Console.WriteLine($"{this.Name} is dead.");
            }
        }





        // Rolls

        protected bool HitChanceCheck(Unit defender)
        {
            if(Weather.CurrentWeather == Weather.WeatherEffect.Foggy)
            {
                return (HitChanceCheckFoggy(defender));
                 
            }


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

        private bool HitChanceCheckFoggy(Unit defender)
        {

            int hit = HitChance.Roll();
            int dr = defender.DefenseRating.Roll();

            bool first = hit >= dr;

            hit = HitChance.Roll();
            dr = defender.DefenseRating.Roll();

            bool second = hit >= dr;


            if (!first || !second)
            {
                Console.WriteLine("The foggy weather caused the attack to miss.");
                return false;
            }
            else
                return true;
            
        }





        #region Console Prompts

        protected void DefensePrompt(Unit attacker, int dmg)
        {
            Console.WriteLine($"{attacker.Name} is attaking {this.Name} for {dmg} damage.");
        }

        protected void DamagePrompt(int dmg)
        {
            Console.WriteLine($"{this.Name} lost {dmg} HP.");
        }

        protected void MissPrompt()
        {
            Console.WriteLine($"The attack missed.");
        }

        protected void AttackPrompt(Unit defender)
        {
            Console.WriteLine($"{this.Name} is attacking {defender.Name}.");
        }

        #endregion
    }
}
