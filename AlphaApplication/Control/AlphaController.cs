using System;
using System.Collections.Generic;
using System.Linq;
using AlphaApplication.Model;
using AlphaInvertedSearcher.Engine;
using AlphaInvertedSearcher.InvertedMap;

namespace AlphaApplication.Control
{
    public class AlphaController
    {
        private static readonly int ExecuteQueryBoard = 3;
        private static readonly int DocsSummaryBoard = 10;

        private AlphaEngine _alphaEngine;
        private Map _map;

        public AlphaController()
        {
            _map = FileReader.GetMap();
        }

        public List<string> Search(string[] strings)
        {
            /*
            var newStrings = InitAlphaEngine(strings).ToList();
            foreach (var newString in newStrings)
            {
                AddWord(newString.Trim());
            }
            */
            InitAlphaEngine(strings).ToList().ForEach(word => AddWord(word.Trim()));
            return _alphaEngine.ExecuteQuery();
        }

        private void AddWord(string word)
        {
            char starter = word[0];
            switch (starter) {
                case '+':
                    _alphaEngine = _alphaEngine.AddLeastIncludes(word.Substring(1));
                    break;
                case '-':
                    _alphaEngine = _alphaEngine.AddExcludes(word.Substring(1));
                    break;
                default:
                    _alphaEngine = _alphaEngine.AddMustIncludes(word);
                    break;
            }
        }

        public string ViewDoc(string[] strings)
        {
            var isComplete = (strings.Length == 2);
            var docId = InitAlphaEngine(strings)[0];
            try
            {
                if (isComplete)
                {
                    var docContext = _alphaEngine.GetDocByID(docId);
                    return "Doc <"+ docId + ">: " +"\n" + docContext;
                }
                return _alphaEngine.GetDocByID(docId);
            }
            catch (DocumentNotFoundException e)
            {
                return "!Document Not Found!\n";
            }
        }
        
        private string[] InitAlphaEngine(string[] strings)
        {
            AlphaEngineBuilder alphaEngineBuilder = new AlphaEngineBuilder();
            if (strings[^1].Equals(" #all"))
            {
                alphaEngineBuilder.SetPrettyQuery();
                strings = strings.Take(strings.Length - 1).ToArray();
            }
            else
            {
                alphaEngineBuilder.SetPrettyQuery(ExecuteQueryBoard).SetSummarizedDoc();
            }
            _alphaEngine = alphaEngineBuilder.Create(_map);
            return strings;
        }
    }
}