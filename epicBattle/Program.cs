using System;
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
            string[] heroes = GetDataFromFile(folderPath+"heroes.txt");
            string[] villains = GetDataFromFile(folderPath + "villains.txt");
            string[] weapon = GetDataFromFile(folderPath + "weapons.txt");

            string randomHero = GetRandomElement(heroes);
            Console.WriteLine($"Your random hero is:{randomHero}");
            string randomVillain = GetRandomElement(villains);
            Console.WriteLine($"Your random hero is:{randomVillain}");
            string heroWeapon = GetRandomElement(weapon);
            Console.WriteLine($"heroes random weapon is:{weapon}");
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
        

        

    }
}
