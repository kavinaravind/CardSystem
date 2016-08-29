using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoLocatedCardSystem.CollaborationWindow.FileLoaderModule;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class PlotCardController : CardController
    {
        public PlotCardController(CentralControllers ctrls) : base(ctrls)
        {
        }

        internal Task<Card[]> Init(FileLoaderModule.Attribute[] attributes)
        {
            throw new NotImplementedException();
        }
    }
}
