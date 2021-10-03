using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Hero : ICharacter
    {
        protected int health = 100;
        protected List<IItem> items = new List<IItem>();

        public string Name { get ; set; }

        public virtual int AttackValue {
            get {
                int result = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IAttackItem)
                    {
                        result += ((IAttackItem)item).AttackValue;
                    }
                }
                return result;
            }
        }

        public virtual int DefenseValue {
            get {
                int result = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IDefenseItem)
                    {
                        result += ((IDefenseItem)item).DefenseValue;
                    }
                }
                return result;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        public void Cure()
        {
            this.Health = 100;
        }

        public void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
        }

        public void RemoveItem(IItem item)
        {
            this.items.Remove(item);
        }
    }
}