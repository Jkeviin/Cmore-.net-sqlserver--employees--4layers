using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_LN_Empleado;
using System.Data.SqlClient;

namespace App_Empresa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btn_agregar_Click(object sender, EventArgs e)
        {

            // Instanciar la logica de negocios
            Empleado objEm = new Empleado();

            //  Crear variables
            String idEmp, nom, apell, tele;
            double salario;

            try
            {
                // Capturar los datos
                idEmp = txt_ident.Text;
                nom = txt_nom.Text;
                apell = txt_apellido.Text;
                tele = txt_telefono.Text;
                salario = Convert.ToDouble(txt_salario.Text);

                // Enviar los valores a la LN
                objEm.Id_Emp = idEmp;
                objEm.Nombre = nom;
                objEm.Apellido = apell;
                objEm.Telefono = tele;
                objEm.Salario = salario;

                if (!objEm.grabar_empleado())
                {
                    MessageBox.Show(objEm.Error);
                    objEm = null;
                    return;
                }
                else
                {
                    MessageBox.Show(objEm.Error);
                    objEm = null;
                    ListarEmpleado();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            // Instanciar la logica de negocios
            Empleado objEm = new Empleado();

            //  Crear variables
            String idEmp, nom, apell, tele;
            double salario;
            try
            {
                // Capturar los datos
                idEmp = txt_ident.Text;
                nom = txt_nom.Text;
                apell = txt_apellido.Text;
                tele = txt_telefono.Text;
                salario = Convert.ToDouble(txt_salario.Text);

                // Enviar los valores a la LN
                objEm.Id_Emp = idEmp;
                objEm.Nombre = nom;
                objEm.Apellido = apell;
                objEm.Telefono = tele;
                objEm.Salario = salario;

                if (!objEm.actualizar_empleado())
                {
                    MessageBox.Show(objEm.Error);
                    objEm = null;
                    return;
                }
                else
                {
                    MessageBox.Show(objEm.Error);
                    objEm = null;
                    ListarEmpleado();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            // Instanciar la logica de negocios
            Empleado objEm = new Empleado();

            //  Crear variables
            String idEmp;
            try
            {
                // Capturar los datos
                idEmp = txt_ident.Text;

                // Enviar los valores a la LN
                objEm.Id_Emp = idEmp;

                if (!objEm.eliminar_empleado())
                {
                    MessageBox.Show(objEm.Error);
                    objEm = null;
                    return;
                }
                else
                {
                    MessageBox.Show(objEm.Error);
                    objEm = null;
                    ListarEmpleado();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarEmpleado();
        }

        private void ListarEmpleado()
        {
            Empleado objNListar = new Empleado();

            if (!objNListar.ListarEmpleado(dgvEmpleado))
            {
                MessageBox.Show(objNListar.Error);
                objNListar = null;
                return;
            }

            objNListar = null;
            return;


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListarEmpleado();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Empleado objEmpl = new Empleado();

            //  Crear variables
            String idEmp;
            try
            {
                SqlDataReader reader;
                // Capturar los datos
                idEmp = txt_ident.Text;

                // Enviar los valores a la LN
                objEmpl.Id_Emp = idEmp;

                if (!objEmpl.Consultar_Emp())
                {
                    MessageBox.Show(objEmpl.Error);
                    objEmpl = null;
                    return;
                }
                else
                {
                    MessageBox.Show(objEmpl.Error);
                    reader = objEmpl.Reader;

                    if (reader.HasRows) {
                        reader.Read();
                        txt_ident.Text = reader.GetString(0);
                        txt_nom.Text = reader.GetString(1);
                        txt_apellido.Text = reader.GetString(2);
                        txt_telefono.Text = reader.GetString(3);
                        txt_salario.Text = Convert.ToString(reader.GetDouble(4));
                        reader.Close();
                    }
                    objEmpl = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
