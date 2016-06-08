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
        Card attachedCard = null;

        /// <summary>
        /// Load the document to the card
        /// </summary>
        /// <param name="doc"></param>
        internal virtual async Task SetArticle(Document doc) {

        }
        /// <summary>
        /// Initialize the card alyers
        /// </summary>
        /// <param name="card"></param>
        internal virtual void Init(Card card) {
            this.attachedCard = card;
        }
    }
}
