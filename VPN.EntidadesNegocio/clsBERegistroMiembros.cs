using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPN.EntidadesNegocio
{
    public class clsBERegistroMiembros
    {
        public int Celebracion { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public int Celular { get; set; }
        public int Correo { get; set; }
        public int TipoMiembro { get; set; }
        public int SintomasCovid { get; set; }
        public string Temperatura { get; set; }
        public int Consentimiento { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }

    }
}
