using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBlablabla.Common.Entities
{
    public class EntChartResult
    {
            public bool success { get; private set; }
            public string[] periodos { get; private set; }
            public int[] aciertos { get; private set; }
            public int[] errores { get; private set; }

            public EntChartResult(bool succes_, string[] periodos_, int[] aciertos_, int[] errores_)
            {
                success = succes_;
                periodos = periodos_;
                aciertos = aciertos_;
                errores = errores_;
            }
        
    }
}
