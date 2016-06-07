using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.DocumentModule
{
    class StopwordMarker
    {
        static string[] stopwords;
        static string fileLoc = @"data\stopwords.txt";
        public StopwordMarker() {
            Load();
        }
        /// <summary>
        /// Load the stopwords from the txt file
        /// </summary>
        private static async void Load()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync(@"data\stopwords.txt");
        }
        /// <summary>
        /// Mark the stop words
        /// </summary>
        /// <param name="token"></param>
        internal static void Mark(Token token) {

        }
    }
}
