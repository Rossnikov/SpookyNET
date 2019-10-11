using System;
using System.Collections.Generic;
using System.Text;

namespace SpookyCORE
{
    // Base class for getting spooky data
    public abstract class SpookyDataSet
    {
        private Random randomDataGenerator;

        protected Random RandomDataGenerator
        {
            get { return randomDataGenerator; }
        }

        protected SpookyDataSet()
        {
            randomDataGenerator = new Random();
        }

        public abstract string GetRandomString();
    }
}
