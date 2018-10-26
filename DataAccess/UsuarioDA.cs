using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataAccess.Modelo;
namespace DataAccess
{
    public class UsuarioDA
    {
        private static UsuarioDA instanciaUsuarioDA = null;
        public static UsuarioDA getUsuarioDA
        {
            get
            {
                if (instanciaUsuarioDA == null)
                    instanciaUsuarioDA = new UsuarioDA();
                return instanciaUsuarioDA;
            }
        }
        public UsuarioBE Insert(UsuarioBE pUsuarioBE)
        {
            int resultado = 0;
            try
            {
                USUARIO oUSUARIO = new USUARIO();
                oUSUARIO.NOMBRE = pUsuarioBE.NOMBRE;
                oUSUARIO.APELLIDO_MATERNO = pUsuarioBE.APELLIDO_MATERNO;
                oUSUARIO.APELLIDO_PATERNO = pUsuarioBE.APELLIDO_PATERNO;

                using (dbModelo db = new dbModelo())
                {
                    db.USUARIO.Add(oUSUARIO);
                    resultado = db.SaveChanges();
                }

                pUsuarioBE.ID = oUSUARIO.ID;


            }
            catch (Exception ex)
            {
                throw;
            }

            return pUsuarioBE;
        }

        public List<UsuarioBE> Get(UsuarioBE.Criterio pCriterio)
        {
            List<UsuarioBE> listado = new List<UsuarioBE>();
            try
            {

                using (dbModelo db = new dbModelo())
                {
                    var lstQuery = (from elem in db.USUARIO
                                    select new UsuarioBE()
                                    {
                                        ID = elem.ID,
                                        NOMBRE=elem.NOMBRE,
                                        APELLIDO_MATERNO=elem.APELLIDO_MATERNO,
                                        APELLIDO_PATERNO=elem.APELLIDO_PATERNO


                                    });

                    if (lstQuery != null)
                    {
                        listado.AddRange(lstQuery.ToList());
                    }



                    if (pCriterio != null)
                    {
                        if (!string.IsNullOrEmpty(pCriterio.NOMBRE))
                        {
                            listado = listado.FindAll(t => t.NOMBRE.Contains(pCriterio.NOMBRE));
                        }

                        return listado;
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
