using Ozow.Service.Interfaces;
using System.Text;

namespace Ozow.Service.Services
{
    public class SortService : ISortService<string>
    {
        #region Readonly Fields

        private readonly char[] _arrayItems = new char[26];

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
            var arrInput = input.ToCharArray();
            int[] intArr = new int[input.Length];

            for(int i = 0; i <= arrInput.Length -1; i++)
            {
               int index = FindIndexByValue(arrInput[i]);               
               
                intArr[i] = index;
            }

            int[] sortedList = SortIndex(intArr);
            
            return BuildFinalList(sortedList);
        }

        #endregion

        #region Private Methods

        private string BuildFinalList(int[] sortedList)
        {
            StringBuilder finalList = new StringBuilder();

            for(int i = 0; i<= sortedList.Length-1; i++)
            {
                if (sortedList[i] >= 0)
                {
                    var p = _arrayItems[sortedList[i]];
                    finalList.Append(p);
                }
            }

            return finalList.ToString();
        }
        
        private char[] LoadAlphabet()
        {
            char[] arrItems = new char[26];
            arrItems[0] = 'a';
            arrItems[1] = 'b';
            arrItems[2] = 'c';
            arrItems[3] = 'd';
            arrItems[4] = 'e';
            arrItems[5] = 'f';
            arrItems[6] = 'g';
            arrItems[7] = 'h';
            arrItems[8] = 'i';
            arrItems[9] = 'j';
            arrItems[10] = 'k';
            arrItems[11] = 'l';
            arrItems[12] = 'm';
            arrItems[13] = 'n';
            arrItems[14] = 'o';
            arrItems[15] = 'p';
            arrItems[16] = 'q';
            arrItems[17] = 'r';
            arrItems[18] = 's';
            arrItems[19] = 't';
            arrItems[20] = 'u';
            arrItems[21] = 'v';
            arrItems[22] = 'w';
            arrItems[23] = 'x';
            arrItems[24] = 'y';
            arrItems[25] = 'z';

            return arrItems;
        }
           
        private int FindIndexByValue(char val)
        {
            char lowerCaseVal = char.ToLower(val);
            for(int i = 0; i<= _arrayItems.Length -1; i++)
            {
                if(_arrayItems[i] == char.ToLower(val))
                {
                    return i;
                }
            }

            return -1;
        }

        private int[] SortIndex(int[] indexArr)
        {
            for(int i = 0; i <= indexArr.Length -2; i++)
            {
                for(int y = 0; y <= indexArr.Length -2; y++)
                {
                    if(indexArr[y] > indexArr[y+1])
                    {
                        var temp = indexArr[y + 1];
                        indexArr[y + 1] = indexArr[y];
                        indexArr[y] = temp;
                    }
                }
            }

            return indexArr;
        }

        #endregion
    }
}
