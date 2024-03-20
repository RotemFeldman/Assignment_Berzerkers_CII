//  C#II (Dor Ben Dor) //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class Unit
    {
        public Unit()
        {
            Damage = GenerateRandomIRandomProvider();
            HitChance = GenerateRandomIRandomProvider();
            DefenseRating = GenerateRandomIRandomProvider();
            WeatherEffect = Weather.WeatherEffect.None;

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

        public Unit(IRandomProvider<int> damage , IRandomProvider<int> hitChance, IRandomProvider<int> defenseRating) 
        {
            Damage = damage;
            HitChance = hitChance;
            DefenseRating = defenseRating;
            WeatherEffect= Weather.WeatherEffect.None;

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
        
        public virtual IRandomProvider<int> Damage { get; protected set; }
        public virtual int HP { get; protected set;}
        public virtual Race UnitRace { get; protected set; }
        public virtual int CarryCapacity { get; protected set; }
        public virtual IRandomProvider<int> HitChance { get; protected set; }
        public virtual IRandomProvider<int> DefenseRating { get; protected set; }
        public virtual bool IsDead { get; protected set; } = false;
        public virtual string Name { get; protected set; }
        public virtual Weather.WeatherEffect WeatherEffect { get; protected set; }

        public enum Race
        {
            Human, Dragonborn, Robot
        }


        // Status Effects //

        public virtual bool IsMarked { get; set; }

        


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


            int hit = HitChance.GetRandom();
            int dr = defender.DefenseRating.GetRandom();

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

            int hit = HitChance.GetRandom();
            int dr = defender.DefenseRating.GetRandom();

            bool first = hit >= dr;

            hit = HitChance.GetRandom();
            dr = defender.DefenseRating.GetRandom();

            bool second = hit >= dr;


            if (!first || !second)
            {
                Console.WriteLine("The foggy weather caused the attack to miss.");
                return false;
            }
            else
                return true;
            
        }

        private IRandomProvider<int> GenerateRandomIRandomProvider()
        {
            if(Random.Shared.Next(1,3) == 1)
            {
                return new Dice((uint)Random.Shared.Next(1,4),(uint)Random.Shared.Next(2,20),Random.Shared.Next(-7,8));
            }
            else
            {
                int[] array = new int[Random.Shared.Next(5,10)];

                foreach (int i in array)
                {
                    array[i] = Random.Shared.Next(10,41);
                }

                return new Bag(array);
            }
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
