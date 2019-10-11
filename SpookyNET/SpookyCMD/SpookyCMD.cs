using System;

namespace SpookyCMD
{
    class SpookyCMD
    {
        string assetRootPath;
        SpookyCMDConfig config;
        SpookyCORE.SpookyCharacterGen charGen;

        public SpookyCMD(string assetPath, string configName)
        {
            assetRootPath = assetPath;
            string configPath = assetPath + "\\" + configName;

            SpookyCMDConfig config = SpookyCMDConfig.ParseConfig(configPath);
            charGen = new SpookyCORE.SpookyCharacterGen();

            string namesFilePath = assetRootPath + "\\" + config.NamesPath;
            string prefixesFilePath = assetRootPath + "\\" + config.LastNamesPrefixesPath;
            string suffixesFilePath = assetRootPath + "\\" + config.LastNamesSuffixesPath;
            string birthplacesFilePath = assetRootPath + "\\" + config.BirthplacesPath;
            string powersFilePath = assetRootPath + "\\" + config.PowersPath;
            string pranksFilePath = assetRootPath + "\\" + config.PranksPath;
            var prefixChance = new SpookyCORE.SpookyChance(config.ChanceToAddPrefix);
            var suffixChance = new SpookyCORE.SpookyChance(config.ChanceToAddSuffix);
            var nickChance = new SpookyCORE.SpookyChance(config.ChanceToAddNickname);

            charGen.Names = new SpookyCORE.SpookyStringData(namesFilePath);
            charGen.Nicknames = new SpookyCORE.SpookyChanceStringData(namesFilePath, nickChance);
            charGen.LastNamesPrefixes = new SpookyCORE.SpookyChanceConcatStringData(prefixesFilePath, prefixChance);
            charGen.LastNameSuffixes = new SpookyCORE.SpookyChanceConcatStringData(suffixesFilePath, suffixChance);
            charGen.Birthplaces = new SpookyCORE.SpookyStringData(birthplacesFilePath);
            charGen.Powers = new SpookyCORE.SpookyStringData(powersFilePath);
            charGen.Pranks = new SpookyCORE.SpookyStringData(pranksFilePath);
        }

        public string GenerateCharacterData()
        {
            var character = charGen.GenerateCharacter();
            return character.GetCharacterDescription();
        }

        static void Main(string[] args)
        {
            SpookyCMD cmd = new SpookyCMD("assets", "config.json");

            while(true)
            {
                var printThisSpooker = cmd.GenerateCharacterData();
                Console.WriteLine(printThisSpooker);
                Console.ReadKey();
            }
        }
    }
}
