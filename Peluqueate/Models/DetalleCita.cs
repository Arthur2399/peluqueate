using System;
using System.Collections.Generic;
using System.Text;

namespace Peluqueate.Models
{
    internal class DetalleCita
    {
        public int id_serviciodetalle { get; set; }
        public int id_ser_emp { get; set; }
        public int id_serviciocabecera { get; set; }
        public string empe_nombre { get; set; }
        public string empe_apellido { get; set; }

        public string ser_servicio { get; set; }
        public string ser_costo { get; set; }


    }
}
