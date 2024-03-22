//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

using System.Security.Cryptography.X509Certificates;

namespace C_II_1stAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
           void RandomFighter<T>(Deck<T> deck, Dice<T> die) where T : struct , IComparable<T> 
           {
                int deckWins = 0;
                int dieWins = 0;
                int ties = 0;

                for (int i = 0; i < deck.Size; i++)
                {
                    T dieRoll = die.GetRandom();
                    T deckDraw = deck.Peek();

                    int result = deckDraw.CompareTo(dieRoll);

                    if (result > 0)
                    {
                        deckWins++;
                    }
                    else if (result < 0)
                    {
                        dieWins++;
                    }
                    else
                        ties++;


                }

                Console.WriteLine($"Deck wins: {deckWins}, Die wins: {dieWins}, Ties: {ties}");
           }

            Dice dice = new Dice(1,20,0);

            Deck<int> deck = new Deck<int>(5);

            for (int i = 0; i < deck.Size; i++)
            {
                deck.TryAdd(Random.Shared.Next(1,20));
            }

            RandomFighter<int>(deck, dice);

        }

        
    }
}
