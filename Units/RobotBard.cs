//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class RobotBard : HeavyUnit
    {

        public RobotBard(IRandomProvider<int> damage, IRandomProvider<int> hitChance, IRandomProvider<int> defenseRating) : base(damage, hitChance, defenseRating)
        { 
            UnitRace = Race.Robot;
            HP = 80;
            CarryCapacity = 25;
            Name = "Robot Bard";
        }

        public RobotBard() : base()
        {
            UnitRace = Race.Robot;
            HP = 80;
            CarryCapacity = 25;
            Name = "Robot Bard";
        }

        public override void Attack(Unit defender)
        {
            int dmg = Damage.GetRandom() + Fortification;
            Console.WriteLine("RobotBard Targets " + (defender)) ;

            switch (defender.UnitRace) 
            {
                case Race.Robot:
                    foreach (Unit u in UnitList.AllRobots) { u.Heal(dmg); }
                    break;
                case Race.Dragonborn:
                    foreach (Unit u in UnitList.AllDragonborns) { u.Defend(this); }
                    break;
                case Race.Human:
                    foreach (Unit  u in UnitList.AllHumans) { u.Defend(this); }
                    break;
                    
            }   
        }

        public override void Defend(Unit attacker)
        {
            base.Defend(attacker);
        }
    }
}
