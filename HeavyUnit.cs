//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class HeavyUnit : Unit
    {
        
        public virtual int Fortification {  get; protected set; }

        public override void Defend(Unit attacker, int dmg)
        {
            Fortification++;

            if (dmg - Fortification < 0)
                return;

            ApplyDamage(dmg - Fortification);
        }
       



    }
}
