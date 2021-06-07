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
        }

        private ZonaRepository zonaRepository;
        private UsuarioRepository usuarioRepository;

        public ZonaRepository ZonaRepository { get => zonaRepository; }
        public UsuarioRepository UsuarioRepository { get => usuarioRepository; }
    }
}
