using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Modelo;
using BusinessEntities;
namespace DataAccess
{
    public class UsuarioAreaDA
    {
        private static UsuarioAreaDA instanciaUsuarioAreaDA = null;
        public static UsuarioAreaDA getUsuarioAreaDA
        {
            get
            {
                if (instanciaUsuarioAreaDA == null)
                    instanciaUsuarioAreaDA = new UsuarioAreaDA();
                return instanciaUsuarioAreaDA;
            }
        }

        public UsuarioAreaBE Insert(UsuarioAreaBE pUsuarioAreaBE)
        {
            int resultado = 0;
            try
            {
                USUARIO_AREA oUSUARIO_AREA = new USUARIO_AREA();
                oUSUARIO_AREA.AREA = pUsuarioAreaBE.AREA;
                oUSUARIO_AREA.USUARIO = pUsuarioAreaBE.USUARIO;

                using (dbModelo db = new dbModelo())
                {
                    db.USUARIO_AREA.Add(oUSUARIO_AREA);
                    resultado = db.SaveChanges();
                }

                pUsuarioAreaBE.ID = oUSUARIO_AREA.ID;


            }
            catch (Exception ex)
            {
                throw;
            }

            return pUsuarioAreaBE;
        }

        public UsuarioAreaBE Delete(UsuarioAreaBE pUsuarioAreaBE)
        {
            int resultado = 0;
            try
            {

                using (dbModelo db = new dbModelo())
                {
                    USUARIO_AREA oUSUARIO_AREA = (from elem in db.USUARIO_AREA where elem.ID == pUsuarioAreaBE.ID select elem).FirstOrDefault();
                    db.USUARIO_AREA.Remove(oUSUARIO_AREA);
                    resultado = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return pUsuarioAreaBE;
        }

        public UsuarioAreaBE DeleteAreas(UsuarioAreaBE pUsuarioAreaBE)
        {
            int resultado = 0;
            try
            {

                using (dbModelo db = new dbModelo())
                {
                    var oUSUARIO_AREAS = (from elem in db.USUARIO_AREA where elem.AREA == pUsuarioAreaBE.AREA select elem).ToList();
                    db.USUARIO_AREA.RemoveRange(oUSUARIO_AREAS);
                    resultado = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return pUsuarioAreaBE;
        }
    }
}
