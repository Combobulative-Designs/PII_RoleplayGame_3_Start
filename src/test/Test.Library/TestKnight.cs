using NUnit.Framework;
using RoleplayGame;



namespace Test.Library
{
    public class TestsKnight
    {
        [Test]
        public void Test1AtacadoArquero()
        {
            int vida = 100;
            string Nombre = "Elenor";
            Knight prueba1 = new Knight(Nombre);
            Archer arquer1 = new Archer("arquero1");
            arquer1.Bow = new Bow();
            prueba1.Shield = new Shield();
            prueba1.Armor = new Armor();
            prueba1.ReceiveAttack(arquer1.AttackValue);

            Assert.AreEqual(vida,prueba1.Health);

        }

        [Test]
        public void Test2Atacado()
        {
            int vida = 99;
            string Nombre = "Elenor";
            Knight prueba1 = new Knight(Nombre);
    
            prueba1.Shield = new Shield();
            prueba1.Armor = new Armor();
            prueba1.ReceiveAttack(40);
            Assert.AreEqual(vida,prueba1.Health);


        }


        [Test]
        public void Test2curado()
        {
            int vida = 100;
            string Nombre = "Elenor";
            Knight prueba1 = new Knight(Nombre);
    
            prueba1.Shield = new Shield();
            prueba1.Armor = new Armor();
            prueba1.ReceiveAttack(50);
        

            prueba1.Cure();
            Assert.AreEqual(vida,prueba1.Health);


        }



    }
}