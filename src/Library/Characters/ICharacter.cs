namespace RoleplayGame
{
    public interface ICharacter
    {
        string Name { get; set; }
        int AttackValue { get; }
        int DefenseValue { get; }
        int Health { get; }
        int VP {get; set;}

        void AddItem(IItem item);
        void RemoveItem(IItem item);
        void ReceiveAttack(ICharacter character); 
        void Cure();
        
    }
}