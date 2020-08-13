using System;
using System.Collections.Generic;
using System.Linq;
using AlphaInvertedSearcher.InvertedMap;

namespace AlphaInvertedSearcher.Engine
{
    public class AlphaEngine
    {
        private HashSet<string> resultSet = new HashSet<string>();
        private HashSet<string> norms = new HashSet<string>();
        private HashSet<string> poss = new HashSet<string>();
        private HashSet<string> negs = new HashSet<string>();



        public AlphaEngine AddNorms(params string[] norms)
        {
            AlphaEngine alphaEngine = this.MemberwiseClone() as AlphaEngine;
            alphaEngine.norms.UnionWith(norms);
            return alphaEngine;
        }

        public AlphaEngine AddPoss(params string[] poss)
        {
            AlphaEngine alphaEngine = this.MemberwiseClone() as AlphaEngine;
            alphaEngine.poss.UnionWith(poss);
            return alphaEngine;
        }

        public AlphaEngine AddNegs(params string[] negs)
        {
            AlphaEngine alphaEngine = this.MemberwiseClone() as AlphaEngine;
            alphaEngine.negs.UnionWith(negs);
            return alphaEngine;
        }

        public List<string> ExecuteQuery()
        {
            //TODO
            // ModifyResultForNorms(); ModifyResultForPoss(); ModifyResultForNegs();
            return resultSet.ToList();
        } 
        
        /*private void ModifyResultForNorms() {
            foreach (string norm in norms)
                resultSet.UnionWith(GetDocsByKeyword(norm));
            
            foreach (var docId in GetAndPrimedSet())
                resultSet.Remove(docId);
        }

        private HashSet<string> GetAndPrimedSet() {
            HashSet<string> hashSetPrime = new HashSet<string>();
            foreach (string norm in norms)  {
                HashSet<string> hashSet = new HashSet<string>(resultSet);
                foreach (var docId in GetDocsByKeyword(norm))
                    hashSet.Remove(docId);
                hashSetPrime.UnionWith(hashSet);
            }
            return hashSetPrime;
        }

        private void ModifyResultForPoss() {
            foreach (string word in poss) {
                resultSet.UnionWith(GetDocsByKeyword(word));
            }
        }
        
        private void ModifyResultForNegs() {
            foreach (string keyword in negs)
            {
                foreach (string docId in GetDocsByKeyword(keyword))
                {
                    resultSet.Remove(docId);
                }
            }
        }*/
    }
    

    
}