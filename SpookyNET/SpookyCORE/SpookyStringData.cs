using System;
using System.Collections.Generic;
using System.Text;

namespace SpookyCORE
{
    // Class for reading spooky data from a file on the disk
    public class SpookyStringData
        : SpookyDataSet
    {
        private List<string> stringData;

        protected List<string> StringData
        {
            get { return stringData; }
        }

        public SpookyStringData(string filePath)
        {
            // Should this be async?
            var stringsFromFile = System.IO.File.ReadAllLines(filePath);
            stringData = new List<string>(stringsFromFile);
        }

        override public string GetRandomString()
        {
            var index = RandomDataGenerator.Next(0, stringData.Count);
            return stringData[index];
        }
    }
}
