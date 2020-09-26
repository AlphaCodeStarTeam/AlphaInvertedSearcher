using System;
using System.IO;
using AlphaApplication.Application;
using Xunit;

namespace AlphaApplicationTest.ViewTest
{
    public class AlphaAppTest
    {

        public string getOutputFromInput(string input)
        {
            var originalConsoleOut = Console.Out;
            var originalConsoleIn = Console.In;

            StringWriter mockedOut = new StringWriter();
            StringReader mockedIn = new StringReader(input);
            
            Console.SetOut(mockedOut);
            Console.SetIn(mockedIn);
            
            AlphaApp alphaApp = new AlphaApp();
            alphaApp.run();
            return mockedOut.ToString();
        }
        
        [Fact]
        public void SearchQueryTest()
        {
            var output = getOutputFromInput("search hello\nexit\n");
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
            Assert.Equal(expected, output);
        }

        [Fact]
        public void SearchAllQueryTest()
        {
            var output = getOutputFromInput("search +hello my world you your -men -women -man -women -language #all\nexit\n");            
            var expected = "Hello, This Is " + "Alpha-Avg" +  "." + 
                             "\n*-Enter <show help> to see the guidance-*" + "\n\n" +
                             "Alpha-Avg> " +
                             "13 Case(s) Found As Follows:\n" +
                             "\tDoc1: 58578\n" +
                             "\tDoc2: 58882\n" +
                             "\tDoc3: 59295\n" +
                             "\tDoc4: 59231\n" +
                             "\tDoc5: 58986\n" +
                             "\tDoc6: 59226\n" +
                             "\tDoc7: 59207\n" +
                             "\tDoc8: 59261\n" +
                             "\tDoc9: 59134\n" +
                             "\tDoc10: 58814\n" +
                             "\tDoc11: 59615\n" +
                             "\tDoc12: 58077\n" +
                             "\tDoc13: 59637\n\r\n" +
                             "Alpha-Avg> " +
                             "AlphaTeam Appreciates Your Usage. GoodBye \n\n";
            Assert.Equal(expected, output);
        }
    }
}