using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SpellsBook book = new SpellsBook();
            SpellOne xSpell= new SpellOne();
            book.AddSpell(xSpell);

            Wizard gandalf = new Wizard("Gandalf");
            gandalf.AddItem( new Staff());
            gandalf.AddItem(book);

            Dwarf gimli = new Dwarf("Gimli");
            gimli.AddItem(new Axe());
            gimli.AddItem(new Helmet());
            gimli.AddItem(new Shield());

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gimli.ReceiveAttack(gandalf);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
        }
    }
}
