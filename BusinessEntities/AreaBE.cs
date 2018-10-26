using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AreaBE
    {
        public int ID { get; set; }
        public int USUARIO_ID { get; set; }
        public string NOMBRE { get; set; }

        public string INMUEBLE_CODIGO { get; set; }
        public string INMUEBLE_NOMBRE { get; set; }

        public class Criterio {
            public int? USUARIO { get; set; }
        }
    }
}
