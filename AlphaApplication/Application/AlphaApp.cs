using System;

namespace AlphaApplication.Application
{
    public class AlphaApp : App
    {
        public AlphaApp(Tuple<string, ConsoleColor> applicationIntro, Tuple<string, ConsoleColor> applicationRun, Tuple<string, ConsoleColor> applicationHelp, Tuple<string, ConsoleColor> applicationExit) : base(applicationIntro, applicationRun, applicationHelp, applicationExit)
        {
            throw new NotImplementedException();
        }

        protected override void InitExecutors()
        {
            Executors.Add("^show help$", args => ShowHelp());
            Executors.Add("^exit$", args => Exit());
            throw new NotImplementedException();
        }
    }
}