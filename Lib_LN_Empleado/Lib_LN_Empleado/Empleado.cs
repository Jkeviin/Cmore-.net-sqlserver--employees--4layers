using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibConexionBD;

namespace Lib_LN_Empleado
{
    public class Empleado
    {
        #region Atributos
        private string id_Emp;
        private string nombre;
        private string apellido;
        private string telefono;
        private double salario;
        private string error;
        #endregion
        #region Propiedades
        public string Id_Emp { get => id_Emp; set => id_Emp = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public double Salario { get => salario; set => salario = value; }
        public string Error { get => error; set => error = value; }
        #endregion
        #region Metodos Publicos
        public bool grabar_empleado()
        { 
            ClsConexion Objc = new ClsConexion();
            string sentencia = "execute USP_insertar_emp '" + id_Emp + "','" + nombre + "','" + apellido + "','" + telefono + "'," + salario;
            if (!Objc.EjecutarSentencia(sentencia, false))
            {
                error = Objc.Error;
                Objc = null;
                return false;
            }
            error = "Se guardó existosamente";
            Objc = null;
            return true;
        }

        public bool actualizar_empleado()
        {
            ClsConexion Objc = new ClsConexion();
            string sentencia = "execute USP_actualizar_emp '" + id_Emp + "','" + nombre + "','" + apellido + "','" + telefono + "'," + salario;
            if (!Objc.EjecutarSentencia(sentencia, false))
            {
                error = Objc.Error;
                Objc = null;
                return false;
            }
            error = "Se actualizó existosamente";
            Objc = null;
            return true;
        }

        public bool eliminar_empleado()
        {
            ClsConexion Objc = new ClsConexion();
            string sentencia = "USP_eliminar_emp '" + id_Emp + "'";
            if (!Objc.EjecutarSentencia(sentencia, false))
            {
                error = Objc.Error;
                Objc = null;
                return false;
            }
            error = "Se eliminó exitosamente";
            Objc = null;
            return true;
        }
        #endregion
    }
}