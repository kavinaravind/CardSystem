using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.ClusterModule
{
    class ClusterController
    {
        CentralControllers controllers;
        Dictionary<string, Cluster> list;
        public ClusterController(CentralControllers ctrls)
        {
            this.controllers = ctrls;
        }

        internal void Init()
        {
            list = new Dictionary<string, Cluster>();
        }

        internal void Deinit()
        {
        }
    }
}
