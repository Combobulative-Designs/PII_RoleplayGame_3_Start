using System.Collections.Generic;

namespace RoleplayGame
{
    public class SpellsBook : IMagicalAttackItem,IMagicalDefenseItem
    {
        public Spell[] Spells { get; set; }
        
        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach (Spell spell in this.Spells)
                {
                    value += spell.AttackValue;
                }
                return value;
            }
        }

        public int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (Spell spell in this.Spells)
                {
                    value += spell.DefenseValue;
                }
                return value;
            }
        }

        public void AddSpell(ISpell spell)
        {

        }
        public void RemoveSPell(ISpell spell)
        {

        }
    }
}