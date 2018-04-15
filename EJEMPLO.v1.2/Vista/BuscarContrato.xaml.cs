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

        DataTable tablita = new DataTable();

        public BuscarContrato()
        {
            InitializeComponent();

            tablita.Columns.Add("Id");
            tablita.Columns.Add("Creación");
            tablita.Columns.Add("Termino");
            tablita.Columns.Add("Titular");
            tablita.Columns.Add("Plan");
            tablita.Columns.Add("Poliza");
            tablita.Columns.Add("Inicio Vig");
            tablita.Columns.Add("Fin Vig");
            tablita.Columns.Add("Vig");
            tablita.Columns.Add("Salud");
            tablita.Columns.Add("Prima Anual");
            tablita.Columns.Add("Prima Mensual");
            tablita.Columns.Add("Observaciones");
            tbl_contrato.IsItemItsOwnContainer(tablita);


        }
    }
}
