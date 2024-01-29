//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CombatManager combat = new CombatManager();

            List<Unit> red = combat.CreatTeam(5, Unit.Race.Human);
            List<Unit> blue = combat.CreatTeam(5, Unit.Race.Robot);

            combat.DoCombat(blue, red);


        }

        
    }
}
