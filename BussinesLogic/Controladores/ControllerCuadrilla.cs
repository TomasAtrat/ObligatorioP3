using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonSolution.Dto;
using DataAccess.Persistencia;
using BussinesLogic.Interfaces;
using CommonSolution.Interfaces;

namespace BussinesLogic.Controladores
{
    public class ControllerCuadrilla : IControllers
    {
        private Repository repositorio;

        public ControllerCuadrilla()
        {
            this.repositorio = new Repository();
        }

        public  List<string> Alta(IDto dto)
        {
            List<string> errores = Verificar((DtoCuadrilla)dto) ;
            if(errores.Count() == 0)
            {
                if(!(VerificarExistencia(((DtoCuadrilla)dto).id)))
                {
                    this.repositorio.CuadrillaRepositorio.AltaCuadrilla((DtoCuadrilla)dto);
                }
                else
                {
                    errores.Add("Ya existe una cuadrilla con esta id");
                }
               
            }
            return errores;
        }

        public List<string> Baja(IDto dto)
        {
            List<string> errores = new List<string>();
            if (VerificarExistencia(((DtoCuadrilla)dto).id) == true)
            { 
            this.repositorio.CuadrillaRepositorio.BajaCuadrilla((DtoCuadrilla)dto);
            }
            else
            {
                errores.Add("No existe");

            }
            return errores;
        }

        public List<string> Modificacion(IDto dto)
        {

            List<string> errores = Verificar((DtoCuadrilla)dto);
            if (errores.Count() == 0)
            {
                if (VerificarExistencia(((DtoCuadrilla)dto).id))
                {
                    this.repositorio.CuadrillaRepositorio.ModificarCuadrilla((DtoCuadrilla)dto);
                }
                else
                {
                    errores.Add("No existe esta cuadrilla");
                }

            }
            return errores;
        }

        public bool VerificarExistencia(long id)
        {
            return this.repositorio.CuadrillaRepositorio.ExisteCuadrilla(id);
        }

        public List<DtoCuadrilla> ListadoDeCuadrillas()
        {
            return this.repositorio.CuadrillaRepositorio.ListarCuadrilla();
        }

        public List<string> Verificar(DtoCuadrilla cuadrilla)
        {
            List<string> errores = new List<string>();
            if (cuadrilla.encargado == null)
            {  
                errores.Add("Agregue un encargdo");
            }
            if(cuadrilla.nombre == null)
            {
                errores.Add("Agregue un nombre a la cuadrilla");
            }
            if(cuadrilla.cantidadPeones <= 0)
            {
                errores.Add("Coloque la cantidad de peones que hay en esta cuadrilla");
            }
            return errores;
        }
    }
}
