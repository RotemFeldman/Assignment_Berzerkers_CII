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

           // combat.DoCombat(blue, red);

            Bag bag1 = new Bag(1,1,4,5,6);
            Bag bag2 = new Bag(1,1,4,5,6);

            Console.WriteLine(bag1.ToString());
            Console.WriteLine(bag2.ToString());
            Console.WriteLine(bag1.GetHashCode());
            Console.WriteLine(bag2.GetHashCode());

            if (bag1.Equals(bag2))
            {
                Console.WriteLine("true");
            }
        }

        
    }
}
