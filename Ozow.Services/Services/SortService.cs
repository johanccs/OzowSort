using Ozow.Service.Interfaces;

namespace Ozow.Service.Services
{
    public class SortService : ISortService<string>
    {
        #region Readonly Fields

        private readonly string[] _arrayItems = new string[26];

        #endregion

        #region Constructor

        public SortService()
        {
            _arrayItems = LoadAlphabet();
        }

        #endregion
        #region Public Methods

        public string Sort(string input)
        {
            return ConvertToLower(input);
        }

        #endregion

        #region Private Methods

        private string ConvertToLower(string input)
        {
            return input.ToLower();
        }    
        
        private string[] LoadAlphabet()
        {
            string[] arrItems = new string[26];
            arrItems[0] = "a";
            arrItems[1] = "b";
            arrItems[2] = "c";
            arrItems[3] = "d";
            arrItems[4] = "e";
            arrItems[5] = "f";
            arrItems[6] = "g";
            arrItems[7] = "h";
            arrItems[8] = "i";
            arrItems[9] = "j";
            arrItems[10] = "k";
            arrItems[11] = "l";
            arrItems[12] = "m";
            arrItems[13] = "n";
            arrItems[14] = "o";
            arrItems[15] = "p";
            arrItems[16] = "q";
            arrItems[17] = "r";
            arrItems[18] = "s";
            arrItems[19] = "t";
            arrItems[20] = "u";
            arrItems[21] = "v";
            arrItems[22] = "w";
            arrItems[23] = "x";
            arrItems[24] = "y";
            arrItems[25] = "z";

            return arrItems;
        }
            

        #endregion

    }
}
