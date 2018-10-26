using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataAccess.Modelo;
namespace DataAccess
{
    public class AreaDA
    {
        private static AreaDA instanciaAreaDA = null;
        public static AreaDA getAreaDA
        {
            get
            {
                if (instanciaAreaDA == null)
                    instanciaAreaDA = new AreaDA();
                return instanciaAreaDA;
            }
        }

        public List<AreaBE> Get(AreaBE.Criterio pCriterio)
        {
            List<AreaBE> listado = new List<AreaBE>();
            try
            {

                using (dbModelo db = new dbModelo())
                {
                    if (pCriterio == null)
                    {
                        var lstQuery = (from elem in db.AREA
                                        select new AreaBE()
                                        {
                                            ID = elem.ID,
                                            NOMBRE = elem.NOMBRE,
                                            INMUEBLE_CODIGO = elem.INMUEBLE


                                        });

                        if (lstQuery != null)
                        {
                            listado.AddRange(lstQuery.ToList());
                        }


                    }
                    else if (pCriterio != null)
                    {
                        if (pCriterio.USUARIO != null)
                        {
                            var lstQuery = (from elem in db.AREA
                                            join usuArea in db.USUARIO_AREA on elem.ID equals usuArea.AREA
                                            where usuArea.USUARIO == pCriterio.USUARIO
                                            select new AreaBE()
                                            {
                                                ID = elem.ID,
                                                NOMBRE = elem.NOMBRE,
                                                INMUEBLE_CODIGO = elem.INMUEBLE,
                                                USUARIO_ID = usuArea.USUARIO


                                            });

                            if (lstQuery != null)
                            {
                                listado.AddRange(lstQuery.ToList());
                            }

                        }




                    }



                        return listado;

                    }
                

            }
            catch (Exception ex)
            {
                throw;
            }

            return listado;
        }

        public AreaBE Insert(AreaBE pAreaBE)
        {
            int resultado = 0;
            try
            {
                AREA oAREA = new AREA();
                oAREA.NOMBRE = pAreaBE.NOMBRE;
                oAREA.INMUEBLE = pAreaBE.INMUEBLE_CODIGO;

                using (dbModelo db = new dbModelo())
                {
                    db.AREA.Add(oAREA);
                    resultado = db.SaveChanges();
                }

                pAreaBE.ID = oAREA.ID;


            }
            catch (Exception ex)
            {
                throw;
            }

            return pAreaBE;
        }


        public AreaBE Update(AreaBE pAreaBE)
        {
            int resultado = 0;
            try
            {

                using (dbModelo db = new dbModelo())
                {

                    AREA oAREA = (from elem in db.AREA where elem.ID == pAreaBE.ID select elem).FirstOrDefault();
                    oAREA.NOMBRE = pAreaBE.NOMBRE;
                    oAREA.INMUEBLE = pAreaBE.INMUEBLE_CODIGO;

                    resultado = db.SaveChanges();
                }



            }
            catch (Exception ex)
            {
                throw;
            }

            return pAreaBE;
        }


        public AreaBE Delete(AreaBE pAreaBE)
        {
            int resultado = 0;
            try
            {

                using (dbModelo db = new dbModelo())
                {
                    AREA oAREA = (from elem in db.AREA where elem.ID == pAreaBE.ID select elem).FirstOrDefault();
                    db.AREA.Remove(oAREA);
                    resultado = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return pAreaBE;
        }
    }
}
