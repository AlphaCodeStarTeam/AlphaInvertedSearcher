using System;
using AlphaInvertedSearcher.InvertedMap;

namespace AlphaInvertedSearcher.Engine
{
    public class AlphaEngineBuilder
    {
        private bool _isDocSummerized = false, isQueryPretty = false;
        private int summerizedDocBoard, prettyQueryBoard;

        public void SetSummarizedDoc(int board = 15)
        {
            summerizedDocBoard = board;
            _isDocSummerized = true;
        }

        public void SetPrettyQuery(int board = Int32.MaxValue)
        {
            isQueryPretty = true;
            prettyQueryBoard = board;
        }

        public AlphaEngine Create(Map map)
        {
            AlphaEngine alphaEngine = new AlphaEngine(map);

            if (_isDocSummerized)
                alphaEngine = new AlphaEngineDocDecorator(alphaEngine, summerizedDocBoard);
            if (isQueryPretty)
                alphaEngine = new AlphaEngineQueryDecorator(alphaEngine, prettyQueryBoard);

            return alphaEngine;
        }
    }
}