using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class Repository
    {
        public Repository()
        {
            this.zonaRepository = new ZonaRepository();
            this.usuarioRepository = new UsuarioRepository();
            this.reclamoRepository = new ReclamoRepository();
        }

        private ZonaRepository zonaRepository;
        private UsuarioRepository usuarioRepository;
        private ReclamoRepository reclamoRepository;

        public ZonaRepository ZonaRepository { get => zonaRepository; }
        public UsuarioRepository UsuarioRepository { get => usuarioRepository; }
        public ReclamoRepository ReclamoRepository { get => reclamoRepository; }
    }
}
