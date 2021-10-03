using System.Collections.Generic;

namespace RoleplayGame
{
    public class Wizard : Hero, IMagicCharacter
    {
        
        private List<IMagicalItem> magicalItems = new List<IMagicalItem>();

        public Wizard(string name)
        {
            this.Name = name;
        }

        public void AddItem(IMagicalItem item)
        {
            this.magicalItems.Add(item);
        }

        public void RemoveItem(IMagicalItem item)
        {
            this.magicalItems.Remove(item);
        }

        public override int AttackValue {
            get {
                int result = 0;
                foreach (IItem item in this.Items)
                {
                    if (item is IAttackItem)
                    {
                        result += ((IAttackItem)item).AttackValue;
                    }
                }
                foreach (IMagicalItem item in this.magicalItems)
                {
                    if (item is IMagicalAttackItem)
                    {
                        result += ((IMagicalAttackItem)item).AttackValue;
                    }
                }

                return result;
            }
        }

        public override int DefenseValue {
            get {
                int result = 0;
                foreach (IItem item in this.Items)
                {
                    if (item is IDefenseItem)
                    {
                        result += ((IDefenseItem)item).DefenseValue;
                    }
                }
                foreach (IMagicalItem item in this.magicalItems)
                {
                    if (item is IMagicalDefenseItem)
                    {
                        result += ((IMagicalDefenseItem)item).DefenseValue;
                    }
                }
                return result;
            }
        }

        
    }
}