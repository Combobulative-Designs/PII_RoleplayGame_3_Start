namespace RoleplayGame
{
    interface ICharacter
    {
        string Name { get; set; }
        int AttackValue { get; }
        int DefenseValue { get; }
        int Health { get; }

        void AddItem(IItem item);
        void RemoveItem(IItem item);
        void ReceiveAttack(int power); 
        void Cure();
    }
}