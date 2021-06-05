using CommonSolution.DTO;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PartidoRepository
    {
        public PartidoRepository()
        {
            this.partidoMapper = new PartidoMapper();
            this.transcursoMapper = new TranscursoMapper();
        }

        private PartidoMapper partidoMapper;
        private TranscursoMapper transcursoMapper;

        public void NuevoPartido(DtoPartido dto)
        {
            Partido partido = this.partidoMapper.mapToEntity(dto);
            using (DBEntities context = new DBEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.Partido.Add(partido);
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception)
                    {
                        trann.Rollback();
                    }

                }
            }
        }
        //Ejercicio 2
        public void IniciarPartido(int id)
        {
            using (DBEntities context = new DBEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.Partido.AsNoTracking().FirstOrDefault(i => i.idPartido == id).FechaHoraInicio = DateTime.Now;
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public DtoPartido GetPartido(int idPartido)
        {
            DtoPartido par = null;
            using (DBEntities context= new DBEntities())
            {
                par = this.partidoMapper.mapToDto(context.Partido.AsNoTracking().FirstOrDefault(i => i.idPartido == idPartido));
            }
            return par;
        }

        //Ejercicio 3
        public void ActualizarMarcador(DtoPartido partido, DtoTranscursoPartido transcursoPartido)
        {
            using (DBEntities context = new DBEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Partido par= context.Partido.AsNoTracking().FirstOrDefault(i => i.idPartido == partido.idPartido);
                        par.PuntosJugador1 = partido.PuntosJugador1;
                        par.PuntosJugador2 = partido.PuntosJugador2;                        
                        context.TranscursoPartido.Add(this.transcursoMapper.mapToEntity(transcursoPartido));
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception)
                    {
                        trann.Rollback();
                    }
                }
            }
        }


        public int jugadorGanadorPartido(int idPartido)
        {
            DtoPartido dto = this.GetPartido(idPartido);
            if (dto.PuntosJugador1 > dto.PuntosJugador2)
            {
                return dto.idJugador1;
            }
            else
            {
                return dto.idJugador2;
            }
        }

        //Ejercicio 5
        public void PartidosPorTorneo()
        {
            List<DtoPartidosTorneo> colPartidos = new List<DtoPartidosTorneo>();
            using (DBEntities context = new DBEntities())
            {
                colPartidos = (from par in context.Partido
                                     where par.FechaHoraFin != null
                                     group par by par.idPartido into pargr
                                     select new DtoPartidosTorneo
                                     {
                                         idProducto = pargr.Key,
                                         cantidad = pargr.Count()
                                     }).ToList() ;
            }
        }

        



    }
}
