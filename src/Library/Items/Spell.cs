namespace RoleplayGame
{
    public class Spell : ISpell , IDefensa , IAtaque
    {
        public int AttackValue
        {
            get
            {
                return 70;
            }
        }

        public int DefenseValue
        {
            get
            {
                return 70;
            }
        }
    }
}