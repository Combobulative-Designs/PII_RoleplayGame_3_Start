using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Character : ICharacter
    {
        private int vp;
        private int health;
        private List<IItem> items = new List<IItem>();

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
            protected set
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

       public abstract void ReceiveAttack(ICharacter character);

        public void RemoveItem(IItem item)
        {
            this.items.Remove(item);
        }
        public int VP
        {
            get
            {
                return this.vp;
            }
            set 
            {
                this.vp = value < 0 ? 0 : value;
            }

        }

        public List<IItem> Items { get => items; }
    }
    
}