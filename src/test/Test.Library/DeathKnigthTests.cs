using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class DeathKnightTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test para el caso de crear un Caballero de la Muerte.
        /// Verifica que el Caballero de la Muerte creado tenga
        /// el nombre correcto y la vida completa.
        /// </summary>
        [Test]
        public void TestCreateDeathKnight()
        {
            string name = "Arthas Menethil";
            DeathKnight arthas = new DeathKnight(name);

            Assert.AreEqual(name, arthas.Name);
            Assert.AreEqual(100, arthas.Health);
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

            DeathKnight arthas = new DeathKnight("Arthas Menethil");
            arthas.AddItem(armor);
            arthas.AddItem(helmet);

            Assert.AreEqual(expectedDefense, arthas.DefenseValue);
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

            DeathKnight arthas = new DeathKnight("Arthas Menethil");
            arthas.AddItem(bow);
            arthas.AddItem(sword); 

            Assert.AreEqual(expectedAttack, arthas.AttackValue);
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

            DeathKnight lichKing = new DeathKnight("Lich King");
            lichKing.AddItem(bow);
            lichKing.AddItem(sword);

            DeathKnight arthas = new DeathKnight("Arthas Menethil");
            arthas.AddItem(helmet);

            arthas.ReceiveAttack(lichKing);

            int expected = 100 - (lichKing.AttackValue - arthas.DefenseValue);
            Assert.AreEqual(expected, arthas.Health);
        }
    }
}