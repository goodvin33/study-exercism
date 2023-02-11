using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class AtbashCipher
    {
        //Plain:  abcdefghijklmnopqrstuvwxyz
        //Cipher: zyxwvutsrqponmlkjihgfedcba

        private static Dictionary<string, string> CodesLettersForChipher = new Dictionary<string, string> { };

        static AtbashCipher()
        {
            int indexLastLetterASCII = 122;
            int indexFirstLetterASCII = 97;

            for(int i = 0; i <=(indexLastLetterASCII-indexFirstLetterASCII); i++)
            {
                CodesLettersForChipher.Add(((char)(i+indexFirstLetterASCII)).ToString(), ((char)(indexLastLetterASCII-i)).ToString());
            }
        }

        private static string GetLetterToEncode(string letter)
        {
            string result= letter;
            foreach(KeyValuePair<string, string> pair in CodesLettersForChipher)
            {
                if(pair.Value == letter.ToLower())
                {
                    result = pair.Key;
                    break;
                }
            }
            return result;
        }

        private static string GetLetterToDecode(string letter)
        {
            string result = letter;
            foreach (KeyValuePair<string, string> pair in CodesLettersForChipher)
            {
                if (pair.Key == letter.ToLower())
                {
                    result = pair.Value;
                    break;
                }
            }
            return result;
        }

        public static string Encode(string plainValue)
        {
            plainValue = CleanString(plainValue);
            char[] charsOfResultString = new char[plainValue.Length];

            for(int i = 0; i < plainValue.Length; i++)
            {
                charsOfResultString[i] = Convert.ToChar(GetLetterToEncode(plainValue[i].ToString()));
            }   
            return SeparateEncodeValue(new string(charsOfResultString));
        }

        public static string Decode(string encodedValue)
        {
            encodedValue = CleanString(encodedValue);
            char[] charsOfResultString = new char[encodedValue.Length];

            for (int i = 0; i < encodedValue.Length; i++)
            {
                charsOfResultString[i] = Convert.ToChar(GetLetterToDecode(encodedValue[i].ToString()));
            }


            return new string(charsOfResultString);
        }

        private static string CleanString(string valueForClean) => new string(valueForClean.Where(x => Char.IsDigit(x) || Char.IsLetter(x)).ToArray());

        private static string SeparateEncodeValue(string encodedValue)
        {
            char[] groupedLetters = new char[] { };
            int counterLettersInGropup = 0;
            int counterLetterInValue = 0;

            while (counterLetterInValue < encodedValue.Length)
            {
                Array.Resize(ref groupedLetters, groupedLetters.Length + 1);
                if (counterLettersInGropup < 5)
                {
                    groupedLetters[groupedLetters.Length - 1] = encodedValue[counterLetterInValue];
                    counterLetterInValue++;
                    counterLettersInGropup++;
                }
                else
                {
                    groupedLetters[groupedLetters.Length - 1] = Convert.ToChar(" ");
                    counterLettersInGropup = 0;
                }
            }


           return new string(groupedLetters);
        }
    }

}
