using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.TableModule
{
    class Item
    {
        public Dictionary<Attribute, Cell> cellList;
        public String uuid { get; set; }

        public Item()
        {
            Init();
        }

        public void Init()
        {
            cellList = new Dictionary<Attribute, Cell>();
        }

        public string GetID()
        {
            return uuid;
        }

        public String GetAll()
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (Attribute attr in cellList.Keys)
            {
                strBuilder.Append(attr.name + ": " + cellList[attr].data + "\n");
            }

            return strBuilder.ToString();
        }

    }
}
