//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class RangedUnit : Unit
    {
        public RangedUnit(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating) : base(damage, hitChance, defenseRating)
        {
            _ammoLeft = AmmoPerReload;
            UnitList.AllRangedUnits.Add(this);
        }

        public RangedUnit() : base()
        {
            _ammoLeft = AmmoPerReload;
            UnitList.AllRangedUnits.Add(this);
        }
        
        public virtual float Range { get; protected set; }
        public virtual int AmmoPerReload { get; protected set; }
        
        protected int _ammoLeft;

        
        public virtual void Reload() => _ammoLeft = AmmoPerReload;

        
    }
}
