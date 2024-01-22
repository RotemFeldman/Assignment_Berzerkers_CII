//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice die = new Dice(1,8,9);
            Dice die2 = new Dice(1,8,8);

            int r = die.Roll();

            Console.WriteLine(r);
            Console.WriteLine(die.ToString());
            Console.WriteLine(die.GetHashCode());
            Console.WriteLine(die2.GetHashCode());

            if(die.Equals(die2))
            {
                Console.WriteLine("eq");
            }
        }
    }
}
