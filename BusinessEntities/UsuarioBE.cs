using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class UsuarioBE
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string AREAS_NOMBRES { get; set; }
        public List<AreaBE> AREAS { get; set; }

        public class Criterio{
            public string NOMBRE { get; set; }
        }
    }
}
