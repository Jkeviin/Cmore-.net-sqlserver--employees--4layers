using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibConexionBD;
using System.Windows.Forms;

using System.Web.UI.WebControls;

namespace LibLlenarGrid
{
    public class ClsLlenarGrid
    {
        #region "CONSTRUCTOR"
        public ClsLlenarGrid() {
            strNombreTabla = "";
            strSQL = "";
            strError = "";
        }
        #endregion

        #region "ATRIBUTOS"
        private string strNombreTabla;
        private string strSQL;
        private string strError;
        #endregion

        #region"PROPIEDADES"
        public string NombreTabla {
            get { return strNombreTabla; }
            set { strNombreTabla = value; }
        }
        public string SQL {
            get { return strSQL; }
            set { strSQL = value; }
        }
        public string Error
        {
            get { return strError; }
            set { strError = value; }
        }
        #endregion

        #region"METODOS PUBLICOS"
        public bool LlenarGrid(DataGridView grdGenerico)
        {
            if (strSQL == "") {
                strError = "debe definir una instruccion SQL";
            }
            ClsConexion objConexionBD = new ClsConexion();
            if (strNombreTabla == "") {
                strNombreTabla = "LlenarGrid";
            }
            if (objConexionBD.LlenarDataSet(strNombreTabla, strSQL, false))
            {
                grdGenerico.DataSource = objConexionBD.DataSet_Retornado.Tables[strNombreTabla];
                objConexionBD.CerrarConexion();
                objConexionBD = null;
                return true;
            }
            else
            {
                strError = objConexionBD.Error;
                objConexionBD.CerrarConexion();
                objConexionBD = null;
                return false;
            }
        }
        public bool LlenarGridWeb(System.Web.UI.WebControls.GridView grdGenerico)
        {
            if (strSQL == "")
            {
                strError = "Debe definir una instruccion SQL";
                return false;
            }
            ClsConexion objConexionBD = new ClsConexion();
            if (strNombreTabla == "")
            {
                strNombreTabla = "DatosGridWeb";
            }
            if (objConexionBD.LlenarDataSet(strNombreTabla, strSQL, false))
            {
                grdGenerico.DataSource = objConexionBD.DataSet_Retornado.Tables[strNombreTabla];
                grdGenerico.DataBind();
                objConexionBD.CerrarConexion();
                objConexionBD = null;
                return true;
            }
            else
            {
                strError = objConexionBD.Error;
                objConexionBD.CerrarConexion();
                objConexionBD = null;
                return false;
            }
        }


        #endregion
    }
}
