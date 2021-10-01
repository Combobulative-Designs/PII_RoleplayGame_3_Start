namespace RoleplayGame
{
    public class Wizard : IMagicCharacter 
    {
        private int health = 100;
        private int items;
        private IMagicalItem MagicalItems;

        public Wizard(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }


        public int AttackValue{get;set;}
        public int DefenseValue{get;set;}

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

        public void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
        }

        public void Cure()
        {
            this.Health = 100;
        }

        public void AddSpell(ISpell spell)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveSpell(ISpell spell)
        {
            throw new System.NotImplementedException();
        }

        public void AddItem(IMagicalItem item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveItem(IMagicalItem item)
        {
            throw new System.NotImplementedException();
        }

        public void AddItem(IItem item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveItem(IItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}