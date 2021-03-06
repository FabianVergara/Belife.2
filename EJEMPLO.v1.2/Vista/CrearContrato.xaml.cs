﻿using System;
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
                Contratos Con = new Contratos();
                if (Con.buscar(txt_titular.Text) == true) {
                    Con = new DALC.Contrato();
                    Biblioteca.Entidades.Planes Plan;
                    Plan = new Planes();
                    Biblioteca.Entidades.Tarificador Tar;
                    Tar = new Tarificador();

                    
                   

                    
                //_____________________________________________________________________________________________________________                
                DateTime fechahoy = DateTime.Now;
                string formatoDeOro = fechahoy.ToString("YYYYMMDDHHmmSS");
                    //validar formato fecha antes de guardar
                    String aaaa = formatoDeOro.Substring(0, 4);
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
                            string mm;
                            if (minutos < 10)
                            {
                                mm = string.Concat("0",minutos);
                            }
                            else
                            {
                                mm = minutos.ToString();
                            }
                            string ss;
                            if (segundos < 10)
                            {
                                ss = string.Concat("0", segundos);
                            }
                            else
                            {
                                ss = segundos.ToString();
                            }
//______________________________________________________________________________________________________________________________
                    int yyyy = int.Parse(aaaa) + 1;//para la fecha de fin de vigencia
                    DateTime fechaCreacion = DateTime.Parse((string.Concat(aaaa, MM, DD, hh, mm, ss)));
                    string fecha = fechaCreacion.ToString("YYYYMMDDHHmmSS");
                    //Con.Numero es automatico en la BD
                    Con.titular = txt_titular.Text;
                    Con.PlanAsociado = cbo_plan.SelectedIndex + 1;
                    /*               if(cbo_plan.SelectedItem.Equals("Vida Inicial"))
               { Con.PlanAsociado = "VID01"; }
               else
               {
                   if (cbo_plan.SelectedItem.Equals("Vida Total"))
                   {
                       Con.PlanAsociado = "VID02";
                   }
                   else
                   {
                       if (cbo_plan.SelectedItem.Equals("Vida Conductor"))
                       {
                           Con.PlanAsociado = "VID03";
                       }
                       else
                       {
                           if (cbo_plan.SelectedItem.Equals("Vida Senior"))
                           {
                               Con.PlanAsociado = "VID04";
                           }
                           else
                           {
                               if (cbo_plan.SelectedItem.Equals("Vida Ahorro"))
                               {
                                   Con.PlanAsociado = "VID05";
                               }

                           }
                       }
                   }
               }
               */
                    Con.Creacion = fecha;
                    Con.InicioVigencia = fecha;
                    DateTime fechaFinVig = DateTime.Parse((string.Concat(yyyy, MM, DD, hh, mm, ss)));
                    Con.FinVigencia = fechaFinVig.ToString("YYYYMMDDHHmmSS");
                    Con.EstaVigente = true;
                    //si se realiza en la biblioteca de entidades aqui no se realiza
                    Con.PrimaAnual = Tar.calculoPrimasanual(Con.PlanAsociado,Con.Titular);//debe retornar valor y pasarlo a la primaanual
                    Con.PrimaMensual = Tar.calculoPrimaMensual(Con.PlanAsociado, Con.Titular);
                    Con.Observaciones = txt_obs.Text;

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
