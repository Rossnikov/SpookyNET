using System;
using System.Collections.Generic;
using System.Text;

namespace SpookyCORE
{
    // Class for generating an output string from a list of strings in a file
    // It will roll a chance before generating and returns an empty string if the roll failed.
    public class SpookyChanceStringData
        : SpookyStringData
    {
        private SpookyChance chanceRoll;

        public SpookyChanceStringData(string filePath, SpookyChance chance)
            : base(filePath)
        {
            chanceRoll = chance;
        }

        override public string GetRandomString()
        {
            if (chanceRoll.RollChance())
            {
                return base.GetRandomString();
            }

            return "";
        }
    }
}
