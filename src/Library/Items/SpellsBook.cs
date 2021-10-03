using System.Collections.Generic;

namespace RoleplayGame
{
    public class SpellsBook : IMagicalAttackItem,IMagicalDefenseItem
    {
        private List<ISpell> spells = new List<ISpell>();
        public List<ISpell> Spells { get => spells; }
        
        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach (ISpell spell in this.Spells)
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
                foreach (ISpell spell in this.Spells)
                {
                    value += spell.DefenseValue;
                }
                return value;
            }
        }

        public void AddSpell(ISpell spell)
        {
            this.spells.Add(spell);
        }

        public void RemoveSPell(ISpell spell)
        {
            this.spells.RemoveAll(value => value == spell);
        }
    }
}