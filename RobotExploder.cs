//  C#II (Dor Ben Dor)  //
// Rotem Feldman - OOP3 //
//////////////////////////

namespace C_II_1stAssignment
{
    sealed class RobotExploder : Unit
    {
        public RobotExploder(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating) : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Robot;
            HP = 1;
            CarryCapacity = 1;
            Name = "Robot Exploder";
        }

        private int _maxHP = 2;

        public override void Attack(Unit defender)
        {
            AttackPrompt(defender);
            defender.Defend(this);
            ApplyDamage(1);
        }

        public override void Defend(Unit attacker)
        {
            if (HitChanceCheck(attacker))
            {
                Console.WriteLine($"{this} evaded the attack.");
                return;
            }          

            int dmg = attacker.Damage.Roll();
            DefensePrompt(attacker, dmg);
            ApplyDamage(dmg);

            if (IsDead && !(attacker is RangedUnit)) { attacker.Defend(this); }
        }

        public override void Heal(int amount)
        {
            base.Heal(amount);

            if (HP > _maxHP) {  HP = _maxHP; }
        }
    }
}
