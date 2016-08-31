using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.TableModule
{
    class ItemList
    {
        public Dictionary<String, Item> itemList;

        public ItemList()
        {
            Init();
        }

        public void Init()
        {
            itemList = new Dictionary<String, Item>();
        }

        public void DeInit()
        {
            itemList.Clear();
            itemList = null;
        }

        public void ClearList()
        {
            itemList.Clear();
        }

        public Item[] getItem()
        {
            return itemList.Values.ToArray();
        }

        public bool AddItem(Item item)
        {
            String id = Guid.NewGuid().ToString();
            item.uuid = id;
            if (item != null)
            {
                itemList.Add(id, item);
                return true;
            }
            return false;
        }

        public bool RemoveItem(String id)
        {
            if (itemList.ContainsKey(id))
            {
                itemList.Remove(id);
                return true;
            }
            return false;
        }
    }
}
