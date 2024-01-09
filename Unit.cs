//   C#II (Dor Ben Dor) //
//     Rotem Feldman    //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class Unit
    {
        public virtual int Damage { get; set; }
        public virtual int HP { get; set;}

        public abstract void Attack(Unit defender, int dmg);
    

        public abstract void Defend(Unit attacker, int dmg);

        protected void ApplyDamage(int dmg)
        {
            HP -= dmg;
        }

        protected enum Race
        {
            Human, Elf, Orc, Merfolk, Fairy
        }
    }
}
