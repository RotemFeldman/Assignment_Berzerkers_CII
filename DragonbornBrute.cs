//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////
namespace C_II_1stAssignment
{
    sealed class DragonbornBrute : Unit
    {
        public DragonbornBrute(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating) : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Dragonborn;
            HP = 55;
            CarryCapacity = 13;
            Name = "Dragonborn Brute";
        }
        

        public override void Attack(Unit defender)
        {
            AttackPrompt(defender);
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
            DefensePrompt(attacker, dmg);

            ApplyDamage(dmg);

            //Damage.SetModifier(Damage.Modifier + 2);
        }
    }
}
