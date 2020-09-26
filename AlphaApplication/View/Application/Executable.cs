using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AlphaApplication.Application
{
    public abstract class Executable
    {
        protected Dictionary<string, Execute> Executors { get; } = new Dictionary<string, Execute>();
        
        protected delegate void Execute(params string[] args);
        
        protected abstract void InitExecutors();

        protected void ExecuteCommand(string command)
        {
            Match match;
            foreach (var inputRegex in Executors.Keys)
            {
                match = Regex.Match(command, inputRegex);
                if (match.Success)
                {
                    Executors[inputRegex].Invoke(GetParameters(match.Groups));
                    return;
                }
            }

            throw new MethodNotFoundException();
        }

        private static string[] GetParameters(GroupCollection groupCollection)
        {
            var parameters = new List<string>();
            for (int i = 1; i < groupCollection.Count; i++)
            {
                parameters.AddRange(groupCollection[i].Captures.ToList().Select(capture => capture.ToString()).ToList());
            }

            return parameters.ToArray();
        }
    }

    public class MethodNotFoundException : Exception { }
}