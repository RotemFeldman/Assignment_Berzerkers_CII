//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////
namespace C_II_1stAssignment
{
    sealed class DragonbornBrute : Unit
    {
        public DragonbornBrute()
        {
            UnitRace = Race.Dragonborn;
            Damage = new Dice(4, 6, 0);
            HP = 55;
            CarryCapacity = 13;
            HitChance = new Dice(4, 6,0);
            DefenseRating = new Dice(2, 4,0);
        }
        

        public override void Attack(Unit defender)
        {
            if (!HitChanceCheck(defender)) { return; }

            defender.Defend(this);

            if (!IsDead)
            {
                int heal = DefenseRating.Roll();
                HP += heal;
            }
        }

        public override void Defend(Unit attacker)
        {
            int dmg = attacker.Damage.Roll();

            ApplyDamage(dmg);

            Damage.SetModifier(Damage.Modifier + 2);
        }
    }
}
