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
    public class ControllerPuntos : IControllersAbm
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
                this.repositorio.PuntoRepository.AddPuntos((DtoPunto)dto);
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
                this.repositorio.PuntoRepository.DeletePunto((DtoPunto)dto);
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
                this.repositorio.PuntoRepository.UpDatePuntos((DtoPunto)dto);
            }
            else
            {
                errores.Add("no existe este punto");
            }

            return errores;
        }

        public bool Verificacion(long id)
        {
            return this.repositorio.PuntoRepository.SearchPunto(id);
        }

        public List<string> AddPointList(List<IDto> dto)
        {
            List<string> errores = new List<string>();
            foreach(DtoPunto i in dto)
            {
                if (!(this.Verificacion(i.id)))
                {
                    this.repositorio.PuntoRepository.AddPuntos(i);
                }
                else
                {
                    errores.Add(i.id + "Ya existe un punto aqui");
                }
            }
            

            return errores;
        }

        public List<IDto> ListAll()
        {
            return this.repositorio.PuntoRepository.getElements().Cast<IDto>().ToList();
        }
    }
}
