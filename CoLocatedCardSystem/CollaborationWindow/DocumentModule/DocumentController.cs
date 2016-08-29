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
        DocumentList list=new DocumentList();
        CentralControllers controllers;
        public DocumentController(CentralControllers ctrls) {
            this.controllers = ctrls;
        }
        /// <summary>
        /// Initialize documents from jsonFile
        /// </summary>
        /// <param name="jsonFilePath"></param>
        public async Task Init(String jsonFilePath) {
            StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await folder.GetFileAsync(jsonFilePath);
            using (var inputStream = await file.OpenReadAsync())
            using (var classicStream = inputStream.AsStreamForRead())
            using (var streamReader = new StreamReader(classicStream)) {
                while (streamReader.Peek() >= 0)
                {
                    string line=streamReader.ReadLine();
                    Document doc = new Document();
                    doc.Load(line);
                    list.AddDocument(doc);
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
        public Document GetDocument(string docID) {
            return list.GetDocument(docID);
        }
        /// <summary>
        /// Get all documents
        /// </summary>
        /// <returns></returns>
        public Document[] GetDocument() {
            return list.GetDocument();
        }
    }
}
