//   C#II (Dor Ben Dor) //
//     Rotem Feldman    //
//////////////////////////

namespace C_II_1stAssignment
{
    abstract class RangedUnit : Unit
    {
        public float Range { get; set; }
        public int AmmoPerReload { get; set; }
        public double ChanceToMultiShot { get; set; }

        protected int _ammoLeft;

        

        

        public override void Attack(Unit defender, int dmg)
        { 
            if(_ammoLeft == 0)
            {
                Reload();
                return;
            }

            if (CheckMultiShot())
                Attack(defender, dmg);

            _ammoLeft--;
        }


        protected virtual void Reload() => _ammoLeft = AmmoPerReload;

        protected bool CheckMultiShot()
        {
            double rnd = Random.Shared.NextDouble();

            if (rnd > ChanceToMultiShot)
                return true;

            return false;
        }
    }
}
