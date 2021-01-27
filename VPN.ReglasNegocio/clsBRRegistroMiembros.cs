using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPN.EntidadesNegocio;
using VPN.DatosNegocio;
using System.Data;

namespace VPN.ReglasNegocio
{
    public class clsBRRegistroMiembros
    {

        private readonly clsDARegistroMiembros clsDARegistroMiembros = new clsDARegistroMiembros();
        public void Guardar(clsBERegistroMiembros objMiembros)
        {
            clsDARegistroMiembros.Guardar(objMiembros);
        }

        public DataTable Consultar()
        {
          return  clsDARegistroMiembros.Consultar();
        }

        public DataTable Buscar(string cedula, string nombre)
        {
            return clsDARegistroMiembros.Buscar(cedula, nombre);
        }

        public DataTable LlenarMaestro()
        {
            return clsDARegistroMiembros.LlenarMaestro();
        }

        public int ConsultarDisponibilidadxCelebracionId(int pCelebracionId)
        {
            return clsDARegistroMiembros.ConsultarDisponibilidadxCelebracionId(pCelebracionId);
        }

        public void GuadarTemperatura(string iDMiembro, string Temperatura)
        {
            clsDARegistroMiembros.GuardarTemperatura(iDMiembro,Temperatura);
        }
    }
}
