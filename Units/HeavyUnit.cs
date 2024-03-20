//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class HeavyUnit : Unit
    {
        public HeavyUnit(IRandomProvider<int> damage, IRandomProvider<int> hitChance, IRandomProvider<int> defenseRating) : base(damage, hitChance, defenseRating)
        {
        }

        public HeavyUnit(): base()
        {
        }

        public virtual int Fortification {  get; protected set; }

        public override void Defend(Unit attacker)
        {
            int dmg = attacker.Damage.GetRandom();
            DefensePrompt(attacker, dmg);

            Fortification++;
            //DefenseRating.SetModifier(Fortification);

            int def = DefenseRating.GetRandom();

            if (dmg - def < 0)
                return;

            ApplyDamage(dmg - def);
        }      
    }
}
