using System.Collections.Generic;

namespace AlphaInvertedSearcher.Engine
{
    public class AlphaEngineDocDecorator : AlphaEngine
    {
        private int board;

        public AlphaEngineDocDecorator(AlphaEngine decorate, int board) : base(decorate)
        {
            this.board = board;
        }

        protected override AlphaEngine CreateThisEngine(AlphaEngine decorate) => 
            new AlphaEngineDocDecorator(decorate, board);

        public override List<string> ExecuteQuery() => _decorate.ExecuteQuery();

        public override string GetDocByID(string docID)
        {
            string doc = _decorate.GetDocByID(docID);
            
            //Decorating doc
            doc = PrintModifiedWords(docID, doc);
            return doc;
        }
        
        private string PrintModifiedWords(string header, string context) {
            string answer = "Doc <"+ header + "> Summary: \n";
            int board = this.board;
            for (int i = 0; i < context.ToCharArray().Length; i++) {
                if(context[i] == ' ') {
                    board--;
                    if(board == 0)
                        break;
                    answer += " ";
                    for (; i < context.ToCharArray().Length && context[i] == ' '; i++);
                }

                answer += context[i];
            }

            answer += "...";
            return answer;
        }
        
    }
}