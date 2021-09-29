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
            Archer legolas = new Archer("Legolas");
            legolas.Helmet = helmet;

            Assert.AreEqual(helmet.DefenseValue, legolas.DefenseValue);
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
            Archer legolas = new Archer("Legolas");
            legolas.Bow = bow;

            Assert.AreEqual(bow.AttackValue, legolas.AttackValue);
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

            Helmet helmet = new Helmet();
            Archer legolas = new Archer("Legolas");
            legolas.Helmet = helmet;

            legolas.ReceiveAttack(64);

            int expected = 100 - (64 - legolas.DefenseValue);
            Assert.AreEqual(expected, legolas.Health);
        }
    }
}