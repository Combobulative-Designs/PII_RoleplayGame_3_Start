using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class ArcherTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test para el caso de crear un Arquero.
        /// Verifica que el Arquero creado tenga
        /// el nombre correcto y la vida completa.
        /// </summary>
        [Test]
        public void TestCreateArcher()
        {
            string name = "Legolas";
            Archer legolas = new Archer(name);

            Assert.AreEqual(name, legolas.Name);
            Assert.AreEqual(100, legolas.Health);
        }

        /// <summary>
        /// Test de calculo de valor defensa.
        /// Verifica que la defensa calculada
        /// sea la correcta para los items
        /// equipados.
        /// </summary>
        [Test]
        public void TestDefenseValue()
        {
            Helmet helmet = new Helmet();
            Armor armor = new Armor();
            int expectedDefense = armor.DefenseValue + helmet.DefenseValue;

            Archer legolas = new Archer("Legolas");
            legolas.AddItem(armor);
            legolas.AddItem(helmet);

            Assert.AreEqual(expectedDefense, legolas.DefenseValue);
        }

        /// <summary>
        /// Test de calculo de valor ataque.
        /// Verifica que el ataque calculado
        /// sea el correcta para los items
        /// equipados.
        /// </summary>
        [Test]
        public void TestAttackValue()
        {
            Bow bow = new Bow(); 
            Sword sword = new Sword(); 
            int expectedAttack = bow.AttackValue + sword.AttackValue;

            Archer legolas = new Archer("Legolas");
            legolas.AddItem(bow);
            legolas.AddItem(sword); 

            Assert.AreEqual(expectedAttack, legolas.AttackValue);
        }

        /// <summary>
        /// Test de recibir daño. Verifica
        /// que la vida restante luego de 
        /// recibir un ataque sea la correcta
        /// para la combinacion de vida inicial
        /// daño recibido, y valor de defensa.
        /// </summary>
        [Test]
        public void TestReceiveDamage()
        {
            Bow bow = new Bow();
            Sword sword = new Sword();
            Helmet helmet = new Helmet();

            Archer legoland = new Archer("Legoland");
            legoland.AddItem(bow);
            legoland.AddItem(sword);

            Archer legolas = new Archer("Legolas");
            legolas.AddItem(helmet);

            legolas.ReceiveAttack(legoland);

            int expected = 100 - (legoland.AttackValue - legolas.DefenseValue);
            Assert.AreEqual(expected, legolas.Health);
        }

        /// <summary>
        /// Test de ganar VP. Verifica que
        /// los VPs de un malo se transfieran
        /// al arquero luego de que este lo
        /// derrote.
        /// </summary>
        [Test]
        public void TestGainVP()
        {
            BadWizard saruman = new BadWizard("Saruman");
            
            Bow bow = new Bow();
            Archer legolas = new Archer("Legolas");
            legolas.AddItem(bow);

            int expectedVP = legolas.VP + saruman.VP;
            while (saruman.Health > 0)
            {
                saruman.ReceiveAttack(legolas);
            }
            Assert.AreEqual(expectedVP, legolas.VP);
        }
    }
}