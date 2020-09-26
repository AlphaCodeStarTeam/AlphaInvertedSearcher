using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AlphaApplication.Control;
using AlphaInvertedSearcher.Engine;

namespace AlphaApplication.Application
{
    public class AlphaApp : App
    {
        public static class AlphaDesign
        {
            internal static readonly Tuple<string, ConsoleColor> AlphaRun = new Tuple<string, ConsoleColor>("Alpha-Avg", ConsoleColor.Magenta);
            
            internal static readonly Tuple<string, ConsoleColor> AlphaIntro = new Tuple<string, ConsoleColor>("Hello, This Is " + AlphaRun.Item1 + "." +
                                                                                                              "\n*-Enter <show help> to see the guidance-*" +
                                                                                                              "\n", ConsoleColor.DarkCyan);
            
            internal static readonly Tuple<String, ConsoleColor> AlphaHelp = new Tuple<string, ConsoleColor>("-* Commands(IgnoreCase): \n" +
                                                                                                             "-> search <must include> <+includes> <-excludes> (e.g. search stack ram data +software +engineer -hardware)\n" +
                                                                                                             "-> show help \n" +
                                                                                                             "-> exit \n", ConsoleColor.DarkGreen);

            internal static readonly Tuple<string, ConsoleColor> AlphaExit = new Tuple<string, ConsoleColor>("AlphaTeam Appreciates Your Usage. GoodBye \n", ConsoleColor.Black);
        }
        
        private static readonly ConsoleColor HeaderColor = ConsoleColor.DarkYellow;
        private static readonly ConsoleColor ContextColor = ConsoleColor.DarkCyan;

        private AlphaController _alphaController = new AlphaController();

        public AlphaApp() : 
            base(AlphaDesign.AlphaIntro, AlphaDesign.AlphaRun, AlphaDesign.AlphaExit) { }

        protected override void InitExecutors()
        {
            Executors.Add("^search( \\S+)+$", args => Search(args));
            Executors.Add("^view doc (\\S+){1,20}$", args => ViewDoc(args));
            Executors.Add("^view doc (\\S+){1,20}( #all)$", args => ViewDoc(args));
            Executors.Add("^show help$", args => ShowHelp());
            Executors.Add("^exit$", args => Exit());
        }

        private void ShowHelp()
        {
            PrintWithDesign(AlphaDesign.AlphaHelp.Item1, true, DefaultBackGroundColor, AlphaDesign.AlphaHelp.Item2);
        }
        
        private void Exit()
        {
            throw new ExitException();
        }
        
        private void Search(String[] strings)
        {
            List<string> result = _alphaController.Search(strings);
            PrintWithDesign(result[0], true, DefaultBackGroundColor, HeaderColor);
            result.Skip(1).ToList().ForEach(line => 
                PrintWithDesign(line, true, DefaultBackGroundColor, ContextColor));
            Console.WriteLine();
        }
        
        private void ViewDoc(string[] args)
        {
            var result = _alphaController.ViewDoc(args);
            var splits = result.Split("\n");
            PrintWithDesign(splits[0], true, DefaultBackGroundColor, HeaderColor);
            var builder = new StringBuilder();
            for (int i = 1; i < splits.Length; i++)
            {
                builder.Append(splits[i] + "\n");
            }

            if (!builder.ToString().Equals("\n"))
            {
                PrintWithDesign(builder.ToString(), true, DefaultBackGroundColor, ContextColor);
            }
            else
            {
                Console.WriteLine();
            }
        }
        
    }
}