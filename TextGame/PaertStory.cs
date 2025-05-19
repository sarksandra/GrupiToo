using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public enum StatusEffects
    {
        Poisoned,
        Healthy
    }
    public enum EnemyClass
    {
        Heavy,
        Light
    }

    public class PaertStory
    {
        public void DialogPrompt(string? npcName, string? text, string? option1, string? option2)
        {
            Console.WriteLine($"{npcName}:");
            Console.WriteLine($"{text}");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"1. {option1}");
            if (option2 != null)
            {
                Console.WriteLine($"2. {option2}");
            }
        }

        public void InventoryCheck()
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine(item);
            }
        }

        public void FightControls()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Your Fight Controls");
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("1.Light Attack\n2.Heavy Attack\n3.Potion");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("You used a light attack");
                    _enemyBaseHealth = _enemyBaseHealth - _baseLightDamage;
                    Console.WriteLine($"Enemy health is now at {_enemyBaseHealth}%");
                    break;
                case "2":
                    Console.WriteLine("You used a heavy attack");
                    _enemyBaseHealth = _enemyBaseHealth - _baseHeavyDamage;
                    _health = _health - 20;
                    Console.WriteLine($"Enemy health is now at {_enemyBaseHealth}%");
                    break;
                case "3":
                    Console.WriteLine("You took a potion!");
                    _health = 100;
                    Console.WriteLine($"Your health is now at {_health}%");
                    break;
                default:
                    Console.WriteLine("...");
                    break;
            }
            Console.WriteLine("-------------------------------------------------------");
        }

        public void Battle(string enemyClass, string EnemyName)
        {
            int healthChanged = _health;
            Random randomNum = new Random();
            int attackType = randomNum.Next(1, 3);
            if (attackType == 1)
            {
                attackType = 1;
            }
            else if (attackType == 2)
            {
                attackType = 2;
            }
            if(enemyClass == "Heavy")
            {
                EnemyClass enemyType = EnemyClass.Heavy;
            }
            else if (enemyClass == "Light")
            {
                EnemyClass enemyType = EnemyClass.Light;
            }
            Console.WriteLine($"You've gotten into a fight with {EnemyName}! They appear to have a {enemyClass} build");
            while (_enemyBaseHealth >  0)
            {
                switch(attackType)
                {
                    case 1:
                        Console.WriteLine($"{EnemyName} used a light attack");
                        healthChanged = _health - _baseLightDamage;
                        break;
                    case 2:
                        Console.WriteLine($"{EnemyName} used a heavy attack");
                        healthChanged = _health - _baseHeavyDamage;
                        break;
                }
                if (healthChanged != _health)
                {
                    Console.WriteLine($"Your health was {_health}%");
                    _health = healthChanged;
                    HealthCheck(healthChanged);
                }
                FightControls();
                if (_enemyBaseHealth <= 0)
                {
                    Console.WriteLine($"You've beaten {EnemyName} in a battle");
                }
            }           
        }

        public void CharacterStatusCheck()
        {
            Console.WriteLine($"You are: {status} and your health is at {_health}%");
        }
        private static int _baseLightDamage = 25;
        private static int _baseHeavyDamage = 40;
        private static int _enemyBaseHealth = 100;
        private string name = "";       
        private static int _health = 22;
        StatusEffects StatusEffects { get; set; }
        StatusEffects status = StatusEffects.Poisoned;
        List<string> Inventory = new List<string>();     
        public void HealthCheck(int health)
        {
            health = _health;
            if (health <= 0)
            {
                Console.WriteLine("You have succumbed to your injuries.");
                Environment.Exit(0);
            }
        }
        
        public void StartCedarCreek()
        {
            Console.Write($"Good Morning, stranger. We found you in a pretty bad state, you're lucky to be alive. What is your name? \nMy name is:");
            name = Console.ReadLine();
            DialogPrompt("stranger", $"Well hello there {name}, you've been down for quite a bit, want to try getting up?", "I'll get up, give me just a second.", null); ;
            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("*You feel sore, but eventually you get up.*");
                    break;
                default:
                    Console.WriteLine("...");
                    DialogPrompt(null, null, null, null);
                    break;
            }


            DialogPrompt("stranger", "How are you feeling?", $"{name}: I feel like shit", "I feel...");
            string decision = Console.ReadLine();
            Console.WriteLine();
            switch (decision)
            {
                case "1":
                    Console.WriteLine();
                    break;
                case "2":
                    CharacterStatusCheck();
                    Console.WriteLine("\n\n");
                    DialogPrompt("stranger", "How are you feeling?", "I feel like shit", "I feel...");                  
                    break;
                default:
                    Console.WriteLine("...");
                    DialogPrompt(null, null, null, null);
                    break;
            }
            DialogPrompt("stranger", "here, take this.", "Yeaaah... no thank you.", "Sure, but what is that?");
            string decision2 = Console.ReadLine();
            Console.WriteLine();
            switch (decision2)
            {
                case "1":
                    Console.WriteLine("You have picked your fate.");
                    _health = 0;
                    HealthCheck(_health);
                    break;
                case "2":
                    Inventory.Add("Greater_Health_Potion");
                    Console.WriteLine("You have received: Greater Health Potion");
                    _health = 100;
                    status = StatusEffects.Healthy;
                    Console.WriteLine("You feel..");
                    CharacterStatusCheck();
                    break;
            }
            DialogPrompt("stranger", $"now that you're cured... i figure its best you get on your way.. I think I will be seeing you again{name}", "Leave the Building", null);
            string decision3 = Console.ReadLine();
            Console.WriteLine();
            switch(decision3)
            {
                case "1":
                    Console.WriteLine("You've left the building.");
                    break;
            }
            Console.WriteLine("You step out of the building, and you get grabbed by a sick looking man, armed with a stick.");
            Battle("Heavy", "Ill Looking Male");
        }
    }
}
