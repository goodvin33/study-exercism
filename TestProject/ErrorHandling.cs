using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class ErrorHandling
    {
        public static void HandleErrorByThrowingException()
        {
            throw new Exception(); 
        }

        public static int? HandleErrorByReturningNullableType(string input)
        {
            int? result;
            if(Int32.TryParse(input, out int number))
            {
                result = number;
            }
            else
            {
                result=null;
            }
           return result;
        }

        public static bool HandleErrorWithOutParam(string input, out int result)
        {
            if(int.TryParse(input, out int number))
            {
                result = number;
                return true;
            }
            else
            {
                result = number;
                return false;
            }  
        }

        public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
        {
            disposableObject.Dispose();
            throw new Exception();
        }

    }
}
