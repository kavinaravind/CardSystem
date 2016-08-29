using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.FileLoaderModule
{
    class ItemList
    {
        Dictionary<string, Item> list;
        /// <summary>
        /// Initialize the item list
        /// </summary>
        internal void Init()
        {
            list = new Dictionary<string, Item>();
        }
        /// <summary>
        /// Deinitialize the item list
        /// </summary>
        internal void Deinit() {

        }
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        internal Item[] GetItem() {
            return list.Values.ToArray();
        }

        internal void AddItem(Item item)
        {
            string id = Guid.NewGuid().ToString();
            list.Add(id, item);
        }


    }
}
