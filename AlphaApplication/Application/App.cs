using System;
using System.Collections.Generic;

namespace AlphaApplication.Application
{
    public abstract class App : Executable
    {
        private readonly Tuple<string, ConsoleColor> ApplicationIntro;
        private readonly Tuple<string, ConsoleColor> ApplicationRun;
        private readonly Tuple<string, ConsoleColor> ApplicationHelp;
        private readonly Tuple<string, ConsoleColor> ApplicationExit;


        protected readonly ConsoleColor DefaultBackGroundColor = Console.BackgroundColor;
        protected readonly ConsoleColor DefaultForeGroundColor = Console.ForegroundColor;
        protected readonly ConsoleColor ErrorForeGround = ConsoleColor.DarkRed;
        
        
        protected App(Tuple<string, ConsoleColor> applicationIntro, 
            Tuple<string, ConsoleColor> applicationRun, 
            Tuple<string, ConsoleColor> applicationHelp, 
            Tuple<string, ConsoleColor> applicationExit)
        {
            ApplicationRun = applicationRun;
            ApplicationExit = applicationExit;
            ApplicationIntro = applicationIntro;
            ApplicationHelp = applicationHelp;
            
            SayHello();
            InitExecutors();
        }

        public void run()
        {
            string commandPrefix = ApplicationRun.Item1 + "> ";
            string input = "";
            while (true)
            {
                PrintWithDesign(commandPrefix, false, DefaultBackGroundColor, ApplicationRun.Item2);
                input = Console.ReadLine().Trim().ToLower();

                try
                {
                    ExecuteCommand(input);
                }
                catch (MethodNotFoundException e)
                {
                    PrintErr("Invalid Command", true);
                }
                catch (ExitException e)
                {
                    PrintWithDesign(ApplicationExit.Item1, true, DefaultBackGroundColor, ApplicationExit.Item2);
                    break;
                }
            }
        }

        protected void SayHello()
        {
            PrintWithDesign(ApplicationIntro.Item1, true, DefaultBackGroundColor, ApplicationIntro.Item2);
        }


        protected void ShowHelp()
        {
            PrintWithDesign(ApplicationHelp.Item1, true, DefaultBackGroundColor, ApplicationHelp.Item2);
        }
        
        private void Exit()
        {
            throw new ExitException();
        }

        protected void PrintWithDesign(string text, bool isLine, ConsoleColor backGroundColor , ConsoleColor foreGroundColor)
        {
            Console.BackgroundColor = backGroundColor;
            Console.ForegroundColor = foreGroundColor;

            Console.Write("{0}{1}", text, (isLine ? "\n" : ""));

            Console.BackgroundColor = DefaultBackGroundColor;
            Console.ForegroundColor = DefaultForeGroundColor;
        }

        protected void PrintErr(string text, bool isLine)
        {
            PrintWithDesign(text + "\n", isLine, DefaultBackGroundColor, ErrorForeGround);
        }

    }
    
    public class ExitException : Exception { }
}