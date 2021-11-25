using System;
using System.Collections.Generic;
using System.Text;

namespace Peluqueate.Models
{
    class Empleados
    {
        public int id_empleados { get; set; }
        public int id_local { get; set; }  
        public string empe_nombre { get; set; }
        public string empe_apellido { get; set; }
        public string empe_email { get; set; }
        public string empe_fechnacimiento { set; get; }
        public string empe_foto { get; set; }
        public string loc_nombre { get; set; }
    }
}
