using System.IO;
using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class EncounterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test para la realización de
        /// un encuentro donde se espera 
        /// que ganen los malos.
        /// </summary>
        [Test]
        public void TestBadGuysWin()
        {
            Dwarf uther = new Dwarf("Uther Pendragon");

            DeathKnight arthas = new DeathKnight("Arthas Menethil");
            arthas.AddItem(new Sword());

            BadArcher silvanas = new BadArcher("Silvanas Windrunner");
            silvanas.AddItem(new Bow());

            BadWizard kelthuzad = new BadWizard("Kel'Thuzad");
            SpellsBook grimoire = new SpellsBook();
            grimoire.AddSpell(new SpellOne());
            kelthuzad.AddItem(grimoire);

            Encounter encounter = new Encounter();
            encounter.AddCharacter(uther);
            encounter.AddCharacter(arthas);
            encounter.AddCharacter(silvanas);
            encounter.AddCharacter(kelthuzad);

            using (StringWriter stringWriter = new StringWriter())
            {
                System.Console.SetOut(stringWriter);
                string expected = "Ganaron los malos.\r\n";
                encounter.DoEncounter();
                Assert.That(stringWriter.ToString(), Is.EqualTo(expected));
            }
        }

        /// <summary>
        /// Test para la realización de
        /// un encuentro donde se espera 
        /// que ganen los heroes.
        /// </summary>
        [Test]
        public void TestHeroesWin()
        {
            Dwarf uther = new Dwarf("Uther Pendragon");
            uther.AddItem(new Axe());

            BadArcher tyrande = new BadArcher("Tyrande Whisperwind");
            tyrande.AddItem(new Bow());

            Wizard jaina = new Wizard("Jaina Proudmoore");
            SpellsBook grimoire = new SpellsBook();
            grimoire.AddSpell(new SpellOne());
            jaina.AddItem(grimoire);

            DeathKnight arthas = new DeathKnight("Arthas Menethil");
            arthas.AddItem(new Sword());

            Encounter encounter = new Encounter();
            encounter.AddCharacter(uther);
            encounter.AddCharacter(tyrande);
            encounter.AddCharacter(jaina);
            encounter.AddCharacter(arthas);

            using (StringWriter stringWriter = new StringWriter())
            {
                System.Console.SetOut(stringWriter);
                string expected = "Ganaron los heroes.\r\n";
                encounter.DoEncounter();
                Assert.That(stringWriter.ToString(), Is.EqualTo(expected));
            }
        }
    }
}