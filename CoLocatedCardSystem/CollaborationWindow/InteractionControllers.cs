using CoLocatedCardSystem.CollaborationWindow.DocumentModule;

namespace CoLocatedCardSystem.CollaborationWindow
{
    /// <summary>
    /// A central controller for all other controllers
    /// </summary>
    public class InteractionControllers
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
