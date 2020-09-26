using System;
using System.IO;
using AlphaApplication.Application;
using Xunit;

namespace AlphaApplicationTest.ViewTest
{
    public class AlphaAppTest
    {
        [Fact]
        public void SearchQueryTest()
        {
            var originalConsoleOut = Console.Out;
            var originalConsoleIn = Console.In;

            StringWriter mockedOut = new StringWriter();
            StringReader mockedIn = new StringReader("search hello\nexit\n");
            
            Console.SetOut(mockedOut);
            Console.SetIn(mockedIn);
            
            AlphaApp alphaApp = new AlphaApp();
            alphaApp.run();
            var expected = "Hello, This Is " + "Alpha-Avg" +  "." + 
                           "\n*-Enter <show help> to see the guidance-*" + "\n\n" +
                           "Alpha-Avg> " +
                           "7 Case(s) Found As Follows:\n" +
                           "\tDoc1: 58077\n" +
                           "\tDoc2: 58814\n" +
                           "\tDoc3: 59134\n" +
                           "\t\t.\n" +
                           "\t\t.\n" +
                           "\t\t.\n" +
                           "\tDoc7: 59615\n\r\n" +
                           "Alpha-Avg> " +
                           "AlphaTeam Appreciates Your Usage. GoodBye \n\n";
            Assert.Equal(expected, mockedOut.ToString());
        }
    }
}