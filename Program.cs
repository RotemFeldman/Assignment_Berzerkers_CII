//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Unit> BlueTeam = new List<Unit>();
            HumanCowboy cowboy = new HumanCowboy();
            BlueTeam.Add(cowboy);
            HumanKnight knight = new HumanKnight();
            BlueTeam.Add(knight);
            HumanMonk monk = new HumanMonk();
            BlueTeam.Add(monk);


            List<Unit> RedTeam = new List<Unit>();
            DragonbornBrute brute = new DragonbornBrute();
            RedTeam.Add(brute);
            DragonbornMage mage = new DragonbornMage();
            RedTeam.Add(mage);
            DragonbornPaladin paladin = new DragonbornPaladin();
            RedTeam.Add(paladin);


            int BlueCount = 0;
            int RedCount = 0;

            bool _bothTeamsAlive = true;
            

            while(_bothTeamsAlive)
            {
                BlueAttack(BlueCount);

                if (!ContinueFight(BlueTeam, RedTeam))
                    break;
                Console.WriteLine();

                RedAttack(RedCount);

                if (!ContinueFight(BlueTeam, RedTeam))
                    break;
                Console.WriteLine();
            }

            if(BlueTeam.Count > 0)
            {
                Console.WriteLine("Blue Wins");
            }
            else
            {
                Console.WriteLine("Red Wins");
            }




            void BlueAttack(int i)
            {
                int def = Random.Shared.Next(0, RedTeam.Count);

                BlueTeam[i].Attack(RedTeam[def]);

                if (RedTeam[def].IsDead)
                {
                    RedTeam.Remove(RedTeam[def]);
                    if (RedCount > RedTeam.Count - 1)
                        RedCount = 0;
                }

                BlueCount++;
                if(BlueCount > BlueTeam.Count -1)
                    BlueCount = 0;
            }

            void RedAttack(int i)
            {
                int def = Random.Shared.Next(0, BlueTeam.Count);

                RedTeam[i].Attack(BlueTeam[def]);

                if (BlueTeam[def].IsDead)
                {
                    BlueTeam.Remove(BlueTeam[def]);
                    if (BlueCount > BlueTeam.Count - 1)
                        BlueCount = 0;
                }

                RedCount++;
                if (RedCount > RedTeam.Count -1)
                    RedCount = 0;
            }

            bool ContinueFight(List<Unit> blue, List<Unit> red)
            {
                if (blue.Count == 0 || red.Count == 0)
                {
                    _bothTeamsAlive = false;
                    return false;
                }
                else
                    return true;
            }


        }

        
    }
}
