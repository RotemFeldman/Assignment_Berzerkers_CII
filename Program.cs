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
           void RandomFighter<T>(Deck<T> deck, Dice<T> die, Comparer<T> comparer) where T : struct , IComparable<T> 
           {
                int deckWins = 0;
                int DieWins = 0;
                int Ties = 0;

                for (int i = 0; i < deck.Size; i++)
                {
                    T dieRoll = die.GetRandom();
                    T deckDraw = deck.Peek();

                    if(comparer.Compare(dieRoll,deckDraw) < 0)
                    {
                        deckWins++;
                    }
                    else if(comparer.Compare(dieRoll,deckDraw)  > 0)
                    {
                        DieWins++;
                    }
                    else
                        Ties++;
                }
           }

            Dice dice = new Dice(1,20,0);

            Deck<int> deck = new Deck<int>(40);

        }

        
    }
}
