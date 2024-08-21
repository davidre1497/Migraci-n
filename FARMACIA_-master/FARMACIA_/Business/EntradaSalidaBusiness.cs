using ControlMigracionWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMigracionWeb.Business
{
    public class EntradaSalidaBusiness
    {
        private readonly EntradaSalidaDataAccess _entradaSalidaDataAccess;

        public EntradaSalidaBusiness()
        {
            _entradaSalidaDataAccess = new EntradaSalidaDataAccess();
        }

        public List<EntradaSalida> ObtenerEntradasSalidas()
        {
            return _entradaSalidaDataAccess.ObtenerEntradasSalidas();
        }

        public void RegistrarEntradaSalida(EntradaSalida entradaSalida)
        {
            _entradaSalidaDataAccess.RegistrarEntradaSalida(entradaSalida);
        }
    }

    public class UsuarioBusiness
    {
        private readonly UsuarioDataAccess _usuarioDataAccess;

        public UsuarioBusiness()
        {
            _usuarioDataAccess = new UsuarioDataAccess();
        }

        public bool AutenticarUsuario(string username, string password)
        {
            return _usuarioDataAccess.AutenticarUsuario(username, password);
        }

        public void RegistrarUsuario(string nombre, string apellido, string username, string password)
        {
            _usuarioDataAccess.RegistrarUsuario(nombre, apellido, username, password);
        }
    }
}