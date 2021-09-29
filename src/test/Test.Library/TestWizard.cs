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
            SpellsBook book = new SpellsBook();
            book.Spells = new Spell[]{ new Spell() };
            int Vidafinal=90;
            string vNombre = "Mago De Prueba";
            Wizard elmago = new Wizard(vNombre );
            elmago.Staff = new Staff();
            elmago.SpellsBook = book;

            elmago.ReceiveAttack(180);

            Assert.AreEqual(Vidafinal, elmago.Health);
            
        }
                [Test]
        public void Testheall()
        {
            int Vidainicial=100;
            SpellsBook book = new SpellsBook();
            book.Spells = new Spell[]{ new Spell() };
            int Vidafinal=90;
            string vNombre = "Mago De Prueba";
            Wizard elmago = new Wizard(vNombre );
            elmago.Staff = new Staff();
            elmago.SpellsBook = book;

            elmago.ReceiveAttack(180);

            Assert.AreEqual(Vidafinal, elmago.Health);

            elmago.Cure();
            Assert.AreEqual(Vidainicial, elmago.Health);

            
        }
        

    }
}