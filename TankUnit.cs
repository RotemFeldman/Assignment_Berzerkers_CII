//   C#II (Dor Ben Dor) //
//     Rotem Feldman    //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class TankUnit : Unit
    {
        public float Fortification {  get;  protected set; }

        public override void Defend(Unit attacker, int dmg)
        {
            Fortification++;           

            ApplyDamage(Convert.ToInt32(dmg - (Fortification/2)));
        }

        public override void Attack(Unit defender, int dmg)
        {
            defender.Defend(this, Damage + Convert.ToInt32(Fortification));
            Fortification = 0;
        }


    }
}
