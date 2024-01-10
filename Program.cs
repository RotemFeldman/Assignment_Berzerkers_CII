//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HumanCowboy HumanCowboy = new HumanCowboy(10,40,5f,6,0.1f);

            HumanCowboy HumanCowboy2 = new HumanCowboy(10, 40, 5f, 6, 0.1f);

            HumanKnight k = new HumanKnight(17,93);
            HumanMonk m = new HumanMonk(12, 74, 0.5f);

        
            Console.WriteLine(HumanCowboy2.HP.ToString());
            HumanCowboy.Attack(m, HumanCowboy.Damage);

            Console.WriteLine(HumanCowboy2.HP.ToString());
            Console.WriteLine(m.Damage.ToString());
        }
    }
}
