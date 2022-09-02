using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Windows.Forms;

namespace LibParametro
{
    public class ClsParametro
    {
        #region "Atributos"
        private String strServidor;
        private String strBaseDatos;
        private String strUsuario;
        private String strPassword;
        private String strError;
        private String strCadenaCnx;
        private String strArchivo;

        private XmlDataDocument objDcto;
        private XmlNode objNodo;
        #endregion

        #region "Constructor"
        ///<summary>
        ///Constructor de la Clase
        ///</summary>
        public ClsParametro()
        {
            objDcto = new XmlDataDocument();
            strArchivo = "";
        }
        #endregion

        #region "Propiedades"
        ///<summary>
        ///Retorna la cadena de error
        ///</summary>
        public String Error
        {
            get { return strError; }
            set { strError = value; }
        }

        ///<summary>
        ///Retorna la cadena de conexion a la BD.
        ///</summary>
        public String CadenaConexion
        {
            get { return strCadenaCnx; }
            set { strCadenaCnx = value; }
        }
        #endregion

        #region "Metodos Publicos"
        ///<summary>
        ///Construye la Cadena de Conexion a la BD
        ///</summary>
        ///<returns>Retorna un Booleano acorde a su Ejecucion</returns>
        public bool CrearConexion()
        {
            if (strArchivo == "")
            {
                try
                {
                    string strNombreArchivo;
                    strNombreArchivo = AppDomain.CurrentDomain.BaseDirectory;
                    strNombreArchivo = strNombreArchivo.Substring(0, strNombreArchivo.Length - 1);
                    if (strNombreArchivo.LastIndexOf("/") > 0)
                    {
                        //Es una aplicacion windows
                        strArchivo = strNombreArchivo.Replace("/", "\\");
                        strArchivo = strArchivo + "\\ConexionBD.xml";
                    }
                    else
                    {
                        //Es una aplicacion web
                        strArchivo = Application.StartupPath + "\\ConexionBD.xml";
                    }
                    objDcto.Load(strArchivo);
                    objNodo = objDcto.SelectSingleNode("//Servidor");
                    strServidor = objNodo.InnerText;

                    objNodo = objDcto.SelectSingleNode("//BaseDatos");
                    strBaseDatos = objNodo.InnerText;

                    objNodo = objDcto.SelectSingleNode("//Usuario");
                    strUsuario = objNodo.InnerText;

                    objNodo = objDcto.SelectSingleNode("//Password");
                    strPassword = objNodo.InnerText;

                    strCadenaCnx = "Data Source=" + strServidor +
                                    ";Initial Catalog=" + strBaseDatos +
                                    ";User Id=" + strUsuario +
                                    ";Password=" + strPassword +
                                    ";Integrated Security=SSPI";
                    return true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    return false;
                }
            }
            else
            {
                strError = "Archivo No Valido";
                return false;
            }
        }
        #endregion
    }
}
