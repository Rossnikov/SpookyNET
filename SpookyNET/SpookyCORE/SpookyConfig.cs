using System;
using System.Collections.Generic;
using System.Text;

namespace SpookyCORE
{
    public class SpookyConfig
    {
        private string namesFileName;
        private string lastNamePrefixesFileName;
        private string lastNameSuffixesFileName;
        private string birthplacesFileName;
        private string powersFileName;
        private string pranksFileName;
        private float chancePrefix;
        private float chanceSuffix;
        private float chanceNickname;

        public string NamesPath
        {
            get { return namesFileName; }
            set { namesFileName = value; }
        }

        public string LastNamesPrefixesPath
        {
            get { return lastNamePrefixesFileName; }
            set { lastNamePrefixesFileName = value; }
        }

        public string LastNamesSuffixesPath
        {
            get { return lastNameSuffixesFileName; }
            set { lastNameSuffixesFileName = value; }
        }

        public string BirthplacesPath
        {
            get { return birthplacesFileName; }
            set { birthplacesFileName = value; }
        }

        public string PowersPath
        {
            get { return powersFileName; }
            set { powersFileName = value; }
        }

        public string PranksPath
        {
            get { return pranksFileName; }
            set { pranksFileName = value; }
        }

        public float ChanceToAddPrefix
        {
            get { return chancePrefix; }
            set { chancePrefix = value; }
        }

        public float ChanceToAddSuffix
        {
            get { return chanceSuffix; }
            set { chanceSuffix = value; }
        }

        public float ChanceToAddNickname
        {
            get { return chanceNickname; }
            set { chanceNickname = value; }
        }

        public static SpookyConfig ParseConfig(string jsonConfigFile)
        {
            string config = System.IO.File.ReadAllText(jsonConfigFile);
            var configData = (SpookyConfig)Newtonsoft.Json.JsonConvert.DeserializeObject(config, typeof(SpookyConfig));

            return configData;
        }

        public static void WriteGenericConfig(string jsonConfigFile)
        {
            SpookyConfig spook = new SpookyConfig();
            spook.namesFileName = "names.txt";
            spook.lastNamePrefixesFileName = "lastNamePrefixes.txt";
            spook.lastNameSuffixesFileName = "lastNameSuffixes.txt";
            spook.birthplacesFileName = "birthplaces.txt";
            spook.powersFileName = "powers.txt";
            spook.pranksFileName = "pranks.txt";
            spook.chancePrefix = 0.15f;
            spook.chanceSuffix = 0.15f;
            spook.chanceNickname = 0.35f;

            var str = Newtonsoft.Json.JsonConvert.SerializeObject(spook, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(jsonConfigFile, str);
        }
    }
}
