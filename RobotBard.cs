//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class RobotBard : HeavyUnit
    {
        public override Race UnitRace { get; set; } = Race.Robot;
        public override int Damage { get; set; } = 5;
        public override int HP { get; set; } = 80;

        public override void Attack(Unit defender)
        {
            switch (defender.UnitRace) 
            {
                case Race.Robot:
                    foreach (Unit u in UnitList.AllRobots) { u.Heal(Damage + Fortification); }
                    break;
                case Race.Dragonborn:
                    foreach (Unit u in UnitList.AllDragonborns) { u.Defend(this,Damage + Fortification); }
                    break;
                case Race.Human:
                    foreach (Unit  u in UnitList.AllHumans) { u.Defend(this, Damage + Fortification); }
                    break;
                    
            }   
        }

        public override void Defend(Unit attacker, int dmg)
        {
            base.Defend(attacker, dmg);
        }
    }
}
