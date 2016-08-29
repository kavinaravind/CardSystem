using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class DocumentCardLayer3 : DocumentCardLayerBase
    {
        public DocumentCardLayer3(Card card) : base(card)
        {
        }

        internal override async Task SetArticle(Document doc)
        {
            await base.SetArticle(doc);
        }
    }
}
