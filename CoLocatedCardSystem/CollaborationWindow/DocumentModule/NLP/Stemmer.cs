namespace CoLocatedCardSystem.CollaborationWindow.DocumentModule
{
    class Stemmer
    {
        private static PorterStemmer stemmer = new PorterStemmer();

        /// <summary>
        /// Stem the token
        /// </summary>
        /// <param name="token"></param>
        internal static void Stem(Token token) {
            string word = token.OriginalWord.ToLower();
            token.StemmedWord = stemmer.stemTerm(word);
            if (token.Type == WordType.DEFAULT) {
                token.Type = WordType.REGULAR;
            }
        }

        internal static string Stem(string str) {
            return stemmer.stemTerm(str);
        }
    }
}
