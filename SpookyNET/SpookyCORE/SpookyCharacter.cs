using System;
using System.Collections.Generic;
using System.Text;

namespace SpookyCORE
{
    public class SpookyCharacter
    {
        private string name;
        private string born;
        private string power;
        private string prank;

        public SpookyCharacter(string charName, string charPlaceofBirth, string charPower, string charPrank)
        {
            name = charName;
            born = charPlaceofBirth;
            power = charPower;
            prank = charPrank;
        }

        public string GetCharacterDescription()
        {
            var outputStr = $"Your name is {name}. And you were born {born} with the power {power}. Your favorite spooky prank is {prank}.";
            return outputStr;
        }
    }
}
