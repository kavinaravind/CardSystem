using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class LayerBase:Canvas
    {
        protected Card attachedCard = null;

        /// <summary>
        /// Load the document to the card
        /// </summary>
        /// <param name="doc"></param>
        internal virtual async Task SetArticle(Document doc) {

        }
        public LayerBase(Card card) {
            attachedCard = card;
        }

        internal virtual async void Init() {

        }
    }
}
