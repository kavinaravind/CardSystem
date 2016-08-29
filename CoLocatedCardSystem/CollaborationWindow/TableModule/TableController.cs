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
        AttributeList attrList;
        ItemList itemList;
        public TableController(CentralControllers ctrls)
        {
            this.controllers = ctrls;
        }
        /// <summary>
        /// Initialize the table controller.
        /// </summary>
        /// <param name="cSVFile"></param>
        /// <returns></returns>
        internal async Task Init(string cSVFile)
        {
            itemList = new ItemList();
            itemList.Init();
            itemList.AddItem(new Item());
            itemList.AddItem(new Item());
            itemList.AddItem(new Item());
            attrList = new AttributeList();
            attrList.Init();
        }

        internal void Deinit()
        {
        }
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        internal Item[] GetItem() {
            return itemList.GetItem();
        }
    }
}
