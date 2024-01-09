//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cowboy cowboy = new Cowboy(10,40,5f,6,0.1f);

            Cowboy cowboy2 = new Cowboy(10, 40, 5f, 6, 0.1f);

            Knight k = new Knight(17,93);
            Monk m = new Monk(12, 74, 0.5f);

        
            Console.WriteLine(cowboy2.HP.ToString());
            cowboy.Attack(m, cowboy.Damage);

            Console.WriteLine(cowboy2.HP.ToString());
            Console.WriteLine(m.Damage.ToString());
        }
    }
}
