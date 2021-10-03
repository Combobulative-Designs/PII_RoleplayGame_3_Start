using NUnit.Framework;
using RoleplayGame;
namespace Test.Library
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestCrearUnMago()
        {
            string vNombre = "Mago De Prueba";


            Wizard elmago = new Wizard(vNombre );

            Assert.AreEqual(vNombre, elmago.Name);
            
        }
        [Test]
        public void TestReceiveAttack()
        {
            Bow bow = new Bow();
            SpellOne spell = new SpellOne();
            SpellsBook book= new SpellsBook();
            

            Archer legoland = new Archer("Legoland");
            legoland.AddItem(bow);

            Wizard mago = new Wizard("Mago");
            mago.AddItem(book);

            mago.ReceiveAttack(legoland);

            int expected = 100 - (bow.AttackValue - mago.DefenseValue);
            Assert.AreEqual(expected, mago.Health);
            
        }
                [Test]
        public void Testheall()
        {
            int Vidainicial=100;
            Bow bow = new Bow();
            SpellOne spell = new SpellOne();
            SpellsBook book= new SpellsBook();
            book.AddSpell(spell);
            

            Archer legoland = new Archer("Legoland");
            legoland.AddItem(bow);

            Wizard mago = new Wizard("Mago");
            mago.AddItem(book);

            mago.ReceiveAttack(legoland);

            int expected = 100 - (bow.AttackValue - mago.DefenseValue);
            

            mago.Cure();
            Assert.AreEqual(Vidainicial, mago.Health);

            
        }
        [Test]        
        public void TestGainVP()
        {
            BadWizard saruman = new BadWizard("Saruman");
            
            SpellOne spell = new SpellOne();
            SpellsBook book= new SpellsBook();
            book.AddSpell(spell);
            Wizard mago = new Wizard("Mago");
            mago.AddItem(book);

            int expectedVP = mago.VP + saruman.VP;
            while (saruman.Health > 0)
            {
                saruman.ReceiveAttack(mago);
            }
            Assert.AreEqual(expectedVP, mago.VP);
        }
        

    }
}