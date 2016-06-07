using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Init(String jsonFilePath) {
            //TO DO initialize the document list.
            list = new DocumentList();
            string nextLine = "";
            while (nextLine != null) {
                list.AddDocument(nextLine);
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
