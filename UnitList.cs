//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    static class UnitList
    {
        static public List<Unit> AllUnits = new List<Unit>();

        static public List<Unit> AllRangedUnits = new List<Unit>();

        static public List<Unit> AllRobots = new List<Unit>();
        static public List<Unit> AllHumans = new List<Unit>();
        static public List<Unit> AllDragonborns = new List<Unit>();

        static public Dictionary<Unit,int> DamageModDic = new Dictionary<Unit,int>();
        static public Dictionary<Unit, int> DefenseModDic = new Dictionary<Unit, int>();
        static public Dictionary<Unit, int> ChanceModDic = new Dictionary<Unit, int>();
    }
}
