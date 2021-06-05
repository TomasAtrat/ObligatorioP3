using CommonSolution.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public class PartidoController
    {
        public PartidoController()
        {
            this.repository = new Repository();
        }

        private Repository repository;

        public void NuevoPartido(DtoPartido dto)
        {
            List<String> colErrores = this.Validate(dto);
            if (colErrores.Count == 0)
                this.repository.PartidoRepository.NuevoPartido(dto);
        }

        public void IniciarPartido(DtoPartido dto)
        {
            this.repository.PartidoRepository.IniciarPartido(dto.idPartido);
        }

        public void ActualizarMarcador(int idPartido, int idJugador)
        {
            DtoPartido partido = this.repository.PartidoRepository.GetPartido(idPartido);
            DtoTranscursoPartido transcurso = this.repository.TranscursoRespository.getTranscurso(idPartido);
            if (partido != null)
            {
                if (transcurso != null)
                {
                    transcurso.nuOrdenPartido++;
                }
                else
                {
                    transcurso = new DtoTranscursoPartido();
                    transcurso.nuOrdenPartido = 1;
                    transcurso.idPartido = partido.idPartido;
                }

                if (partido.idJugador1 == idJugador)
                {
                    partido.idJugador1++;
                    transcurso.puntoJugador1 = 1;
                }
                else
                {
                    partido.PuntosJugador2++;
                    transcurso.puntoJugador2 = 1;
                }

            }
            
        }

        private List<String> Validate(DtoPartido dto)
        {
            List<string> colErrores = new List<string>();
            if (!this.repository.JugadorRepository.existeJugador(dto.idJugador1))
                colErrores.Add("El jugador 1 no existe");
            if (!this.repository.JugadorRepository.existeJugador(dto.idJugador2))
                colErrores.Add("El jugador 2 no existe");
            if (this.repository.TorneoRepository.ExisteTorneo(dto.idTorneo))
                colErrores.Add("Verifique que el torneo exista");
            return colErrores;
        }
    }
}
