using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoLocatedCardSystem.CollaborationWindow.ClusterModule;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class ClusterCardController : CardController
    {
        public ClusterCardController(CentralControllers ctrls) : base(ctrls)
        {
        }

        internal Task<Card[]> Init(Cluster[] clusters)
        {
            throw new NotImplementedException();
        }
    }
}
