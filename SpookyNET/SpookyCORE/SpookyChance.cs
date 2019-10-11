using System;
using System.Collections.Generic;
using System.Text;

namespace SpookyCORE
{
    public class SpookyChance
    {
        private Random randomGenerator;
        private float chance;

        public SpookyChance(float howSpookyIsIt)
        {
            randomGenerator = new Random();
            chance = howSpookyIsIt;
        }

        public bool RollChance()
        {
            return randomGenerator.NextDouble() <= chance;
        }
    }
}
