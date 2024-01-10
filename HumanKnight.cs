﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    sealed class HumanKnight : HeavyUnit
    {
        public override Race UnitRace { get; set; } = Race.Human;
        public HumanKnight(int damage, int hp) : base(damage, hp)
        {
        }

        public override void Attack(Unit defender, int dmg)
        {
            defender.Defend(this, dmg + Fortification);
            Fortification /= 2;
        }
    }
}