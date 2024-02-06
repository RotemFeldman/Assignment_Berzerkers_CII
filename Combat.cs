//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    internal class CombatManager
    {
        public void DoCombat(List<Unit> BlueTeam, List<Unit> RedTeam, string blueTeamName = "Blue", string redTeamName = "Red")
        {

            int blueResources = TeamResourcesAmount(BlueTeam);
            int redResources = TeamResourcesAmount(RedTeam);

            int BlueIndex = Random.Shared.Next(0, BlueTeam.Count - 1);
            int RedIndex = Random.Shared.Next(0, RedTeam.Count - 1);

            bool _bothTeamsAlive = true;


            while (_bothTeamsAlive)
            {
                BlueAttack(BlueIndex);

                if (!ContinueFight(BlueTeam, RedTeam))
                    break;
                Console.WriteLine();

                RedAttack(RedIndex);

                if (!ContinueFight(BlueTeam, RedTeam))
                    break;
                Console.WriteLine();

                Weather.CheckWeather();
            }

            if (BlueTeam.Count > 0)
            {
                Console.WriteLine($"{blueTeamName} Wins");
                Console.WriteLine($"They gained {redResources} resources");
            }
            else
            {
                Console.WriteLine($"{redTeamName} Wins");
                Console.WriteLine($"They gained {blueResources} resources");
            }




            void BlueAttack(int i)
            {
                int def = Random.Shared.Next(0, RedTeam.Count);

                BlueTeam[i].Attack(RedTeam[def]);

                if (RedTeam[def].IsDead)
                {
                    RedTeam.Remove(RedTeam[def]);
                    if (RedIndex > RedTeam.Count - 1)
                        RedIndex = 0;
                }

                BlueIndex++;
                if (BlueIndex > BlueTeam.Count - 1)
                    BlueIndex = 0;
            }

            void RedAttack(int i)
            {
                int def = Random.Shared.Next(0, BlueTeam.Count);

                RedTeam[i].Attack(BlueTeam[def]);

                if (BlueTeam[def].IsDead)
                {
                    BlueTeam.Remove(BlueTeam[def]);
                    if (BlueIndex > BlueTeam.Count - 1)
                        BlueIndex = 0;
                }

                RedIndex++;
                if (RedIndex > RedTeam.Count - 1)
                    RedIndex = 0;
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

        public List<Unit> CreateTeam(int teamSize, Unit.Race race)
        {
            List<Unit> list = new List<Unit>();
            for (int i = 0; i < teamSize; i++)
            {
                int rnd = Random.Shared.Next(1, 4);

                switch (race)
                {
                    case Unit.Race.Human:
                        if (rnd == 1)
                            list.Add(new HumanCowboy());
                        else if (rnd == 2)
                            list.Add(new HumanKnight());
                        else if (rnd == 3)
                            list.Add(new HumanMonk());
                        break;
                    case Unit.Race.Robot:
                        if (rnd == 1)
                            list.Add(new RobotBard());
                        else if (rnd == 2)
                            list.Add(new RobotExploder());
                        else if (rnd == 3)
                            list.Add(new RobotSniper());
                        break;
                    case Unit.Race.Dragonborn:
                        if (rnd == 1)
                            list.Add(new DragonbornBrute());
                        else if (rnd == 2)
                            list.Add(new DragonbornMage());
                        else if (rnd == 3)
                            list.Add(new DragonbornPaladin());
                        break;
                        default: break;

                }      
            }
            return list;
        }

        private int TeamResourcesAmount(List<Unit> team)
        {
            int amount = 0;

            foreach (var unit in team)
            {
                amount += Random.Shared.Next(unit.CarryCapacity + 1);
            }

            return amount;
        }


    }
}
