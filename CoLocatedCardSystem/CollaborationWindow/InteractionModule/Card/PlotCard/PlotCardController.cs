using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoLocatedCardSystem.CollaborationWindow.TableModule;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class PlotCardController : CardController
    {
        public PlotCardController(CentralControllers ctrls) : base(ctrls)
        {
        }

        internal Task<Card[]> Init(TableModule.Attribute[] attributes)
        {
            throw new NotImplementedException();
        }
    }
}
