//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class RobotBard : HeavyUnit
    {

        public RobotBard() { 
            UnitRace = Race.Robot;
            Damage = new Dice(2, 6, +3);
            HP = 80;
            CarryCapacity = 25;
            HitChance = new Dice(3,8,0);
            DefenseRating = new Dice(4,6,0);
            Name = "Robot Bard";
        }

        public override void Attack(Unit defender)
        {
            int dmg = Damage.Roll() + Fortification;
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
