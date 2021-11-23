using System;
using System.Collections.Generic;
using System.Text;

namespace Peluqueate.Models
{
    class Local
    {
        public int id_local { get; set; }
        public int id_ciudades { get; set; }
        public string loc_nombre { get; set; }
        public string loc_direccion { get; set; }
        public string loc_longitud { get; set; }
        public string loc_latitud { get; set; }

    }
}
