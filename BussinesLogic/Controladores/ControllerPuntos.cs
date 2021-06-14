using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Persistencia;
using CommonSolution.Dto;
using BussinesLogic.Interfaces;
using CommonSolution.Interfaces;

namespace BussinesLogic.Controladores
{
    public class ControllerPuntos : IControllers
    {
        private Repository repositorio;

        public ControllerPuntos()
        {
            this.repositorio = new Repository();
        }

        public List<string> Alta(IDto dto)
        {
            List<string> errores = new List<string>();
            if(!(this.Verificacion(((DtoPunto)dto).id)))
            {
                this.repositorio.RepositoryDePunto.AddPuntos((DtoPunto)dto);
            }
            else
            {
                errores.Add("Ya existe un punto aqui");
            }
           
            return errores;
        }


        public List<string> Baja(IDto dto)
        {
            List<string> errores = new List<string>();
            if (this.Verificacion(((DtoPunto)dto).id))
            {
                this.repositorio.RepositoryDePunto.DeletePunto((DtoPunto)dto);
            }
            else
            {
                errores.Add("no existe este punto");
            }

            return errores;
        }

        public List<string> Modificacion(IDto dto)
        {
            List<string> errores = new List<string>();
            if (this.Verificacion(((DtoPunto)dto).id))
            {
                this.repositorio.RepositoryDePunto.UpDatePuntos((DtoPunto)dto);
            }
            else
            {
                errores.Add("no existe este punto");
            }

            return errores;
        }

        public bool Verificacion(long id)
        {
            return this.repositorio.RepositoryDePunto.SearchPunto(id);
        }
    }
}
