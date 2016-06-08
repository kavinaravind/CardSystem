﻿using System;
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
        public async Task<Document[]> Init(String jsonFilePath) {
            list = new DocumentList();
            StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await folder.GetFileAsync(jsonFilePath);
            IList<string> lines = await FileIO.ReadLinesAsync(file);
            foreach (string line in lines) {
                Document doc = new Document();
                doc.Load(line);
                list.AddDocument(doc);
            }
            return list.GetDocument();
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

        public Document[] GetDocument() {
            return list.GetDocument();
        }
    }
}
