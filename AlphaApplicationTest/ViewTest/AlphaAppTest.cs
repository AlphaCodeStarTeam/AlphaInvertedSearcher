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
            
            Assert.Equal("Fuck", mockedOut.ToString());
        }
    }
}