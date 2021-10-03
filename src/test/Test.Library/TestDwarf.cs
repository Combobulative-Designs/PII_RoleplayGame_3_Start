using NUnit.Framework;
using RoleplayGame;



namespace Test.Library
{
    public class TestsDwarf
    {
        [Test]
        public void TestCrearDwarf()
        {
            string name = "Dwarf";
            int Vida = 100;
            Dwarf Enano = new Dwarf("Dwarf");

            Assert.AreEqual(name, Enano.Name);
            Assert.AreEqual(Vida, Enano.Health);
        }



        [Test]
        public void TestAttackDwarf()
        {

            Axe axe = new Axe(); 
            int AttackExp = axe.AttackValue;

            Dwarf Enano = new Dwarf("Dwarf");
            Enano.AddItem(axe); 

            Assert.AreEqual(AttackExp, Enano.AttackValue);
        }

        [Test]
        public void TestDefenseDwarf()
        {
            Shield shield = new Shield();
            Armor armor = new Armor();
            int Defenseesp = armor.DefenseValue + shield.DefenseValue;

            Dwarf Enano = new Dwarf("Dwarf");
            Enano.AddItem(armor);
            Enano.AddItem(shield);

            Assert.AreEqual(Defenseesp, Enano.DefenseValue);
        }

        [Test]
        public void TestVP()
        {
            BadArcher ArqueroMalo = new BadArcher("ArqueroMalo");
            
            Axe axe = new Axe();
            Dwarf Enano = new Dwarf("Dwarf");
            Enano.AddItem(axe);

            int expectedVP = Enano.VP + ArqueroMalo.VP;
            while (ArqueroMalo.Health > 0)
            {
                ArqueroMalo.ReceiveAttack(Enano);
            }
            Assert.AreEqual(expectedVP, Enano.VP);
        }
    }
}


