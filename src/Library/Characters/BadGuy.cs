using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class BadGuy : ICharacter
    {
        protected int vp = 100;
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

        public void ReceiveAttack(ICharacter character)
        {
            if (this.DefenseValue < character.AttackValue)
            {
                this.Health -= character.AttackValue - this.DefenseValue;
            }
            if (this.Health==0 && character is Hero)
            {
                character.VP +=  this.VP;
                this.VP=0;
            }
        }

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
    }
}