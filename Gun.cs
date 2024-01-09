using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    internal class Gun
    {
        public int Damage { get; set; }
        public int Range { get; set; }
        public int AmmoPerReload { get; set; }
        public double ChanceToMultiShot { get; set; }

        public bool CheckMultiShot()
        {
            double rnd = Random.Shared.NextDouble();

            if (rnd > ChanceToMultiShot)
                return true;

            return false;
        }

    }
}
