using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow
{
    /// <summary>
    /// A central controller for all other controllers
    /// </summary>
    class InteractionControllers
    {
        DocumentController documentController;
        /// <summary>
        /// Initialize all documents
        /// </summary>
        public void Init() {
            documentController = new DocumentController(this);
            documentController.Init(FilePath.NewsArticle);//Load the document
        }

        internal void Deinit()
        {
            documentController.Deinit();
        }
    }
}
