//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class RangedUnit : Unit
    {
        public RangedUnit() {
            _ammoLeft = AmmoPerReload;
            UnitList.AllRangedUnits.Add(this);
        }
        
        public abstract float Range { get; set; }
        public abstract bool InRange { get; set; }
        public virtual int AmmoPerReload { get; set; }
        

        protected int _ammoLeft;

        



        public virtual void Reload() => _ammoLeft = AmmoPerReload;

        
    }
}
