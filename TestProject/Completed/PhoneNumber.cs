using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class PhoneNumber
    {
        public static string Clean(string phoneNumber)
        {
            string cleanedPhoneNumber = CleanPhoneNumber(phoneNumber);

            //(NXX)-NXX-XXXX
            if(cleanedPhoneNumber.Length == 11 && CheckCorrectedCountryCode(cleanedPhoneNumber))
            {                
                cleanedPhoneNumber = cleanedPhoneNumber.Substring(1, 10);
            }
            
            if(cleanedPhoneNumber.Length == 10 && (Convert.ToInt32(cleanedPhoneNumber[0].ToString()) >=2 && 9 >=Convert.ToInt32(cleanedPhoneNumber[0].ToString())) && (Convert.ToInt32(cleanedPhoneNumber[3].ToString()) >= 2 && 9 >= Convert.ToInt32(cleanedPhoneNumber[3].ToString())))
            {
                return cleanedPhoneNumber;
            }
            else
            {
                throw new ArgumentException();
            }   
        }
        
        public static string CleanPhoneNumber(string phoneNumber) =>  new(phoneNumber.Where(c => Char.IsDigit(c)).ToArray());

        public static bool CheckCorrectedCountryCode (string phoneNumber)
        {
             if(phoneNumber.Length > 10)
            {
                if(Convert.ToInt32(phoneNumber[0].ToString()) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
             else
            {
               return true;
            }
        }
        
    }
}
