using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CoLocatedCardSystem.CollaborationWindow.DocumentModule
{
    class DocumentController
    {
        DocumentList list;
        InteractionControllers interactionControllers;
        public DocumentController(InteractionControllers itcCtrlr) {
            this.interactionControllers = itcCtrlr;
        }
        /// <summary>
        /// Initialize documents from jsonFile
        /// </summary>
        /// <param name="jsonFilePath"></param>
        public async void Init(String jsonFilePath) {
            list = new DocumentList();
            StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await folder.GetFileAsync(jsonFilePath);
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            ulong size = stream.Size;

            using (var inputStream = stream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                    string allText = dataReader.ReadString(numBytesLoaded);
                    string[] lines = allText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach(string str in lines) {
                        Debug.WriteLine("TEXT: " + str);
                        Document doc = new Document();
                        doc.Load(str);
                        //list.AddDocument(doc);
                        //Debug.WriteLine(doc.GetContent());
                    }
                }
            }
        }
        /// <summary>
        /// Deinit the document module
        /// </summary>
        public void Deinit() {
            list.Clear();
        }
        /// <summary>
        /// Get the document by ID
        /// </summary>
        /// <param name="docID"></param>
        /// <returns></returns>
        Document GetDocument(string docID) {
            return list.GetDocument(docID);
        }
    }
}
