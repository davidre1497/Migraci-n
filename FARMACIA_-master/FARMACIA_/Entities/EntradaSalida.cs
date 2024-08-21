using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMigracionWeb.Entities
{
    public class EntradaSalida
    {
        public int IdEntradaSalida { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string LugarEntrada { get; set; }
        public string LugarSalida { get; set; }
    }

    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}