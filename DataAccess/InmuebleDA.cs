using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataAccess.Modelo;


namespace DataAccess
{
    public class InmuebleDA
    {
        private static InmuebleDA instanciaInmuebleDA = null;
        public static InmuebleDA getInmuebleDA
        {
            get
            {
                if (instanciaInmuebleDA == null)
                    instanciaInmuebleDA = new InmuebleDA();
                return instanciaInmuebleDA;
            }
        }

        public List<InmuebleBE> Get(InmuebleBE.Criterio pCriterio)
        {
            List<InmuebleBE> listado = new List<InmuebleBE>();
            try
            {

                using (dbModelo db = new dbModelo())
                {
                    if (pCriterio == null)
                    {
                        var lstQuery = (from elem in db.INMUEBLE
                                        select new InmuebleBE()
                                        {
                                            ID = elem.ID,
                                            NOMBRE = elem.NOMBRE,
                                            CODIGO = elem.CODIGO


                                        });

                        if (lstQuery != null)
                        {
                            listado.AddRange(lstQuery.ToList());
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return listado;
        }


    }
}
