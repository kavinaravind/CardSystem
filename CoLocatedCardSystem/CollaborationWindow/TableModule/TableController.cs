using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.FileLoaderModule
{
    class TableController
    {
        CentralControllers controllers;
        public TableController(CentralControllers ctrls)
        {
            this.controllers = ctrls;
        }
        /// <summary>
        /// Initialize the table controller.
        /// </summary>
        /// <param name="cSVFile"></param>
        /// <returns></returns>
        internal async Task<Item[]> Init(string cSVFile)
        {
            Item[] items = new Item[] { new Item(), new Item(), new Item(), };
            return items;
        }

        internal void Deinit()
        {
        }
    }
}
