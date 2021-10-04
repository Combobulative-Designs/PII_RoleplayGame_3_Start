using NUnit.Framework;
using RoleplayGame;



namespace Test.Library
{
    public class TestKnight
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
        public void TestCreateKnight()
        {
            string name = "Nicolas";
            Knight legolas = new Knight(name);

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

            Knight xKnight = new Knight("Nicolas");
            xKnight.AddItem(armor);
            xKnight.AddItem(helmet);

            Assert.AreEqual(expectedDefense, xKnight.DefenseValue);
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

            Knight xKnight = new Knight("Nicolas");
            xKnight.AddItem(bow);
            xKnight.AddItem(sword); 

            Assert.AreEqual(expectedAttack, xKnight.AttackValue);
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
            Helmet helmet = new Helmet();
            Sword sword=new Sword();
            

            Knight xKnight = new Knight("Nicolas");
            xKnight.AddItem(bow);
            xKnight.AddItem(sword);

            Knight legolas = new Knight("Legolas");
            legolas.AddItem(helmet);

            legolas.ReceiveAttack(xKnight);

            int expected = 100 - (xKnight.AttackValue - legolas.DefenseValue);
            Assert.AreEqual(expected, legolas.Health);
        }

        [Test]
        public void TestCure()
        {
            Bow bow = new Bow();
            Sword sword = new Sword();
            Helmet helmet = new Helmet();

            Knight xKnight1 = new Knight("Nico");
            xKnight1.AddItem(bow);
            xKnight1.AddItem(sword);

            Knight xKnight2 = new Knight("Pedro");
            xKnight2.AddItem(helmet);

            xKnight2.ReceiveAttack(xKnight1);
            xKnight2.Cure();
            Assert.AreEqual(100, xKnight2.Health);
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
            BadWizard xMalo = new BadWizard("ReMalo");
            
            Bow bow = new Bow();
            Knight xKnight = new Knight("Nico");
            xKnight.AddItem(bow);

            int expectedVP = xKnight.VP + xMalo.VP;
            while (xMalo.Health > 0)
            {
                xMalo.ReceiveAttack(xKnight);
            }
            Assert.AreEqual(expectedVP, xKnight.VP);
        }
    }
}