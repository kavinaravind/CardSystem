using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.DocumentModule
{
    class ProcessedDocument
    {
        Token[] list;
        /// <summary>
        /// Initialize the token list with the content. Processed with token makers.
        /// </summary>
        /// <param name="content"></param>
        internal void InitTokens(string content) {
            Regex r = new Regex("([\\t{}():;., \"“”\n])");
            List<Token> tokenList = new List<Token>();
            string stack = "";
            //Partition the content with the regular expression.
            for (int i = 0; i < content.Length; i++)
            {
                if (r.IsMatch("" + content[i]))//Add a spliter
                {
                    Token tk = new Token();
                    tk.OriginalWord = "" + content[i];
                    tokenList.Add(tk);
                    if (stack.Length > 0)
                    {
                        Token token = new Token();
                        token.OriginalWord = stack;
                        tokenList.Add(token);
                        stack = "";
                    }
                }
                else//Add the letter to the word stack
                {
                    stack += content[i];
                }
            }
            foreach (Token tk in tokenList) {
                PunctuationMarker.Mark(tk);
                Stemmer.Stem(tk); // convert to root form
                StopwordMarker.Mark(tk);
                IrregularMarker.Mark(tk);
            }
            list = tokenList.ToArray<Token>();
        }
        /// <summary>
        /// Return the number of tokens whose original word is the same with the key work
        /// </summary>
        /// <param name="key">key word</param>
        /// <returns></returns>
        internal int CountToken(string key) {
            return 0;
        }
        /// <summary>
        /// Return a string of the whole document, in processed form.
        /// </summary>
        /// <returns></returns>
        public string GetProcessedDocument() {
            string result = "";
            foreach (Token token in list)
            {
                result += token.StemmedWord;
            }
            return result;
        }
    }
}
