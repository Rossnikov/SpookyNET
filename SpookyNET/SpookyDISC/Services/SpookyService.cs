using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpookyDISC.Services
{
    public class SpookyService
    {
        SpookyCORE.SpookyCharacterGen charGen;

        public SpookyService(string assetPath, string configName)
        {
            string configPath = assetPath + "\\" + configName;

            SpookyCORE.SpookyConfig config = SpookyCORE.SpookyConfig.ParseConfig(configPath);
            charGen = new SpookyCORE.SpookyCharacterGen();

            string namesFilePath = assetPath + "\\" + config.NamesPath;
            string prefixesFilePath = assetPath + "\\" + config.LastNamesPrefixesPath;
            string suffixesFilePath = assetPath + "\\" + config.LastNamesSuffixesPath;
            string birthplacesFilePath = assetPath + "\\" + config.BirthplacesPath;
            string powersFilePath = assetPath + "\\" + config.PowersPath;
            string pranksFilePath = assetPath + "\\" + config.PranksPath;
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

        public string GetSpookyDescription()
        {
            var character = charGen.GenerateCharacter();
            return character.GetCharacterDescription();
        }
    }
}
