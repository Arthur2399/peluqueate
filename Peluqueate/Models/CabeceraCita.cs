using System;
using System.Collections.Generic;
using System.Text;

namespace Peluqueate.Models
{
    class CabeceraCita
    {
        public int id_serviciocabecera { get; set; }
        public int id_usuarios { get; set; }
        public int id_local { get; set; }
        public string sercab_fecha { get; set; }
        public string sercab_hora { get; set; }
    }
}
