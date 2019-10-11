using System;

namespace SpookyCORE
{
    public class SpookyCharacterGen
    {
        private SpookyDataSet nameDataSet;
        private SpookyDataSet nicknameDataSet;
        private SpookyDataSet lastNamePrefixesDataSet;
        private SpookyDataSet lastNameSuffixesDataSet;
        private SpookyDataSet birthplacesDataSet;
        private SpookyDataSet powersDataSet;
        private SpookyDataSet pranksDataSet;

        public SpookyDataSet Names
        {
            set { nameDataSet = value; }
        }

        public SpookyDataSet Nicknames
        {
            set { nicknameDataSet = value; }
        }

        public SpookyDataSet LastNamesPrefixes
        {
            set { lastNamePrefixesDataSet = value; }
        }

        public SpookyDataSet LastNameSuffixes
        {
            set { lastNameSuffixesDataSet = value; }
        }

        public SpookyDataSet Birthplaces
        {
            set { birthplacesDataSet = value; }
        }

        public SpookyDataSet Powers
        {
            set { powersDataSet = value; }
        }

        public SpookyDataSet Pranks
        {
            set { pranksDataSet = value; }
        }

        public SpookyCharacter GenerateCharacter()
        {
            string charName = GenerateCharacterName();
            string charBirthplace = birthplacesDataSet.GetRandomString();
            string charPower = powersDataSet.GetRandomString();
            string charPrank = pranksDataSet.GetRandomString();

            SpookyCharacter character = new SpookyCharacter(charName, charBirthplace, charPower, charPrank);

            return character;
        }

        private string GenerateCharacterName()
        {
            string name = nameDataSet.GetRandomString();
            string nickname = nicknameDataSet.GetRandomString();
            if(nickname.Length > 0)
            {
                name += " \"" + nickname + "\"";
            }

            name += " ";
            name += lastNamePrefixesDataSet.GetRandomString();
            name += nameDataSet.GetRandomString();
            name += lastNameSuffixesDataSet.GetRandomString();

            return name;
        }
    }
}
