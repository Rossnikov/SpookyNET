using System;
using System.Collections.Generic;

namespace SpookyNET
{
    struct Character
    {
        public string name;
        public string born;
        public string power;
        public string prank;
    }

    class Program
    {
        Random randomGenerator;
        List<string> names;
        List<string> lastNamePrefixes;
        List<string> lastNameSuffixes;
        List<string> birthplaces;
        List<string> powers;
        List<string> pranks;

        float lastNamePrefixChance = 0.15f;
        float lastNameSuffixChance = 0.15f;
        float addNicknameChance = 0.35f;

        List<string> GetStringsFromFile(string path)
        {
            var stringsFromFile = System.IO.File.ReadAllLines(path);
            List<string> strings = new List<string>(stringsFromFile);

            return strings;
        }

        string GetRandomStringFrom(List<string> strings)
        {
            var index = randomGenerator.Next(0, strings.Count);
            return strings[index];
        }

        float GetRandomRatio()
        {
            return (float)randomGenerator.NextDouble();
        }

        bool ChanceRoll(float ratio)
        {
            return GetRandomRatio() <= ratio;
        }

        string GetName()
        {
            string name = GetRandomStringFrom(names);

            var addNickname = ChanceRoll(addNicknameChance);
            if (addNickname)
            {
                name += " \"" + GetRandomStringFrom(names) + "\"";
            }

            name += " ";

            foreach(var prefix in lastNamePrefixes)
            {
                var addPrefix = ChanceRoll(lastNamePrefixChance);
                if(addPrefix)
                {
                    name += prefix;
                }
            }

            name += GetRandomStringFrom(names);

            return name;
        }

        public Character GenerateCharacter()
        {
            Character c;
            c.name = GetName();
            c.born = GetRandomStringFrom(birthplaces);
            c.power = GetRandomStringFrom(powers);
            c.prank = GetRandomStringFrom(pranks);

            return c;
        }

        public Program()
        {
            randomGenerator = new Random();

            names = GetStringsFromFile("names.txt");
            lastNamePrefixes = GetStringsFromFile("prefixes.txt");
            lastNameSuffixes = GetStringsFromFile("suffixes.txt");
            birthplaces = GetStringsFromFile("birthplaces.txt");
            powers = GetStringsFromFile("powers.txt");
            pranks = GetStringsFromFile("pranks.txt");
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            while (true)
            {
                var character = p.GenerateCharacter();
                var outputStr = $"Your name is {character.name}. And you were born {character.born} with the power {character.power}. Your favorite spooky prank is {character.prank}.";
                Console.WriteLine(outputStr);

                Console.ReadKey();
            }
        }
    }
}
