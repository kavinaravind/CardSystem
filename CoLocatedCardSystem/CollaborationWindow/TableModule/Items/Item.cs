using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.FileLoaderModule
{
    class Item
    {
        internal string GetID()
        {
            return "itemID:1234567";
        }

        internal string GetAll()
        {
            return "itemID:1234567\nage:89\nsize:01\ngender:Female";
        }
    }
}
