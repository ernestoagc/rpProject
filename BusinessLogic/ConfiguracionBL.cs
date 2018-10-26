using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataAccess;
using System.Transactions;
namespace BusinessLogic
{
    public class ConfiguracionBL
    {

        AreaDA areaDA = AreaDA.getAreaDA;
        UsuarioDA usuarioDA = UsuarioDA.getUsuarioDA;

        UsuarioAreaDA usuarioAreaDA = UsuarioAreaDA.getUsuarioAreaDA;
        InmuebleDA inmuebleDA = InmuebleDA.getInmuebleDA;
        private static ConfiguracionBL instanciaConfiguracionBL = null;
        public static ConfiguracionBL getConfiguracionBL
        {
            get
            {
                if (instanciaConfiguracionBL == null)
                    instanciaConfiguracionBL = new ConfiguracionBL();
                return instanciaConfiguracionBL;
            }
        }



        #region Funciones AplicativoWeb
        public List<UsuarioBE> GetUsuario(UsuarioBE.Criterio pCriterio)
        {

            List<UsuarioBE> usuarios = usuarioDA.Get(pCriterio);

            foreach (UsuarioBE usuarioBE in usuarios)
            {
                AreaBE.Criterio criterioArea = new AreaBE.Criterio();
                criterioArea.USUARIO = usuarioBE.ID;
                usuarioBE.AREAS = new List<AreaBE>();
                usuarioBE.AREAS.AddRange(areaDA.Get(criterioArea));
                usuarioBE.AREAS_NOMBRES = "";
                foreach (AreaBE areaBE in usuarioBE.AREAS)
                {
                    usuarioBE.AREAS_NOMBRES = usuarioBE.AREAS_NOMBRES + "-" + areaBE.NOMBRE;
                }


            }

            return usuarios;
        }

        public List<AreaBE> GetArea(AreaBE.Criterio pCriterio)
        {
            return areaDA.Get(pCriterio);
        }

        public AreaBE InsertArea(AreaBE pAreaBE)
        {
            return areaDA.Insert(pAreaBE);
        }

        public AreaBE UpdateArea(AreaBE pAreaBE)
        {
            return areaDA.Update(pAreaBE);
        }


        public AreaBE DeleteArea(AreaBE pAreaBE)
        {

            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                UsuarioAreaBE usuarioAreaBE = new UsuarioAreaBE() {AREA= pAreaBE.ID};
                usuarioAreaDA.DeleteAreas(usuarioAreaBE);
                areaDA.Delete(pAreaBE);

                transactionScope.Complete();
            }
            return pAreaBE;
        }

        public UsuarioBE InsertUsuario(UsuarioBE usuarioBE)
        {


            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                usuarioDA.Insert(usuarioBE);

                foreach (AreaBE areaBE in usuarioBE.AREAS)
                {
                    UsuarioAreaBE usuarioAreaBE = new UsuarioAreaBE();
                    usuarioAreaBE.AREA = areaBE.ID;
                    usuarioAreaBE.USUARIO = usuarioBE.ID;
                    usuarioAreaDA.Insert(usuarioAreaBE);
                }

                transactionScope.Complete();
            }

            return usuarioBE;
        }
        #endregion




        #region Funcciones webService

        public List<InmuebleBE> GetInmueble(InmuebleBE.Criterio pCriterio) {
            return inmuebleDA.Get(pCriterio);
        }

        #endregion

    }
}
