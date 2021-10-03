using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class BadGuy : Character
    {
        public override void ReceiveAttack(ICharacter character)
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

        public BadGuy()
        {
            this.VP = 1;
            this.Health = 100;
        }
    }
}