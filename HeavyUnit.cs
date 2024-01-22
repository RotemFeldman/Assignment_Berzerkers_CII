//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class HeavyUnit : Unit
    {
        
        public virtual int Fortification {  get; protected set; }

        public override void Defend(Unit attacker)
        {
            int dmg = attacker.Damage.Roll();
            DefensePrompt(attacker, dmg);

            Fortification++;
            DefenseRating.SetModifier(Fortification);

            int def = DefenseRating.Roll();

            if (dmg - def < 0)
                return;

            ApplyDamage(dmg - def);
        }      
    }
}
