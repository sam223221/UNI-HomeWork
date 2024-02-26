using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.test_folder
{
    internal static class funcTest
    {
        // Nameing convention - ClassName
        public static void worlddumbestfunction_returnbsPikaPikaIfZero_RetunString()
        {
            try 
            { 
                // Arrange - go get your varibles, what ever you need, og get functions
                int a = 0;
                worlddumbestfunction worldsdumbest = new worlddumbestfunction();


                // Act - execute this function
                string result = worldsdumbest.returnbsPikaPikaIfZero(a);


                // Assert - what ever retuns is what you want
                if (result == "PikaPika")
                {
                    Console.WriteLine("PASSED : worlddumbestfunction_returnbsPikaPikaIfZero_RetunString");
                }
                else
                {
                    Console.WriteLine("FAILED : worlddumbestfunction_returnbsPikaPikaIfZero_RetunString");
                }


            } catch (Exception e) 
            {
                Console.WriteLine("sometyhing went wrong " + e);
            }
        }
    }
}
