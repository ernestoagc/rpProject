using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTransferObject;
using BusinessLogic;
using BusinessEntities;
namespace ServicioWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Servicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Servicio.svc o Servicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Servicio : IServicio
    {
        ConfiguracionBL configuracionBL = ConfiguracionBL.getConfiguracionBL;
        public List<InmuebleDTO> getInmuebles()
        {
            List<InmuebleBE> inmueblesBE =  configuracionBL.GetInmueble(null);
            return Helper.UtilFunction.getInmueblesDTO(inmueblesBE);
        }
    }
}
