using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Encounter
    {
        private List<Hero> heroes = new List<Hero>();
        private List<BadGuy> badGuys = new List<BadGuy>();
        
        public void AddCharacter(BadGuy character)
        {
            this.badGuys.Add(character);
        }
        public void AddCharacter(Hero character)
        {
            this.heroes.Add(character);
        }

        public void DoEncounter()
        {
            if (this.badGuys.Count >= 1 && this.heroes.Count >= 1)
            {
                this.DoTurnBadGuys();
            }
            else
            {
                Console.WriteLine($"Faltan heroes o malos.");
            }
        }

        private void DoTurnBadGuys()
        {
            int index = 0;

            foreach (BadGuy badGuy in this.badGuys)
            {
                if (this.heroes.Count > 0)
                {
                    this.heroes[index].ReceiveAttack(badGuy);
                    if (this.heroes[index].Health == 0)
                    {
                        this.heroes.RemoveAt(index);
                    }
                    index += 1;
                    if (index >= this.heroes.Count)
                    {
                        index = 0;
                    }
                }
            }
            
            if (this.heroes.Count > 0)
            {
                this.DoTurnHeroes();
            }
            else
            {
                this.EndEncounter();
            }
        }

        private void DoTurnHeroes()
        {
            int index = 0;
            foreach (Hero hero in this.heroes)
            {
                if (this.badGuys.Count > 0)
                {
                    this.badGuys[index].ReceiveAttack(hero);
                    if (this.badGuys[index].Health == 0)
                    {
                        this.badGuys.RemoveAt(index);
                    }
                    index += 1;
                    if (index >= this.badGuys.Count)
                    {
                        index = 0;
                    }
                    if (hero.VP >= 5)
                    {
                        hero.Cure();
                        hero.VP = 0;
                    }
                }
            }
            
            if (this.badGuys.Count > 0)
            {
                this.DoTurnHeroes();
            }
            else
            {
                this.EndEncounter();
            }
        }

        private void EndEncounter()
        {
            if (this.heroes.Count > 0)
            {
                Console.WriteLine($"Ganaron los heroes.");
            }
            else
            {
                Console.WriteLine($"Ganaron los malos.");
            }
        }
    }
}