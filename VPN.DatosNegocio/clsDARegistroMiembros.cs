using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPN.EntidadesNegocio;

namespace VPN.DatosNegocio
{
    public class clsDARegistroMiembros
    {
       private readonly Database _dbDB = new DatabaseProviderFactory().Create("Instancia ASIEL");

        public void Guardar(clsBERegistroMiembros objMiembros)
        {
            System.Data.Common.DbCommand dbCommandConsulta = null;
            dbCommandConsulta = _dbDB.GetStoredProcCommand("spMiembros_Guardar");
            _dbDB.AddInParameter(dbCommandConsulta, "pCelebracionID", DbType.String, objMiembros.Celebracion);
            _dbDB.AddInParameter(dbCommandConsulta, "pCedula", DbType.String, objMiembros.Cedula);
            _dbDB.AddInParameter(dbCommandConsulta, "pNombre", DbType.String, objMiembros.Nombre);
            _dbDB.AddInParameter(dbCommandConsulta, "pEdad", DbType.String, objMiembros.Edad);
            _dbDB.AddInParameter(dbCommandConsulta, "pCelular", DbType.String, objMiembros.Celular);
            _dbDB.AddInParameter(dbCommandConsulta, "pCorreo", DbType.String, objMiembros.Correo);
            _dbDB.AddInParameter(dbCommandConsulta, "pTipoMiembro", DbType.String, objMiembros.TipoMiembro);
            _dbDB.AddInParameter(dbCommandConsulta, "pSintomasCovid", DbType.String, objMiembros.SintomasCovid);
            _dbDB.AddInParameter(dbCommandConsulta, "pConsentimiento", DbType.String, objMiembros.Consentimiento);
            _dbDB.AddInParameter(dbCommandConsulta, "pFecha", DbType.Date, objMiembros.Fecha);

            _dbDB.ExecuteNonQuery(dbCommandConsulta);
        }

        public void GuardarTemperatura(string iDMiembro, string temperatura)
        {
            System.Data.Common.DbCommand dbCommandConsulta = null;
            dbCommandConsulta = _dbDB.GetStoredProcCommand("spMiembros_Actualizar");
            _dbDB.AddInParameter(dbCommandConsulta, "pMiembroID", DbType.String, iDMiembro);
            _dbDB.AddInParameter(dbCommandConsulta, "pTemperatura", DbType.String, temperatura);
            _dbDB.AddInParameter(dbCommandConsulta, "pFechaUltimaActualizacion", DbType.Date, System.DateTime.Today);

            _dbDB.ExecuteNonQuery(dbCommandConsulta);
        }

        public DataTable Buscar(string cedula, string nombre)
        {
            System.Data.Common.DbCommand dbCommandConsulta = null;
            dbCommandConsulta = _dbDB.GetStoredProcCommand("spMiembros_Consultar");
            _dbDB.AddInParameter(dbCommandConsulta, "pNombre", DbType.String, nombre);
            _dbDB.AddInParameter(dbCommandConsulta, "pCedula", DbType.String, cedula);

            return _dbDB.ExecuteDataSet(dbCommandConsulta).Tables[0];
        }

        public DataTable Consultar()
        {
            System.Data.Common.DbCommand dbCommandConsulta = null;
            dbCommandConsulta = _dbDB.GetStoredProcCommand("spMiembros_Consultar");
            
            return _dbDB.ExecuteDataSet(dbCommandConsulta).Tables[0];
        }

        public DataTable LlenarMaestro()
        {
            System.Data.Common.DbCommand dbCommandConsulta = null;
            dbCommandConsulta = _dbDB.GetStoredProcCommand("spCelebraciones_LlenarMaestro");

            return _dbDB.ExecuteDataSet(dbCommandConsulta).Tables[0];
        }

        public int ConsultarDisponibilidadxCelebracionId(int pCelebracionId)
        {
            System.Data.Common.DbCommand dbCommandConsulta = null;
            dbCommandConsulta = _dbDB.GetStoredProcCommand("spCelebraciones_ConsultarDisponibilidad");
            _dbDB.AddInParameter(dbCommandConsulta, "pCelebracionId", DbType.Int64, pCelebracionId);
            return (int)_dbDB.ExecuteScalar(dbCommandConsulta);
        }
    }
}
