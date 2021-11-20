using System;
using System.Collections.Generic;
using System.Text;

namespace Peluqueate.Models
{
    class Usuarios
    {
        public int id_usuarios { get; set; }
        public int id_ciudades { get; set; }
        public string user_nombre { get; set; }
        public string user_apellido { get; set; }
        public string user_fechnacimiento { get; set; }
        public string user_email { set; get; }
        public int user_genero { get; set; }
        public string user_foto { get; set; }
    }
}
