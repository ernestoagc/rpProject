using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataTransferObject;
namespace Helper
{
    public static class UtilFunction
    {
        public static InmuebleDTO getInmuebleDTO(InmuebleBE pInmuebleBE) {
            InmuebleDTO inmuebleDTO = new InmuebleDTO();
            inmuebleDTO.CODIGO = pInmuebleBE.CODIGO;
            inmuebleDTO.NOMBRE = pInmuebleBE.NOMBRE;
            return inmuebleDTO;
        }

        public static List<InmuebleDTO> getInmueblesDTO(List<InmuebleBE> pInmueblesBE)
        {
            List<InmuebleDTO> resultado = new List<InmuebleDTO>();

            foreach (InmuebleBE inmuebleBE in  pInmueblesBE) {
                resultado.Add(getInmuebleDTO(inmuebleBE));
            }
            return resultado;
        }
    }
}
