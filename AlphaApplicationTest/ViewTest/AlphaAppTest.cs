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
            var expected = "Hello, This Is " + "Alpha-Inverted-Searcher" +  "." + 
                           "\n*-Enter <show help> to see the guidance-*" + "\n\n" +
                           "Alpha-Inverted-Searcher> " +
                           "7 Case(s) Found As Follows:\n" +
                           "\tDoc1: 58077\n" +
                           "\tDoc2: 58814\n" +
                           "\tDoc3: 59134\n" +
                           "\t\t.\n" +
                           "\t\t.\n" +
                           "\t\t.\n" +
                           "\tDoc7: 59615\n\r\n" +
                           "Alpha-Inverted-Searcher> " +
                           "AlphaTeam Appreciates Your Usage. GoodBye \n\n";
            Assert.Equal(expected, output);
        }

        [Fact]
        public void SearchAllQueryTest()
        {
            var output = getOutputFromInput("search +hello my world you your -men -women -man -women -language #all\nexit\n");            
            var expected = "Hello, This Is " + "Alpha-Inverted-Searcher" +  "." + 
                             "\n*-Enter <show help> to see the guidance-*" + "\n\n" +
                             "Alpha-Inverted-Searcher> " +
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
                             "Alpha-Inverted-Searcher> " +
                             "AlphaTeam Appreciates Your Usage. GoodBye \n\n";
            Assert.Equal(expected, output);
        }
            
        [Fact]
        public void ViewDocTest() {
            var output = getOutputFromInput("view doc 57110\nexit\n");
            var expected = "Hello, This Is " + "Alpha-Inverted-Searcher" +  "." + 
                           "\n*-Enter <show help> to see the guidance-*" + "\n\n" +
                           "Alpha-Inverted-Searcher> " +
                           "Doc <57110> Summary: \n" +
                           "I have a 42 yr old male friend, misdiagnosed as havin osteopporosis for two years,...\n\n" +
                           "Alpha-Inverted-Searcher> " +
                           "AlphaTeam Appreciates Your Usage. GoodBye \n\n";
            Assert.Equal(expected, output);
        }

        [Fact]
        public void ViewAllDocTest()
        {
            var output = getOutputFromInput("view doc 57110 #all\nexit\n");
            var expected = "Hello, This Is " + "Alpha-Inverted-Searcher" +  "." + 
                           "\n*-Enter <show help> to see the guidance-*" + "\n\n" +
                           "Alpha-Inverted-Searcher> " +
                           "Doc <57110>: \n" +
                           "I have a 42 yr old male friend, misdiagnosed as havin osteopporosis for two years, who recently found out that hi illness is the rare Gaucher's disease.Gaucher's disease symptoms include: brittle bones (he lost 9 inches off his hieght); enlarged liver and spleen; interna bleeding; and fatigue (all the time). The problem (in Type 1) i attributed to a genetic mutation where there is a lack of th enzyme glucocerebroside in macrophages so the cells swell up This will eventually cause deathEnyzme replacement therapy has been successfully developed an approved by the FDA in the last few years so that those patient administered with this drug (called Ceredase) report a remarkabl improvement in their condition. Ceredase, which is manufacture by biotech biggy company--Genzyme--costs the patient $380,00 per year. Gaucher\\'s disease has justifyably been called \"the mos expensive disease in the world\"NEED INFOI have researched Gaucher's disease at the library but am relyin on netlanders to provide me with any additional information**news, stories, report**people you know with this diseas**ideas, articles about Genzyme Corp, how to get a hold o   enough money to buy some, programs available to help wit   costs**Basically ANY HELP YOU CAN OFFEThanks so very muchDeborah\n\n" +
                           "Alpha-Inverted-Searcher> " +
                           "AlphaTeam Appreciates Your Usage. GoodBye \n\n";
            Assert.Equal(expected, output);
        }
            
        [Fact]
        public void ViewDocNotFoundTest() {
                var output = getOutputFromInput("view doc abc #all\nexit\n");
                var expected = "Hello, This Is " + "Alpha-Inverted-Searcher" +  "." + 
                               "\n*-Enter <show help> to see the guidance-*" + "\n\n" +
                               "Alpha-Inverted-Searcher> " +
                               "!Document Not Found!\n\r\n" +
                               "Alpha-Inverted-Searcher> " +
                               "AlphaTeam Appreciates Your Usage. GoodBye \n\n";
                Assert.Equal(expected, output);
        }
    }

}