using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Hero : Character
    {

       public override void ReceiveAttack(ICharacter character)
        {
            if (this.DefenseValue < character.AttackValue)
            {
                this.Health -= character.AttackValue - this.DefenseValue;
            }
        }

        public Hero()
        {
            this.VP = 0;
            this.Health = 100;
        }
    }
}