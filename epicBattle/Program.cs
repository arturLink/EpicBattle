﻿using System;
using System.IO;

namespace epicBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] heroes = { "Harry Poter", "Superman", "Luke Skywalker", "Lara Croft" };
            //string[] villains = { "Voldemort", "Joker", "Venom ", "Darth Vader", "Cruela" };

            string folderPath = @"C:\Users\opilane\samples\";
            string[] heroes = GetDataFromFile(folderPath + "heroes.txt");
            string[] villains = GetDataFromFile(folderPath + "villains.txt");
            string[] weapon = GetDataFromFile(folderPath + "weapons.txt");
            string[] armor = GetDataFromFile(folderPath + "armor.txt");

            string randomHero = GetRandomElement(heroes);
            string randomVillain = GetRandomElement(villains);
            string heroWeapon = GetRandomElement(weapon);
            string villainWeapon = GetRandomElement(weapon);
            string heroArmor = GetRandomElement(armor);
            string villainArmor = GetRandomElement(armor);

            int heroHP = GeneratedHP(heroArmor);
            int villainHP = GeneratedHP(villainArmor);



            Console.WriteLine($"Your random hero is:{randomHero} in {heroArmor}");
            Console.WriteLine($"Your random hero is:{randomVillain} in {villainArmor}");
            Console.WriteLine($"{randomHero} with {heroWeapon} will fight {randomVillain} with {villainWeapon}");
            Console.WriteLine($"{randomVillain} HP: {villainHP}");
            Console.WriteLine($"{randomHero} HP: {heroHP}");

            while (heroHP! <= 0 || villainHP! <= 0)
            {
                heroHP = heroHP - Hit(randomVillain, villainWeapon);
                villainHP = villainHP - Hit(randomHero, heroWeapon);
            }
            if (heroHP > villainHP)
            {
                Console.WriteLine($"{randomHero} saves the day!");
            }
            else if (heroHP < villainHP)
            {
                Console.WriteLine("Dark Side wins!");
            }
            else
            {
                Console.WriteLine($"Someday {randomHero} shall fight {randomVillain} again!");
            }
        }

        public static string GetRandomElement(string[] someArray)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, someArray.Length);
            string randomCharacter = someArray[randomIndex];
            return randomCharacter;
        }

        public static string[] GetDataFromFile(string filePath)
        {
            string[] dataFromFile = File.ReadAllLines(filePath);
            return dataFromFile;
        }
        
        public static int GeneratedHP(string armor)
        {
            int characterHP = armor.Length;
            return characterHP;
        }
        
        public static int Hit(string weapon,string character)
        {
            Random rnd = new Random();
            int strike = rnd.Next(0, weapon.Length - 2);
            Console.WriteLine($"{character} hit {strike}!");

            if (strike == weapon.Length - 2)
            {
                Console.WriteLine($"Awesome! {character} made a critical hit!");
            }
            else if (strike == 0)
            {
                Console.WriteLine($"Bad luck! {character} missed the target!");
            }
            return strike;
        }
    }
}
