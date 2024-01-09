//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class RangedUnit : Unit
    {
        public float Range { get; set; }
        public int AmmoPerReload { get; set; }
        

        protected int _ammoLeft;

        protected RangedUnit(int damage, int hp, float range, int ammoPerReload, float chanceToActivateAbility) : base(damage, hp)
        {
            Range = range;
            AmmoPerReload = ammoPerReload;
            ChanceToActivateAbility = chanceToActivateAbility;
            _ammoLeft = ammoPerReload;
        }



        public virtual void Reload() => _ammoLeft = AmmoPerReload;

        
    }
}
