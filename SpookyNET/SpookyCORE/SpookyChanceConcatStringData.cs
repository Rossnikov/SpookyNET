using System;
using System.Collections.Generic;
using System.Text;

namespace SpookyCORE
{
    // Class for generating an output string from a list of strings in a file
    // It will roll a chance for each entry in the file and provide concatenated
    // output from all available strings that passed the chance roll.
    public class SpookyChanceConcatStringData
        : SpookyStringData
    {
        private SpookyChance chanceRoll;

        public SpookyChanceConcatStringData(string filePath, SpookyChance chance) 
            : base(filePath)
        {
            chanceRoll = chance;
        }

        override public string GetRandomString()
        {
            string result = "";
            foreach(var str in StringData)
            {
                if (chanceRoll.RollChance())
                {
                    result += str;
                }
            }

            return result;
        }
    }
}
