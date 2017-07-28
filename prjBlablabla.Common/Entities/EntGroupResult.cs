using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBlablabla.Common.Entities
{
    public class EntGroupResult
    {
        public bool success { get; private set; }
        public string[] grupos { get; private set; }

        public EntGroupResult(bool succes_, string[] grupos_)
        {
            success = succes_;
            grupos = grupos_;
        }
    }
}
