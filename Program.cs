//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HumanCowboy HumanCowboy = new HumanCowboy();
            HumanCowboy HumanCowboy2 = new HumanCowboy();
            HumanKnight k = new HumanKnight();
            HumanMonk m = new HumanMonk();
            
        
            Console.WriteLine(HumanCowboy2.HP.ToString());
            HumanCowboy.Attack(HumanCowboy2);
            HumanCowboy.Attack(HumanCowboy2);
            Console.WriteLine(HumanCowboy2.HP.ToString());
            

            foreach (RangedUnit unit in UnitList.AllRangedUnits) { unit.Reload(); } 

            foreach (Unit unit in UnitList.AllUnits) { Console.WriteLine(unit.ToString()); }

        }
    }
}
