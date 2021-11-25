using System;
using System.Collections.Generic;
using System.Text;

namespace Peluqueate.Models
{
    class ServiciosEmpleados
    {
        public int id_ser_emp { get; set; }
        public int id_empleados { get; set; }
        public int id_servicio { get; set; }
        public string empe_nombre { get; set; }
        public int id_local { get; set; }
        public string ser_costo { get; set; }
        public string ser_tiempo { get; set; }
        public string ser_servicio { get; set; }
        public string ser_tporol { get; set; }

    }
}
