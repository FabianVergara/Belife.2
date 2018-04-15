using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Biblioteca.Entidades;
using Biblioteca.DALC;
namespace Vista
{
    /// <summary>
    /// Lógica de interacción para CrearContrato.xaml
    /// </summary>
    public partial class CrearContrato : Window
    {
        public CrearContrato()
        {
            InitializeComponent();

            List<Planes> Listado = new Planes().ListarPlan();
            foreach (Planes item in Listado)
            {
                cbo_plan.Items.Add(item.Descripcion);
            }


        }

        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            /*Se autogenera 
             * Numero Contrato
             * Creacion fecha
             * inicio vigencia/termino vigencia un año más tarde de entrar en vigencia
             * vigencia(true/false)
             *Prima anual y mensual (a partir del tarificador)
             */
            //debo ingresar rut cliente
            //plan asociado
            //--del plan asociado la poliza es automatica
            //declaracion de salud (si/no)
            //observaciones
            try
            {
                //validar si es cliente
                Contratos con = new Contratos();
                if (con.buscar(txt_titular.Text) == true) { 
                
                String titular = txt_titular.Text;

                DateTime fechahoy = DateTime.Now;
                string formatoDeOro = fechahoy.ToString("YYYYMMDDHHmmSS");
                    //validar formato fecha antes de guardar
                    String aaaa = formatoDeOro.Substring(0, 3);
                    int mes = int.Parse(formatoDeOro.Substring(4,2));
                    int dia = int.Parse(formatoDeOro.Substring(6, 2));
                    int hora = int.Parse(formatoDeOro.Substring(8, 2));
                    int minutos = int.Parse(formatoDeOro.Substring(10, 2));
                    int segundos = int.Parse(formatoDeOro.Substring(-2));
                            string MM;
                            if (mes < 10)
                            {
                                MM = string.Concat("0",mes);//CONCATENO MES CON EL 0
                            }
                            else
                            {
                                MM = mes.ToString();
                            }
                            string DD;
                            if (dia<10)
                            {
                                DD = string.Concat("0", dia);
                            }
                            else
                            {
                                DD = dia.ToString();
                            }
                            string hh;
                            if (hora<10)
                            {
                                hh =string.Concat("0",hora);
                            }
                            else
                            {
                                hh = hora.ToString();
                            }
                            string min;
                            if (minutos < 10)
                            {
                                min = string.Concat("0",minutos);
                            }
                            else
                            {
                                min = minutos.ToString();
                            }
                            string seg;
                            if (segundos < 10)
                            {
                                seg = string.Concat("0", segundos);
                            }
                            else
                            {
                                seg = segundos.ToString();
                            }
                    String fecha_lista = (string.Concat(aaaa, MM, DD, hh, min, seg));
                    String fecha = fecha_lista.ToString("YYYYMMDDHHmmss");
                    
                }
                else
                {
                    MessageBox.Show("El rut ingresado no pertenece a ningun cliente");
                }



            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
