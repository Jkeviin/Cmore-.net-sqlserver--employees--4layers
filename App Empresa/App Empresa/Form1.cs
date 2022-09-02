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
