using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CallWebAPIAsync()
                .Wait();
        }
        static asyncTaskCallWebAPIAsync()
        {
            using (var client = newHttpClient())
            {
                //Send HTTP requests from here.  
            }
        }

    }
}
