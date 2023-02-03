using System;


namespace TestProject
{
    public static class Luhn
    {

        public static bool  IsValid(string number) => CleanString(number).Length > 1 && (DoublingNumbers(CleanString(number)).Select(x => Convert.ToInt64(x.ToString())).Sum() % 10 == 0) ;

        public static string CleanString(string number)
        {
            char[] onlyDigit = new char[0] { };
            foreach(char c in number)
            {
                if(Char.IsDigit(c))
                {
                    Array.Resize(ref onlyDigit, onlyDigit.Length + 1);
                    onlyDigit[onlyDigit.Length-1] = c;
                }
                else
                {
                    if(Char.IsSeparator(c) == false)
                    {
                        onlyDigit = new char[1]{Convert.ToChar("1")};
                        break;
                    } 
                }
            }
            return new string(onlyDigit);
        }

        public static string DoublingNumbers(string number)
        {
            number = new string(number.ToCharArray().Reverse().ToArray());
            char[] numbersAfterDoubling = new char[]{};
            for(int i = 0; i < number.Length ; i++)
            {
                Array.Resize(ref numbersAfterDoubling, numbersAfterDoubling.Length + 1);
                if (i%2 != 0)
                {
                    if (Convert.ToInt32(number[i].ToString())*2 >9)
                    {
                        numbersAfterDoubling[numbersAfterDoubling.Length - 1] = Convert.ToChar(((Convert.ToInt32(number[i].ToString()) * 2) - 9).ToString());
                    }
                    else
                    {
                        numbersAfterDoubling[numbersAfterDoubling.Length - 1] = Convert.ToChar((Convert.ToInt32(number[i].ToString()) * 2).ToString());
                    }
                }
                else
                {
                    numbersAfterDoubling[numbersAfterDoubling.Length - 1] = number[i];
                }
               
            }
            return new string(numbersAfterDoubling.Reverse().ToArray());
        }      
    }
}
