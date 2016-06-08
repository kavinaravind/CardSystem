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
            var lines = await FileIO.ReadLinesAsync(file);
            foreach (string line in lines) {
                Document doc = new Document();
                doc.Load(line);
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
