using System;
using System.Collections.Generic;
using System.Data;
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

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para BuscarContrato.xaml
    /// </summary>
    public partial class BuscarContrato : Window
    {

        

        public BuscarContrato()
        {
            InitializeComponent();

            


        }


        //llenar tabla

        private void LlenarTabla(IEnumerable<Contratos> listado) {
            DataTable tablita = new DataTable();

            tablita.Columns.Add("Id",typeof(string));
            tablita.Columns.Add("Creación", typeof(string));
            tablita.Columns.Add("Termino", typeof(string));
            tablita.Columns.Add("Titular",typeof(string));
            tablita.Columns.Add("Plan", typeof(string));
            tablita.Columns.Add("Poliza", typeof(string));
            tablita.Columns.Add("Inicio Vig", typeof(string));
            tablita.Columns.Add("Fin Vig", typeof(string));
            tablita.Columns.Add("Vig", typeof(string));
            tablita.Columns.Add("Salud",typeof(string));
            tablita.Columns.Add("Prima Anual", typeof(string));
            tablita.Columns.Add("Prima Mensual", typeof(string));
            tablita.Columns.Add("Observaciones", typeof(string));
            tbl_contrato.IsItemItsOwnContainer(tablita);

        }
    }
}
