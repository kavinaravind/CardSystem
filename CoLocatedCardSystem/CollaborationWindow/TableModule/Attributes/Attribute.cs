using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.TableModule
{
    class Attribute
    {
        public String name { get; set; }
        public ATTRIBUTETYPE type { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public List<String> values { get; set; }

        public Attribute()
        {

        }
    }
}
