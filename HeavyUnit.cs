//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class HeavyUnit : Unit
    {
        protected HeavyUnit(int damage, int hp) : base(damage, hp) 
        {
        }

        public int Fortification {  get; set; }

        public override void Defend(Unit attacker, int dmg)
        {
            Fortification++;

            if (dmg - Fortification < 0)
                return;

            ApplyDamage(dmg - Fortification);
        }
       



    }
}
